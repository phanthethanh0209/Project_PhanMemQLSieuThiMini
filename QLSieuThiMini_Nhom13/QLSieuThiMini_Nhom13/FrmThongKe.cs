using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using BUL;
using DAL;

namespace QLSieuThiMini_Nhom13
{
    public partial class FrmThongKe : Form
    {
        ThongKeBUL thongKeBUL = new ThongKeBUL();

        public FrmThongKe()
        {
            InitializeComponent();
        }

        private void FrmThongKe_Load(object sender, EventArgs e)
        {
            bangThongKeDGV.DataSource = thongKeBUL.ThongKeSanPham(startDatePicker.Text, endDatePicker.Text, "Ngày");

            comboBox2.Items.AddRange(new string[] { "Sản Phẩm", "Khách Hàng"});
            comboBox2.SelectedIndex = 0; // Mặc định chọn "Ngày".

            comboBox1.Items.AddRange(new string[] { "Ngày", "Tháng", "Năm" });
            comboBox1.SelectedIndex = 0; // Mặc định chọn "Ngày".
        }

        private void thongKeBTN_Click(object sender, EventArgs e)
        {
            DateTime startDate = startDatePicker.Value;
            DateTime endDate = endDatePicker.Value;

            if (startDate > endDate)
            {
                MessageBox.Show("Ngày bắt đầu phải nhỏ hơn hoặc bằng ngày kết thúc.", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            // Lấy kiểu thống kê từ combobox
            string groupBy = comboBox1.SelectedItem.ToString(); // "Ngày", "Tháng", "Năm"
            string thongKeLoai = comboBox2.SelectedItem.ToString(); // "Sản Phẩm" hoặc "Khách Hàng"

            DataTable data;

            if (thongKeLoai == "Sản Phẩm")
            {
                // Thống kê doanh thu theo sản phẩm
                data = thongKeBUL.ThongKeSanPham(startDatePicker.Text, endDatePicker.Text, groupBy);
            }
            else if (thongKeLoai == "Khách Hàng")
            {
                // Thống kê doanh thu theo khách hàng
                data = thongKeBUL.ThongKeKhachHangTheoThoiGian(startDatePicker.Text, endDatePicker.Text, groupBy);
            }
            else
            {
                MessageBox.Show("Vui lòng chọn loại thống kê hợp lệ.", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            // Cập nhật DataGridView
            bangThongKeDGV.DataSource = data;

            // Cập nhật biểu đồ
            chart1.Series.Clear();
            var series = new System.Windows.Forms.DataVisualization.Charting.Series("DoanhThu");
            series.ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.Column;
            chart1.Series.Add(series);

            foreach (DataRow row in data.Rows)
            {
                string ten = thongKeLoai == "Sản Phẩm" ? row["TenSP"].ToString() : row["TenKH"].ToString();
                decimal doanhThu = Convert.ToDecimal(row["DoanhThu"]);
                series.Points.AddXY(ten, doanhThu);
            }
        }

        private void xuatBaoCaoBTN_Click(object sender, EventArgs e)
        {
            CrystalReport1 crystalReport1 = new CrystalReport1();
            crystalReport1.SetDataSource(thongKeBUL.ThongKeSanPham(startDatePicker.Text, endDatePicker.Text, "Ngày"));
            FrmInBaoCao frmInBaoCao = new FrmInBaoCao();
            frmInBaoCao.crystalReportViewer1.ReportSource = crystalReport1;
            frmInBaoCao.ShowDialog();
        }
    }
}
