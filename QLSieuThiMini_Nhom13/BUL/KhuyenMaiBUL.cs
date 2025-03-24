using DAL;
using DTO;
using System;
using System.Collections.Generic;
using System.Data;

namespace BUL
{
    public class KhuyenMaiBUL
    {
        KhuyenMaiDAL dal;
        public KhuyenMaiBUL()
        {
            dal = new KhuyenMaiDAL();
        }

        public List<KhuyenMaiDTO> layTatCaKhuyenMai()
        {
            return dal.layTatCaKhuyenMai();
        }

        public List<KhuyenMaiDTO> layTatCaKhuyenMaiTheoNgay(DateTime ngayBD, DateTime ngayKT)
        {
            return dal.layTatCaKhuyenMaiTheoNgay(ngayBD, ngayKT);
        }

        public List<KhuyenMaiDTO> timKiemKhuyenMai(string search)
        {
            return dal.timKiemKhuyenMai(search);
        }

        public KhuyenMaiDTO layKhuyenMaiTheoMaKM(string makm)
        {
            return dal.layKhuyenMaiTheoMaKM(makm);
        }

        public KhuyenMaiDTO layKMCuaSanPham(string maSP)
        {
            return dal.layKMCuaSanPham(maSP);
        }

        public string TaoMaKhuyenMai()
        {
            string key = "KM";

            string dt = dal.layMaKMCuoiCung();

            if (dt == null)
            {
                key += "0001";
            }
            else
            {

                string maBanDau = dt.ToString();
                string sott = maBanDau.Substring(2, 4);
                int num = int.Parse(sott) + 1;

                key += num.ToString("D4");
                //if (num < 10)
                //    key += "00" + num;
                //else
                //{
                //    if (num < 100)
                //        key += "0" + num;
                //    else
                //        key += num;
                //}
            }
            return key;

        }


        public bool themKhuyenMai(KhuyenMaiDTO km)
        {
            return dal.themKhuyenMai(km) == 1;
        }

        public bool suaKhuyenMai(KhuyenMaiDTO km)
        {
            return dal.suaKhuyenMai(km) == 1;
        }

        public bool xoaKhuyenMai(string makm)
        {
            return dal.xoaKhuyenMai(makm) == 1;
        }
    }
}
