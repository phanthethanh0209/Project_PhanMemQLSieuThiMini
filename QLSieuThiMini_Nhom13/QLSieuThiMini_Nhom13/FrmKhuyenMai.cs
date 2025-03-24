using BUL;
using DTO;
using Guna.UI2.WinForms;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Transactions;
using System.Windows.Forms;

namespace QLSieuThiMini_Nhom13
{
    public partial class FrmKhuyenMai : Form
    {
        KhuyenMaiBUL kmBUL;
        SanPhamBUL spBUL;
        NhomSanPhamKMBUL nhomSPKMBUL;
        CTNhomSanPhamKMBUL ctNhomSPKMBul;
        Guna2MessageDialog message;

        public FrmKhuyenMai()
        {
            InitializeComponent();
            message = new Guna2MessageDialog
            {
                Style = MessageDialogStyle.Light,
            };

            //dgvSPMua.MouseDown += dgvMua_MouseDown;
            //dgvSPTang.MouseDown += dgvTang_MouseDown;

            kmBUL = new KhuyenMaiBUL();
            spBUL = new SanPhamBUL();
            nhomSPKMBUL = new NhomSanPhamKMBUL();
            ctNhomSPKMBul = new CTNhomSanPhamKMBUL();
        }

        private void FrmKhuyenMaiTest_Load(object sender, System.EventArgs e)
        {
            // Tắt tính năng tự động sinh cột
            dgvSPMua.AutoGenerateColumns = false;
            dgvSPMua.AllowUserToAddRows = false;

            dgvSPTang.AutoGenerateColumns = false;
            dgvSPTang.AllowUserToAddRows = false;

            //// Tạo các cột cho DataGridView
            //dgvSPMua.Rows.Add("SP001", "Gạo 5kg");

            //// Dữ liệu các sản phẩm trong siêu thị
            //dgvSPTang.Rows.Add("SP001", "Gạo 5kg");
            //dgvSPTang.Rows.Add("SP002", "Dầu ăn 1L");
            //dgvSPTang.Rows.Add("SP003", "Bánh Kẹo");
            //dgvSPTang.Rows.Add("SP004", "Sữa Bột 900g");

            // Thiết lập tiêu đề của DataGridView in đậm
            foreach (DataGridViewColumn column in dgvSPTang.Columns)
            {
                column.HeaderCell.Style.Font = new Font("Tahoma", 9, FontStyle.Bold);
            }
            foreach (DataGridViewColumn column in dgvSPMua.Columns)
            {
                column.HeaderCell.Style.Font = new Font("Tahoma", 9, FontStyle.Bold);
            }

            loadCboDonViGiam();

            //Enable
            txtMaKM.Enabled = false; //luôn khóa
            anHien(false);
            btnXemDS.Enabled = true;
            btnThemKM.Enabled = true;
            btnHuy.Enabled = true;
            cboPhanTramOrTien.SelectedIndex = 0;
        }


        void loadCboDonViGiam()
        {
            cboPhanTramOrTien.DataSource = new List<KeyValuePair<int, string>>()
            {
                new KeyValuePair<int, string>(0, "VNĐ"),
                new KeyValuePair<int, string>(1, "%")
            };
            cboPhanTramOrTien.ValueMember = "Key";
            cboPhanTramOrTien.DisplayMember = "Value";
        }

        public List<SanPhamDTO> lstSanPhamMua = new List<SanPhamDTO>();
        public List<SanPhamDTO> lstSanPhamTang = new List<SanPhamDTO>();
        string tacVu;
        string giaG;
        string MaNhomSPMua, MaNhomSPTang;

        void anHien(bool anHien)
        {
            txtTenKM.Enabled = anHien;
            dtpNgayBD.Enabled = anHien;
            dtpNgayKT.Enabled = anHien;
            txtSLMua.Enabled = anHien;
            txtSLTang.Enabled = anHien;
            txtGiaGiam.Enabled = anHien;
            rdGiamTien.Enabled = anHien;
            rdTangHang.Enabled = anHien;

            btnThemSPMua.Enabled = anHien;
            btnThemSPTang.Enabled = anHien;

            btnXemDS.Enabled = anHien;
            btnThemKM.Enabled = anHien;
            btnSuaKM.Enabled = anHien;
            btnXoaKM.Enabled = anHien;
            btnLuuKm.Enabled = anHien;
            btnHuy.Enabled = anHien;
            cboPhanTramOrTien.Enabled = anHien;
        }


        void xoaTextBox()
        {
            txtMaKM.Text = "";
            txtTenKM.Text = "";
            txtSLMua.Text = "";
            txtSLTang.Text = "";
            dtpNgayBD.Value = DateTime.Now;
            dtpNgayKT.Value = DateTime.Now;
            txtGiaGiam.Text = "";
            rdGiamTien.Checked = false;
            rdTangHang.Checked = false;
            lbGiaGiamTuongUng.Text = "";
            lbGiaSP.Text = "";

        }


        void loadDGVSanPhamMua(List<SanPhamDTO> lstSP)
        {
            dgvSPMua.DataSource = null;
            if (dgvSPMua.Rows.Count > 0)
            {
                dgvSPMua.Rows.Clear();
            }
            dgvSPTang.AutoGenerateColumns = false;
            dgvSPMua.DataSource = lstSP;
        }

        void loadDGVSanPhamTang(List<SanPhamDTO> lstSP)
        {
            dgvSPTang.DataSource = null;

            if (dgvSPTang.Rows.Count > 0)
            {
                dgvSPTang.Rows.Clear();
            }
            dgvSPTang.AutoGenerateColumns = false;
            dgvSPTang.DataSource = lstSP;
        }


        private void btnThemSPMua_Click(object sender, System.EventArgs e)
        {
            FrmChonSPKM myForm = new FrmChonSPKM(lstSanPhamMua);
            myForm.StartPosition = FormStartPosition.CenterScreen;
            myForm.ShowDialog();
            //maHD = myForm.maHD;

            if (myForm.isSPHopLe && myForm.lstSPChon.Count > 0)
            {
                foreach (SanPhamDTO sp in myForm.lstSPChon)
                {
                    if (!lstSanPhamMua.Any(s => s.MaSP == sp.MaSP)) //Nếu sp chưa có trong lstSanPhamMua
                        lstSanPhamMua.Add(sp);
                    lbGiaSP.Text = sp.GiaBan + "VNĐ";
                }
                loadDGVSanPhamMua(lstSanPhamMua);
            }
        }

        private void btnXemDS_Click(object sender, System.EventArgs e)
        {
            tacVu = "xem";
            //xoaTextBox();
            FrmXemDSKhuyenMai myForm = new FrmXemDSKhuyenMai();
            myForm.StartPosition = FormStartPosition.CenterScreen;
            myForm.ShowDialog();

            //Lấy ra khuyến mãi
            if (myForm.MaKMChon != null && myForm.MaKMChon.Length > 0)
            {
                KhuyenMaiDTO km = kmBUL.layKhuyenMaiTheoMaKM(myForm.MaKMChon);
                txtMaKM.Text = km.MaKM;
                dtpNgayBD.Value = km.NgayBD;
                dtpNgayKT.Value = km.NgayKT;
                txtTenKM.Text = km.TenKM;
                txtSLMua.Text = km.SLMua.ToString();
                txtSLTang.Text = km.SLTang == 0 ? "" : km.SLTang.ToString();
                cboPhanTramOrTien.SelectedIndex = km.DonViGiam == "Phần trăm" ? 1 : 0;
                if (txtSLTang.Text.Length > 0)
                    rdTangHang.Checked = true;
                else
                    rdGiamTien.Checked = true;

                lstSanPhamMua.Clear();
                List<CTNhomSanPhamKMDTO> lstMua = nhomSPKMBUL.layMotNhomSanPhamKM(km.MaNhomSPMua);
                MaNhomSPMua = km.MaNhomSPMua;
                foreach (CTNhomSanPhamKMDTO sp in lstMua)
                {
                    SanPhamDTO sanpham = spBUL.layMotSanPham(sp.MaSP);
                    lstSanPhamMua.Add(sanpham);
                    lbGiaSP.Text = sanpham.GiaBan + "VNĐ";
                }
                loadDGVSanPhamMua(lstSanPhamMua);

                lstSanPhamTang.Clear();
                List<CTNhomSanPhamKMDTO> lstTang = nhomSPKMBUL.layMotNhomSanPhamKM(km.MaNhomSPTang);
                MaNhomSPTang = km.MaNhomSPTang;
                foreach (CTNhomSanPhamKMDTO sp in lstTang)
                {
                    SanPhamDTO sanpham = spBUL.layMotSanPham(sp.MaSP);
                    lstSanPhamTang.Add(sanpham);
                    lbGiaGiamTuongUng.Text = sanpham.GiaBan + "VNĐ";

                }
                loadDGVSanPhamTang(lstSanPhamTang);

                if (km.SLTang == 0) //là giảm tiền --> đã chuyển từ null sang 0 ở DAL
                {
                    lbGiaGiamTuongUng.Text = "";
                    txtSLTang.Text = "";
                    if (km.DonViGiam == "Tiền")
                        txtGiaGiam.Text = km.GiaGiam.ToString("F0");
                    else //%
                        txtGiaGiam.Text = (km.GiaGiam / double.Parse(lbGiaSP.Text.Substring(0, lbGiaSP.Text.Length - 3)) * 100).ToString("F0"); // Đảm bảo số nguyên

                }


                //Khóa lại, cho phép xem và sửa
                anHien(false);
                btnThemKM.Enabled = true;
                btnSuaKM.Enabled = true;
                btnXoaKM.Enabled = true;
                btnXemDS.Enabled = true;
                btnHuy.Enabled = true;

            }

        }

        private void btnThemKM_Click(object sender, System.EventArgs e)
        {
            xoaTextBox();
            anHien(true);
            lstSanPhamMua.Clear();
            lstSanPhamTang.Clear();
            if (dgvSPMua.Rows.Count > 0)
            {
                dgvSPMua.DataSource = null;
                dgvSPMua.Rows.Clear();
            }
            if (dgvSPTang.Rows.Count > 0)
            {
                dgvSPTang.DataSource = null;
                dgvSPTang.Rows.Clear();
            }

            txtMaKM.Text = kmBUL.TaoMaKhuyenMai();
            btnThemKM.Enabled = false;
            btnSuaKM.Enabled = false;
            btnXoaKM.Enabled = false;

            rdGiamTien.Checked = true; //mặc định là giảm tiền
            tacVu = "thêm";
        }

        private void rdTangHang_CheckedChanged(object sender, System.EventArgs e)
        {
            if (rdTangHang.Checked)
            {
                rdGiamTien.Checked = false;
                txtGiaGiam.Enabled = false;
                txtGiaGiam.Text = "";
                cboPhanTramOrTien.Enabled = false;
                btnThemSPTang.Enabled = true;
                txtSLTang.Enabled = true;
            }

        }

        private void rdGiamTien_CheckedChanged(object sender, System.EventArgs e)
        {
            if (rdGiamTien.Checked)
            {
                txtGiaGiam.Enabled = true;
                cboPhanTramOrTien.Enabled = true;
                cboPhanTramOrTien.SelectedIndex = 0;
                rdTangHang.Checked = false;
                btnThemSPTang.Enabled = false;
                txtSLTang.Enabled = false;
            }


        }

        private void btnThemSPTang_Click(object sender, System.EventArgs e)
        {
            FrmChonSPKM myForm = new FrmChonSPKM(lstSanPhamMua);
            myForm.StartPosition = FormStartPosition.CenterScreen;
            myForm.ShowDialog();
            //maHD = myForm.maHD;

            if (myForm.isSPHopLe && myForm.lstSPChon.Count > 0)
            {
                foreach (SanPhamDTO sp in myForm.lstSPChon)
                {
                    if (!lstSanPhamTang.Any(s => s.MaSP == sp.MaSP)) //Nếu sp chưa có trong lstSanPhamMua
                        lstSanPhamTang.Add(sp);
                    lbGiaGiamTuongUng.Text = sp.GiaBan + "VNĐ";
                }
                loadDGVSanPhamTang(lstSanPhamTang);
            }
        }


        bool kiemTraDuLieuHopLe()
        {
            if (rdGiamTien.Checked && txtGiaGiam.Text.Length == 0)
            {
                message.Buttons = MessageDialogButtons.OK;
                message.Icon = MessageDialogIcon.Error;
                message.Parent = this.ParentForm;
                message.Show("Hãy nhập giá giảm", "Thông Báo");
                return false;
            }
            if (rdGiamTien.Checked && cboPhanTramOrTien.SelectedIndex == 0 && int.Parse(txtGiaGiam.Text) < 1000) //chọn VNĐ
            {
                message.Buttons = MessageDialogButtons.OK;
                message.Icon = MessageDialogIcon.Error;
                message.Parent = this.ParentForm;
                message.Show("Tiền giảm không hợp lệ", "Thông Báo");
                return false;

            }
            if (rdGiamTien.Checked && cboPhanTramOrTien.SelectedIndex == 1 && int.Parse(txtGiaGiam.Text) > 100)
            {
                message.Buttons = MessageDialogButtons.OK;
                message.Icon = MessageDialogIcon.Error;
                message.Parent = this.ParentForm;
                message.Show("Phần trăm giảm không hợp lệ", "Thông Báo");
                return false;

            }
            if (rdTangHang.Checked && dgvSPTang.RowCount <= 0)
            {
                message.Buttons = MessageDialogButtons.OK;
                message.Icon = MessageDialogIcon.Error;
                message.Parent = this.ParentForm;
                message.Show("Hãy chọn sản phẩm tặng tương ứng", "Thông Báo");
                return false;

            }
            if (rdTangHang.Checked && int.Parse(txtSLTang.Text) <= 0)
            {
                message.Buttons = MessageDialogButtons.OK;
                message.Icon = MessageDialogIcon.Error;
                message.Parent = this.ParentForm;
                message.Show("Số lượng tặng không hợp lệ", "Thông Báo");
                return false;

            }

            if (txtTenKM.Text.Length == 0)
            {
                message.Buttons = MessageDialogButtons.OK;
                message.Icon = MessageDialogIcon.Error;
                message.Parent = this.ParentForm;
                message.Show("Tên khuyến mãi không hợp lệ", "Thông Báo");
                return false;

            }

            if (txtSLMua.Text.Length == 0)
            {
                message.Buttons = MessageDialogButtons.OK;
                message.Icon = MessageDialogIcon.Error;
                message.Parent = this.ParentForm;
                message.Show("Số lượng tặng không hợp lệ", "Thông Báo");
                return false;

            }

            if (dtpNgayBD.Value >= dtpNgayKT.Value)
            {
                message.Buttons = MessageDialogButtons.OK;
                message.Icon = MessageDialogIcon.Error;
                message.Parent = this.ParentForm;
                message.Show("Ngày bắt đầu và ngày kết thúc không hợp lệ", "Thông Báo");
                return false;

            }
            return true;
        }





        void themKM()
        {
            if (kiemTraDuLieuHopLe())
            {
                using (TransactionScope scope = new TransactionScope())
                {
                    try
                    {
                        //Tạo nhóm 1
                        MaNhomSPMua = nhomSPKMBUL.TaoMaNhomSanPham();
                        NhomSPKhuyenMaiDTO nhom1 = new NhomSPKhuyenMaiDTO(MaNhomSPMua, "Nhóm mua");
                        if (nhomSPKMBUL.themSanPham(nhom1))
                        {
                            //Tạo chi tiết nhóm 1
                            foreach (SanPhamDTO sp in lstSanPhamMua)
                            {
                                CTNhomSanPhamKMDTO ctNhom1 = new CTNhomSanPhamKMDTO(MaNhomSPMua, sp.MaSP);
                                ctNhomSPKMBul.themSanPham(ctNhom1);
                            }
                        }

                        //Tạo nhóm 2
                        MaNhomSPTang = nhomSPKMBUL.TaoMaNhomSanPham();
                        NhomSPKhuyenMaiDTO nhom2 = new NhomSPKhuyenMaiDTO(MaNhomSPTang, "Nhóm tặng");
                        if (nhomSPKMBUL.themSanPham(nhom2))
                        {
                            //Tạo chi tiết nhóm 2
                            foreach (SanPhamDTO sp in lstSanPhamTang)
                            {
                                CTNhomSanPhamKMDTO ctNhom2 = new CTNhomSanPhamKMDTO(MaNhomSPTang, sp.MaSP);
                                ctNhomSPKMBul.themSanPham(ctNhom2);
                            }
                        }

                        //Tạo khuyến mãi
                        int? slTang;
                        double giaG;
                        if (rdTangHang.Checked)
                        {
                            slTang = int.Parse(txtSLTang.Text);
                            giaG = double.Parse(lbGiaGiamTuongUng.Text.Substring(0, lbGiaSP.Text.Length - 3));
                        }
                        else
                        {
                            slTang = null;
                            if (cboPhanTramOrTien.SelectedIndex == 0) //tiền
                            {
                                giaG = double.Parse(txtGiaGiam.Text);
                            }
                            else //%
                            {
                                giaG = double.TryParse(txtGiaGiam.Text, out double giaGiam) && double.TryParse(lbGiaSP.Text.Substring(0, lbGiaSP.Text.Length - 3), out double giaSP) ? (giaGiam * giaSP) / 100 : 0;

                            }
                        }
                        string dvg;
                        if (cboPhanTramOrTien.SelectedIndex == 0)
                            dvg = "Tiền";
                        else
                            dvg = "Phần trăm";

                        KhuyenMaiDTO km = new KhuyenMaiDTO(txtMaKM.Text, txtTenKM.Text, MaNhomSPMua, MaNhomSPTang, int.Parse(txtSLMua.Text), slTang, dtpNgayBD.Value, dtpNgayKT.Value, giaG, dvg);
                        kmBUL.themKhuyenMai(km);



                        // Đánh dấu TransactionScope là hoàn thành
                        scope.Complete();
                        MessageBox.Show("Thêm thành công!", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);

                        //xoaTextBox();
                        anHien(false);
                        btnXemDS.Enabled = true;
                        btnThemKM.Enabled = true;
                        btnSuaKM.Enabled = true;
                        btnXoaKM.Enabled = true;
                        btnHuy.Enabled = true;


                    }
                    catch (Exception ex)
                    {
                        // Nếu có lỗi, transaction sẽ tự động rollback
                        MessageBox.Show(ex.Message, "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }
        }


        void suaKM()
        {
            if (kiemTraDuLieuHopLe())
            {
                using (TransactionScope scope = new TransactionScope())
                {
                    try
                    {
                        //Tạo lại nhóm mua
                        List<CTNhomSanPhamKMDTO> nhom1 = nhomSPKMBUL.layMotNhomSanPhamKM(MaNhomSPMua);
                        foreach (CTNhomSanPhamKMDTO n in nhom1)
                            ctNhomSPKMBul.xoaSanPham(n);

                        foreach (SanPhamDTO sp in lstSanPhamMua)
                        {
                            CTNhomSanPhamKMDTO ctNhom1 = new CTNhomSanPhamKMDTO(MaNhomSPMua, sp.MaSP);
                            ctNhomSPKMBul.themSanPham(ctNhom1);
                        }

                        //Tạo lại nhóm tặng
                        List<CTNhomSanPhamKMDTO> nhom2 = nhomSPKMBUL.layMotNhomSanPhamKM(MaNhomSPTang);
                        foreach (CTNhomSanPhamKMDTO n in nhom2)
                            ctNhomSPKMBul.xoaSanPham(n);

                        foreach (SanPhamDTO sp in lstSanPhamTang)
                        {
                            CTNhomSanPhamKMDTO ctNhom2 = new CTNhomSanPhamKMDTO(MaNhomSPTang, sp.MaSP);
                            ctNhomSPKMBul.themSanPham(ctNhom2);
                        }

                        //Tạo khuyến mãi
                        int? slTang;
                        double giaG;
                        if (rdTangHang.Checked)
                        {
                            slTang = int.Parse(txtSLTang.Text);
                            giaG = double.Parse(lbGiaGiamTuongUng.Text.Substring(0, lbGiaSP.Text.Length - 3));
                        }
                        else
                        {
                            slTang = null;
                            if (cboPhanTramOrTien.SelectedIndex == 0) //tiền
                            {
                                giaG = double.Parse(txtGiaGiam.Text);
                            }
                            else //%
                            {
                                giaG = double.TryParse(txtGiaGiam.Text, out double giaGiam) && double.TryParse(lbGiaSP.Text.Substring(0, lbGiaSP.Text.Length - 3), out double giaSP) ? (giaGiam * giaSP) / 100 : 0;

                            }
                        }

                        string dvg;
                        if (cboPhanTramOrTien.SelectedIndex == 0)
                            dvg = "Tiền";
                        else
                            dvg = "Phần trăm";

                        KhuyenMaiDTO km = new KhuyenMaiDTO(txtMaKM.Text, txtTenKM.Text, MaNhomSPMua, MaNhomSPTang, int.Parse(txtSLMua.Text), slTang, dtpNgayBD.Value, dtpNgayKT.Value, giaG, dvg);
                        kmBUL.suaKhuyenMai(km);



                        // Đánh dấu TransactionScope là hoàn thành
                        scope.Complete();
                        MessageBox.Show("Sửa thành công!", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);

                        //xoaTextBox();
                        anHien(false);
                        btnXemDS.Enabled = true;
                        btnThemKM.Enabled = true;
                        btnSuaKM.Enabled = true;
                        btnXoaKM.Enabled = true;
                        btnHuy.Enabled = true;


                    }
                    catch (Exception ex)
                    {
                        // Nếu có lỗi, transaction sẽ tự động rollback
                        MessageBox.Show(ex.Message, "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }
        }



        void xoaKM()
        {
            if (kiemTraDuLieuHopLe())
            {
                using (TransactionScope scope = new TransactionScope())
                {
                    try
                    {

                        //Xóa nhóm mua
                        List<CTNhomSanPhamKMDTO> nhom1 = nhomSPKMBUL.layMotNhomSanPhamKM(MaNhomSPMua);
                        foreach (CTNhomSanPhamKMDTO n in nhom1)
                            ctNhomSPKMBul.xoaSanPham(n);

                        //Xóa nhóm tặng
                        List<CTNhomSanPhamKMDTO> nhom2 = nhomSPKMBUL.layMotNhomSanPhamKM(MaNhomSPTang);
                        foreach (CTNhomSanPhamKMDTO n in nhom2)
                            ctNhomSPKMBul.xoaSanPham(n);

                        //Xóa khuyến mãi                       
                        kmBUL.xoaKhuyenMai(txtMaKM.Text);

                        //Xóa nhóm
                        nhomSPKMBUL.xoaSanPham(MaNhomSPMua);
                        nhomSPKMBUL.xoaSanPham(MaNhomSPTang);


                        // Đánh dấu TransactionScope là hoàn thành
                        scope.Complete();
                        MessageBox.Show("Xóa thành công!", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);

                        xoaTextBox();
                        anHien(false);
                        btnXemDS.Enabled = true;
                        btnThemKM.Enabled = true;
                        btnSuaKM.Enabled = true;
                        btnXoaKM.Enabled = true;
                        btnHuy.Enabled = true;
                        if (dgvSPMua.Rows.Count > 0)
                        {
                            dgvSPMua.DataSource = null;
                            dgvSPMua.Rows.Clear();
                        }
                        if (dgvSPTang.Rows.Count > 0)
                        {
                            dgvSPTang.DataSource = null;
                            dgvSPTang.Rows.Clear();
                        }

                    }
                    catch (Exception ex)
                    {
                        // Nếu có lỗi, transaction sẽ tự động rollback
                        MessageBox.Show(ex.Message, "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }
        }



        private void btnLuuKm_Click(object sender, System.EventArgs e)
        {
            message.Buttons = MessageDialogButtons.YesNo;
            message.Icon = MessageDialogIcon.Question;
            message.Parent = this.ParentForm;
            DialogResult r = message.Show("Bạn có chắc chắn muốn " + tacVu + " không?", "Thông Báo");

            if (tacVu == "thêm" && r == DialogResult.Yes)
                themKM();
            else if (tacVu == "sửa" && r == DialogResult.Yes)
                suaKM();
            else if (tacVu == "xóa" && r == DialogResult.Yes)
                xoaKM();


        }

        private void btnSuaKM_Click(object sender, EventArgs e)
        {
            anHien(true);
            tacVu = "sửa";
            btnSuaKM.Enabled = false;
            btnThemKM.Enabled = false;
            btnXoaKM.Enabled = false;
            //rdGiamTien.Enabled = false;
            //rdTangHang.Enabled = false;
            if (rdGiamTien.Checked)
            {
                txtSLTang.Enabled = false;
                btnThemSPTang.Enabled = false;
                rdTangHang.Enabled = false;
            }
            else
            {
                txtGiaGiam.Enabled = false;
                cboPhanTramOrTien.Enabled = false;
                rdGiamTien.Enabled = false;
            }

        }

        private void dgvSPMua_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Right)
            {
                // Lấy tọa độ chuột và xác định dòng trong DataGridView
                DataGridView.HitTestInfo hitTestInfo = dgvSPMua.HitTest(e.X, e.Y);
                if (hitTestInfo.RowIndex >= 0)
                {
                    dgvSPMua.ClearSelection();
                    dgvSPMua.Rows[hitTestInfo.RowIndex].Selected = true;
                }


                // Tạo ContextMenuStrip
                ContextMenuStrip contextMenu = new ContextMenuStrip();
                ToolStripMenuItem deleteMenuItem = new ToolStripMenuItem("Xóa sản phẩm");
                contextMenu.Items.Add(deleteMenuItem);

                // Gán ContextMenuStrip vào DataGridView
                dgvSPMua.ContextMenuStrip = contextMenu;

                // Xử lý sự kiện khi click vào
                deleteMenuItem.Click += DeleteSanPhamMua_Click;
            }
        }

        private void dgvSPTang_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Right)
            {
                // Lấy tọa độ chuột và xác định dòng trong DataGridView
                DataGridView.HitTestInfo hitTestInfo = dgvSPTang.HitTest(e.X, e.Y);
                if (hitTestInfo.RowIndex >= 0)
                {
                    dgvSPTang.ClearSelection();
                    dgvSPTang.Rows[hitTestInfo.RowIndex].Selected = true;
                }

                // Tạo ContextMenuStrip
                ContextMenuStrip contextMenu = new ContextMenuStrip();
                ToolStripMenuItem deleteMenuItem = new ToolStripMenuItem("Xóa sản phâm");
                contextMenu.Items.Add(deleteMenuItem);

                // Gán ContextMenuStrip vào DataGridView
                dgvSPTang.ContextMenuStrip = contextMenu;

                // Xử lý sự kiện khi click vào item "Xóa học sinh"
                deleteMenuItem.Click += DeleteSanPhamTang_Click;
            }
        }


        private void DeleteSanPhamMua_Click(object sender, EventArgs e)
        {
            if (dgvSPMua.SelectedRows.Count > 0)
            {
                // Lấy dòng được chọn
                DataGridViewRow selectedRow = dgvSPMua.SelectedRows[0];
                SanPhamDTO selected = (SanPhamDTO)selectedRow.DataBoundItem;

                // Hiển thị xác nhận xóa
                message.Buttons = MessageDialogButtons.YesNo;
                message.Icon = MessageDialogIcon.Question;
                message.Parent = this.ParentForm;
                DialogResult r = message.Show("Xóa sản phẩm '" + selected.TenSP + "'?", "Thông Báo");

                if (r == DialogResult.Yes)
                {
                    lstSanPhamMua.Remove(selected);

                    loadDGVSanPhamMua(lstSanPhamMua);
                }
            }
        }


        private void DeleteSanPhamTang_Click(object sender, EventArgs e)
        {
            if (dgvSPTang.SelectedRows.Count > 0)
            {
                // Lấy dòng được chọn
                DataGridViewRow selectedRow = dgvSPTang.SelectedRows[0];
                SanPhamDTO selected = (SanPhamDTO)selectedRow.DataBoundItem;

                // Hiển thị xác nhận xóa
                message.Buttons = MessageDialogButtons.YesNo;
                message.Icon = MessageDialogIcon.Question;
                message.Parent = this.ParentForm;
                DialogResult r = message.Show("Xóa sản phẩm '" + selected.TenSP + "'?", "Thông Báo");

                if (r == DialogResult.Yes)
                {
                    lstSanPhamTang.Remove(selected);
                    loadDGVSanPhamTang(lstSanPhamTang);
                }
            }
        }

        private void btnHuy_Click(object sender, EventArgs e)
        {
            anHien(false);
            xoaTextBox();
            lstSanPhamMua.Clear();
            lstSanPhamTang.Clear();
            if (dgvSPMua.Rows.Count > 0)
            {
                dgvSPMua.DataSource = null;
                dgvSPMua.Rows.Clear();
            }
            if (dgvSPTang.Rows.Count > 0)
            {
                dgvSPTang.DataSource = null;
                dgvSPTang.Rows.Clear();
            }
            btnXemDS.Enabled = true;
            btnThemKM.Enabled = true;
            btnHuy.Enabled = true;
            cboPhanTramOrTien.SelectedIndex = 0;
        }

        private void btnXoaKM_Click(object sender, EventArgs e)
        {
            tacVu = "xóa";
            btnSuaKM.Enabled = false;
            btnThemKM.Enabled = false;
            btnXoaKM.Enabled = false;
            btnLuuKm.Enabled = true;
            btnHuy.Enabled = true;

        }
    }
}
