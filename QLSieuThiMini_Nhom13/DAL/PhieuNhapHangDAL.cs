using DTO;
using System.Data;
using System.Data.SqlClient;

namespace DAL
{
    public class PhieuNhapHangDAL
    {
        string conn = null;
        SqlConnection con;

        public PhieuNhapHangDAL()
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


        public DataTable getAll()
        {
            string sql = "select * from PhieuNhapHang";
            SqlDataAdapter da = new SqlDataAdapter(sql, con);
            DataTable dt = new DataTable();
            da.Fill(dt);
            return dt;
        }


        public DataTable layMotPhieuNhapHang(string maPNH)
        {
            string sql = "select * from PhieuNhapHang where MaPNH= '" + maPNH + "'";
            SqlDataAdapter da = new SqlDataAdapter(sql, con);
            DataTable dt = new DataTable();
            da.Fill(dt);
            return dt;
        }

        public DataTable layDSPhieuNhapHang(string text)
        {
            string sql = "SELECT* FROM PhieuNhapHang pn, NhaCungCap ncc, NguoiDung nd " +
                          "WHERE  ncc.MaNCC = pn.MaNCC " +
                          "AND  pn.MaND = nd.MaND ";

            if (text != "" && text != null)
            {
                if (text.StartsWith("PN"))
                {
                    sql = "SELECT* FROM PhieuNhapHang pn, NhaCungCap ncc, NguoiDung nd " +
                          "WHERE ncc.MaNCC = pn.MaNCC " +
                          "AND pn.MaND = nd.MaND " +
                          "AND MaPNH LIKE N'" + text + "%'";
                }
                else
                {
                    sql = "SELECT* FROM PhieuNhapHang pn, NhaCungCap ncc, NguoiDung nd " +
                          "WHERE ncc.MaNCC = pn.MaNCC " +
                          "AND pn.MaND = nd.MaND " +
                          "AND TenNCC LIKE N'" + text + "%'";
                }

            }

            SqlDataAdapter da = new SqlDataAdapter(sql, con);
            DataTable dt = new DataTable();
            da.Fill(dt);
            return dt;
        }

        public DataTable locPhieuNhapHangTheoNgay(string ngayBD, string ngayKT)
        {
            string sql = "SELECT * FROM PhieuNhapHang pn, NhaCungCap ncc, NguoiDung nd " +
                          "WHERE ncc.MaNCC = pn.MaNCC " +
                          "AND pn.MaND = nd.MaND " +
                          "AND pn.NgayNhap > '" + ngayBD + "' AND pn.NgayNhap < '" + ngayKT + "' ";

            SqlDataAdapter da = new SqlDataAdapter(sql, con);
            DataTable dt = new DataTable();
            da.Fill(dt);
            return dt;
        }

        public DataTable layMaPNHCuoiCung(string maPNH)
        {
            string sql = "SELECT TOP 1 MaPNH FROM PhieuNhapHang WHERE MaPNH LIKE '" + maPNH + "%' ORDER BY MaPNH DESC";
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

        public bool InsertPhieuNhapHang(PhieuNhapHangDTO pnh)
        {
            string ngaynhap = pnh.NgayNhap.ToString("yyyy-MM-dd HH:mm:ss");
            string sql = "insert into PhieuNhapHang values( '" + pnh.MaPNH + "', '" + ngaynhap + "', '" + pnh.TongTien + "', '" + pnh.MaNCC + "', '" + pnh.MaND + "')";
            return ExcuteNonQuery(sql);
        }

        public bool DeletePhieuNhapHang(string maPNH)
        {
            string sql = "delete from PhieuNhapHang where MaPNH= '" + maPNH + "'";
            return ExcuteNonQuery(sql);
        }

        public bool UpdatePhieuNhapHang(PhieuNhapHangDTO pnh)
        {
            string sql = "update PhieuNhapHang set NgayNhap='" + pnh.NgayNhap + "', TongTien='" + pnh.TongTien + "', MaNCC='" + pnh.MaNCC + "', MaND='" + pnh.MaND + "' where MaPNH= '" + pnh.MaPNH + "'";
            return ExcuteNonQuery(sql);
        }


        public DataTable layTTPhieuNhapHang(string maPN)
        {
            string sql = "SELECT s.MaSP, s.TenSP, ct.SoLuong, ct.DonGia, Sum(ct.SoLuong*ct.DonGia) As ThanhTien " +
                "FROM PhieuNhapHang pn, ChiTietPNH ct, SanPham s, NhaCungCap ncc, NguoiDung nd " +
                "Where pn.MaPNH = ct.MaPNH And s.MaSP = ct.MaSP And ncc.MaNCC = pn.MaNCC And nd.MaND = pn.MaND " +
                "And pn.MaPNH = '" + maPN.Trim() + "' Group by s.MaSP, s.TenSP, ct.SoLuong, ct.DonGia";

            SqlDataAdapter da = new SqlDataAdapter(sql, con);
            DataTable dt = new DataTable();
            da.Fill(dt);
            return dt;
        }
    }
}
