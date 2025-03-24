namespace DTO
{
    public class NguoiDungDTO
    {
        public string MaND { get; set; }
        public string TenTK { get; set; }
        public string TenND { get; set; }
        public string MatKhau { get; set; }
        public int HoatDong { get; set; }

        public NguoiDungDTO()
        {
            HoatDong = 0;
        }

        public NguoiDungDTO(string maND, string tenTK, string tenND, string matKhau, int hoatDong)
        {
            MaND = maND;
            TenTK = tenTK;
            TenND = tenND;
            MatKhau = matKhau;
            //MatKhau = BCrypt.Net.BCrypt.HashPassword(matKhau);

            // Tạo salt ngẫu nhiên
            //byte[] salt = new byte[16];
            //using (RNGCryptoServiceProvider rng = new RNGCryptoServiceProvider())
            //{
            //    rng.GetBytes(salt);
            //}

            //// Mã hóa mật khẩu với salt sử dụng SHA-256
            //using (SHA256 sha256 = SHA256.Create())
            //{
            //    byte[] passwordBytes = Encoding.UTF8.GetBytes(matKhau);
            //    byte[] saltedPassword = passwordBytes.Concat(salt).ToArray();
            //    byte[] hash = sha256.ComputeHash(saltedPassword);

            //    // Gộp hash và salt thành một chuỗi để lưu vào CSDL
            //    MatKhau = Convert.ToBase64String(hash.Concat(salt).ToArray());
            //}

            HoatDong = hoatDong;
        }

        //Hiển thị cho dgv của frm ND_NhomND
        public NguoiDungDTO(string maND, string tenTK, string tenND)
        {
            MaND = maND;
            TenTK = tenTK;
            TenND = tenND;
        }
    }
}
