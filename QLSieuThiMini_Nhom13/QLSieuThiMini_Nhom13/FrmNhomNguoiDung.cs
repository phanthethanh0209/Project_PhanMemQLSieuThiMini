using BUL;
using DTO;
using System.Windows.Forms;

namespace QLSieuThiMini_Nhom13
{
    public partial class FrmNhomNguoiDung : Form
    {
        public FrmNhomNguoiDung()
        {
            InitializeComponent();
        }

        NhomNguoiDungBUL bul;

        private void FrmNhomNguoiDung_Load(object sender, System.EventArgs e)
        {
            bul = new NhomNguoiDungBUL();
            loadData();
            anHienText(false);

            txtGhiChu.Multiline = true;    // Cho phép nhập nhiều dòng
            txtGhiChu.ScrollBars = ScrollBars.Vertical;  // Thêm thanh cuộn dọc
            txtGhiChu.Width = 200;
            txtGhiChu.Height = 100;

        }

        public void lienKet()
        {
            lbMaNhom.DataBindings.Clear();
            lbMaNhom.DataBindings.Add("Text", dgvNhomND.DataSource, "MaNhom");
            txtGhiChu.DataBindings.Clear();
            txtGhiChu.DataBindings.Add("Text", dgvNhomND.DataSource, "GhiChu");
            txtTenND.DataBindings.Clear();
            txtTenND.DataBindings.Add("Text", dgvNhomND.DataSource, "TenNhom");
        }

        string tacVu = "";

        public void loadData()
        {
            dgvNhomND.AutoGenerateColumns = false;
            dgvNhomND.ReadOnly = true;
            dgvNhomND.DataSource = bul.layDSNhomND();
            lienKet();
        }

        private bool kiemTraThongTin()
        {
            if (txtTenND.Text.Length == 0 || txtGhiChu.Text.Length == 0)
            {
                MessageBox.Show("Vui lòng nhập đầy đủ thông tin", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }
            return true;
        }

        private void anHienText(bool t)
        {
            txtTenND.Enabled = t;
            txtGhiChu.Enabled = t;
        }

        private void xoaTextbox()
        {
            lbMaNhom.Text = "";
            txtTenND.Clear();
            txtGhiChu.Clear();
        }

        private void btnCRUD_UC1_HuyClicked(object sender, System.EventArgs e)
        {
            tacVu = "Huy";
            anHienText(false);
        }

        private void btnCRUD_UC1_XoaClicked(object sender, System.EventArgs e)
        {
            tacVu = "Xoa";
            anHienText(false);
        }

        private void btnCRUD_UC1_ThemClicked(object sender, System.EventArgs e)
        {
            tacVu = "Them";
            anHienText(true);
            xoaTextbox();
            lbMaNhom.Text = "Nhom04";
        }

        private void btnCRUD_UC1_LuuClicked(object sender, System.EventArgs e)
        {

            if (kiemTraThongTin())
            {
                NhomNguoiDungDTO dto = new NhomNguoiDungDTO(lbMaNhom.Text, txtTenND.Text, txtGhiChu.Text);

                if (tacVu == "Them")
                {
                    DialogResult rs = MessageBox.Show("Bạn có muốn thêm nhóm người dùng?", "Thông Báo", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                    if (rs == DialogResult.Yes)
                    {
                        if (bul.themNhomND(dto))
                        {
                            MessageBox.Show("Thêm người dùng thành công", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        }
                        else
                        {
                            MessageBox.Show("Thêm người dùng thất bại", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        }

                    }

                }
                else if (tacVu == "Sua")
                {
                    DialogResult rs = MessageBox.Show("Bạn có muốn sửa nhóm người dùng?", "Thông Báo", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                    if (rs == DialogResult.Yes)
                    {
                        if (bul.suaNhomND(dto))
                        {
                            MessageBox.Show("Sửa người dùng thành công", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        }
                        else
                        {
                            MessageBox.Show("Sửa người dùng thất bại", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        }
                    }
                }
                else if (tacVu == "Xoa")
                {
                    DialogResult rs = MessageBox.Show("Bạn có muốn xóa nhóm người dùng?", "Thông Báo", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                    if (rs == DialogResult.Yes)
                    {
                        if (bul.xoaNhomND(dto))
                        {
                            MessageBox.Show("Xóa người dùng thành công", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        }
                        else
                        {
                            MessageBox.Show("Xóa người dùng thất bại", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        }
                    }
                }
            }
            anHienText(false);
            xoaTextbox();
            loadData();
            tacVu = "";
        }

        private void btnCRUD_UC1_SuaClicked(object sender, System.EventArgs e)
        {
            tacVu = "Sua";
            anHienText(true);
        }

        private void btnCRUD_UC1_Load(object sender, System.EventArgs e)
        {

        }
    }
}
