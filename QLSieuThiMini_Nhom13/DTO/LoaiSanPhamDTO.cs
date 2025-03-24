using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTO
{
    public class LoaiSanPhamDTO
    {
        public string maLoai { get; set; }
        public string tenLoai { get; set; }

        public LoaiSanPhamDTO()
        {
            maLoai = string.Empty;
            tenLoai = string.Empty;
        }

        public LoaiSanPhamDTO(string maLoai, string tenLoai)
        {
            this.maLoai = maLoai;
            this.tenLoai = tenLoai;
        }
    }
}
