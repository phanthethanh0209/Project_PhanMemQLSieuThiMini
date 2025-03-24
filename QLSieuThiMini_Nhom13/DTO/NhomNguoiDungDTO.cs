namespace DTO
{
    public class NhomNguoiDungDTO
    {
        public string MaNhom { get; set; }
        public string TenNhom { get; set; }
        public string GhiChu { get; set; }

        public NhomNguoiDungDTO(string maNhom, string tenNhom, string ghiChu)
        {
            MaNhom = maNhom;
            TenNhom = tenNhom;
            GhiChu = ghiChu;
        }
    }
}
