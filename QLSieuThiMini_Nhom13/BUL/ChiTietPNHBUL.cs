using DAL;
using DTO;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BUL
{
    public class ChiTietPNHBUL
    {
        ChiTietPNHDAL ctPNHDAL = new ChiTietPNHDAL();

        public List<ChiTietPNHDTO> getAll()
        {
            List<ChiTietPNHDTO> lst = new List<ChiTietPNHDTO>();
            DataTable table = ctPNHDAL.getAll();
            foreach (DataRow row in table.Rows)
            {
                ChiTietPNHDTO dto;
                string maPNH = row[0].ToString();
                string maSP = row[1].ToString();
                int soLuong = int.Parse(row[2].ToString());
                double donGia = double.Parse(row[3].ToString());
                dto = new ChiTietPNHDTO(maPNH, maSP, soLuong, donGia);
                lst.Add(dto);
            }
            return lst;
        }

        public List<ChiTietPNHDTO> layDSSPTrongPhieuNhap(string maPN)
        {
            List<ChiTietPNHDTO> lst = new List<ChiTietPNHDTO>();
            DataTable table = ctPNHDAL.layDSSPTrongPhieuNhap(maPN);
            foreach (DataRow row in table.Rows)
            {
                ChiTietPNHDTO dto;
                string maSP = row["MaSP"].ToString();
                int soLuong = int.Parse(row["SoLuong"].ToString());
                double donGia = double.Parse(row["DonGia"].ToString());
                dto = new ChiTietPNHDTO(maPN, maSP, soLuong, donGia);
                lst.Add(dto);
            }
            return lst;
        }

        public bool InsertChiTietPNH(ChiTietPNHDTO pnh)
        {
            return ctPNHDAL.InsertChiTietPNH(pnh);
        }

        public bool UpdateChiTietPNH(ChiTietPNHDTO pnh)
        {
            return ctPNHDAL.UpdateChiTietPNH(pnh);
        }

        public bool DeleteChiTietPNH(string maPNH, string maSP)
        {
            return ctPNHDAL.DeleteChiTietPNH(maPNH, maSP);
        }
    }
}
