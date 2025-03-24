using System.Data;
using DTO;

namespace DAL
{
    public class NhomNguoiDungDAL
    {
        QlSieuThi_DataSetTableAdapters.NhomNguoiDungTableAdapter adapNhomNguoiDung;

        public NhomNguoiDungDAL()
        {
            adapNhomNguoiDung = new QlSieuThi_DataSetTableAdapters.NhomNguoiDungTableAdapter();
        }

        //Load lên combobox trong frmND_NhomND
        public DataTable layTatCaNhomND()
        {
            return adapNhomNguoiDung.GetData();
        }

        public int themNhomND(NhomNguoiDungDTO nhomND)
        {
            return adapNhomNguoiDung.themNhomNguoiDung(nhomND.MaNhom, nhomND.TenNhom, nhomND.GhiChu);
        }

        public int xoaNhomND(NhomNguoiDungDTO nhomND)
        {
            return adapNhomNguoiDung.xoaNhomNguoiDung(nhomND.MaNhom);
        }

        public int suaNhomND(NhomNguoiDungDTO nhomND)
        {
            return adapNhomNguoiDung.suaNhomNguoiDung(nhomND.TenNhom, nhomND.GhiChu, nhomND.MaNhom);
        }
    }
}
