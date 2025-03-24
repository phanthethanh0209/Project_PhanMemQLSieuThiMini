using DAL;
using DTO;
using System;
using System.Collections.Generic;
using System.Data;

namespace BUL
{
    public class HoaDonBUL
    {
        HoaDonDAL dal;
        public HoaDonBUL()
        {
            dal = new HoaDonDAL();
        }

        public List<HoaDonDTO> layDSHoaDon(string text)
        {
            List<HoaDonDTO> lst = new List<HoaDonDTO>();
            DataTable table = dal.layDSHoaDon(text);
            foreach (DataRow row in table.Rows)
            {
                HoaDonDTO dto;
                string maHD = row["MaHD"].ToString();
                DateTime ngayLap = DateTime.Parse(row["NgayLap"].ToString());
                int? tichDiem = row["TichDiem"] != DBNull.Value ? (int?)int.Parse(row["TichDiem"].ToString()) : null;
                double tongTien = double.Parse(row["TongTien"].ToString());
                double tienNhan = double.Parse(row["TienNhan"].ToString());
                //string maKH = row["MaKH"].ToString();
                //string maND = row["MaND"].ToString();
                string tenKH = "Khách lẻ";

                if (row["MaKH"].ToString() != "")
                    tenKH = row["TenKH"].ToString();
                //if ( text != null && text.StartsWith("HD") == false)

                string tenND = row["TenND"].ToString();
                dto = new HoaDonDTO(maHD, ngayLap, tichDiem, tongTien, tenKH, tenND, tienNhan);
                lst.Add(dto);
            }
            return lst;
        }

        public List<HoaDonDTO> locHoaDonTheoNgay(string ngayBD, string ngayKT)
        {
            List<HoaDonDTO> lst = new List<HoaDonDTO>();
            DataTable table = dal.locHoaDonTheoNgay(ngayBD, ngayKT);
            foreach (DataRow row in table.Rows)
            {
                HoaDonDTO dto;
                string maHD = row["MaHD"].ToString();
                DateTime ngayLap = DateTime.Parse(row["NgayLap"].ToString());
                int? tichDiem = row["TichDiem"] != DBNull.Value ? (int?)int.Parse(row["TichDiem"].ToString()) : null;
                double tongTien = double.Parse(row["TongTien"].ToString());
                double tienNhan = double.Parse(row["TienNhan"].ToString());

                string tenKH = "Khách lẻ";

                if (row["MaKH"].ToString() != "")
                    tenKH = row["TenKH"].ToString();

                string tenND = row["TenND"].ToString();
                dto = new HoaDonDTO(maHD, ngayLap, tichDiem, tongTien, tenKH, tenND, tienNhan);
                lst.Add(dto);
            }
            return lst;
        }



        public List<LichSuBanHangDTO> layLichSuBanHang()
        {
            List<LichSuBanHangDTO> lst = new List<LichSuBanHangDTO>();
            DataTable table = dal.layLichSuBanHang();
            foreach (DataRow row in table.Rows)
            {
                LichSuBanHangDTO dto;
                DateTime ngayLap = DateTime.Parse(row["NgayLap"].ToString());
                string tenSP = row["TenSP"].ToString();
                string maSP = row["MaSP"].ToString();
                float soLuong = float.Parse(row["SoLuongBan"].ToString());
                float giaBan = float.Parse(row["GiaBan"].ToString());
                float doanhThu = float.Parse(row["DoanhThu"].ToString());
                float km = float.Parse(row["KhuyenMai"].ToString());
                //int giaBan = Convert.ToInt32(row["GiaBan"]);
                //int doanhThu = Convert.ToInt32(row["DoanhThu"]);


                dto = new LichSuBanHangDTO(ngayLap, maSP, tenSP, soLuong, giaBan, doanhThu, km);
                lst.Add(dto);
            }
            return lst;
        }



        public HoaDonDTO layTTHoaDon(string maHD)
        {
            HoaDonDTO dto = null;  // Khởi tạo null để trả về nếu không có dữ liệu
            DataTable table = dal.layTTHoaDon(maHD);

            if (table.Rows.Count > 0)
            {
                DataRow row = table.Rows[0];  // Lấy hàng đầu tiên từ DataTable
                DateTime ngayLap = DateTime.Parse(row["NgayLap"].ToString());
                double tongTien = double.Parse(row["TongTien"].ToString());
                string maKH = row["MaKH"].ToString();
                string maND = row["MaND"].ToString();
                double tienNhan = double.Parse(row["TienNhan"].ToString());
                int? tichDiem = row["TichDiem"] != DBNull.Value ? (int?)int.Parse(row["TichDiem"].ToString()) : null;
                double tienGiam = double.Parse(row["TienGiam"].ToString());

                // Tạo một đối tượng HoaDonDTO với các thông tin lấy được
                dto = new HoaDonDTO(maHD, ngayLap, tichDiem, tongTien, maKH, maND, tienNhan, tienGiam);
            }

            return dto;
        }



        public string TaoMaHD()
        {
            string key = "HD" + DateTime.Now.ToString("ddMMyyHHmmss");
            return key;
        }

        public bool themHoaDon(HoaDonDTO hd)
        {
            return dal.themHoaDon(hd);
        }
    }
}
