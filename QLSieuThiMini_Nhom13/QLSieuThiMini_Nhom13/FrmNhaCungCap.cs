using BUL;
using DTO;
using System;
using System.Linq;
using System.Net.Mail;
using System.Windows.Forms;

namespace QLSieuThiMini_Nhom13
{
    public partial class FrmNhaCungCap : Form
    {
        NhaCungCapBUL bul;
        bool phieuNhap = false;
        public string MaNCC_PN { get; private set; }
        public string SDT_PN { get; private set; }

        public bool batForm = false;
        public string sdtNCC;
        public FrmNhaCungCap(bool phieuNhapHang)
        {
            InitializeComponent();
            bul = new NhaCungCapBUL();
            phieuNhap = phieuNhapHang;


        }

        public FrmNhaCungCap()
        {
            InitializeComponent();
            bul = new NhaCungCapBUL();
        }

        string tacVu = "Xem";
        private void FrmNhaCungCap_Load(object sender, EventArgs e)
        {
            txtMaNCC.Enabled = false;

            hienThiDgvNhaCungCap();
            EnableTextBox(false);

            if (phieuNhap)
            {
                //kích hoạt nút thêm
                btnCRUD_UC1_ThemClicked(this, EventArgs.Empty); //cái này là nó chưa click vào hả? tôi muốn nó tự click mà

                //btnCRUD_UC1_ThemClicked += btnCRUD_UC1_ThemClicked;
            }

        }

        public void hienThiDgvNhaCungCap()
        {
            dgvNhaCungCap.AutoGenerateColumns = false;
            dgvNhaCungCap.ReadOnly = true;
            dgvNhaCungCap.DataSource = bul.layTatCaNhaCungCap();
            lienKetDgvVaTextbox();
        }

        public void lienKetDgvVaTextbox()
        {
            txtMaNCC.DataBindings.Clear();
            txtMaNCC.DataBindings.Add("Text", dgvNhaCungCap.DataSource, "MaNCC");

            txtTenNCC.DataBindings.Clear();
            txtTenNCC.DataBindings.Add("Text", dgvNhaCungCap.DataSource, "TenNCC");

            txtEmail.DataBindings.Clear();
            txtEmail.DataBindings.Add("Text", dgvNhaCungCap.DataSource, "Email");

            txtSDT.DataBindings.Clear();
            txtSDT.DataBindings.Add("Text", dgvNhaCungCap.DataSource, "SDT");

            txtDiaChi.DataBindings.Clear();
            txtDiaChi.DataBindings.Add("Text", dgvNhaCungCap.DataSource, "DiaChi");

            txtWebsite.DataBindings.Clear();
            txtWebsite.DataBindings.Add("Text", dgvNhaCungCap.DataSource, "Website");
        }

        private void btnCRUD_UC1_ThemClicked(object sender, EventArgs e)
        {
            tacVu = "Them";
            EnableTextBox(true);
        }

        private void btnCRUD_UC1_SuaClicked(object sender, EventArgs e)
        {
            tacVu = "Sua";
            EnableTextBox(true);
        }

        private void btnCRUD_UC1_XoaClicked(object sender, EventArgs e)
        {
            tacVu = "Xoa";
            EnableTextBox(true);

            if (phieuNhap)//từ form phiếu nhập qua thì xóa luôn MaNCC_PN
            {
                MaNCC_PN = null;
                SDT_PN = null;
            }
        }

        private void btnCRUD_UC1_HuyClicked(object sender, EventArgs e)
        {
            tacVu = "Huy";
            xoaTextbox();
            EnableTextBox(false);
        }

        private void btnCRUD_UC1_LuuClicked(object sender, EventArgs e)
        {
            string maNCC = txtMaNCC.Text;
            string email = txtEmail.Text;
            string tenNCC = txtTenNCC.Text;
            string sDT = txtSDT.Text;
            string website = txtWebsite.Text;
            string diaChi = txtDiaChi.Text;
            NhaCungCapDTO nd = new NhaCungCapDTO(maNCC, tenNCC, sDT, email, diaChi, website);

            if (!CheckSDT(sDT))
            {
                MessageBox.Show("Số điện thoại không đúng!", "Cảnh báo", MessageBoxButtons.OK, MessageBoxIcon.Warning, MessageBoxDefaultButton.Button1);
                return;
            }
            else if (!CheckWebsite(website))
            {
                MessageBox.Show("Địa chỉ website không hợp lệ!", "Cảnh báo", MessageBoxButtons.OK, MessageBoxIcon.Warning, MessageBoxDefaultButton.Button1);
                return;
            }
            else if (!CheckEmail(email))
            {
                MessageBox.Show("Email không hợp lệ!", "Cảnh báo", MessageBoxButtons.OK, MessageBoxIcon.Warning, MessageBoxDefaultButton.Button1);
                return;
            }

            if (bul.kiemTraTrungSDT(sDT))
            {
                MessageBox.Show("Số điện thoại đã tồn tại!", "Cảnh báo", MessageBoxButtons.OK, MessageBoxIcon.Warning, MessageBoxDefaultButton.Button1);
                return;
            }

            if (tacVu == "Them")
            {
                DialogResult result = MessageBox.Show("Bạn có muốn thêm không?", "Thêm", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button1);
                if (result == DialogResult.Yes)
                {
                    if (kiemTraDayDu())
                    {
                        if (bul.themNhaCungCap(nd))
                        {
                            MessageBox.Show("Thêm thành công", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1);
                        }
                        else
                        {
                            MessageBox.Show("Thêm không thành công", "Cảnh báo", MessageBoxButtons.OK, MessageBoxIcon.Warning, MessageBoxDefaultButton.Button1);
                        }
                    }
                }

            }
            else if (tacVu == "Sua")
            {
                DialogResult result = MessageBox.Show("Bạn có muốn sửa không?", "Sửa", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button1);
                if (result == DialogResult.Yes)
                {
                    if (kiemTraDayDu())
                    {
                        if (bul.suaNhaCungCap(nd))
                        {
                            MessageBox.Show("Sửa thành công", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1);
                        }
                        else
                        {
                            MessageBox.Show("Sửa không thành công", "Cảnh báo", MessageBoxButtons.OK, MessageBoxIcon.Warning, MessageBoxDefaultButton.Button1);
                        }
                    }
                }
            }
            else if (tacVu == "Xoa")
            {
                DialogResult result = MessageBox.Show("Bạn có muốn xóa không?", "Xóa", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button1);
                if (result == DialogResult.Yes)
                {
                    if (kiemTraDayDu())
                    {
                        if (bul.xoaNhaCungCap(maNCC))
                        {
                            MessageBox.Show("Xoa thành công", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1);
                        }
                        else
                        {
                            MessageBox.Show("Xoá không thành công", "Cảnh báo", MessageBoxButtons.OK, MessageBoxIcon.Warning, MessageBoxDefaultButton.Button1);
                        }
                    }
                }
            }
            //else
            //{
            //    tacVu = "Xem";
            //}

            hienThiDgvNhaCungCap();

            if (tacVu == "Them" && phieuNhap)
            {
                MaNCC_PN = maNCC;
                SDT_PN = sDT;
            }

            EnableTextBox(true);
        }
        void xoaTextbox()
        {
            txtEmail.Clear();
            txtTenNCC.Clear();
            txtSDT.Clear();
            txtDiaChi.Clear();
            txtWebsite.Clear();
        }
        private void EnableTextBox(bool status)
        {
            txtEmail.Enabled = status;
            txtTenNCC.Enabled = status;
            txtSDT.Enabled = status;
            txtDiaChi.Enabled = status;
            txtWebsite.Enabled = status;
        }

        bool kiemTraDayDu()
        {
            if (txtEmail.Text.Length == 0 || txtTenNCC.Text.Length == 0 || txtSDT.Text.Length == 0 || txtDiaChi.Text.Length == 0 || txtWebsite.Text.Length == 0)
            {
                MessageBox.Show("Vui lòng chọn đầy đủ thông tin", "Cảnh báo", MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1);
                return false;
            }
            return true;
        }

        private bool CheckSDT(string phoneNumber)
        {
            // Kiểm tra nếu chuỗi chỉ chứa số và có độ dài từ 10 đến 15 ký tự
            return phoneNumber.All(char.IsDigit) && phoneNumber.Length >= 10 && phoneNumber.Length <= 15;
        }

        private bool CheckEmail(string email)
        {
            if (string.IsNullOrEmpty(email))
                return false;
            try
            {
                MailAddress mailAddress = new MailAddress(email);
                return true;
            }
            catch (FormatException)
            {
                return false;
            }
        }

        private bool CheckWebsite(string url)
        {
            if (Uri.TryCreate(url, UriKind.Absolute, out Uri uriResult))
            {
                // Kiểm tra nếu URL có một scheme hợp lệ (http, https, ftp, v.v.)
                return (uriResult.Scheme == Uri.UriSchemeHttp || uriResult.Scheme == Uri.UriSchemeHttps);
            }
            return false;
        }
    }
}
