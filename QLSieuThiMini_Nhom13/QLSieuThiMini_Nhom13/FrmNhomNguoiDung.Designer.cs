namespace QLSieuThiMini_Nhom13
{
    partial class FrmNhomNguoiDung
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FrmNhomNguoiDung));
            Bunifu.UI.WinForms.BunifuTextBox.StateProperties stateProperties1 = new Bunifu.UI.WinForms.BunifuTextBox.StateProperties();
            Bunifu.UI.WinForms.BunifuTextBox.StateProperties stateProperties2 = new Bunifu.UI.WinForms.BunifuTextBox.StateProperties();
            Bunifu.UI.WinForms.BunifuTextBox.StateProperties stateProperties3 = new Bunifu.UI.WinForms.BunifuTextBox.StateProperties();
            Bunifu.UI.WinForms.BunifuTextBox.StateProperties stateProperties4 = new Bunifu.UI.WinForms.BunifuTextBox.StateProperties();
            Bunifu.UI.WinForms.BunifuTextBox.StateProperties stateProperties5 = new Bunifu.UI.WinForms.BunifuTextBox.StateProperties();
            Bunifu.UI.WinForms.BunifuTextBox.StateProperties stateProperties6 = new Bunifu.UI.WinForms.BunifuTextBox.StateProperties();
            Bunifu.UI.WinForms.BunifuTextBox.StateProperties stateProperties7 = new Bunifu.UI.WinForms.BunifuTextBox.StateProperties();
            Bunifu.UI.WinForms.BunifuTextBox.StateProperties stateProperties8 = new Bunifu.UI.WinForms.BunifuTextBox.StateProperties();
            this.tableLayoutPanel3 = new System.Windows.Forms.TableLayoutPanel();
            this.bunifuGroupBox1 = new Bunifu.UI.WinForms.BunifuGroupBox();
            this.dgvNhomND = new Bunifu.UI.WinForms.BunifuDataGridView();
            this.MaNhom = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.TenNhom = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.txtTenND = new Bunifu.UI.WinForms.BunifuTextBox();
            this.txtGhiChu = new Bunifu.UI.WinForms.BunifuTextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.tableLayoutPanel4 = new System.Windows.Forms.TableLayoutPanel();
            this.btnCRUD_UC1 = new QLSieuThiMini_Nhom13.UserControls.BtnCRUD_UC();
            this.lbMaNhom = new System.Windows.Forms.Label();
            this.tableLayoutPanel3.SuspendLayout();
            this.bunifuGroupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvNhomND)).BeginInit();
            this.tableLayoutPanel1.SuspendLayout();
            this.tableLayoutPanel4.SuspendLayout();
            this.SuspendLayout();
            // 
            // tableLayoutPanel3
            // 
            this.tableLayoutPanel3.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.tableLayoutPanel3.ColumnCount = 1;
            this.tableLayoutPanel3.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel3.Controls.Add(this.bunifuGroupBox1, 0, 0);
            this.tableLayoutPanel3.Location = new System.Drawing.Point(46, 148);
            this.tableLayoutPanel3.Name = "tableLayoutPanel3";
            this.tableLayoutPanel3.RowCount = 1;
            this.tableLayoutPanel3.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel3.Size = new System.Drawing.Size(872, 309);
            this.tableLayoutPanel3.TabIndex = 51;
            // 
            // bunifuGroupBox1
            // 
            this.bunifuGroupBox1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.bunifuGroupBox1.BorderColor = System.Drawing.Color.LightGray;
            this.bunifuGroupBox1.BorderRadius = 1;
            this.bunifuGroupBox1.BorderThickness = 1;
            this.bunifuGroupBox1.Controls.Add(this.dgvNhomND);
            this.bunifuGroupBox1.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.bunifuGroupBox1.LabelAlign = System.Windows.Forms.HorizontalAlignment.Left;
            this.bunifuGroupBox1.LabelIndent = 10;
            this.bunifuGroupBox1.LineStyle = Bunifu.UI.WinForms.BunifuGroupBox.LineStyles.Solid;
            this.bunifuGroupBox1.Location = new System.Drawing.Point(3, 3);
            this.bunifuGroupBox1.Name = "bunifuGroupBox1";
            this.bunifuGroupBox1.Size = new System.Drawing.Size(866, 303);
            this.bunifuGroupBox1.TabIndex = 46;
            this.bunifuGroupBox1.TabStop = false;
            this.bunifuGroupBox1.Text = "Danh sách nhóm người dùng";
            // 
            // dgvNhomND
            // 
            this.dgvNhomND.AllowCustomTheming = false;
            dataGridViewCellStyle1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(248)))), ((int)(((byte)(251)))), ((int)(((byte)(255)))));
            dataGridViewCellStyle1.ForeColor = System.Drawing.Color.Black;
            this.dgvNhomND.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle1;
            this.dgvNhomND.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dgvNhomND.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvNhomND.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.dgvNhomND.CellBorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.SingleHorizontal;
            this.dgvNhomND.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.None;
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.BackColor = System.Drawing.Color.DodgerBlue;
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Segoe UI Semibold", 11.75F, System.Drawing.FontStyle.Bold);
            dataGridViewCellStyle2.ForeColor = System.Drawing.Color.White;
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(24)))), ((int)(((byte)(115)))), ((int)(((byte)(204)))));
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.Color.White;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvNhomND.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle2;
            this.dgvNhomND.ColumnHeadersHeight = 40;
            this.dgvNhomND.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.MaNhom,
            this.TenNhom});
            this.dgvNhomND.CurrentTheme.AlternatingRowsStyle.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(248)))), ((int)(((byte)(251)))), ((int)(((byte)(255)))));
            this.dgvNhomND.CurrentTheme.AlternatingRowsStyle.Font = new System.Drawing.Font("Segoe UI Semibold", 9.75F, System.Drawing.FontStyle.Bold);
            this.dgvNhomND.CurrentTheme.AlternatingRowsStyle.ForeColor = System.Drawing.Color.Black;
            this.dgvNhomND.CurrentTheme.AlternatingRowsStyle.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(210)))), ((int)(((byte)(232)))), ((int)(((byte)(255)))));
            this.dgvNhomND.CurrentTheme.AlternatingRowsStyle.SelectionForeColor = System.Drawing.Color.Black;
            this.dgvNhomND.CurrentTheme.BackColor = System.Drawing.Color.White;
            this.dgvNhomND.CurrentTheme.GridColor = System.Drawing.Color.FromArgb(((int)(((byte)(221)))), ((int)(((byte)(238)))), ((int)(((byte)(255)))));
            this.dgvNhomND.CurrentTheme.HeaderStyle.BackColor = System.Drawing.Color.DodgerBlue;
            this.dgvNhomND.CurrentTheme.HeaderStyle.Font = new System.Drawing.Font("Segoe UI Semibold", 11.75F, System.Drawing.FontStyle.Bold);
            this.dgvNhomND.CurrentTheme.HeaderStyle.ForeColor = System.Drawing.Color.White;
            this.dgvNhomND.CurrentTheme.HeaderStyle.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(24)))), ((int)(((byte)(115)))), ((int)(((byte)(204)))));
            this.dgvNhomND.CurrentTheme.HeaderStyle.SelectionForeColor = System.Drawing.Color.White;
            this.dgvNhomND.CurrentTheme.Name = null;
            this.dgvNhomND.CurrentTheme.RowsStyle.BackColor = System.Drawing.Color.White;
            this.dgvNhomND.CurrentTheme.RowsStyle.Font = new System.Drawing.Font("Segoe UI Semibold", 9.75F, System.Drawing.FontStyle.Bold);
            this.dgvNhomND.CurrentTheme.RowsStyle.ForeColor = System.Drawing.Color.Black;
            this.dgvNhomND.CurrentTheme.RowsStyle.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(210)))), ((int)(((byte)(232)))), ((int)(((byte)(255)))));
            this.dgvNhomND.CurrentTheme.RowsStyle.SelectionForeColor = System.Drawing.Color.Black;
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle3.BackColor = System.Drawing.Color.White;
            dataGridViewCellStyle3.Font = new System.Drawing.Font("Segoe UI Semibold", 9.75F, System.Drawing.FontStyle.Bold);
            dataGridViewCellStyle3.ForeColor = System.Drawing.Color.Black;
            dataGridViewCellStyle3.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(210)))), ((int)(((byte)(232)))), ((int)(((byte)(255)))));
            dataGridViewCellStyle3.SelectionForeColor = System.Drawing.Color.Black;
            dataGridViewCellStyle3.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dgvNhomND.DefaultCellStyle = dataGridViewCellStyle3;
            this.dgvNhomND.EnableHeadersVisualStyles = false;
            this.dgvNhomND.GridColor = System.Drawing.Color.FromArgb(((int)(((byte)(221)))), ((int)(((byte)(238)))), ((int)(((byte)(255)))));
            this.dgvNhomND.HeaderBackColor = System.Drawing.Color.DodgerBlue;
            this.dgvNhomND.HeaderBgColor = System.Drawing.Color.Empty;
            this.dgvNhomND.HeaderForeColor = System.Drawing.Color.White;
            this.dgvNhomND.Location = new System.Drawing.Point(6, 25);
            this.dgvNhomND.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.dgvNhomND.Name = "dgvNhomND";
            this.dgvNhomND.RowHeadersVisible = false;
            this.dgvNhomND.RowHeadersWidth = 62;
            this.dgvNhomND.RowTemplate.Height = 40;
            this.dgvNhomND.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvNhomND.Size = new System.Drawing.Size(860, 273);
            this.dgvNhomND.TabIndex = 16;
            this.dgvNhomND.Theme = Bunifu.UI.WinForms.BunifuDataGridView.PresetThemes.Light;
            // 
            // MaNhom
            // 
            this.MaNhom.DataPropertyName = "MaNhom";
            this.MaNhom.HeaderText = "Mã Nhóm";
            this.MaNhom.MinimumWidth = 8;
            this.MaNhom.Name = "MaNhom";
            // 
            // TenNhom
            // 
            this.TenNhom.DataPropertyName = "TenNhom";
            this.TenNhom.HeaderText = "Tên nhóm";
            this.TenNhom.MinimumWidth = 8;
            this.TenNhom.Name = "TenNhom";
            // 
            // label3
            // 
            this.label3.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(83, 26);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(51, 16);
            this.label3.TabIndex = 46;
            this.label3.Text = "Ghi chú";
            // 
            // label2
            // 
            this.label2.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(511, 15);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(67, 16);
            this.label2.TabIndex = 45;
            this.label2.Text = "Tên nhóm";
            // 
            // txtTenND
            // 
            this.txtTenND.AcceptsReturn = false;
            this.txtTenND.AcceptsTab = false;
            this.txtTenND.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtTenND.AnimationSpeed = 200;
            this.txtTenND.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.None;
            this.txtTenND.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.None;
            this.txtTenND.AutoSizeHeight = true;
            this.txtTenND.BackColor = System.Drawing.Color.Transparent;
            this.txtTenND.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("txtTenND.BackgroundImage")));
            this.txtTenND.BorderColorActive = System.Drawing.Color.DodgerBlue;
            this.txtTenND.BorderColorDisabled = System.Drawing.Color.FromArgb(((int)(((byte)(204)))), ((int)(((byte)(204)))), ((int)(((byte)(204)))));
            this.txtTenND.BorderColorHover = System.Drawing.Color.FromArgb(((int)(((byte)(105)))), ((int)(((byte)(181)))), ((int)(((byte)(255)))));
            this.txtTenND.BorderColorIdle = System.Drawing.Color.Silver;
            this.txtTenND.BorderRadius = 1;
            this.txtTenND.BorderThickness = 1;
            this.txtTenND.CharacterCase = Bunifu.UI.WinForms.BunifuTextBox.CharacterCases.Normal;
            this.txtTenND.CharacterCasing = System.Windows.Forms.CharacterCasing.Normal;
            this.txtTenND.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.txtTenND.DefaultFont = new System.Drawing.Font("Segoe UI", 9.25F);
            this.txtTenND.DefaultText = "";
            this.txtTenND.FillColor = System.Drawing.Color.White;
            this.txtTenND.HideSelection = true;
            this.txtTenND.IconLeft = null;
            this.txtTenND.IconLeftCursor = System.Windows.Forms.Cursors.IBeam;
            this.txtTenND.IconPadding = 10;
            this.txtTenND.IconRight = null;
            this.txtTenND.IconRightCursor = System.Windows.Forms.Cursors.IBeam;
            this.txtTenND.Lines = new string[0];
            this.txtTenND.Location = new System.Drawing.Point(657, 2);
            this.txtTenND.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.txtTenND.MaxLength = 32767;
            this.txtTenND.MinimumSize = new System.Drawing.Size(1, 1);
            this.txtTenND.Modified = false;
            this.txtTenND.Multiline = false;
            this.txtTenND.Name = "txtTenND";
            stateProperties1.BorderColor = System.Drawing.Color.DodgerBlue;
            stateProperties1.FillColor = System.Drawing.Color.Empty;
            stateProperties1.ForeColor = System.Drawing.Color.Empty;
            stateProperties1.PlaceholderForeColor = System.Drawing.Color.Empty;
            this.txtTenND.OnActiveState = stateProperties1;
            stateProperties2.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(204)))), ((int)(((byte)(204)))), ((int)(((byte)(204)))));
            stateProperties2.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(240)))), ((int)(((byte)(240)))), ((int)(((byte)(240)))));
            stateProperties2.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(109)))), ((int)(((byte)(109)))), ((int)(((byte)(109)))));
            stateProperties2.PlaceholderForeColor = System.Drawing.Color.DarkGray;
            this.txtTenND.OnDisabledState = stateProperties2;
            stateProperties3.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(105)))), ((int)(((byte)(181)))), ((int)(((byte)(255)))));
            stateProperties3.FillColor = System.Drawing.Color.Empty;
            stateProperties3.ForeColor = System.Drawing.Color.Empty;
            stateProperties3.PlaceholderForeColor = System.Drawing.Color.Empty;
            this.txtTenND.OnHoverState = stateProperties3;
            stateProperties4.BorderColor = System.Drawing.Color.Silver;
            stateProperties4.FillColor = System.Drawing.Color.White;
            stateProperties4.ForeColor = System.Drawing.Color.Empty;
            stateProperties4.PlaceholderForeColor = System.Drawing.Color.Empty;
            this.txtTenND.OnIdleState = stateProperties4;
            this.txtTenND.Padding = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.txtTenND.PasswordChar = '\0';
            this.txtTenND.PlaceholderForeColor = System.Drawing.Color.Silver;
            this.txtTenND.PlaceholderText = "";
            this.txtTenND.ReadOnly = false;
            this.txtTenND.ScrollBars = System.Windows.Forms.ScrollBars.None;
            this.txtTenND.SelectedText = "";
            this.txtTenND.SelectionLength = 0;
            this.txtTenND.SelectionStart = 0;
            this.txtTenND.ShortcutsEnabled = true;
            this.txtTenND.Size = new System.Drawing.Size(212, 43);
            this.txtTenND.Style = Bunifu.UI.WinForms.BunifuTextBox._Style.Bunifu;
            this.txtTenND.TabIndex = 40;
            this.txtTenND.TextAlign = System.Windows.Forms.HorizontalAlignment.Left;
            this.txtTenND.TextMarginBottom = 0;
            this.txtTenND.TextMarginLeft = 3;
            this.txtTenND.TextMarginTop = 1;
            this.txtTenND.TextPlaceholder = "";
            this.txtTenND.UseSystemPasswordChar = false;
            this.txtTenND.WordWrap = true;
            // 
            // txtGhiChu
            // 
            this.txtGhiChu.AcceptsReturn = false;
            this.txtGhiChu.AcceptsTab = false;
            this.txtGhiChu.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtGhiChu.AnimationSpeed = 200;
            this.txtGhiChu.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.None;
            this.txtGhiChu.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.None;
            this.txtGhiChu.AutoSizeHeight = true;
            this.txtGhiChu.BackColor = System.Drawing.Color.Transparent;
            this.txtGhiChu.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("txtGhiChu.BackgroundImage")));
            this.txtGhiChu.BorderColorActive = System.Drawing.Color.DodgerBlue;
            this.txtGhiChu.BorderColorDisabled = System.Drawing.Color.FromArgb(((int)(((byte)(204)))), ((int)(((byte)(204)))), ((int)(((byte)(204)))));
            this.txtGhiChu.BorderColorHover = System.Drawing.Color.FromArgb(((int)(((byte)(105)))), ((int)(((byte)(181)))), ((int)(((byte)(255)))));
            this.txtGhiChu.BorderColorIdle = System.Drawing.Color.Silver;
            this.txtGhiChu.BorderRadius = 1;
            this.txtGhiChu.BorderThickness = 1;
            this.txtGhiChu.CharacterCase = Bunifu.UI.WinForms.BunifuTextBox.CharacterCases.Normal;
            this.txtGhiChu.CharacterCasing = System.Windows.Forms.CharacterCasing.Normal;
            this.txtGhiChu.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.txtGhiChu.DefaultFont = new System.Drawing.Font("Segoe UI", 9.25F);
            this.txtGhiChu.DefaultText = "";
            this.txtGhiChu.FillColor = System.Drawing.Color.White;
            this.txtGhiChu.HideSelection = true;
            this.txtGhiChu.IconLeft = null;
            this.txtGhiChu.IconLeftCursor = System.Windows.Forms.Cursors.IBeam;
            this.txtGhiChu.IconPadding = 10;
            this.txtGhiChu.IconRight = null;
            this.txtGhiChu.IconRightCursor = System.Windows.Forms.Cursors.IBeam;
            this.txtGhiChu.Lines = new string[0];
            this.txtGhiChu.Location = new System.Drawing.Point(221, 2);
            this.txtGhiChu.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.txtGhiChu.MaxLength = 32767;
            this.txtGhiChu.MinimumSize = new System.Drawing.Size(1, 1);
            this.txtGhiChu.Modified = false;
            this.txtGhiChu.Multiline = false;
            this.txtGhiChu.Name = "txtGhiChu";
            stateProperties5.BorderColor = System.Drawing.Color.DodgerBlue;
            stateProperties5.FillColor = System.Drawing.Color.Empty;
            stateProperties5.ForeColor = System.Drawing.Color.Empty;
            stateProperties5.PlaceholderForeColor = System.Drawing.Color.Empty;
            this.txtGhiChu.OnActiveState = stateProperties5;
            stateProperties6.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(204)))), ((int)(((byte)(204)))), ((int)(((byte)(204)))));
            stateProperties6.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(240)))), ((int)(((byte)(240)))), ((int)(((byte)(240)))));
            stateProperties6.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(109)))), ((int)(((byte)(109)))), ((int)(((byte)(109)))));
            stateProperties6.PlaceholderForeColor = System.Drawing.Color.DarkGray;
            this.txtGhiChu.OnDisabledState = stateProperties6;
            stateProperties7.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(105)))), ((int)(((byte)(181)))), ((int)(((byte)(255)))));
            stateProperties7.FillColor = System.Drawing.Color.Empty;
            stateProperties7.ForeColor = System.Drawing.Color.Empty;
            stateProperties7.PlaceholderForeColor = System.Drawing.Color.Empty;
            this.txtGhiChu.OnHoverState = stateProperties7;
            stateProperties8.BorderColor = System.Drawing.Color.Silver;
            stateProperties8.FillColor = System.Drawing.Color.White;
            stateProperties8.ForeColor = System.Drawing.Color.Empty;
            stateProperties8.PlaceholderForeColor = System.Drawing.Color.Empty;
            this.txtGhiChu.OnIdleState = stateProperties8;
            this.txtGhiChu.Padding = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.txtGhiChu.PasswordChar = '\0';
            this.txtGhiChu.PlaceholderForeColor = System.Drawing.Color.Silver;
            this.txtGhiChu.PlaceholderText = "";
            this.txtGhiChu.ReadOnly = false;
            this.txtGhiChu.ScrollBars = System.Windows.Forms.ScrollBars.None;
            this.txtGhiChu.SelectedText = "";
            this.txtGhiChu.SelectionLength = 0;
            this.txtGhiChu.SelectionStart = 0;
            this.txtGhiChu.ShortcutsEnabled = true;
            this.txtGhiChu.Size = new System.Drawing.Size(648, 64);
            this.txtGhiChu.Style = Bunifu.UI.WinForms.BunifuTextBox._Style.Bunifu;
            this.txtGhiChu.TabIndex = 42;
            this.txtGhiChu.TextAlign = System.Windows.Forms.HorizontalAlignment.Left;
            this.txtGhiChu.TextMarginBottom = 0;
            this.txtGhiChu.TextMarginLeft = 3;
            this.txtGhiChu.TextMarginTop = 1;
            this.txtGhiChu.TextPlaceholder = "";
            this.txtGhiChu.UseSystemPasswordChar = false;
            this.txtGhiChu.WordWrap = true;
            // 
            // label1
            // 
            this.label1.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(78, 15);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(62, 16);
            this.label1.TabIndex = 44;
            this.label1.Text = "Mã nhóm";
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.tableLayoutPanel1.ColumnCount = 4;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 25F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 25F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 25F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 25F));
            this.tableLayoutPanel1.Controls.Add(this.lbMaNhom, 0, 0);
            this.tableLayoutPanel1.Controls.Add(this.label2, 2, 0);
            this.tableLayoutPanel1.Controls.Add(this.txtTenND, 3, 0);
            this.tableLayoutPanel1.Controls.Add(this.label1, 0, 0);
            this.tableLayoutPanel1.Location = new System.Drawing.Point(46, 12);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 1;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(872, 47);
            this.tableLayoutPanel1.TabIndex = 48;
            // 
            // tableLayoutPanel4
            // 
            this.tableLayoutPanel4.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.tableLayoutPanel4.ColumnCount = 2;
            this.tableLayoutPanel4.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 25F));
            this.tableLayoutPanel4.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 75F));
            this.tableLayoutPanel4.Controls.Add(this.label3, 0, 0);
            this.tableLayoutPanel4.Controls.Add(this.txtGhiChu, 1, 0);
            this.tableLayoutPanel4.Location = new System.Drawing.Point(46, 65);
            this.tableLayoutPanel4.Name = "tableLayoutPanel4";
            this.tableLayoutPanel4.RowCount = 1;
            this.tableLayoutPanel4.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel4.Size = new System.Drawing.Size(872, 68);
            this.tableLayoutPanel4.TabIndex = 49;
            // 
            // btnCRUD_UC1
            // 
            this.btnCRUD_UC1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.btnCRUD_UC1.Location = new System.Drawing.Point(49, 478);
            this.btnCRUD_UC1.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.btnCRUD_UC1.Name = "btnCRUD_UC1";
            this.btnCRUD_UC1.Size = new System.Drawing.Size(866, 62);
            this.btnCRUD_UC1.TabIndex = 52;
            this.btnCRUD_UC1.LuuClicked += new QLSieuThiMini_Nhom13.UserControls.BtnCRUD_UC.LuuClickedHandler(this.btnCRUD_UC1_LuuClicked);
            this.btnCRUD_UC1.ThemClicked += new QLSieuThiMini_Nhom13.UserControls.BtnCRUD_UC.ThemClickedHandler(this.btnCRUD_UC1_ThemClicked);
            this.btnCRUD_UC1.SuaClicked += new QLSieuThiMini_Nhom13.UserControls.BtnCRUD_UC.SuaClickedHandler(this.btnCRUD_UC1_SuaClicked);
            this.btnCRUD_UC1.XoaClicked += new QLSieuThiMini_Nhom13.UserControls.BtnCRUD_UC.XoaClickedHandler(this.btnCRUD_UC1_XoaClicked);
            this.btnCRUD_UC1.HuyClicked += new QLSieuThiMini_Nhom13.UserControls.BtnCRUD_UC.HuyClickedHandler(this.btnCRUD_UC1_HuyClicked);
            this.btnCRUD_UC1.Load += new System.EventHandler(this.btnCRUD_UC1_Load);
            // 
            // lbMaNhom
            // 
            this.lbMaNhom.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.lbMaNhom.AutoSize = true;
            this.lbMaNhom.Location = new System.Drawing.Point(296, 15);
            this.lbMaNhom.Name = "lbMaNhom";
            this.lbMaNhom.Size = new System.Drawing.Size(62, 16);
            this.lbMaNhom.TabIndex = 46;
            this.lbMaNhom.Text = "Mã nhóm";
            // 
            // FrmNhomNguoiDung
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(965, 551);
            this.Controls.Add(this.btnCRUD_UC1);
            this.Controls.Add(this.tableLayoutPanel3);
            this.Controls.Add(this.tableLayoutPanel4);
            this.Controls.Add(this.tableLayoutPanel1);
            this.Name = "FrmNhomNguoiDung";
            this.Text = "FrmNhomNguoiDung";
            this.Load += new System.EventHandler(this.FrmNhomNguoiDung_Load);
            this.tableLayoutPanel3.ResumeLayout(false);
            this.bunifuGroupBox1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvNhomND)).EndInit();
            this.tableLayoutPanel1.ResumeLayout(false);
            this.tableLayoutPanel1.PerformLayout();
            this.tableLayoutPanel4.ResumeLayout(false);
            this.tableLayoutPanel4.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel3;
        private Bunifu.UI.WinForms.BunifuGroupBox bunifuGroupBox1;
        private Bunifu.UI.WinForms.BunifuDataGridView dgvNhomND;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private Bunifu.UI.WinForms.BunifuTextBox txtTenND;
        private Bunifu.UI.WinForms.BunifuTextBox txtGhiChu;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel4;
        private UserControls.BtnCRUD_UC btnCRUD_UC1;
        private System.Windows.Forms.DataGridViewTextBoxColumn MaNhom;
        private System.Windows.Forms.DataGridViewTextBoxColumn TenNhom;
        private System.Windows.Forms.Label lbMaNhom;
    }
}