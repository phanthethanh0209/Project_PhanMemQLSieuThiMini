using DAL;
using DTO;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BUL
{
    public class LoaiSanPhamBUL
    {
        LoaiSanPhamDAL loaiSPDAL = new LoaiSanPhamDAL();
        public List<LoaiSanPhamDTO> listLoaiSP = new List<LoaiSanPhamDTO>();

        public List<LoaiSanPhamDTO> LayTatCaLoaiSP()
        {
            listLoaiSP = new List<LoaiSanPhamDTO>();
            DataTable table = loaiSPDAL.LayTatCaLoaiSP();
            foreach (DataRow row in table.Rows)
            {
                LoaiSanPhamDTO dto;
                string maLoai = row["MaLoai"].ToString().Trim();
                string tenLoai = row["TenLoai"].ToString().Trim();
                dto = new LoaiSanPhamDTO(maLoai, tenLoai);
                listLoaiSP.Add(dto);
            }
            return listLoaiSP;
        }

        public LoaiSanPhamDTO LayThongTinMotLoai(string maLoaii)
        {
            listLoaiSP = new List<LoaiSanPhamDTO>();
            DataTable table = loaiSPDAL.LayThongTinMotLoai(maLoaii);
            LoaiSanPhamDTO dto= new LoaiSanPhamDTO();
            foreach (DataRow row in table.Rows)
            {
                string maLoai = row["MaLoai"].ToString().Trim();
                string tenLoai = row["TenLoai"].ToString().Trim();
                dto = new LoaiSanPhamDTO(maLoai, tenLoai);  
            }
            return dto;
        }

        public bool ThemLoaiSP(LoaiSanPhamDTO lsp)
        {
            return loaiSPDAL.Insert(lsp) == 1;
        }

        public bool XoaLoaiSP(LoaiSanPhamDTO lsp)
        {
            return loaiSPDAL.Delete(lsp) == 1;
        }

        public bool SuaLoaiSP(LoaiSanPhamDTO lsp)
        {
            return loaiSPDAL.Update(lsp) == 1;
        }
    }
}
