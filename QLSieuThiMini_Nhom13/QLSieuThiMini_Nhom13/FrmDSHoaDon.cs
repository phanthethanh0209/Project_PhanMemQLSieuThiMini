using BUL;
using QLMamNon;
using System;
using System.Windows.Forms;

namespace QLSieuThiMini_Nhom13
{
    public partial class FrmDSHoaDon : Form
    {
        HoaDonBUL bul;
        public string maHD;

        public FrmDSHoaDon()
        {
            InitializeComponent();
            bul = new HoaDonBUL();
        }
        private void FrmDSHoaDon_Load(object sender, EventArgs e)
        {
            loadDSHD();
        }

        public void loadDSHD()
        {
            dgvDSHD.AutoGenerateColumns = false;
            dgvDSHD.ReadOnly = true;
            dgvDSHD.DataSource = bul.layDSHoaDon(null);
        }

        private void txtMaHD_TextChanged(object sender, EventArgs e)
        {
            dgvDSHD.DataSource = bul.layDSHoaDon(txtMaHD.Text);
        }

        private void bunifuGroupBox1_Enter(object sender, EventArgs e)
        {

        }

        private void btnXemDSHD_Click(object sender, EventArgs e)
        {
            if (maHD != null)
            {
                this.Close();
            }
            else
            {
                CustomMessageBox.ShowError(this.ParentForm, "Vui lòng chọn hóa đơn!", "Thông Báo");
                return;
            }
        }

        private void dgvDSHD_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                DataGridViewRow selectedRow = dgvDSHD.Rows[e.RowIndex];

                maHD = selectedRow.Cells["MaHD2"].Value.ToString();
            }
        }


        private void btnLoc_Click(object sender, EventArgs e)
        {
            if (t.Value > txtNgayKT.Value)
            {
                CustomMessageBox.ShowError(this.ParentForm, "Ngày bắt đầu không được lớn hơn ngày kết thúc", "Thông Báo");
            }
            else
            {
                string ngayBD = (DateTime.Parse(t.Text)).ToString("yyyy-MM-dd");
                string ngayKT = (DateTime.Parse(txtNgayKT.Text)).ToString("yyyy-MM-dd");
                dgvDSHD.DataSource = bul.locHoaDonTheoNgay(ngayBD, ngayKT);
            }

        }
    }
}
