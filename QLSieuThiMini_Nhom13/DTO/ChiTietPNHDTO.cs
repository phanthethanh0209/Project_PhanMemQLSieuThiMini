using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTO
{
    public class ChiTietPNHDTO
    {
        public string MaPNH { get; set; }
        public string MaSP { get; set; }
        public int SoLuong { get; set; }
        public double DonGia { get; set; }

        public ChiTietPNHDTO()
        {

        }

        public ChiTietPNHDTO(string maPNH, string maSP, int soLuong, double donGia)
        {
            MaPNH = maPNH;
            MaSP = maSP;
            SoLuong = soLuong;
            DonGia = donGia;
        }

    }

    
}
