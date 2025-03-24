namespace QLSieuThiMini_Nhom13
{
    partial class FrmDangNhap
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FrmDangNhap));
            this.guna2AnimateWindow1 = new Guna.UI2.WinForms.Guna2AnimateWindow(this.components);
            this.dangNhap_UC1 = new QLSieuThiMini_Nhom13.UserControls.DangNhap_UC();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // guna2AnimateWindow1
            // 
            this.guna2AnimateWindow1.TargetForm = this;
            // 
            // dangNhap_UC1
            // 
            this.dangNhap_UC1.Location = new System.Drawing.Point(752, 177);
            this.dangNhap_UC1.MatKhau = "";
            this.dangNhap_UC1.Name = "dangNhap_UC1";
            this.dangNhap_UC1.Size = new System.Drawing.Size(431, 282);
            this.dangNhap_UC1.TabIndex = 34;
            this.dangNhap_UC1.TenDN = "";
            this.dangNhap_UC1.SubmitClicked += new QLSieuThiMini_Nhom13.UserControls.DangNhap_UC.SubmitClickedHandler(this.dangNhap_UC1_SubmitClicked);
            this.dangNhap_UC1.CancelClicked += new QLSieuThiMini_Nhom13.UserControls.DangNhap_UC.CancelClickedHandler(this.dangNhap_UC1_CancelClicked);
            this.dangNhap_UC1.ChangePass += new QLSieuThiMini_Nhom13.UserControls.DangNhap_UC.ChangePasswordClickedHandler(this.dangNhap_UC1_ChangePass);
            this.dangNhap_UC1.Load += new System.EventHandler(this.dangNhap_UC1_Load);
            // 
            // pictureBox1
            // 
            this.pictureBox1.Dock = System.Windows.Forms.DockStyle.Left;
            this.pictureBox1.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox1.Image")));
            this.pictureBox1.Location = new System.Drawing.Point(0, 0);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(740, 593);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox1.TabIndex = 33;
            this.pictureBox1.TabStop = false;
            // 
            // FrmDangNhap
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1195, 593);
            this.Controls.Add(this.dangNhap_UC1);
            this.Controls.Add(this.pictureBox1);
            this.Cursor = System.Windows.Forms.Cursors.Default;
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "FrmDangNhap";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "FrmDangNhap";
            this.Load += new System.EventHandler(this.FrmDangNhap_Load);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.PictureBox pictureBox1;
        private Guna.UI2.WinForms.Guna2AnimateWindow guna2AnimateWindow1;
        private UserControls.DangNhap_UC dangNhap_UC1;
    }
}