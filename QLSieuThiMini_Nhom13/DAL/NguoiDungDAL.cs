using DTO;
using System.Data;

namespace DAL
{
    public class NguoiDungDAL
    {

        QlSieuThi_DataSetTableAdapters.NguoiDungTableAdapter adapNguoiDung;

        public NguoiDungDAL()
        {
            adapNguoiDung = new QlSieuThi_DataSetTableAdapters.NguoiDungTableAdapter();
            adapNguoiDung.Connection.ConnectionString = Settings1.Default.ChuoiKN;
        }

        //public DataTable dangNhap(string tenTK)
        //{
        //    return adapNguoiDung.dangNhap(tenTK);
        //}

        public DataTable dangNhap(string tenTK, string password)
        {
            return adapNguoiDung.dangNhap(tenTK, password);
        }

        public int doiMatKhau(string tenTK, string matKhauCu, string matkhauMoi)
        {
            return adapNguoiDung.DoiMatKhau(matkhauMoi, tenTK, matKhauCu);
        }

        public DataTable layTatCaNguoiDung()
        {
            return adapNguoiDung.GetData();
        }

        public DataTable layNDConHoatDongVaKoCoTrongNhom(string maNhom)
        {
            return adapNguoiDung.layNDConHoatDongKoThuocNhom(maNhom);
        }

        public DataTable layMotNguoiDung(string tenND)
        {
            return adapNguoiDung.layMotNguoiDung(tenND);
        }

        public int? kiemTraNguoiDungTonTai(NguoiDungDTO nd)
        {
            return adapNguoiDung.kiemTraNguoiDungTonTai(nd.TenTK);
        }

        public int themNguoiDung(NguoiDungDTO nd)
        {
            if (kiemTraNguoiDungTonTai(nd) > 0)
                return 0;
            return adapNguoiDung.themNguoiDung(nd.MaND, nd.TenTK, nd.TenND, nd.MatKhau, nd.HoatDong);
        }

        public int xoaNguoiDung(NguoiDungDTO nd)
        {
            if (kiemTraNguoiDungTonTai(nd) == 0)
                return 0;
            return adapNguoiDung.xoaNguoiDung(nd.MaND);
        }

        public int suaNguoiDung(NguoiDungDTO nd)
        {
            if (kiemTraNguoiDungTonTai(nd) == 0)
                return 0;
            return adapNguoiDung.suaNguoiDung(nd.TenTK, nd.TenND, nd.MatKhau, nd.HoatDong, nd.MaND);
        }

    }
}
