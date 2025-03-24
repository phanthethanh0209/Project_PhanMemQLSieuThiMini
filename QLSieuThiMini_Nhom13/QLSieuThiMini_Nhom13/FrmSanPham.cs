using BUL;
using DTO;
using QLSieuThiMini_Nhom13.UserControls;
using Syncfusion.XlsIO;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Windows.Forms;

namespace QLSieuThiMini_Nhom13
{
    public partial class FrmSanPham : Form
    {
        public FrmSanPham()
        {
            InitializeComponent();
        }

        SanPhamBUL sanPhamBUL = new SanPhamBUL();
        NhaCungCapBUL nccBUL = new NhaCungCapBUL();
        ThuongHieuBUL thuongHieuBUL = new ThuongHieuBUL();
        LoaiSanPhamBUL loaiSPBUL = new LoaiSanPhamBUL();
        List<SanPhamDTO> dssp_List;

        private void FrmSanPham_Load(object sender, EventArgs e)
        {
            //Khởi tạo
            hienThiCboTH();
            hienThiCboLoaiSP();
            //hienThiDgvSanPham();
            cboDonVi.Items.Add("Gam");
            cboDonVi.Items.Add("Kg");

            //LUÔN KHÓA
            txtMaSP.Enabled = false;
            txtGiaBan.Enabled = false;
            txtSoLuong.Enabled = false;

            //Enable
            txtTenSP.Enabled = false;
            txtMau.Enabled = false;
            txtKichCo.Enabled = false;
            txtGiaNhap.Enabled = false;
            txtGiaBan.Enabled = false;
            txtNSX.Enabled = false;
            txtHSD.Enabled = false;
            cboMaLoai.Enabled = false;
            cboMaTH.Enabled = false;
            cboDonVi.Enabled = false;
            btnChonHinh.Enabled = false;

            txtMaSP.Text = "";
            txtTenSP.Text = "";
            txtMau.Text = "";
            txtKichCo.Text = "";
            txtGiaNhap.Text = "";
            txtGiaBan.Text = "";
            txtNSX.Text = "";
            txtHSD.Text = "";
            txtSoLuong.Text = "";

            loadCboLoai();
            loadCboThuongHieu();
            cboTH.SelectedIndex = -1;
            cboLoaiSp.SelectedIndex = -1;
            ShowUserControl(sanPhamBUL.layDSSanPham());
        }

        //private void ShowUserControl()
        //{
        //    int right = 0;
        //    int top = 5;
        //    foreach (SanPhamDTO sp in sanPhamBUL.layDSSanPham())
        //    {
        //        SanPham_UC myControl = new SanPham_UC(sp.TenSP, int.Parse(sp.GiaBan.ToString()), sp.HinhAnh);
        //        //myControl.Dock = DockStyle.Fill; // Tự động mở rộng theo Form

        //        myControl.AutoSize = false;
        //        myControl.Dock = DockStyle.None;
        //        //myControl.Anchor = AnchorStyles.None;
        //        //myControl.Size = new Size(20, 20); // Kích thước
        //        myControl.Location = new Point(right, top); // Vị trí trong Form
        //        myControl.Width = 150;
        //        myControl.Height = 200;

        //        // Thêm UserControl vào Controls của Form
        //        //this.ShadowPnl.ControlAdded(myControl);
        //        ShadowPnl.Controls.Add(myControl);
        //        myControl.BringToFront();

        //        right += myControl.Width + 5;
        //    }
        //}



        private void SanPham_UC_Click(object sender, EventArgs e)
        {
            SanPham_UC control = sender as SanPham_UC;

            if (control != null)
            {
                // Lấy thông tin từ UserControl
                txtTenSP.Text = control.TenSP.ToString();
                txtMaSP.Text = control.MaSP.ToString();

                SanPhamDTO sp = sanPhamBUL.layMotSanPham(control.MaSP);

                string maLoai = sp.MaLoai;
                LoaiSanPhamDTO lsp = loaiSPBUL.LayThongTinMotLoai(maLoai);
                cboMaLoai.Text = lsp.tenLoai;
                string maTH = sp.MaTH;
                ThuongHieuDTO th = thuongHieuBUL.LayThongTinMotThuongHieu(maTH);
                cboMaTH.Text = th.tenThuongHieu;
                txtGiaBan.Text = sp.GiaBan.ToString();
                txtSoLuong.Text = sp.SLTon.ToString();

                txtMau.Text = sp.MauSac.ToString();
                if (sp.KichCo < 1) //nếu là số thập phân, ví dụ 0.1 0.01 0.001kg
                {
                    txtKichCo.Text = (sp.KichCo * 1000).ToString(); //thì chuyển về gam
                    cboDonVi.SelectedIndex = 0;
                }
                else
                {
                    txtKichCo.Text = sp.KichCo.ToString(); //thì chuyển về kg
                    cboDonVi.SelectedIndex = 1;
                }

                txtGiaNhap.Text = sp.GiaNhap.ToString();
                txtNSX.Text = sp.NgaySX.ToString();
                txtHSD.Text = sp.HSD.ToString();
                UploadHinh("Upload\\Images\\" + sp.HinhAnh);

                if (tacVu == "Sua")
                {
                    txtTenSP.Enabled = true;
                    txtMau.Enabled = true;
                    txtKichCo.Enabled = true;
                    txtGiaNhap.Enabled = true;
                    txtGiaBan.Enabled = true;
                    txtNSX.Enabled = true;
                    txtHSD.Enabled = true;
                    cboMaTH.Enabled = true;
                    cboMaLoai.Enabled = true;
                    cboDonVi.Enabled = true;
                    btnChonHinh.Enabled = true;
                }
                else
                {
                    //Enable
                    txtTenSP.Enabled = false;
                    txtMau.Enabled = false;
                    txtKichCo.Enabled = false;
                    txtGiaNhap.Enabled = false;
                    txtGiaBan.Enabled = false;
                    txtNSX.Enabled = false;
                    txtHSD.Enabled = false;
                    cboMaTH.Enabled = false;
                    cboMaLoai.Enabled = false;
                    cboDonVi.Enabled = false;
                    btnChonHinh.Enabled = false;
                }
            }
        }


        //KHỞI TẠO BIẾN STATIC ĐỂ FORM DS SẢN PHẨM NHẬN THÔNG TIN TRẢ VỀ KHI ĐÓNG FORM
        //private JFrame parentFrame;
        //public static String masp_new = "";
        //public static String tensp_new = "";
        //public static int soluong_new = 0;
        //public static int gianhap_new = 0;

        string tacVu = "Xem";

        void hienThiCboTH()
        {
            cboMaTH.DataSource = thuongHieuBUL.LayTatCaThuongHieu();
            cboMaTH.ValueMember = "maThuongHieu";
            cboMaTH.DisplayMember = "tenThuongHieu";
            cboMaTH.SelectedIndex = -1;
        }

        void hienThiCboLoaiSP()
        {
            cboMaLoai.DataSource = loaiSPBUL.LayTatCaLoaiSP();
            cboMaLoai.ValueMember = "maLoai";
            cboMaLoai.DisplayMember = "tenLoai";
            cboMaLoai.SelectedIndex = -1;
        }

        //void hienThiDgvSanPham()
        //{
        //    dgvDSSP.AutoGenerateColumns = false;
        //    dgvDSSP.DataSource = sanPhamBUL.layDSSanPham();
        //    //Gắn hình ảnh vào dgvDSSP cột HinhAnhSP
        //}
        //void hienThiDgvSanPham()
        //{
        //    dgvDSSP.AutoGenerateColumns = false;
        //    dgvDSSP.DataSource = sanPhamBUL.layDSSanPham(); 

        //    foreach (DataGridViewRow row in dgvDSSP.Rows)
        //    {
        //        string imagePath = "Upload\\Images\\" + row.Cells["HinhAnhSP"].Value.ToString();

        //        // Nếu hình ảnh không phải null và đường dẫn hợp lệ
        //        if (!string.IsNullOrEmpty(imagePath) && File.Exists(imagePath))
        //        {
        //            // Gán hình ảnh vào cột HinhAnhSP
        //            row.Cells["HinhAnhSP"].Value = Image.FromFile(imagePath);
        //        }
        //        else
        //        {
        //            // Nếu không có hình ảnh, bạn có thể đặt hình ảnh mặc định
        //            row.Cells["HinhAnhSP"].Value = Image.FromFile("Upload\\Images\\ImageReset.png");
        //        }
        //    }
        //}
        //void hienThiDgvSanPham()
        //{
        //    //List<SanPhamDTO> dssp = sanPhamBUL.layDSSanPham();
        //    dgvDSSP.AutoGenerateColumns = false;
        //    dgvDSSP.DataSource = sanPhamBUL.layDSSanPham();
        //    dgvDSSP.RowTemplate.Height = 120;
        //    dgvDSSP.Columns["HinhAnhSP"].DataPropertyName = "HinhAnh";

        //    dgvDSSP.CellFormatting += dgvDSSP_CellFormatting;
        //}

        private void dgvDSSP_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            // Kiểm tra nếu là cột HinhAnhSP và có dữ liệu
            //if (dgvDSSP.Columns[e.ColumnIndex].Name == "HinhAnhSP" && e.Value != null)
            //{
            //    string hinhAnhPath = "Upload\\Images\\" + e.Value.ToString();

            //    try
            //    {
            //        // Kiểm tra nếu đường dẫn hợp lệ và chuyển đổi thành Image
            //        Image img = Image.FromFile(hinhAnhPath); // Đọc hình ảnh từ đường dẫn
            //        e.Value = img; // Gán hình ảnh vào cell
            //    }
            //    catch (Exception ex)
            //    {
            //        // Nếu có lỗi khi tải hình ảnh (ví dụ: file không tồn tại), có thể thay thế bằng hình mặc định
            //        e.Value = Image.FromFile("Upload\\Images\\ImageReset.png");
            //        //e.Value = Image.FromFile(hinhAnhPath);
            //    }
            //}
        }




        void reset(bool open)
        {
            txtTenSP.Enabled = open;
            txtMau.Enabled = open;
            txtKichCo.Enabled = open;
            txtGiaNhap.Enabled = open;
            txtGiaBan.Enabled = open;
            txtNSX.Enabled = open;
            txtHSD.Enabled = open;
            cboMaLoai.Enabled = open;
            cboMaTH.Enabled = open;
            cboDonVi.Enabled = open;
            btnChonHinh.Enabled = open;
            txtMaSP.Text = "";
            txtTenSP.Text = "";
            txtMau.Text = "";
            txtKichCo.Text = "";
            txtGiaNhap.Text = "";
            txtGiaBan.Text = "";
            txtNSX.Text = "";
            txtHSD.Text = "";
            cboMaLoai.SelectedIndex = -1;
            cboMaTH.SelectedIndex = -1;
            cboDonVi.SelectedIndex = -1;
            txtSoLuong.Text = "0";
            UploadHinh(null);
        }
        private void btnCRUD_UC1_ThemClicked(object sender, EventArgs e)
        {
            reset(true);
            txtMaSP.Text = sanPhamBUL.TaoMaSanPham();
            cboDonVi.SelectedIndex = 1;

            tacVu = "Them";
        }

        private void btnCRUD_UC1_SuaClicked(object sender, EventArgs e)
        {

            reset(false);
            txtSoLuong.Text = "";

            tacVu = "Sua";
        }

        private void btnCRUD_UC1_XoaClicked(object sender, EventArgs e)
        {
            reset(false);
            txtSoLuong.Text = "";

            tacVu = "Xoa";
        }

        private void btnCRUD_UC1_HuyClicked(object sender, EventArgs e)
        {
            reset(false);
            txtSoLuong.Text = "";
            tacVu = "Xem";
        }

        string hinhAnh;
        private void btnCRUD_UC1_LuuClicked(object sender, EventArgs e)
        {

            string maSP = txtMaSP.Text;
            string tenSP = txtTenSP.Text;
            string mau = txtMau.Text;

            int sLTon = int.Parse(txtSoLuong.Text);
            double giaNhap = double.Parse(txtGiaNhap.Text);
            double giaBan = double.Parse(txtGiaBan.Text);
            DateTime nSX = txtNSX.Value;
            DateTime hSD = txtHSD.Value;
            string maLoai = cboMaLoai.SelectedValue.ToString();
            string maTH = cboMaTH.SelectedValue.ToString();
            string hinhAnhh = hinhAnh;
            double kichCo;
            if (cboDonVi.SelectedIndex == 1) //KG
                kichCo = double.Parse(txtKichCo.Text);
            else //Gam
                kichCo = double.Parse(txtKichCo.Text) / 1000;

            SanPhamDTO dto = new SanPhamDTO(maSP, tenSP, giaBan, giaNhap, sLTon, nSX, hSD, kichCo, mau, maLoai, maTH, hinhAnhh);
            if (tacVu == "Them")
            {
                if (sanPhamBUL.themSanPham(dto))
                {
                    MessageBox.Show("Thêm sản phẩm thành công", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1);
                }
                else
                {
                    MessageBox.Show("Thêm sản phẩm thất bại", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1);
                }
            }

            if (tacVu == "Sua")
            {
                if (sanPhamBUL.suaSanPham(dto))
                {
                    MessageBox.Show("Sửa sản phẩm thành công", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1);
                }
                else
                {
                    MessageBox.Show("Sửa sản phẩm thất bại", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1);
                }
            }

            if (tacVu == "Xoa")
            {
                if (sanPhamBUL.xoaSanPham(dto))
                {
                    MessageBox.Show("Xóa sản phẩm thành công", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1);
                }
                else
                {
                    MessageBox.Show("Xóa sản phẩm thất bại", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1);
                }
            }

            ShadowPnl.Controls.Clear();
            ShowUserControl(sanPhamBUL.layDSSanPham());

            reset(false);
            tacVu = "Xem";
            //hienThiDgvSanPham();
        }



        private void btnChonHinh_Click(object sender, EventArgs e)
        {
            using (OpenFileDialog openFileDialog = new OpenFileDialog())
            {
                // Thiết lập các bộ lọc cho file (chỉ chọn hình ảnh)
                openFileDialog.Filter = "Image Files|*.jpg;*.jpeg;*.png;*.bmp";

                if (openFileDialog.ShowDialog() == DialogResult.OK)
                {
                    // Lấy đường dẫn của file được chọn
                    string selectedFilePath = openFileDialog.FileName;

                    // Lấy mã học sinh từ TextBox txtMaHS
                    string maHS = txtMaSP.Text.Trim();

                    // Lấy phần mở rộng của file ảnh đã chọn
                    string fileExtension = Path.GetExtension(selectedFilePath);

                    // Tạo tên file mới dựa trên mã học sinh và phần mở rộng
                    string newFileName = $"{maHS}{fileExtension}";

                    // Đường dẫn tạm để tạo file mới với tên đã đổi
                    string tempFilePath = Path.Combine(Path.GetTempPath(), newFileName);

                    // Copy file vào đường dẫn tạm với tên mới
                    File.Copy(selectedFilePath, tempFilePath, true);

                    // Gọi hàm WriteFile để lưu file đã đổi tên vào thư mục "Images"
                    string savedFileName = WriteFile(tempFilePath, "Images");

                    // Xóa file tạm sau khi lưu thành công
                    File.Delete(tempFilePath);

                    // Hiển thị thông báo file đã được lưu
                    hinhAnh = savedFileName;
                    //MessageBox.Show("File đã được lưu với tên: " + savedFileName);

                    // Lấy đường dẫn của file đã lưu
                    string savedFilePath = Path.Combine(Directory.GetCurrentDirectory(), "Upload\\Images", savedFileName);


                    // Hiển thị hình ảnh lên BunifuImageButton
                    UploadHinh(savedFilePath);
                }
            }

        }

        // Hàm để upload và hiển thị hình ảnh
        void UploadHinh(string hinh)
        {
            try
            {
                // Tạo đối tượng Image từ file hình ảnh
                Image selectedImage = Image.FromFile("Upload\\Images\\ImageReset.png");
                if (hinh != null)
                    selectedImage = Image.FromFile(hinh);
                // Hiển thị hình ảnh lên BunifuImageButton
                lblHinh.Image = selectedImage;

                // Nếu muốn thay đổi kích thước của hình ảnh để phù hợp với kích thước của button:
                lblHinh.Image = new Bitmap(selectedImage, new Size(lblHinh.Width, lblHinh.Height));
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi khi hiển thị hình ảnh: " + ex.Message);
            }
        }




        private string WriteFile(string selectedFilePath, string folderName)
        {
            string fileName = Path.GetFileName(selectedFilePath);
            try
            {
                // Đường dẫn của thư mục 'Upload/[folderName]' được tạo từ thư mục hiện tại
                string filePath = Path.Combine(Directory.GetCurrentDirectory(), $"Upload\\{folderName}");

                // Kiểm tra xem thư mục có tồn tại hay không, nếu không thì tạo mới
                if (!Directory.Exists(filePath))
                {
                    Directory.CreateDirectory(filePath);
                }

                // Xác định đường dẫn đích để lưu file
                string exactPath = Path.Combine(filePath, fileName);

                // Copy file từ đường dẫn đã chọn (selectedFilePath) đến vị trí lưu trữ (exactPath)
                File.Copy(selectedFilePath, exactPath, true); // 'open' để ghi đè nếu file đã tồn tại
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi khi lưu file: " + ex.Message);
            }

            return fileName;
        }

        private void txtMau_TextChanged(object sender, EventArgs e)
        {
            string inputText = txtMau.Text;
            string filteredText = "";

            // Lặp qua từng ký tự và kiểm tra xem có phải là chữ không
            foreach (char c in inputText)
            {
                if (char.IsLetter(c) || char.IsWhiteSpace(c)) // Cho phép chữ cái và khoảng trắng
                {
                    filteredText += c; // Thêm ký tự vào filteredText nếu là chữ
                }
            }

            // Nếu có ký tự không hợp lệ
            if (inputText.Length != filteredText.Length)
            {
                MessageBox.Show("Màu sắc không nhập kí tự số hoặc ký tự đặc biệt!");
                txtMau.Text = filteredText; // Chỉ giữ lại ký tự chữ
                txtMau.SelectionStart = txtMau.Text.Length; // Đặt con trỏ ở cuối
            }
            else
            {
                txtMau.Text = filteredText; // Chỉ giữ lại ký tự chữ
            }
        }

        private void txtKichCo_TextChanged(object sender, EventArgs e)
        {
            string inputText = txtKichCo.Text;
            string filteredText = "";
            bool dotFound = false; // Biến cờ để kiểm tra dấu chấm đã xuất hiện chưa

            // Lặp qua từng ký tự và kiểm tra xem có phải là số hoặc dấu chấm không
            foreach (char c in inputText)
            {
                if (char.IsDigit(c)) // Nếu là số
                {
                    filteredText += c;
                }
                else if (c == '.' && !dotFound) // Nếu là dấu chấm và chưa có dấu chấm
                {
                    filteredText += c;
                    dotFound = true; // Đánh dấu là đã có dấu chấm
                }
            }

            // Nếu có ký tự không hợp lệ
            if (inputText.Length != filteredText.Length)
            {
                MessageBox.Show("Kích cỡ không nhập kí tự khác số!");
            }

            txtKichCo.Text = filteredText; // Chỉ giữ lại ký tự số và dấu chấm hợp lệ
            txtKichCo.SelectionStart = txtKichCo.Text.Length; // Đặt con trỏ ở cuối

        }

        private void txtGiaNhap_TextChanged(object sender, EventArgs e)
        {
            string inputText = txtGiaNhap.Text;
            string filteredText = "";

            // Lặp qua từng ký tự và kiểm tra xem có phải là số không
            foreach (char c in inputText)
            {
                if (char.IsDigit(c))
                {
                    filteredText += c; // Thêm ký tự vào filteredText nếu là số
                }
            }

            // Nếu có ký tự không hợp lệ
            if (inputText.Length != filteredText.Length)
            {
                MessageBox.Show("Kích cỡ không nhập kí tự khác số!");
                txtGiaNhap.Text = filteredText;
                txtGiaNhap.SelectionStart = txtGiaNhap.Text.Length; // Đặt con trỏ ở cuối
            }
            else
            {
                txtGiaNhap.Text = filteredText; // Chỉ giữ lại ký tự số
            }
        }

        private void dgvDSSP_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            //if (e.RowIndex >= 0)
            //{
            //    DataGridViewRow selectedRow = dgvDSSP.Rows[e.RowIndex];

            //    txtMaSP.Text = selectedRow.Cells["MaSP"].Value.ToString();
            //    txtTenSP.Text = selectedRow.Cells["TenSP"].Value.ToString();
            //    string maLoai = selectedRow.Cells["MaLoai"].Value.ToString();
            //    LoaiSanPhamDTO lsp = loaiSPBUL.LayThongTinMotLoai(maLoai);
            //    cboMaLoai.Text = lsp.tenLoai;
            //    string maTH = selectedRow.Cells["MaTH"].Value.ToString();
            //    ThuongHieuDTO th = thuongHieuBUL.LayThongTinMotThuongHieu(maTH);
            //    cboMaTH.Text = th.tenThuongHieu;
            //    txtGiaBan.Text = selectedRow.Cells["GiaBan"].Value.ToString();
            //    txtSoLuong.Text = selectedRow.Cells["SoLuong"].Value.ToString();

            //    SanPhamDTO sp = sanPhamBUL.layMotSanPham(txtMaSP.Text);
            //    txtMau.Text = sp.MauSac.ToString();
            //    if (sp.KichCo < 1) //nếu là số thập phân, ví dụ 0.1 0.01 0.001kg
            //    {
            //        txtKichCo.Text = (sp.KichCo * 1000).ToString(); //thì chuyển về gam
            //        cboDonVi.SelectedIndex = 0;
            //    }
            //    else
            //    {
            //        txtKichCo.Text = sp.KichCo.ToString(); //thì chuyển về kg
            //        cboDonVi.SelectedIndex = 1;
            //    }

            //    txtGiaNhap.Text = sp.GiaNhap.ToString();
            //    txtNSX.Text = sp.NgaySX.ToString();
            //    txtHSD.Text = sp.HSD.ToString();
            //    UploadHinh("Upload\\Images\\" + sp.HinhAnh);


            //    if (tacVu == "Sua")
            //    {
            //        txtTenSP.Enabled = true;
            //        txtMau.Enabled = true;
            //        txtKichCo.Enabled = true;
            //        txtGiaNhap.Enabled = true;
            //        txtGiaBan.Enabled = true;
            //        txtNSX.Enabled = true;
            //        txtHSD.Enabled = true;
            //        cboMaTH.Enabled = true;
            //        cboMaLoai.Enabled = true;
            //        cboDonVi.Enabled = true;
            //        btnChonHinh.Enabled = true;
            //    }
            //    else
            //    {
            //        //Enable
            //        txtTenSP.Enabled = false;
            //        txtMau.Enabled = false;
            //        txtKichCo.Enabled = false;
            //        txtGiaNhap.Enabled = false;
            //        txtGiaBan.Enabled = false;
            //        txtNSX.Enabled = false;
            //        txtHSD.Enabled = false;
            //        cboMaTH.Enabled = false;
            //        cboMaLoai.Enabled = false;
            //        cboDonVi.Enabled = false;
            //        btnChonHinh.Enabled = false;
            //    }
            //}
        }

        private void btnCRUD_UC1_Load(object sender, EventArgs e)
        {

        }

        private void txtGiaBan_TextChanged(object sender, EventArgs e)
        {
            string inputText = txtGiaBan.Text;
            string filteredText = "";

            // Lặp qua từng ký tự và kiểm tra xem có phải là số không
            foreach (char c in inputText)
            {
                if (char.IsDigit(c))
                {
                    filteredText += c; // Thêm ký tự vào filteredText nếu là số
                }
            }

            // Nếu có ký tự không hợp lệ
            if (inputText.Length != filteredText.Length)
            {
                MessageBox.Show("Kích cỡ không nhập kí tự khác số!");
                txtGiaBan.Text = filteredText;
                txtGiaBan.SelectionStart = txtGiaBan.Text.Length; // Đặt con trỏ ở cuối
            }
            else
            {
                txtGiaBan.Text = filteredText; // Chỉ giữ lại ký tự số
            }
        }

        private void dgvDSSP_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void FrmSanPham_Resize(object sender, EventArgs e)
        {
            //ShowUserControl();
        }

        private void ShadowPnl_Resize(object sender, EventArgs e)
        {
            //ShowUserControl();

        }

        private void btnXuatExcel_Click(object sender, EventArgs e)
        {

        }

        private void ShadowPnl_Paint(object sender, PaintEventArgs e)
        {

        }

        bool loadLoaiXong = false;
        bool loadTHXong = false;
        void loadCboThuongHieu()
        {
            cboTH.DataSource = thuongHieuBUL.LayTatCaThuongHieu();
            cboTH.DisplayMember = "tenThuongHieu";
            cboTH.ValueMember = "maThuongHieu";
            loadTHXong = true;
        }

        void loadCboLoai()
        {
            cboLoaiSp.DataSource = loaiSPBUL.LayTatCaLoaiSP();
            cboLoaiSp.DisplayMember = "TenLoai";
            cboLoaiSp.ValueMember = "MaLoai";
            loadLoaiXong = true;
        }

        private void cboTH_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (loadTHXong && cboTH.SelectedIndex >= 0)
            {
                ShadowPnl.Controls.Clear();
                ShowUserControl(sanPhamBUL.layDSSanPhamTheoThuongHieu(cboTH.SelectedValue.ToString()));
                cboLoaiSp.SelectedIndex = -1;
                ckXemTatCa.Checked = false;
            }
        }

        private void cboLoaiSp_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (loadLoaiXong && cboLoaiSp.SelectedIndex >= 0)
            {
                ShadowPnl.Controls.Clear();
                ShowUserControl(sanPhamBUL.layDSSanPhamTheoLoai(cboLoaiSp.SelectedValue.ToString()));
                cboTH.SelectedIndex = -1;
                ckXemTatCa.Checked = false;
            }
        }

        private void ckXemTatCa_CheckedChanged(object sender, EventArgs e)
        {
            if (ckXemTatCa.Checked)
            {
                ShadowPnl.Controls.Clear();
                ShowUserControl(sanPhamBUL.layDSSanPham());
                cboLoaiSp.SelectedIndex = -1;
                cboTH.SelectedIndex = -1;
            }
        }

        private void txtSanPham_TextChanged(object sender, EventArgs e)
        {
            ShowUserControl(sanPhamBUL.timKiemSPTheoMaHoacTen(txtSanPham.Text));
        }



        private void ShowUserControl(List<SanPhamDTO> dsSanPham)
        {
            int x = 0; // Tọa độ X của UserControl đầu tiên
            int y = 0; // Tọa độ Y của UserControl đầu tiên
            int controlSpacing = 3; // Khoảng cách giữa các UserControl
            int controlWidth = 150; // Chiều rộng của UserControl
            int controlHeight = 200; // Chiều cao của UserControl

            foreach (SanPhamDTO sp in dsSanPham)
            {
                // Tạo một instance của UserControl
                SanPham_UC myControl = new SanPham_UC(sp.MaSP, sp.TenSP, int.Parse(sp.GiaBan.ToString()), sp.HinhAnh);
                //myControl.Click += new EventHandler(SanPham_UC_Click);

                myControl.Clicked += SanPham_UC_Click;

                myControl.AutoSize = false;
                myControl.Width = controlWidth;
                myControl.Height = controlHeight;

                // Kiểm tra nếu vị trí X cộng với chiều rộng của UserControl vượt quá chiều rộng Panel
                if (x + controlWidth > ShadowPnl.ClientSize.Width)
                {
                    x = 0; // Đặt lại vị trí X về 0 (xuống dòng)
                    y += controlHeight + controlSpacing; // Tăng vị trí Y để xuống dòng
                }

                myControl.Location = new Point(x, y);
                ShadowPnl.Controls.Add(myControl);
                myControl.BringToFront();

                // Tính vị trí X cho UserControl tiếp theo
                x += controlWidth + controlSpacing;
            }

            // Bật cuộn khi cần
            guna2VScrollBar1.BindingContainer = ShadowPnl;
            ShadowPnl.AutoScroll = true;
        }

        private void btnChon_Click(object sender, EventArgs e)
        {
            using (ExcelEngine excelEngine = new ExcelEngine())
            {
                IApplication application = excelEngine.Excel;
                application.DefaultVersion = ExcelVersion.Excel2013;
                IWorkbook workbook = excelEngine.Excel.Workbooks.Open("Template/DsSanPham.xlsx");
                IWorksheet worksheet = workbook.Worksheets[0];

                string ngay = "Ngày " + DateTime.Now.Day + " tháng " + DateTime.Now.Month + " năm " + DateTime.Now.Year;
                worksheet.Replace("%NgayThangNam", ngay);

                List<SanPhamDTO> sanphams = new List<SanPhamDTO>();
                List<SanPhamDTO> danhSachSanPham = sanPhamBUL.layDSSanPham();

                if (cboTH.SelectedIndex >= 0)
                {
                    worksheet.Replace("%Hinhthuc", "DANH SÁCH SẢN PHẨM THƯƠNG HIỆU " + cboTH.Text);
                    danhSachSanPham = sanPhamBUL.layDSSanPhamTheoThuongHieu(cboTH.SelectedValue.ToString());
                }

                if (cboLoaiSp.SelectedIndex >= 0)
                {
                    worksheet.Replace("%Hinhthuc", "DANH SÁCH SẢN PHẨM THUỘC LOẠI " + cboLoaiSp.Text);
                    danhSachSanPham = sanPhamBUL.layDSSanPhamTheoLoai(cboLoaiSp.SelectedValue.ToString());
                }

                if (ckXemTatCa.Checked)
                {
                    worksheet.Replace("%Hinhthuc", "DANH SÁCH SẢN PHẨM TẠI CỬA HÀNG");
                    danhSachSanPham = sanPhamBUL.layDSSanPham();
                }

                int stt = 1;
                foreach (SanPhamDTO sp in danhSachSanPham)
                {
                    sp.STT = stt++;
                    sanphams.Add(sp);
                }

                ITemplateMarkersProcessor marker = workbook.CreateTemplateMarkersProcessor();
                marker.AddVariable("Sanpham", sanphams);
                marker.ApplyMarkers();

                string filePath = "xong.xlsx";
                workbook.SaveAs(filePath);
                workbook.Close();
                MessageBox.Show("Xuất file thành công!");

                // Tự động mở file Excel sau khi xuất thành công
                System.Diagnostics.Process.Start(new System.Diagnostics.ProcessStartInfo
                {
                    FileName = filePath,
                    UseShellExecute = true
                });
            }
        }

    }
}
