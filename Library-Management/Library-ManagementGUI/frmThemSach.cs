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
    public partial class frmThemSach : DevComponents.DotNetBar.OfficeForm
    {

        private string strMaDG;
        private string sKeyword = string.Empty;
        private string mapm;

        private PhieuMuonBUS phieuMuonBus;
        private SachBUS sachBus;
        private TheDocGiaBUS theDGBus;
        private QuyDinhPhieuMuonBUS QdPhieuMuonBus;
        private QuyDinhPhieuTraBUS QdPhieuTraBus;

        private List<string> ListMaSach = new List<string>();
        private List<string> ListMaDG = new List<string>();
        private List<string> ListTenDG = new List<string>();
        private List<int> ListSLSachMuon = new List<int>();
        private List<SachDTO> ListSach = new List<SachDTO>();
        private QuyDinhPhieuMuonDTO QD;
        private QuyDinhPhieuTraDTO QdinhPtra;
        QuyDinhPhieuMuonDTO Qd;
        private static int intSoLuongSachDuocMuon;
        private int intTongSoSachDangChon = 0;
        private int flag;
        private int MucPhat;
       
        AutoCompleteStringCollection MaDG_Source = new AutoCompleteStringCollection();

        private  Form1 frm1;

        public frmThemSach(Form1 form1)
        {

            InitializeComponent();
            this.frm1 = form1;
            

            Create_DataGV_ThemSach();

            sachBus = new SachBUS();
            theDGBus = new TheDocGiaBUS();
            phieuMuonBus = new PhieuMuonBUS();
            QdPhieuMuonBus = new QuyDinhPhieuMuonBUS();
            QD = new QuyDinhPhieuMuonDTO();
            QdinhPtra = new QuyDinhPhieuTraDTO();
            QdPhieuTraBus = new QuyDinhPhieuTraBUS();

            LoadDataGirdView_NhapSach();
            LoadMaDG_Into_CmbxMaDG();

            GetQuyDinh_PhieuMuon();

            flag = 1;
        }

        public frmThemSach(Form1 form1, PhieuMuonDTO phieuMuon_CellClick)
        {
            InitializeComponent();
            this.frm1 = form1;


            sachBus = new SachBUS();
            theDGBus = new TheDocGiaBUS();
            phieuMuonBus = new PhieuMuonBUS();
            QdPhieuMuonBus = new QuyDinhPhieuMuonBUS();

            Create_DataGV_ThemSach();
            LoadMaDG_Into_CmbxMaDG();
            txtTenDG_frmMuon.Text = ListTenDG[ListMaDG.IndexOf(phieuMuon_CellClick.Madg.ToString())];
            cmbxMaDG_frmMuon.Text = phieuMuon_CellClick.Madg;
            mapm = phieuMuon_CellClick.Mapm;

            GetQuyDinh_PhieuMuon();
            
            ListMaSach = new List<string>();
            ListMaSach = InputChecking.Instance.SeparateWords(phieuMuon_CellClick.Masach.ToString());
            //Tim Kiem Ten DG Dua Vao MaDG
            ListSLSachMuon.Clear();
            for(int index = 0; index < ListMaSach.Count; index++)
            {
                ListSLSachMuon.Add(1);
            }

            intTongSoSachDangChon = ListMaSach.Count;

         
            AddSach_Into_ListSach();
            ThemSach_Into_DgvThemSach_FromList();
            this.LoadDataGirdView_NhapSach();
            ThemSachFrom_DgvLoadSach_Into_DgvThemSach();
            CheckIfRowIsChecked_In_Dgv_LoadSach();

            flag = 2;
        }


        #region Xử Lí sự kiện
        //Xử Lí CÁC SỰ KIỆN TRONG FORM THÊM SÁCH
        private void buttonX3_Click(object sender, EventArgs e)
        {
            ThemSachFrom_DgvLoadSach_Into_DgvThemSach();
            
        }


        private void btnXoaSach_Click(object sender, EventArgs e)
        {
            XoaSach_From_DgvThemSach();
        }

        private void txtSearch_frmMuon_TextChanged_1(object sender, EventArgs e)
        {
            TimKiemSach_TheoKeyWord();
        }

        private void btnOK_Click(object sender, EventArgs e)
        {
            if (InputChecking.Instance.IsNullOrEmpty(txtTenDG_frmMuon))
            {
                MessageBox.Show("VUI LÒNG KIỂM TRA LẠI DỮ LIỆU", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else if (dgvThemSach_frmMuon.Rows.Count == 0)
            {
                MessageBox.Show("HÃY CHỌN ÍT NHẤT 1 CUỐN SÁCH! ", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else
            {
                if (flag == 1)
                {
                    //THEM PHIEU MUON
                    ThemPhieuMuon_GUI();

                    frm1.LoadDSPhieuMuon_Into_DGV_QLMuon(frm1.ListPhieuMuon);
                    this.Close();

                }
                else
                {
                    //SUA PHIEU MUON
                    SuaPhieuMuon_GUI();
                    frm1.LoadDSPhieuMuon_Into_DGV_QLMuon(frm1.ListPhieuMuon);
                    this.Close();

                }
                
            }

        }
        //btn CANCEL
        private void btnCancel_Click(object sender, EventArgs e)
        {
            DialogResult result_ = MessageBox.Show("BẠN CHẮC CHẮN MUỐN ĐÓNG CỬA SỔ NÀY ?", "Warning!", MessageBoxButtons.OKCancel, MessageBoxIcon.Warning);
            if (result_ == DialogResult.OK)
            {
                this.Close();
            }
            else
            {
                //roll back
            }

        }

        //Preview TenDG
        private void cmbxMaDG_frmMuon_PreviewKeyDown(object sender, PreviewKeyDownEventArgs e)
        {
            strMaDG = cmbxMaDG_frmMuon.Text;
            txtTenDG_frmMuon.ReadOnly = true;
            if (MaDG_Source.Contains(strMaDG))
            {
                int index = MaDG_Source.IndexOf(strMaDG);
                txtTenDG_frmMuon.Text = ListTenDG[index].ToString();
            }
            if (cmbxMaDG_frmMuon.Text == "")
                txtTenDG_frmMuon.Text = "";

        }

        //Load MaDG into Combobox 

        private void cmbxMaDG_frmMuon_SelectedIndexChanged(object sender, EventArgs e)
        {
            LoadMaDG_Into_CmbxMaDG();
        }

        #endregion
        #region Load dữ liệu
        //LOAD DU LIEU VÀO DATAGRIDVIEW
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
               // dgvLoadSach.Sort(dgvLoadSach.Columns[0], ListSortDirection.Ascending);

                CurrencyManager myCurrencyManager = (CurrencyManager)this.BindingContext[dgvLoadSach.DataSource];
                myCurrencyManager.Refresh();
            }

        }

        #endregion

        #region Format Giao Diện
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
            SoLuong.Enabled = false;
            SoLuong.Width = (dgvLoadSach.Width / 6) / 2;
            dgvLoadSach.Columns.Add(SoLuong);

          
            for(int index = 0;index < dgvLoadSach.ColumnCount; index++)
            {
                dgvLoadSach.Columns[index].Resizable = DataGridViewTriState.False;
            }

            dgvLoadSach.AutoSizeRowsMode = DataGridViewAutoSizeRowsMode.None;
            dgvLoadSach.AllowUserToResizeRows = false;
            dgvLoadSach.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.None;
            dgvLoadSach.AllowUserToResizeColumns = false;

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
            TenSach.Width = ((dgvThemSach_frmMuon.Width - 3 * (MaSach.Width)) - 25);
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
            SoLuong.Width = (dgvThemSach_frmMuon.Width / 4) / 2;
            SoLuong.Enabled = false;
            dgvThemSach_frmMuon.Columns.Add(SoLuong);

            dgvThemSach_frmMuon.Sort(dgvThemSach_frmMuon.Columns[0], ListSortDirection.Ascending);

        }

        #endregion

        #region Xử Lí Tác Vụ
        //XỬ LÝ CÁC TÁC VỤ TRONG FORM THÊM SÁCH
        private void ThemSachFrom_DgvLoadSach_Into_DgvThemSach()
        {
            string strMa = string.Empty;
            int soLuongSach = 0;

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
                                row.Cells[4].Value = true;
                                break;


                            }
                        }

                        if (rowAlreadyExist == false)
                        {
                            if (row.Cells[5].Value == null)
                                row.Cells[5].Value = 1;

                            //Add ma Sach vao ListMaSach
                            strMa = row.Cells[0].Value.ToString();
                            soLuongSach = Int32.Parse(row.Cells[5].Value.ToString());

                            if (AddMaSach_SoLuong_ToList(strMa, soLuongSach))
                            {
                                dgvThemSach_frmMuon.Rows.Add(row.Cells[0].Value.ToString(),
                                                        row.Cells[1].Value.ToString(),
                                                        row.Cells[5].Value.ToString());
                            }
                        }
                    }

                    else
                    {
                        if (row.Cells[5].Value == null)
                            row.Cells[5].Value = 1;

                        //Add ma Sach vao ListMaSach
                        strMa = row.Cells[0].Value.ToString();
                        soLuongSach = Int32.Parse(row.Cells[5].Value.ToString());

                        if (AddMaSach_SoLuong_ToList(strMa, soLuongSach))
                        {
                            dgvThemSach_frmMuon.Rows.Add(row.Cells[0].Value.ToString(),
                                                    row.Cells[1].Value.ToString(),
                                                    row.Cells[5].Value.ToString());
                        }

                    }
                }
            }
        }

        private void ThemSach_Into_DgvThemSach_FromList()
        {
            foreach(SachDTO sach in ListSach)
            {
                dgvThemSach_frmMuon.Rows.Add(sach.Masach, sach.Tensach, 1);
                
            }
           
          
        }

        private void XoaSach_From_DgvThemSach()
        {
            List<string> rowId = new List<string>();
            foreach (DataGridViewRow row in dgvThemSach_frmMuon.SelectedRows)
            {
                dgvThemSach_frmMuon.Rows.Remove(row);
                string id = row.Cells[0].Value.ToString();
                rowId.Add(id);

            }

            foreach (DataGridViewRow row in dgvLoadSach.Rows)
            {
                foreach (string ID in rowId)
                {
                    if ((string)dgvLoadSach.Rows[row.Index].Cells[0].Value == ID)
                    {
                        dgvLoadSach.Rows[row.Index].Cells[4].Value = false;
                        dgvLoadSach.Rows[row.Index].Cells[5].Value = 1;
                    }

                    //(row.Cells[4] as DataGridViewCheckBoxCell).Value = false;
                }
            }

            try
            {
                foreach (string strMa in ListMaSach)
                {
                    foreach (string ID in rowId)
                    {
                        if (strMa == ID)
                        {
                            //Cap nhat gia tri so luong sach dang muon
                            
                            int temp = ListSLSachMuon[(ListMaSach.IndexOf(strMa))];
                            intTongSoSachDangChon -= temp;

                            int temp1 = (ListMaSach.IndexOf(strMa));

                            ListMaSach.RemoveAt(temp1);
                            ListSLSachMuon.RemoveAt(temp1);

                        }
                    }
                }
            }
            catch
            {

            }
            
        }

        private void TimKiemSach_TheoKeyWord()
        {
            List<SachDTO> ListSach = sachBus.SelectByKeyWord(sKeyword);
            sKeyword = txtSearch_frmMuon.Text.Trim();
            if (sKeyword == null || sKeyword == string.Empty || sKeyword.Length == 0)
            {
                this.LoadDataGirdView_NhapSach();
                CheckIfRowAlreadyExist();
            }
            else
            {
                this.LoadDataGirdView_NhapSach();
                CheckIfRowAlreadyExist();

            }

        }

        public void AddSach_Into_ListSach()
        {
            //SachDTO sach = new SachDTO();
            List<SachDTO> listSach = new List<SachDTO>();

            foreach (string strMaSach in ListMaSach)
            {
                listSach = sachBus.SelectByKeyWord(strMaSach);
                ListSach.Add(listSach[0]);
            }
        }

        private void CheckIfRowAlreadyExist()
        {
            List<string> rowId = new List<string>();
            List<int> rowSoLuong = new List<int>();
            foreach (DataGridViewRow row in dgvThemSach_frmMuon.Rows)
            {
                string id = row.Cells[0].Value.ToString();
                int SoLuong = Int32.Parse(row.Cells[2].Value.ToString());
                rowId.Add(id);
                rowSoLuong.Add(SoLuong);

            }

            foreach (DataGridViewRow row in dgvLoadSach.Rows)
            {
                foreach (string ID in rowId)
                {
                    if ((string)dgvLoadSach.Rows[row.Index].Cells[0].Value == ID)
                    {
                        

                        dgvLoadSach.Rows[row.Index].Cells[4].Value = true;
                        dgvLoadSach.Rows[row.Index].Cells[5].Value = rowSoLuong[rowId.IndexOf(ID)];
                    }

                    //(row.Cells[4] as DataGridViewCheckBoxCell).Value = false;
                }
            }
        }


        private void CheckIfRowIsChecked_In_Dgv_LoadSach()
        {
            List<string> rowId = new List<string>();
            foreach (DataGridViewRow row in dgvThemSach_frmMuon.Rows)
            {
                
                string id = row.Cells[0].Value.ToString();
                rowId.Add(id);

            }

            foreach (DataGridViewRow row in dgvLoadSach.Rows)
            {
                string ID = ((string) dgvLoadSach.Rows[row.Index].Cells[0].Value.ToString());
                if (dgvLoadSach.Rows[row.Index].Cells[4].Value == null)
                    dgvLoadSach.Rows[row.Index].Cells[4].Value = false;

                foreach (string strID in rowId)
                {
                    if (strID == ID)
                    {
                        dgvLoadSach.Rows[row.Index].Cells[4].Value = true;
                        //(row.Cells[4] as DataGridViewCheckBoxCell).Value = true;

                        //đây là số lượng cuốn sách đang được chọn
                        dgvLoadSach.Rows[row.Index].Cells[5].Value = 1;
                    }

                    //(row.Cells[4] as DataGridViewCheckBoxCell).Value = false;
                }
            }
        }

        //ThemSach_VaoDGV_ThemSach
        private bool AddMaSach_SoLuong_ToList(string strValue, int soLuong)
        {
            int temp = soLuong;
            //temp là số lượng sách đang được chọn tạm thời trên form

            if (intTongSoSachDangChon < intSoLuongSachDuocMuon && (temp+ intTongSoSachDangChon) <= intSoLuongSachDuocMuon)
            {
                bool alreadyExist = ListMaSach.Contains(strValue);
                if (!alreadyExist)
                {
                    ListMaSach.Add(strValue);
                    ListSLSachMuon.Add(soLuong);

                    intTongSoSachDangChon += ListSLSachMuon[ListSLSachMuon.Count - 1];
                    
                }
                return true;

            }
            else
            {
                MessageBox.Show("CHỈ ĐƯỢC MƯỢN TỐI ĐA " + intSoLuongSachDuocMuon.ToString() + " CUỐN SÁCH", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
              
                return false;
            }
        }


        private void LoadMaDG_Into_CmbxMaDG()
        {

            DataTable dtTheDG = new DataTable();
            dtTheDG = theDGBus.GetBangDocGia();

            foreach (DataRow row in dtTheDG.Rows)
            {
                string ID = row[1].ToString();
                string Ten = row[3].ToString();

                MaDG_Source.Add(ID);
                ListMaDG.Add(ID);
                ListTenDG.Add(Ten);
            }


            cmbxMaDG_frmMuon.AutoCompleteCustomSource = MaDG_Source;
            cmbxMaDG_frmMuon.AutoCompleteMode = AutoCompleteMode.SuggestAppend;
            cmbxMaDG_frmMuon.AutoCompleteSource = AutoCompleteSource.CustomSource;

        }

        private void GetPhieuMuon_Data_From_GUI(PhieuMuonDTO phieuMuonDTO)
        {
            phieuMuonDTO.Madg = cmbxMaDG_frmMuon.Text.ToString();
            phieuMuonDTO.Soluong = intTongSoSachDangChon;
            phieuMuonDTO.Ngaymuon = DateTime.Now;
            phieuMuonDTO.Hantra = phieuMuonDTO.CalDueDate(Qd);
            phieuMuonDTO.Masach = string.Empty;
            phieuMuonDTO.Mapm = mapm;
            phieuMuonDTO.Mucphat = MucPhat;
           
            foreach(string Ma in ListMaSach)
            {
                phieuMuonDTO.Masach += (Ma+" ");
            }
        }

        private void ThemPhieuMuon_GUI()
        {
            PhieuMuonDTO phieuMuonDTO = new PhieuMuonDTO();
            SachDTO sachDTO = new SachDTO();
            TheDocGiaDTO theDG = new TheDocGiaDTO();

            GetPhieuMuon_Data_From_GUI(phieuMuonDTO);
            theDG.Madg = phieuMuonDTO.Madg;

            int flag = 0;
            foreach (string ma in ListMaSach)
            {
                sachDTO.Masach = ma;
                bool updateSach = sachBus.UpdateData(sachDTO);
                if (updateSach)
                    flag = 1;
            }
            
            bool result = phieuMuonBus.ThemPhieuMuon(phieuMuonDTO);
            bool resultDG = theDGBus.UpdateSoSachMuon(theDG, intTongSoSachDangChon);

            if (result && resultDG && flag ==1)
            {
                //SACH SOLUONG VA LUOT MUON
                MessageBox.Show("ĐÃ LẬP PHIẾU MƯỢN THÀNH CÔNG!", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                this.Close();

            }
            else
            {
                MessageBox.Show("ĐÃ CÓ LỖI XẢY RA, VUI LÒNG KIỂM TRA LẠI", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

            
        }

        private void SuaPhieuMuon_GUI()
        {
            PhieuMuonDTO phieuMuonDTO = new PhieuMuonDTO();
            SachDTO sachDTO = new SachDTO();
            TheDocGiaDTO theDG = new TheDocGiaDTO();

            GetPhieuMuon_Data_From_GUI(phieuMuonDTO);
            theDG.Madg = phieuMuonDTO.Madg;

            int flag = 0;
            foreach (string ma in ListMaSach)
            {
                sachDTO.Masach = ma;
                bool updateSach = sachBus.UpdateData(sachDTO);
                if (updateSach)
                    flag = 1;
            }

            bool result = phieuMuonBus.SuaPhieuMuon(phieuMuonDTO);
            bool resultDG = theDGBus.UpdateSoSachMuon(theDG, intTongSoSachDangChon);

            if (result && resultDG && flag == 1)
            {
                //SACH SOLUONG VA LUOT MUON
                MessageBox.Show("ĐÃ CẬP NHẬT PHIẾU MƯỢN THÀNH CÔNG!", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                this.Close();

            }
            else
            {
                MessageBox.Show("ĐÃ CÓ LỖI XẢY RA, VUI LÒNG KIỂM TRA LẠI", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }


        }

        private void GetQuyDinh_PhieuMuon()
        {
            try
            {
                Qd = new QuyDinhPhieuMuonDTO();
                DataTable dtQd = new DataTable();

                dtQd = QdPhieuMuonBus.LoadBangQDPM();
                DataRow row = dtQd.Rows[dtQd.Rows.Count - 1];

                Qd.Songaymuontoida = Int32.Parse(row[2].ToString());
                Qd.Sosachtoida = Int32.Parse(row[1].ToString());
               intSoLuongSachDuocMuon = Qd.Sosachtoida;

         

                QdinhPtra = new QuyDinhPhieuTraDTO();
                DataTable dtQDPT = new DataTable();

                dtQDPT = QdPhieuTraBus.LoadBangQDPT();

                DataRow rows = dtQDPT.Rows[dtQDPT.Rows.Count - 1];
                QdinhPtra.Tienphat = Int32.Parse(row[2].ToString());

                MucPhat = QdinhPtra.Tienphat;
            }
            catch
            {
                MessageBox.Show("VUI LÒNG KIỂM TRA LẠI DỮ LIỆU Ở TAB QUY ĐỊNH", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            



        }

        #endregion



    }
}