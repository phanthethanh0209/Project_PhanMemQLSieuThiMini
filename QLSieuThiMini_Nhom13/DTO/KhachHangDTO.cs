using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTO
{
    public class KhachHangDTO
    {
        public string maKH { get; set; }
        public string tenKH { get; set; }
        public string sdt { get; set; }
        public string email { get; set; }
        public int diemTichLuy { get; set; }

        public KhachHangDTO()
        {
            this.maKH = "";
            this.tenKH = "";
            this.sdt = "";
            this.email = "";
            this.diemTichLuy = 0;
        }

        public KhachHangDTO(string maKH, string tenKH, string sdt, string email, int diemTichLuy)
        {
            this.maKH = maKH;
            this.tenKH = tenKH;
            this.sdt = sdt;
            this.email = email;
            this.diemTichLuy = diemTichLuy;
        }
    }
}
