using DTO;
using System;
using System.Data;
using System.Data.SqlClient;

namespace DAL
{
    public class HoaDonDAL
    {
        string conn = null;
        SqlConnection con;

        public HoaDonDAL()
        {
            conn = Settings1.Default.ChuoiKN;
            con = new SqlConnection(conn);
        }

        public void Open()
        {
            if (con.State == ConnectionState.Closed)
            {
                con.Open();
            }
        }

        public void Close()
        {
            if (con.State == ConnectionState.Open)
            {
                con.Close();
            }
        }

        public DataTable layDSHoaDon(string text)
        {
            string sql = "SELECT* FROM HoaDon hd " +
                          "LEFT JOIN KhachHang kh ON kh.MaKH = hd.MaKH " +
                          "INNER JOIN NguoiDung nd ON hd.MaND = nd.MaND ";

            if (text != "" && text != null)
            {
                if (text.StartsWith("HD"))
                {
                    sql = "SELECT* FROM HoaDon hd " +
                          "LEFT JOIN KhachHang kh ON kh.MaKH = hd.MaKH " +
                          "INNER JOIN NguoiDung nd ON hd.MaND = nd.MaND " +
                          "WHERE MaHD LIKE N'" + text + "%'";
                }
                else
                {
                    sql = "SELECT* FROM HoaDon hd " +
                          "INNER JOIN KhachHang kh ON kh.MaKH = hd.MaKH " +
                          "INNER JOIN NguoiDung nd ON hd.MaND = nd.MaND " +
                          "WHERE TenKH LIKE N'" + text + "%'";
                }

            }

            SqlDataAdapter da = new SqlDataAdapter(sql, con);
            DataTable dt = new DataTable();
            da.Fill(dt);
            return dt;
        }

        public DataTable locHoaDonTheoNgay(string ngayBD, string ngayKT)
        {
            string sql = "SELECT * FROM HoaDon hd " +
                          "LEFT JOIN KhachHang kh ON kh.MaKH = hd.MaKH " +
                          "INNER JOIN NguoiDung nd ON hd.MaND = nd.MaND " +
                          "WHERE hd.NgayLap > '" + ngayBD + "' AND hd.NgayLap < '" + ngayKT + "' ";

            SqlDataAdapter da = new SqlDataAdapter(sql, con);
            DataTable dt = new DataTable();
            da.Fill(dt);
            return dt;
        }

        public DataTable layTTHoaDon(string mahd)
        {
            string sql = "select * from HoaDon" +
                " where MaHD = '" + mahd + "'";

            SqlDataAdapter da = new SqlDataAdapter(sql, con);
            DataTable dt = new DataTable();
            da.Fill(dt);
            return dt;
        }


        public DataTable layMaHDCuoiCung(string maHD)
        {
            string sql = "SELECT TOP 1 MaHD FROM HoaDon WHERE MaHD LIKE '" + maHD + "%' ORDER BY MaHD DESC";
            SqlDataAdapter da = new SqlDataAdapter(sql, con);
            DataTable dt = new DataTable();
            da.Fill(dt);
            return dt;
        }



        //public DataTable layLichSuBanHang()
        //{
        //    string sql = "SELECT CONVERT(date, hd.NgayLap) AS NgayLap, sp.TenSP, SUM(ct.SoLuong) AS SoLuongBan, sp.GiaBan, (SUM(ct.SoLuong) * sp.GiaBan) AS DoanhThu " +
        //        "FROM SanPham sp JOIN ChiTietHD ct ON sp.MaSP = ct.MaSP " +
        //        "JOIN HoaDon hd ON hd.MaHD = ct.MaHD " +
        //        "GROUP BY CONVERT(date, hd.NgayLap), sp.TenSP, sp.GiaBan " +
        //        "ORDER BY CONVERT(date, hd.NgayLap), sp.TenSP";

        //    SqlDataAdapter da = new SqlDataAdapter(sql, con);
        //    DataTable dt = new DataTable();
        //    da.Fill(dt);
        //    return dt;
        //} 

        public DataTable layLichSuBanHang()
        {
            string sql = "WITH dsSPDuocMua AS ( SELECT hd.NgayLap, ct.MaSP, ct.SoLuong FROM HoaDon hd JOIN ChiTietHD ct ON hd.MaHD = ct.MaHD ), " +
                "dsNgay AS(SELECT DISTINCT NgayLap FROM HoaDon), " +
                "dsSPCoKhuyenMai AS(SELECT ctkm.MaSP, km.MaKM, km.NgayBD, km.NgayKT FROM KhuyenMai km JOIN NhomSanPhamKM nsp ON km.MaNhomSPMua = nsp.MaNhomSP JOIN CTNhomSanPhamKM ctkm ON nsp.MaNhomSP = ctkm.MaNhomSP) " +
                "SELECT dsNgay.NgayLap, sp.MaSP, sp.TenSP, sp.GiaBan, COALESCE(SUM(dsSPDuocMua.SoLuong), 0) AS SoLuongBan, COALESCE(SUM(dsSPDuocMua.SoLuong * sp.GiaBan), 0) AS DoanhThu, " +
                "CASE WHEN dsNgay.NgayLap BETWEEN dsSPCoKhuyenMai.NgayBD AND dsSPCoKhuyenMai.NgayKT THEN 1 ELSE 0 END AS KhuyenMai " +
                "FROM SanPham sp CROSS JOIN dsNgay LEFT JOIN dsSPDuocMua ON sp.MaSP = dsSPDuocMua.MaSP AND dsSPDuocMua.NgayLap = dsNgay.NgayLap " +
                "LEFT JOIN dsSPCoKhuyenMai ON sp.MaSP = dsSPCoKhuyenMai.MaSP " +
                "GROUP BY dsNgay.NgayLap, sp.MaSP, sp.TenSP, sp.GiaBan, dsSPCoKhuyenMai.NgayBD, dsSPCoKhuyenMai.NgayKT " +
                "ORDER BY dsNgay.NgayLap DESC, sp.MaSP; ";

            SqlDataAdapter da = new SqlDataAdapter(sql, con);
            DataTable dt = new DataTable();
            da.Fill(dt);
            return dt;
        }




        public bool ExcuteNonQuery(string pQuery)
        {
            Open();
            SqlCommand cmd = new SqlCommand(pQuery, con);
            int so = cmd.ExecuteNonQuery();

            Close();
            return so > 0;
        }

        public bool themHoaDon(HoaDonDTO hd)
        {
            try
            {
                string ngayLapFormatted = hd.NgayLap.ToString("yyyy-MM-dd HH:mm:ss");
                string sql = "insert into HoaDon values( '" + hd.MaHD + "', '" + ngayLapFormatted + "', '" + hd.TichDiem + "', '" + hd.TienGiam + "', '" + hd.TongTien + "', '" + hd.MaKH + "', '" + hd.MaND + "', '" + hd.TienNhan + "')";
                if (hd.MaKH == null)
                {
                    sql = "insert into HoaDon values( '" + hd.MaHD + "', '" + ngayLapFormatted + "', NULL, '" + hd.TienGiam + "', '" + hd.TongTien + "', NULL, '" + hd.MaND + "', '" + hd.TienNhan + "')";
                }
                return ExcuteNonQuery(sql);
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error: " + ex.Message);
                return false;
            }
        }
    }
}
