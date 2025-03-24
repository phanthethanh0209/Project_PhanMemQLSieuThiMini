using DAL;
using DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BUL
{
    public class ThuongHieuBUL
    {
        ThuongHieuDAL dal;
        public ThuongHieuBUL()
        {
            dal = new ThuongHieuDAL();
        }

        public List<ThuongHieuDTO> LayTatCaThuongHieu()
        {
            return dal.LayTatCaThuongHieu();
        }

        public ThuongHieuDTO LayThongTinMotThuongHieu(string maTH)
        {
            return dal.LayThongTinMotThuongHieu(maTH);
        }

        public bool ThemThuongHieu(ThuongHieuDTO th)
        {
            return dal.ThemThuongHieu(th) == 1;
        }

        public bool SuaThuongHieu(ThuongHieuDTO th)
        {
            return dal.SuaThuongHieu(th) == 1;
        }

        public bool XoaThuongHieu(ThuongHieuDTO th)
        {
            return dal.XoaThuongHieu(th) == 1;
        }
    }
}
