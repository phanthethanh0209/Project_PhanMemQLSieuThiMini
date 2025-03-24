using DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL
{
    public class ThuongHieuDAL
    {
        DB_SieuThiDataContext db;

        public ThuongHieuDAL()
        {
            db = new DB_SieuThiDataContext();
        }

        //Load lên dgv theo combobox trong frmND_NhomND
        public List<ThuongHieuDTO> LayTatCaThuongHieu()
        {
            return db.ThuongHIeus.Select(th => new ThuongHieuDTO
            {
                maThuongHieu = th.MaTH,
                tenThuongHieu = th.TenTH,
            }).ToList();
        }

        public ThuongHieuDTO LayThongTinMotThuongHieu(string maThuongHieu)
        {
            return db.ThuongHIeus
             .Where(th => th.MaTH == maThuongHieu)
             .Select(th => new ThuongHieuDTO
             {
                 maThuongHieu = th.MaTH,
                 tenThuongHieu = th.TenTH,
             })
             .FirstOrDefault();
        }

        public int ThemThuongHieu(ThuongHieuDTO th)
        {
            try
            {
                string maxMaTH = db.ThuongHIeus
                                    .OrderByDescending(ad => ad.MaTH)
                                    .Select(ad => ad.MaTH)
                                    .FirstOrDefault();

                string newMaTH;
                if (!string.IsNullOrEmpty(maxMaTH) && int.TryParse(maxMaTH.Substring(2), out int numericPart))
                {
                    newMaTH = "TH" + (numericPart + 1).ToString("D3");
                }
                else
                {
                    newMaTH = "TH001";
                }

                th.maThuongHieu = newMaTH;

                ThuongHIeu th2 = new ThuongHIeu()
                {
                    MaTH = th.maThuongHieu.Trim(),
                    TenTH = th.tenThuongHieu.Trim(),
                };

                db.ThuongHIeus.InsertOnSubmit(th2);
                db.SubmitChanges();
                return 1;
            }
            catch (Exception ex)
            {
                return 0;
            }
        }


        public int SuaThuongHieu(ThuongHieuDTO th)
        {
            try
            {
                ThuongHIeu th2 = db.ThuongHIeus.FirstOrDefault(n => n.MaTH == th.maThuongHieu);
                th2.TenTH = th.tenThuongHieu;

                db.SubmitChanges();
                return 1;
            }
            catch (Exception ex)
            {
                return 0;
            }
        }

        public int XoaThuongHieu(ThuongHieuDTO th)
        {
            try
            {
                ThuongHIeu th2 = db.ThuongHIeus.FirstOrDefault(n => n.MaTH == th.maThuongHieu);
                db.ThuongHIeus.DeleteOnSubmit(th2);
                db.SubmitChanges();
                return 1;
            }
            catch (Exception ex)
            {
                return 0;
            }
        }


    }
}
