using DTO;
using System;
using System.Collections.Generic;
using System.Linq;

namespace DAL
{
    public class NhaCungCapDAL
    {
        DB_SieuThiDataContext db;
        public NhaCungCapDAL()
        {
            db = new DB_SieuThiDataContext();
        }
        public List<NhaCungCapDTO> layTatCaNhaCungCap()
        {
            return db.NhaCungCaps.Select(ncc => new NhaCungCapDTO
            {
                MaNCC = ncc.MaNCC.Trim(),
                TenNCC = ncc.TenNCC,
                SDT = ncc.SDT,
                Email = ncc.Email,
                DiaChi = ncc.DiaChi,
                Website = ncc.Website
            }).ToList();
        }
        public NhaCungCapDTO laySDTNhaCungCap(string sdt)
        {
            NhaCungCapDTO nhaCungCap = db.NhaCungCaps
                       .Where(n => n.SDT == sdt)
                       .Select(n => new NhaCungCapDTO
                       {
                           MaNCC = n.MaNCC.Trim(),
                           TenNCC = n.TenNCC,
                           SDT = n.SDT,
                           DiaChi = n.DiaChi,
                           // Thêm các thuộc tính khác nếu có
                       })
                       .FirstOrDefault();

            return nhaCungCap;
        }

        public NhaCungCapDTO layNhaCungCapTheoMa(string maNCC)
        {
            return db.NhaCungCaps
                     .Where(ncc => ncc.MaNCC == maNCC)
                     .Select(ncc => new NhaCungCapDTO
                     {
                         MaNCC = ncc.MaNCC,
                         TenNCC = ncc.TenNCC,
                         SDT = ncc.SDT,
                         Email = ncc.Email,
                         DiaChi = ncc.DiaChi,
                         Website = ncc.Website
                     })
                     .FirstOrDefault();
        }

        public string taoMaNhaCungCapMoi()
        {
            // Lấy mã nhà cung cấp cuối cùng từ cơ sở dữ liệu và sắp xếp theo mã
            var lastNCC = db.NhaCungCaps
                            .OrderByDescending(n => n.MaNCC)
                            .Select(n => n.MaNCC)
                            .FirstOrDefault();

            int newNumber = 1; // Khởi tạo số mới nếu không có nhà cung cấp nào

            if (!string.IsNullOrEmpty(lastNCC) && lastNCC.Length > 3)
            {
                // Tách phần số ra khỏi mã (bỏ tiền tố "NCC")
                string numberPart = lastNCC.Substring(3);
                if (int.TryParse(numberPart, out int lastNumber))
                {
                    newNumber = lastNumber + 1;
                }
            }

            // Tạo mã mới với tiền tố "NCC" và phần số tăng lên
            return $"NCC{newNumber:D3}"; // Định dạng D3 để phần số luôn có 3 chữ số (ví dụ: NCC001)
        }

        public int themNhaCungCap(NhaCungCapDTO nd)
        {
            try
            {
                NhaCungCap ncc = new NhaCungCap()
                {
                    MaNCC = taoMaNhaCungCapMoi(),
                    TenNCC = nd.TenNCC,
                    Email = nd.Email,
                    DiaChi = nd.DiaChi,
                    SDT = nd.SDT,
                    Website = nd.Website
                };

                db.NhaCungCaps.InsertOnSubmit(ncc);
                db.SubmitChanges();
                return 1;
            }
            catch (Exception ex)
            {
                return 0;
            }
        }


        public int xoaNhaCungCap(string maNCC)
        {
            try
            {
                NhaCungCap ncc = db.NhaCungCaps.FirstOrDefault(n => n.MaNCC == maNCC);
                db.NhaCungCaps.DeleteOnSubmit(ncc);
                db.SubmitChanges();
                return 1;
            }
            catch (Exception ex)
            {
                return 0;
            }
        }


        public int suaNhaCungCap(NhaCungCapDTO nd)
        {
            try
            {
                NhaCungCap ncc = db.NhaCungCaps.FirstOrDefault(n => n.MaNCC == nd.MaNCC);
                ncc.TenNCC = nd.TenNCC;
                ncc.Email = nd.Email;
                ncc.DiaChi = nd.DiaChi;
                ncc.SDT = nd.SDT;
                ncc.Website = nd.Website;

                db.SubmitChanges();
                return 1;
            }
            catch (Exception ex)
            {
                return 0;
            }
        }

        public bool kiemTraSDTTonTai(string sdt)
        {
            return db.NhaCungCaps.Any(n => n.SDT == sdt);
        }

    }
}
