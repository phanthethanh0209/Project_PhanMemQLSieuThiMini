using DAL;
using DTO;
using System.Collections.Generic;
using System.Data;

namespace BUL
{
    public class KhachHangBUL
    {
        KhachHangDAL khachHangDAL = new KhachHangDAL();
        public List<KhachHangDTO> LayTatCaKhachHang()
        {
            List<KhachHangDTO> lst = new List<KhachHangDTO>();
            DataTable table = khachHangDAL.layTatCaKhachHang();
            foreach (DataRow row in table.Rows)
            {
                KhachHangDTO dto;
                string maKH = row["MaKH"].ToString().Trim();
                string tenKH = row["TenKH"].ToString().Trim();
                string sdt = row["SDT"].ToString().Trim();
                string email = row["Email"].ToString().Trim();
                int diemTichLuy = int.Parse(row[4].ToString());
                dto = new KhachHangDTO(maKH, tenKH, sdt, email, diemTichLuy);
                lst.Add(dto);
            }
            return lst;
        }

        public KhachHangDTO layMotKHTheoSDT(string sdt)
        {
            DataTable table = khachHangDAL.layMotKHTheoSDT(sdt);
            KhachHangDTO dto = null;
            foreach (DataRow row in table.Rows)
            {
                string maKH = row["MaKH"].ToString();
                string tenKH = row["TenKH"].ToString();
                string sodt = row["SDT"].ToString();
                string email = row["Email"].ToString();
                int diemTL = int.Parse(row["DiemTichLuy"].ToString());
                dto = new KhachHangDTO(maKH, tenKH, sodt, email, diemTL);
            }
            return dto;
        }

        public KhachHangDTO layKHTheoMa(string maKH)
        {
            KhachHangDTO dto = null;
            DataTable table = khachHangDAL.layKHTheoMa(maKH);
            if (table.Rows.Count > 0)
            {
                DataRow row = table.Rows[0];
                string tenKH = row["TenKH"].ToString();
                string sodt = row["SDT"].ToString();
                string email = row["Email"].ToString();
                int diemTL = int.Parse(row["DiemTichLuy"].ToString());
                dto = new KhachHangDTO(maKH, tenKH, sodt, email, diemTL);
            }
            return dto;
        }

        public bool ThemKhachHang(KhachHangDTO khachHang)
        {
            return khachHangDAL.themKhachHang(khachHang) == 1;
        }

        public bool XoaKhachHang(KhachHangDTO khachHang)
        {
            return khachHangDAL.xoaKhachHang(khachHang) == 1;
        }

        public bool SuaKhachHang(KhachHangDTO khachHang)
        {
            return khachHangDAL.suaKhachHang(khachHang) == 1;
        }

        public bool CapNhatDTL(KhachHangDTO khachHang)
        {
            return khachHangDAL.capNhatDTL(khachHang) == 1;
        }

        public bool KiemTraTrungSDT(string sdt)
        {
            return khachHangDAL.kiemTraSDTTonTai(sdt);
        }
    }
}
