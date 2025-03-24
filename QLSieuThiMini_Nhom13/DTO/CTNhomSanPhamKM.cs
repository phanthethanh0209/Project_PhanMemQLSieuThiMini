using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTO
{
    public class CTNhomSanPhamKM
    {
        public string MaNhomSP { get; set; }
        public string MaSP { get; set; }

        public CTNhomSanPhamKM()
        {

        }

        public CTNhomSanPhamKM(string maNhomSP, string maSP)
        {
            MaNhomSP = maNhomSP;
            MaSP = maSP;
        }
    }
}
