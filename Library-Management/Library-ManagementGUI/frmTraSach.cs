using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using BUS;
using DevComponents.DotNetBar;
using DTO;

namespace Library_ManagementGUI
{
    public partial class frmTraSach : DevComponents.DotNetBar.OfficeForm
    {
        PhieuMuonDTO SelectedReceipt;
        PhieuMuonBUS phieumuonBUS;
        SachBUS sachBUS;
        private TheDocGiaBUS theDGBus;
        PhieuTraBUS phieutraBUS;
        List<string> SelectedBookIDs;

        public frmTraSach()
        {
            InitializeComponent();

            sachBUS = new SachBUS();
            theDGBus = new TheDocGiaBUS();
            phieumuonBUS = new PhieuMuonBUS();
            phieutraBUS = new PhieuTraBUS();
        }

        public frmTraSach(PhieuMuonDTO selectedreceipt)
        {
            InitializeComponent();

            sachBUS = new SachBUS();
            theDGBus = new TheDocGiaBUS();
            phieumuonBUS = new PhieuMuonBUS();
            phieutraBUS = new PhieuTraBUS();
            SelectedReceipt = selectedreceipt;
            SelectedBookIDs = new List<string>();
        }

        protected override void OnLoad(EventArgs e)
        {
            LoadFormTraSach();
        }

        void FormartDataGridView(List<SachDTO> ListBooks)
        {
            dgvSach.Columns.Clear();
            dgvSach.DataSource = null;

            dgvSach.AutoGenerateColumns = false;
            dgvSach.AllowUserToAddRows = false;
            dgvSach.DataSource = ListBooks;

            DataGridViewTextBoxColumn MaSach = new DataGridViewTextBoxColumn();
            MaSach.Name = "MaSach";
            MaSach.HeaderText = "Mã Sách";
            MaSach.DataPropertyName = "MaSach";
            MaSach.Width = dgvSach.Width / 16;
            dgvSach.Columns.Add(MaSach);

            DataGridViewTextBoxColumn TenSach = new DataGridViewTextBoxColumn();
            TenSach.Name = "TenSach";
            TenSach.HeaderText = "Tên Sách";
            TenSach.DataPropertyName = "TenSach";
            TenSach.Width = (7 * dgvSach.Width) / 25;
            dgvSach.Columns.Add(TenSach);

            DataGridViewTextBoxColumn TheLoai = new DataGridViewTextBoxColumn();
            TheLoai.Name = "TheLoai";
            TheLoai.HeaderText = "Thể Loại";
            TheLoai.DataPropertyName = "TheLoai";
            TheLoai.Width = (7 * dgvSach.Width) / 25;
            dgvSach.Columns.Add(TheLoai);

            DataGridViewTextBoxColumn TacGia = new DataGridViewTextBoxColumn();
            TacGia.Name = "TacGia";
            TacGia.HeaderText = "Tác Giả";
            TacGia.DataPropertyName = "TacGia";
            TacGia.Width = (7 * dgvSach.Width) / 25;
            dgvSach.Columns.Add(TacGia);

            DataGridViewCheckBoxColumn dgvCheckBox = new DataGridViewCheckBoxColumn();
            dgvCheckBox.Name = "CheckBoxes";
            dgvCheckBox.HeaderText = "Select";
            dgvCheckBox.Width = dgvSach.Width / 16;
            dgvSach.Columns.Add(dgvCheckBox);
        }

        void DisplayReceiptBooks(List<SachDTO> ListBooks)
        {
            FormartDataGridView(ListBooks);

            CurrencyManager myCurrencyManager = (CurrencyManager)this.BindingContext[dgvSach.DataSource];
            myCurrencyManager.Refresh();
        }

        void LoadFormTraSach()
        {
            txtMaDG_frmTraSach.Text = SelectedReceipt.Madg;
            //txtTenDG_frmTraSach.Text = SelectedReceipt.Hoten;
            DisplayReceiptBooks(phieumuonBUS.GetSelectedReceiptBooks(SelectedReceipt.Mapm));
        }

        private void btnOK_frmTraSach_Click(object sender, EventArgs e)
        {
            if (SelectedBookIDs.Count > 0)
            {
                phieutraBUS.ReturnItems(SelectedBookIDs, SelectedReceipt.Mapm, SelectedReceipt.Madg, SelectedReceipt.Ngaymuon, SelectedReceipt.Mucphat);

                this.Close();
            }
            else
            {
                MessageBox.Show("Chọn sách cần trả !");
            }
        }

        private void btnCancel_frmTraSach_Click(object sender, EventArgs e)
        {
            DialogResult result = MessageBox.Show("Bạn có muốn thoát không ?", "", MessageBoxButtons.YesNo);

            if (result == DialogResult.Yes)
            {
                this.Close();
            }
        }

        private void dgvSach_CurrentCellDirtyStateChanged(object sender, EventArgs e)
        {
            if (dgvSach.IsCurrentCellDirty)
            {
                dgvSach.CommitEdit(DataGridViewDataErrorContexts.Commit);
            }
        }

        private void dgvSach_CellValueChanged(object sender, DataGridViewCellEventArgs e)
        {
            if (e.ColumnIndex == 4)
            {
                if (!(Boolean)dgvSach.Rows[e.RowIndex].Cells[4].Value)
                {
                    SelectedBookIDs.Remove(dgvSach.Rows[e.RowIndex].Cells[0].Value.ToString());
                }
                else
                {
                    SelectedBookIDs.Add(dgvSach.Rows[e.RowIndex].Cells[0].Value.ToString());
                }
            }
        }
    }
}