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
    public class NhomSanPhamKMDAL
    {
        string conn = null;
        SqlConnection con;

        public NhomSanPhamKMDAL()
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

        public DataTable layDSNhomSanPhamKM()
        {
            string sql = "select * from NhomSanPhamKM";
            SqlDataAdapter da = new SqlDataAdapter(sql, con);
            DataTable dt = new DataTable();
            da.Fill(dt);
            return dt;
        }


        public DataTable layMotNhomSanPhamKM(string maNhomSP)
        {
            string sql = "select * from NhomSanPhamKM n, CTNhomSanPhamKM ct Where n.MaNhomSP = ct.MaNhomSP and n.MaNhomSP = '" + maNhomSP + "'";
            SqlDataAdapter da = new SqlDataAdapter(sql, con);
            DataTable dt = new DataTable();
            da.Fill(dt);
            return dt;
        }


        public DataTable layMaNhomSPCuoiCung()
        {
            string sql = "SELECT TOP 1 MaNhomSP FROM NhomSanPhamKM WHERE MaNhomSP LIKE 'NSP%' ORDER BY MaNhomSP DESC";
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

        public bool themNhomSanPhamKM(NhomSPKhuyenMaiDTO sp)
        {
            try
            {
                string sql = "insert into NhomSanPhamKM values( '" + sp.MaNhomSP + "', N'" + sp.LoaiNhom + "')";
                return ExcuteNonQuery(sql);
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error: " + ex.Message);
                return false;
            }
        }

        public bool xoaNhomSanPhamKM(string maNhomSP)
        {
            try
            {
                string sql = "delete from NhomSanPhamKM where MaNhomSP= '" + maNhomSP + "'";
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
