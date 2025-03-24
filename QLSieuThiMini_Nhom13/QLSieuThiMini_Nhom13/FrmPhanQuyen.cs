using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using DTO;
using BUL;

namespace QLSieuThiMini_Nhom13
{
    public partial class FrmPhanQuyen : Form
    {
        ManHinhBUL manHinhBUL = new ManHinhBUL();
        PhanQuyenBUL phanQuyenBUL = new PhanQuyenBUL();

        private List<NhomNguoiDungDTO> listNhomNguoiDungBUL = new List<NhomNguoiDungDTO>();
        private List<PhanQuyenDTO> listNhomNguoiDungCoManHinh = new List<PhanQuyenDTO>();

        public FrmPhanQuyen()
        {
            InitializeComponent();
        }

        private void FrmPhanQuyen_Load(object sender, EventArgs e)
        {
            loadDgvNhomNguoiDung();
            loadCboManHinh();
            cboManHinh.SelectedIndex = -1;
            dgvNhomNguoiDungCoManHinh.DataSource = null;
            dgvNhomNguoiDungChuaCoManHinh.DataSource = null;
        }

        private void loadCboManHinh()
        {
            cboManHinh.DataSource = manHinhBUL.LayTatCaManHinh();
            cboManHinh.ValueMember = "MaMH";
            cboManHinh.DisplayMember = "TenMH";
        }

        private void loadDgvNhomNguoiDung()
        {
            dgvNhomNguoiDungChuaCoManHinh.AutoGenerateColumns = false;

            //lưu vào list trước khi lưu vào datagridview
            if (cboManHinh.SelectedIndex != -1)
            {
                listNhomNguoiDungBUL = phanQuyenBUL.LayNhomNguoiDungChuaCoManHinh(cboManHinh.SelectedValue.ToString());
                dgvNhomNguoiDungChuaCoManHinh.DataSource = new BindingList<NhomNguoiDungDTO>(listNhomNguoiDungBUL);
            }
        }

        private void loadDgvNhomNguoiDungTrongNhom()
        {
            dgvNhomNguoiDungCoManHinh.AutoGenerateColumns = false;

            //lưu vào list trước khi lưu vào datagridview
            if (cboManHinh.SelectedIndex != -1)
            {
                listNhomNguoiDungCoManHinh = phanQuyenBUL.LayNhomNguoiDungCoManHinh(cboManHinh.SelectedValue.ToString());
                dgvNhomNguoiDungCoManHinh.DataSource = new BindingList<PhanQuyenDTO>(listNhomNguoiDungCoManHinh);
            }
        }

        private void cboManHinh_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cboManHinh.SelectedIndex != -1)
            {
                loadDgvNhomNguoiDung();
                loadDgvNhomNguoiDungTrongNhom();
            }
        }

        private void btnThem_Click(object sender, System.EventArgs e)
        {
            DialogResult result = MessageBox.Show("Bạn có muốn thêm không?", "Thêm", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button1);

            if (result == DialogResult.Yes)
            {
                if (cboManHinh.SelectedIndex != -1 && dgvNhomNguoiDungChuaCoManHinh.SelectedRows.Count != 0)
                {
                    string maNhom = dgvNhomNguoiDungChuaCoManHinh.SelectedRows[0].Cells[0].Value.ToString();
                    string tenNhom = dgvNhomNguoiDungChuaCoManHinh.SelectedRows[0].Cells[1].Value.ToString();
                    string maMH = cboManHinh.SelectedValue.ToString();
                    string tenMH = cboManHinh.SelectedText;
                    string ghiChu = ucGhiChu.Textbox;
                    PhanQuyenDTO dto = new PhanQuyenDTO(maNhom, maMH, tenNhom, tenMH, ghiChu);
                    if (phanQuyenBUL.themQuyen(dto))
                    {
                        MessageBox.Show("Thêm thành công", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1);
                        //xóa dòng đó ra khỏi datagridview
                        listNhomNguoiDungBUL.RemoveAt(dgvNhomNguoiDungChuaCoManHinh.SelectedRows[0].Index);
                        dgvNhomNguoiDungChuaCoManHinh.DataSource = new BindingList<NhomNguoiDungDTO>(listNhomNguoiDungBUL);
                    }
                    else
                        MessageBox.Show("Thêm không thành công", "Cảnh báo", MessageBoxButtons.OK, MessageBoxIcon.Warning, MessageBoxDefaultButton.Button1);
                    loadDgvNhomNguoiDung();
                    loadDgvNhomNguoiDungTrongNhom();
                }
                else
                {
                    MessageBox.Show("Vui lòng chọn đầy đủ thông tin");
                }
            }
        }

        private void btnXoa_Click(object sender, System.EventArgs e)
        {
            DialogResult result = MessageBox.Show("Bạn có muốn xóa không?", "Thêm", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button1);

            if (result == DialogResult.Yes)
            {
                if (cboManHinh.SelectedIndex != -1 && dgvNhomNguoiDungCoManHinh.SelectedRows.Count != 0)
                {
                    string maNhom = dgvNhomNguoiDungCoManHinh.SelectedRows[0].Cells[0].Value.ToString();
                    string maMH = dgvNhomNguoiDungCoManHinh.SelectedRows[0].Cells[1].Value.ToString();
                    PhanQuyenDTO dto = new PhanQuyenDTO(maNhom, maMH, "", "", "");
                    if (phanQuyenBUL.xoaQuyen(dto))
                    {
                        MessageBox.Show("Xóa thành công", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1);
                        //xóa dòng đó ra khỏi datagridview
                        //listNhomNguoiDungBUL.RemoveAt(dgvNhomNguoiDungCoManHinh.SelectedRows[0].Index);
                        dgvNhomNguoiDungCoManHinh.DataSource = new BindingList<NhomNguoiDungDTO>(listNhomNguoiDungBUL);
                    }
                    else
                        MessageBox.Show("Xóa không thành công", "Cảnh báo", MessageBoxButtons.OK, MessageBoxIcon.Warning, MessageBoxDefaultButton.Button1);
                    loadDgvNhomNguoiDung();
                    loadDgvNhomNguoiDungTrongNhom();
                }
                else
                {
                    MessageBox.Show("Vui lòng chọn đầy đủ thông tin");
                }
            }
        }

    }
}
