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
    public partial class frmChiTietPhieuMuon : DevComponents.DotNetBar.OfficeForm
    {
        private List<SachDTO> ListSach = new List<SachDTO>();
        private List<string> ListMaSach;
        private TheDocGiaBUS theDGBus;
        private string strNgayMuon;
        private string strTenDG;
        private string strMaDG;

        private SachBUS sachBus;
        public frmChiTietPhieuMuon(PhieuMuonDTO phieuMuon)
        {
            InitializeComponent();
            sachBus = new SachBUS();
            theDGBus = new TheDocGiaBUS();

            GetInfo_From(phieuMuon);
            GetTenDG_From_MaDG();
            AddSach_Into_ListSach();
            SetTenDG_NgayMuon();

            LoadDataGirdView_ChiTietPM();


        }

        public frmChiTietPhieuMuon()
        {
            InitializeComponent();
        }

        #region Xử Lí Dữ Liệu Trên GUI
        public void GetInfo_From(PhieuMuonDTO phieuMuon)
        {
            strMaDG = phieuMuon.Madg;
            strNgayMuon = phieuMuon.Ngaymuon.ToShortDateString();

            //Tách từng mã sách ra thành 1 list mã sách
            ListMaSach = InputChecking.Instance.SeparateWords(phieuMuon.Masach.ToString());
        }

        public void AddSach_Into_ListSach()
        {
            //SachDTO sach = new SachDTO();
            List<SachDTO> listSach = new List<SachDTO>();

            foreach(string strMaSach in ListMaSach)
            {
                listSach = sachBus.SelectByKeyWord(strMaSach);
                ListSach.Add(listSach[0]);
            }
        }

        private void SetTenDG_NgayMuon()
        {
            lbHoTen.Text += strTenDG;
            lbNgayMuon.Text += strNgayMuon;
        }

        public void GetTenDG_From_MaDG()
        {
            try
            {
                DataTable dtTheDG = new DataTable();
                dtTheDG = theDGBus.SelectByKeyWord(strMaDG);

                DataRow row = dtTheDG.Rows[0];
                strTenDG = string.Empty;
                strTenDG = row[2].ToString();
            }

            catch
            {
                MessageBox.Show("ĐÃ CÓ LỖI XẢY RA, VUI LÒNG KIỂM TRA LẠI DỮ LIỆU", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

        }

        #endregion

        #region Trình Bày Giao Diện
        private void Create_DataGV_CTPhieuMuon()
        {
            
            DataGridViewTextBoxColumn MaSach = new DataGridViewTextBoxColumn();
            MaSach.Name = "MaSach";
            MaSach.HeaderText = "Mã Sách";
            MaSach.DataPropertyName = "masach";
            MaSach.Width = (dgvChiTietPhieuMuon.Width / 6) / 2 + 30;
            dgvChiTietPhieuMuon.Columns.Add(MaSach);


            DataGridViewTextBoxColumn TenSach = new DataGridViewTextBoxColumn();
            TenSach.Name = "TenSach";
            TenSach.HeaderText = "Tên Sách";
            TenSach.DataPropertyName = "tensach";
            TenSach.Width = ((dgvChiTietPhieuMuon.Width - 2 * (MaSach.Width)) / 3 + (dgvChiTietPhieuMuon.Width - 3 * (MaSach.Width)) / 6);
            dgvChiTietPhieuMuon.Columns.Add(TenSach);


            DataGridViewTextBoxColumn TheLoai = new DataGridViewTextBoxColumn();
            TheLoai.Name = "TheLoai";
            TheLoai.HeaderText = "Thể Loại";
            TheLoai.DataPropertyName = "theloai";
            TheLoai.Width = (((dgvChiTietPhieuMuon.Width - (3 * (MaSach.Width))) - TenSach.Width)) / 2 + 15;
            dgvChiTietPhieuMuon.Columns.Add(TheLoai);


            DataGridViewTextBoxColumn TacGia = new DataGridViewTextBoxColumn();
            TacGia.Name = "TacGia";
            TacGia.HeaderText = "Tác Giả";
            TacGia.DataPropertyName = "tacgia";
            TacGia.Width = TheLoai.Width  + 65;
            dgvChiTietPhieuMuon.Columns.Add(TacGia);

         
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
            SoLuong.Width = (dgvChiTietPhieuMuon.Width / 6) / 2 ;
            dgvChiTietPhieuMuon.Columns.Add(SoLuong);

        }

        #endregion


        #region Load Dữ Liệu Lên GUI
        private void LoadDataGirdView_ChiTietPM()
        {
            
            if (ListSach == null)
            {
                MessageBox.Show("XẢY RA LỖI KHI LẤY DỮ LIỆU! ", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            else
            {
                dgvChiTietPhieuMuon.Columns.Clear();
                dgvChiTietPhieuMuon.DataSource = null;
 
                dgvChiTietPhieuMuon.AutoGenerateColumns = false;
                dgvChiTietPhieuMuon.AllowUserToAddRows = false;
                dgvChiTietPhieuMuon.DataSource = ListSach;
                Create_DataGV_CTPhieuMuon();
                CurrencyManager myCurrencyManager = (CurrencyManager)this.BindingContext[dgvChiTietPhieuMuon.DataSource];
                myCurrencyManager.Refresh();
            }

        }

        #endregion

        private void frmChiTietPhieuMuon_Load(object sender, EventArgs e)
        {

        }
    }
}