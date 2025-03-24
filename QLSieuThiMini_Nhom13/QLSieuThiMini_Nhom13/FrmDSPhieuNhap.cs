using BUL;
using QLMamNon;
using System;
using System.Windows.Forms;

namespace QLSieuThiMini_Nhom13
{
    public partial class FrmDSPhieuNhap : Form
    {
        PhieuNhapHangBUL bul;
        public string MaPhieuNhap { get; private set; }
        public FrmDSPhieuNhap()
        {
            InitializeComponent();
            bul = new PhieuNhapHangBUL();
        }


        public void loadDSPN()
        {
            dgvDSPN.AutoGenerateColumns = false;
            dgvDSPN.ReadOnly = true;
            dgvDSPN.DataSource = bul.layDSPhieuNhapHang(null);
        }

        private void txtMaHD_TextChanged(object sender, EventArgs e)
        {
            dgvDSPN.DataSource = bul.layMotPhieuNhapHang(txtMaPNH.Text);
        }

        private void FrmDSPhieuNhap_Load(object sender, EventArgs e)
        {
            loadDSPN();
        }

        private void btnXemChiTietPN_Click(object sender, EventArgs e)
        {
            if (MaPhieuNhap != null)
            {
                this.Close();
            }
            else
            {
                CustomMessageBox.ShowError(this.ParentForm, "Hãy chọn 1 phiếu nhập", "Thông Báo");
                return;
            }
        }

        private void dgvDSPN_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                DataGridViewRow selectedRow = dgvDSPN.Rows[e.RowIndex];

                MaPhieuNhap = selectedRow.Cells["MaPNH"].Value.ToString();
            }
        }

        private void txtMaPN_TextChanged(object sender, EventArgs e)
        {
            dgvDSPN.DataSource = bul.layDSPhieuNhapHang(txtMaPN.Text);
        }

        private void btnLoc_Click(object sender, EventArgs e)
        {
            if (txtNgayBD.Value > txtNgayKT.Value)
            {
                CustomMessageBox.ShowError(this.ParentForm, "Ngày bắt đầu không được lớn hơn ngày kết thúc", "Thông Báo");
            }
            else
            {
                string ngayBD = (DateTime.Parse(txtNgayBD.Text)).ToString("yyyy-MM-dd");
                string ngayKT = (DateTime.Parse(txtNgayKT.Text)).ToString("yyyy-MM-dd");
                dgvDSPN.DataSource = bul.locPhieuNhapHangTheoNgay(ngayBD, ngayKT);
            }
        }
    }
}
