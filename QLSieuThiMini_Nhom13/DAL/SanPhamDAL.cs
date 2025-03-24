using DTO;
using System;
using System.Data;
using System.Data.SqlClient;
using System.Globalization;

namespace DAL
{
    public class SanPhamDAL
    {
        string conn = null;
        SqlConnection con;

        public SanPhamDAL()
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

        public DataTable layDSSanPham()
        {
            string sql = "select * from SanPham";
            SqlDataAdapter da = new SqlDataAdapter(sql, con);
            DataTable dt = new DataTable();
            da.Fill(dt);
            return dt;
        }

        public DataTable layDSSanPhamTheoTenHoacMa(string text)
        {
            string sql = "select * from SanPham where MaSP = '" + text + "' OR TenSP Like N'%" + text + "%'";
            SqlDataAdapter da = new SqlDataAdapter(sql, con);
            DataTable dt = new DataTable();
            da.Fill(dt);
            return dt;
        }

        public DataTable layDSSanPhamTheoLoai(string maLoai)
        {
            string sql = "select * from SanPham sp, LoaiSanPham l where sp.MaLoai = l.MaLoai and l.MaLoai = '" + maLoai + "'";
            SqlDataAdapter da = new SqlDataAdapter(sql, con);
            DataTable dt = new DataTable();
            da.Fill(dt);
            return dt;
        }

        public DataTable layDSSanPhamTheoThuongHieu(string maTH)
        {
            string sql = "select * from SanPham sp, ThuongHieu l where sp.MaTH = l.MaTH and l.MaTH= '" + maTH + "' ";
            SqlDataAdapter da = new SqlDataAdapter(sql, con);
            DataTable dt = new DataTable();
            da.Fill(dt);
            return dt;
        }


        public DataTable layMotSanPham(string maSP)
        {
            string sql = "select * from SanPham Where MaSP = '" + maSP + "'";
            SqlDataAdapter da = new SqlDataAdapter(sql, con);
            DataTable dt = new DataTable();
            da.Fill(dt);
            return dt;
        }


        public DataTable layMaSPCuoiCung()
        {
            string sql = "SELECT TOP 1 MaSP FROM SanPham WHERE MaSP LIKE 'SP%' ORDER BY MaSP DESC";
            SqlDataAdapter da = new SqlDataAdapter(sql, con);
            DataTable dt = new DataTable();
            da.Fill(dt);
            return dt;
        }

        public DataTable timKiemSPTheoMaHoacTen(string search)
        {
            string sql = "select * from SanPham WHERE MaSP = '" + search + "' OR TenSP LIKE N'%" + search + "%' OR TenSP LIKE N'" + search + " %' OR TenSP LIKE N'% " + search + "' ";
            SqlDataAdapter da = new SqlDataAdapter(sql, con);
            DataTable dt = new DataTable();
            da.Fill(dt);
            return dt;
        }


        //xác định ngày mình dự đoán, sản phẩm đó có km ko
        public DataTable layDSSanPhamKemKhuyenMaiTheoNgayDuDoan(string ngayDuDoan)
        {
            string sql = "SELECT sp.MaSP,  sp.TenSP, sp.GiaBan, " +
                "CASE WHEN km.MaKM IS NOT NULL THEN 1 ELSE 0 END AS KhuyenMai " +
                "FROM SanPham sp " +
                "LEFT JOIN CTNhomSanPhamKM ctkm ON sp.MaSP = ctkm.MaSP " +
                "LEFT JOIN NhomSanPhamKM nsp ON ctkm.MaNhomSP = nsp.MaNhomSP " +
                "LEFT JOIN KhuyenMai km ON nsp.MaNhomSP = km.MaNhomSPMua " +
                "AND CONVERT(date, '" + ngayDuDoan + "') BETWEEN km.NgayBD AND km.NgayKT";
            SqlDataAdapter da = new SqlDataAdapter(sql, con);
            DataTable dt = new DataTable();
            da.Fill(dt);
            return dt;
        }



        public bool capNhatSLTon(string masp, int slTon)
        {
            try
            {
                string sql = "update SanPham set SLTon = SLTon - " + slTon + " where MaSP= '" + masp + "'";
                return ExcuteNonQuery(sql);
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error: " + ex.Message);
                return false;
            }
        }


        public bool capNhatSLTonChoPN(string masp, int slTon)
        {
            try
            {
                string sql = "update SanPham set SLTon = SLTon + " + slTon + " where MaSP= '" + masp + "'";
                return ExcuteNonQuery(sql);
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error: " + ex.Message);
                return false;
            }
        }

        public bool ExcuteNonQuery(string pQuery)
        {
            Open();
            SqlCommand cmd = new SqlCommand(pQuery, con);
            int so = cmd.ExecuteNonQuery();

            Close();
            return so > 0;
        }

        public bool themSanPham(SanPhamDTO sp)
        {
            try
            {
                string nsx = sp.NgaySX.ToString("yyyy-MM-dd");
                string hsd = sp.HSD.ToString("yyyy-MM-dd");
                string kichCoStr = sp.KichCo.ToString("0.00", CultureInfo.InvariantCulture);
                string sql = "insert into SanPham values( '" + sp.MaSP + "', N'" + sp.TenSP + "', '" + sp.GiaBan + "'," +
                    " '" + sp.SLTon + "', '" + nsx + "',  '" + hsd + "', " + kichCoStr + ", N'" + sp.MauSac + "', '" + sp.MaLoai + "',  '" + sp.MaTH + "', '" + sp.HinhAnh + "', '" + sp.GiaNhap + "'   )";
                return ExcuteNonQuery(sql);
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error: " + ex.Message);
                return false;
            }
        }

        public bool xoaSanPham(SanPhamDTO sp)
        {
            try
            {
                string sql = "delete from SanPham where MaSP= '" + sp.MaSP + "'";
                return ExcuteNonQuery(sql);
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error: " + ex.Message);
                return false;
            }
        }

        public bool suaSanPham(SanPhamDTO sp)
        {
            try
            {
                string nsx = sp.NgaySX.ToString("yyyy-MM-dd");
                string hsd = sp.HSD.ToString("yyyy-MM-dd");
                string kichCoStr = sp.KichCo.ToString("0.00", CultureInfo.InvariantCulture);
                string sql = "update SanPham set TenSP = N'" + sp.TenSP + "', GiaBan = '" + sp.GiaBan + "', SLTon = '" + sp.SLTon + "'," +
                    " NgaySX = '" + nsx + "', HSD = '" + hsd + "', KichCo = " + kichCoStr + ", MauSac = N'" + sp.MauSac + "'," +
                    " MaLoai = '" + sp.MaLoai + "', MaTH = '" + sp.MaTH + "', HinhAnh= '" + sp.HinhAnh + "', GiaNhap = '" + sp.GiaNhap + "' where MaSP= '" + sp.MaSP + "'";
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
