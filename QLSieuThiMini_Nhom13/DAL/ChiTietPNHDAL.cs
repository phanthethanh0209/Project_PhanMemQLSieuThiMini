using DTO;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL
{
    public class ChiTietPNHDAL
    {
        string conn = null;
        SqlConnection con;

        public ChiTietPNHDAL()
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
            string sql = "select * from ChiTietPNH";
            SqlDataAdapter da = new SqlDataAdapter(sql, con);
            DataTable dt = new DataTable();
            da.Fill(dt);
            return dt;
        }

        public DataTable layDSSPTrongPhieuNhap(string maPNH)
        {
            string sql = "select * from ChiTietPNH where MaPNH = '" + maPNH + "'";
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


        public bool InsertChiTietPNH(ChiTietPNHDTO pnh)
        {
            string sql = "insert into ChiTietPNH values( '" + pnh.MaPNH + "', '" + pnh.MaSP + "', '" + pnh.SoLuong + "', '" + pnh.DonGia + "')";
            return ExcuteNonQuery(sql);
        }

        public bool DeleteChiTietPNH(string maPNH, string MaSP)
        {
            string sql = "delete from ChiTietPNH where MaPNH= '" + maPNH + "' and MaSP= '"+ MaSP +"'";
            return ExcuteNonQuery(sql);
        }

        public bool UpdateChiTietPNH(ChiTietPNHDTO pnh)
        {
            string sql = "update ChiTietPNH set SoLuong='" + pnh.SoLuong + "', DonGia='" + pnh.DonGia + "' where MaPNH= '" + pnh.MaPNH + "' and MaSP= '"+pnh.MaSP+"'";
            return ExcuteNonQuery(sql);
        }
    }
}
