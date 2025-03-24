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
    public class CTNhomSanPhamKMDAL
    {
        string conn = null;
        SqlConnection con;

        public CTNhomSanPhamKMDAL()
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

        
        //public DataTable layCTNhomSanPhamKMDAL(string maNhomSP)
        //{
        //    string sql = "select * from NhomSanPhamKM Where MaNhomSP = '" + maNhomSP + "'";
        //    SqlDataAdapter da = new SqlDataAdapter(sql, con);
        //    DataTable dt = new DataTable();
        //    da.Fill(dt);
        //    return dt;
        //}


        public bool ExcuteNonQuery(string pQuery)
        {
            Open();
            SqlCommand cmd = new SqlCommand(pQuery, con);
            int so = cmd.ExecuteNonQuery();

            Close();
            return so > 0;
        }

        public bool themCTNhomSanPhamKM(CTNhomSanPhamKMDTO sp)
        {
            try
            {
                string sql = "insert into CTNhomSanPhamKM values( '" + sp.MaNhomSP + "', N'" + sp.MaSP + "')";
                return ExcuteNonQuery(sql);
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error: " + ex.Message);
                return false;
            }
        }

        public bool xoaCTNhomSanPhamKM(CTNhomSanPhamKMDTO sp)
        {
            try
            {
                string sql = "delete from CTNhomSanPhamKM where MaNhomSP= '" + sp.MaNhomSP + "' and MaSP = '"+sp.MaSP+"'";
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
