using BUL;
using DTO;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace QLSieuThiMini_Nhom13
{
    public partial class FrmLoaiSanPham : Form
    {
        private LoaiSanPhamBUL bul = new LoaiSanPhamBUL();

        string tacVu = "Xem";

        public FrmLoaiSanPham()
        {
            InitializeComponent();
        }

        private void FrmLoaiSanPham_Load(object sender, EventArgs e)
        {
            TaiManHinh();
            EnableTextBox(false);
            txtMaLoai.Enabled = false;
        }

        private void TaiManHinh()
        {
            dgvLoaiSP.DataSource = bul.LayTatCaLoaiSP();
            binding();
            dgvLoaiSP.AutoGenerateColumns = false;
            dgvLoaiSP.ReadOnly = true;
        }

        public void binding()
        {
            txtMaLoai.DataBindings.Clear();
            txtMaLoai.DataBindings.Add("Text", dgvLoaiSP.DataSource, "MaLoai");
            txtTenLoai.DataBindings.Clear();
            txtTenLoai.DataBindings.Add("Text", dgvLoaiSP.DataSource, "TenLoai");
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
            string maLoai = txtMaLoai.Text;
            string tenLoai = txtTenLoai.Text;
            LoaiSanPhamDTO lsp = new LoaiSanPhamDTO(maLoai, tenLoai);

            if (tacVu == "Them")
            {
                DialogResult result = MessageBox.Show("Bạn có muốn thêm không?", "Thêm", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button1);
                if (result == DialogResult.Yes)
                {
                    if (kiemTraDayDu())
                    {
                        if (bul.ThemLoaiSP(lsp))
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
                        if (bul.SuaLoaiSP(lsp))
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
                        if (bul.XoaLoaiSP(lsp))
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
            txtTenLoai.Enabled = status;
        }

        private void xoaTextbox()
        {
            txtMaLoai.Clear();
            txtTenLoai.Clear();
        }
        private bool kiemTraDayDu()
        {
            if (txtTenLoai.Text.Length == 0)
            {
                MessageBox.Show("Vui lòng nhập đầy đủ thông tin", "Cảnh báo", MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1);
                return false;
            }
            return true;
        }
    }
}
