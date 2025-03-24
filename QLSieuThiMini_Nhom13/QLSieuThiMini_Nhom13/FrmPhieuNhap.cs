using BUL;
using DTO;
using Guna.UI2.WinForms;
using QLSieuThiMini_Nhom13.UserControls;
using System;
using System.Collections.Generic;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Transactions;
using System.Windows.Forms;

namespace QLSieuThiMini_Nhom13
{
    public partial class FrmPhieuNhap : Form
    {
        SanPhamBUL sanPhamBUL;
        PhieuNhapHangBUL phieuNhapHangBUL;
        ChiTietPNHBUL chiTietPNHBUL;
        NhaCungCapBUL nhaCungCapBUL;
        NguoiDungBUL nguoiDungBUL;

        Guna2MessageDialog message;
        string maND;
        public FrmPhieuNhap(string maND)
        {
            InitializeComponent();

            sanPhamBUL = new SanPhamBUL();
            phieuNhapHangBUL = new PhieuNhapHangBUL();
            chiTietPNHBUL = new ChiTietPNHBUL();
            nhaCungCapBUL = new NhaCungCapBUL();
            nguoiDungBUL = new NguoiDungBUL();

            //FrmMain f = new FrmMain();
            message = new Guna2MessageDialog
            {
                Style = MessageDialogStyle.Light,
                //Parent = this.Parent.
            };
            this.maND = maND;
            //message.Parent = this;
        }

        private void FrmHoaDonTest_Load(object sender, EventArgs e)
        {
            ShowUserControl();
            btnChonSP.Enabled = false;
            btnThanhToan.Enabled = false;

            themTabPage();
            btnThemPhieu.Enabled = false;
            btnIn.Enabled = false;

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

            foreach (SanPhamDTO sp in lstDSSanPham)
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
        string maPN, maSP, tenSP, giaBan;
        TabPage newPage;
        List<ChiTietPNHDTO> lstCTPN = new List<ChiTietPNHDTO>();
        List<SanPhamPN_UC> lstUCSP = new List<SanPhamPN_UC>(); // lst sp các usercontrol dùng để cập nhật trên giao diện
        PhieuNhapHangDTO pnDTO = new PhieuNhapHangDTO();
        bool flag = true;
        private void btnChonSP_Click(object sender, EventArgs e)
        {
            int stt = 0;
            int top = 0;
            int soLuong = 1;
            int giaSP = int.Parse(giaBan);

            // them sp trùng -> cập nhật
            ChiTietPNHDTO pn = lstCTPN.FirstOrDefault(t => t.MaSP == maSP);
            if (pn != null)
            {
                pn.SoLuong += 1;
                SanPhamPN_UC sanPhamHD_UC = lstUCSP.FirstOrDefault(u => u.MaSP == maSP);
                if (sanPhamHD_UC != null)
                {
                    flag = true;
                    sanPhamHD_UC.SoLuong += 1;
                    sanPhamHD_UC.ThanhTien = sanPhamHD_UC.SoLuong * sanPhamHD_UC.GiaSP;
                }
            }
            else // thêm sp mới
            {
                // thêm vào list các sp trong pn
                lstCTPN.Add(new ChiTietPNHDTO
                {
                    MaSP = maSP,
                    DonGia = giaSP,
                    SoLuong = soLuong,
                });

                // thêm sp lên giao diện
                SanPhamPN_UC item = new SanPhamPN_UC(maSP, tenSP, giaSP);
                item.ClickXoa += Item_ClickXoa;
                item.ClickThayDoiSL += Item_ClickThayDoiSL;
                lstUCSP.Add(item);
                newPage.Controls.Add(item);

                item.SoLuong = soLuong;
                item.ThanhTien = item.SoLuong * item.GiaSP;
                item.Width = newPage.ClientSize.Width;
                item.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
                //item.Dock = DockStyle.Top;

                // xét vị trí hiện sp
                foreach (Control c in newPage.Controls)
                {
                    stt++;
                    item.Top = top;
                    item.Left = 0;

                    top = c.Bottom;

                    newPage.AutoScroll = true;
                }

                item.SoTT = stt;

                txtTongSoHang.Text = stt.ToString();
            }

            capNhatTTPhieuNhap();
        }

        private void capNhatTTPhieuNhap()
        {
            txtTongSoHang.Text = lstCTPN.Count().ToString();
            double tongTien = lstCTPN.Sum(t => t.DonGia * t.SoLuong);
            lbTongTien.Text = tongTien.ToString("N0");

            //txtTienNhan.Clear();
        }

        private void Item_ClickThayDoiSL(object sender, EventArgs e)
        {
            NumericUpDown soLuong = sender as NumericUpDown;

            if (soLuong != null)
            {
                SanPhamPN_UC control = soLuong.Parent.Parent.Parent as SanPhamPN_UC;

                //control.SoLuong += 1;
                SanPhamPN_UC sanPhamPN_UC = lstUCSP.FirstOrDefault(u => u.MaSP == control.MaSP);
                if (sanPhamPN_UC != null)
                {
                    // cập nhật uc trên giao diện
                    sanPhamPN_UC.SoLuong = int.Parse(soLuong.Value.ToString());
                    sanPhamPN_UC.ThanhTien = sanPhamPN_UC.SoLuong * sanPhamPN_UC.GiaSP;

                    // cập nhật trên lst để thêm vào csdl
                    ChiTietPNHDTO ctsp = lstCTPN.FirstOrDefault(u => u.MaSP == control.MaSP);
                    ctsp.SoLuong = int.Parse(soLuong.Value.ToString());
                    capNhatTTPhieuNhap();
                }
            }

        }

        private void capNhatListSanPhamHDUC(TabPage tabpage)
        {
            int stt = 1; // Bắt đầu từ số thứ tự 1
            int currentTop = 0;
            foreach (Control control in tabpage.Controls.OfType<SanPhamPN_UC>())
            {
                control.Dock = DockStyle.None; // Bỏ DockStyle
                control.Top = currentTop;      // Cập nhật vị trí Top
                currentTop += control.Height; // Tăng vị trí cho UserControl tiếp theo
                SanPhamPN_UC sanPhamUC = control as SanPhamPN_UC;
                if (sanPhamUC != null)
                {
                    sanPhamUC.SoTT = stt; // Cập nhật số thứ tự (hoặc Label)
                    stt++; // Tăng số thứ tự
                }
            }
        }

        private bool isCloseIconVisible = false; // Biến trạng thái
        private void txtTimNCC_IconRightClick(object sender, EventArgs e)
        {
            if (enableNCC) return;

            if (isCloseIconVisible)
            {
                // Xử lý khi icon Close được nhấn
                txtTimNCC.Text = string.Empty;
                txtTimNCC.ReadOnly = false;
                txtTimNCC.IconRight = Properties.Resources.Search;
                txtTimNCC.IconLeft = Properties.Resources.Plus;
                isCloseIconVisible = false;  // Reset trạng thái
                txtMaPhieuNhap.Text = string.Empty;
                txtNgayLap.Text = string.Empty;
            }
            else
            {
                // Xử lý logic hiện tại (khi chưa ở trạng thái Close)
                NhaCungCapDTO nhaCungCap = new NhaCungCapDTO();
                nhaCungCap = nhaCungCapBUL.laySDTNhaCungCap(txtTimNCC.Text);
                if (nhaCungCap == null)
                {
                    message.Buttons = MessageDialogButtons.OK;
                    message.Icon = MessageDialogIcon.Error;
                    message.Parent = this.ParentForm;
                    message.Show("Không tìm thấy thông tin nhà cung cấp", "Thông Báo");
                }
                else
                {
                    txtTimNCC.Text = nhaCungCap.TenNCC;
                    txtTimNCC.IconLeft = Properties.Resources.User;
                    txtTimNCC.IconRight = Properties.Resources.Close;
                    txtTimNCC.ReadOnly = true;
                    guna2HtmlLabel2.Focus();

                    maPN = phieuNhapHangBUL.TaoMaPNH(nhaCungCap.MaNCC);
                    pnDTO.MaNCC = nhaCungCap.MaNCC;
                    pnDTO.MaPNH = maPN;
                    pnDTO.NgayNhap = DateTime.Now;
                    btnThanhToan.Enabled = true;

                    //txtMaPhieuNhap.Text = phieuNhapHangBUL.TaoMaPNH(txtTimNCC.Text);
                    txtMaPhieuNhap.Text = maPN;
                    txtNgayLap.Text = pnDTO.NgayNhap.ToString("dd/MM/yyyy HH:mm:ss");

                    isCloseIconVisible = true; // Cập nhật trạng thái
                }
            }
        }

        private void btnThanhToan_Click(object sender, EventArgs e)
        {
            PhieuNhapHangDTO pn = new PhieuNhapHangDTO(txtMaPhieuNhap.Text, pnDTO.NgayNhap, double.Parse(lbTongTien.Text), pnDTO.MaNCC, maND);
            message.Parent = this.ParentForm;
            message.Buttons = MessageDialogButtons.YesNo;
            message.Icon = MessageDialogIcon.Question;
            DialogResult r = message.Show("Bạn có muốn lưu phiếu nhập?", "Xác nhận");
            if (r == DialogResult.Yes)
            {
                using (TransactionScope scope = new TransactionScope())
                {
                    try
                    {
                        if (phieuNhapHangBUL.InsertPhieuNhapHang(pn))
                        {
                            foreach (ChiTietPNHDTO sp in lstCTPN)
                            {
                                sp.MaPNH = pn.MaPNH;
                                if (!chiTietPNHBUL.InsertChiTietPNH(sp))
                                {
                                    throw new Exception("Thêm chi tiết phiếu nhập thất bại!"); // Nếu thêm chi tiết không thành công, ném lỗi để rollback
                                }

                                if (!sanPhamBUL.capNhatSLTonChoPN(sp.MaSP, sp.SoLuong))
                                {
                                    throw new Exception("Cập nhật số lượng tồn thất bại!");
                                }
                            }

                            // Đánh dấu TransactionScope là hoàn thành
                            scope.Complete();
                            message.Parent = this.ParentForm;
                            message.Buttons = MessageDialogButtons.OK;
                            message.Icon = MessageDialogIcon.Information;
                            message.Show("Thêm phiếu nhập thành công!", "Thông Báo");

                            // Đặt lại trạng thái sau khi transaction hoàn thành
                            txtTimNCC.Text = string.Empty;
                            txtTimNCC.ReadOnly = false;
                            txtTimNCC.IconRight = Properties.Resources.Search;
                            txtTimNCC.IconLeft = Properties.Resources.Plus;
                            isCloseIconVisible = false;  // Reset trạng thái
                            txtMaPhieuNhap.Text = string.Empty;
                            txtNgayLap.Text = string.Empty;
                            lstCTPN.Clear();
                            lstUCSP.Clear();
                            txtTongSoHang.Text = string.Empty;
                            newPage.Controls.Clear();
                            btnThanhToan.Enabled = false;
                            lbTongTien.Text = string.Empty;
                            //btnIn.Enabled = false;
                        }
                        else
                        {
                            throw new Exception("Thêm phiếu nhập thất bại!");
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

        private void clearSanPhamUC()
        {
        }

        string tacVu = "";
        string diachi, sdt, tenND;
        double tongTienPN;
        bool enableNCC = false;
        private void btnXemDS_Click(object sender, EventArgs e)
        {
            //Gọi form DS PHIẾU NHẬP
            FrmDSPhieuNhap frm = new FrmDSPhieuNhap();
            frm.StartPosition = FormStartPosition.CenterScreen;
            frm.ShowDialog();

            //Trả về maPHP
            string maPNH = frm.MaPhieuNhap;

            //Hiển thị thông tin chi tiết phiếu nhập vừa chọn
            if (maPNH != null)
            {
                txtMaPhieuNhap.Text = maPNH;
                PhieuNhapHangDTO pnh = phieuNhapHangBUL.layMotPhieuNhapHang(maPNH);
                txtNgayLap.Text = pnh.NgayNhap.ToString();
                tongTienPN = pnh.TongTien;
                lbTongTien.Text = tongTienPN.ToString("N0");
                NhaCungCapDTO ncc = nhaCungCapBUL.layNhaCungCapTheoMa(pnh.MaNCC);
                txtTimNCC.Text = ncc.TenNCC;
                NguoiDungDTO nd = nguoiDungBUL.layMotNguoiDung(pnh.MaND);
                txtTKNV.Text = nd.TenTK;
                btnThemPhieu.Enabled = true;
                btnIn.Enabled = true;
                btnChonSP.Enabled = false;
                tacVu = "Xem";

                txtTimNCC.IconLeft = Properties.Resources.User;
                txtTimNCC.IconRight = Properties.Resources.Close;
                txtTimNCC.ReadOnly = true;
                guna2HtmlLabel2.Focus();
                isCloseIconVisible = true; // Cập nhật trạng thái
                enableNCC = true;

                // lấy tt để in phiếu
                diachi = ncc.DiaChi;
                sdt = ncc.SDT;
                tenND = nd.TenND;

                lstCTPN.Clear();
                lstUCSP.Clear();
                newPage.Controls.Clear();
                lstCTPN = chiTietPNHBUL.layDSSPTrongPhieuNhap(maPNH);
                int stt = 0;
                int top = 0;

                foreach (ChiTietPNHDTO ct in lstCTPN)
                {
                    double thanhTien = double.Parse(ct.DonGia.ToString()) * double.Parse(ct.SoLuong.ToString());
                    SanPhamDTO sp = sanPhamBUL.layMotSanPham(ct.MaSP);

                    // thêm sp lên giao diện
                    SanPhamPN_UC item = new SanPhamPN_UC(ct.MaSP, sp.TenSP, ct.DonGia);
                    //item.ClickXoa += Item_ClickXoa;
                    item.ClickThayDoiSL += Item_ClickThayDoiSLTrongDS;
                    //lstUCSP.Add(item);
                    newPage.Controls.Add(item);

                    item.SoLuong = ct.SoLuong;
                    item.ThanhTien = item.SoLuong * item.GiaSP;
                    item.Width = newPage.ClientSize.Width;
                    item.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;

                    stt++;
                    // xét vị trí hiện sp
                    foreach (Control c in newPage.Controls)
                    {
                        item.Top = top;
                        item.Left = 0;

                        top = c.Bottom;

                        newPage.AutoScroll = true;
                    }

                    item.SoTT = stt;

                }

                txtTongSoHang.Text = stt.ToString();
            }
        }

        private void Item_ClickThayDoiSLTrongDS(object sender, EventArgs e)
        {
            //e.Handled = true; // Ngăn không cho xử lý phím
        }

        private void btnThemPhieu_Click(object sender, EventArgs e)
        {
            tabPhieuNhap.Controls.Clear();
            themTabPage();
            btnThemPhieu.Enabled = false;
            btnChonSP.Enabled = true;
            btnIn.Enabled = false;
            tacVu = "Thêm";
            isCloseIconVisible = false;
            enableNCC = false;
        }

        public static string NumberToWords(long number)
        {
            if (number == 0) return "không";

            string[] units = { "", "một", "hai", "ba", "bốn", "năm", "sáu", "bảy", "tám", "chín" };
            string[] levels = { "", "nghìn", "triệu", "tỷ" };

            string result = "";
            int level = 0;

            while (number > 0)
            {
                int group = (int)(number % 1000); // Lấy 3 chữ số cuối
                number /= 1000;                  // Bỏ 3 chữ số cuối

                if (group > 0)
                {
                    string groupText = ConvertGroupToWords(group, units);
                    result = groupText + " " + levels[level] + " " + result;
                }

                level++;
            }

            return result.Trim() + " đồng";
        }

        private void txtSanPham_IconRightClick(object sender, EventArgs e)
        {
            ShowUserControl(txtSanPham.Text);
        }

        private void txtTimNCC_IconLeftClick(object sender, EventArgs e)
        {
            if (!isCloseIconVisible)
            {
                FrmNhaCungCap myForm = new FrmNhaCungCap();
                myForm.batForm = true;
                myForm.StartPosition = FormStartPosition.CenterScreen;
                myForm.ShowDialog();

                if (myForm.sdtNCC != null)
                {
                    NhaCungCapDTO ncc = nhaCungCapBUL.laySDTNhaCungCap(myForm.sdtNCC);
                    //k = khachHangBUL.layMotKHTheoSDT(myForm.sdtKH);
                    if (ncc != null)
                    {
                        txtTimNCC.Text = ncc.TenNCC;
                        txtTimNCC.IconLeft = Properties.Resources.User;
                        txtTimNCC.IconRight = Properties.Resources.Close;
                        txtTimNCC.ReadOnly = true;
                        guna2HtmlLabel2.Focus();

                        maPN = phieuNhapHangBUL.TaoMaPNH(ncc.MaNCC);
                        pnDTO.MaNCC = ncc.MaNCC;
                        pnDTO.MaPNH = maPN;
                        pnDTO.NgayNhap = DateTime.Now;
                        btnThanhToan.Enabled = true;

                        txtMaPhieuNhap.Text = maPN;
                        txtNgayLap.Text = pnDTO.NgayNhap.ToString("dd/MM/yyyy HH:mm:ss");

                        isCloseIconVisible = true; // Cập nhật trạng thái
                    }

                }
            }
        }

        private void btnThemSP_Click(object sender, EventArgs e)
        {
            FrmSanPham myForm = new FrmSanPham();
            myForm.StartPosition = FormStartPosition.CenterScreen;
            myForm.ShowDialog();
            ShowUserControl();
        }

        private static string ConvertGroupToWords(int number, string[] units)
        {
            int hundreds = number / 100;
            int tens = (number % 100) / 10;
            int ones = number % 10;

            string result = "";

            // Hàng trăm
            if (hundreds > 0)
            {
                result += units[hundreds] + " trăm";
            }

            // Hàng chục và hàng đơn vị
            if (tens > 1)
            {
                result += " " + units[tens] + " mươi";
                if (ones == 1) result += " mốt";
                else if (ones == 5) result += " lăm";
                else if (ones > 0) result += " " + units[ones];
            }
            else if (tens == 1)
            {
                result += " mười";
                if (ones == 1) result += " một";
                else if (ones == 5) result += " lăm";
                else if (ones > 0) result += " " + units[ones];
            }
            else if (tens == 0 && ones > 0)
            {
                if (hundreds > 0) result += " lẻ"; // Chỉ thêm "lẻ" nếu có hàng trăm
                result += " " + units[ones];
            }

            return result.Trim();
        }

        private void btnIn_Click(object sender, EventArgs e)
        {
            DataTable tbl_PhieuNhap = phieuNhapHangBUL.layTTPhieuNhapHang(txtMaPhieuNhap.Text);

            //Tạo 1 biến tự tăng làm số thứ tự trong bảng           
            DataColumn col = new DataColumn("STT", typeof(int));
            tbl_PhieuNhap.Columns.Add(col);
            col.SetOrdinal(0);
            int len = tbl_PhieuNhap.Rows.Count;
            for (int i = 0; i < len; ++i)
            {
                tbl_PhieuNhap.Rows[i]["STT"] = i + 1;
            }

            Dictionary<string, string> dic = new Dictionary<string, string>(); ;
            //string format = "MM/dd/yyyy h:mm:ss tt";

            // Chuyển đổi chuỗi thành DateTime
            string dateTimeString = txtNgayLap.Text;
            string ngaythanghientai = "Ngày " + DateTime.Now.Day + " Tháng " + DateTime.Now.Month + " Năm " + DateTime.Now.Year;
            string format = "dd/MM/yyyy h:mm:ss tt"; // Định dạng tương ứng
            DateTime dateTime = DateTime.ParseExact(dateTimeString, format, null);
            // Lấy ngày, tháng, năm
            int ngay = dateTime.Day;
            int thang = dateTime.Month;
            int nam = dateTime.Year;
            long tongTien = long.Parse(tongTienPN.ToString());
            string tongtienBangChu = NumberToWords(tongTien);

            dic.Add("sophieu", txtMaPhieuNhap.Text);
            dic.Add("tenncc", txtTimNCC.Text);
            dic.Add("diachi", diachi);
            dic.Add("sodienthoai", sdt);
            dic.Add("ngay", ngay.ToString());
            dic.Add("thang", thang.ToString());
            dic.Add("nam", nam.ToString());
            dic.Add("nguoilapphieu", tenND);
            dic.Add("tongtien", lbTongTien.Text);
            dic.Add("tienbangchu", tongtienBangChu);
            dic.Add("ngaythanghientai", ngaythanghientai);

            // Đường dẫn file Template mình để, còn true là mở file word lên
            WordExport wd = new WordExport(Application.StartupPath + "/Template/PhieuNhapHang.dotx", true);
            // In các Field
            wd.WriteFields(dic);
            wd.WriteTable(tbl_PhieuNhap, 1);

            MessageBox.Show("Xuất xong!!!");
        }

        private void Item_ClickXoa(object sender, EventArgs e)
        {
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
                    SanPhamPN_UC sanPhamHD_UC = btnXoa.Parent.Parent.Parent as SanPhamPN_UC;

                    if (sanPhamHD_UC != null)
                    {
                        // Xóa UserControl khỏi container (xóa khỏi giao diện)
                        TabPage tab = sanPhamHD_UC.Parent as TabPage;
                        sanPhamHD_UC.Parent.Controls.Remove(sanPhamHD_UC);

                        // Cập nhật thứ tự các UserControl
                        capNhatListSanPhamHDUC(tab);

                        // Xóa sản phẩm khỏi danh sách
                        lstCTPN.RemoveAll(sp => sp.MaSP == sanPhamHD_UC.MaSP);
                        lstUCSP.RemoveAll(sp => sp.MaSP == sanPhamHD_UC.MaSP);
                        //capNhatTTHoaDon(lstSP_HD4, hdDTO4);
                        capNhatListSanPhamHDUC(newPage);
                        capNhatTTPhieuNhap();

                    }
                }
            }
        }

        private void SanPham_UC_Click(object sender, EventArgs e)
        {
            if (tacVu == "Xem") return;
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
            newPage = new TabPage();

            // Đặt tiêu đề cho TabPage
            newPage.Text = "Nhập hàng";
            newPage.BackColor = Color.White;

            // Thêm TabPage vào TabControl
            tabPhieuNhap.TabPages.Add(newPage);

            // Chuyển sang TabPage vừa tạo
            tabPhieuNhap.SelectedTab = newPage;
            txtNgayLap.Text = string.Empty;

            txtTimNCC.Text = string.Empty;
            txtTimNCC.ReadOnly = false;
            txtTimNCC.IconRight = Properties.Resources.Search;
            txtTimNCC.IconLeft = Properties.Resources.Plus;
            //isCloseIconVisible = false;  // Reset trạng thái

            txtMaPhieuNhap.Text = string.Empty;
            txtNgayLap.Text = string.Empty;
            lbTongTien.Text = string.Empty;
            txtTongSoHang.Text = string.Empty;
            lstCTPN.Clear();
            lstUCSP.Clear();
            newPage.Controls.Clear();
        }

    }
}
