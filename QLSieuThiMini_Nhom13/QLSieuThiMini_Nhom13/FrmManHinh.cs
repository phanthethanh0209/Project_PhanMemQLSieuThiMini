using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using BUL;
using DTO;

namespace QLSieuThiMini_Nhom13
{
    public partial class FrmManHinh : Form
    {
        private ManHinhBUL bul = new ManHinhBUL();

        string tacVu = "Xem";

        public FrmManHinh()
        {
            InitializeComponent();
        }

        private void FrmManHinh_Load(object sender, EventArgs e)
        {
            TaiManHinh();
            EnableTextBox(false);
            txtMaMH.Enabled = false;
        }

        private void TaiManHinh()
        {
            dgvManHinh.DataSource = bul.LayTatCaManHinh();
            binding();
            dgvManHinh.AutoGenerateColumns = false;
            dgvManHinh.ReadOnly = true;
        }

        public void binding()
        {
            txtMaMH.DataBindings.Clear();
            txtMaMH.DataBindings.Add("Text", dgvManHinh.DataSource, "MaMH");
            txtTenMH.DataBindings.Clear();
            txtTenMH.DataBindings.Add("Text", dgvManHinh.DataSource, "TenMH");
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
            string maMH = txtMaMH.Text;
            string tenMH = txtTenMH.Text;
            ManHinhDTO mh = new ManHinhDTO(maMH, tenMH);

            if (tacVu == "Them")
            {
                DialogResult result = MessageBox.Show("Bạn có muốn thêm không?", "Thêm", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button1);
                if (result == DialogResult.Yes)
                {
                    if (kiemTraDayDu())
                    {
                        if (bul.ThemManHinh(mh))
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
                        if (bul.SuaManHinh(mh))
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
                        if (bul.XoaManHinh(mh))
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
            txtTenMH.Enabled = status;
        }

        private void xoaTextbox()
        {
            txtMaMH.Clear();
            txtMaMH.Clear();
        }
        private bool kiemTraDayDu()
        {
            if (txtTenMH.Text.Length == 0)
            {
                MessageBox.Show("Vui lòng nhập đầy đủ thông tin", "Cảnh báo", MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1);
                return false;
            }
            return true;
        }
    }
}
