using DAL;
using DTO;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Security.Cryptography;
using System.Text;

namespace BUL
{
    public class NguoiDungBUL
    {
        NguoiDungDAL nguoidungDAL = new NguoiDungDAL();
        public List<NguoiDungDTO> layTatCaNguoiDung()
        {
            List<NguoiDungDTO> lst = new List<NguoiDungDTO>();
            DataTable table = nguoidungDAL.layTatCaNguoiDung();
            foreach (DataRow row in table.Rows)
            {
                NguoiDungDTO dto;
                string maND = row["MaND"].ToString().Trim();
                string tenTK = row["TenTK"].ToString().Trim();
                string tenND = row["TenND"].ToString().Trim();
                string matKhau = row["MatKhau"].ToString().Trim();
                int hoatDong = int.Parse(row[4].ToString());
                dto = new NguoiDungDTO(maND, tenTK, tenND, matKhau, hoatDong);
                lst.Add(dto);
            }
            return lst;
        }

        public List<NguoiDungDTO> layNDConHoatDongVaKoCoTrongNhom(string maNhom)
        {
            List<NguoiDungDTO> lst = new List<NguoiDungDTO>();
            DataTable table = nguoidungDAL.layNDConHoatDongVaKoCoTrongNhom(maNhom);
            foreach (DataRow row in table.Rows)
            {
                NguoiDungDTO dto;
                string maND = row["MaND"].ToString().Trim();
                string tenTK = row["TenTK"].ToString().Trim();
                string tenND = row["TenND"].ToString().Trim();
                dto = new NguoiDungDTO(maND, tenTK, tenND);
                lst.Add(dto);
            }
            return lst;
        }

        public NguoiDungDTO layMotNguoiDung(string mand)
        {
            NguoiDungDTO dto = new NguoiDungDTO();
            DataTable table = nguoidungDAL.layMotNguoiDung(mand);
            foreach (DataRow row in table.Rows)
            {
                string maND = row["MaND"].ToString().Trim();
                string tenTK = row["TenTK"].ToString().Trim();
                string tenND = row["TenND"].ToString().Trim();
                string matKhau = row["MatKhau"].ToString().Trim();
                int hoatDong = int.Parse(row[4].ToString());
                dto = new NguoiDungDTO(maND, tenTK, tenND, matKhau, hoatDong);
            }
            return dto;
        }

        //public NguoiDungDTO dangNhap(string tentk, string password)
        //{

        //    NguoiDungDTO dto = new NguoiDungDTO();
        //    DataTable table = nguoidungDAL.dangNhap(tentk, password);
        //    if (table.Rows.Count > 0)
        //    {
        //        DataRow row = table.Rows[0];
        //        string maND = row["MaND"].ToString().Trim();
        //        string tenTK = row["TenTK"].ToString().Trim();
        //        string tenND = row["TenND"].ToString().Trim();
        //        string matKhau = row["MatKhau"].ToString().Trim();
        //        int hoatDong = int.Parse(row["HoatDong"].ToString());
        //        dto = new NguoiDungDTO(maND, tenTK, tenND, matKhau, hoatDong);
        //    }
        //    return dto;
        //}

        //public bool VerifyPassword(string enteredPassword, string hashedPassword)
        //{
        //    return BCrypt.Net.BCrypt.Verify(enteredPassword, hashedPassword);
        //}

        public bool VerifyPassword(string inputPassword, string storedHashedPassword)
        {
            byte[] storedHash = Convert.FromBase64String(storedHashedPassword);
            byte[] salt = new byte[16];
            Array.Copy(storedHash, storedHash.Length - 16, salt, 0, 16);

            using (SHA256 sha256 = SHA256.Create())
            {
                byte[] inputPasswordBytes = Encoding.UTF8.GetBytes(inputPassword);
                byte[] saltedInputPassword = inputPasswordBytes.Concat(salt).ToArray();
                byte[] inputHash = sha256.ComputeHash(saltedInputPassword);

                // So sánh hash đã tính toán với hash đã lưu
                return storedHash.Take(32).SequenceEqual(inputHash);
            }
        }


        //public NguoiDungDTO dangNhap(string tenTK, string password)
        //{

        //    // Lấy người dùng từ cơ sở dữ liệu dựa trên tên tài khoản
        //    DataTable table = nguoidungDAL.dangNhap(tenTK);

        //    if (table.Rows.Count > 0)
        //    {
        //        DataRow row = table.Rows[0];
        //        string hashedPassword = row["MatKhau"].ToString().Trim(); // Lấy mật khẩu đã mã hóa từ DB

        //        // Xác thực mật khẩu
        //        if (VerifyPassword(password, hashedPassword))
        //        {
        //            // Nếu mật khẩu đúng, tạo DTO người dùng
        //            string maND = row["MaND"].ToString().Trim();
        //            string tenND = row["TenND"].ToString().Trim();
        //            int hoatDong = int.Parse(row["HoatDong"].ToString());

        //            return new NguoiDungDTO(maND, tenTK, tenND, hashedPassword, hoatDong);
        //        }
        //    }

        //    // Trả về null nếu không khớp
        //    return null;
        //}


        public NguoiDungDTO dangNhap(string tenTK, string password)
        {

            // Lấy người dùng từ cơ sở dữ liệu dựa trên tên tài khoản
            DataTable table = nguoidungDAL.dangNhap(tenTK, password);

            if (table.Rows.Count > 0)
            {
                DataRow row = table.Rows[0];
                string hashedPassword = row["MatKhau"].ToString().Trim(); // Lấy mật khẩu đã mã hóa từ DB

                // Nếu mật khẩu đúng, tạo DTO người dùng
                string maND = row["MaND"].ToString().Trim();
                string tenND = row["TenND"].ToString().Trim();
                int hoatDong = int.Parse(row["HoatDong"].ToString());

                return new NguoiDungDTO(maND, tenTK, tenND, hashedPassword, hoatDong);

            }

            // Trả về null nếu không khớp
            return null;
        }

        public bool doiMatKhau(string tenTK, string matKhauCu, string matKhauMoi)
        {
            return nguoidungDAL.doiMatKhau(tenTK, matKhauCu, matKhauMoi) == 1;
        }

        public bool themNguoiDung(NguoiDungDTO nguoidung)
        {
            return nguoidungDAL.themNguoiDung(nguoidung) == 1;
        }

        public bool xoaNguoiDung(NguoiDungDTO nguoidung)
        {
            return nguoidungDAL.xoaNguoiDung(nguoidung) == 1;
        }

        public bool suaNguoiDung(NguoiDungDTO nguoidung)
        {
            return nguoidungDAL.suaNguoiDung(nguoidung) == 1;
        }
    }
}
