using DAL;
using DTO;
using System;
using System.Collections.Generic;
using System.Data;

namespace BUL
{
    public class CTNhomSanPhamKMBUL
    {
        CTNhomSanPhamKMDAL dal= new CTNhomSanPhamKMDAL();
       
        //public List<CTNhomSanPhamKMDTO> layDSNhomSanPhamKM()
        //{
        //    List<CTNhomSanPhamKMDTO> lst = new List<CTNhomSanPhamKMDTO>();
        //    DataTable table = dal.lay();
        //    foreach (DataRow row in table.Rows)
        //    {
        //        CTNhomSanPhamKMDTO dto;
        //        string maSP = row["MaNhomSP"].ToString();
        //        string tenSP = row["LoaiNhom"].ToString();
               
        //        dto = new CTNhomSanPhamKMDTO(maSP, tenSP);
        //        lst.Add(dto);
        //    }
        //    return lst;
        //}

      
        public bool themSanPham(CTNhomSanPhamKMDTO sp)
        {
            return dal.themCTNhomSanPhamKM(sp);
        }

      
        public bool xoaSanPham(CTNhomSanPhamKMDTO sp)
        {
            return dal.xoaCTNhomSanPhamKM(sp);
        }
    }
}
