using DTO;
using System.Data;
using System.Data.SqlClient;

namespace DAL
{
    public class KhachHangDAL
    {
        QlSieuThi_DataSetTableAdapters.KhachHangTableAdapter adapKhachHang = new QlSieuThi_DataSetTableAdapters.KhachHangTableAdapter();

        public KhachHangDAL()
        {
            adapKhachHang.Connection.ConnectionString = Settings1.Default.ChuoiKN;
        }

        public DataTable layTatCaKhachHang()
        {
            return adapKhachHang.GetData();
        }

        public int? kiemTraKhachHangTonTai(KhachHangDTO kh)
        {
            return adapKhachHang.KiemTraKhachHangTonTai(kh.maKH);
        }

        public DataTable layKHTheoMa(string maKH)
        {
            return adapKhachHang.LayKHTheoMa(maKH);
        }

        public int themKhachHang(KhachHangDTO kh)
        {
            if (kiemTraKhachHangTonTai(kh) > 0)
                return 0;
            return adapKhachHang.ThemKhachHang(taoMaKhachHangMoi(), kh.tenKH, kh.sdt, kh.email, kh.diemTichLuy);
        }

        public int xoaKhachHang(KhachHangDTO kh)
        {
            try
            {
                if (kiemTraKhachHangTonTai(kh) == 0)
                    return 0;
                return adapKhachHang.XoaKhachHang(kh.maKH);
            }
            catch (System.Exception)
            {
                return 0;
                throw;
            }
            
        }

        public int suaKhachHang(KhachHangDTO kh)
        {
            try
            {
                if (kiemTraKhachHangTonTai(kh) == 0)
                    return 0;
                return adapKhachHang.CapNhatKhachHang(kh.tenKH, kh.sdt, kh.email, kh.diemTichLuy, kh.maKH);
            }
            catch (System.Exception)
            {
                return 0;
                throw;
            }
            
        }

        public DataTable layMotKHTheoSDT(string sdt)
        {
            return adapKhachHang.layMotKHTheoSDT(sdt);
        }

        public bool kiemTraSDTTonTai(string sdt)
        {
            // Kiểm tra nếu số điện thoại tồn tại trong cơ sở dữ liệu
            var result = adapKhachHang.KiemTraTrungSDT(sdt);
            return result.HasValue && result.Value > 0;
        }

        public string taoMaKhachHangMoi()
        {
            DataTable dt = adapKhachHang.LayMaKhachHangCuoiCung();

            int newNumber = 1;
            string lastMaKH = string.Empty;

            if (dt != null && dt.Rows.Count > 0)
            {
                lastMaKH = dt.Rows[0][0].ToString();
            }

            if (!string.IsNullOrEmpty(lastMaKH) && lastMaKH.Length > 2)
            {
                string numberPart = lastMaKH.Substring(2);
                if (int.TryParse(numberPart, out int lastNumber))
                {
                    newNumber = lastNumber + 1;
                }
            }

            return $"KH{newNumber:D3}";
        }

        public int capNhatDTL(KhachHangDTO kh)
        {
            if (kiemTraKhachHangTonTai(kh) == 0)
                return 0;
            return adapKhachHang.CapNhatDTL(kh.diemTichLuy, kh.maKH);
        }
    }


}
