using BUL;
using DTO;
using Guna.UI2.WinForms;
using QLSieuThiMini_Nhom13.UserControls;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Transactions;
using System.Windows.Forms;

namespace QLSieuThiMini_Nhom13
{
    public partial class FrmHoaDon : Form
    {
        SanPhamBUL sanPhamBUL;
        HoaDonBUL hoaDonBUL;
        CTHoaDonBUL cTHoaDonBUL;
        KhachHangBUL khachHangBUL;
        NguoiDungBUL nguoiDungBUL;
        KhuyenMaiBUL khuyenMaiBUL;
        NhomSanPhamKMBUL nhomSanPhamKMBUL;

        Guna2MessageDialog message;
        string TenTK;
        public FrmHoaDon(string tenTK)
        {
            InitializeComponent();

            sanPhamBUL = new SanPhamBUL();
            hoaDonBUL = new HoaDonBUL();
            khachHangBUL = new KhachHangBUL();
            cTHoaDonBUL = new CTHoaDonBUL();
            nguoiDungBUL = new NguoiDungBUL();
            khuyenMaiBUL = new KhuyenMaiBUL();
            nhomSanPhamKMBUL = new NhomSanPhamKMBUL();

            TenTK = tenTK;
            txtTKNV.Text = tenTK;
            //FrmMain f = new FrmMain();
            message = new Guna2MessageDialog
            {
                Style = MessageDialogStyle.Light,
                //Parent = this.Parent.
            };
            //message.Parent = this;
        }

        private void FrmHoaDonTest_Load(object sender, EventArgs e)
        {
            ShowUserControl();
            btnChonSP.Enabled = false;
            btnThanhToan.Enabled = false;

            themTabPage();
            btnApDung.Enabled = false;

        }
        private void ShowUserControl(string text = null)
        {
            int x = 0; // Tọa độ X của UserControl đầu tiên
            int y = 0; // Tọa độ Y của UserControl đầu tiên
            int controlSpacing = 3; // Khoảng cách giữa các UserControl
            int controlWidth = 120; // Chiều rộng của UserControl
            int controlHeight = 150; // Chiều cao của UserControl

            PnlSanPham.Controls.Clear();
            List<SanPhamDTO> lstDSSanPham = sanPhamBUL.layDSSanPham();
            if (text != null)
            {
                lstDSSanPham = sanPhamBUL.layDSSanPhamTheoTenHoacMa(text);
            }

            foreach (SanPhamDTO sp in sanPhamBUL.layDSSanPham())
            {
                // Tạo một instance của UserControl
                SanPham_UC myControl = new SanPham_UC(sp.MaSP, sp.TenSP, int.Parse(sp.GiaBan.ToString()), sp.HinhAnh);
                //myControl.Click += new EventHandler(SanPham_UC_Click);

                myControl.Clicked += SanPham_UC_Click;

                myControl.AutoSize = false;
                myControl.Width = controlWidth;
                myControl.Height = controlHeight;

                // Kiểm tra nếu vị trí X cộng với chiều rộng của UserControl vượt quá chiều rộng Panel
                if (x + controlWidth > PnlSanPham.ClientSize.Width)
                {
                    x = 0; // Đặt lại vị trí X về 0 (xuống dòng)
                    y += controlHeight + controlSpacing; // Tăng vị trí Y để xuống dòng
                }

                myControl.Location = new Point(x, y);
                PnlSanPham.Controls.Add(myControl);
                myControl.BringToFront();

                // Tính vị trí X cho UserControl tiếp theo
                x += controlWidth + controlSpacing;
            }

            // Bật cuộn khi cần
            guna2VScrollBar1.BindingContainer = PnlSanPham;
            PnlSanPham.AutoScroll = true;
        }

        private SanPham_UC selectedControl = null;
        string maSP, tenSP, giaBan;
        private void SanPham_UC_Click(object sender, EventArgs e)
        {
            SanPham_UC control = sender as SanPham_UC;

            if (control != null)
            {
                // Xóa viền của UserControl trước đó nếu không phải là control hiện tại
                if (selectedControl != null && selectedControl != control)
                {
                    selectedControl.BorderStyle = BorderStyle.None;
                }

                // Cập nhật viền cho UserControl được chọn
                control.BorderStyle = BorderStyle.FixedSingle;
                selectedControl = control; // Ghi nhận control hiện tại

                // Kích hoạt nút "Chọn"
                btnChonSP.Enabled = true;

                maSP = control.MaSP;
                tenSP = control.TenSP;
                giaBan = control.GiaSP.ToString();
            }
        }

        //string maHD = "";
        private void themTabPage()
        {
            if (tabHoaDon.TabCount >= 4)
            {
                message.Buttons = MessageDialogButtons.OK;
                message.Icon = MessageDialogIcon.Error;
                message.Parent = this.ParentForm;
                DialogResult rs = message.Show("Chỉ được xử lý tối đa 4 hóa đơn cùng lúc!", "Thông Báo");
                return;
            }

            TabPage newPage = new TabPage();

            // Đặt tiêu đề cho TabPage
            newPage.Text = "Hóa đơn " + (tabHoaDon.TabPages.Count + 1);
            newPage.BackColor = Color.White;

            // Thêm TabPage vào TabControl
            tabHoaDon.TabPages.Add(newPage);

            // Chuyển sang TabPage vừa tạo
            tabHoaDon.SelectedTab = newPage;
            txtNgayLap.Text = string.Empty;

            txtTimKH.Text = string.Empty;
            txtTimKH.ReadOnly = false;
            txtTimKH.IconRight = Properties.Resources.Search;
            txtTimKH.IconLeft = Properties.Resources.Plus;
            txtDiemTL.Text = string.Empty;
            isCloseIconVisible = false;  // Reset trạng thái

            //maHD = hoaDonBUL.TaoMaHD();

            //// thêm thông tin cho hóa đơn thuộc tabpage tương ứng
            //TabPage t = tabHoaDon.TabPages[selectedIndex];
            //int tab = selectedIndex + 1;
            //if (tab == 1)
            //{
            //    hdDTO1.MaHD = maHD;
            //    hdDTO1.NgayLap = DateTime.Now;
            //}
            //else if (tab == 2)
            //{
            //    hdDTO2.MaHD = maHD;
            //    hdDTO2.NgayLap = DateTime.Now;
            //}
            //else if (tab == 3)
            //{
            //    hdDTO3.MaHD = maHD;
            //    hdDTO3.NgayLap = DateTime.Now;
            //}
            //else
            //{
            //    hdDTO4.MaHD = maHD;
            //    hdDTO4.NgayLap = DateTime.Now;
            //}
        }

        private void btnThem_Click(object sender, EventArgs e)
        {
            if (xemDS)
            {
                //TabPage page = tabHoaDon.TabPages[selectedIndex];

                tabHoaDon.TabPages.RemoveAt(0);

                txtMaHD.Clear();
                txtTKNV.Text = TenTK;
                txtNgayLap.Clear();
                txtTimKH.Clear();
                txtDiemTL.Text = string.Empty;
                txtMaHD.Clear();
                txtTienNhan.Clear();
                lbTienThua.Text = string.Empty;
                lbGiaTriHD.Text = string.Empty;
                lbTongTien.Text = string.Empty;
                lbTietKiemHV.Text = string.Empty;
                txtTongSoHang.Text = string.Empty;
                //btnChonSP.Enabled = false;
                btnThanhToan.Enabled = false;
                k = null;
                btnApDung.Enabled = false;
                isDiscountApplied = false;

                txtTimKH.Enabled = true;
                txtTienNhan.Enabled = true;

                if (isCloseIconVisible)
                {
                    txtTimKH.Text = string.Empty;
                    txtTimKH.ReadOnly = false;
                    txtTimKH.IconRight = Properties.Resources.Search;
                    txtTimKH.IconLeft = Properties.Resources.Plus;
                    txtDiemTL.Text = string.Empty;
                    isCloseIconVisible = false;  // Reset trạng thái
                }

                xemDS = false;
            }

            themTabPage();
        }

        List<CTHoaDonDTO> lstSP_HD1 = new List<CTHoaDonDTO>();
        List<CTHoaDonDTO> lstSP_HD2 = new List<CTHoaDonDTO>();
        List<CTHoaDonDTO> lstSP_HD3 = new List<CTHoaDonDTO>();
        List<CTHoaDonDTO> lstSP_HD4 = new List<CTHoaDonDTO>();

        List<SanPhamHD_UC> lstUCHD1 = new List<SanPhamHD_UC>();
        List<SanPhamHD_UC> lstUCHD2 = new List<SanPhamHD_UC>();
        List<SanPhamHD_UC> lstUCHD3 = new List<SanPhamHD_UC>();
        List<SanPhamHD_UC> lstUCHD4 = new List<SanPhamHD_UC>();

        //List<HoaDonDTO> lstHoaDon = new List<HoaDonDTO>();
        HoaDonDTO hdDTO1 = new HoaDonDTO();
        HoaDonDTO hdDTO2 = new HoaDonDTO();
        HoaDonDTO hdDTO3 = new HoaDonDTO();
        HoaDonDTO hdDTO4 = new HoaDonDTO();

        // tổng sp của 4 list -> dùng để ktra số lượng sp giữa các hd
        List<CTHoaDonDTO> lstSP_4HD;
        private int tinhTongSoSPDaChon(string masp)
        {
            lstSP_4HD = new List<CTHoaDonDTO>();
            lstSP_4HD.AddRange(lstSP_HD1);
            lstSP_4HD.AddRange(lstSP_HD2);
            lstSP_4HD.AddRange(lstSP_HD3);
            lstSP_4HD.AddRange(lstSP_HD4);
            int tongSoSPDaChon = lstSP_4HD.Where(t => t.MaSP == masp).Sum(t => t.SoLuong);
            return tongSoSPDaChon;
        }

        private int soLuong = 0;

        private void themSPVaoHD(List<CTHoaDonDTO> lstSP_HD, List<SanPhamHD_UC> lstUCHD, TabPage page, HoaDonDTO hdDTO)
        {
            int stt = 0;
            //tabPageHD1.Controls.Clear();
            int top = 0;
            soLuong = 1;
            int giaSP = int.Parse(giaBan);

            // them sp vào list
            if (lstSP_HD.Any(t => t.MaSP == maSP))
            {
                capNhatSoLuong(lstSP_HD, maSP, lstUCHD);
            }
            else
            {
                SanPhamDTO sanPhamDTO = sanPhamBUL.layMotSanPham(maSP);

                int tongSPDuocChon = tinhTongSoSPDaChon(maSP) + 1;

                if (tongSPDuocChon > sanPhamDTO.SLTon)
                {
                    message.Buttons = MessageDialogButtons.OK;
                    message.Icon = MessageDialogIcon.Error;
                    message.Parent = this.ParentForm;
                    DialogResult rs = message.Show("Số lượng sản phẩm không đủ!", "Thông Báo");

                    //MessageBox.Show("Số lượng sản phẩm không đủ!", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                // thêm vào list các sp trong hd
                lstSP_HD.Add(new CTHoaDonDTO
                {
                    MaHD = hdDTO.MaHD,
                    MaSP = maSP,
                    DonGia = giaSP,
                    SoLuong = soLuong,
                });

                // thêm sp lên giao diện
                SanPhamHD_UC item = new SanPhamHD_UC(maSP, tenSP, giaSP);
                item.ClickXoa += Item_ClickXoa;
                item.ClickThayDoiSL += Item_ClickThayDoiSL;
                lstUCHD.Add(item);
                page.Controls.Add(item);

                item.SoLuong = soLuong;
                item.ThanhTien = item.SoLuong * item.GiaSP;
                item.Width = page.ClientSize.Width;
                item.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
                //item.Dock = DockStyle.Top;

                // xét vị trí hiện sp
                foreach (Control c in page.Controls)
                {
                    stt++;
                    item.Top = top;
                    item.Left = 0;

                    top = c.Bottom;

                    page.AutoScroll = true;
                }

                item.SoTT = stt;

                txtTongSoHang.Text = stt.ToString();
            }
            //txtTongTien.Text = tinhTongTien(lstSP_HD).ToString("N0");
            capNhatTTHoaDon(lstSP_HD, hdDTO);
        }

        bool flag = true;
        int soLuongCu = 0;
        private void Item_ClickThayDoiSL(object sender, EventArgs e)
        {
            // Kiểm tra xem người dùng đang tăng hay giảm
            NumericUpDown soLuong = sender as NumericUpDown;

            if (soLuong != null)
            {
                SanPhamHD_UC control = soLuong.Parent.Parent.Parent as SanPhamHD_UC;

                SanPhamDTO sanPhamDTO = sanPhamBUL.layMotSanPham(control.MaSP);
                //int tongSPDuocChon = tinhTongSoSPDaChon(control.MaSP) + 1;
                //if (flag)
                int tongSPDuocChon = tinhTongSoSPDaChon(control.MaSP);
                control.TongSoLuong = tongSPDuocChon;

                int soLuongCu = control.SoLuongCu; // Thêm thuộc tính SoLuongCu vào control
                int soLuongMoi = (int)soLuong.Value;

                // Kiểm tra nếu số lượng đang tăng
                if (soLuongMoi > soLuongCu)
                    if (sanPhamDTO.SLTon <= tongSPDuocChon && flag)
                    {
                        message.Buttons = MessageDialogButtons.OK;
                        message.Icon = MessageDialogIcon.Error;
                        message.Parent = this.ParentForm;
                        DialogResult rs = message.Show("Số lượng sản phẩm không đủ!", "Thông Báo");

                        // Khôi phục giá trị cũ nếu vượt quá
                        flag = true;
                        return;
                    }
                flag = true;
                TabPage t = tabHoaDon.TabPages[selectedIndex];
                int tab = selectedIndex + 1;
                CTHoaDonDTO item;
                SanPhamHD_UC sanPhamHD_UC;
                if (tab == 1)
                {
                    sanPhamHD_UC = lstUCHD1.FirstOrDefault(u => u.MaSP == control.MaSP);
                    item = lstSP_HD1.FirstOrDefault(u => u.MaSP == control.MaSP);
                }
                else if (tab == 2)
                {
                    sanPhamHD_UC = lstUCHD2.FirstOrDefault(u => u.MaSP == control.MaSP);
                    item = lstSP_HD2.FirstOrDefault(u => u.MaSP == control.MaSP);
                }
                else if (tab == 3)
                {
                    sanPhamHD_UC = lstUCHD3.FirstOrDefault(u => u.MaSP == control.MaSP);
                    item = lstSP_HD3.FirstOrDefault(u => u.MaSP == control.MaSP);
                }
                else
                {
                    sanPhamHD_UC = lstUCHD4.FirstOrDefault(u => u.MaSP == control.MaSP);
                    item = lstSP_HD4.FirstOrDefault(u => u.MaSP == control.MaSP);
                }

                //SanPhamHD_UC sanPhamHD_UC = lstUCHD.FirstOrDefault(u => u.MaSP == control.MaSP);
                if (sanPhamHD_UC != null)
                {
                    sanPhamHD_UC.SoLuong = (int)soLuong.Value;
                    //soLuongCu = (int)soLuong.Value;
                    sanPhamHD_UC.ThanhTien = sanPhamHD_UC.SoLuong * sanPhamHD_UC.GiaSP;

                    //CTHoaDonDTO item = lstSP_HD1.FirstOrDefault(u => u.MaSP == control.MaSP);
                    item.SoLuong = (int)soLuong.Value;
                    capNhatHD();
                }
            }
        }

        private void capNhatHD()
        {
            TabPage t = tabHoaDon.TabPages[selectedIndex];
            int tab = selectedIndex + 1;
            if (tab == 1)
            {
                capNhatTTHoaDon(lstSP_HD1, hdDTO1);
            }
            else if (tab == 2)
            {
                capNhatTTHoaDon(lstSP_HD2, hdDTO2);
            }
            else if (tab == 3)
            {
                capNhatTTHoaDon(lstSP_HD3, hdDTO3);
            }
            else
            {
                capNhatTTHoaDon(lstSP_HD4, hdDTO4);
            }

        }
        private void Item_ClickXoa(object sender, EventArgs e)
        {
            // xóa ở cả list UC và list DTO và giao diện
            // Hiển thị hộp thoại xác nhận
            message.Buttons = MessageDialogButtons.YesNo;
            message.Icon = MessageDialogIcon.Question;
            message.Parent = this.ParentForm;
            DialogResult rs = message.Show("Bạn có muốn xóa sản phẩm khỏi hóa đơn?", "Thông Báo");

            if (rs == DialogResult.Yes)
            {
                // Lấy nút xóa được nhấn
                Guna2ImageButton btnXoa = sender as Guna2ImageButton;
                if (btnXoa != null)
                {
                    // Lấy UserControl chứa nút xóa
                    SanPhamHD_UC sanPhamHD_UC = btnXoa.Parent.Parent.Parent as SanPhamHD_UC;

                    if (sanPhamHD_UC != null)
                    {
                        // Xóa UserControl khỏi container (xóa khỏi giao diện)
                        TabPage tab = sanPhamHD_UC.Parent as TabPage;
                        sanPhamHD_UC.Parent.Controls.Remove(sanPhamHD_UC);


                        // Cập nhật thứ tự các UserControl
                        capNhatListSanPhamHDUC(tab);

                        // Xóa sản phẩm khỏi danh sách (nếu có)
                        TabPage t = tabHoaDon.TabPages[selectedIndex];
                        int tabIndex = selectedIndex + 1;
                        if (tabIndex == 1)
                        {
                            lstSP_HD1.RemoveAll(sp => sp.MaSP == sanPhamHD_UC.MaSP);
                            lstUCHD1.RemoveAll(sp => sp.MaSP == sanPhamHD_UC.MaSP);
                            capNhatTTHoaDon(lstSP_HD1, hdDTO1);
                        }
                        else if (tabIndex == 2)
                        {
                            lstSP_HD2.RemoveAll(sp => sp.MaSP == sanPhamHD_UC.MaSP);
                            lstUCHD2.RemoveAll(sp => sp.MaSP == sanPhamHD_UC.MaSP);
                            capNhatTTHoaDon(lstSP_HD2, hdDTO2);
                        }
                        else if (tabIndex == 3)
                        {
                            lstSP_HD3.RemoveAll(sp => sp.MaSP == sanPhamHD_UC.MaSP);
                            lstUCHD3.RemoveAll(sp => sp.MaSP == sanPhamHD_UC.MaSP);
                            capNhatTTHoaDon(lstSP_HD3, hdDTO3);
                        }
                        else
                        {
                            lstSP_HD4.RemoveAll(sp => sp.MaSP == sanPhamHD_UC.MaSP);
                            lstUCHD4.RemoveAll(sp => sp.MaSP == sanPhamHD_UC.MaSP);
                            capNhatTTHoaDon(lstSP_HD4, hdDTO4);
                        }

                        // kh còn sản phẩm và chỉ tồn tại 1 tab thì bật nút xem DS Hoa don

                        bool enable = false;
                        foreach (SanPhamHD_UC sp in t.Controls.OfType<SanPhamHD_UC>())
                        {
                            enable = true;
                            break;
                        }

                        if (enable)
                        {
                            btnXemDS.Enabled = false;
                        }
                        else
                        {
                            btnXemDS.Enabled = true;
                            //if (tabHoaDon.TabPages.Count > 1)
                            //    tabHoaDon.TabPages.RemoveAt(selectedIndex); // Xóa page
                        }
                    }
                }
            }
        }
        private void capNhatListSanPhamHDUC(TabPage tabpage)
        {
            int stt = 1; // Bắt đầu từ số thứ tự 1
            int currentTop = 0;
            foreach (Control control in tabpage.Controls.OfType<SanPhamHD_UC>())
            {
                control.Dock = DockStyle.None; // Bỏ DockStyle
                control.Top = currentTop;      // Cập nhật vị trí Top
                currentTop += control.Height; // Tăng vị trí cho UserControl tiếp theo
                SanPhamHD_UC sanPhamUC = control as SanPhamHD_UC;
                if (sanPhamUC != null)
                {
                    sanPhamUC.SoTT = stt; // Cập nhật số thứ tự (hoặc Label)
                    stt++; // Tăng số thứ tự
                }
            }
        }

        private void capNhatSoLuong(List<CTHoaDonDTO> lstSP_HD, string masp, List<SanPhamHD_UC> lstUCHD)
        {
            // cập nhật ở cả list UC và list DTO
            //// Lấy dòng hiện tại trong dgv tương ứng với mã sản phẩm
            CTHoaDonDTO ctsanPham = lstSP_HD.FirstOrDefault(sp => sp.MaSP == masp);
            flag = false;
            if (ctsanPham != null)
            {
                // Lấy số lượng cũ từ danh sách dssp và cộng thêm số lượng mới
                int soLuongMoi = ctsanPham.SoLuong + 1;
                SanPhamDTO spdto = sanPhamBUL.layMotSanPham(masp);

                int tongSPDuocChon = tinhTongSoSPDaChon(masp);
                if (tongSPDuocChon >= spdto.SLTon)
                {
                    message.Buttons = MessageDialogButtons.OK;
                    message.Icon = MessageDialogIcon.Error;
                    message.Parent = this.ParentForm;
                    DialogResult rs = message.Show("Số lượng sản phẩm không đủ!", "Thông Báo");
                    flag = true;
                    //MessageBox.Show("Số lượng sản phẩm không đủ!", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                ctsanPham.SoLuong = soLuongMoi;

                SanPhamHD_UC sanPhamHD_UC = lstUCHD.FirstOrDefault(u => u.MaSP == masp);
                if (sanPhamHD_UC != null)
                {
                    sanPhamHD_UC.SoLuong = soLuongMoi;
                    sanPhamHD_UC.TongSoLuong = tongSPDuocChon;
                    //if (flag) return;
                    sanPhamHD_UC.ThanhTien = sanPhamHD_UC.SoLuong * sanPhamHD_UC.GiaSP;
                    //sanPhamHD_UC.Refresh();
                }
            }
        }

        private double tinhTongTien(List<CTHoaDonDTO> lstSP_HD)
        {
            double tongTien = 0;
            foreach (CTHoaDonDTO item in lstSP_HD)
            {
                tongTien += item.DonGia * item.SoLuong;
            }
            return tongTien;
        }

        double tongTien = 0;
        private void capNhatTTHoaDon(List<CTHoaDonDTO> lstSP_HD, HoaDonDTO hoaDonDTO)
        {
            txtMaHD.Text = hoaDonDTO.MaHD;
            txtNgayLap.Text = hoaDonDTO.NgayLap.ToString("dd/MM/yyyy HH:mm:ss");

            if (hoaDonDTO.MaKH != null)
            {
                txtTimKH.IconLeft = Properties.Resources.User;
                txtTimKH.IconRight = Properties.Resources.Close;
                txtTimKH.ReadOnly = true;

                KhachHangDTO khachHangDTO = khachHangBUL.layKHTheoMa(hoaDonDTO.MaKH);
                txtDiemTL.Text = khachHangDTO.diemTichLuy.ToString();
                txtTimKH.Text = khachHangDTO.tenKH;
                guna2HtmlLabel1.Focus();
                isCloseIconVisible = true;
            }
            else
            {
                txtTimKH.Text = string.Empty;
                txtTimKH.ReadOnly = false;
                txtTimKH.IconRight = Properties.Resources.Search;
                txtTimKH.IconLeft = Properties.Resources.Plus;
                txtDiemTL.Text = string.Empty;
                isCloseIconVisible = false;  // Reset trạng thái
            }
            lbGiaGiam.Text = lstSP_HD.Where(t => t.MaSP.StartsWith("KM")).Sum(t => t.DonGia * t.SoLuong).ToString();
            txtTongSoHang.Text = lstSP_HD.Count(sp => sp.MaSP.StartsWith("SP")).ToString();
            tongTien = lstSP_HD.Where(t => t.MaSP.StartsWith("SP")).Sum(t => t.DonGia * t.SoLuong);
            lbGiaTriHD.Text = tongTien.ToString("N0");
            lbTietKiemHV.Text = "0";
            double giaG = lbGiaGiam.Text.Length == 0 ? 0 : double.Parse(lbGiaGiam.Text);
            lbTongTien.Text = (tongTien - int.Parse(lbTietKiemHV.Text.Replace(",", "")) + giaG).ToString("N0");
            isDiscountApplied = false;
            //btnApDung đổi icon nút áp dụng


            txtTienNhan.Clear();
            lbTienThua.Text = string.Empty;

            bool enable = false;
            TabPage page = tabHoaDon.TabPages[selectedIndex];
            int tab = selectedIndex + 1;
            foreach (SanPhamHD_UC sp in page.Controls.OfType<SanPhamHD_UC>())
            {
                enable = true;
                break;
            }
            btnThanhToan.Enabled = enable;

            if (tabHoaDon.TabPages.Count == 1)
            {
                btnXemDS.Enabled = !enable;
            }
        }

        private void btnThanhToan_Click(object sender, EventArgs e)
        {
            if (lbTienThua.Text.Length == 0)
            {
                message.Buttons = MessageDialogButtons.OK;
                message.Icon = MessageDialogIcon.Error;
                message.Parent = this.ParentForm;
                message.Show("Tiền nhận không hợp lệ!", "Thông Báo");
                return;
            }

            TabPage t = tabHoaDon.TabPages[selectedIndex];
            int tab = selectedIndex + 1;
            if (tab == 1)
            {
                thanhToanHoaDon(lstSP_HD1);
            }
            else if (tab == 2)
            {
                thanhToanHoaDon(lstSP_HD2);
            }
            else if (tab == 3)
            {
                thanhToanHoaDon(lstSP_HD3);
            }
            else
            {
                thanhToanHoaDon(lstSP_HD4);
            }



            bool enable = false;
            foreach (SanPhamHD_UC sp in t.Controls.OfType<SanPhamHD_UC>())
            {
                enable = true;
                break;
            }

            if (enable)
            {
                btnXemDS.Enabled = false;
            }
            else
            {
                btnXemDS.Enabled = true;
                //if (tabHoaDon.TabPages.Count > 1)
                //    tabHoaDon.TabPages.RemoveAt(selectedIndex); // Xóa page
            }
        }

        private void thanhToanHoaDon(List<CTHoaDonDTO> lstSPHD)
        {
            message.Buttons = MessageDialogButtons.YesNo;
            message.Icon = MessageDialogIcon.Question;
            message.Parent = this.ParentForm;
            DialogResult rs = message.Show("Bạn có muốn thêm hóa đơn?", "Thông Báo");
            if (rs == DialogResult.Yes)
            {
                int dtl = 0;
                double diemTich = 0;

                DateTime ngayLap;
                DateTime.TryParse(txtNgayLap.Text, out ngayLap);

                // trg hợp áp dụng điểm (có giá giảm) (2TH:  1 là áp dụng chưa hết điểm, 2 là áp dụng hết điểm)
                double giaGiam = 0;
                double diemConLai = 0;
                if (isDiscountApplied)
                {
                    giaGiam = k.diemTichLuy; // đổi điểm thành tiền
                    if (giaGiam > tongTien)
                    {
                        giaGiam = tongTien;
                        diemConLai = k.diemTichLuy - giaGiam;
                        k.diemTichLuy = int.Parse(diemConLai.ToString()); // cập nhật điểm còn lại
                        diemTich = 0; // reset diem vì đã áp dụng hết và kh tích thêm điểm đối với hd đã áp dụng điểm
                    }
                    else
                    {
                        k.diemTichLuy = 0;
                        diemTich = 0; // reset diem vì đã áp dụng hết và kh tích thêm điểm đối với hd đã áp dụng điểm
                    }
                }
                else
                {
                    // trg hợp kh áp dụng điểm
                    if (txtDiemTL.TextLength != 0)
                    {
                        int diemTL = int.Parse(txtDiemTL.Text);
                        diemTich = double.Parse(lbGiaTriHD.Text) / 10;// 10 VNĐ == 1đ
                        dtl = diemTL + int.Parse(diemTich.ToString());
                        k.diemTichLuy = dtl;
                    }
                }

                HoaDonDTO hd = new HoaDonDTO
                {
                    MaHD = txtMaHD.Text,
                    //NgayLap = DateTime.Now,
                    NgayLap = ngayLap,
                    MaKH = k?.maKH,
                    TenND = txtTKNV.Text,
                    TichDiem = diemTich,
                    MaND = txtTKNV.Text,
                    TienNhan = double.Parse(txtTienNhan.Text),
                    TienGiam = double.Parse(lbTietKiemHV.Text),
                    TongTien = double.Parse(lbGiaTriHD.Text)
                };

                using (TransactionScope scope = new TransactionScope())
                {
                    try
                    {
                        if (hoaDonBUL.themHoaDon(hd))
                        {
                            foreach (CTHoaDonDTO sp in lstSPHD)
                            {
                                if (sp.MaSP.StartsWith("SP")) // chỉ thêm những item là sp, ko là KM
                                {
                                    if (!cTHoaDonBUL.themCTHoaDon(sp))
                                    {
                                        throw new Exception("Thêm chi tiết hóa đơn thất bại!"); // Nếu thêm chi tiết không thành công, ném lỗi để rollback
                                    }

                                    if (!sanPhamBUL.capNhatSLTon(sp.MaSP, sp.SoLuong))
                                    {
                                        throw new Exception("Cập nhật số lượng tồn thất bại!");
                                    }
                                }

                            }
                            if (k != null)
                            {
                                // cập nhật điểm cho khách hàng
                                if (!khachHangBUL.CapNhatDTL(k))
                                {
                                    throw new Exception("Cập nhật điểm tích lũy cho khách hàng thất bại!");
                                }
                            }

                            // Đánh dấu TransactionScope là hoàn thành
                            scope.Complete();
                            message.Buttons = MessageDialogButtons.OK;
                            message.Icon = MessageDialogIcon.Information;
                            message.Parent = this.ParentForm;
                            message.Show("Thêm thành công!", "Thông Báo");

                            // Đặt lại trạng thái sau khi transaction hoàn thành
                            clear();

                        }
                        else
                        {
                            throw new Exception("Thêm hóa đơn thất bại!");
                        }
                    }
                    catch (Exception ex)
                    {
                        // Nếu có lỗi, transaction sẽ tự động rollback
                        MessageBox.Show(ex.Message, "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }
        }

        private void txtTienNhan_TextChanged(object sender, EventArgs e)
        {
            lbTienThua.Text = string.Empty;

            if (xemDS) return;

            if (!int.TryParse(txtTienNhan.Text, out int tienNhan))
            {
                //message.Buttons = MessageDialogButtons.OK;
                //message.Icon = MessageDialogIcon.Error;
                //message.Parent = this.ParentForm;
                //message.Show("Vui lòng chỉ nhập số vào ô Tiền Nhận", "Thông Báo");
                //txtTienNhan.Text = ""; // Xóa dữ liệu không hợp lệ
                return;
            }

            if (!int.TryParse(lbTongTien.Text.Replace(".", ""), out int tongTienDaGiam))
            {
                message.Buttons = MessageDialogButtons.OK;
                message.Icon = MessageDialogIcon.Error;
                message.Parent = this.ParentForm;
                message.Show("Dữ liệu trong Tổng Tiền không hợp lệ", "Thông Báo");
                txtTienNhan.Text = ""; // Xóa dữ liệu không hợp lệ
                return;
            }

            // So sánh và tính toán tiền thừa
            if (tienNhan >= tongTienDaGiam)
            {
                int tienThua = tienNhan - tongTienDaGiam;
                lbTienThua.Text = tienThua.ToString("N0"); // Định dạng tiền tệ với dấu phẩy
            }
        }

        private void lbTongTien_TextChanged(object sender, EventArgs e)
        {
            btnThanhToan.Enabled = false;
            int tongTien = int.Parse(lbGiaTriHD.Text);
            if (tongTien > 0)
            {
                btnThanhToan.Enabled = true;
            }
        }

        int selectedIndex = 0;
        private void tabHoaDon_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (xemDS) return;
            selectedIndex = tabHoaDon.SelectedIndex;
            capNhatHD();
        }

        private bool isCloseIconVisible = false; // Biến trạng thái
        int diemTichLuy = 0;
        KhachHangDTO k = null;
        private void txtTimKH_IconRightClick(object sender, EventArgs e)
        {
            if (isCloseIconVisible)
            {
                // Xử lý khi icon Close được nhấn
                txtTimKH.Text = string.Empty;
                txtTimKH.ReadOnly = false;
                txtTimKH.IconRight = Properties.Resources.Search;
                txtTimKH.IconLeft = Properties.Resources.Plus;
                txtDiemTL.Text = string.Empty;
                isCloseIconVisible = false;  // Reset trạng thái
            }
            else
            {
                // Xử lý logic hiện tại (khi chưa ở trạng thái Close)
                k = khachHangBUL.layMotKHTheoSDT(txtTimKH.Text);
                if (k == null)
                {
                    message.Buttons = MessageDialogButtons.OK;
                    message.Icon = MessageDialogIcon.Error;
                    message.Parent = this.ParentForm;
                    message.Show("Không tìm thấy thông tin khách hàng", "Thông Báo");
                }
                else
                {
                    txtTimKH.Text = k.tenKH;
                    txtTimKH.IconLeft = Properties.Resources.User;
                    txtTimKH.IconRight = Properties.Resources.Close;
                    txtTimKH.ReadOnly = true;
                    txtDiemTL.Text = k.diemTichLuy.ToString();
                    btnApDung.Enabled = true;
                    guna2HtmlLabel1.Focus();

                    isCloseIconVisible = true; // Cập nhật trạng thái

                    // đưa tt khách hàng vào hd
                    TabPage t = tabHoaDon.TabPages[selectedIndex];
                    int tab = selectedIndex + 1;
                    if (tab == 1)
                    {
                        hdDTO1.MaKH = k.maKH;
                    }
                    else if (tab == 2)
                    {
                        hdDTO2.MaKH = k.maKH;
                    }
                    else if (tab == 3)
                    {
                        hdDTO3.MaKH = k.maKH;
                    }
                    else
                    {
                        hdDTO4.MaKH = k.maKH;
                    }

                }
            }
        }

        private void txtTimKH_IconLeftClick(object sender, EventArgs e)
        {
            if (!isCloseIconVisible)
            {
                FrmKhachHang myForm = new FrmKhachHang();
                myForm.batForm = true;
                myForm.StartPosition = FormStartPosition.CenterScreen;
                myForm.ShowDialog();

                if (txtDiemTL.Text.Length == 0)
                {
                    k = khachHangBUL.layMotKHTheoSDT(myForm.sdtKH);
                    if (k != null)
                    {
                        txtTimKH.Text = k.tenKH;
                        txtTimKH.IconLeft = Properties.Resources.User;
                        txtTimKH.IconRight = Properties.Resources.Close;
                        txtTimKH.ReadOnly = true;
                        txtDiemTL.Text = k.diemTichLuy.ToString();
                        guna2HtmlLabel1.Focus();

                        isCloseIconVisible = true; // Cập nhật trạng thái
                    }

                }
            }
        }

        private void txtSanPham_TextChanged(object sender, EventArgs e)
        {

        }

        private void setMaHD(HoaDonDTO hdDTO)
        {
            if (hdDTO.MaHD == null)
            {
                hdDTO.MaHD = hoaDonBUL.TaoMaHD();
                hdDTO.NgayLap = DateTime.Now;
            }
        }

        bool xemDS = false;
        private void btnXemDS_Click(object sender, EventArgs e)
        {
            FrmDSHoaDon myForm = new FrmDSHoaDon();
            myForm.StartPosition = FormStartPosition.CenterScreen;
            myForm.ShowDialog();
            string maHD = myForm.maHD;

            //truy vấn lấy thông tin hóa đơn
            HoaDonDTO hoadDTO = hoaDonBUL.layTTHoaDon(maHD);

            if (hoadDTO != null)
            {
                xemDS = true;

                TabPage newPage = new TabPage();

                // Đặt tiêu đề cho TabPage
                newPage.Text = "Hóa đơn " + maHD;
                newPage.BackColor = Color.White;

                // Thêm TabPage vào TabControl
                tabHoaDon.TabPages.Add(newPage);

                // Chuyển sang TabPage vừa tạo
                tabHoaDon.SelectedTab = newPage;

                double tienGiam = double.Parse(hoadDTO.TienGiam.ToString());
                double giaTriHD = double.Parse(hoadDTO.TongTien.ToString());
                double tienNhan = double.Parse(hoadDTO.TienNhan.ToString());
                double tongTien = double.Parse((giaTriHD - tienGiam).ToString());

                txtMaHD.Text = hoadDTO.MaHD;
                txtNgayLap.Text = hoadDTO.NgayLap.ToShortDateString();

                KhachHangDTO khachHangDTO = khachHangBUL.layKHTheoMa(hoadDTO.MaKH);
                if (khachHangDTO != null)
                    txtTimKH.Text = khachHangDTO.tenKH;

                NguoiDungDTO nguoiDungDTO = nguoiDungBUL.layMotNguoiDung(hoadDTO.MaND);
                txtTKNV.Text = nguoiDungDTO.TenND;

                txtDiemTL.Text = hoadDTO.TichDiem?.ToString();
                lbGiaTriHD.Text = giaTriHD.ToString("N0");
                lbTietKiemHV.Text = tienGiam.ToString("N0");
                lbTongTien.Text = tongTien.ToString("N0");
                txtTienNhan.Text = tienNhan.ToString("N0");
                lbTienThua.Text = (tienNhan - tongTien).ToString("N0");

                //txtMaHD.Enabled = false;
                txtTongSoHang.Enabled = false;
                txtTienNhan.Enabled = false;
                //btnThem.Enabled = false;
                txtTimKH.Enabled = false;
                //btnThanhToan.Enabled = false;
                btnApDung.Enabled = false;


                tabHoaDon.TabPages.RemoveAt(0);
                hienThiCTHD(maHD, newPage);
            }
        }

        private void hienThiCTHD(string maHD, TabPage newPage)
        {
            List<CTHoaDonDTO> cTHoaDonDTOs = cTHoaDonBUL.layDSSPTrongHD(maHD);
            // thêm sp lên giao diện
            //tabPageHD1.Controls.Clear();
            int top = 0;
            int stt = 0;
            foreach (CTHoaDonDTO ct in cTHoaDonDTOs)
            {
                SanPhamDTO sanPhamDTO = sanPhamBUL.layMotSanPham(ct.MaSP);
                int giaSP = int.Parse(ct.DonGia.ToString());

                SanPhamHD_UC item = new SanPhamHD_UC(sanPhamDTO.MaSP, sanPhamDTO.TenSP, giaSP);
                //item.ClickXoa += Item_ClickXoa;
                //item.ClickThayDoiSL += Item_ClickThayDoiSL;
                //lstUCHD.Add(item);
                newPage.Controls.Add(item);

                item.SoLuong = ct.SoLuong;
                item.ThanhTien = ct.SoLuong * giaSP;
                item.Width = newPage.ClientSize.Width;
                item.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
                //item.Dock = DockStyle.Top;

                // xét vị trí hiện sp
                foreach (Control c in newPage.Controls)
                {
                    item.Top = top;
                    item.Left = 0;

                    top = c.Bottom;

                    newPage.AutoScroll = true;
                }

                stt++;
                item.SoTT = stt;

                txtTongSoHang.Text = stt.ToString();
            }

        }

        private void txtTienNhan_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsDigit(e.KeyChar) && !char.IsControl(e.KeyChar))
            {
                e.Handled = true; // Ngăn ký tự được nhập vào
            }
        }

        private bool isDiscountApplied = false;
        private void btnApDung_Click(object sender, EventArgs e)
        {
            if (txtMaHD.Text.Length == 0)
            {
                message.Buttons = MessageDialogButtons.OK;
                message.Icon = MessageDialogIcon.Error;
                message.Parent = this.ParentForm;
                message.Show("Điểm không được áp dụng!", "Thông Báo");
                return;
            }

            if (k != null)
            {
                if (int.Parse(txtDiemTL.Text) <= 0)
                {
                    message.Buttons = MessageDialogButtons.OK;
                    message.Icon = MessageDialogIcon.Error;
                    message.Parent = this.ParentForm;
                    message.Show("Điểm không hợp lệ để áp dụng!", "Thông Báo");
                    return;
                }

                double tienDaGiam = 0;
                if (!isDiscountApplied) // Chưa áp dụng
                {
                    double giaGiam = k.diemTichLuy;
                    lbTietKiemHV.Text = giaGiam.ToString("N0");
                    isDiscountApplied = true; // Đánh dấu là đã áp dụng

                    if (giaGiam > tongTien)
                    {
                        giaGiam = tongTien;
                    }

                    lbTietKiemHV.Text = giaGiam.ToString("N0");
                    tienDaGiam = tongTien - giaGiam;

                    txtTienNhan.Clear();
                    lbTienThua.Text = string.Empty;
                }
                else // Đã áp dụng
                {
                    lbTietKiemHV.Text = "0"; // Hoàn tác giảm giá
                    isDiscountApplied = false; // Đặt lại trạng thái

                    tienDaGiam = tongTien;
                }

                lbTongTien.Text = tienDaGiam.ToString("N0");
            }
        }

        private void txtTimKH_TextChanged(object sender, EventArgs e)
        {

        }

        private void txtDiemTL_TextChanged(object sender, EventArgs e)
        {
            btnApDung.Enabled = false;
            if (txtDiemTL.Text.Length != 0)
                btnApDung.Enabled = true;
        }
        double giaGiam = 0;
        void xetKMChoSanPham(List<CTHoaDonDTO> lstSPTrongHoaDon, List<SanPhamHD_UC> lstUCHD, TabPage page, HoaDonDTO hoadon)
        {

            //kiểm tra sản phẩm có nằm trong khuyến mãi nào hay không
            KhuyenMaiDTO km = khuyenMaiBUL.layKMCuaSanPham(maSP);
            if (km != null)
            {
                //Tính số sp đã được áp dụng km rồi
                int slSanPhamDaApDungKM = 0;
                SanPhamHD_UC sanPhamHD_UC = lstUCHD.FirstOrDefault(u => u.MaSP == km.MaKM);
                if (sanPhamHD_UC != null)
                {
                    int slTang = km.SLTang ?? 0;
                    slSanPhamDaApDungKM = (slTang + km.SLMua) * sanPhamHD_UC.SoLuong; //số lg sp đã áp dụng xong km rồi

                }

                //Đề xuất khuyến mãi


                //Tính số lượng thực tế của nhóm sp áp dụng km tại hóa đơn
                int demSLSanPhamApDungKM = 0;
                List<CTNhomSanPhamKMDTO> lstSpMuaDuocApDungKM = nhomSanPhamKMBUL.layMotNhomSanPhamKM(km.MaNhomSPMua);
                foreach (CTHoaDonDTO sp in lstSPTrongHoaDon)
                {
                    //kiểm tra nếu sp.MaSP có trong lstSpMuaDuocApDungKM 
                    if (lstSpMuaDuocApDungKM.Any(p => p.MaSP == sp.MaSP))
                    {
                        demSLSanPhamApDungKM += sp.SoLuong;
                    }
                }

                demSLSanPhamApDungKM = demSLSanPhamApDungKM - slSanPhamDaApDungKM; //Tính số lượng chưa áp dụng khuyến mãi
                while (demSLSanPhamApDungKM != 0 && demSLSanPhamApDungKM >= km.SLMua + km.SLTang) //Áp dụng km khi đủ số lượng
                {
                    bool isDaTru = false;
                    //Trừ ra số sản phẩm mà khách hàng phải trả tiền
                    if (demSLSanPhamApDungKM >= km.SLMua)
                    {
                        demSLSanPhamApDungKM -= km.SLMua;
                        isDaTru = true;

                    }

                    //Áp dụng khuyến mãi
                    if (isDaTru && demSLSanPhamApDungKM >= km.SLTang)
                    {
                        int slTang = km.SLTang ?? 0;
                        demSLSanPhamApDungKM -= slTang;

                        //Hiển thị khuyến mãi lên giao diện
                        //kiểm tra lstUCHD này có SanPhamHD_UC với SanPhamHD_UC.MaSP == km.MaKM chưa
                        SanPhamHD_UC Km_UC = lstUCHD.FirstOrDefault(u => u.MaSP == km.MaKM);
                        if (Km_UC == null)
                        {
                            SanPhamHD_UC item = new SanPhamHD_UC(km.MaKM, km.TenKM, -km.GiaGiam);
                            item.ClickXoa += Item_ClickXoa;

                            lstUCHD.Add(item);

                            // Kiểm tra và chỉ thêm nếu không trùng
                            if (!lstSPTrongHoaDon.Any(hd => hd.MaHD == lstSPTrongHoaDon[0].MaHD && hd.MaSP == km.MaKM))
                            {
                                CTHoaDonDTO hd2 = new CTHoaDonDTO(lstSPTrongHoaDon[0].MaHD, km.MaKM, 1, -km.GiaGiam);
                                lstSPTrongHoaDon.Add(hd2);
                            }

                            page.Controls.Add(item);

                            // Cập nhật thông tin của 
                            item.SoLuong = 1;
                            item.ThanhTien = -(item.SoLuong * item.GiaSP);

                            item.Width = page.ClientSize.Width;
                            item.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;

                            int stt = 0;
                            int top = 0;

                            // xét vị trí hiện sp
                            foreach (Control c in page.Controls)
                            {
                                stt++;
                                item.Top = top;
                                item.Left = 0;

                                top = c.Bottom;

                                page.AutoScroll = true;
                            }
                            item.SoTT = stt;
                        }
                        else
                        {
                            // Nếu đã tồn tại, cập nhật số lượng và thành tiền
                            Km_UC.SoLuong += 1;
                            Km_UC.ThanhTien = -(Km_UC.SoLuong * Km_UC.GiaSP);
                            // Kiểm tra và chỉ thêm nếu không trùng
                            if (lstSPTrongHoaDon.Any(hd => hd.MaHD == lstSPTrongHoaDon[0].MaHD && hd.MaSP == km.MaKM))
                            {
                                // Lấy ra item cần cập nhật
                                CTHoaDonDTO existingItem = lstSPTrongHoaDon.FirstOrDefault(hd => hd.MaHD == lstSPTrongHoaDon[0].MaHD && hd.MaSP == km.MaKM);
                                if (existingItem != null)
                                {
                                    existingItem.SoLuong += 1;
                                }
                            }

                        }
                        capNhatTTHoaDon(lstSPTrongHoaDon, hoadon);

                    }


                }


            }
            else
            {
                return;
            }

        }

        private void txtSanPham_IconRightClick(object sender, EventArgs e)
        {
            ShowUserControl(txtSanPham.Text);
        }

        private void btnChonSP_Click(object sender, EventArgs e)
        {
            //btnXemDS.Enabled = false;

            TabPage t = tabHoaDon.TabPages[selectedIndex];
            int tab = selectedIndex + 1;

            string maHD = hoaDonBUL.TaoMaHD();
            if (tab == 1)
            {
                setMaHD(hdDTO1);
                themSPVaoHD(lstSP_HD1, lstUCHD1, t, hdDTO1);
                xetKMChoSanPham(lstSP_HD1, lstUCHD1, t, hdDTO1);
            }
            else if (tab == 2)
            {
                setMaHD(hdDTO2);
                themSPVaoHD(lstSP_HD2, lstUCHD2, t, hdDTO2);
                xetKMChoSanPham(lstSP_HD2, lstUCHD2, t, hdDTO2);
            }
            else if (tab == 3)
            {
                setMaHD(hdDTO3);
                themSPVaoHD(lstSP_HD3, lstUCHD3, t, hdDTO3);
                xetKMChoSanPham(lstSP_HD3, lstUCHD3, t, hdDTO3);
            }
            else
            {
                setMaHD(hdDTO4);
                themSPVaoHD(lstSP_HD4, lstUCHD4, t, hdDTO4);
                xetKMChoSanPham(lstSP_HD4, lstUCHD4, t, hdDTO4);
            }
            //tabHoaDon.TabPages[selectedIndex].Text
            //themSPVaoHD(lstSP_HD1);
        }

        private void clear()
        {
            txtMaHD.Clear();
            txtNgayLap.Clear();
            txtTimKH.Clear();
            txtDiemTL.Text = string.Empty;
            txtMaHD.Clear();
            txtTienNhan.Clear();
            lbTienThua.Text = string.Empty;
            lbGiaTriHD.Text = string.Empty;
            lbTongTien.Text = string.Empty;
            lbTietKiemHV.Text = string.Empty;
            txtTongSoHang.Text = string.Empty;
            //btnChonSP.Enabled = false;
            btnThanhToan.Enabled = false;
            k = null;
            btnApDung.Enabled = false;
            isDiscountApplied = false;

            if (isCloseIconVisible)
            {
                // Xử lý khi icon Close được nhấn
                txtTimKH.Text = string.Empty;
                txtTimKH.ReadOnly = false;
                txtTimKH.IconRight = Properties.Resources.Search;
                txtTimKH.IconLeft = Properties.Resources.Plus;
                txtDiemTL.Text = string.Empty;
                isCloseIconVisible = false;  // Reset trạng thái
            }

            TabPage t = tabHoaDon.TabPages[selectedIndex];
            int tab = selectedIndex + 1;
            if (tab == 1)
            {
                lstSP_HD1.Clear();
                lstUCHD1.Clear();
                hdDTO1 = new HoaDonDTO();

                t.Controls.Clear();
                return;
            }
            else if (tab == 2)
            {
                lstSP_HD2.Clear();
                lstUCHD2.Clear();
                hdDTO2 = new HoaDonDTO();

                t.Controls.Clear();
            }
            else if (tab == 3)
            {
                lstSP_HD3.Clear();
                lstUCHD3.Clear();
                hdDTO3 = new HoaDonDTO();
                t.Controls.Clear();
            }
            else
            {
                lstSP_HD4.Clear();
                lstUCHD4.Clear();
                hdDTO4 = new HoaDonDTO();
                t.Controls.Clear();
            }
            tabHoaDon.TabPages.RemoveAt(selectedIndex); // Xóa page

            //if (tabHoaDon.TabPages.Count == 1)
            //{
            //    btnXemDS.Enabled = true;
            //}

        }
    }
}
