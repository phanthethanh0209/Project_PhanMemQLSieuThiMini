namespace QLSieuThiMini_Nhom13
{
    partial class FrmCauHinh
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
            this.cbo_Database = new System.Windows.Forms.ComboBox();
            this.label4 = new System.Windows.Forms.Label();
            this.cbo_Servername = new System.Windows.Forms.ComboBox();
            this.label3 = new System.Windows.Forms.Label();
            this.btn_Reset = new System.Windows.Forms.Button();
            this.btn_Save = new System.Windows.Forms.Button();
            this.txt_Password = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.txt_Username = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // cbo_Database
            // 
            this.cbo_Database.FormattingEnabled = true;
            this.cbo_Database.Location = new System.Drawing.Point(188, 208);
            this.cbo_Database.Margin = new System.Windows.Forms.Padding(4);
            this.cbo_Database.Name = "cbo_Database";
            this.cbo_Database.Size = new System.Drawing.Size(312, 24);
            this.cbo_Database.TabIndex = 38;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(70, 208);
            this.label4.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(67, 16);
            this.label4.TabIndex = 37;
            this.label4.Text = "Database";
            // 
            // cbo_Servername
            // 
            this.cbo_Servername.FormattingEnabled = true;
            this.cbo_Servername.Location = new System.Drawing.Point(188, 30);
            this.cbo_Servername.Margin = new System.Windows.Forms.Padding(4);
            this.cbo_Servername.Name = "cbo_Servername";
            this.cbo_Servername.Size = new System.Drawing.Size(312, 24);
            this.cbo_Servername.TabIndex = 36;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(70, 30);
            this.label3.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(47, 16);
            this.label3.TabIndex = 35;
            this.label3.Text = "Server";
            // 
            // btn_Reset
            // 
            this.btn_Reset.Location = new System.Drawing.Point(405, 266);
            this.btn_Reset.Margin = new System.Windows.Forms.Padding(4);
            this.btn_Reset.Name = "btn_Reset";
            this.btn_Reset.Size = new System.Drawing.Size(100, 28);
            this.btn_Reset.TabIndex = 34;
            this.btn_Reset.Text = "Nhập lại";
            this.btn_Reset.UseVisualStyleBackColor = true;
            // 
            // btn_Save
            // 
            this.btn_Save.Location = new System.Drawing.Point(74, 266);
            this.btn_Save.Margin = new System.Windows.Forms.Padding(4);
            this.btn_Save.Name = "btn_Save";
            this.btn_Save.Size = new System.Drawing.Size(100, 28);
            this.btn_Save.TabIndex = 33;
            this.btn_Save.Text = "Save";
            this.btn_Save.UseVisualStyleBackColor = true;
            // 
            // txt_Password
            // 
            this.txt_Password.Location = new System.Drawing.Point(188, 148);
            this.txt_Password.Margin = new System.Windows.Forms.Padding(4);
            this.txt_Password.Name = "txt_Password";
            this.txt_Password.Size = new System.Drawing.Size(312, 22);
            this.txt_Password.TabIndex = 32;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(70, 88);
            this.label2.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(70, 16);
            this.label2.TabIndex = 31;
            this.label2.Text = "Username";
            // 
            // txt_Username
            // 
            this.txt_Username.Location = new System.Drawing.Point(188, 84);
            this.txt_Username.Margin = new System.Windows.Forms.Padding(4);
            this.txt_Username.Name = "txt_Username";
            this.txt_Username.Size = new System.Drawing.Size(312, 22);
            this.txt_Username.TabIndex = 30;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(70, 157);
            this.label1.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(67, 16);
            this.label1.TabIndex = 29;
            this.label1.Text = "Password";
            // 
            // FrmCauHinh
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(611, 328);
            this.Controls.Add(this.cbo_Database);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.cbo_Servername);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.btn_Reset);
            this.Controls.Add(this.btn_Save);
            this.Controls.Add(this.txt_Password);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.txt_Username);
            this.Controls.Add(this.label1);
            this.Name = "FrmCauHinh";
            this.Text = "FrmCauHinh";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ComboBox cbo_Database;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.ComboBox cbo_Servername;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Button btn_Reset;
        private System.Windows.Forms.Button btn_Save;
        private System.Windows.Forms.TextBox txt_Password;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox txt_Username;
        private System.Windows.Forms.Label label1;
    }
}