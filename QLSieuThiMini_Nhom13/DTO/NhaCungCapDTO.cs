using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTO
{
    public class NhaCungCapDTO
    {
        public string MaNCC { get; set; }
        public string TenNCC { get; set; }
        public string SDT { get; set; }
        public string Email { get; set; }
        public string DiaChi { get; set; }
        public string Website { get; set; }

        public NhaCungCapDTO()
        {

        }
        public NhaCungCapDTO(string maNCC, string tenNCC, string sDT, string email, string diaChi, string website)
        {
            MaNCC = maNCC;
            TenNCC = tenNCC;
            SDT = sDT;
            Email = email;
            DiaChi = diaChi;
            Website = website;
        }
    }
}
