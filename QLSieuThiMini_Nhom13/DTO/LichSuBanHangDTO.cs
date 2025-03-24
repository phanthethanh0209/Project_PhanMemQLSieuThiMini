using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTO
{
    public class LichSuBanHangDTO
    {
        public DateTime NgayLap { get; set; }
        public string TenSP { get; set; }
        public string MaSP { get; set; }
        public float SoLuong { get; set; }
        public float GiaBan { get; set; }
        public float DoanhThu { get; set; }
        public float NgayLapAsFloat { get; set; }
        public float ThuTrongTuan { get; set; }
        public float KhuyenMai { get; set; }

        public LichSuBanHangDTO(DateTime ngayLap, string maSP, string tenSP, float soLuong, float giaBan, float doanhThu, float km)
        {
            NgayLap = ngayLap;
            MaSP = maSP;
            TenSP = tenSP;
            NgayLapAsFloat = (float)(NgayLap - DateTime.MinValue).TotalDays;
            ThuTrongTuan = (float)NgayLap.DayOfWeek;
            SoLuong = soLuong;
            GiaBan = giaBan;
            DoanhThu = doanhThu;
            KhuyenMai = km;

        }
    }
}
