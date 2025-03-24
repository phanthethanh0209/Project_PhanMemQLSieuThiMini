using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL
{
    public class ThongKeDAL
    {
        QlSieuThi_DataSetTableAdapters.HoaDonTableAdapter adapHoaDon = new QlSieuThi_DataSetTableAdapters.HoaDonTableAdapter();
        QlSieuThi_DataSetTableAdapters.ChiTietHDTableAdapter adapCTHoaDon = new QlSieuThi_DataSetTableAdapters.ChiTietHDTableAdapter();
        QlSieuThi_DataSetTableAdapters.SanPhamTableAdapter adapSanPham = new QlSieuThi_DataSetTableAdapters.SanPhamTableAdapter();

        public DataTable ThongKeSanPham(DateTime startDate, DateTime endDate, string groupBy)
        {
            string query = @"
        SELECT sp.MaSP, sp.TenSP, 
               {0} AS NgayLap, 
               SUM(cthd.SoLuong) AS SoLuongBan, 
               SUM(cthd.SoLuong * cthd.DonGia) AS DoanhThu
        FROM ChiTietHD AS cthd 
        INNER JOIN SanPham AS sp ON sp.MaSP = cthd.MaSP 
        INNER JOIN HoaDon AS hd ON hd.MaHD = cthd.MaHD
        WHERE hd.NgayLap BETWEEN @StartDate AND @EndDate
        GROUP BY sp.MaSP, sp.TenSP, {0}";

            string groupByField;
            if (groupBy == "Ngày")
                groupByField = "CONVERT(DATE, hd.NgayLap)";
            else if (groupBy == "Tháng")
                groupByField = "FORMAT(hd.NgayLap, 'yyyy-MM')";
            else if (groupBy == "Năm")
                groupByField = "YEAR(hd.NgayLap)";
            else
                groupByField = "CONVERT(DATE, hd.NgayLap)";

            query = string.Format(query, groupByField);

            using (var connection = new SqlConnection(Settings1.Default.ChuoiKN))
            using (var command = new SqlCommand(query, connection))
            {
                command.Parameters.AddWithValue("@StartDate", startDate);
                command.Parameters.AddWithValue("@EndDate", endDate);

                var adapter = new SqlDataAdapter(command);
                var result = new DataTable();
                adapter.Fill(result);
                return result;
            }
        }

        public DataTable ThongKeDoanhThuKhachHang(DateTime startDate, DateTime endDate, string groupBy)
        {
            using (SqlConnection conn = new SqlConnection(Settings1.Default.ChuoiKN))
            {
                string groupColumn = "";
                switch (groupBy)
                {
                    case "Ngày":
                        groupColumn = "CONVERT(VARCHAR, hd.NgayLap, 111)";
                        break;
                    case "Tháng":
                        groupColumn = "FORMAT(hd.NgayLap, 'yyyy-MM')";
                        break;
                    case "Năm":
                        groupColumn = "YEAR(hd.NgayLap)";
                        break;
                    default:
                        throw new ArgumentException("Tham số không hợp lệ.");
                }

                string query = $@"
        SELECT 
            {groupColumn} AS ThoiGian,
            kh.MaKH,
            kh.TenKH,
            SUM(cthd.SoLuong * cthd.DonGia) AS DoanhThu
        FROM 
            KhachHang kh
        INNER JOIN 
            HoaDon hd ON kh.MaKH = hd.MaKH
        INNER JOIN 
            ChiTietHD cthd ON hd.MaHD = cthd.MaHD
        WHERE 
            hd.NgayLap BETWEEN @StartDate AND @EndDate
        GROUP BY 
            {groupColumn}, kh.MaKH, kh.TenKH
        ORDER BY 
            ThoiGian, DoanhThu DESC";

                SqlCommand cmd = new SqlCommand(query, conn);
                cmd.Parameters.AddWithValue("@StartDate", startDate);
                cmd.Parameters.AddWithValue("@EndDate", endDate);

                SqlDataAdapter adapter = new SqlDataAdapter(cmd);
                DataTable result = new DataTable();
                adapter.Fill(result);

                return result;
            }
        }

    }
}
