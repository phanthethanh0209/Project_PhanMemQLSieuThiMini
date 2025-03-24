using DTO;
using System;
using System.Collections.Generic;
using System.Data;

namespace DAL
{
    public class ManHinhDAL
    {
        QlSieuThi_DataSetTableAdapters.DM_ManHinhTableAdapter adapManHinh;

        public ManHinhDAL()
        {
            adapManHinh = new QlSieuThi_DataSetTableAdapters.DM_ManHinhTableAdapter();
            adapManHinh.Connection.ConnectionString = Settings1.Default.ChuoiKN;
        }

        public DataTable LayTatCaManHinh()
        {
            return adapManHinh.GetData();
        }
        public int? kiemTraManHinhTonTai(ManHinhDTO mh)
        {
            return adapManHinh.kiemTraManHinhTonTai(mh.maMH);
        }

        public int Insert(ManHinhDTO mh)
        {
            try
            {
                // Lấy mã màn hình lớn nhất
                DataTable dt = adapManHinh.LayMaManHinhLonNhat();

                string maxMaMH = null;
                if (dt.Rows.Count > 0)
                {
                    maxMaMH = dt.Rows[0][0]?.ToString();
                }

                // Sinh mã mới
                string newMaMH;
                if (!string.IsNullOrEmpty(maxMaMH) && int.TryParse(maxMaMH.Substring(2), out int numericPart))
                {
                    newMaMH = "MH" + (numericPart + 1).ToString("D3");
                }
                else
                {
                    newMaMH = "MH001";
                }

                string a = newMaMH;
                // Thực hiện thêm
                int result = adapManHinh.Insert(a, mh.tenMH);
                if (result == 0)
                {
                    throw new Exception("Insert operation failed.");
                }
                return result;
            }
            catch (Exception ex)
            {
                // Ghi log lỗi
                Console.WriteLine($"Error: {ex.Message}");
                return 0;
            }
        }




        public int Delete(ManHinhDTO mh)
        {
            if (kiemTraManHinhTonTai(mh) == 0)
                return 0;
            return adapManHinh.XoaManHinh(mh.maMH);
        }

        public int Update(ManHinhDTO mh)
        {
            if (kiemTraManHinhTonTai(mh) == 0)
                return 0;
            return adapManHinh.CapNhatManHinh(mh.tenMH, mh.maMH);
        }
    }
}
