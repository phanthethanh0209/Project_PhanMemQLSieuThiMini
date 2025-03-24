using BUL;
using DTO;
using System.Collections.Generic;
using System.ComponentModel;
using System.Windows.Forms;

namespace QLSieuThiMini_Nhom13
{
    public partial class FrmND_NhomND : Form
    {
        public FrmND_NhomND()
        {
            InitializeComponent();
        }

        NhomNguoiDungBUL nhomNDBul = new NhomNguoiDungBUL();
        NguoiDungBUL nguoiDungBul = new NguoiDungBUL();
        ND_NhomNDBUL nD_NhomNdBul = new ND_NhomNDBUL();

        private List<NguoiDungDTO> lstNguoiDung;
        private List<ND_NhomNDDTO> lstND_NhomND;

        private void FrmND_NhomND_Load(object sender, System.EventArgs e)
        {
            loadDgvNguoiDung();
            loadCboNhomNguoiDung();
            cboNhomND.SelectedIndex = -1;
            dgvNguoiDungTrongNhom.DataSource = null;
            dgvNguoiDung.DataSource = null;
        }

        void loadCboNhomNguoiDung()
        {
            cboNhomND.DataSource = nhomNDBul.layDSNhomND();
            cboNhomND.ValueMember = "MaNhom";
            cboNhomND.DisplayMember = "TenNhom";
        }

        void loadDgvNguoiDung()
        {
            dgvNguoiDungTrongNhom.AutoGenerateColumns = false;

            //lưu vào list trước khi lưu vào datagridview
            if (cboNhomND.SelectedIndex != -1)
            {
                lstNguoiDung = nguoiDungBul.layNDConHoatDongVaKoCoTrongNhom(cboNhomND.SelectedValue.ToString());
                dgvNguoiDung.DataSource = new BindingList<NguoiDungDTO>(lstNguoiDung);
            }

            if (dgvNguoiDung.Columns.Contains("MatKhau"))
                dgvNguoiDung.Columns.Remove("MatKhau");

            if (dgvNguoiDung.Columns.Contains("HoatDong"))
                dgvNguoiDung.Columns.Remove("HoatDong");

        }

        void loadDgvNguoiDungTrongNhom()
        {
            dgvNguoiDung.AutoGenerateColumns = false;

            if (cboNhomND.SelectedIndex != -1)
            {
                //lưu vào list trước khi lưu vào datagridview
                lstND_NhomND = nD_NhomNdBul.layNguoiDungTheoMaNhom(cboNhomND.SelectedValue.ToString());
                dgvNguoiDungTrongNhom.DataSource = new BindingList<ND_NhomNDDTO>(lstND_NhomND);
            }


        }

        private void cboNhomND_SelectedIndexChanged(object sender, System.EventArgs e)
        {
            if (cboNhomND.SelectedIndex != -1)
            {
                loadDgvNguoiDungTrongNhom();
                loadDgvNguoiDung();
            }
        }

        private void btnThem_Click(object sender, System.EventArgs e)
        {
            DialogResult result = MessageBox.Show("Bạn có muốn thêm không?", "Thêm", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button1);

            if (result == DialogResult.Yes)
            {
                if (cboNhomND.SelectedIndex != -1 && dgvNguoiDung.SelectedRows.Count != 0)
                {
                    string maND = dgvNguoiDung.SelectedRows[0].Cells[0].Value.ToString();
                    string maNhom = cboNhomND.SelectedValue.ToString();
                    ND_NhomNDDTO dto = new ND_NhomNDDTO(maNhom, maND, ucGhiChu.Textbox);
                    if (nD_NhomNdBul.themND_NhomND(dto))
                    {
                        MessageBox.Show("Thêm thành công", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1);
                        //xóa dòng đó ra khỏi datagridview
                        lstNguoiDung.RemoveAt(dgvNguoiDung.SelectedRows[0].Index);
                        dgvNguoiDung.DataSource = new BindingList<NguoiDungDTO>(lstNguoiDung);
                    }
                    else
                        MessageBox.Show("Thêm không thành công", "Cảnh báo", MessageBoxButtons.OK, MessageBoxIcon.Warning, MessageBoxDefaultButton.Button1);
                    loadDgvNguoiDungTrongNhom();
                    loadDgvNguoiDung();
                }
                else
                {
                    MessageBox.Show("Vui lòng chọn đầy đủ thông tin");
                }
            }


        }

        private void btnXoa_Click(object sender, System.EventArgs e)
        {
            DialogResult result = MessageBox.Show("Bạn có muốn xóa không?", "Xóa", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button1);

            if (result == DialogResult.Yes)
            {
                if (cboNhomND.SelectedIndex != -1 && dgvNguoiDungTrongNhom.SelectedRows.Count != 0)
                {
                    string maND = dgvNguoiDungTrongNhom.SelectedRows[0].Cells[1].Value.ToString();
                    string maNhom = cboNhomND.SelectedValue.ToString();
                    ND_NhomNDDTO dto = new ND_NhomNDDTO(maNhom, maND, ucGhiChu.Textbox);
                    if (nD_NhomNdBul.xoaND_NhomND(dto))
                    {
                        MessageBox.Show("Xóa thành công", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1);
                        //xóa dòng đó ra khỏi datagridview
                        lstND_NhomND.RemoveAt(dgvNguoiDungTrongNhom.SelectedRows[0].Index);
                        dgvNguoiDungTrongNhom.DataSource = new BindingList<ND_NhomNDDTO>(lstND_NhomND);
                    }
                    else
                        MessageBox.Show("Xóa không thành công", "Cảnh báo", MessageBoxButtons.OK, MessageBoxIcon.Warning, MessageBoxDefaultButton.Button1);
                    loadDgvNguoiDungTrongNhom();
                    loadDgvNguoiDung();
                }
                else
                {
                    MessageBox.Show("Vui lòng chọn đầy đủ thông tin");
                }
            }
        }


    }
}
