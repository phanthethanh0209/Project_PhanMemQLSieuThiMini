using BUL;
using Guna.UI2.WinForms;
using System;
using System.Collections.Generic;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Runtime.InteropServices;
using System.Windows.Forms;

namespace QLSieuThiMini_Nhom13
{
    public partial class FrmMain : Form
    {
        ND_NhomNDBUL nD_NhomNDBUL;
        PhanQuyenBUL phanQuyenBUL;
        string TenTK;
        string maND;
        public bool isThoat = true;

        Guna2MessageDialog message;
        public FrmMain(string maND, string tentk)
        {
            InitializeComponent();
            message = new Guna2MessageDialog();
            message.Style = MessageDialogStyle.Light;
            message.Parent = this;

            CollapseMenu();
            this.Padding = new Padding(borderSize);//Border size
            this.BackColor = Color.FromArgb(98, 102, 244);//Border color

            nD_NhomNDBUL = new ND_NhomNDBUL();
            phanQuyenBUL = new PhanQuyenBUL();

            TenTK = tentk;
            txtTenDN.Text = tentk;
            this.maND = maND;
        }

        //Fields
        private int borderSize = 2;
        private Size formSize;

        private void FrmMain_Load(object sender, System.EventArgs e)
        {
            formSize = this.ClientSize;
            bool enabled = false;
            // bool enabled = false;
            List<string> lstMaNhom = nD_NhomNDBUL.layDSMaNhomTuTenTK(TenTK);
            foreach (string maNhom in lstMaNhom)
            {
                DataTable dsQuyen = phanQuyenBUL.layDSTenManHinh(maNhom);
                foreach (DataRow mh in dsQuyen.Rows)
                {
                    if ((int)mh[2] == 1) //mh[2]=1 là có quyền
                        enabled = true;
                    FindMenuPhanQuyen(panelMenu, mh[4].ToString(), enabled); //mh[4] là tên màn hình

                }
            }
        }


        // Hàm duyệt các button menu cấp 1
        private void FindMenuPhanQuyen(Panel mnuItems, string pScreenName, bool pEnable)
        {
            foreach (Control menu in mnuItems.Controls)
            {
                if (menu is Guna2Button buttonMenu)
                {
                    if (buttonMenu.ContextMenuStrip is Guna2ContextMenuStrip guna2MenuStrip)
                    {
                        // Duyệt qua các item trong ContextMenuStrip (cấp 2 trở đi)
                        FindMenuPhanQuyen2(guna2MenuStrip.Items, pScreenName, pEnable);

                        // Cập nhật quyền cho button dựa trên trạng thái của các mục trong ContextMenuStrip
                        buttonMenu.Enabled = CheckAllMenuChildVisible(guna2MenuStrip.Items);
                        buttonMenu.Visible = buttonMenu.Enabled; // Chỉ hiển thị button nếu nó được bật
                    }
                    else if (string.Equals(pScreenName, buttonMenu.Tag as string))
                    {
                        // Nếu không có Guna2ContextMenuStrip, kiểm tra và cập nhật quyền cho buttonMenu
                        buttonMenu.Enabled = pEnable;
                        buttonMenu.Visible = pEnable;
                    }

                }

            }
        }

        // Hàm đệ quy để duyệt các menu con từ cấp 2 trở đi
        private void FindMenuPhanQuyen2(ToolStripItemCollection mnuItems, string pScreenName, bool pEnable)
        {
            foreach (ToolStripItem menu in mnuItems)
            {
                // Kiểm tra nếu là ToolStripMenuItem và có DropDownItems (menu con)
                if (menu is ToolStripMenuItem menuItem)
                {
                    // Nếu menu có các item con, đệ quy kiểm tra các item con này
                    if (menuItem.DropDownItems.Count > 0)
                    {
                        FindMenuPhanQuyen2(menuItem.DropDownItems, pScreenName, pEnable);

                        // Cập nhật trạng thái Enabled và Visible cho ToolStripMenuItem
                        menuItem.Enabled = CheckAllMenuChildVisible(menuItem.DropDownItems);
                        menuItem.Visible = menuItem.Enabled; // Mục cha chỉ hiển thị nếu có mục con nào được bật
                    }

                    // Nếu pScreenName khớp với Tag của menuItem, cập nhật quyền cho menuItem
                    else if (string.Equals(pScreenName, menuItem.Tag as string))
                    {
                        menuItem.Enabled = pEnable;
                        menuItem.Visible = pEnable;
                    }
                }
            }
        }

        // Hàm kiểm tra tất cả các item con trong một menu có Visible hay không
        private bool CheckAllMenuChildVisible(ToolStripItemCollection mnuItems)
        {
            // Kiểm tra các mục con trong menu, nếu có ít nhất một mục con được bật, trả về true
            foreach (ToolStripItem menuItem in mnuItems)
            {
                if (menuItem is ToolStripMenuItem item)
                {
                    if (item.Enabled)
                    {
                        return true;
                    }
                }
                else if (menuItem is ToolStripSeparator)
                {
                    // Bỏ qua các ToolStripSeparator (dấu phân cách)
                    continue;
                }
            }
            return false;
        }




        [DllImport("user32.DLL", EntryPoint = "ReleaseCapture")]
        private extern static void ReleaseCapture();
        [DllImport("user32.DLL", EntryPoint = "SendMessage")]
        private extern static void SendMessage(System.IntPtr hWnd, int wMsg, int wParam, int lParam);

        private void panelTitleBar_MouseDown(object sender, MouseEventArgs e)
        {
            ReleaseCapture();
            SendMessage(this.Handle, 0x112, 0xf012, 0);
        }


        //Private methods
        private void AdjustForm()
        {
            switch (this.WindowState)
            {
                case FormWindowState.Maximized: //Maximized form (After)
                    this.Padding = new Padding(8, 8, 8, 0);
                    break;
                case FormWindowState.Normal: //Restored form (After)
                    if (this.Padding.Top != borderSize)
                        this.Padding = new Padding(borderSize);
                    break;
            }
        }

        private void CollapseMenu()
        {
            if (this.panelMenu.Width > 200) //Collapse menu
            {
                panelMenu.Width = 100;
                //bunifuPictureBox1.Visible = false;
                //btnMenu.Dock = DockStyle.Top;
                //btnMenu.Anchor = AnchorStyles.None;
                btnMenu.Left = (panelMenu.Width / 2) - 25;
                foreach (Guna2Button menuButton in panelMenu.Controls.OfType<Guna2Button>())
                {
                    menuButton.Text = "";
                    menuButton.ImageAlign = HorizontalAlignment.Center;
                    //menuButton.IconLeftAlign = ContentAlignment.MiddleCenter;
                    menuButton.Padding = new Padding(0);
                }
            }
            else
            { //Expand menu
                panelMenu.Width = 230;
                //bunifuPictureBox1.Visible = true;
                //btnMenu.Dock = DockStyle.None;
                btnMenu.Left = panelMenu.Width - 50;
                foreach (Guna2Button menuButton in panelMenu.Controls.OfType<Guna2Button>())
                {
                    menuButton.Text = "   " + menuButton.Tag.ToString();
                    //menuButton.IconLeftAlign = ContentAlignment.MiddleLeft;
                    menuButton.ImageAlign = HorizontalAlignment.Left;
                    menuButton.Padding = new Padding(10, 0, 0, 0);
                }
            }
        }

        private void Open_DropdownMenu(ContextMenuStrip dropdownMenu, object sender)
        {
            Control control = (Control)sender;
            dropdownMenu.VisibleChanged += new EventHandler((sender2, ev)
                => DropdownMenu_VisibleChanged(sender2, ev, control));
            dropdownMenu.Show(control, control.Width, 0);
        }

        private void DropdownMenu_VisibleChanged(object sender2, EventArgs ev, Control control)
        {
            ContextMenuStrip dropdownMenu = (ContextMenuStrip)sender2;
            if (dropdownMenu.Visible)
            {
                control.BackColor = Color.FromArgb(159, 161, 224);
            }
            else
            {
                control.BackColor = Color.FromArgb(98, 102, 224);
            }
        }

        private void btnHeThong_Click(object sender, EventArgs e)
        {
            Open_DropdownMenu(MenuItemHeThong, sender);
        }

        private void btnMenu_Click(object sender, EventArgs e)
        {
            CollapseMenu();
        }

        private Form activeForm = null;
        private void openChildForm(Form childForm)
        {
            if (activeForm != null) activeForm.Close();
            activeForm = childForm;
            childForm.TopLevel = false;
            childForm.FormBorderStyle = FormBorderStyle.None;
            childForm.Dock = DockStyle.Fill;
            panelChildForm.Controls.Add(childForm);
            panelChildForm.Tag = childForm;
            childForm.BringToFront();
            childForm.Show();
        }

        private void btnThoat_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void ManHinhToolStripMenuItem_Click(object sender, EventArgs e)
        {
            openChildForm(new FrmManHinh());
        }

        private void NguoiDungToolStripMenuItem_Click(object sender, EventArgs e)
        {
            openChildForm(new FrmNguoiDung());
        }

        private void NhomNguoiDungToolStripMenuItem_Click(object sender, EventArgs e)
        {
            openChildForm(new FrmNhomNguoiDung());
        }

        private void NDNhomNDToolStripMenuItem_Click(object sender, EventArgs e)
        {
            openChildForm(new FrmND_NhomND());

        }

        private void PhanQuyenToolStripMenuItem_Click(object sender, EventArgs e)
        {
            openChildForm(new FrmPhanQuyen());

        }

        private void btnKhuyenMai_Click(object sender, EventArgs e)
        {
            openChildForm(new FrmKhuyenMai());
        }

        private void btnNhaCC_Click(object sender, EventArgs e)
        {
            openChildForm(new FrmNhaCungCap());
        }

        private void btnPhieuNhap_Click(object sender, EventArgs e)
        {
            openChildForm(new FrmPhieuNhap(maND));
        }

        private void btnHoaDon_Click(object sender, EventArgs e)
        {
            //openChildForm(new FrmHoaDon());
            openChildForm(new FrmHoaDon(maND));
        }

        private void btnSanPham_Click(object sender, EventArgs e)
        {
            openChildForm(new FrmSanPham());
        }

        private void FrmMain_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (isThoat)
            {
                message.Buttons = MessageDialogButtons.YesNo;
                message.Icon = MessageDialogIcon.Question;
                message.Parent = this;
                DialogResult result = message.Show("Bạn có chắc chắn muốn thoát?", "Xác nhận");
                if (result == DialogResult.Yes)
                {
                    isThoat = false;
                    Application.Exit();
                }
                else
                {
                    e.Cancel = true; // Hủy sự kiện đóng Form
                }
            }
        }

        private void btnDanhMuc_Click(object sender, EventArgs e)
        {
            Open_DropdownMenu(MenuItemDanhMuc, sender);
        }

        private void btnLoaiSP_Click(object sender, EventArgs e)
        {
            openChildForm(new FrmLoaiSanPham());
        }

        private void btnKhachHang_Click(object sender, EventArgs e)
        {
            openChildForm(new FrmKhachHang());

        }

        private void btnThuongHieu_Click(object sender, EventArgs e)
        {
            openChildForm(new FrmThuongHieu());

        }

        private void btnDuDoan_Click(object sender, EventArgs e)
        {
            openChildForm(new FrmDuBaoDoanhThu());
        }

        private void btnBaoCao_Click(object sender, EventArgs e)
        {
            Open_DropdownMenu(MenuItemBaoCao, sender);

        }

        private void btnThongKe_Click(object sender, EventArgs e)
        {
            openChildForm(new FrmThongKe());
        }

        public event EventHandler DangXuat;

        private void btnDangXuat_Click(object sender, EventArgs e)
        {
        }

        private void btnDangXuat_Click_1(object sender, EventArgs e)
        {
            message.Buttons = MessageDialogButtons.YesNo;
            message.Icon = MessageDialogIcon.Question;
            message.Parent = this;

            //message.Parent = this.ParentForm;
            DialogResult result = message.Show("Bạn có muốn đăng xuất?", "Xác nhận");
            if (result == DialogResult.Yes)
            {
                isThoat = false;
                DangXuat(this, new EventArgs());
            }

        }



        //private async void ShowLoadingForm(Form f)
        //{
        //    Guna2WinProgressIndicator indicator = new Guna2WinProgressIndicator();
        //    indicator.Size = new Size(60, 60);
        //    indicator.Location = new Point(20, 20);
        //    indicator.CircleSize = 1.5f;
        //    indicator.BackColor = TransparencyKey;

        //    f.Controls.Add(indicator);
        //    f.Show();

        //    await Task.Delay(5000); // Mô phỏng thời gian tải dữ liệu
        //    f.Close();
        //}

    }
}
