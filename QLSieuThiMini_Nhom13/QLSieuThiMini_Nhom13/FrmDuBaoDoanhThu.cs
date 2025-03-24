using BUL;
using DTO;
using Microsoft.ML;
using Microsoft.ML.Data;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Windows.Forms;

namespace QLSieuThiMini_Nhom13
{
    public partial class FrmDuBaoDoanhThu : Form
    {
        HoaDonBUL hoaDonBUL;
        SanPhamBUL sanPhamBUL;

        public FrmDuBaoDoanhThu()
        {
            InitializeComponent();
            hoaDonBUL = new HoaDonBUL();
            sanPhamBUL = new SanPhamBUL();

            context = new MLContext();

        }

        MLContext context = new MLContext();

        Microsoft.ML.Data.TransformerChain<Microsoft.ML.Data.RegressionPredictionTransformer<Microsoft.ML.Trainers.LinearRegressionModelParameters>> model = new Microsoft.ML.Data.TransformerChain<Microsoft.ML.Data.RegressionPredictionTransformer<Microsoft.ML.Trainers.LinearRegressionModelParameters>>();
        PredictionEngine<LichSuBanHangDTO, ResultModel> predicttionEngine;


        private void FrmDuBaoDoanhThu_Load(object sender, EventArgs e)
        {

            string[] columnsList = new string[] { "Ngày", "Mã sản phẩm", "Tên sản phẩm", "Giá bán", "Thứ", "Khuyến mãi", "Số Lượng đã bán", "Doanh thu" };
            dgv.Columns.Clear();

            for (int i = 0; i < columnsList.Length; i++)
            {
                dgv.Columns.Add("col" + i, columnsList[i]);
            }

            dgv.ColumnHeadersHeight = 40;


            List<LichSuBanHangDTO> hoaDonList = hoaDonBUL.layLichSuBanHang();

            foreach (LichSuBanHangDTO hoaDon in hoaDonList)
            {
                string km = hoaDon.KhuyenMai == 1 ? "Có" : "Không";
                float thu = hoaDon.ThuTrongTuan + 1;
                dgv.Rows.Add(hoaDon.NgayLap.ToString("dd/MM/yyyy"), hoaDon.MaSP, hoaDon.TenSP, hoaDon.GiaBan, thu, km, hoaDon.SoLuong, hoaDon.DoanhThu);
            }
            btnDuDoan.Enabled = false;

        }

        private void btnTrain_Click(object sender, EventArgs e)
        {
            btnDuDoan.Enabled = true;
            btnTrain.Enabled = false;

            List<LichSuBanHangDTO> lst = hoaDonBUL.layLichSuBanHang();
            IDataView dataTran = context.Data.LoadFromEnumerable(lst);

            // Chuẩn bị pipeline cho dữ liệu. 
            EstimatorChain<RegressionPredictionTransformer<Microsoft.ML.Trainers.LinearRegressionModelParameters>> estimator = context.Transforms.Concatenate("Features", new[] { "NgayLapAsFloat", "GiaBan", "ThuTrongTuan", "KhuyenMai" })
                                .Append(context.Regression.Trainers.Sdca(labelColumnName: "SoLuong"));

            // Huấn luyện mô hình
            TransformerChain<RegressionPredictionTransformer<Microsoft.ML.Trainers.LinearRegressionModelParameters>> model2 = estimator.Fit(dataTran);
            model = model2;

            // Tạo prediction engine
            predicttionEngine = context.Model.CreatePredictionEngine<LichSuBanHangDTO, ResultModel>(model);

            MessageBox.Show("Train thành công!");
        }

        private void btnDuDoan_Click(object sender, EventArgs e)
        {
            //btnDuDoan.Enabled = false;
            btnTrain.Enabled = true;
            DateTime ngayDuDoan = dtpNgayDuDoan.Value.Date;

            // Lấy danh sách lịch sử bán hàng
            List<LichSuBanHangDTO> lstLichSuBanHang = hoaDonBUL.layLichSuBanHang();

            // Lọc 3 ngày gần nhất so với ngày dự đoán
            var lstNgayGanNhat = lstLichSuBanHang
                .Where(ls => ls.NgayLap < ngayDuDoan)
                .GroupBy(ls => ls.NgayLap.Date)
                .Select(group => new
                {
                    Ngay = group.Key,
                    TongDoanhThu = group.Sum(ls => ls.DoanhThu)
                })
                .OrderByDescending(x => x.Ngay)
                .Take(3)
                .ToList();


            chart1.Series.Clear();


            System.Windows.Forms.DataVisualization.Charting.Series series3NgayGanNhat = new System.Windows.Forms.DataVisualization.Charting.Series("DoanhThu 3 Ngày Gần Nhất")
            {
                ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.Column,
                XValueType = System.Windows.Forms.DataVisualization.Charting.ChartValueType.DateTime,
                Color = System.Drawing.Color.Blue
            };
            chart1.Series.Add(series3NgayGanNhat);

            foreach (var ngay in lstNgayGanNhat)
            {
                series3NgayGanNhat.Points.AddXY(ngay.Ngay, ngay.TongDoanhThu);
            }


            // Hiển thị dữ liệu dự đoán trong DataGridView
            dgv.Rows.Clear();
            double doanhThuDuDoan = 0;
            foreach (SanPhamDTO sp in sanPhamBUL.layDSSanPhamKemKhuyenMaiTheoNgayDuDoan(ngayDuDoan.ToString("yyyy/MM/dd")))
            {
                LichSuBanHangDTO ls = new LichSuBanHangDTO(
                    ngayDuDoan,
                    sp.MaSP,
                    sp.TenSP,
                    0, // số lượng dự đoán để 0
                    (float)sp.GiaBan,
                    0, // doanh thu dự đoán để 0
                    sp.KhuyenMai
                );

                ResultModel prediction = predicttionEngine.Predict(ls);
                doanhThuDuDoan += prediction.SoLuongBan * sp.GiaBan;

                dgv.Rows.Add(
                    ngayDuDoan.ToShortDateString(),
                    sp.MaSP,
                    sp.TenSP,
                    sp.GiaBan,
                    ls.ThuTrongTuan,
                    sp.KhuyenMai,
                    prediction.SoLuongBan,
                    doanhThuDuDoan
                );
            }


            // Tạo Series cho ngày dự đoán
            System.Windows.Forms.DataVisualization.Charting.Series seriesNgayDuDoan = new System.Windows.Forms.DataVisualization.Charting.Series("DoanhThu Ngày Dự Đoán")
            {
                ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.Column,
                XValueType = System.Windows.Forms.DataVisualization.Charting.ChartValueType.DateTime,
                Color = System.Drawing.Color.Red // Màu đỏ cho ngày dự đoán
            };
            chart1.Series.Add(seriesNgayDuDoan);

            // Thêm dữ liệu ngày dự đoán vào Series
            seriesNgayDuDoan.Points.AddXY(ngayDuDoan, doanhThuDuDoan);



            MessageBox.Show("Dự đoán doanh thu hoàn tất!");

        }
    }
}
