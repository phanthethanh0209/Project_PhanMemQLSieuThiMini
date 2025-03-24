using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Runtime.InteropServices.ComTypes;
using System.Text;
using System.Threading.Tasks;
using DAL;
using DTO;

namespace BUL
{
    public class ManHinhBUL
    {
        ManHinhDAL manHinhDAL = new ManHinhDAL();
        public List<ManHinhDTO> listManHinh = new List<ManHinhDTO>();
        public string trangThai = "";
        public List<ManHinhDTO> LayTatCaManHinh()
        {
            listManHinh = new List<ManHinhDTO>();
            DataTable table = manHinhDAL.LayTatCaManHinh();
            foreach (DataRow row in table.Rows)
            {
                ManHinhDTO dto;
                string maND = row["MaMH"].ToString().Trim();
                string tenTK = row["TenMH"].ToString().Trim();
                dto = new ManHinhDTO(maND, tenTK);
                listManHinh.Add(dto);

            }
            return listManHinh;
        }

        public bool ThemManHinh(ManHinhDTO mh)
        {
            return manHinhDAL.Insert(mh) == 1;
        }

        public bool XoaManHinh(ManHinhDTO mh)
        {
            return manHinhDAL.Delete(mh) == 1;
        }

        public bool SuaManHinh(ManHinhDTO mh)
        {
            return manHinhDAL.Update(mh) == 1;
        }

    }
}
