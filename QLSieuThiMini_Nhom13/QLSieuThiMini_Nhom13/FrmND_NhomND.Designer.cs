
namespace QLSieuThiMini_Nhom13
{
    partial class FrmND_NhomND
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle4 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle5 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle6 = new System.Windows.Forms.DataGridViewCellStyle();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FrmND_NhomND));
            Bunifu.UI.WinForms.BunifuButton.BunifuButton2.BorderEdges borderEdges1 = new Bunifu.UI.WinForms.BunifuButton.BunifuButton2.BorderEdges();
            Bunifu.UI.WinForms.BunifuButton.BunifuButton2.BorderEdges borderEdges2 = new Bunifu.UI.WinForms.BunifuButton.BunifuButton2.BorderEdges();
            this.gBNguoiDung = new Bunifu.UI.WinForms.BunifuGroupBox();
            this.bunifuGroupBox1 = new Bunifu.UI.WinForms.BunifuGroupBox();
            this.dgvNguoiDung = new Bunifu.UI.WinForms.BunifuDataGridView();
            this.MaND = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.TenTK = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.TenND = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.gBNdTrongNhom = new Bunifu.UI.WinForms.BunifuGroupBox();
            this.dgvNguoiDungTrongNhom = new Bunifu.UI.WinForms.BunifuDataGridView();
            this.cboNhomND = new Bunifu.UI.WinForms.BunifuDropdown();
            this.bunifuLabel1 = new Bunifu.UI.WinForms.BunifuLabel();
            this.btnThem = new Bunifu.UI.WinForms.BunifuButton.BunifuButton2();
            this.btnXoa = new Bunifu.UI.WinForms.BunifuButton.BunifuButton2();
            this.ucGhiChu = new QLSieuThiMini_Nhom13.LabelTextbox_UC();
            this.MaNhom = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this._MaND = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this._TenTK = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this._TenND = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.GhiChu = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.bunifuGroupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvNguoiDung)).BeginInit();
            this.gBNdTrongNhom.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvNguoiDungTrongNhom)).BeginInit();
            this.SuspendLayout();
            // 
            // gBNguoiDung
            // 
            this.gBNguoiDung.BorderColor = System.Drawing.Color.LightGray;
            this.gBNguoiDung.BorderRadius = 1;
            this.gBNguoiDung.BorderThickness = 1;
            this.gBNguoiDung.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.gBNguoiDung.LabelAlign = System.Windows.Forms.HorizontalAlignment.Left;
            this.gBNguoiDung.LabelIndent = 10;
            this.gBNguoiDung.LineStyle = Bunifu.UI.WinForms.BunifuGroupBox.LineStyles.Solid;
            this.gBNguoiDung.Location = new System.Drawing.Point(75, 123);
            this.gBNguoiDung.Name = "gBNguoiDung";
            this.gBNguoiDung.Size = new System.Drawing.Size(505, 284);
            this.gBNguoiDung.TabIndex = 0;
            this.gBNguoiDung.TabStop = false;
            this.gBNguoiDung.Text = "Tất cả người dùng";
            // 
            // bunifuGroupBox1
            // 
            this.bunifuGroupBox1.BorderColor = System.Drawing.Color.LightGray;
            this.bunifuGroupBox1.BorderRadius = 1;
            this.bunifuGroupBox1.BorderThickness = 1;
            this.bunifuGroupBox1.Controls.Add(this.dgvNguoiDung);
            this.bunifuGroupBox1.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.bunifuGroupBox1.LabelAlign = System.Windows.Forms.HorizontalAlignment.Left;
            this.bunifuGroupBox1.LabelIndent = 10;
            this.bunifuGroupBox1.LineStyle = Bunifu.UI.WinForms.BunifuGroupBox.LineStyles.Solid;
            this.bunifuGroupBox1.Location = new System.Drawing.Point(75, 123);
            this.bunifuGroupBox1.Name = "bunifuGroupBox1";
            this.bunifuGroupBox1.Size = new System.Drawing.Size(505, 463);
            this.bunifuGroupBox1.TabIndex = 0;
            this.bunifuGroupBox1.TabStop = false;
            this.bunifuGroupBox1.Text = "Người dùng không có trong nhóm";
            // 
            // dgvNguoiDung
            // 
            this.dgvNguoiDung.AllowCustomTheming = false;
            dataGridViewCellStyle1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(248)))), ((int)(((byte)(251)))), ((int)(((byte)(255)))));
            dataGridViewCellStyle1.ForeColor = System.Drawing.Color.Black;
            this.dgvNguoiDung.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle1;
            this.dgvNguoiDung.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvNguoiDung.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.dgvNguoiDung.CellBorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.SingleHorizontal;
            this.dgvNguoiDung.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.None;
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.BackColor = System.Drawing.Color.DodgerBlue;
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Segoe UI Semibold", 11.75F, System.Drawing.FontStyle.Bold);
            dataGridViewCellStyle2.ForeColor = System.Drawing.Color.White;
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(24)))), ((int)(((byte)(115)))), ((int)(((byte)(204)))));
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.Color.White;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvNguoiDung.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle2;
            this.dgvNguoiDung.ColumnHeadersHeight = 40;
            this.dgvNguoiDung.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.MaND,
            this.TenTK,
            this.TenND});
            this.dgvNguoiDung.CurrentTheme.AlternatingRowsStyle.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(248)))), ((int)(((byte)(251)))), ((int)(((byte)(255)))));
            this.dgvNguoiDung.CurrentTheme.AlternatingRowsStyle.Font = new System.Drawing.Font("Segoe UI Semibold", 9.75F, System.Drawing.FontStyle.Bold);
            this.dgvNguoiDung.CurrentTheme.AlternatingRowsStyle.ForeColor = System.Drawing.Color.Black;
            this.dgvNguoiDung.CurrentTheme.AlternatingRowsStyle.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(210)))), ((int)(((byte)(232)))), ((int)(((byte)(255)))));
            this.dgvNguoiDung.CurrentTheme.AlternatingRowsStyle.SelectionForeColor = System.Drawing.Color.Black;
            this.dgvNguoiDung.CurrentTheme.BackColor = System.Drawing.Color.White;
            this.dgvNguoiDung.CurrentTheme.GridColor = System.Drawing.Color.FromArgb(((int)(((byte)(221)))), ((int)(((byte)(238)))), ((int)(((byte)(255)))));
            this.dgvNguoiDung.CurrentTheme.HeaderStyle.BackColor = System.Drawing.Color.DodgerBlue;
            this.dgvNguoiDung.CurrentTheme.HeaderStyle.Font = new System.Drawing.Font("Segoe UI Semibold", 11.75F, System.Drawing.FontStyle.Bold);
            this.dgvNguoiDung.CurrentTheme.HeaderStyle.ForeColor = System.Drawing.Color.White;
            this.dgvNguoiDung.CurrentTheme.HeaderStyle.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(24)))), ((int)(((byte)(115)))), ((int)(((byte)(204)))));
            this.dgvNguoiDung.CurrentTheme.HeaderStyle.SelectionForeColor = System.Drawing.Color.White;
            this.dgvNguoiDung.CurrentTheme.Name = null;
            this.dgvNguoiDung.CurrentTheme.RowsStyle.BackColor = System.Drawing.Color.White;
            this.dgvNguoiDung.CurrentTheme.RowsStyle.Font = new System.Drawing.Font("Segoe UI Semibold", 9.75F, System.Drawing.FontStyle.Bold);
            this.dgvNguoiDung.CurrentTheme.RowsStyle.ForeColor = System.Drawing.Color.Black;
            this.dgvNguoiDung.CurrentTheme.RowsStyle.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(210)))), ((int)(((byte)(232)))), ((int)(((byte)(255)))));
            this.dgvNguoiDung.CurrentTheme.RowsStyle.SelectionForeColor = System.Drawing.Color.Black;
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle3.BackColor = System.Drawing.Color.White;
            dataGridViewCellStyle3.Font = new System.Drawing.Font("Segoe UI Semibold", 9.75F, System.Drawing.FontStyle.Bold);
            dataGridViewCellStyle3.ForeColor = System.Drawing.Color.Black;
            dataGridViewCellStyle3.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(210)))), ((int)(((byte)(232)))), ((int)(((byte)(255)))));
            dataGridViewCellStyle3.SelectionForeColor = System.Drawing.Color.Black;
            dataGridViewCellStyle3.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dgvNguoiDung.DefaultCellStyle = dataGridViewCellStyle3;
            this.dgvNguoiDung.EnableHeadersVisualStyles = false;
            this.dgvNguoiDung.GridColor = System.Drawing.Color.FromArgb(((int)(((byte)(221)))), ((int)(((byte)(238)))), ((int)(((byte)(255)))));
            this.dgvNguoiDung.HeaderBackColor = System.Drawing.Color.DodgerBlue;
            this.dgvNguoiDung.HeaderBgColor = System.Drawing.Color.Empty;
            this.dgvNguoiDung.HeaderForeColor = System.Drawing.Color.White;
            this.dgvNguoiDung.Location = new System.Drawing.Point(21, 41);
            this.dgvNguoiDung.MultiSelect = false;
            this.dgvNguoiDung.Name = "dgvNguoiDung";
            this.dgvNguoiDung.ReadOnly = true;
            this.dgvNguoiDung.RowHeadersVisible = false;
            this.dgvNguoiDung.RowHeadersWidth = 62;
            this.dgvNguoiDung.RowTemplate.Height = 40;
            this.dgvNguoiDung.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvNguoiDung.Size = new System.Drawing.Size(465, 404);
            this.dgvNguoiDung.TabIndex = 0;
            this.dgvNguoiDung.Theme = Bunifu.UI.WinForms.BunifuDataGridView.PresetThemes.Light;
            // 
            // MaND
            // 
            this.MaND.DataPropertyName = "MaND";
            this.MaND.HeaderText = "Mã ND";
            this.MaND.MinimumWidth = 8;
            this.MaND.Name = "MaND";
            this.MaND.ReadOnly = true;
            // 
            // TenTK
            // 
            this.TenTK.DataPropertyName = "TenTK";
            this.TenTK.HeaderText = "Tên tài khoản";
            this.TenTK.MinimumWidth = 8;
            this.TenTK.Name = "TenTK";
            this.TenTK.ReadOnly = true;
            // 
            // TenND
            // 
            this.TenND.DataPropertyName = "TenND";
            this.TenND.HeaderText = "Tên người dùng";
            this.TenND.MinimumWidth = 8;
            this.TenND.Name = "TenND";
            this.TenND.ReadOnly = true;
            // 
            // gBNdTrongNhom
            // 
            this.gBNdTrongNhom.BorderColor = System.Drawing.Color.LightGray;
            this.gBNdTrongNhom.BorderRadius = 1;
            this.gBNdTrongNhom.BorderThickness = 1;
            this.gBNdTrongNhom.Controls.Add(this.dgvNguoiDungTrongNhom);
            this.gBNdTrongNhom.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.gBNdTrongNhom.LabelAlign = System.Windows.Forms.HorizontalAlignment.Left;
            this.gBNdTrongNhom.LabelIndent = 10;
            this.gBNdTrongNhom.LineStyle = Bunifu.UI.WinForms.BunifuGroupBox.LineStyles.Solid;
            this.gBNdTrongNhom.Location = new System.Drawing.Point(680, 123);
            this.gBNdTrongNhom.Name = "gBNdTrongNhom";
            this.gBNdTrongNhom.Size = new System.Drawing.Size(613, 455);
            this.gBNdTrongNhom.TabIndex = 1;
            this.gBNdTrongNhom.TabStop = false;
            this.gBNdTrongNhom.Text = "Người dùng trong nhóm";
            // 
            // dgvNguoiDungTrongNhom
            // 
            this.dgvNguoiDungTrongNhom.AllowCustomTheming = false;
            dataGridViewCellStyle4.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(248)))), ((int)(((byte)(251)))), ((int)(((byte)(255)))));
            dataGridViewCellStyle4.Font = new System.Drawing.Font("Tahoma", 8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle4.ForeColor = System.Drawing.Color.Black;
            this.dgvNguoiDungTrongNhom.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle4;
            this.dgvNguoiDungTrongNhom.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvNguoiDungTrongNhom.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.dgvNguoiDungTrongNhom.CellBorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.SingleHorizontal;
            this.dgvNguoiDungTrongNhom.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.None;
            dataGridViewCellStyle5.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle5.BackColor = System.Drawing.Color.DodgerBlue;
            dataGridViewCellStyle5.Font = new System.Drawing.Font("Segoe UI Semibold", 11.75F, System.Drawing.FontStyle.Bold);
            dataGridViewCellStyle5.ForeColor = System.Drawing.Color.White;
            dataGridViewCellStyle5.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(24)))), ((int)(((byte)(115)))), ((int)(((byte)(204)))));
            dataGridViewCellStyle5.SelectionForeColor = System.Drawing.Color.White;
            dataGridViewCellStyle5.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvNguoiDungTrongNhom.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle5;
            this.dgvNguoiDungTrongNhom.ColumnHeadersHeight = 40;
            this.dgvNguoiDungTrongNhom.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.MaNhom,
            this._MaND,
            this._TenTK,
            this._TenND,
            this.GhiChu});
            this.dgvNguoiDungTrongNhom.CurrentTheme.AlternatingRowsStyle.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(248)))), ((int)(((byte)(251)))), ((int)(((byte)(255)))));
            this.dgvNguoiDungTrongNhom.CurrentTheme.AlternatingRowsStyle.Font = new System.Drawing.Font("Segoe UI Semibold", 9.75F, System.Drawing.FontStyle.Bold);
            this.dgvNguoiDungTrongNhom.CurrentTheme.AlternatingRowsStyle.ForeColor = System.Drawing.Color.Black;
            this.dgvNguoiDungTrongNhom.CurrentTheme.AlternatingRowsStyle.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(210)))), ((int)(((byte)(232)))), ((int)(((byte)(255)))));
            this.dgvNguoiDungTrongNhom.CurrentTheme.AlternatingRowsStyle.SelectionForeColor = System.Drawing.Color.Black;
            this.dgvNguoiDungTrongNhom.CurrentTheme.BackColor = System.Drawing.Color.White;
            this.dgvNguoiDungTrongNhom.CurrentTheme.GridColor = System.Drawing.Color.FromArgb(((int)(((byte)(221)))), ((int)(((byte)(238)))), ((int)(((byte)(255)))));
            this.dgvNguoiDungTrongNhom.CurrentTheme.HeaderStyle.BackColor = System.Drawing.Color.DodgerBlue;
            this.dgvNguoiDungTrongNhom.CurrentTheme.HeaderStyle.Font = new System.Drawing.Font("Segoe UI Semibold", 11.75F, System.Drawing.FontStyle.Bold);
            this.dgvNguoiDungTrongNhom.CurrentTheme.HeaderStyle.ForeColor = System.Drawing.Color.White;
            this.dgvNguoiDungTrongNhom.CurrentTheme.HeaderStyle.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(24)))), ((int)(((byte)(115)))), ((int)(((byte)(204)))));
            this.dgvNguoiDungTrongNhom.CurrentTheme.HeaderStyle.SelectionForeColor = System.Drawing.Color.White;
            this.dgvNguoiDungTrongNhom.CurrentTheme.Name = null;
            this.dgvNguoiDungTrongNhom.CurrentTheme.RowsStyle.BackColor = System.Drawing.Color.White;
            this.dgvNguoiDungTrongNhom.CurrentTheme.RowsStyle.Font = new System.Drawing.Font("Segoe UI Semibold", 9.75F, System.Drawing.FontStyle.Bold);
            this.dgvNguoiDungTrongNhom.CurrentTheme.RowsStyle.ForeColor = System.Drawing.Color.Black;
            this.dgvNguoiDungTrongNhom.CurrentTheme.RowsStyle.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(210)))), ((int)(((byte)(232)))), ((int)(((byte)(255)))));
            this.dgvNguoiDungTrongNhom.CurrentTheme.RowsStyle.SelectionForeColor = System.Drawing.Color.Black;
            dataGridViewCellStyle6.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle6.BackColor = System.Drawing.Color.White;
            dataGridViewCellStyle6.Font = new System.Drawing.Font("Segoe UI Semibold", 9.75F, System.Drawing.FontStyle.Bold);
            dataGridViewCellStyle6.ForeColor = System.Drawing.Color.Black;
            dataGridViewCellStyle6.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(210)))), ((int)(((byte)(232)))), ((int)(((byte)(255)))));
            dataGridViewCellStyle6.SelectionForeColor = System.Drawing.Color.Black;
            dataGridViewCellStyle6.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dgvNguoiDungTrongNhom.DefaultCellStyle = dataGridViewCellStyle6;
            this.dgvNguoiDungTrongNhom.EnableHeadersVisualStyles = false;
            this.dgvNguoiDungTrongNhom.GridColor = System.Drawing.Color.FromArgb(((int)(((byte)(221)))), ((int)(((byte)(238)))), ((int)(((byte)(255)))));
            this.dgvNguoiDungTrongNhom.HeaderBackColor = System.Drawing.Color.DodgerBlue;
            this.dgvNguoiDungTrongNhom.HeaderBgColor = System.Drawing.Color.Empty;
            this.dgvNguoiDungTrongNhom.HeaderForeColor = System.Drawing.Color.White;
            this.dgvNguoiDungTrongNhom.Location = new System.Drawing.Point(6, 41);
            this.dgvNguoiDungTrongNhom.MultiSelect = false;
            this.dgvNguoiDungTrongNhom.Name = "dgvNguoiDungTrongNhom";
            this.dgvNguoiDungTrongNhom.ReadOnly = true;
            this.dgvNguoiDungTrongNhom.RowHeadersVisible = false;
            this.dgvNguoiDungTrongNhom.RowHeadersWidth = 62;
            this.dgvNguoiDungTrongNhom.RowTemplate.Height = 40;
            this.dgvNguoiDungTrongNhom.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvNguoiDungTrongNhom.Size = new System.Drawing.Size(601, 404);
            this.dgvNguoiDungTrongNhom.TabIndex = 1;
            this.dgvNguoiDungTrongNhom.Theme = Bunifu.UI.WinForms.BunifuDataGridView.PresetThemes.Light;
            // 
            // cboNhomND
            // 
            this.cboNhomND.BackColor = System.Drawing.Color.Transparent;
            this.cboNhomND.BackgroundColor = System.Drawing.Color.White;
            this.cboNhomND.BorderColor = System.Drawing.Color.Silver;
            this.cboNhomND.BorderRadius = 1;
            this.cboNhomND.Color = System.Drawing.Color.Silver;
            this.cboNhomND.Direction = Bunifu.UI.WinForms.BunifuDropdown.Directions.Down;
            this.cboNhomND.DisabledBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(240)))), ((int)(((byte)(240)))), ((int)(((byte)(240)))));
            this.cboNhomND.DisabledBorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(204)))), ((int)(((byte)(204)))), ((int)(((byte)(204)))));
            this.cboNhomND.DisabledColor = System.Drawing.Color.FromArgb(((int)(((byte)(240)))), ((int)(((byte)(240)))), ((int)(((byte)(240)))));
            this.cboNhomND.DisabledForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(109)))), ((int)(((byte)(109)))), ((int)(((byte)(109)))));
            this.cboNhomND.DisabledIndicatorColor = System.Drawing.Color.DarkGray;
            this.cboNhomND.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed;
            this.cboNhomND.DropdownBorderThickness = Bunifu.UI.WinForms.BunifuDropdown.BorderThickness.Thin;
            this.cboNhomND.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboNhomND.DropDownTextAlign = Bunifu.UI.WinForms.BunifuDropdown.TextAlign.Left;
            this.cboNhomND.FillDropDown = true;
            this.cboNhomND.FillIndicator = false;
            this.cboNhomND.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.cboNhomND.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.cboNhomND.ForeColor = System.Drawing.Color.Black;
            this.cboNhomND.FormattingEnabled = true;
            this.cboNhomND.Icon = null;
            this.cboNhomND.IndicatorAlignment = Bunifu.UI.WinForms.BunifuDropdown.Indicator.Right;
            this.cboNhomND.IndicatorColor = System.Drawing.Color.DarkGray;
            this.cboNhomND.IndicatorLocation = Bunifu.UI.WinForms.BunifuDropdown.Indicator.Right;
            this.cboNhomND.IndicatorThickness = 2;
            this.cboNhomND.IsDropdownOpened = false;
            this.cboNhomND.ItemBackColor = System.Drawing.Color.White;
            this.cboNhomND.ItemBorderColor = System.Drawing.Color.White;
            this.cboNhomND.ItemForeColor = System.Drawing.Color.Black;
            this.cboNhomND.ItemHeight = 26;
            this.cboNhomND.ItemHighLightColor = System.Drawing.Color.DodgerBlue;
            this.cboNhomND.ItemHighLightForeColor = System.Drawing.Color.White;
            this.cboNhomND.ItemTopMargin = 3;
            this.cboNhomND.Location = new System.Drawing.Point(301, 45);
            this.cboNhomND.Name = "cboNhomND";
            this.cboNhomND.Size = new System.Drawing.Size(260, 32);
            this.cboNhomND.TabIndex = 3;
            this.cboNhomND.Text = null;
            this.cboNhomND.TextAlignment = Bunifu.UI.WinForms.BunifuDropdown.TextAlign.Left;
            this.cboNhomND.TextLeftMargin = 5;
            this.cboNhomND.SelectedIndexChanged += new System.EventHandler(this.cboNhomND_SelectedIndexChanged);
            // 
            // bunifuLabel1
            // 
            this.bunifuLabel1.AllowParentOverrides = false;
            this.bunifuLabel1.AutoEllipsis = false;
            this.bunifuLabel1.Cursor = System.Windows.Forms.Cursors.Default;
            this.bunifuLabel1.CursorType = System.Windows.Forms.Cursors.Default;
            this.bunifuLabel1.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.bunifuLabel1.Location = new System.Drawing.Point(109, 52);
            this.bunifuLabel1.Name = "bunifuLabel1";
            this.bunifuLabel1.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.bunifuLabel1.Size = new System.Drawing.Size(149, 25);
            this.bunifuLabel1.TabIndex = 4;
            this.bunifuLabel1.Text = "Nhóm người dùng";
            this.bunifuLabel1.TextAlignment = System.Drawing.ContentAlignment.TopLeft;
            this.bunifuLabel1.TextFormat = Bunifu.UI.WinForms.BunifuLabel.TextFormattingOptions.Default;
            // 
            // btnThem
            // 
            this.btnThem.AllowAnimations = true;
            this.btnThem.AllowMouseEffects = true;
            this.btnThem.AllowToggling = false;
            this.btnThem.AnimationSpeed = 200;
            this.btnThem.AutoGenerateColors = false;
            this.btnThem.AutoRoundBorders = false;
            this.btnThem.AutoSizeLeftIcon = true;
            this.btnThem.AutoSizeRightIcon = true;
            this.btnThem.BackColor = System.Drawing.Color.Transparent;
            this.btnThem.BackColor1 = System.Drawing.Color.DodgerBlue;
            this.btnThem.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btnThem.BackgroundImage")));
            this.btnThem.BorderStyle = Bunifu.UI.WinForms.BunifuButton.BunifuButton2.BorderStyles.Solid;
            this.btnThem.ButtonText = ">>";
            this.btnThem.ButtonTextMarginLeft = 0;
            this.btnThem.ColorContrastOnClick = 45;
            this.btnThem.ColorContrastOnHover = 45;
            this.btnThem.Cursor = System.Windows.Forms.Cursors.Default;
            borderEdges1.BottomLeft = true;
            borderEdges1.BottomRight = true;
            borderEdges1.TopLeft = true;
            borderEdges1.TopRight = true;
            this.btnThem.CustomizableEdges = borderEdges1;
            this.btnThem.DialogResult = System.Windows.Forms.DialogResult.None;
            this.btnThem.DisabledBorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(191)))), ((int)(((byte)(191)))), ((int)(((byte)(191)))));
            this.btnThem.DisabledFillColor = System.Drawing.Color.FromArgb(((int)(((byte)(204)))), ((int)(((byte)(204)))), ((int)(((byte)(204)))));
            this.btnThem.DisabledForecolor = System.Drawing.Color.FromArgb(((int)(((byte)(168)))), ((int)(((byte)(160)))), ((int)(((byte)(168)))));
            this.btnThem.FocusState = Bunifu.UI.WinForms.BunifuButton.BunifuButton2.ButtonStates.Pressed;
            this.btnThem.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.btnThem.ForeColor = System.Drawing.Color.White;
            this.btnThem.IconLeftAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnThem.IconLeftCursor = System.Windows.Forms.Cursors.Default;
            this.btnThem.IconLeftPadding = new System.Windows.Forms.Padding(11, 3, 3, 3);
            this.btnThem.IconMarginLeft = 11;
            this.btnThem.IconPadding = 10;
            this.btnThem.IconRightAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnThem.IconRightCursor = System.Windows.Forms.Cursors.Default;
            this.btnThem.IconRightPadding = new System.Windows.Forms.Padding(3, 3, 7, 3);
            this.btnThem.IconSize = 25;
            this.btnThem.IdleBorderColor = System.Drawing.Color.DodgerBlue;
            this.btnThem.IdleBorderRadius = 1;
            this.btnThem.IdleBorderThickness = 1;
            this.btnThem.IdleFillColor = System.Drawing.Color.DodgerBlue;
            this.btnThem.IdleIconLeftImage = null;
            this.btnThem.IdleIconRightImage = null;
            this.btnThem.IndicateFocus = false;
            this.btnThem.Location = new System.Drawing.Point(586, 240);
            this.btnThem.Name = "btnThem";
            this.btnThem.OnDisabledState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(191)))), ((int)(((byte)(191)))), ((int)(((byte)(191)))));
            this.btnThem.OnDisabledState.BorderRadius = 1;
            this.btnThem.OnDisabledState.BorderStyle = Bunifu.UI.WinForms.BunifuButton.BunifuButton2.BorderStyles.Solid;
            this.btnThem.OnDisabledState.BorderThickness = 1;
            this.btnThem.OnDisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(204)))), ((int)(((byte)(204)))), ((int)(((byte)(204)))));
            this.btnThem.OnDisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(168)))), ((int)(((byte)(160)))), ((int)(((byte)(168)))));
            this.btnThem.OnDisabledState.IconLeftImage = null;
            this.btnThem.OnDisabledState.IconRightImage = null;
            this.btnThem.onHoverState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(105)))), ((int)(((byte)(181)))), ((int)(((byte)(255)))));
            this.btnThem.onHoverState.BorderRadius = 1;
            this.btnThem.onHoverState.BorderStyle = Bunifu.UI.WinForms.BunifuButton.BunifuButton2.BorderStyles.Solid;
            this.btnThem.onHoverState.BorderThickness = 1;
            this.btnThem.onHoverState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(105)))), ((int)(((byte)(181)))), ((int)(((byte)(255)))));
            this.btnThem.onHoverState.ForeColor = System.Drawing.Color.White;
            this.btnThem.onHoverState.IconLeftImage = null;
            this.btnThem.onHoverState.IconRightImage = null;
            this.btnThem.OnIdleState.BorderColor = System.Drawing.Color.DodgerBlue;
            this.btnThem.OnIdleState.BorderRadius = 1;
            this.btnThem.OnIdleState.BorderStyle = Bunifu.UI.WinForms.BunifuButton.BunifuButton2.BorderStyles.Solid;
            this.btnThem.OnIdleState.BorderThickness = 1;
            this.btnThem.OnIdleState.FillColor = System.Drawing.Color.DodgerBlue;
            this.btnThem.OnIdleState.ForeColor = System.Drawing.Color.White;
            this.btnThem.OnIdleState.IconLeftImage = null;
            this.btnThem.OnIdleState.IconRightImage = null;
            this.btnThem.OnPressedState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(40)))), ((int)(((byte)(96)))), ((int)(((byte)(144)))));
            this.btnThem.OnPressedState.BorderRadius = 1;
            this.btnThem.OnPressedState.BorderStyle = Bunifu.UI.WinForms.BunifuButton.BunifuButton2.BorderStyles.Solid;
            this.btnThem.OnPressedState.BorderThickness = 1;
            this.btnThem.OnPressedState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(40)))), ((int)(((byte)(96)))), ((int)(((byte)(144)))));
            this.btnThem.OnPressedState.ForeColor = System.Drawing.Color.White;
            this.btnThem.OnPressedState.IconLeftImage = null;
            this.btnThem.OnPressedState.IconRightImage = null;
            this.btnThem.Size = new System.Drawing.Size(88, 39);
            this.btnThem.TabIndex = 5;
            this.btnThem.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.btnThem.TextAlignment = System.Windows.Forms.HorizontalAlignment.Center;
            this.btnThem.TextMarginLeft = 0;
            this.btnThem.TextPadding = new System.Windows.Forms.Padding(0);
            this.btnThem.UseDefaultRadiusAndThickness = true;
            this.btnThem.Click += new System.EventHandler(this.btnThem_Click);
            // 
            // btnXoa
            // 
            this.btnXoa.AllowAnimations = true;
            this.btnXoa.AllowMouseEffects = true;
            this.btnXoa.AllowToggling = false;
            this.btnXoa.AnimationSpeed = 200;
            this.btnXoa.AutoGenerateColors = false;
            this.btnXoa.AutoRoundBorders = false;
            this.btnXoa.AutoSizeLeftIcon = true;
            this.btnXoa.AutoSizeRightIcon = true;
            this.btnXoa.BackColor = System.Drawing.Color.Transparent;
            this.btnXoa.BackColor1 = System.Drawing.Color.DodgerBlue;
            this.btnXoa.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btnXoa.BackgroundImage")));
            this.btnXoa.BorderStyle = Bunifu.UI.WinForms.BunifuButton.BunifuButton2.BorderStyles.Solid;
            this.btnXoa.ButtonText = "<<";
            this.btnXoa.ButtonTextMarginLeft = 0;
            this.btnXoa.ColorContrastOnClick = 45;
            this.btnXoa.ColorContrastOnHover = 45;
            this.btnXoa.Cursor = System.Windows.Forms.Cursors.Default;
            borderEdges2.BottomLeft = true;
            borderEdges2.BottomRight = true;
            borderEdges2.TopLeft = true;
            borderEdges2.TopRight = true;
            this.btnXoa.CustomizableEdges = borderEdges2;
            this.btnXoa.DialogResult = System.Windows.Forms.DialogResult.None;
            this.btnXoa.DisabledBorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(191)))), ((int)(((byte)(191)))), ((int)(((byte)(191)))));
            this.btnXoa.DisabledFillColor = System.Drawing.Color.FromArgb(((int)(((byte)(204)))), ((int)(((byte)(204)))), ((int)(((byte)(204)))));
            this.btnXoa.DisabledForecolor = System.Drawing.Color.FromArgb(((int)(((byte)(168)))), ((int)(((byte)(160)))), ((int)(((byte)(168)))));
            this.btnXoa.FocusState = Bunifu.UI.WinForms.BunifuButton.BunifuButton2.ButtonStates.Pressed;
            this.btnXoa.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.btnXoa.ForeColor = System.Drawing.Color.White;
            this.btnXoa.IconLeftAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnXoa.IconLeftCursor = System.Windows.Forms.Cursors.Default;
            this.btnXoa.IconLeftPadding = new System.Windows.Forms.Padding(11, 3, 3, 3);
            this.btnXoa.IconMarginLeft = 11;
            this.btnXoa.IconPadding = 10;
            this.btnXoa.IconRightAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnXoa.IconRightCursor = System.Windows.Forms.Cursors.Default;
            this.btnXoa.IconRightPadding = new System.Windows.Forms.Padding(3, 3, 7, 3);
            this.btnXoa.IconSize = 25;
            this.btnXoa.IdleBorderColor = System.Drawing.Color.DodgerBlue;
            this.btnXoa.IdleBorderRadius = 1;
            this.btnXoa.IdleBorderThickness = 1;
            this.btnXoa.IdleFillColor = System.Drawing.Color.DodgerBlue;
            this.btnXoa.IdleIconLeftImage = null;
            this.btnXoa.IdleIconRightImage = null;
            this.btnXoa.IndicateFocus = false;
            this.btnXoa.Location = new System.Drawing.Point(586, 339);
            this.btnXoa.Name = "btnXoa";
            this.btnXoa.OnDisabledState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(191)))), ((int)(((byte)(191)))), ((int)(((byte)(191)))));
            this.btnXoa.OnDisabledState.BorderRadius = 1;
            this.btnXoa.OnDisabledState.BorderStyle = Bunifu.UI.WinForms.BunifuButton.BunifuButton2.BorderStyles.Solid;
            this.btnXoa.OnDisabledState.BorderThickness = 1;
            this.btnXoa.OnDisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(204)))), ((int)(((byte)(204)))), ((int)(((byte)(204)))));
            this.btnXoa.OnDisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(168)))), ((int)(((byte)(160)))), ((int)(((byte)(168)))));
            this.btnXoa.OnDisabledState.IconLeftImage = null;
            this.btnXoa.OnDisabledState.IconRightImage = null;
            this.btnXoa.onHoverState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(105)))), ((int)(((byte)(181)))), ((int)(((byte)(255)))));
            this.btnXoa.onHoverState.BorderRadius = 1;
            this.btnXoa.onHoverState.BorderStyle = Bunifu.UI.WinForms.BunifuButton.BunifuButton2.BorderStyles.Solid;
            this.btnXoa.onHoverState.BorderThickness = 1;
            this.btnXoa.onHoverState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(105)))), ((int)(((byte)(181)))), ((int)(((byte)(255)))));
            this.btnXoa.onHoverState.ForeColor = System.Drawing.Color.White;
            this.btnXoa.onHoverState.IconLeftImage = null;
            this.btnXoa.onHoverState.IconRightImage = null;
            this.btnXoa.OnIdleState.BorderColor = System.Drawing.Color.DodgerBlue;
            this.btnXoa.OnIdleState.BorderRadius = 1;
            this.btnXoa.OnIdleState.BorderStyle = Bunifu.UI.WinForms.BunifuButton.BunifuButton2.BorderStyles.Solid;
            this.btnXoa.OnIdleState.BorderThickness = 1;
            this.btnXoa.OnIdleState.FillColor = System.Drawing.Color.DodgerBlue;
            this.btnXoa.OnIdleState.ForeColor = System.Drawing.Color.White;
            this.btnXoa.OnIdleState.IconLeftImage = null;
            this.btnXoa.OnIdleState.IconRightImage = null;
            this.btnXoa.OnPressedState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(40)))), ((int)(((byte)(96)))), ((int)(((byte)(144)))));
            this.btnXoa.OnPressedState.BorderRadius = 1;
            this.btnXoa.OnPressedState.BorderStyle = Bunifu.UI.WinForms.BunifuButton.BunifuButton2.BorderStyles.Solid;
            this.btnXoa.OnPressedState.BorderThickness = 1;
            this.btnXoa.OnPressedState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(40)))), ((int)(((byte)(96)))), ((int)(((byte)(144)))));
            this.btnXoa.OnPressedState.ForeColor = System.Drawing.Color.White;
            this.btnXoa.OnPressedState.IconLeftImage = null;
            this.btnXoa.OnPressedState.IconRightImage = null;
            this.btnXoa.Size = new System.Drawing.Size(88, 39);
            this.btnXoa.TabIndex = 6;
            this.btnXoa.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.btnXoa.TextAlignment = System.Windows.Forms.HorizontalAlignment.Center;
            this.btnXoa.TextMarginLeft = 0;
            this.btnXoa.TextPadding = new System.Windows.Forms.Padding(0);
            this.btnXoa.UseDefaultRadiusAndThickness = true;
            this.btnXoa.Click += new System.EventHandler(this.btnXoa_Click);
            // 
            // ucGhiChu
            // 
            this.ucGhiChu.Label = "Ghi chú";
            this.ucGhiChu.Location = new System.Drawing.Point(766, 22);
            this.ucGhiChu.Name = "ucGhiChu";
            this.ucGhiChu.Size = new System.Drawing.Size(407, 55);
            this.ucGhiChu.TabIndex = 7;
            this.ucGhiChu.Textbox = "";
            // 
            // MaNhom
            // 
            this.MaNhom.DataPropertyName = "MaNhom";
            this.MaNhom.HeaderText = "Mã nhóm";
            this.MaNhom.MinimumWidth = 8;
            this.MaNhom.Name = "MaNhom";
            this.MaNhom.ReadOnly = true;
            // 
            // _MaND
            // 
            this._MaND.DataPropertyName = "MaND";
            this._MaND.HeaderText = "Mã ND";
            this._MaND.MinimumWidth = 8;
            this._MaND.Name = "_MaND";
            this._MaND.ReadOnly = true;
            // 
            // _TenTK
            // 
            this._TenTK.DataPropertyName = "TenTK";
            this._TenTK.HeaderText = "Tên tài khoản";
            this._TenTK.MinimumWidth = 8;
            this._TenTK.Name = "_TenTK";
            this._TenTK.ReadOnly = true;
            // 
            // _TenND
            // 
            this._TenND.DataPropertyName = "TenND";
            this._TenND.HeaderText = "Tên người dùng";
            this._TenND.MinimumWidth = 8;
            this._TenND.Name = "_TenND";
            this._TenND.ReadOnly = true;
            // 
            // GhiChu
            // 
            this.GhiChu.DataPropertyName = "GhiChu";
            this.GhiChu.HeaderText = "Ghi chú";
            this.GhiChu.MinimumWidth = 8;
            this.GhiChu.Name = "GhiChu";
            this.GhiChu.ReadOnly = true;
            // 
            // FrmND_NhomND
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1330, 637);
            this.Controls.Add(this.ucGhiChu);
            this.Controls.Add(this.btnXoa);
            this.Controls.Add(this.btnThem);
            this.Controls.Add(this.bunifuLabel1);
            this.Controls.Add(this.cboNhomND);
            this.Controls.Add(this.gBNdTrongNhom);
            this.Controls.Add(this.bunifuGroupBox1);
            this.Controls.Add(this.gBNguoiDung);
            this.Name = "FrmND_NhomND";
            this.Text = "Phân nhóm người dùng";
            this.Load += new System.EventHandler(this.FrmND_NhomND_Load);
            this.bunifuGroupBox1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvNguoiDung)).EndInit();
            this.gBNdTrongNhom.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvNguoiDungTrongNhom)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private Bunifu.UI.WinForms.BunifuGroupBox gBNguoiDung;
        private Bunifu.UI.WinForms.BunifuGroupBox bunifuGroupBox1;
        private Bunifu.UI.WinForms.BunifuGroupBox gBNdTrongNhom;
        private Bunifu.UI.WinForms.BunifuDropdown cboNhomND;
        private Bunifu.UI.WinForms.BunifuLabel bunifuLabel1;
        private Bunifu.UI.WinForms.BunifuButton.BunifuButton2 btnThem;
        private Bunifu.UI.WinForms.BunifuButton.BunifuButton2 btnXoa;
        private Bunifu.UI.WinForms.BunifuDataGridView dgvNguoiDung;
        private System.Windows.Forms.DataGridViewTextBoxColumn MaND;
        private System.Windows.Forms.DataGridViewTextBoxColumn TenTK;
        private System.Windows.Forms.DataGridViewTextBoxColumn TenND;
        private Bunifu.UI.WinForms.BunifuDataGridView dgvNguoiDungTrongNhom;
        private LabelTextbox_UC ucGhiChu;
        private System.Windows.Forms.DataGridViewTextBoxColumn MaNhom;
        private System.Windows.Forms.DataGridViewTextBoxColumn _MaND;
        private System.Windows.Forms.DataGridViewTextBoxColumn _TenTK;
        private System.Windows.Forms.DataGridViewTextBoxColumn _TenND;
        private System.Windows.Forms.DataGridViewTextBoxColumn GhiChu;
    }
}