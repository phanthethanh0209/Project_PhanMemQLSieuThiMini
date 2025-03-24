using System;

namespace DTO
{
    public class NhomSPKhuyenMaiDTO
    {
        public string MaNhomSP { get; set; }
        public string LoaiNhom { get; set; }
        
        public NhomSPKhuyenMaiDTO() { }
        public NhomSPKhuyenMaiDTO(string manhomSP, string loaiNhom)
        {
            MaNhomSP = manhomSP;
            LoaiNhom = loaiNhom;
        }
    }
}
