using BUL;
using DTO;
using System;
using System.Windows.Forms;


namespace QLSieuThiMini_Nhom13
{
    public partial class FrmNguoiDung : Form
    {
        NguoiDungBUL bul;
        public FrmNguoiDung()
        {
            InitializeComponent();
            bul = new NguoiDungBUL();
        }

        string tacVu = "Xem";
        private void FrmNguoiDung_Load(object sender, EventArgs e)
        {
            loadDgvNguoiDung();
        }

        public void loadDgvNguoiDung()
        {
            dgvNguoiDung.DataSource = bul.layTatCaNguoiDung();
            lienKetDgvVaTextbox();
            dgvNguoiDung.AutoGenerateColumns = false;
            dgvNguoiDung.ReadOnly = true;
        }

        public void lienKetDgvVaTextbox()
        {
            txtMaND.DataBindings.Clear();
            txtMaND.DataBindings.Add("Text", dgvNguoiDung.DataSource, "MaND");
            txtTenTK.DataBindings.Clear();
            txtTenTK.DataBindings.Add("Text", dgvNguoiDung.DataSource, "TenTK");
            txtTenND.DataBindings.Clear();
            txtTenND.DataBindings.Add("Text", dgvNguoiDung.DataSource, "TenND");
            txtMatKhau.DataBindings.Clear();
            txtMatKhau.DataBindings.Add("Text", dgvNguoiDung.DataSource, "MatKhau");
            ckbHoatDong.DataBindings.Clear();
            ckbHoatDong.DataBindings.Add("Checked", dgvNguoiDung.DataSource, "HoatDong");
        }

        private void btnCRUD_UC1_ThemClicked(object sender, EventArgs e)
        {
            tacVu = "Them";
        }

        private void btnCRUD_UC1_SuaClicked(object sender, EventArgs e)
        {
            tacVu = "Sua";
        }

        private void btnCRUD_UC1_XoaClicked(object sender, EventArgs e)
        {
            tacVu = "Xoa";
        }

        private void btnCRUD_UC1_HuyClicked(object sender, EventArgs e)
        {
            tacVu = "Huy";
            xoaTextbox();
        }

        private void btnCRUD_UC1_LuuClicked(object sender, EventArgs e)
        {
            string maND = txtMaND.Text;
            string tenND = txtTenND.Text;
            string tenTK = txtTenTK.Text;
            string mk = txtMatKhau.Text;
            int hd = ckbHoatDong.Checked ? 1 : 0;
            NguoiDungDTO nd = new NguoiDungDTO(maND, tenTK, tenND, mk, hd);

            if (tacVu == "Them")
            {
                DialogResult result = MessageBox.Show("Bạn có muốn thêm không?", "Thêm", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button1);
                if (result == DialogResult.Yes)
                {
                    if (kiemTraDayDu())
                    {
                        if (bul.themNguoiDung(nd))
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
            else if( tacVu== "Sua")
            {
                DialogResult result = MessageBox.Show("Bạn có muốn sửa không?", "Sửa", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button1);
                if (result == DialogResult.Yes)
                {
                    if (kiemTraDayDu())
                    {
                        if (bul.suaNguoiDung(nd))
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
            else if( tacVu == "Xoa")
            {
                DialogResult result = MessageBox.Show("Bạn có muốn xóa không?", "Xóa", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button1);
                if (result == DialogResult.Yes)
                {
                    if (kiemTraDayDu())
                    {
                        if (bul.xoaNguoiDung(nd))
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
            else
            {
                tacVu = "Xem";
            }

            loadDgvNguoiDung();
        }
        void xoaTextbox()
        {
            txtTenND.Clear();
            txtTenTK.Clear();
            txtMatKhau.Clear();
            ckbHoatDong.Checked = false;
        }
        bool kiemTraDayDu()
        {
            if( txtMaND.Text.Length == 0 || txtTenND.Text.Length == 0 || txtTenTK.Text.Length == 0|| txtMatKhau.Text.Length == 0)
            {
                MessageBox.Show("Vui lòng chọn đầy đủ thông tin", "Cảnh báo", MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1);
                return false;
            }    
            return true;
        }
    }
}
