using DAL;
using DTO;
using System.Collections.Generic;
using System.Data;

namespace BUL
{
    public class CTHoaDonBUL
    {
        CTHoaDonDAL dal;
        public CTHoaDonBUL()
        {
            dal = new CTHoaDonDAL();
        }

        public List<CTHoaDonDTO> layCTHoaDon()
        {
            List<CTHoaDonDTO> lst = new List<CTHoaDonDTO>();
            DataTable table = dal.layCTHoaDon();
            foreach (DataRow row in table.Rows)
            {
                CTHoaDonDTO dto;
                string maHD = row["MaHD"].ToString();
                string maSP = row["MaSP"].ToString();
                int soLuong = int.Parse(row["SoLuong"].ToString());
                double donGia = double.Parse(row["DonGia"].ToString());
                dto = new CTHoaDonDTO(maHD, maSP, soLuong, donGia);
                lst.Add(dto);
            }
            return lst;
        }

        public List<CTHoaDonDTO> layDSSPTrongHD(string maHD)
        {
            List<CTHoaDonDTO> lst = new List<CTHoaDonDTO>();
            DataTable table = dal.layDSSPTrongHD(maHD);
            foreach (DataRow row in table.Rows)
            {
                CTHoaDonDTO dto;
                string maSP = row["MaSP"].ToString();
                int soLuong = int.Parse(row["SoLuong"].ToString());
                double donGia = double.Parse(row["DonGia"].ToString());
                dto = new CTHoaDonDTO(maHD, maSP, soLuong, donGia);
                lst.Add(dto);
            }
            return lst;
        }

        public bool themCTHoaDon(CTHoaDonDTO hd)
        {
            return dal.themCTHoaDon(hd);
        }
    }
}
