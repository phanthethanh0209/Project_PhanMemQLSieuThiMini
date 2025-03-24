using BUL;
using Guna.UI2.WinForms;
using System;
using System.Drawing;
using System.Windows.Forms;

namespace QLSieuThiMini_Nhom13
{
    public partial class FrmXemDSKhuyenMai : Form
    {
        KhuyenMaiBUL kmBUL ;
        Guna2MessageDialog message;
        public string MaKMChon { get; set; }
        public FrmXemDSKhuyenMai()
        {
            InitializeComponent();
            message = new Guna2MessageDialog
            {
                Style = MessageDialogStyle.Light,
            };
            kmBUL = new KhuyenMaiBUL();
        }

        private void FrmXemDSKhuyenMai_Load(object sender, EventArgs e)
        {
            dgvKM.AutoGenerateColumns = false;
            dgvKM.AllowUserToAddRows = false;

            foreach (DataGridViewColumn column in dgvKM.Columns)
            {
                column.HeaderCell.Style.Font = new Font("Tahoma", 9, FontStyle.Bold);
            }

            dgvKM.DataSource = kmBUL.layTatCaKhuyenMai();


        }

        private void btnChon_Click(object sender, EventArgs e)
        {
            if (dgvKM.CurrentRow != null)
            {
                MaKMChon = dgvKM.CurrentRow.Cells[0].Value?.ToString();
                this.Close();
            }
            else
            {
                message.Buttons = MessageDialogButtons.OK;
                message.Icon = MessageDialogIcon.Error;
                message.Parent = this.ParentForm;
                message.Show("Hãy chọn 1 khuyến mãi", "Thông Báo");
            }
        }

        private void btnLoc_Click(object sender, EventArgs e)
        {
            if(dtpNgayBD.Value <= dtpNgayKT.Value)
            {
                dgvKM.DataSource= kmBUL.layTatCaKhuyenMaiTheoNgay(dtpNgayBD.Value, dtpNgayKT.Value);
            }else
            {
                message.Buttons = MessageDialogButtons.OK;
                message.Icon = MessageDialogIcon.Error;
                message.Parent = this.ParentForm;
                message.Show("Ngày không hợp lệ", "Thông Báo");
            }    
        }

        private void txtTimKiemKM_TextChanged(object sender, EventArgs e)
        {
            dgvKM.DataSource= kmBUL.timKiemKhuyenMai(txtTimKiemKM.Text);
        }

        //private void dgvKM_CellClick(object sender, DataGridViewCellEventArgs e)
        //{
        //    if (e.RowIndex >= 0)
        //    {
        //        DataGridViewRow selectedRow = dgvKM.Rows[e.RowIndex];

        //        MaKM =  selectedRow.Cells["MaKM"].Value;
        //    }
        //}
    }
}
