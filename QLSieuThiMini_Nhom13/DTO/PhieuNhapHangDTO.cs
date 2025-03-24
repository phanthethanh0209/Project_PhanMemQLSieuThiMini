using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTO
{
    public class PhieuNhapHangDTO
    {
        public string MaPNH { get; set; }
        public DateTime NgayNhap { get; set; }
        public double TongTien { get; set; }
        public string MaNCC { get; set; }
        public string MaND { get; set; }
        public string TenNCC { get; set; }
        public string TenND { get; set; }

        public PhieuNhapHangDTO()
        {

        }

        public PhieuNhapHangDTO(string maPNH, DateTime ngayNhap, double tongTien, string maNCC, string maND)
        {
            MaPNH = maPNH;
            NgayNhap = ngayNhap;
            TongTien = tongTien;
            MaNCC = maNCC;
            MaND = maND;
        }

        public PhieuNhapHangDTO(string maPNH, DateTime ngayNhap, double tongTien, string maNCC, string maND, string tenNCC, string tenND)
        {
            MaPNH = maPNH;
            NgayNhap = ngayNhap;
            TongTien = tongTien;
            MaNCC = maNCC;
            MaND = maND;
            TenNCC = tenNCC;
            TenND = tenND;
        }
    }
}
