namespace Library_ManagementGUI
{
    partial class frmThemSach
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
            this.txtSearch_frmMuon = new System.Windows.Forms.TextBox();
            this.lbSearch = new System.Windows.Forms.Label();
            this.dgvLoadSach = new DevComponents.DotNetBar.Controls.DataGridViewX();
            this.fillByToolStripButton = new System.Windows.Forms.ToolStripButton();
            this.dgvThemSach_frmMuon = new DevComponents.DotNetBar.Controls.DataGridViewX();
            this.btnXoaSach = new DevComponents.DotNetBar.ButtonX();
            this.btnThemSach = new DevComponents.DotNetBar.ButtonX();
            this.btnOK = new DevComponents.DotNetBar.ButtonX();
            this.btnCancel = new DevComponents.DotNetBar.ButtonX();
            this.txtTenDG_frmMuon = new DevComponents.DotNetBar.Controls.TextBoxX();
            this.lbTenDG_frmMuon = new DevComponents.DotNetBar.LabelX();
            this.lbMaDG_frmMuon = new DevComponents.DotNetBar.LabelX();
            this.cmbxMaDG_frmMuon = new DevComponents.DotNetBar.Controls.ComboBoxEx();
            ((System.ComponentModel.ISupportInitialize)(this.dgvLoadSach)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvThemSach_frmMuon)).BeginInit();
            this.SuspendLayout();
            // 
            // txtSearch_frmMuon
            // 
            this.txtSearch_frmMuon.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend;
            this.txtSearch_frmMuon.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.RecentlyUsedList;
            this.txtSearch_frmMuon.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtSearch_frmMuon.Location = new System.Drawing.Point(398, 68);
            this.txtSearch_frmMuon.Name = "txtSearch_frmMuon";
            this.txtSearch_frmMuon.Size = new System.Drawing.Size(452, 22);
            this.txtSearch_frmMuon.TabIndex = 56;
            this.txtSearch_frmMuon.TextChanged += new System.EventHandler(this.txtSearch_frmMuon_TextChanged_1);
            // 
            // lbSearch
            // 
            this.lbSearch.AutoSize = true;
            this.lbSearch.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbSearch.Location = new System.Drawing.Point(326, 71);
            this.lbSearch.Name = "lbSearch";
            this.lbSearch.Size = new System.Drawing.Size(61, 18);
            this.lbSearch.TabIndex = 57;
            this.lbSearch.Text = "Search";
            // 
            // dgvLoadSach
            // 
            this.dgvLoadSach.AllowUserToDeleteRows = false;
            this.dgvLoadSach.AllowUserToOrderColumns = true;
            this.dgvLoadSach.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.DisplayedCells;
            this.dgvLoadSach.BackgroundColor = System.Drawing.SystemColors.ControlLightLight;
            this.dgvLoadSach.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dgvLoadSach.DefaultCellStyle = dataGridViewCellStyle1;
            this.dgvLoadSach.GridColor = System.Drawing.Color.FromArgb(((int)(((byte)(208)))), ((int)(((byte)(215)))), ((int)(((byte)(229)))));
            this.dgvLoadSach.Location = new System.Drawing.Point(12, 141);
            this.dgvLoadSach.Name = "dgvLoadSach";
            this.dgvLoadSach.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvLoadSach.Size = new System.Drawing.Size(838, 488);
            this.dgvLoadSach.TabIndex = 58;
            // 
            // fillByToolStripButton
            // 
            this.fillByToolStripButton.Name = "fillByToolStripButton";
            this.fillByToolStripButton.Size = new System.Drawing.Size(23, 23);
            // 
            // dgvThemSach_frmMuon
            // 
            this.dgvThemSach_frmMuon.AllowUserToAddRows = false;
            this.dgvThemSach_frmMuon.AllowUserToDeleteRows = false;
            this.dgvThemSach_frmMuon.AllowUserToResizeColumns = false;
            this.dgvThemSach_frmMuon.AllowUserToResizeRows = false;
            this.dgvThemSach_frmMuon.BackgroundColor = System.Drawing.SystemColors.ControlLightLight;
            this.dgvThemSach_frmMuon.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle2.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dgvThemSach_frmMuon.DefaultCellStyle = dataGridViewCellStyle2;
            this.dgvThemSach_frmMuon.EditMode = System.Windows.Forms.DataGridViewEditMode.EditProgrammatically;
            this.dgvThemSach_frmMuon.GridColor = System.Drawing.Color.FromArgb(((int)(((byte)(208)))), ((int)(((byte)(215)))), ((int)(((byte)(229)))));
            this.dgvThemSach_frmMuon.Location = new System.Drawing.Point(922, 141);
            this.dgvThemSach_frmMuon.Name = "dgvThemSach_frmMuon";
            this.dgvThemSach_frmMuon.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvThemSach_frmMuon.Size = new System.Drawing.Size(495, 488);
            this.dgvThemSach_frmMuon.TabIndex = 59;
            // 
            // btnXoaSach
            // 
            this.btnXoaSach.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton;
            this.btnXoaSach.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground;
            this.btnXoaSach.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnXoaSach.Location = new System.Drawing.Point(866, 355);
            this.btnXoaSach.Name = "btnXoaSach";
            this.btnXoaSach.Size = new System.Drawing.Size(50, 23);
            this.btnXoaSach.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.btnXoaSach.TabIndex = 62;
            this.btnXoaSach.Text = "<<<";
            this.btnXoaSach.Tooltip = "Xóa Khỏi Bảng";
            this.btnXoaSach.Click += new System.EventHandler(this.btnXoaSach_Click);
            // 
            // btnThemSach
            // 
            this.btnThemSach.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton;
            this.btnThemSach.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground;
            this.btnThemSach.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnThemSach.Location = new System.Drawing.Point(866, 326);
            this.btnThemSach.Name = "btnThemSach";
            this.btnThemSach.Size = new System.Drawing.Size(50, 23);
            this.btnThemSach.SplitButton = true;
            this.btnThemSach.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.btnThemSach.TabIndex = 61;
            this.btnThemSach.Text = ">>>";
            this.btnThemSach.ThemeAware = true;
            this.btnThemSach.Tooltip = "Thêm Vào Bảng";
            this.btnThemSach.Click += new System.EventHandler(this.buttonX3_Click);
            // 
            // btnOK
            // 
            this.btnOK.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton;
            this.btnOK.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground;
            this.btnOK.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnOK.Image = global::Library_ManagementGUI.Properties.Resources.OK2;
            this.btnOK.Location = new System.Drawing.Point(12, 58);
            this.btnOK.Name = "btnOK";
            this.btnOK.Size = new System.Drawing.Size(111, 45);
            this.btnOK.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.btnOK.TabIndex = 48;
            this.btnOK.Text = "Hoàn Thành";
            this.btnOK.TextColor = System.Drawing.Color.Black;
            this.btnOK.Click += new System.EventHandler(this.btnOK_Click);
            // 
            // btnCancel
            // 
            this.btnCancel.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton;
            this.btnCancel.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground;
            this.btnCancel.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnCancel.Image = global::Library_ManagementGUI.Properties.Resources.Cancel1;
            this.btnCancel.Location = new System.Drawing.Point(151, 58);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(111, 45);
            this.btnCancel.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.btnCancel.TabIndex = 44;
            this.btnCancel.Text = "Hủy";
            this.btnCancel.TextColor = System.Drawing.Color.Black;
            this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
            // 
            // txtTenDG_frmMuon
            // 
            this.txtTenDG_frmMuon.BackColor = System.Drawing.Color.White;
            // 
            // 
            // 
            this.txtTenDG_frmMuon.Border.Class = "TextBoxBorder";
            this.txtTenDG_frmMuon.Border.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.txtTenDG_frmMuon.DisabledBackColor = System.Drawing.Color.White;
            this.txtTenDG_frmMuon.ForeColor = System.Drawing.Color.Black;
            this.txtTenDG_frmMuon.Location = new System.Drawing.Point(997, 92);
            this.txtTenDG_frmMuon.Name = "txtTenDG_frmMuon";
            this.txtTenDG_frmMuon.PreventEnterBeep = true;
            this.txtTenDG_frmMuon.ReadOnly = true;
            this.txtTenDG_frmMuon.Size = new System.Drawing.Size(305, 20);
            this.txtTenDG_frmMuon.TabIndex = 69;
            // 
            // lbTenDG_frmMuon
            // 
            this.lbTenDG_frmMuon.AutoSize = true;
            // 
            // 
            // 
            this.lbTenDG_frmMuon.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.lbTenDG_frmMuon.Location = new System.Drawing.Point(921, 93);
            this.lbTenDG_frmMuon.Name = "lbTenDG_frmMuon";
            this.lbTenDG_frmMuon.Size = new System.Drawing.Size(44, 15);
            this.lbTenDG_frmMuon.TabIndex = 68;
            this.lbTenDG_frmMuon.Text = "Tên ĐG:";
            // 
            // lbMaDG_frmMuon
            // 
            this.lbMaDG_frmMuon.AutoSize = true;
            // 
            // 
            // 
            this.lbMaDG_frmMuon.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.lbMaDG_frmMuon.Location = new System.Drawing.Point(921, 58);
            this.lbMaDG_frmMuon.Name = "lbMaDG_frmMuon";
            this.lbMaDG_frmMuon.Size = new System.Drawing.Size(40, 15);
            this.lbMaDG_frmMuon.TabIndex = 67;
            this.lbMaDG_frmMuon.Text = "Mã ĐG:";
            // 
            // cmbxMaDG_frmMuon
            // 
            this.cmbxMaDG_frmMuon.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.Suggest;
            this.cmbxMaDG_frmMuon.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems;
            this.cmbxMaDG_frmMuon.DisplayMember = "Text";
            this.cmbxMaDG_frmMuon.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed;
            this.cmbxMaDG_frmMuon.ForeColor = System.Drawing.Color.Black;
            this.cmbxMaDG_frmMuon.FormattingEnabled = true;
            this.cmbxMaDG_frmMuon.ItemHeight = 15;
            this.cmbxMaDG_frmMuon.Location = new System.Drawing.Point(997, 58);
            this.cmbxMaDG_frmMuon.Name = "cmbxMaDG_frmMuon";
            this.cmbxMaDG_frmMuon.Size = new System.Drawing.Size(304, 21);
            this.cmbxMaDG_frmMuon.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.cmbxMaDG_frmMuon.TabIndex = 71;
            this.cmbxMaDG_frmMuon.SelectedIndexChanged += new System.EventHandler(this.cmbxMaDG_frmMuon_SelectedIndexChanged);
            this.cmbxMaDG_frmMuon.PreviewKeyDown += new System.Windows.Forms.PreviewKeyDownEventHandler(this.cmbxMaDG_frmMuon_PreviewKeyDown);
            // 
            // frmThemSach
            // 
            this.BackColor = System.Drawing.SystemColors.GradientInactiveCaption;
            this.ClientSize = new System.Drawing.Size(1429, 641);
            this.Controls.Add(this.cmbxMaDG_frmMuon);
            this.Controls.Add(this.txtTenDG_frmMuon);
            this.Controls.Add(this.lbTenDG_frmMuon);
            this.Controls.Add(this.lbMaDG_frmMuon);
            this.Controls.Add(this.btnXoaSach);
            this.Controls.Add(this.btnThemSach);
            this.Controls.Add(this.dgvThemSach_frmMuon);
            this.Controls.Add(this.dgvLoadSach);
            this.Controls.Add(this.lbSearch);
            this.Controls.Add(this.txtSearch_frmMuon);
            this.Controls.Add(this.btnOK);
            this.Controls.Add(this.btnCancel);
            this.DoubleBuffered = true;
            this.Name = "frmThemSach";
            this.Text = "Quản Lý Thư Viện - Form Mượn Sách";
            ((System.ComponentModel.ISupportInitialize)(this.dgvLoadSach)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvThemSach_frmMuon)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private DevComponents.DotNetBar.ButtonX btnCancel;
        private DevComponents.DotNetBar.ButtonX btnOK;
        private System.Windows.Forms.TextBox txtSearch_frmMuon;
        private System.Windows.Forms.Label lbSearch;
        private DevComponents.DotNetBar.Controls.DataGridViewX dgvLoadSach;
        private System.Windows.Forms.ToolStripButton fillByToolStripButton;
        private DevComponents.DotNetBar.Controls.DataGridViewX dgvThemSach_frmMuon;
        private DevComponents.DotNetBar.ButtonX btnXoaSach;
        private DevComponents.DotNetBar.ButtonX btnThemSach;
        private DevComponents.DotNetBar.Controls.TextBoxX txtTenDG_frmMuon;
        private DevComponents.DotNetBar.LabelX lbTenDG_frmMuon;
        private DevComponents.DotNetBar.LabelX lbMaDG_frmMuon;
        private DevComponents.DotNetBar.Controls.ComboBoxEx cmbxMaDG_frmMuon;
      
    }
}