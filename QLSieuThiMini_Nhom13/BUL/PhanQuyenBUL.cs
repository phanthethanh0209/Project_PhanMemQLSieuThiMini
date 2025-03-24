using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DTO;
using DAL;
using System.Data;

namespace BUL
{
    public class PhanQuyenBUL
    {
        PhanQuyenDAL quyenDAL = new PhanQuyenDAL();
        public List<NhomNguoiDungDTO> LayNhomNguoiDungChuaCoManHinh(string maMH)
        {
            List<NhomNguoiDungDTO> lst = new List<NhomNguoiDungDTO>();
            DataTable table = quyenDAL.LayNhomNguoiDungChuaCoManHinh(maMH);
            foreach (DataRow row in table.Rows)
            {
                NhomNguoiDungDTO dto;

                string maNhom = row["MaNhom"].ToString().Trim();
                string tenNhom = row["TenNhom"].ToString().Trim();

                dto = new NhomNguoiDungDTO(maNhom, tenNhom, "");
                lst.Add(dto);
            }
            return lst;
        }

        public List<PhanQuyenDTO> LayNhomNguoiDungCoManHinh(string maMH)
        {
            List<PhanQuyenDTO> lst = new List<PhanQuyenDTO>();
            DataTable table = quyenDAL.LayNhomNguoiDungCoManHinh(maMH);
            foreach (DataRow row in table.Rows)
            {
                PhanQuyenDTO dto;

                string maNhom = row["MaNhom"].ToString().Trim();
                string tenNhom = row["TenNhom"].ToString().Trim();
                string tenMH = row["TenMH"].ToString().Trim();

                dto = new PhanQuyenDTO(maNhom, maMH, tenNhom, tenMH, "");
                lst.Add(dto);
            }
            return lst;
        }

        public bool themQuyen(PhanQuyenDTO pq)
        {
            return quyenDAL.themQuyen(pq) == 1;
        }

        public bool xoaQuyen(PhanQuyenDTO pq)
        {
            return quyenDAL.xoaQuyen(pq) == 1;
        }

        public DataTable layDSTenManHinh(string maNhom)
        {
            return quyenDAL.layDSTenManHinh(maNhom);
        }

    }
}
