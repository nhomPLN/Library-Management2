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
    
    public partial class Test : DevComponents.DotNetBar.OfficeForm
    {

        private string sKeyword = string.Empty;
        private SachBUS sachBus;
        private NhanVienBUS nhanVienBus;
        public Test()
        {
            InitializeComponent();

            Create_DataGV_ThemSach();


            sachBus = new SachBUS();
            nhanVienBus = new NhanVienBUS();

            LoadDataGirdView_NhapSach();

        }


        private void LoadDataGirdView_NhapSach()
        {
            SachDTO sachDTO = new SachDTO();
            List<SachDTO> ListSach;
            ListSach = sachBus.SelectByKeyWord(sKeyword);



            if (ListSach == null)
            {
                MessageBox.Show("XẢY RA LỖI KHI LẤY DỮ LIỆU! ", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            else
            {
                dgvLoadSach.Columns.Clear();
                dgvLoadSach.DataSource = null;

                dgvLoadSach.AutoGenerateColumns = false;
                dgvLoadSach.AllowUserToAddRows = false;
                dgvLoadSach.DataSource = ListSach;

                Create_DataGV_LoadSach();

                CurrencyManager myCurrencyManager = (CurrencyManager)this.BindingContext[dgvLoadSach.DataSource];
                myCurrencyManager.Refresh();
            }

        }


        


        private void DGC_TEST_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        //CREATE DATA GIRDVIEW COLUMN AND FORMAT

        private void Create_DataGV_LoadSach()
        {
            //DGV_TEST.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;


            DataGridViewTextBoxColumn MaSach = new DataGridViewTextBoxColumn();
            MaSach.Name = "MaSach";
            MaSach.HeaderText = "Mã Sách";
            MaSach.DataPropertyName = "masach";
            MaSach.Width = (dgvLoadSach.Width / 6) / 2;
            dgvLoadSach.Columns.Add(MaSach);


            DataGridViewTextBoxColumn TenSach = new DataGridViewTextBoxColumn();
            TenSach.Name = "TenSach";
            TenSach.HeaderText = "Tên Sách";
            TenSach.DataPropertyName = "tensach";
            TenSach.Width = ((dgvLoadSach.Width - 3 * (MaSach.Width)) / 3 + (dgvLoadSach.Width - 3 * (MaSach.Width)) / 6);
            dgvLoadSach.Columns.Add(TenSach);


            DataGridViewTextBoxColumn TheLoai = new DataGridViewTextBoxColumn();
            TheLoai.Name = "TheLoai";
            TheLoai.HeaderText = "Thể Loại";
            TheLoai.DataPropertyName = "theloai";
            TheLoai.Width = (((dgvLoadSach.Width - (3 * (MaSach.Width))) - TenSach.Width)) / 2;
            dgvLoadSach.Columns.Add(TheLoai);


            DataGridViewTextBoxColumn TacGia = new DataGridViewTextBoxColumn();
            TacGia.Name = "TacGia";
            TacGia.HeaderText = "Tác Giả";
            TacGia.DataPropertyName = "tacgia";
            TacGia.Width = TheLoai.Width - 42;
            dgvLoadSach.Columns.Add(TacGia);

            DataGridViewCheckBoxColumn dgvCheckBox = new DataGridViewCheckBoxColumn();
            dgvCheckBox.Name = "Select";
            dgvCheckBox.HeaderText = "Select";

            dgvCheckBox.Width = (dgvLoadSach.Width / 6) / 2;
            dgvLoadSach.Columns.Add(dgvCheckBox);


            DevComponents.DotNetBar.Controls.DataGridViewIntegerInputColumn SoLuong;
            SoLuong = new DevComponents.DotNetBar.Controls.DataGridViewIntegerInputColumn();
            SoLuong.BackgroundStyle.Class = "DataGridViewNumericBorder";
            SoLuong.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            SoLuong.BackgroundStyle.TextColor = System.Drawing.Color.Black;
            SoLuong.HeaderText = "Số Lượng";
            SoLuong.InputHorizontalAlignment = DevComponents.Editors.eHorizontalAlignment.Left;
            SoLuong.MinValue = 1;
            SoLuong.Name = "SoLuong";
            SoLuong.ShowUpDown = true;
            SoLuong.Width = (dgvLoadSach.Width / 6) / 2;
            dgvLoadSach.Columns.Add(SoLuong);
        }

        private void Create_DataGV_ThemSach()
        {
            dgvThemSach_frmMuon.AutoGenerateColumns = false;
            dgvThemSach_frmMuon.AllowUserToAddRows = false;


            DataGridViewTextBoxColumn MaSach = new DataGridViewTextBoxColumn();
            MaSach.Name = "MaSach";
            MaSach.HeaderText = "Mã Sách";
            MaSach.DataPropertyName = "masach";
            MaSach.Width = (dgvThemSach_frmMuon.Width / 4) / 3;
            dgvThemSach_frmMuon.Columns.Add(MaSach);


            DataGridViewTextBoxColumn TenSach = new DataGridViewTextBoxColumn();
            TenSach.Name = "TenSach";
            TenSach.HeaderText = "Tên Sách";
            TenSach.DataPropertyName = "tensach";
            TenSach.Width = ((dgvThemSach_frmMuon.Width - 3 * (MaSach.Width)) - 4);
            dgvThemSach_frmMuon.Columns.Add(TenSach);

            DevComponents.DotNetBar.Controls.DataGridViewIntegerInputColumn SoLuong;
            SoLuong = new DevComponents.DotNetBar.Controls.DataGridViewIntegerInputColumn();
            SoLuong.BackgroundStyle.Class = "DataGridViewNumericBorder";
            SoLuong.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            SoLuong.BackgroundStyle.TextColor = System.Drawing.Color.Black;
            SoLuong.HeaderText = "Số Lượng";
            SoLuong.InputHorizontalAlignment = DevComponents.Editors.eHorizontalAlignment.Left;
            SoLuong.MinValue = 1;
            SoLuong.Name = "SoLuong";
            SoLuong.ShowUpDown = true;
            SoLuong.Width = (dgvThemSach_frmMuon.Width / 4) / 3;
            dgvThemSach_frmMuon.Columns.Add(SoLuong);

        }

        private void ThemSachFrom_DgvLoadSach_Into_DgvThemSach()
        {


            for (int i = 0; i <= dgvLoadSach.Rows.Count - 1; i++)
            {

                bool rowAlreadyExist = false;
                //DataGridViewCheckBoxCell chk = (DataGridViewCheckBoxCell)row.Cells[0];
                if (dgvLoadSach.Rows[i].Cells[4].Value == null)
                    dgvLoadSach.Rows[i].Cells[4].Value = false;

                bool checkedCell = (bool)dgvLoadSach.Rows[i].Cells[4].Value;
                if (checkedCell == true)
                {
                    DataGridViewRow row = dgvLoadSach.Rows[i];

                    if (dgvThemSach_frmMuon.Rows.Count != 0)
                    {
                        for (int j = 0; j <= dgvThemSach_frmMuon.Rows.Count - 1; j++)
                        {
                            if (row.Cells[0].Value.ToString() == dgvThemSach_frmMuon.Rows[j].Cells[0].Value.ToString())
                            {
                                rowAlreadyExist = true;
                                break;
                            }
                        }


                        if (rowAlreadyExist == false)
                        {
                            if (row.Cells[5].Value == null)
                                row.Cells[5].Value = 1;

                            dgvThemSach_frmMuon.Rows.Add(row.Cells[0].Value.ToString(),
                                                       row.Cells[1].Value.ToString(),
                                                       row.Cells[5].Value.ToString()
                                                       );
                        }
                    }

                    else
                    {
                        if (row.Cells[5].Value == null)
                            row.Cells[5].Value = 1;

                        dgvThemSach_frmMuon.Rows.Add(row.Cells[0].Value.ToString(),
                                                       row.Cells[1].Value.ToString(),
                                                       row.Cells[5].Value.ToString()
                                                       );
                    }
                }
            }
        }

        private void buttonX1_Click(object sender, EventArgs e)
        {
            ThemSachFrom_DgvLoadSach_Into_DgvThemSach();
        }

        private void TimKiemSach_TheoKeyWord()
        {
            List<SachDTO> ListSach = sachBus.SelectByKeyWord(sKeyword);
            sKeyword = txtSearch_frmMuon.Text.Trim();
            if (sKeyword == null || sKeyword == string.Empty || sKeyword.Length == 0)
            {
                this.LoadDataGirdView_NhapSach();
            }
            else
            {
                this.LoadDataGirdView_NhapSach();

            }

            

        }

        private void txtSearch_frmMuon_TextChanged(object sender, EventArgs e)
        {
            TimKiemSach_TheoKeyWord();
        }
    }
}
