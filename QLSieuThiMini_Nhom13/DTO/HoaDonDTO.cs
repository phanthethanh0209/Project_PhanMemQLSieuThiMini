using System;

namespace DTO
{
    public class HoaDonDTO
    {
        public string MaHD { get; set; }
        public DateTime NgayLap { get; set; }
        public double? TichDiem { get; set; }
        public double TongTien { get; set; }
        public string MaKH { get; set; }
        public string TenKH { get; set; }
        public string MaND { get; set; }
        public string TenND { get; set; }
        public double TienNhan { get; set; }
        public double TienGiam { get; set; }



        public HoaDonDTO() { }

        public HoaDonDTO(string maHD, DateTime ngayLap, double? tichDiem, double tongTien, string maKH, string maND, string tenKH, string tenND, double tienNhan, double tienGiam)
        {
            MaHD = maHD;
            NgayLap = ngayLap;
            TichDiem = tichDiem;
            TongTien = tongTien;
            MaKH = maKH;
            MaND = maND;
            TenKH = tenKH;
            TenND = tenND;
            TienNhan = tienNhan;
            TienGiam = tienGiam;
        }

        public HoaDonDTO(string maHD, DateTime ngayLap, double tongTien, string maKH, string maND, double tienNhan)
        {
            MaHD = maHD;
            NgayLap = ngayLap;
            TongTien = tongTien;
            MaKH = maKH;
            MaND = maND;
            TienNhan = tienNhan;
        }

        public HoaDonDTO(string maHD, DateTime ngayLap, double? tichDiem, double tongTien, string tenKH, string tenND, double tienNhan)
        {
            MaHD = maHD;
            NgayLap = ngayLap;
            TichDiem = tichDiem;
            TongTien = tongTien;
            TenKH = tenKH;
            TenND = tenND;
            TienNhan = tienNhan;
        }

        public HoaDonDTO(string maHD, DateTime ngayLap, double? tichDiem, double tongTien, string maKH, string maND, double tienNhan, double tienGiam)
        {
            MaHD = maHD;
            NgayLap = ngayLap;
            TongTien = tongTien;
            TichDiem = tichDiem;
            MaKH = maKH;
            MaND = maND;
            TienNhan = tienNhan;
            TienGiam = tienGiam;
        }
    }
}
