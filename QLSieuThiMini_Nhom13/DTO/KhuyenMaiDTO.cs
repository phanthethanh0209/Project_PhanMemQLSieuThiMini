using System;

namespace DTO
{
    public class KhuyenMaiDTO
    {
        public string MaKM { get; set; }
        public string TenKM { get; set; }
        public string MaNhomSPMua { get; set; }
        public string MaNhomSPTang { get; set; }
        public int SLMua { get; set; }
        public int? SLTang { get; set; }
        public DateTime NgayBD { get; set; }
        public DateTime NgayKT { get; set; }
        public double GiaGiam { get; set; }
        public string DonViGiam { get; set; }

        public KhuyenMaiDTO() { }
        public KhuyenMaiDTO(string makm, string tenkm, string maNhomMua, string maNhomTang, int sLMua, int? sLTang, DateTime ngaybd, DateTime ngaykt, double giaG, string dvg)
        {
            MaKM = makm;
            TenKM = tenkm;
            MaNhomSPMua = maNhomMua;
            MaNhomSPTang = maNhomTang;
            SLMua = sLMua;
            SLTang = sLTang;
            NgayBD = ngaybd;
            NgayKT = ngaykt;
            GiaGiam = giaG;
            DonViGiam = dvg;
        }
    }
}
