using System;

namespace DTO
{
    public class CTNhomSanPhamKMDTO
    {
        public string MaNhomSP { get; set; }
        public string MaSP { get; set; }
        

        public CTNhomSanPhamKMDTO() { }
        public CTNhomSanPhamKMDTO(string manhomSP, string maSP)
        {
            MaNhomSP = manhomSP;
            MaSP = maSP;
        }
    }
}
