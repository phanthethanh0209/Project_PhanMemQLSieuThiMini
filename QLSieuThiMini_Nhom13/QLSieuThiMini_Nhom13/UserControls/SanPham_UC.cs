using System;
using System.Drawing;
using System.Windows.Forms;

namespace QLSieuThiMini_Nhom13.UserControls
{
    public partial class SanPham_UC : UserControl
    {
        public SanPham_UC()
        {
            InitializeComponent();
        }

        public SanPham_UC(string maSP, string tenSP, int giaSP, string tenHinh)
        {
            InitializeComponent();

            TenSP = tenSP;
            GiaSP = giaSP;
            TenHinh = tenHinh;
            MaSP = maSP;

            UploadHinh("Upload\\Images\\" + tenHinh);

            RegisterClickEvent(this);
        }

        private string maSP;
        private string tenSP;
        private int giaSP;
        private string tenHinh;

        public string MaSP
        {
            get => maSP;
            set
            {
                maSP = value;
            }
        }

        public string TenSP
        {
            get => tenSP;
            set
            {
                tenSP = value;
                lbTenSP.Text = tenSP; // Hiển thị tên sản phẩm lên Label
            }
        }

        public int GiaSP
        {
            get => giaSP;
            set
            {
                giaSP = value;
                lbGiaSP.Text = giaSP.ToString("N0") + " VND"; // Hiển thị giá sản phẩm lên Label
            }
        }

        public string TenHinh
        {
            get => tenHinh;
            set
            {
                tenHinh = value;
                imageAnhSP.Text = tenHinh; // Hiển thị tên sản phẩm lên Label
            }
        }

        void UploadHinh(string hinh)
        {
            try
            {
                // Tạo đối tượng Image từ file hình ảnh
                Image selectedImage = Image.FromFile("Upload\\Images\\ImageReset.png");
                if (hinh != null)
                    selectedImage = Image.FromFile(hinh);
                // Hiển thị hình ảnh lên BunifuImageButton
                imageAnhSP.Image = selectedImage;

                // Nếu muốn thay đổi kích thước của hình ảnh để phù hợp với kích thước của button:
                imageAnhSP.Image = new Bitmap(selectedImage, new Size(imageAnhSP.Width, imageAnhSP.Height));
            }
            catch (Exception ex)
            {
               // MessageBox.Show("Lỗi khi hiển thị hình ảnh: " + ex.Message);
            }
        }


        public delegate void ClickedHandler(object sender, EventArgs e);
        public event ClickedHandler Clicked;

        protected virtual void OnClickedHandler(EventArgs e)
        {
            Clicked?.Invoke(this, e); // Kích hoạt sự kiện nếu có đăng ký
        }

        private void RegisterClickEvent(Control parent)
        {
            foreach (Control control in parent.Controls)
            {
                control.Click += (s, e) => OnClickedHandler(e); // Kích hoạt sự kiện khi bất kỳ control con nào được click
                RegisterClickEvent(control); // Đệ quy đăng ký sự kiện cho các control con
            }
        }
    }
}
