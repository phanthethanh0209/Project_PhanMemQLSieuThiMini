using DTO;
using System.Data;

namespace DAL
{
    public class PhanQuyenDAL
    {
        QlSieuThi_DataSetTableAdapters.PhanQuyenTableAdapter adapPhanQuyen;
        QlSieuThi_DataSetTableAdapters.NhomNguoiDungTableAdapter nhomNguoiDung;

        public PhanQuyenDAL()
        {
            adapPhanQuyen = new QlSieuThi_DataSetTableAdapters.PhanQuyenTableAdapter();
            nhomNguoiDung = new QlSieuThi_DataSetTableAdapters.NhomNguoiDungTableAdapter();
            adapPhanQuyen.Connection.ConnectionString = Settings1.Default.ChuoiKN;
            nhomNguoiDung.Connection.ConnectionString = Settings1.Default.ChuoiKN;
        }

        public DataTable LayNhomNguoiDungChuaCoManHinh(string maMH)
        {
            return nhomNguoiDung.layNhomNguoiDungChuaCoManHinh(maMH);
        }

        public DataTable LayNhomNguoiDungCoManHinh(string maMH)
        {
            return nhomNguoiDung.layNhomNguoiDungCoManHinh(maMH);
        }

        public int? kiemTraTonTai(string maNhom, string maMH)
        {
            return adapPhanQuyen.kiemTraNhomNguoiDungTonTai(maNhom, maMH);
        }
        public int themQuyen(PhanQuyenDTO pq)
        {
            //kiểm tra để tránh thêm trùng khóa chính
            if (kiemTraTonTai(pq.maNhom, pq.maMH) > 0)
                return 0;
            return adapPhanQuyen.themQuyen(pq.maNhom, pq.maMH, 1);
        }

        public int xoaQuyen(PhanQuyenDTO pq)
        {
            //kiểm tra để tránh thêm trùng khóa chính
            if (kiemTraTonTai(pq.maNhom, pq.maMH) == 0)
                return 0;
            return adapPhanQuyen.xoaQuyen(pq.maNhom, pq.maMH);
        }

        public DataTable layDSTenManHinh(string maNhom)
        {
            return adapPhanQuyen.layDSTenManHinh(maNhom);
        }

    }
}
