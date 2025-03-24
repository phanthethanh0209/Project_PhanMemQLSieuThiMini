using BUL;
using DTO;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace QLSieuThiMini_Nhom13
{
    public partial class FrmThuongHieu : Form
    {
        private ThuongHieuBUL bul = new ThuongHieuBUL();

        string tacVu = "Xem";

        public FrmThuongHieu()
        {
            InitializeComponent();
        }

        private void FrmThuongHieu_Load(object sender, EventArgs e)
        {
            TaiManHinh();
            EnableTextBox(false);
            txtMaTH.Enabled = false;
        }

        private void TaiManHinh()
        {
            dgvThuongHieu.DataSource = bul.LayTatCaThuongHieu();
            binding();
            dgvThuongHieu.AutoGenerateColumns = false;
            dgvThuongHieu.ReadOnly = true;
        }

        public void binding()
        {
            txtMaTH.DataBindings.Clear();
            txtMaTH.DataBindings.Add("Text", dgvThuongHieu.DataSource, "MaThuongHieu");
            txtTenTH.DataBindings.Clear();
            txtTenTH.DataBindings.Add("Text", dgvThuongHieu.DataSource, "TenThuongHieu");
        }

        private void btnCRUD_UC1_ThemClicked(object sender, EventArgs e)
        {
            EnableTextBox(true);
            tacVu = "Them";
        }

        private void btnCRUD_UC1_SuaClicked(object sender, EventArgs e)
        {
            EnableTextBox(true);
            tacVu = "Sua";
        }

        private void btnCRUD_UC1_XoaClicked(object sender, EventArgs e)
        {
            EnableTextBox(true);
            tacVu = "Xoa";
        }

        private void btnCRUD_UC1_HuyClicked(object sender, EventArgs e)
        {
            EnableTextBox(false);
            tacVu = "Huy";
        }

        private void btnCRUD_UC1_LuuClicked(object sender, EventArgs e)
        {
            string maTH = txtMaTH.Text;
            string tenTH = txtTenTH.Text;
            ThuongHieuDTO th = new ThuongHieuDTO(maTH, tenTH);

            if (tacVu == "Them")
            {
                DialogResult result = MessageBox.Show("Bạn có muốn thêm không?", "Thêm", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button1);
                if (result == DialogResult.Yes)
                {
                    if (kiemTraDayDu())
                    {
                        if (bul.ThemThuongHieu(th))
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
                        if (bul.SuaThuongHieu(th))
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
                        if (bul.XoaThuongHieu(th))
                        {
                            MessageBox.Show("Xóa thành công", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1);
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

            EnableTextBox(false);
            TaiManHinh();
        }
        
        private void EnableTextBox(bool status)
        {
            txtTenTH.Enabled = status;
        }

        private void xoaTextbox()
        {
            txtMaTH.Clear();
            txtTenTH.Clear();
        }
        private bool kiemTraDayDu()
        {
            if (txtTenTH.Text.Length == 0)
            {
                MessageBox.Show("Vui lòng nhập đầy đủ thông tin", "Cảnh báo", MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1);
                return false;
            }
            return true;
        }
    }
}
