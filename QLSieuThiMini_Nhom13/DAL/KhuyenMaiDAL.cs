using DTO;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;

namespace DAL
{
    public class KhuyenMaiDAL
    {
        DB_SieuThiDataContext db;

        public KhuyenMaiDAL()
        {
            db = new DB_SieuThiDataContext();
        }

        //Load lên dgv theo combobox trong frmND_NhomND
        public List<KhuyenMaiDTO> layTatCaKhuyenMai()
        {
            return db.KhuyenMais.Select(km => new KhuyenMaiDTO
            {
                MaKM = km.MaKM,
                TenKM = km.TenKM,
                MaNhomSPMua= km.MaNhomSPMua,
                MaNhomSPTang= km.MaNhomSPTang,
                NgayBD = km.NgayBD,
                NgayKT = km.NgayKT,
                SLMua= km.SLMua,
                SLTang= km.SLTang.HasValue ? km.SLTang.Value : 0,
                GiaGiam = km.GiaGiam,
                DonViGiam= km.DonViGiam
            }).ToList();
        }

        public List<KhuyenMaiDTO> layTatCaKhuyenMaiTheoNgay(DateTime ngayBD, DateTime ngayKT)
        {
            return db.KhuyenMais
                     .Where(km => km.NgayBD >= ngayBD && km.NgayKT <= ngayKT)
                     .Select(km => new KhuyenMaiDTO
                     {
                         MaKM = km.MaKM,
                         TenKM = km.TenKM,
                         MaNhomSPMua = km.MaNhomSPMua,
                         MaNhomSPTang = km.MaNhomSPTang,
                         NgayBD = km.NgayBD,
                         NgayKT = km.NgayKT,
                         SLMua = km.SLMua,
                         SLTang = km.SLTang.HasValue ? km.SLTang.Value : 0,
                         GiaGiam = km.GiaGiam,
                         DonViGiam = km.DonViGiam
                     })
                     .ToList();
        }

        public List<KhuyenMaiDTO> timKiemKhuyenMai(string search)
        {
            return db.KhuyenMais
                     .Where(km => km.MaKM.Contains(search) ||
                                  km.TenKM.Contains(search))
                     .Select(km => new KhuyenMaiDTO
                     {
                         MaKM = km.MaKM,
                         TenKM = km.TenKM,
                         MaNhomSPMua = km.MaNhomSPMua,
                         MaNhomSPTang = km.MaNhomSPTang,
                         NgayBD = km.NgayBD,
                         NgayKT = km.NgayKT,
                         SLMua = km.SLMua,
                         SLTang = km.SLTang.HasValue ? km.SLTang.Value : 0,
                         GiaGiam = km.GiaGiam,
                         DonViGiam = km.DonViGiam
                     })
                     .ToList();
        }


        public string layMaKMCuoiCung()
        {
            return db.KhuyenMais
                     .Where(km => km.MaKM.StartsWith("KM"))
                     .OrderByDescending(km => km.MaKM)    
                     .Select(km => km.MaKM)               
                     .FirstOrDefault();                 
        }


        public KhuyenMaiDTO layKhuyenMaiTheoMaKM(string maKM)
        {
            return db.KhuyenMais
                     .Where(km => km.MaKM == maKM)
                     .Select(km => new KhuyenMaiDTO
                     {
                         MaKM = km.MaKM,
                         TenKM = km.TenKM,
                         MaNhomSPMua = km.MaNhomSPMua,
                         MaNhomSPTang = km.MaNhomSPTang,
                         NgayBD = km.NgayBD,
                         NgayKT = km.NgayKT,
                         SLMua = km.SLMua,
                         SLTang = km.SLTang.HasValue ? km.SLTang.Value : 0,
                         GiaGiam = km.GiaGiam,
                         DonViGiam = km.DonViGiam
                     })
                     .FirstOrDefault();
        }

        //Khuyến mãi của sp đó
        public KhuyenMaiDTO layKMCuaSanPham(string maSP)
        {
            var query = from km in db.KhuyenMais
                        join nsp in db.NhomSanPhamKMs on km.MaNhomSPMua equals nsp.MaNhomSP
                        join ct in db.CTNhomSanPhamKMs on nsp.MaNhomSP equals ct.MaNhomSP
                        where ct.MaSP == maSP
                              && DateTime.Now >= km.NgayBD
                              && DateTime.Now <= km.NgayKT
                        select new KhuyenMaiDTO
                        {
                            MaKM = km.MaKM,
                            TenKM = km.TenKM,
                            MaNhomSPMua = km.MaNhomSPMua,
                            MaNhomSPTang = km.MaNhomSPTang,
                            NgayBD = km.NgayBD,
                            NgayKT = km.NgayKT,
                            SLMua = km.SLMua,
                            SLTang = km.SLTang.HasValue ? km.SLTang.Value : 0,
                            GiaGiam = km.GiaGiam,
                            DonViGiam = km.DonViGiam
                        };

            return query.FirstOrDefault();
        }




        public int themKhuyenMai(KhuyenMaiDTO km)
        {
            try
            {
                KhuyenMai ncc = new KhuyenMai()
                {
                    MaKM = km.MaKM,
                    TenKM = km.TenKM,
                    MaNhomSPMua= km.MaNhomSPMua,
                    MaNhomSPTang= km.MaNhomSPTang,                   
                    NgayBD = km.NgayBD,
                    NgayKT = km.NgayKT,
                    SLMua= km.SLMua,
                    SLTang= km.SLTang,
                    GiaGiam= km.GiaGiam,
                    DonViGiam = km.DonViGiam
                };

                db.KhuyenMais.InsertOnSubmit(ncc);
                db.SubmitChanges();

                return 1;
            }
            catch (Exception ex)
            {
                return 0;
            }
        }

        public int suaKhuyenMai(KhuyenMaiDTO km)
        {
            try
            {
                KhuyenMai khuyenmai = db.KhuyenMais.FirstOrDefault(n => n.MaKM == km.MaKM);
                khuyenmai.TenKM = km.TenKM;
                khuyenmai.MaNhomSPMua = km.MaNhomSPMua;
                khuyenmai.MaNhomSPTang = km.MaNhomSPTang;
                khuyenmai.NgayBD = km.NgayBD;
                khuyenmai.NgayKT = km.NgayKT;
                khuyenmai.SLMua = km.SLMua;
                khuyenmai.SLTang = km.SLTang;
                khuyenmai.GiaGiam = km.GiaGiam;
                khuyenmai.DonViGiam = km.DonViGiam;

                db.SubmitChanges();
                return 1;
            }
            catch (Exception ex)
            {
                return 0;
            }
        }

        public int xoaKhuyenMai(string makm)
        {
            try
            {
                KhuyenMai khuyenmai = db.KhuyenMais.FirstOrDefault(n => n.MaKM == makm);
                db.KhuyenMais.DeleteOnSubmit(khuyenmai);
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
