using DAL;
using DTO;
using System.Collections.Generic;
using System.Data;

namespace BUL
{
    public class NhomNguoiDungBUL
    {
        NhomNguoiDungDAL nhomNguoidungDAL = new NhomNguoiDungDAL();

        public List<NhomNguoiDungDTO> layDSNhomND()
        {
            List<NhomNguoiDungDTO> lst = new List<NhomNguoiDungDTO>();
            DataTable table = nhomNguoidungDAL.layTatCaNhomND();
            foreach (DataRow row in table.Rows)
            {
                NhomNguoiDungDTO dto;
                string maNhom = row["MaNhom"].ToString().Trim();
                string tenNhom = row["TenNhom"].ToString().Trim();
                string ghiChu = row["GhiChu"].ToString().Trim();

                dto = new NhomNguoiDungDTO(maNhom, tenNhom, ghiChu);
                lst.Add(dto);
            }
            return lst;
        }

        public bool themNhomND(NhomNguoiDungDTO nhom)
        {
            return nhomNguoidungDAL.themNhomND(nhom) == 1;
        }

        public bool xoaNhomND(NhomNguoiDungDTO nhom)
        {
            return nhomNguoidungDAL.xoaNhomND(nhom) == 1;
        }

        public bool suaNhomND(NhomNguoiDungDTO nhom)
        {
            return nhomNguoidungDAL.suaNhomND(nhom) == 1;
        }
    }
}
