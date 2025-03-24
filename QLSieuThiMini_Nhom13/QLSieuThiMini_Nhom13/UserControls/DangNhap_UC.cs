using Guna.UI2.WinForms;
using System;
using System.Windows.Forms;

namespace QLSieuThiMini_Nhom13.UserControls
{
    public partial class DangNhap_UC : UserControl
    {
        Guna2MessageDialog message;
        public DangNhap_UC()
        {
            InitializeComponent();

            message = new Guna2MessageDialog();
            message.Style = MessageDialogStyle.Light;
        }

        public delegate void SubmitClickedHandler(object sender, EventArgs e); // định nghĩa delegate phục vụ cho event
        public event SubmitClickedHandler SubmitClicked; // định nghĩa event SubmitClicked cho control

        // định nghĩa hàm xử lý sự kiện SubmitClicked
        protected virtual void OnSubmitClicked(object sender, EventArgs e)
        {
            if (SubmitClicked != null) SubmitClicked(sender, e);
        }

        private void btnDangNhap_Click(object sender, EventArgs e)
        {
            message.Parent = this.ParentForm;
            message.Icon = MessageDialogIcon.Error;
            message.Buttons = MessageDialogButtons.OK;
            if (txtTenDN.Text.Length == 0)
            {
                message.Show("Hãy nhập tên đăng nhập!"); return;
            }
            if (txtMatKhau.Text.Length == 0)
            {
                message.Show("Hãy nhập mật khẩu!"); return;
            }
            OnSubmitClicked(sender, e);
        }

        private void ckbHienThi_CheckedChanged(object sender, EventArgs e)
        {
            if (ckbHienThi.Checked)
                txtMatKhau.PasswordChar = (char)0;
            else
                txtMatKhau.PasswordChar = '●';
        }


        public delegate void CancelClickedHandler(object sender, EventArgs e); // định nghĩa delegate phục vụ cho event
        public event CancelClickedHandler CancelClicked; // định nghĩa event SubmitClicked cho control

        // định nghĩa hàm xử lý sự kiện SubmitClicked
        protected virtual void OnCancelClicked(object sender, EventArgs e)
        {
            if (CancelClicked != null) CancelClicked(sender, e);
        }

        private void btnThoat_Click(object sender, EventArgs e)
        {
            message.Parent = this.ParentForm;
            message.Icon = MessageDialogIcon.Question;
            message.Buttons = MessageDialogButtons.YesNo;
            DialogResult rs = message.Show("Bạn có muốn thoát?", "Thông báo");
            if (rs == DialogResult.Yes)
            {
                OnCancelClicked(sender, e);
            }
        }

        public string TenDN
        {
            get { return txtTenDN.Text; }
            set { txtTenDN.Text = value; }
        }

        public string MatKhau
        {
            get { return txtMatKhau.Text; }
            set { txtMatKhau.Text = value; }
        }

        public delegate void ChangePasswordClickedHandler(object sender, EventArgs e); // định nghĩa delegate phục vụ cho event
        public event ChangePasswordClickedHandler ChangePass; // định nghĩa event SubmitClicked cho control


        // định nghĩa hàm xử lý sự kiện SubmitClicked
        protected virtual void ChangePassClicked(object sender, EventArgs e)
        {
            if (ChangePass != null) ChangePass(sender, e);
        }
        private void btnDoiMK_Click(object sender, EventArgs e)
        {
            ChangePassClicked(sender, e);
        }
    }
}
