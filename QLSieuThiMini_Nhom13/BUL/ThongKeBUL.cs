using DAL;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BUL
{
    public class ThongKeBUL
    {
        ThongKeDAL dal = new ThongKeDAL();

        public DataTable ThongKeSanPham(string startDate, string endDate, string groupBy)
        {
            DateTime startDateDate = DateTime.Parse(startDate);
            DateTime endDateDate = DateTime.Parse(endDate);
            return dal.ThongKeSanPham(startDateDate, endDateDate, groupBy);
        }

        public DataTable ThongKeKhachHangTheoThoiGian(string startDate, string endDate, string groupBy)
        {
            DateTime startDateDate = DateTime.Parse(startDate);
            DateTime endDateDate = DateTime.Parse(endDate);
            // Truyền tham số xuống lớp DAL để truy vấn dữ liệu từ database
            return dal.ThongKeDoanhThuKhachHang(startDateDate, endDateDate, groupBy);
        }
    }
}
