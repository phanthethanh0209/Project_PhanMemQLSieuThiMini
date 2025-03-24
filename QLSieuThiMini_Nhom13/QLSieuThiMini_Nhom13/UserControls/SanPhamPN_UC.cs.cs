using BUL;
using System;
using System.Windows.Forms;

namespace QLSieuThiMini_Nhom13.UserControls
{
    public partial class SanPhamPN_UC : UserControl
    {
        public SanPhamPN_UC()
        {
            InitializeComponent();
        }

        SanPhamBUL sanPhamBUL;
        public SanPhamPN_UC(string maSP, string tenSP, double giaSP)
        {
            InitializeComponent();

            sanPhamBUL = new SanPhamBUL();
            MaSP = maSP;
            TenSP = tenSP;
            GiaSP = giaSP;
            //SoTT = soTT;
            //TongTien = tongTien;
            //SoLuong = soLuong;
        }

        private int soTT;
        private int soLuong;
        private double thanhTien;
        private string maSP;
        private string tenSP;
        private double giaSP;

        public string MaSP { get => maSP; set { maSP = value; lbMaSP.Text = maSP; } }
        public string TenSP { get => tenSP; set { tenSP = value; lbTenSP.Text = tenSP; } }
        public double GiaSP { get => giaSP; set { giaSP = value; lbGiaBan.Text = giaSP.ToString("N0") /*+ " VND"*/; } }

        public int SoTT { get => soTT; set { soTT = value; lbSTT.Text = soTT.ToString(); } }


        public double ThanhTien { get => thanhTien; set { thanhTien = value; lbThanhTien.Text = (giaSP * soLuong).ToString("N0"); } }

        private bool isUpdating = false; // Cờ kiểm soát
        public int SoLuong
        {
            get => soLuong; set
            {
                soLuong = value;
                nbSoLuong.Value = soLuong;
                SoLuongCu = soLuong; // Lưu giá trị cũ
                //SanPhamDTO sanPhamDTO = sanPhamBUL.layMotSanPham(maSP);
                //if (sanPhamDTO.SLTon < value)
                //{
                //    soLuong = value - 1;
                //    nbSoLuong.Value = soLuong - 1;
                //}
            }
        }

        private int soLuongCu;

        public int SoLuongCu
        {
            get => soLuongCu;
            private set => soLuongCu = value; // Chỉ cho phép đặt giá trị từ bên trong class
        }

        private int tongSoLuong;

        public int TongSoLuong
        {
            get => tongSoLuong;
            set => tongSoLuong = value; // Chỉ cho phép đặt giá trị từ bên trong class
        }

        public delegate void ClickThayDoiSLHandler(object sender, EventArgs e);
        public event ClickThayDoiSLHandler ClickThayDoiSL;
        protected virtual void OnClickThayDoiSL(object sender, EventArgs e)
        {
            if (ClickThayDoiSL != null) ClickThayDoiSL(sender, e);
        }
        private int previousValue;
        bool flag = true;
        private void numericUpDown1_ValueChanged(object sender, EventArgs e)
        {
            OnClickThayDoiSL(sender, e);
            //if (flag)
            //{
            //    OnClickThayDoiSL(sender, e);
            //    if (maSP.StartsWith("SP"))
            //    {
            //        SanPhamDTO sanPhamDTO = sanPhamBUL.layMotSanPham(maSP);
            //        if (sanPhamDTO.SLTon <= TongSoLuong && flag)
            //        {
            //            flag = false;
            //            nbSoLuong.Value = SoLuongCu;
            //            flag = true;
            //        }
            //        SoLuongCu = soLuong; // Lưu giá trị cũ
            //    }


            //}

        }

        public delegate void ClickXoaHandler(object sender, EventArgs e);
        public event ClickXoaHandler ClickXoa;

        protected virtual void OnClickXoa(object sender, EventArgs e)
        {
            if (ClickXoa != null) ClickXoa(sender, e);
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            OnClickXoa(sender, e);
        }

    }
}
