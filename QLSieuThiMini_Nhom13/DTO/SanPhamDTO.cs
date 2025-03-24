using System;

namespace DTO
{
    public class SanPhamDTO
    {
        public int STT { get; set; }
        public string MaSP { get; set; }
        public string TenSP { get; set; }
        public double GiaBan { get; set; }
        public double GiaNhap { get; set; }
        public int SLTon { get; set; }
        public DateTime NgaySX { get; set; }
        public DateTime HSD { get; set; }
        public double KichCo { get; set; }
        public string MauSac { get; set; }
        public string MaLoai { get; set; }
        public string MaTH { get; set; }
        public string HinhAnh { get; set; }

        public int KhuyenMai { get; set; }

        public SanPhamDTO() { }

        public SanPhamDTO(string maSP, string tenSP, double giaBan, int km)
        {
            TenSP = tenSP;
            GiaBan = giaBan;
            MaSP = maSP;
            KhuyenMai = km;
        }

        public SanPhamDTO(string maSP, string tenSP, double giaBan, double giaNhap, int sLTon, DateTime ngaySX, DateTime hSD, double kichCo, string mauSac, string maLoai, string maTH, string hinhAnh)
        {
            MaSP = maSP;
            TenSP = tenSP;
            GiaBan = giaBan;
            GiaNhap = giaNhap;
            SLTon = sLTon;
            NgaySX = ngaySX;
            HSD = hSD;
            KichCo = kichCo;
            MauSac = mauSac;
            MaLoai = maLoai;
            MaTH = maTH;
            HinhAnh = hinhAnh;
        }
    }
}
