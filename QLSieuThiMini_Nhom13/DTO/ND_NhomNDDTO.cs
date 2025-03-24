using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTO
{
    public class ND_NhomNDDTO
    {
        public string MaNhom { get; set; }
        public string MaND { get; set; }
        public string TenTK { get; set; }
        public string TenND { get; set; }
        public string GhiChu { get; set; }

        public ND_NhomNDDTO(string maNhom, string maND, string tenTK, string tenND, string ghiChu)
        {
            MaNhom = maNhom;
            MaND = maND;
            TenTK = tenTK;
            TenND = tenND;
            GhiChu = ghiChu;
        }

        public ND_NhomNDDTO(string maNhom, string maND, string ghiChu)
        {
            MaNhom = maNhom;
            MaND = maND;
            GhiChu = ghiChu;
        }
    }
}
