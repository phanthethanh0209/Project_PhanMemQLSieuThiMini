using DTO;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL
{
    public class ND_NhomNDDAL
    {
        QlSieuThi_DataSetTableAdapters.NguoiDung_NhomNguoiDungTableAdapter adapND_NhomND;

        public ND_NhomNDDAL()
        {
            adapND_NhomND = new QlSieuThi_DataSetTableAdapters.NguoiDung_NhomNguoiDungTableAdapter();
        }

        //Load lên dgv theo combobox trong frmND_NhomND
        public DataTable layNguoiDungTheoMaNhom(string maNhom)
        {
            return adapND_NhomND.layDSNguoiDungTheoMaNhom(maNhom);
        }

        public int? kiemTraTonTai(string maNhom, string maND)
        {
            return adapND_NhomND.kiemTraNguoiDungTonTai(maNhom, maND);
        }
        public int themND_NhomND(ND_NhomNDDTO nd)
        {
            //kiểm tra để tránh thêm trùng khóa chính
            if (kiemTraTonTai(nd.MaNhom, nd.MaND) > 0)
                return 0;
            return adapND_NhomND.themND_NhomND( nd.MaND, nd.MaNhom, nd.GhiChu);
        }

        public int xoaND_NhomND(ND_NhomNDDTO nd)         
        {
            //kiểm tra 
            if (kiemTraTonTai(nd.MaNhom, nd.MaND) == 0)
                return 0;
            return adapND_NhomND.xoaND_NhomND(nd.MaND, nd.MaNhom);
        }

        public DataTable layDSMaNhomTuTenTK(string tenTK)
        {
            DataTable dt = adapND_NhomND.layDSMaNhomTuTenTk(tenTK);

            return dt;
        }

    }
}
