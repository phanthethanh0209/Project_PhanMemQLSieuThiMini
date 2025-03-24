using BUL;
using DTO;
using Guna.UI2.WinForms;
using QLSieuThiMini_Nhom13.UserControls;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;

namespace QLSieuThiMini_Nhom13
{
    public partial class FrmChonSPKM : Form
    {
        SanPhamBUL sanPhamBUL;
        LoaiSanPhamBUL lspBUL;
        ThuongHieuBUL thBUL;
        KhuyenMaiBUL kmBUL;
        Guna2MessageDialog message;


        public List<SanPhamDTO> lstSPFormTruoc = new List<SanPhamDTO>();
        public List<SanPhamDTO> lstSPChon = new List<SanPhamDTO>();
        bool loadLoaiXong = false;
        bool loadTHXong = false;
        //bool isSPMua;
        public bool isSPHopLe= false;

        public FrmChonSPKM(List<SanPhamDTO> dsSPFormTruoc)
        {
            InitializeComponent();
            message = new Guna2MessageDialog
            {
                Style = MessageDialogStyle.Light,
            };

            sanPhamBUL = new SanPhamBUL();
            lspBUL = new LoaiSanPhamBUL();
            thBUL = new ThuongHieuBUL();
            kmBUL = new KhuyenMaiBUL();

            btnChon.Enabled = false;

            lstSPFormTruoc = dsSPFormTruoc;
            //isSPMua = isSPMuaa;

            ShowUserControl(sanPhamBUL.layDSSanPham()); //load tất cả sản phẩm
        }

        private void FrmChonSPKM_Load(object sender, EventArgs e)
        {
            loadCboThuongHieu();
            loadCboLoai();
            cboLoaiSp.SelectedIndex = -1;
            cboTH.SelectedIndex = -1;
        
        }

        void loadCboThuongHieu()
        {
            cboTH.DataSource = thBUL.LayTatCaThuongHieu();
            cboTH.DisplayMember = "tenThuongHieu";
            cboTH.ValueMember = "maThuongHieu";
            loadTHXong = true;
        }

        void loadCboLoai()
        {
            cboLoaiSp.DataSource = lspBUL.LayTatCaLoaiSP();
            cboLoaiSp.DisplayMember = "TenLoai";
            cboLoaiSp.ValueMember = "MaLoai";
            loadLoaiXong = true;
        }

        private void ShowUserControl(List<SanPhamDTO> dsSanPham)
        {
            int x = 0; // Tọa độ X của UserControl đầu tiên
            int y = 0; // Tọa độ Y của UserControl đầu tiên
            int controlSpacing = 7; // Khoảng cách giữa các UserControl
            int controlWidth = 110; // Chiều rộng của UserControl
            int controlHeight = 160; // Chiều cao của UserControl

            ShadowPnl.Controls.Clear();
            foreach (SanPhamDTO sp in dsSanPham)
            {
                // Tạo một instance của UserControl
                SanPham_UC myControl = new SanPham_UC(sp.MaSP, sp.TenSP, int.Parse(sp.GiaBan.ToString()), sp.HinhAnh);
                //myControl.Click += new EventHandler(SanPham_UC_Click);

                myControl.Clicked += SanPham_UC_Click;

                myControl.AutoSize = false;
                myControl.Width = controlWidth;
                myControl.Height = controlHeight;

                // Kiểm tra nếu vị trí X cộng với chiều rộng của UserControl vượt quá chiều rộng Panel
                if (x + controlWidth > ShadowPnl.ClientSize.Width)
                {
                    x = 0; // Đặt lại vị trí X về 0 (xuống dòng)
                    y += controlHeight + controlSpacing; // Tăng vị trí Y để xuống dòng
                }

                myControl.Location = new Point(x, y);
                ShadowPnl.Controls.Add(myControl);
                myControl.BringToFront();

                // Tính vị trí X cho UserControl tiếp theo
                x += controlWidth + controlSpacing;
            }

            // Bật cuộn khi cần
            guna2VScrollBar1.BindingContainer = ShadowPnl;
            ShadowPnl.AutoScroll = true;
        }

        private SanPham_UC selectedControl = null;
        private void SanPham_UC_Click(object sender, EventArgs e)
        {
            SanPham_UC control = sender as SanPham_UC;

            if (control != null)
            {
                // Xóa viền của UserControl trước đó nếu không phải là control hiện tại
                //if (selectedControl != null && selectedControl != control)
                //{
                //    selectedControl.BorderStyle = BorderStyle.None;
                //}


                SanPhamDTO sp = sanPhamBUL.layMotSanPham(control.MaSP);

                var spToRemove = lstSPChon.FirstOrDefault(t => t.MaSP == sp.MaSP);
                if (spToRemove != null)
                {
                    control.BorderStyle = BorderStyle.None;
                    
                        lstSPChon.Remove(spToRemove);

                }
                else
                {

                    control.BorderStyle = BorderStyle.FixedSingle;
                    selectedControl = control; // Ghi nhận control hiện tại

                    btnChon.Enabled = true;
                    // Cập nhật viền cho UserControl được chọn
                    lstSPChon.Add(sp);

                }

            }
        }

        bool kiemTraSanPhamCungMenhGia()
        {
            double giaBanChuan = lstSPChon[0].GiaBan;

            foreach (SanPhamDTO sp in lstSPChon)
            {
                if (sp.GiaBan != giaBanChuan)
                {
                    message.Buttons = MessageDialogButtons.OK;
                    message.Icon = MessageDialogIcon.Error;
                    message.Parent = this.ParentForm;
                    message.Show("Các sản phẩm cùng nhóm khuyến mãi phải có mệnh giá ngang nhau! Vui lòng kiểm tra lại", "Thông Báo");
                    return false;
                }
            }

            return true; // Tất cả có cùng giá
        }

        bool kiemTraKM()
        {
            foreach (SanPhamDTO sp in lstSPChon)
            {
                KhuyenMaiDTO km = kmBUL.layKMCuaSanPham(sp.MaSP);
                if (km != null)
                {
                    message.Buttons = MessageDialogButtons.OK;
                    message.Icon = MessageDialogIcon.Error;
                    message.Parent = this.ParentForm;
                    message.Show("Sản phẩm '" + sp.TenSP + "' đang được áp dụng khuyến mãi '" + km.TenKM + "' ! Hãy chọn sản phẩm khác ", "Thông Báo");
                    return false;
                }
            }
            return true;            

        } 

        private void btnChon_Click(object sender, System.EventArgs e)
        {
            if( lstSPChon.Count > 0 && kiemTraSanPhamCungMenhGia() && kiemTraKM()      ) //sp tặng
            {
                isSPHopLe = true;
                this.Close();
            }  

        }
              

        private void cboTH_SelectedIndexChanged(object sender, EventArgs e)
        {
            if(loadTHXong && cboTH.SelectedIndex >=0)
            {
                ShowUserControl(sanPhamBUL.layDSSanPhamTheoThuongHieu(cboTH.SelectedValue.ToString()));
                cboLoaiSp.SelectedIndex = -1;
                ckXemTatCa.Checked = false;
            }    
        }

        private void cboLoaiSp_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (loadLoaiXong && cboLoaiSp.SelectedIndex >= 0)
            {
                ShowUserControl(sanPhamBUL.layDSSanPhamTheoLoai(cboLoaiSp.SelectedValue.ToString()));
                cboTH.SelectedIndex = -1;
                ckXemTatCa.Checked = false;
            }
        }

        private void ckXemTatCa_CheckedChanged(object sender, EventArgs e)
        {
            if (ckXemTatCa.Checked)
            {
                ShowUserControl(sanPhamBUL.layDSSanPham());
                cboLoaiSp.SelectedIndex = -1;
                cboTH.SelectedIndex = -1;
            }
        }

        private void txtSanPham_TextChanged(object sender, EventArgs e)
        {
            ShowUserControl(sanPhamBUL.timKiemSPTheoMaHoacTen(txtSanPham.Text));
        }
    }
}
