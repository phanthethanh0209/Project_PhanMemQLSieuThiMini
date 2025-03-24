using DAL;
using DTO;
using System;
using System.Collections.Generic;
using System.Data;

namespace BUL
{
    public class PhieuNhapHangBUL
    {
        PhieuNhapHangDAL phieuNhaphangDAL = new PhieuNhapHangDAL();

        //public List<PhieuNhapHangDTO> getAll()
        //{
        //    List<PhieuNhapHangDTO> lst = new List<PhieuNhapHangDTO>();
        //    DataTable table = phieuNhaphangDAL.getAll();
        //    foreach (DataRow row in table.Rows)
        //    {
        //        PhieuNhapHangDTO dto;
        //        string maPNH = row["MaPNH"].ToString();
        //        DateTime ngayNhap = DateTime.Parse(row["NgayNhap"].ToString());
        //        double tongTien = double.Parse(row["TongTien"].ToString());
        //        string tenNCC = row["TenNCC"].ToString();
        //        string tenND = row["TenND"].ToString();
        //        dto = new PhieuNhapHangDTO(maPNH, ngayNhap, tongTien, tenNCC, tenND);
        //        lst.Add(dto);
        //    }
        //    return lst;
        //}


        public List<PhieuNhapHangDTO> layDSPhieuNhapHang(string text)
        {
            List<PhieuNhapHangDTO> lst = new List<PhieuNhapHangDTO>();
            DataTable table = phieuNhaphangDAL.layDSPhieuNhapHang(text);
            foreach (DataRow row in table.Rows)
            {
                PhieuNhapHangDTO dto;
                string maPNH = row["MaPNH"].ToString();
                DateTime ngayNhap = DateTime.Parse(row["NgayNhap"].ToString());
                double tongTien = double.Parse(row["TongTien"].ToString());
                string maNCC = row["MaNCC"].ToString();
                string maND = row["MaND"].ToString();
                string tenNCC = row["TenNCC"].ToString();
                string tenND = row["TenND"].ToString();
                dto = new PhieuNhapHangDTO(maPNH, ngayNhap, tongTien, maNCC, maND, tenNCC, tenND);
                lst.Add(dto);
            }
            return lst;
        }

        public List<PhieuNhapHangDTO> locPhieuNhapHangTheoNgay(string ngayBD, string ngayKT)
        {
            List<PhieuNhapHangDTO> lst = new List<PhieuNhapHangDTO>();
            DataTable table = phieuNhaphangDAL.locPhieuNhapHangTheoNgay(ngayBD, ngayKT);
            foreach (DataRow row in table.Rows)
            {
                PhieuNhapHangDTO dto;
                string maPNH = row["MaPNH"].ToString();
                DateTime ngayNhap = DateTime.Parse(row["NgayNhap"].ToString());
                double tongTien = double.Parse(row["TongTien"].ToString());
                string maNCC = row["MaNCC"].ToString();
                string maND = row["MaND"].ToString();
                string tenNCC = row["TenNCC"].ToString();
                string tenND = row["TenND"].ToString();
                dto = new PhieuNhapHangDTO(maPNH, ngayNhap, tongTien, maNCC, maND, tenNCC, tenND);
                lst.Add(dto);
            }
            return lst;
        }

        public PhieuNhapHangDTO layMotPhieuNhapHang(string MaPNH)
        {
            DataTable table = phieuNhaphangDAL.layMotPhieuNhapHang(MaPNH);
            PhieuNhapHangDTO dto = new PhieuNhapHangDTO();
            foreach (DataRow row in table.Rows)
            {
                string maPNH = row[0].ToString();
                DateTime ngayNhap = DateTime.Parse(row[1].ToString());
                double tongTien = double.Parse(row[2].ToString());
                string maNCC = row[3].ToString();
                string maND = row[4].ToString();
                dto = new PhieuNhapHangDTO(maPNH, ngayNhap, tongTien, maNCC, maND);

            }
            return dto;
        }

        public string TaoMaPNH(string maNCC) //thể hiện số phiếu nhập hàng của 1 nhà cung cấp
        {
            string key = "PN_" + maNCC.Trim() + "_" + DateTime.Now.ToString("ddMMyy");

            DataTable dt = phieuNhaphangDAL.layMaPNHCuoiCung(key);

            if (dt.Rows.Count == 0)
            {
                key += "_001";
            }
            else
            {
                string maBanDau = dt.Rows[0][0].ToString();
                string sott = maBanDau.Substring(maBanDau.Trim().Length - 3, 3);
                int num = int.Parse(sott) + 1;
                if (num < 10)
                    key += "_00" + num;
                else
                {
                    if (num < 100)
                        key += "_0" + num;
                    else
                        key += num;
                }
            }
            return key;

        }

        public bool InsertPhieuNhapHang(PhieuNhapHangDTO pnh)
        {
            return phieuNhaphangDAL.InsertPhieuNhapHang(pnh);
        }

        public bool UpdatePhieuNhapHang(PhieuNhapHangDTO pnh)
        {
            return phieuNhaphangDAL.UpdatePhieuNhapHang(pnh);
        }

        public bool DeletePhieuNhapHang(string maPNH)
        {
            return phieuNhaphangDAL.DeletePhieuNhapHang(maPNH);
        }


        public DataTable layTTPhieuNhapHang(string maPN)
        {
            DataTable table = phieuNhaphangDAL.layTTPhieuNhapHang(maPN);

            return table;
        }
    }
}
