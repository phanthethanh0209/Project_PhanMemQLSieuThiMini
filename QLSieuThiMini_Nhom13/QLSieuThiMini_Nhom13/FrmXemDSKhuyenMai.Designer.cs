namespace QLSieuThiMini_Nhom13
{
    partial class FrmXemDSKhuyenMai
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            this.tableLayoutPanel7 = new System.Windows.Forms.TableLayoutPanel();
            this.guna2HtmlLabel2 = new Guna.UI2.WinForms.Guna2HtmlLabel();
            this.guna2HtmlLabel1 = new Guna.UI2.WinForms.Guna2HtmlLabel();
            this.btnChon = new Guna.UI2.WinForms.Guna2GradientButton();
            this.dtpNgayKT = new Guna.UI2.WinForms.Guna2DateTimePicker();
            this.dtpNgayBD = new Guna.UI2.WinForms.Guna2DateTimePicker();
            this.guna2GroupBox1 = new Guna.UI2.WinForms.Guna2GroupBox();
            this.dgvKM = new Guna.UI2.WinForms.Guna2DataGridView();
            this.txtTimKiemKM = new Guna.UI2.WinForms.Guna2TextBox();
            this.btnLoc = new Guna.UI2.WinForms.Guna2GradientButton();
            this.MaKM = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.TenKM = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.tableLayoutPanel7.SuspendLayout();
            this.guna2GroupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvKM)).BeginInit();
            this.SuspendLayout();
            // 
            // tableLayoutPanel7
            // 
            this.tableLayoutPanel7.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.tableLayoutPanel7.ColumnCount = 3;
            this.tableLayoutPanel7.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 25F));
            this.tableLayoutPanel7.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 25F));
            this.tableLayoutPanel7.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 25F));
            this.tableLayoutPanel7.Controls.Add(this.guna2HtmlLabel2, 1, 0);
            this.tableLayoutPanel7.Controls.Add(this.guna2HtmlLabel1, 0, 0);
            this.tableLayoutPanel7.Controls.Add(this.dtpNgayBD, 0, 1);
            this.tableLayoutPanel7.Controls.Add(this.dtpNgayKT, 1, 1);
            this.tableLayoutPanel7.Controls.Add(this.btnLoc, 2, 1);
            this.tableLayoutPanel7.Location = new System.Drawing.Point(14, 21);
            this.tableLayoutPanel7.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.tableLayoutPanel7.Name = "tableLayoutPanel7";
            this.tableLayoutPanel7.RowCount = 2;
            this.tableLayoutPanel7.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel7.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel7.Size = new System.Drawing.Size(1001, 104);
            this.tableLayoutPanel7.TabIndex = 64;
            // 
            // guna2HtmlLabel2
            // 
            this.guna2HtmlLabel2.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.guna2HtmlLabel2.BackColor = System.Drawing.Color.Transparent;
            this.guna2HtmlLabel2.Font = new System.Drawing.Font("Tahoma", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.guna2HtmlLabel2.Location = new System.Drawing.Point(436, 13);
            this.guna2HtmlLabel2.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.guna2HtmlLabel2.Name = "guna2HtmlLabel2";
            this.guna2HtmlLabel2.Size = new System.Drawing.Size(126, 26);
            this.guna2HtmlLabel2.TabIndex = 67;
            this.guna2HtmlLabel2.Text = "Ngày kết thúc";
            // 
            // guna2HtmlLabel1
            // 
            this.guna2HtmlLabel1.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.guna2HtmlLabel1.BackColor = System.Drawing.Color.Transparent;
            this.guna2HtmlLabel1.Font = new System.Drawing.Font("Tahoma", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.guna2HtmlLabel1.Location = new System.Drawing.Point(105, 13);
            this.guna2HtmlLabel1.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.guna2HtmlLabel1.Name = "guna2HtmlLabel1";
            this.guna2HtmlLabel1.Size = new System.Drawing.Size(122, 26);
            this.guna2HtmlLabel1.TabIndex = 63;
            this.guna2HtmlLabel1.Text = "Ngày bắt đầu";
            // 
            // btnChon
            // 
            this.btnChon.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.btnChon.BorderRadius = 10;
            this.btnChon.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnChon.DisabledState.BorderColor = System.Drawing.Color.DarkGray;
            this.btnChon.DisabledState.CustomBorderColor = System.Drawing.Color.DarkGray;
            this.btnChon.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(169)))), ((int)(((byte)(169)))), ((int)(((byte)(169)))));
            this.btnChon.DisabledState.FillColor2 = System.Drawing.Color.FromArgb(((int)(((byte)(169)))), ((int)(((byte)(169)))), ((int)(((byte)(169)))));
            this.btnChon.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(141)))), ((int)(((byte)(141)))), ((int)(((byte)(141)))));
            this.btnChon.FillColor = System.Drawing.Color.CornflowerBlue;
            this.btnChon.FillColor2 = System.Drawing.Color.FromArgb(((int)(((byte)(98)))), ((int)(((byte)(102)))), ((int)(((byte)(244)))));
            this.btnChon.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Bold);
            this.btnChon.ForeColor = System.Drawing.Color.White;
            this.btnChon.Image = global::QLSieuThiMini_Nhom13.Properties.Resources.Checkmark;
            this.btnChon.ImageAlign = System.Windows.Forms.HorizontalAlignment.Left;
            this.btnChon.ImageSize = new System.Drawing.Size(22, 22);
            this.btnChon.Location = new System.Drawing.Point(763, 64);
            this.btnChon.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.btnChon.Name = "btnChon";
            this.btnChon.Size = new System.Drawing.Size(235, 44);
            this.btnChon.TabIndex = 65;
            this.btnChon.Text = "Chọn khuyến mãi";
            this.btnChon.Click += new System.EventHandler(this.btnChon_Click);
            // 
            // dtpNgayKT
            // 
            this.dtpNgayKT.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.dtpNgayKT.BorderRadius = 15;
            this.dtpNgayKT.Checked = true;
            this.dtpNgayKT.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(140)))), ((int)(((byte)(180)))), ((int)(((byte)(255)))));
            this.dtpNgayKT.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dtpNgayKT.ForeColor = System.Drawing.Color.White;
            this.dtpNgayKT.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtpNgayKT.Location = new System.Drawing.Point(336, 56);
            this.dtpNgayKT.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.dtpNgayKT.MaxDate = new System.DateTime(9998, 12, 31, 0, 0, 0, 0);
            this.dtpNgayKT.MinDate = new System.DateTime(1753, 1, 1, 0, 0, 0, 0);
            this.dtpNgayKT.Name = "dtpNgayKT";
            this.dtpNgayKT.Size = new System.Drawing.Size(327, 44);
            this.dtpNgayKT.TabIndex = 69;
            this.dtpNgayKT.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.dtpNgayKT.Value = new System.DateTime(2024, 11, 22, 14, 2, 21, 622);
            // 
            // dtpNgayBD
            // 
            this.dtpNgayBD.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.dtpNgayBD.BorderRadius = 15;
            this.dtpNgayBD.Checked = true;
            this.dtpNgayBD.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(140)))), ((int)(((byte)(180)))), ((int)(((byte)(255)))));
            this.dtpNgayBD.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dtpNgayBD.ForeColor = System.Drawing.Color.White;
            this.dtpNgayBD.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtpNgayBD.Location = new System.Drawing.Point(3, 56);
            this.dtpNgayBD.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.dtpNgayBD.MaxDate = new System.DateTime(9998, 12, 31, 0, 0, 0, 0);
            this.dtpNgayBD.MinDate = new System.DateTime(1753, 1, 1, 0, 0, 0, 0);
            this.dtpNgayBD.Name = "dtpNgayBD";
            this.dtpNgayBD.Size = new System.Drawing.Size(327, 44);
            this.dtpNgayBD.TabIndex = 68;
            this.dtpNgayBD.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.dtpNgayBD.Value = new System.DateTime(2024, 11, 22, 14, 2, 21, 622);
            // 
            // guna2GroupBox1
            // 
            this.guna2GroupBox1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.guna2GroupBox1.Controls.Add(this.dgvKM);
            this.guna2GroupBox1.Controls.Add(this.txtTimKiemKM);
            this.guna2GroupBox1.Controls.Add(this.btnChon);
            this.guna2GroupBox1.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.guna2GroupBox1.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(125)))), ((int)(((byte)(137)))), ((int)(((byte)(149)))));
            this.guna2GroupBox1.Location = new System.Drawing.Point(14, 132);
            this.guna2GroupBox1.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.guna2GroupBox1.Name = "guna2GroupBox1";
            this.guna2GroupBox1.Size = new System.Drawing.Size(1001, 621);
            this.guna2GroupBox1.TabIndex = 65;
            this.guna2GroupBox1.Text = "Danh sách sản phẩm";
            // 
            // dgvKM
            // 
            dataGridViewCellStyle1.BackColor = System.Drawing.Color.White;
            this.dgvKM.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle1;
            this.dgvKM.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(130)))), ((int)(((byte)(147)))), ((int)(((byte)(250)))));
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Segoe UI", 9F);
            dataGridViewCellStyle2.ForeColor = System.Drawing.Color.White;
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(130)))), ((int)(((byte)(147)))), ((int)(((byte)(250)))));
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.Color.White;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvKM.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle2;
            this.dgvKM.ColumnHeadersHeight = 40;
            this.dgvKM.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.MaKM,
            this.TenKM});
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle3.BackColor = System.Drawing.Color.White;
            dataGridViewCellStyle3.Font = new System.Drawing.Font("Segoe UI", 9F);
            dataGridViewCellStyle3.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(125)))), ((int)(((byte)(137)))), ((int)(((byte)(149)))));
            dataGridViewCellStyle3.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            dataGridViewCellStyle3.SelectionForeColor = System.Drawing.Color.Black;
            dataGridViewCellStyle3.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dgvKM.DefaultCellStyle = dataGridViewCellStyle3;
            this.dgvKM.GridColor = System.Drawing.Color.FromArgb(((int)(((byte)(231)))), ((int)(((byte)(229)))), ((int)(((byte)(255)))));
            this.dgvKM.Location = new System.Drawing.Point(8, 128);
            this.dgvKM.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.dgvKM.Name = "dgvKM";
            this.dgvKM.ReadOnly = true;
            this.dgvKM.RowHeadersVisible = false;
            this.dgvKM.RowHeadersWidth = 51;
            this.dgvKM.RowTemplate.Height = 40;
            this.dgvKM.Size = new System.Drawing.Size(990, 490);
            this.dgvKM.TabIndex = 8;
            this.dgvKM.ThemeStyle.AlternatingRowsStyle.BackColor = System.Drawing.Color.White;
            this.dgvKM.ThemeStyle.AlternatingRowsStyle.Font = null;
            this.dgvKM.ThemeStyle.AlternatingRowsStyle.ForeColor = System.Drawing.Color.Empty;
            this.dgvKM.ThemeStyle.AlternatingRowsStyle.SelectionBackColor = System.Drawing.Color.Empty;
            this.dgvKM.ThemeStyle.AlternatingRowsStyle.SelectionForeColor = System.Drawing.Color.Empty;
            this.dgvKM.ThemeStyle.BackColor = System.Drawing.Color.White;
            this.dgvKM.ThemeStyle.GridColor = System.Drawing.Color.FromArgb(((int)(((byte)(231)))), ((int)(((byte)(229)))), ((int)(((byte)(255)))));
            this.dgvKM.ThemeStyle.HeaderStyle.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(130)))), ((int)(((byte)(147)))), ((int)(((byte)(250)))));
            this.dgvKM.ThemeStyle.HeaderStyle.BorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.None;
            this.dgvKM.ThemeStyle.HeaderStyle.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dgvKM.ThemeStyle.HeaderStyle.ForeColor = System.Drawing.Color.White;
            this.dgvKM.ThemeStyle.HeaderStyle.HeaightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
            this.dgvKM.ThemeStyle.HeaderStyle.Height = 40;
            this.dgvKM.ThemeStyle.ReadOnly = true;
            this.dgvKM.ThemeStyle.RowsStyle.BackColor = System.Drawing.Color.White;
            this.dgvKM.ThemeStyle.RowsStyle.BorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.SingleHorizontal;
            this.dgvKM.ThemeStyle.RowsStyle.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.dgvKM.ThemeStyle.RowsStyle.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(71)))), ((int)(((byte)(69)))), ((int)(((byte)(94)))));
            this.dgvKM.ThemeStyle.RowsStyle.Height = 40;
            this.dgvKM.ThemeStyle.RowsStyle.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.dgvKM.ThemeStyle.RowsStyle.SelectionForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
//            this.dgvKM.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvKM_CellClick);
            // 
            // txtTimKiemKM
            // 
            this.txtTimKiemKM.Animated = true;
            this.txtTimKiemKM.BorderColor = System.Drawing.Color.Transparent;
            this.txtTimKiemKM.BorderRadius = 10;
            this.txtTimKiemKM.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.txtTimKiemKM.DefaultText = "";
            this.txtTimKiemKM.DisabledState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(208)))), ((int)(((byte)(208)))), ((int)(((byte)(208)))));
            this.txtTimKiemKM.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(226)))), ((int)(((byte)(226)))), ((int)(((byte)(226)))));
            this.txtTimKiemKM.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(138)))), ((int)(((byte)(138)))), ((int)(((byte)(138)))));
            this.txtTimKiemKM.DisabledState.PlaceholderForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(138)))), ((int)(((byte)(138)))), ((int)(((byte)(138)))));
            this.txtTimKiemKM.FillColor = System.Drawing.Color.WhiteSmoke;
            this.txtTimKiemKM.FocusedState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.txtTimKiemKM.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.txtTimKiemKM.ForeColor = System.Drawing.Color.Black;
            this.txtTimKiemKM.HoverState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.txtTimKiemKM.IconLeftCursor = System.Windows.Forms.Cursors.Hand;
            this.txtTimKiemKM.IconRight = global::QLSieuThiMini_Nhom13.Properties.Resources.Search;
            this.txtTimKiemKM.IconRightCursor = System.Windows.Forms.Cursors.Hand;
            this.txtTimKiemKM.Location = new System.Drawing.Point(8, 64);
            this.txtTimKiemKM.Margin = new System.Windows.Forms.Padding(3, 5, 3, 5);
            this.txtTimKiemKM.Name = "txtTimKiemKM";
            this.txtTimKiemKM.PasswordChar = '\0';
            this.txtTimKiemKM.PlaceholderForeColor = System.Drawing.Color.Gray;
            this.txtTimKiemKM.PlaceholderText = "Nhập mã hoặc tên khuyến mãi";
            this.txtTimKiemKM.SelectedText = "";
            this.txtTimKiemKM.Size = new System.Drawing.Size(368, 44);
            this.txtTimKiemKM.TabIndex = 7;
            this.txtTimKiemKM.TextChanged += new System.EventHandler(this.txtTimKiemKM_TextChanged);
            // 
            // btnLoc
            // 
            this.btnLoc.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.btnLoc.BorderRadius = 10;
            this.btnLoc.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnLoc.DisabledState.BorderColor = System.Drawing.Color.DarkGray;
            this.btnLoc.DisabledState.CustomBorderColor = System.Drawing.Color.DarkGray;
            this.btnLoc.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(169)))), ((int)(((byte)(169)))), ((int)(((byte)(169)))));
            this.btnLoc.DisabledState.FillColor2 = System.Drawing.Color.FromArgb(((int)(((byte)(169)))), ((int)(((byte)(169)))), ((int)(((byte)(169)))));
            this.btnLoc.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(141)))), ((int)(((byte)(141)))), ((int)(((byte)(141)))));
            this.btnLoc.FillColor = System.Drawing.Color.CornflowerBlue;
            this.btnLoc.FillColor2 = System.Drawing.Color.FromArgb(((int)(((byte)(98)))), ((int)(((byte)(102)))), ((int)(((byte)(244)))));
            this.btnLoc.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Bold);
            this.btnLoc.ForeColor = System.Drawing.Color.White;
            this.btnLoc.Image = global::QLSieuThiMini_Nhom13.Properties.Resources.Checkmark;
            this.btnLoc.ImageAlign = System.Windows.Forms.HorizontalAlignment.Left;
            this.btnLoc.ImageSize = new System.Drawing.Size(22, 22);
            this.btnLoc.Location = new System.Drawing.Point(780, 56);
            this.btnLoc.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.btnLoc.Name = "btnLoc";
            this.btnLoc.Size = new System.Drawing.Size(107, 44);
            this.btnLoc.TabIndex = 70;
            this.btnLoc.Text = "Lọc";
            this.btnLoc.Click += new System.EventHandler(this.btnLoc_Click);
            // 
            // MaKM
            // 
            this.MaKM.DataPropertyName = "MaKM";
            this.MaKM.HeaderText = "Mã khuyến mãi";
            this.MaKM.MinimumWidth = 6;
            this.MaKM.Name = "MaKM";
            this.MaKM.ReadOnly = true;
            // 
            // TenKM
            // 
            this.TenKM.DataPropertyName = "TenKM";
            this.TenKM.HeaderText = "Tên khuyến mãi";
            this.TenKM.MinimumWidth = 6;
            this.TenKM.Name = "TenKM";
            this.TenKM.ReadOnly = true;
            // 
            // FrmXemDSKhuyenMai
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1028, 769);
            this.Controls.Add(this.guna2GroupBox1);
            this.Controls.Add(this.tableLayoutPanel7);
            this.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.Name = "FrmXemDSKhuyenMai";
            this.Text = "FrmXemDSKM";
            this.Load += new System.EventHandler(this.FrmXemDSKhuyenMai_Load);
            this.tableLayoutPanel7.ResumeLayout(false);
            this.tableLayoutPanel7.PerformLayout();
            this.guna2GroupBox1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvKM)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel7;
        private Guna.UI2.WinForms.Guna2HtmlLabel guna2HtmlLabel2;
        private Guna.UI2.WinForms.Guna2HtmlLabel guna2HtmlLabel1;
        private Guna.UI2.WinForms.Guna2GradientButton btnChon;
        private Guna.UI2.WinForms.Guna2GroupBox guna2GroupBox1;
        private Guna.UI2.WinForms.Guna2TextBox txtTimKiemKM;
        private Guna.UI2.WinForms.Guna2DataGridView dgvKM;
        private Guna.UI2.WinForms.Guna2DateTimePicker dtpNgayBD;
        private Guna.UI2.WinForms.Guna2DateTimePicker dtpNgayKT;
        private Guna.UI2.WinForms.Guna2GradientButton btnLoc;
        private System.Windows.Forms.DataGridViewTextBoxColumn MaKM;
        private System.Windows.Forms.DataGridViewTextBoxColumn TenKM;
    }
}