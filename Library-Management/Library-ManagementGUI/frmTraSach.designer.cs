namespace Library_ManagementGUI
{
    partial class frmTraSach
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
            this.dgvSach = new DevComponents.DotNetBar.Controls.DataGridViewX();
            this.fillByToolStripButton = new System.Windows.Forms.ToolStripButton();
            this.btnOK_frmTraSach = new DevComponents.DotNetBar.ButtonX();
            this.btnCancel_frmTraSach = new DevComponents.DotNetBar.ButtonX();
            this.txtTenDG_frmTraSach = new DevComponents.DotNetBar.Controls.TextBoxX();
            this.lbTenDG_frmMuon = new DevComponents.DotNetBar.LabelX();
            this.lbMaDG_frmMuon = new DevComponents.DotNetBar.LabelX();
            this.txtMaDG_frmTraSach = new DevComponents.DotNetBar.Controls.TextBoxX();
            ((System.ComponentModel.ISupportInitialize)(this.dgvSach)).BeginInit();
            this.SuspendLayout();
            // 
            // dgvSach
            // 
            this.dgvSach.BackgroundColor = System.Drawing.SystemColors.ControlLightLight;
            this.dgvSach.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvSach.Location = new System.Drawing.Point(12, 141);
            this.dgvSach.Name = "dgvSach";
            this.dgvSach.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvSach.Size = new System.Drawing.Size(1204, 463);
            this.dgvSach.TabIndex = 58;
            this.dgvSach.CellValueChanged += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvSach_CellValueChanged);
            this.dgvSach.CurrentCellDirtyStateChanged += new System.EventHandler(this.dgvSach_CurrentCellDirtyStateChanged);
            // 
            // fillByToolStripButton
            // 
            this.fillByToolStripButton.Name = "fillByToolStripButton";
            this.fillByToolStripButton.Size = new System.Drawing.Size(23, 23);
            // 
            // btnOK_frmTraSach
            // 
            this.btnOK_frmTraSach.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton;
            this.btnOK_frmTraSach.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground;
            this.btnOK_frmTraSach.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnOK_frmTraSach.Location = new System.Drawing.Point(12, 24);
            this.btnOK_frmTraSach.Name = "btnOK_frmTraSach";
            this.btnOK_frmTraSach.Size = new System.Drawing.Size(111, 45);
            this.btnOK_frmTraSach.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.btnOK_frmTraSach.TabIndex = 48;
            this.btnOK_frmTraSach.Text = "Hoàn Thành";
            this.btnOK_frmTraSach.TextColor = System.Drawing.Color.Black;
            this.btnOK_frmTraSach.Click += new System.EventHandler(this.btnOK_frmTraSach_Click);
            // 
            // btnCancel_frmTraSach
            // 
            this.btnCancel_frmTraSach.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton;
            this.btnCancel_frmTraSach.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground;
            this.btnCancel_frmTraSach.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnCancel_frmTraSach.Location = new System.Drawing.Point(156, 24);
            this.btnCancel_frmTraSach.Name = "btnCancel_frmTraSach";
            this.btnCancel_frmTraSach.Size = new System.Drawing.Size(111, 45);
            this.btnCancel_frmTraSach.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.btnCancel_frmTraSach.TabIndex = 44;
            this.btnCancel_frmTraSach.Text = "Hủy";
            this.btnCancel_frmTraSach.TextColor = System.Drawing.Color.Black;
            this.btnCancel_frmTraSach.Click += new System.EventHandler(this.btnCancel_frmTraSach_Click);
            // 
            // txtTenDG_frmTraSach
            // 
            this.txtTenDG_frmTraSach.BackColor = System.Drawing.Color.White;
            // 
            // 
            // 
            this.txtTenDG_frmTraSach.Border.Class = "TextBoxBorder";
            this.txtTenDG_frmTraSach.Border.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.txtTenDG_frmTraSach.DisabledBackColor = System.Drawing.Color.White;
            this.txtTenDG_frmTraSach.ForeColor = System.Drawing.Color.Black;
            this.txtTenDG_frmTraSach.Location = new System.Drawing.Point(912, 68);
            this.txtTenDG_frmTraSach.Name = "txtTenDG_frmTraSach";
            this.txtTenDG_frmTraSach.PreventEnterBeep = true;
            this.txtTenDG_frmTraSach.ReadOnly = true;
            this.txtTenDG_frmTraSach.Size = new System.Drawing.Size(305, 20);
            this.txtTenDG_frmTraSach.TabIndex = 69;
            // 
            // lbTenDG_frmMuon
            // 
            this.lbTenDG_frmMuon.AutoSize = true;
            // 
            // 
            // 
            this.lbTenDG_frmMuon.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.lbTenDG_frmMuon.Location = new System.Drawing.Point(862, 73);
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
            this.lbMaDG_frmMuon.Location = new System.Drawing.Point(862, 36);
            this.lbMaDG_frmMuon.Name = "lbMaDG_frmMuon";
            this.lbMaDG_frmMuon.Size = new System.Drawing.Size(40, 15);
            this.lbMaDG_frmMuon.TabIndex = 67;
            this.lbMaDG_frmMuon.Text = "Mã ĐG:";
            // 
            // txtMaDG_frmTraSach
            // 
            this.txtMaDG_frmTraSach.BackColor = System.Drawing.Color.White;
            // 
            // 
            // 
            this.txtMaDG_frmTraSach.Border.Class = "TextBoxBorder";
            this.txtMaDG_frmTraSach.Border.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.txtMaDG_frmTraSach.DisabledBackColor = System.Drawing.Color.White;
            this.txtMaDG_frmTraSach.ForeColor = System.Drawing.Color.Black;
            this.txtMaDG_frmTraSach.Location = new System.Drawing.Point(912, 31);
            this.txtMaDG_frmTraSach.Name = "txtMaDG_frmTraSach";
            this.txtMaDG_frmTraSach.PreventEnterBeep = true;
            this.txtMaDG_frmTraSach.ReadOnly = true;
            this.txtMaDG_frmTraSach.Size = new System.Drawing.Size(305, 20);
            this.txtMaDG_frmTraSach.TabIndex = 70;
            // 
            // frmTraSach
            // 
            this.BackColor = System.Drawing.SystemColors.GradientInactiveCaption;
            this.ClientSize = new System.Drawing.Size(1230, 616);
            this.Controls.Add(this.txtMaDG_frmTraSach);
            this.Controls.Add(this.txtTenDG_frmTraSach);
            this.Controls.Add(this.lbTenDG_frmMuon);
            this.Controls.Add(this.lbMaDG_frmMuon);
            this.Controls.Add(this.dgvSach);
            this.Controls.Add(this.btnOK_frmTraSach);
            this.Controls.Add(this.btnCancel_frmTraSach);
            this.DoubleBuffered = true;
            this.Name = "frmTraSach";
            this.Text = "Quản Lý Thư Viện - Form Mượn Sách";
            ((System.ComponentModel.ISupportInitialize)(this.dgvSach)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private DevComponents.DotNetBar.ButtonX btnCancel_frmTraSach;
        private DevComponents.DotNetBar.ButtonX btnOK_frmTraSach;
        private System.Windows.Forms.DataGridView dgvSach;
        private System.Windows.Forms.ToolStripButton fillByToolStripButton;
        private DevComponents.DotNetBar.Controls.TextBoxX txtTenDG_frmTraSach;
        private DevComponents.DotNetBar.LabelX lbTenDG_frmMuon;
        private DevComponents.DotNetBar.LabelX lbMaDG_frmMuon;
        private DevComponents.DotNetBar.Controls.TextBoxX txtMaDG_frmTraSach;
    }
}