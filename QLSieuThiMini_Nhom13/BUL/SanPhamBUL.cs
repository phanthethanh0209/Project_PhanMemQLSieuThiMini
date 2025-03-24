using DAL;
using DTO;
using System;
using System.Collections.Generic;
using System.Data;

namespace BUL
{
    public class SanPhamBUL
    {
        SanPhamDAL dal;
        public SanPhamBUL()
        {
            dal = new SanPhamDAL();
        }

        public List<SanPhamDTO> layDSSanPham()
        {
            List<SanPhamDTO> lst = new List<SanPhamDTO>();
            DataTable table = dal.layDSSanPham();
            foreach (DataRow row in table.Rows)
            {
                SanPhamDTO dto;
                string maSP = row["MaSP"].ToString();
                string tenSP = row["TenSP"].ToString();
                double giaBan = double.Parse(row["GiaBan"].ToString());
                double giaNhap = double.Parse(row["GiaNhap"].ToString());
                int slTon = int.Parse(row["SLTon"].ToString());
                DateTime ngaySX = DateTime.Parse(row["NgaySX"].ToString());
                DateTime hsd = DateTime.Parse(row["HSD"].ToString());
                double kichCo = double.Parse(row["KichCo"].ToString());
                string mauSac = row["MauSac"].ToString();
                string maLoai = row["MaLoai"].ToString();
                string maTH = row["MaTH"].ToString();
                string hinhAnh = row["HinhAnh"].ToString();
                dto = new SanPhamDTO(maSP, tenSP, giaBan, giaNhap, slTon, ngaySX, hsd, kichCo, mauSac, maLoai, maTH, hinhAnh);
                lst.Add(dto);
            }
            return lst;
        }



        public List<SanPhamDTO> layDSSanPhamKemKhuyenMaiTheoNgayDuDoan(string ngay)
        {
            List<SanPhamDTO> lst = new List<SanPhamDTO>();
            DataTable table = dal.layDSSanPhamKemKhuyenMaiTheoNgayDuDoan(ngay);
            foreach (DataRow row in table.Rows)
            {
                SanPhamDTO dto;
                string maSP = row["MaSP"].ToString();
                string tenSP = row["TenSP"].ToString();
                double giaBan = double.Parse(row["GiaBan"].ToString());
                int km = int.Parse(row["KhuyenMai"].ToString());

                dto = new SanPhamDTO(maSP, tenSP, giaBan, km);
                lst.Add(dto);
            }
            return lst;
        }



        public List<SanPhamDTO> layDSSanPhamTheoTenHoacMa(string text)
        {
            List<SanPhamDTO> lst = new List<SanPhamDTO>();
            DataTable table = dal.layDSSanPhamTheoTenHoacMa(text);
            foreach (DataRow row in table.Rows)
            {
                SanPhamDTO dto;
                string maSP = row["MaSP"].ToString();
                string tenSP = row["TenSP"].ToString();
                double giaBan = double.Parse(row["GiaBan"].ToString());
                double giaNhap = double.Parse(row["GiaNhap"].ToString());
                int slTon = int.Parse(row["SLTon"].ToString());
                DateTime ngaySX = DateTime.Parse(row["NgaySX"].ToString());
                DateTime hsd = DateTime.Parse(row["HSD"].ToString());
                double kichCo = double.Parse(row["KichCo"].ToString());
                string mauSac = row["MauSac"].ToString();
                string maLoai = row["MaLoai"].ToString();
                string maTH = row["MaTH"].ToString();
                string hinhAnh = row["HinhAnh"].ToString();
                dto = new SanPhamDTO(maSP, tenSP, giaBan, giaNhap, slTon, ngaySX, hsd, kichCo, mauSac, maLoai, maTH, hinhAnh);
                lst.Add(dto);
            }
            return lst;
        }

        public List<SanPhamDTO> layDSSanPhamTheoLoai(string maLoaii)
        {
            List<SanPhamDTO> lst = new List<SanPhamDTO>();
            DataTable table = dal.layDSSanPhamTheoLoai(maLoaii);
            foreach (DataRow row in table.Rows)
            {
                SanPhamDTO dto;
                string maSP = row["MaSP"].ToString();
                string tenSP = row["TenSP"].ToString();
                double giaBan = double.Parse(row["GiaBan"].ToString());
                double giaNhap = double.Parse(row["GiaNhap"].ToString());
                int slTon = int.Parse(row["SLTon"].ToString());
                DateTime ngaySX = DateTime.Parse(row["NgaySX"].ToString());
                DateTime hsd = DateTime.Parse(row["HSD"].ToString());
                double kichCo = double.Parse(row["KichCo"].ToString());
                string mauSac = row["MauSac"].ToString();
                string maLoai = row["MaLoai"].ToString();
                string maTH = row["MaTH"].ToString();
                string hinhAnh = row["HinhAnh"].ToString();
                dto = new SanPhamDTO(maSP, tenSP, giaBan, giaNhap, slTon, ngaySX, hsd, kichCo, mauSac, maLoai, maTH, hinhAnh);
                lst.Add(dto);
            }
            return lst;
        }



        public List<SanPhamDTO> layDSSanPhamTheoThuongHieu(string maTHH)
        {
            List<SanPhamDTO> lst = new List<SanPhamDTO>();
            DataTable table = dal.layDSSanPhamTheoThuongHieu(maTHH);
            foreach (DataRow row in table.Rows)
            {
                SanPhamDTO dto;
                string maSP = row["MaSP"].ToString();
                string tenSP = row["TenSP"].ToString();
                double giaBan = double.Parse(row["GiaBan"].ToString());
                double giaNhap = double.Parse(row["GiaNhap"].ToString());
                int slTon = int.Parse(row["SLTon"].ToString());
                DateTime ngaySX = DateTime.Parse(row["NgaySX"].ToString());
                DateTime hsd = DateTime.Parse(row["HSD"].ToString());
                double kichCo = double.Parse(row["KichCo"].ToString());
                string mauSac = row["MauSac"].ToString();
                string maLoai = row["MaLoai"].ToString();
                string maTH = row["MaTH"].ToString();
                string hinhAnh = row["HinhAnh"].ToString();
                dto = new SanPhamDTO(maSP, tenSP, giaBan, giaNhap, slTon, ngaySX, hsd, kichCo, mauSac, maLoai, maTH, hinhAnh);
                lst.Add(dto);
            }
            return lst;
        }


        public List<SanPhamDTO> timKiemSPTheoMaHoacTen(string search)
        {
            List<SanPhamDTO> lst = new List<SanPhamDTO>();
            DataTable table = dal.timKiemSPTheoMaHoacTen(search);
            foreach (DataRow row in table.Rows)
            {
                SanPhamDTO dto;
                string maSP = row["MaSP"].ToString();
                string tenSP = row["TenSP"].ToString();
                double giaBan = double.Parse(row["GiaBan"].ToString());
                double giaNhap = double.Parse(row["GiaNhap"].ToString());
                int slTon = int.Parse(row["SLTon"].ToString());
                DateTime ngaySX = DateTime.Parse(row["NgaySX"].ToString());
                DateTime hsd = DateTime.Parse(row["HSD"].ToString());
                double kichCo = double.Parse(row["KichCo"].ToString());
                string mauSac = row["MauSac"].ToString();
                string maLoai = row["MaLoai"].ToString();
                string maTH = row["MaTH"].ToString();
                string hinhAnh = row["HinhAnh"].ToString();
                dto = new SanPhamDTO(maSP, tenSP, giaBan, giaNhap, slTon, ngaySX, hsd, kichCo, mauSac, maLoai, maTH, hinhAnh);
                lst.Add(dto);
            }
            return lst;
        }



        public SanPhamDTO layMotSanPham(string ma)
        {
            DataTable table = dal.layMotSanPham(ma);
            SanPhamDTO dto = null;
            foreach (DataRow row in table.Rows)
            {
                string maSP = row["MaSP"].ToString();
                string tenSP = row["TenSP"].ToString();
                double giaBan = double.Parse(row["GiaBan"].ToString());
                double giaNhap = double.Parse(row["GiaNhap"].ToString());
                int slTon = int.Parse(row["SLTon"].ToString());
                DateTime ngaySX = DateTime.Parse(row["NgaySX"].ToString());
                DateTime hsd = DateTime.Parse(row["HSD"].ToString());
                double kichCo = double.Parse(row["KichCo"].ToString());
                string mauSac = row["MauSac"].ToString();
                string maLoai = row["MaLoai"].ToString();
                string maTH = row["MaTH"].ToString();
                string hinhAnh = row["HinhAnh"].ToString();
                dto = new SanPhamDTO(maSP, tenSP, giaBan, giaNhap, slTon, ngaySX, hsd, kichCo, mauSac, maLoai, maTH, hinhAnh);
            }
            return dto;
        }


        public string TaoMaSanPham()
        {
            string key = "SP";

            DataTable dt = dal.layMaSPCuoiCung();

            if (dt.Rows.Count == 0)
            {
                key += "001";
            }
            else
            {

                string maBanDau = dt.Rows[0][0].ToString();
                string sott = maBanDau.Substring(2, 3);
                int num = int.Parse(sott) + 1;
                if (num < 10)
                    key += "00" + num;
                else
                {
                    if (num < 100)
                        key += "0" + num;
                    else
                        key += num;
                }
            }
            return key;

        }

        public bool capNhatSLTon(string masp, int slTon)
        {
            return dal.capNhatSLTon(masp, slTon);
        }

        public bool capNhatSLTonChoPN(string masp, int slTon)
        {
            return dal.capNhatSLTonChoPN(masp, slTon);
        }

        public bool themSanPham(SanPhamDTO sp)
        {
            return dal.themSanPham(sp);
        }

        public bool suaSanPham(SanPhamDTO sp)
        {
            return dal.suaSanPham(sp);
        }

        public bool xoaSanPham(SanPhamDTO sp)
        {
            return dal.xoaSanPham(sp);
        }
    }
}
