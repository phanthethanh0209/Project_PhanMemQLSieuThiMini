namespace DTO
{
    public class CTHoaDonDTO
    {
        public string MaHD { get; set; }
        public string MaSP { get; set; }
        public int SoLuong { get; set; }
        public double DonGia { get; set; }

        public CTHoaDonDTO(string maHD, string maSP, int soLuong, double donGia)
        {
            MaHD = maHD;
            MaSP = maSP;
            SoLuong = soLuong;
            DonGia = donGia;
        }

        public CTHoaDonDTO() { }

    }
}
