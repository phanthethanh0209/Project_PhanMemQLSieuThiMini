using BUL;
using DTO;
using System.Linq;
using System.Net.Mail;
using System.Windows.Forms;
using System;

namespace QLSieuThiMini_Nhom13
{
    public partial class FrmKhachHang : Form
    {
        KhachHangBUL bul = new KhachHangBUL();

        public string sdtKH;
        public bool batForm;

        public FrmKhachHang()
        {
            InitializeComponent();
        }

        string tacVu = "Xem";

        private void FrmKhachHang_Load(object sender, EventArgs e)
        {
            txtMaKH.Enabled = false;
            EnableTextBox(false);
            loadDgvKhachHang();
        }

        public void loadDgvKhachHang()
        {
            dgvKhachHang.DataSource = bul.LayTatCaKhachHang();
            lienKetDgvVaTextbox();
            dgvKhachHang.AutoGenerateColumns = false;
            dgvKhachHang.ReadOnly = true;
        }

        public void lienKetDgvVaTextbox()
        {
            txtMaKH.DataBindings.Clear();
            txtMaKH.DataBindings.Add("Text", dgvKhachHang.DataSource, "MaKH");
            txtTenKH.DataBindings.Clear();
            txtTenKH.DataBindings.Add("Text", dgvKhachHang.DataSource, "TenKH");
            txtSDT.DataBindings.Clear();
            txtSDT.DataBindings.Add("Text", dgvKhachHang.DataSource, "SDT");
            txtEmail.DataBindings.Clear();
            txtEmail.DataBindings.Add("Text", dgvKhachHang.DataSource, "Email");
            txtDiemTichLuy.DataBindings.Clear();
            txtDiemTichLuy.DataBindings.Add("Text", dgvKhachHang.DataSource, "DiemTichLuy");
        }

        private void btnCRUD_UC1_ThemClicked(object sender, EventArgs e)
        {
            tacVu = "Them";
            xoaTextbox();
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
        }

        private void btnCRUD_UC1_HuyClicked(object sender, EventArgs e)
        {
            tacVu = "Huy";
            EnableTextBox(false);
            xoaTextbox();
        }

        private void btnCRUD_UC1_LuuClicked(object sender, EventArgs e)
        {
            string maKH = txtMaKH.Text;
            string tenKH = txtTenKH.Text;
            string sdt = txtSDT.Text;
            string email = txtEmail.Text;
            int diemTL = 0;

            if (!string.IsNullOrEmpty(txtDiemTichLuy.Text))
            {
                diemTL = int.Parse(txtDiemTichLuy.Text);
            }
            KhachHangDTO kh = new KhachHangDTO(maKH, tenKH, sdt, email, diemTL);

            if (!CheckSDT(sdt))
            {
                MessageBox.Show("Số điện thoại không đúng!", "Cảnh báo", MessageBoxButtons.OK, MessageBoxIcon.Warning, MessageBoxDefaultButton.Button1);
                return;
            }
            else if (!CheckEmail(email))
            {
                MessageBox.Show("Email không hợp lệ!", "Cảnh báo", MessageBoxButtons.OK, MessageBoxIcon.Warning, MessageBoxDefaultButton.Button1);
                return;
            }

            if (tacVu == "Them")
            {
                if (bul.KiemTraTrungSDT(sdt))
                {
                    MessageBox.Show("Số điện thoại đã tồn tại!", "Cảnh báo", MessageBoxButtons.OK, MessageBoxIcon.Warning, MessageBoxDefaultButton.Button1);
                    return;
                }

                DialogResult result = MessageBox.Show("Bạn có muốn thêm không?", "Thêm", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button1);
                if (result == DialogResult.Yes)
                {
                    if (kiemTraDayDu())
                    {
                        if (bul.ThemKhachHang(kh))
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
                        try
                        {
                            if (bul.SuaKhachHang(kh))
                            {
                                MessageBox.Show("Sửa thành công", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1);
                            }
                            else
                            {
                                MessageBox.Show("Sửa không thành công", "Cảnh báo", MessageBoxButtons.OK, MessageBoxIcon.Warning, MessageBoxDefaultButton.Button1);
                            }
                        }
                        catch (Exception)
                        {
                            MessageBox.Show("Sửa không thành công", "Cảnh báo", MessageBoxButtons.OK, MessageBoxIcon.Warning, MessageBoxDefaultButton.Button1);
                            throw;
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
                        try
                        {
                            if (bul.XoaKhachHang(kh))
                            {
                                MessageBox.Show("Xoa thành công", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1);
                            }
                            else
                            {
                                MessageBox.Show("Xoá không thành công", "Cảnh báo", MessageBoxButtons.OK, MessageBoxIcon.Warning, MessageBoxDefaultButton.Button1);
                            }
                        }
                        catch (Exception)
                        {
                            MessageBox.Show("Xoá không thành công", "Cảnh báo", MessageBoxButtons.OK, MessageBoxIcon.Warning, MessageBoxDefaultButton.Button1);
                            throw;
                        }
                        
                    }
                }
            }
            else
            {
                tacVu = "Xem";
            }

            loadDgvKhachHang();

            EnableTextBox(true);
        }
        void xoaTextbox()
        {
            txtMaKH.Clear();
            txtTenKH.Clear();
            txtSDT.Clear();
            txtEmail.Clear();
            txtDiemTichLuy.Clear();
        }

        private void EnableTextBox(bool status)
        {
            txtEmail.Enabled = status;
            txtTenKH.Enabled = status;
            txtSDT.Enabled = status;
            txtDiemTichLuy.Enabled = status;
        }

        bool kiemTraDayDu()
        {
            if (txtTenKH.Text.Length == 0 || txtSDT.Text.Length == 0 || txtEmail.Text.Length == 0 || txtDiemTichLuy.Text.Length == 0)
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

    }
}