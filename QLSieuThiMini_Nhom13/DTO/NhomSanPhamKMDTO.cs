using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTO
{
    public class NhomSanPhamKMDTO
    {
        public string MaNhomSP { get; set; }
        public string LoaiNhom { get; set; }


        public NhomSanPhamKMDTO()
        {

        }

        public NhomSanPhamKMDTO(string maNhomKM, string loaiNhom)
        {
            MaNhomSP = maNhomKM;
            LoaiNhom = loaiNhom;
        }
    }
}
