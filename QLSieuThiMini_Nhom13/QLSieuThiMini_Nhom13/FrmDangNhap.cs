using BUL;
using DTO;
using Guna.UI2.WinForms;
using System;
using System.Windows.Forms;

namespace QLSieuThiMini_Nhom13
{
    public partial class FrmDangNhap : Form
    {
        NguoiDungBUL NguoiDungBUL;
        Guna2MessageDialog message;

        public FrmDangNhap()
        {
            InitializeComponent();

            NguoiDungBUL = new NguoiDungBUL();
            message = new Guna2MessageDialog();
            message.Style = MessageDialogStyle.Light;
            message.Parent = this;
            //txtMatKhau.UseSystemPasswordChar = true;

            //Guna.UI2.WinForms.Guna2Transition gunaTransition = new Guna.UI2.WinForms.Guna2Transition();
            //gunaTransition.AnimationType = Guna.UI2.AnimatorNS.AnimationType.HorizSlide;
            //gunaTransition.Show(btnDangNhap);
            //gunaTransition.Show(btnThoat);
            //gunaTransition.Show(btnCauHinh);

            // loading
            //Guna2ProgressIndicator gunaProgressIndicator = new Guna2ProgressIndicator();
            //gunaProgressIndicator.CircleSize = 1F;
            //gunaProgressIndicator.Location = new Point(100, 100);
            //gunaProgressIndicator.Size = new Size(60, 60);
            //gunaProgressIndicator.ProgressColor = Color.BlueViolet;
            //gunaProgressIndicator.Start();
            //this.Controls.Add(gunaProgressIndicator);
        }

        private void btnDangNhap_Click(object sender, EventArgs e)
        {
            //string tentk = txtTenDN.Text;
            //string matkhau = txtMatKhau.Text;

            //if (tentk.Length > 0 && matkhau.Length > 0)
            //{
            //    NguoiDungDTO nguoiDungDTO = NguoiDungBUL.dangNhap(tentk, matkhau);
            //    if (nguoiDungDTO.TenND == null)
            //    {
            //        message.Buttons = MessageDialogButtons.OK;
            //        message.Icon = MessageDialogIcon.Error;
            //        message.Show("Tên tài khoàn hoặc mật khẩu không đúng!", "Thông Báo");
            //        return;
            //    }

            //    if (nguoiDungDTO.HoatDong == 1)
            //    {
            //        FrmMain frmMain = new FrmMain();
            //        frmMain.Show();
            //        this.Hide();
            //    }
            //    else
            //    {
            //        message.Buttons = MessageDialogButtons.OK;
            //        message.Icon = MessageDialogIcon.Error;
            //        message.Show("Tài khoàn đã bị thu hồi!", "Thông Báo");
            //    }
            //}
            //else
            //{
            //    message.Buttons = MessageDialogButtons.OK;
            //    message.Icon = MessageDialogIcon.Warning;
            //    message.Show("Vui lòng nhập tài khoản và mật khẩu!", "Thông Báo");
            //}
        }

        private void ckbHienThi_CheckedChanged(object sender, Bunifu.UI.WinForms.BunifuCheckBox.CheckedChangedEventArgs e)
        {
            //if (ckbHienThi.Checked)
            //    txtMatKhau.PasswordChar = (char)0;
            //else
            //    txtMatKhau.PasswordChar = '●';
        }

        private void btnThoat_Click(object sender, EventArgs e)
        {
            message.Buttons = MessageDialogButtons.YesNo;
            message.Icon = MessageDialogIcon.Information;
            DialogResult result = message.Show("Bạn có chắc chắn muốn thoát?", "Xác nhận");
            if (result == DialogResult.Yes)
                this.Close();
        }

        private void FrmDangNhap_Load(object sender, EventArgs e)
        {

        }

        private void ckbHienThi_CheckedChanged(object sender, EventArgs e)
        {
            //if (ckbHienThi.Checked)
            //    txtMatKhau.PasswordChar = (char)0;
            //else
            //    txtMatKhau.PasswordChar = '●';
        }

        private void dangNhap_UC1_SubmitClicked(object sender, EventArgs e)
        {
            string tentk = dangNhap_UC1.TenDN;
            string matkhau = dangNhap_UC1.MatKhau;

            if (tentk.Length > 0 && matkhau.Length > 0)
            {
                NguoiDungDTO nguoiDungDTO = NguoiDungBUL.dangNhap(tentk, matkhau);
                if (nguoiDungDTO == null)
                {
                    message.Buttons = MessageDialogButtons.OK;
                    message.Icon = MessageDialogIcon.Error;
                    message.Show("Tên tài khoàn hoặc mật khẩu không đúng!", "Thông Báo");
                    return;
                }

                if (nguoiDungDTO.HoatDong == 1)
                {
                    FrmMain frmMain = new FrmMain(nguoiDungDTO.MaND, nguoiDungDTO.TenTK);
                    this.Hide();
                    frmMain.Show();
                    frmMain.DangXuat += f_DangXuat; // tạo sự kiện đăng xuất cho frmMain
                }
                else
                {
                    message.Buttons = MessageDialogButtons.OK;
                    message.Icon = MessageDialogIcon.Error;
                    message.Show("Tài khoàn đã bị thu hồi!", "Thông Báo");
                }
            }
            //else
            //{
            //    message.Buttons = MessageDialogButtons.OK;
            //    message.Icon = MessageDialogIcon.Warning;
            //    message.Show("Vui lòng nhập tài khoản và mật khẩu!", "Thông Báo");
            //}
        }


        private void f_DangXuat(object sender, EventArgs e)
        {
            (sender as FrmMain).isThoat = false;
            (sender as FrmMain).Close();
            this.Show();
            //txtTenDN.Clear();
            //txtMatKhau.Clear();
            dangNhap_UC1.TenDN = string.Empty;
            dangNhap_UC1.MatKhau = string.Empty;
        }

        private void dangNhap_UC1_CancelClicked(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void dangNhap_UC1_ChangePass(object sender, EventArgs e)
        {
            FrmDoiMatKhau f = new FrmDoiMatKhau();
            f.Show();
        }

        private void dangNhap_UC1_Load(object sender, EventArgs e)
        {

        }
    }
}
