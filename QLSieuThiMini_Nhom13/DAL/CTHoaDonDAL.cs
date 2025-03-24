using DTO;
using System;
using System.Data;
using System.Data.SqlClient;

namespace DAL
{
    public class CTHoaDonDAL
    {
        string conn = null;
        SqlConnection con;

        public CTHoaDonDAL()
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
        public bool ExcuteNonQuery(string pQuery)
        {
            Open();
            SqlCommand cmd = new SqlCommand(pQuery, con);
            int so = cmd.ExecuteNonQuery();

            Close();
            return so > 0;
        }

        public DataTable layCTHoaDon()
        {
            string sql = "select * from ChiTietHD ct, HoaDon hd" +
                " where hd.MaHD = ct.MaHD";
            SqlDataAdapter da = new SqlDataAdapter(sql, con);
            DataTable dt = new DataTable();
            da.Fill(dt);
            return dt;
        }

        public DataTable layDSSPTrongHD(string maHD)
        {
            string sql = "select * from ChiTietHD where MaHD = '" + maHD + "'";
            SqlDataAdapter da = new SqlDataAdapter(sql, con);
            DataTable dt = new DataTable();
            da.Fill(dt);
            return dt;
        }

        public bool themCTHoaDon(CTHoaDonDTO ct)
        {
            try
            {
                string sql = "insert into ChiTietHD values( '" + ct.MaHD + "', '" + ct.MaSP + "', '" + ct.SoLuong + "', '" + ct.DonGia + "')";
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
