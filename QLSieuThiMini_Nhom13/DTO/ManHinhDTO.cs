namespace DTO
{
    public class ManHinhDTO
    {
        public string maMH { get; set; }
        public string tenMH { get; set; }

        public ManHinhDTO()
        {
            maMH = string.Empty;
            tenMH = string.Empty;
        }

        public ManHinhDTO(string maMH, string tenMH)
        {
            this.maMH = maMH;
            this.tenMH = tenMH;
        }

    }
}
