namespace DTO
{
    public class PhanQuyenDTO
    {
        public string maNhom { get; set; }  
        public string maMH { get; set; }
        public string tenNhom {  get; set; }  
        public string tenMH { get; set; }
        public string ghiChu { get; set; }  

        public PhanQuyenDTO()
        {
            maNhom = string.Empty;
            maMH = string.Empty;
            tenNhom = string.Empty;
            tenMH = string.Empty;
            ghiChu = string.Empty;
        }

        public PhanQuyenDTO(string maNhom, string maMH, string tenNhom, string tenMH, string ghiChu)
        {
            this.maNhom = maNhom;
            this.maMH = maMH;
            this.tenNhom = tenNhom;
            this.tenMH = tenMH;
            this.ghiChu = ghiChu;
        }

    }
}
