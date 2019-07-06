namespace Library_ManagementGUI
{
    partial class Test
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
            this.dgvLoadSach = new System.Windows.Forms.DataGridView();
            this.dgvThemSach_frmMuon = new System.Windows.Forms.DataGridView();
            this.buttonX1 = new DevComponents.DotNetBar.ButtonX();
            this.button1 = new System.Windows.Forms.Button();
            this.button2 = new System.Windows.Forms.Button();
            this.lbSearch = new System.Windows.Forms.Label();
            this.txtSearch_frmMuon = new System.Windows.Forms.TextBox();
            this.buttonX2 = new DevComponents.DotNetBar.ButtonX();
            ((System.ComponentModel.ISupportInitialize)(this.dgvLoadSach)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvThemSach_frmMuon)).BeginInit();
            this.SuspendLayout();
            // 
            // dgvLoadSach
            // 
            this.dgvLoadSach.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvLoadSach.Location = new System.Drawing.Point(12, 72);
            this.dgvLoadSach.Name = "dgvLoadSach";
            this.dgvLoadSach.Size = new System.Drawing.Size(797, 394);
            this.dgvLoadSach.TabIndex = 0;
            this.dgvLoadSach.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.DGC_TEST_CellContentClick);
            // 
            // dgvThemSach_frmMuon
            // 
            this.dgvThemSach_frmMuon.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvThemSach_frmMuon.Location = new System.Drawing.Point(874, 72);
            this.dgvThemSach_frmMuon.Name = "dgvThemSach_frmMuon";
            this.dgvThemSach_frmMuon.Size = new System.Drawing.Size(484, 394);
            this.dgvThemSach_frmMuon.TabIndex = 1;
            // 
            // buttonX1
            // 
            this.buttonX1.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton;
            this.buttonX1.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground;
            this.buttonX1.Location = new System.Drawing.Point(815, 221);
            this.buttonX1.Name = "buttonX1";
            this.buttonX1.Size = new System.Drawing.Size(50, 23);
            this.buttonX1.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.buttonX1.TabIndex = 2;
            this.buttonX1.Text = ">>>";
            this.buttonX1.Click += new System.EventHandler(this.buttonX1_Click);
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(13, 22);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(75, 23);
            this.button1.TabIndex = 4;
            this.button1.Text = "OK";
            this.button1.UseVisualStyleBackColor = true;
            // 
            // button2
            // 
            this.button2.Location = new System.Drawing.Point(113, 22);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(75, 23);
            this.button2.TabIndex = 5;
            this.button2.Text = "Cancel";
            this.button2.UseVisualStyleBackColor = true;
            // 
            // lbSearch
            // 
            this.lbSearch.AutoSize = true;
            this.lbSearch.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbSearch.Location = new System.Drawing.Point(241, 25);
            this.lbSearch.Name = "lbSearch";
            this.lbSearch.Size = new System.Drawing.Size(66, 20);
            this.lbSearch.TabIndex = 59;
            this.lbSearch.Text = "Search";
            // 
            // txtSearch_frmMuon
            // 
            this.txtSearch_frmMuon.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend;
            this.txtSearch_frmMuon.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.RecentlyUsedList;
            this.txtSearch_frmMuon.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtSearch_frmMuon.Location = new System.Drawing.Point(313, 23);
            this.txtSearch_frmMuon.Name = "txtSearch_frmMuon";
            this.txtSearch_frmMuon.Size = new System.Drawing.Size(496, 26);
            this.txtSearch_frmMuon.TabIndex = 58;
            this.txtSearch_frmMuon.TextChanged += new System.EventHandler(this.txtSearch_frmMuon_TextChanged);
            // 
            // buttonX2
            // 
            this.buttonX2.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton;
            this.buttonX2.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground;
            this.buttonX2.Location = new System.Drawing.Point(815, 250);
            this.buttonX2.Name = "buttonX2";
            this.buttonX2.Size = new System.Drawing.Size(50, 23);
            this.buttonX2.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.buttonX2.TabIndex = 60;
            this.buttonX2.Text = "<<<";
            // 
            // Test
            // 
            this.ClientSize = new System.Drawing.Size(1370, 572);
            this.Controls.Add(this.buttonX2);
            this.Controls.Add(this.lbSearch);
            this.Controls.Add(this.txtSearch_frmMuon);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.buttonX1);
            this.Controls.Add(this.dgvThemSach_frmMuon);
            this.Controls.Add(this.dgvLoadSach);
            this.DoubleBuffered = true;
            this.Name = "Test";
            this.Text = "Test";
            ((System.ComponentModel.ISupportInitialize)(this.dgvLoadSach)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvThemSach_frmMuon)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataGridView dgvLoadSach;
        private System.Windows.Forms.DataGridView dgvThemSach_frmMuon;
        private DevComponents.DotNetBar.ButtonX buttonX1;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.Label lbSearch;
        private System.Windows.Forms.TextBox txtSearch_frmMuon;
        private DevComponents.DotNetBar.ButtonX buttonX2;
    }
}