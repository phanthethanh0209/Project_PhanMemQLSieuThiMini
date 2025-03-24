using DAL;
using DTO;
using System;
using System.Collections.Generic;
using System.Data;

namespace BUL
{
    public class NhomSanPhamKMBUL
    {
        NhomSanPhamKMDAL dal= new NhomSanPhamKMDAL();
       
        public List<NhomSPKhuyenMaiDTO> layDSNhomSanPhamKM()
        {
            List<NhomSPKhuyenMaiDTO> lst = new List<NhomSPKhuyenMaiDTO>();
            DataTable table = dal.layDSNhomSanPhamKM();
            foreach (DataRow row in table.Rows)
            {
                NhomSPKhuyenMaiDTO dto;
                string maSP = row["MaNhomSP"].ToString();
                string tenSP = row["LoaiNhom"].ToString();
               
                dto = new NhomSPKhuyenMaiDTO(maSP, tenSP);
                lst.Add(dto);
            }
            return lst;
        }


        public List<CTNhomSanPhamKMDTO> layMotNhomSanPhamKM(string maNhomSP)
        {
            List<CTNhomSanPhamKMDTO> lst = new List<CTNhomSanPhamKMDTO>();
            DataTable table = dal.layMotNhomSanPhamKM(maNhomSP);
            foreach (DataRow row in table.Rows)
            {
                CTNhomSanPhamKMDTO dto;
                string maNhom = row["MaNhomSP"].ToString();
               // string tenSP = row["LoaiNhom"].ToString();
                string maSP = row["MaSP"].ToString();

                dto = new CTNhomSanPhamKMDTO(maNhom, maSP);
                lst.Add(dto);
            }
            return lst;
        }


        public string TaoMaNhomSanPham()
        {
            string key = "NSPKM";

            DataTable dt = dal.layMaNhomSPCuoiCung();

            if (dt.Rows.Count == 0)
            {
                key += "0001";
            }
            else
            {

                string maBanDau = dt.Rows[0][0].ToString();
                string sott = maBanDau.Substring(5, 4);
                int num = int.Parse(sott) + 1;
                key += num.ToString("D4");
                //if (num < 10)
                //    key += "000" + num;
                //else
                //{
                //    if (num < 100)
                //        key += "00" + num;
                //    else
                //        key += num;
                //}
            }
            return key;

        }

    

        public bool themSanPham(NhomSPKhuyenMaiDTO sp)
        {
            return dal.themNhomSanPhamKM(sp);
        }

      
        public bool xoaSanPham(string maNhom)
        {
            return dal.xoaNhomSanPhamKM(maNhom);
        }
    }
}
