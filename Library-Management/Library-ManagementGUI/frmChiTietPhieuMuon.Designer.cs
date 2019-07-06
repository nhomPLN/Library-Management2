namespace Library_ManagementGUI
{
    partial class frmChiTietPhieuMuon
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
            this.lbPhieuMuon = new DevComponents.DotNetBar.LabelX();
            this.dgvChiTietPhieuMuon = new DevComponents.DotNetBar.Controls.DataGridViewX();
            this.lbHoTen = new DevComponents.DotNetBar.LabelX();
            this.lbNgayMuon = new DevComponents.DotNetBar.LabelX();
            ((System.ComponentModel.ISupportInitialize)(this.dgvChiTietPhieuMuon)).BeginInit();
            this.SuspendLayout();
            // 
            // lbPhieuMuon
            // 
            // 
            // 
            // 
            this.lbPhieuMuon.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.lbPhieuMuon.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbPhieuMuon.Location = new System.Drawing.Point(396, 12);
            this.lbPhieuMuon.Name = "lbPhieuMuon";
            this.lbPhieuMuon.Size = new System.Drawing.Size(180, 23);
            this.lbPhieuMuon.TabIndex = 0;
            this.lbPhieuMuon.Text = "Chi Tiết Phiếu Mượn";
            // 
            // dgvChiTietPhieuMuon
            // 
            this.dgvChiTietPhieuMuon.BackgroundColor = System.Drawing.SystemColors.ControlLightLight;
            this.dgvChiTietPhieuMuon.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle1.ForeColor = System.Drawing.Color.Black;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.Color.Black;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dgvChiTietPhieuMuon.DefaultCellStyle = dataGridViewCellStyle1;
            this.dgvChiTietPhieuMuon.EditMode = System.Windows.Forms.DataGridViewEditMode.EditProgrammatically;
            this.dgvChiTietPhieuMuon.GridColor = System.Drawing.Color.FromArgb(((int)(((byte)(208)))), ((int)(((byte)(215)))), ((int)(((byte)(229)))));
            this.dgvChiTietPhieuMuon.Location = new System.Drawing.Point(12, 91);
            this.dgvChiTietPhieuMuon.Name = "dgvChiTietPhieuMuon";
            this.dgvChiTietPhieuMuon.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvChiTietPhieuMuon.Size = new System.Drawing.Size(982, 370);
            this.dgvChiTietPhieuMuon.TabIndex = 1;
            // 
            // lbHoTen
            // 
            // 
            // 
            // 
            this.lbHoTen.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.lbHoTen.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbHoTen.Location = new System.Drawing.Point(86, 51);
            this.lbHoTen.Name = "lbHoTen";
            this.lbHoTen.Size = new System.Drawing.Size(301, 23);
            this.lbHoTen.TabIndex = 2;
            this.lbHoTen.Text = "Họ  Và Tên: ";
            // 
            // lbNgayMuon
            // 
            // 
            // 
            // 
            this.lbNgayMuon.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.lbNgayMuon.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbNgayMuon.Location = new System.Drawing.Point(695, 51);
            this.lbNgayMuon.Name = "lbNgayMuon";
            this.lbNgayMuon.Size = new System.Drawing.Size(299, 23);
            this.lbNgayMuon.TabIndex = 3;
            this.lbNgayMuon.Text = "Ngày Mượn: ";
            // 
            // frmChiTietPhieuMuon
            // 
            this.BackColor = System.Drawing.SystemColors.GradientInactiveCaption;
            this.ClientSize = new System.Drawing.Size(1006, 473);
            this.Controls.Add(this.lbNgayMuon);
            this.Controls.Add(this.lbHoTen);
            this.Controls.Add(this.dgvChiTietPhieuMuon);
            this.Controls.Add(this.lbPhieuMuon);
            this.DoubleBuffered = true;
            this.Name = "frmChiTietPhieuMuon";
            this.Text = "Chi Tiết Phiếu Mượn";
            this.Load += new System.EventHandler(this.frmChiTietPhieuMuon_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgvChiTietPhieuMuon)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private DevComponents.DotNetBar.LabelX lbPhieuMuon;
        private DevComponents.DotNetBar.LabelX lbNgayMuon;
        private DevComponents.DotNetBar.Controls.DataGridViewX dgvChiTietPhieuMuon;
        private DevComponents.DotNetBar.LabelX lbHoTen;
    }
}