using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTO
{
    public class ThuongHieuDTO
    {
        public string maThuongHieu { get; set; }
        public string tenThuongHieu { get; set; }

        public ThuongHieuDTO()
        {
            maThuongHieu = string.Empty;
            tenThuongHieu = string.Empty;
        }

        public ThuongHieuDTO(string maThuongHieu, string tenThuongHieu)
        {
            this.maThuongHieu = maThuongHieu;
            this.tenThuongHieu = tenThuongHieu;
        }
    }
}
