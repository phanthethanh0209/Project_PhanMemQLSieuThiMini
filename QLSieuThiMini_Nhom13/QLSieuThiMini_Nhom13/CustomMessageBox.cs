using Guna.UI2.WinForms;
using System.Windows.Forms;

namespace QLMamNon
{
    public static class CustomMessageBox
    {
        private static Guna2MessageDialog gunaMessage = new Guna2MessageDialog
        {
            Style = MessageDialogStyle.Light, // Giao diện sáng
            Buttons = MessageDialogButtons.OK, // Mặc định chỉ có nút OK
            Icon = MessageDialogIcon.Information, // Biểu tượng mặc định
            Caption = "Thông báo" // Tiêu đề mặc định
        };

        public static DialogResult Show(Form parent, string text, string caption)
        {
            gunaMessage.Buttons = MessageDialogButtons.OK;
            gunaMessage.Icon = MessageDialogIcon.Information; // Biểu tượng mặc định
            gunaMessage.Caption = caption;
            gunaMessage.Parent = parent;
            return gunaMessage.Show(text);
        }

        public static DialogResult ShowError(Form parent, string text, string caption)
        {
            gunaMessage.Buttons = MessageDialogButtons.OK;
            gunaMessage.Icon = MessageDialogIcon.Error; // Biểu tượng mặc định
            gunaMessage.Caption = caption;
            gunaMessage.Parent = parent;
            return gunaMessage.Show(text);
        }


        public static DialogResult ShowQuesstion(Form parent, string text, string caption)
        {
            gunaMessage.Buttons = MessageDialogButtons.YesNo;
            gunaMessage.Icon = MessageDialogIcon.Question; // Biểu tượng mặc định
            gunaMessage.Caption = caption;
            gunaMessage.Parent = parent;
            return gunaMessage.Show(text);
        }


    }
}
