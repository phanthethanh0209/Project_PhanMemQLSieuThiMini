using DTO;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL
{
    public class LoaiSanPhamDAL
    {
        QlSieuThi_DataSetTableAdapters.LoaiSanPhamTableAdapter adapterLoaiSP;

        public LoaiSanPhamDAL()
        {
            adapterLoaiSP = new QlSieuThi_DataSetTableAdapters.LoaiSanPhamTableAdapter();
            adapterLoaiSP.Connection.ConnectionString = Settings1.Default.ChuoiKN;
        }

        public DataTable LayTatCaLoaiSP()
        {
            return adapterLoaiSP.GetData();
        }

        public DataTable LayThongTinMotLoai(string maLoai)
        {
            return adapterLoaiSP.LayThongTin1Loai(maLoai);
        }

        public int? kiemTraLoaiSPTonTai(LoaiSanPhamDTO lsp)
        {
            return adapterLoaiSP.KiemTraTonTaiLoaiSP(TaoMaLoaiSPMoi());
        }

        public int Insert(LoaiSanPhamDTO lsp)
        {
            if (kiemTraLoaiSPTonTai(lsp) > 0)
                return 0;
            return adapterLoaiSP.ThemLoaiSP(TaoMaLoaiSPMoi(), lsp.tenLoai);
        }

        public int Delete(LoaiSanPhamDTO lsp)
        {
            return adapterLoaiSP.XoaLoaiSP(lsp.maLoai);
        }

        public int Update(LoaiSanPhamDTO lsp)
        {
            return adapterLoaiSP.CapNhatLoaiSP(lsp.tenLoai, lsp.maLoai);
        }

        public string TaoMaLoaiSPMoi()
        {
            DataTable table = LayTatCaLoaiSP();

            int maxValue = 0;

            foreach (DataRow row in table.Rows)
            {
                string maLoai = row["MaLoai"].ToString().Trim();
                string numberPart = maLoai.Substring(3);

                if (int.TryParse(numberPart, out int value))
                {
                    if (value > maxValue)
                        maxValue = value;
                }
            }

            int newValue = maxValue + 1;
            return $"LSP{newValue:000}";
        }
    }
}
