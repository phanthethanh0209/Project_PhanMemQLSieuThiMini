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
    public class ND_NhomNDBUL
    {
        ND_NhomNDDAL nhomNguoidungDAL = new ND_NhomNDDAL();
        public List<ND_NhomNDDTO> layNguoiDungTheoMaNhom(string maNhomDK)
        {
            List<ND_NhomNDDTO> lst = new List<ND_NhomNDDTO>();
            DataTable table = nhomNguoidungDAL.layNguoiDungTheoMaNhom(maNhomDK);
            foreach (DataRow row in table.Rows)
            {
                ND_NhomNDDTO dto;

                string maNhom = row["MaNhom"].ToString().Trim();
                string maND = row["MaND"].ToString().Trim();
                string tenTk = row["TenTK"].ToString().Trim();
                string tenND = row["TenND"].ToString().Trim();
                string ghiChu = row["GhiChu"].ToString().Trim();

                dto = new ND_NhomNDDTO(maNhom, maND, tenTk, tenND, ghiChu);
                lst.Add(dto);
            }
            return lst;
        }

        public List<string> layDSMaNhomTuTenTK(string tenTK)
        {
            List<string> lst = new List<string>();
            DataTable table = nhomNguoidungDAL.layDSMaNhomTuTenTK(tenTK);
            foreach (DataRow row in table.Rows)
            {
                string maNhom = row["MaNhom"].ToString().Trim();

                lst.Add(maNhom);
            }
            return lst;
        }


        public bool themND_NhomND(ND_NhomNDDTO nd_nhomND)
        {
            return nhomNguoidungDAL.themND_NhomND(nd_nhomND) == 1;
        }

        public bool xoaND_NhomND(ND_NhomNDDTO nd_nhomND)
        {
            return nhomNguoidungDAL.xoaND_NhomND(nd_nhomND) == 1;
        }

    }
}
