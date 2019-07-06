using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using BUS;
using DevComponents.DotNetBar;
using DTO;
using Library_ManagementGUI.Properties;

namespace Library_ManagementGUI
{
    public partial class Form1 : Form
    {

        #region Phuc
        TheDocGiaBUS tdgBUS;
        QDLoaiDocGiaBUS ldgBUS;
        QDLoaiSachBUS lsBUS;
        QDChucVuNhanVienBUS cvnvBUS;
        ThongKeDocGiaBUS tkdgBUS;
        ThongKeSachBUS tksBUS;
        QuyDinhDocGiaBUS qddgBUS;        //SachBUS sachBUS; khong xoa
        QuyDinhSachBUS qdsBUS;
        QuyDinhNhanVienBUS qdnvBUS;
        QuyDinhPhieuMuonBUS qdpmBUS;
        QuyDinhPhieuTraBUS qdptBUS;
        #endregion

        private static int flag = 0;
        private static int flagBtnOK_NhanVien = -1;
        private string strMaNV = string.Empty;
        private string sKeyword = string.Empty;
        private NhanVienBUS nhanVienBus;
        private ChucVuNVBUS chucVuBus;
        private TaiKhoanBUS taiKhoanBus;
        private SachBUS sachBus;
        private PhieuMuonBUS phieuMuonBus;
        private TheDocGiaBUS theDGBus;
        private QuyDinhPhieuMuonBUS QdPhieuMuonBus;
        private int IDENT_CURRENT = 0;

        public List<PhieuMuonDTO> ListPhieuMuon;
        PhieuMuonDTO phieuMuonDTO_CellClick = new PhieuMuonDTO();
        QuyDinhPhieuMuonDTO Qd;
       

        public Form1()
        {
            InitializeComponent();

            #region Nghia

            sachBUS = new SachBUS();
            theloaisachBUS = new TheLoaiSachBUS();
            SelectedBooks = new List<string>();
            inputchecker = new InputChecking();

            #endregion

            #region Phuc
            // Loai
            tdgBUS = new TheDocGiaBUS();

            ldgBUS = new QDLoaiDocGiaBUS();

            lsBUS = new QDLoaiSachBUS();

            cvnvBUS = new QDChucVuNhanVienBUS();

            // Thong ke
            tkdgBUS = new ThongKeDocGiaBUS();

            tksBUS = new ThongKeSachBUS();

            // Quy Dinh
            qddgBUS = new QuyDinhDocGiaBUS();

            qdsBUS = new QuyDinhSachBUS();

            qdnvBUS = new QuyDinhNhanVienBUS();

            qdpmBUS = new QuyDinhPhieuMuonBUS();

            qdptBUS = new QuyDinhPhieuTraBUS();
            //LoadTabQLDG();
            tdgBUS.LoadTabQLDG(ref dgvDG, ref txtMaDG, ref txtHoTenDG, ref dtpNgaySinhDG, ref txtDiaChiDG, ref txtEmailDG, ref cbxLoaiDG, ref dtpNgayLapTheDG, ref dtpNgayHetHanDG, ref txtSoSachDangMuonDG, ref txtTongTienNoDG, ref txtTuoiToiThieuDG, ref txtTuoiToiDaDG, ref cbxTimKiemDG, ref txtThoiHanTheDG, ldgBUS, tdgBUS, qddgBUS);
            #endregion

            #region QLNhanVien_PhieuMuon
            nhanVienBus = new NhanVienBUS();
            chucVuBus = new ChucVuNVBUS();
            taiKhoanBus = new TaiKhoanBUS();
            sachBus = new SachBUS();
            phieuMuonBus = new PhieuMuonBUS();
            theDGBus = new TheDocGiaBUS();
            QdPhieuMuonBus = new QuyDinhPhieuMuonBUS();

            ListPhieuMuon = new List<PhieuMuonDTO>();


            LoadChucVu_Combobox();
            LoadDanhSachNhanVien_VaoDGV();
            HideButtonOK_Cancel();
            cbxTimKiem.Text = cbxTimKiem1.Text;
            LoadDSPhieuMuon_Into_DGV_QLMuon(ListPhieuMuon);
            GetQuyDinh_PhieuMuon();

            #endregion
        }


        #region TAB QUẢN LÍ NHÂN VIÊN

        #region Xử Lí Sự Kiện Tab Nhân Viên

        //BUTTON THEM
        private void btnThemNV_Click(object sender, EventArgs e)
        {
            flagBtnOK_NhanVien = 1;
            ShowButtonOK_Cancel();
            txtMaNV.Enabled = false;
            txtMaNV.ReadOnly = true;
            dgvNhanVien.Enabled = false;

            //btnOK_NhanVien.Location

            txtHoTen.Focus();
            txtMaNV.Enabled = false;
            txtMaNV.ReadOnly = false;
            txtTenDN.Text = CreatePassword(4);
            txtMatKhauNV.Text = CreatePassword(8);
            SetTextEmpty(pnThongTinNhanVien);

            try
            {
                dgvNhanVien.Rows[0].Selected = true;
                dgvNhanVien.ClearSelection();
            }
            catch
            {

            }


        }

        //BUTTON OK
        private void btnOK_NhanVien_Click(object sender, EventArgs e)
        {
            dgvNhanVien.Enabled = true;
            if (flagBtnOK_NhanVien == 1)
            {
                ThemNhanVien_GUI();
            }
            else if (flagBtnOK_NhanVien == 0)
            {
                SuaNhanVien_GUI();
            }
            else
                MessageBox.Show("VUI LÒNG KIỂM TRA LẠI DỮ LIỆU", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);

        }

        //BUTTON CANCEL
        private void btnCancel_NhanVien_Click(object sender, EventArgs e)
        {
            ////Chức năng thêm nhận viên đang được sử dụng
            //flagBtnOK_NhanVien = 1;

            HideButtonOK_Cancel();
            dgvNhanVien.Enabled = true;
            LoadDanhSachNhanVien_VaoDGV();
            //dgvNhanVien.Rows[0].Selected = true;

        }

        //BUTTON SUA

        private void btnXoaNV_Click(object sender, EventArgs e)
        {
            //dgvNhanVien.Enabled = false;
            //Tạo List string chứ MaNV
            List<string> selectedRowsID = new List<string>();

            //add MaNV của những row đang được select vào List
            foreach (DataGridViewRow row in dgvNhanVien.SelectedRows)
            {
                string id = row.Cells[0].Value.ToString();
                selectedRowsID.Add(id);
            }


            //1. Map data from GUI
            NhanVienDTO nhanVienDTO = new NhanVienDTO();
            TaiKhoanDTO taiKhoanDTO = new TaiKhoanDTO();

            if (selectedRowsID.Count == 0)
            {
                MessageBox.Show("HÃY CHỌN ÍT NHẤT MỘT HÀNG DỮ LIỆU ĐỂ XÓA!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else
            {


                DialogResult result_ = MessageBox.Show("BẠN CHẮC CHẮN MUỐN XÓA NHÂN VIÊN CHỨ ?", "Warning!", MessageBoxButtons.OKCancel, MessageBoxIcon.Warning);

                if (result_ == DialogResult.OK)
                {

                    //Thực hiện xóa NhanVien theo MaNV
                    foreach (string strID in selectedRowsID)
                    {
                        nhanVienDTO.StrMaNhanVien = strID;
                        taiKhoanDTO.IntMaNV = Int32.Parse(strID);

                        //2.Kiem tra tren tang database
                        bool accountResult = taiKhoanBus.XoaTK(taiKhoanDTO);
                        if (accountResult)
                        {
                            bool result = nhanVienBus.XoaNV(nhanVienDTO);

                            if (result)
                                flag = 1;
                        }

                        else
                        {
                            MessageBox.Show("XẢY RA LỖI KHI XÓA NHÂN VIÊN!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }
                    }

                    if (flag == 1)
                    {
                        LoadDanhSachNhanVien_VaoDGV();
                        LoadTaiKhoanNV();
                        MessageBox.Show("ĐÃ XÓA NHÂN VIÊN THÀNH CÔNG", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Information);

                    }

                }

                else
                {
                    //Roll back to NhanVien
                }
            }
        }


        private void btnSuaNV_Click(object sender, EventArgs e)
        {
            //Chức năng Sửa thông tin nhân viên đang được sử dụng

            flagBtnOK_NhanVien = 0;

            ShowButtonOK_Cancel();

            //Mã Nhân Viên Không Thể Được Sửa Đổi
            txtMaNV.ReadOnly = true;
            txtHoTen.Focus();
        }

        //BUTTON TIM KIEM
        private void btnTimKiem_Click(object sender, EventArgs e)
        {
            btnCancel_NhanVien.Show();
            btnCancel_NhanVien.Location = new Point(957, 102);

            sKeyword = txtTimKiem.Text.Trim();
            if (sKeyword == null || sKeyword == string.Empty || sKeyword.Length == 0) // tìm tất cả
            {
                List<NhanVienDTO> ListNhanVien = nhanVienBus.Select();
                this.LoadDanhSachNhanVien_VaoDGV();
                this.LoadTaiKhoanNV();
            }
            else
            {
                List<NhanVienDTO> ListNhanVien = nhanVienBus.SelectByKeyWord(sKeyword);
                if (ListNhanVien == null)
                {
                    MessageBox.Show("KHÔNG TÌM THẤY NHÂN VIÊN NÀY!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                else
                {
                    this.LoadDanhSachNhanVien_VaoDGV(ListNhanVien);
                    this.LoadTaiKhoanNV();
                }

            }
        }


        private void dgvNhanVien_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            int ind = e.RowIndex;
            try
            {
                DataGridViewRow selectedRows = dgvNhanVien.Rows[ind];

                //binding dgv to textbox
                txtMaNV.Text = selectedRows.Cells[0].Value.ToString();
                txtHoTen.Text = selectedRows.Cells[1].Value.ToString();
                dtpNgaySinh.Text = selectedRows.Cells[2].Value.ToString();
                cbxChucVu.Text = selectedRows.Cells[3].Value.ToString();
                dtpNgayVaoLam.Text = selectedRows.Cells[4].Value.ToString();
                txtEmail.Text = selectedRows.Cells[5].Value.ToString();
                txtSDT.Text = selectedRows.Cells[7].Value.ToString();
                txtDiaChi.Text = selectedRows.Cells[6].Value.ToString();
                txtLuong.Text = selectedRows.Cells[8].Value.ToString();
                txtTienPhat.Text = selectedRows.Cells[9].Value.ToString();

                strMaNV = selectedRows.Cells[0].Value.ToString();
                LoadTaiKhoanNV();
            }
            catch
            {

            }

        }

        //------------------------------------

        #endregion

        #region Xử Lí Dữ Liệu Tab Nhân Viên
        //LOAD DỮ LIỆU

        //LOAD DATA VÀO COMBOBOX
        private void LoadChucVu_Combobox()
        {
            List<ChucVuNVDTO> ListChucVu = chucVuBus.Select();

            if (ListChucVu == null)
            {
                MessageBox.Show("KHÔNG THỂ LOAD ĐƯỢC DỮ LIỆU", "Thông Báo Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            cbxChucVu.DataSource = new BindingSource(ListChucVu, String.Empty);
            cbxChucVu.DisplayMember = "StrTenLoaiChucVu";
            cbxChucVu.ValueMember = "StrMaLoaiChucVu";

            CurrencyManager myCurrencyManager = (CurrencyManager)this.BindingContext[cbxChucVu.DataSource];
            myCurrencyManager.Refresh();

            if (cbxChucVu.Items.Count > 0)
            {
                cbxChucVu.SelectedIndex = 0;
            }

        }

        //Load DanhSach NhanVien Vao DGVIEW

        private void LoadDanhSachNhanVien_VaoDGV()
        {
            List<NhanVienDTO> ListNhanVien = nhanVienBus.Select();


            if (ListNhanVien == null)
            {
                MessageBox.Show("XẢY RA LỖI KHI LẤY DỮ LIỆU! ", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            dgvNhanVien.DataSource = ListNhanVien;
            ChangeHeaderText_InDGV();


            dgvNhanVien.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;

            try
            {
                dgvNhanVien.Sort(dgvNhanVien.Columns[0], ListSortDirection.Ascending);

                //Sắp xếp các cột
                foreach (DataGridViewColumn column in dgvNhanVien.Columns)
                {
                    column.SortMode = DataGridViewColumnSortMode.Automatic;
                }


            }
            catch
            {

            }


            CurrencyManager myCurrencyManager = (CurrencyManager)this.BindingContext[dgvNhanVien.DataSource];
            myCurrencyManager.Refresh();

            BindingDGVIntoTextbox_Default();

            LoadTaiKhoanNV();

        }

        private void LoadTaiKhoanNV()
        {
            try
            {
                List<TaiKhoanDTO> ListTaiKhoan = taiKhoanBus.SelectByKeyWord(strMaNV);
                txtTenDN.Text = ListTaiKhoan[0].StrTenTk.ToString();
                txtMatKhauNV.Text = ListTaiKhoan[0].StrMatKhau.ToString();
            }
            catch
            {

            }

        }

        //Over Load Function
        private void LoadDanhSachNhanVien_VaoDGV(List<NhanVienDTO> ListNhanVien)
        {
            ListNhanVien = nhanVienBus.SelectByKeyWord(sKeyword);

            if (ListNhanVien == null)
            {
                MessageBox.Show("XẢY RA LỖI KHI LẤY DỮ LIỆU! ", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            dgvNhanVien.DataSource = ListNhanVien;

            ChangeHeaderText_InDGV();
            dgvNhanVien.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;



            //Sắp xếp các cột
            foreach (DataGridViewColumn column in dgvNhanVien.Columns)
            {
                column.SortMode = DataGridViewColumnSortMode.Automatic;
            }


            CurrencyManager myCurrencyManager = (CurrencyManager)this.BindingContext[dgvNhanVien.DataSource];
            myCurrencyManager.Refresh();

            //Hiện dữ liệu lên khi mới mở tab Nhân Viên
            BindingDGVIntoTextbox_Default();

        }

        #endregion

        #region Kiểm Tra Định Dạng Và Tính Đúng Đắn Của Dữ Liệu
        //KIỂM TRA TÍNH HỢP LỆ CỦA DỮ LIỆU
        private bool CheckingInputData()
        {
            //Định dạng lại họ tên trước khi get vào DTO
            InputChecking.Instance.TextBoxToProperCase(txtHoTen);

            //Kiểm tra tính hợp lệ của dữ liệu
            if (InputChecking.Instance.IsValidName(txtHoTen.ToString()) &&
            InputChecking.Instance.IsValidEmail(txtEmail) &&
            InputChecking.Instance.IsValidDate(dtpNgaySinh) &&
            InputChecking.Instance.IsValidDate(dtpNgayVaoLam) &&
            //InputChecking.Instance.IsNumber(txtSDT.ToString()) &&
            //InputChecking.Instance.IsNumber(txtLuong.ToString()) &&
            //InputChecking.Instance.IsNumber(txtTienPhat.ToString()) &&
            (InputChecking.Instance.IsNullOrEmpty(txtLuong) == false) &&
            (InputChecking.Instance.IsNullOrEmpty(txtTienPhat) == false) &&
            (InputChecking.Instance.IsNullOrEmpty(txtHoTen) == false) &&
            (InputChecking.Instance.IsNullOrEmpty(txtEmail) == false) &&
            (InputChecking.Instance.IsNullOrEmpty(txtSDT) == false)

            )
                return true;
            else
                return false;
        }


        //FORMAT GIAO DIỆN

        //Sửa đổi tên Cột hiển thị lên Form QLTV
        private void ChangeHeaderText_InDGV()
        {
            dgvNhanVien.Columns[0].HeaderText = "Mã Nhân Viên";
            dgvNhanVien.Columns[1].HeaderText = "Họ và Tên";
            dgvNhanVien.Columns[2].HeaderText = "Ngày Sinh";
            dgvNhanVien.Columns[3].HeaderText = "Chức Vụ";
            dgvNhanVien.Columns[4].HeaderText = "Ngày Vào Làm";
            dgvNhanVien.Columns[5].HeaderText = "Email";
            dgvNhanVien.Columns[6].HeaderText = "Địa Chỉ";
            dgvNhanVien.Columns[7].HeaderText = "Số Điện Thoại";
            dgvNhanVien.Columns[8].HeaderText = "Lương Tháng";
            dgvNhanVien.Columns[9].HeaderText = "Tiền Phạt";

        }

        //Lấy dữ liệu từ Gui vào NhaanVien DTO
        private void GetNhanVienData_FromGui(NhanVienDTO nhanVienDTO)
        {

            nhanVienDTO.StrMaNhanVien = txtMaNV.Text;
            nhanVienDTO.StrHoTen = txtHoTen.Text;
            nhanVienDTO.DtNgaySinh = dtpNgaySinh.Value;
            nhanVienDTO.StrMaChucVu = cbxChucVu.SelectedValue.ToString();
            nhanVienDTO.DtNgayVaoLam = dtpNgayVaoLam.Value;
            nhanVienDTO.StrEmail = txtEmail.Text;
            nhanVienDTO.StrSoDT = txtSDT.Text;
            nhanVienDTO.StrDiaChi = txtDiaChi.Text;
            /*CultureInfo.CreateSpecificCulture("en-US")*/
            try
            {
                nhanVienDTO.FlLuong = double.Parse(txtLuong.Text);
                nhanVienDTO.FlTienPhat = float.Parse(txtTienPhat.Text);
            }
            catch
            {

            }

        }

        //Lấy Dữ Liệu Từ GUI Vào TaiKhoanDTO
        private void GetNhanVienAccount_FromGUI_Default(TaiKhoanDTO taiKhoanDTO)
        {
            taiKhoanDTO.StrMaChucVu = cbxChucVu.SelectedValue.ToString();
            taiKhoanDTO.StrMatKhau = txtMatKhauNV.Text;
            taiKhoanDTO.StrTenTk = txtTenDN.Text;

        }

        private void GetNhanVienAccount_FromGUI_UserEdit(TaiKhoanDTO taiKhoanDTO)
        {
            taiKhoanDTO.StrMaChucVu = cbxChucVu.SelectedValue.ToString();
            taiKhoanDTO.StrMatKhau = txtMatKhauNV.Text.ToString();
            taiKhoanDTO.StrTenTk = txtTenDN.Text;
            taiKhoanDTO.IntMaNV = Int32.Parse(strMaNV);

        }

        private void BindingDGVIntoTextbox_Default()
        {
            try
            {
                DataGridViewRow selectedRows = dgvNhanVien.Rows[0];
                txtMaNV.Text = selectedRows.Cells[0].Value.ToString();
                txtHoTen.Text = selectedRows.Cells[1].Value.ToString();
                dtpNgaySinh.Text = selectedRows.Cells[2].Value.ToString();
                cbxChucVu.Text = selectedRows.Cells[3].Value.ToString();
                dtpNgayVaoLam.Text = selectedRows.Cells[4].Value.ToString();
                txtEmail.Text = selectedRows.Cells[5].Value.ToString();
                txtSDT.Text = selectedRows.Cells[7].Value.ToString();
                txtDiaChi.Text = selectedRows.Cells[6].Value.ToString();
                txtLuong.Text = selectedRows.Cells[8].Value.ToString();
                txtTienPhat.Text = selectedRows.Cells[9].Value.ToString();

                strMaNV = selectedRows.Cells[0].Value.ToString();
            }
            catch
            {

            }

        }

        #endregion

        #region Xử Lí Các Dữ Liệu Từ GUI (NhanVien Tab)
        // XỬ LÍ CÁC TÁC VỤ TRÊN GUI
        //Thêm Nhân Viên Mới
        private void ThemNhanVien_GUI()
        {
            NhanVienDTO nhanVienDTO = new NhanVienDTO();
            TaiKhoanDTO taiKhoanDTO = new TaiKhoanDTO();

            //1. Check data from GUI
            if (CheckingInputData())
            {
                //2. Map data from GUI
                GetNhanVienData_FromGui(nhanVienDTO);
                GetNhanVienAccount_FromGUI_Default(taiKhoanDTO);

                //3. Thêm vào DB
                bool result = nhanVienBus.ThemNV(nhanVienDTO);
                if (result)
                {
                    //Lay Gia Tri cua MaNV
                    taiKhoanDTO.IntMaNV = nhanVienBus.Select_IDENT_CURRENT(IDENT_CURRENT);


                    bool taiKhoanResult = taiKhoanBus.ThemTK(taiKhoanDTO);
                    if (taiKhoanResult)
                    {
                        LoadDanhSachNhanVien_VaoDGV();
                        MessageBox.Show("ĐÃ THÊM NHÂN VIÊN MỚI", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Information);

                        HideButtonOK_Cancel();
                    }

                    else
                    {
                        nhanVienBus.XoaNV(nhanVienDTO);
                        MessageBox.Show("THÊM NHÂN VIÊN KHÔNG THÀNH CÔNG!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }


                }

                else
                    MessageBox.Show("THÊM NHÂN VIÊN KHÔNG THÀNH CÔNG!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

            else
                MessageBox.Show("VUI LÒNG KIỂM TRA LẠI DỮ LIỆU", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }

        private void SuaNhanVien_GUI()
        {
            NhanVienDTO nhanVienDTO = new NhanVienDTO();
            TaiKhoanDTO taiKhoanDTO = new TaiKhoanDTO();

            //1. Check data from GUI
            if (CheckingInputData())
            {
                //2. Map data from GUI
                GetNhanVienData_FromGui(nhanVienDTO);
                GetNhanVienAccount_FromGUI_UserEdit(taiKhoanDTO);

                //3. Thêm vào DB
                bool result = nhanVienBus.SuaNV(nhanVienDTO);
                bool re = taiKhoanBus.SuaTK(taiKhoanDTO);
                if ((result) && re)
                {
                    LoadDanhSachNhanVien_VaoDGV();
                    MessageBox.Show("ĐÃ CẬP NHẬT THÔNG TIN NHÂN VIÊN", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Information);

                    HideButtonOK_Cancel();
                }

                else
                    MessageBox.Show("CẬP NHẬT THÔNG TIN KHÔNG THÀNH CÔNG", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

            else
                MessageBox.Show("VUI LÒNG KIỂM TRA LẠI DỮ LIỆU", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }

        #endregion

        #region Control Các Thành Phần của Tab Nhân VIên

        private void ShowButtonOK_Cancel()
        {

            btnTimKiem.Hide();
            txtTimKiem.Hide();
            cbxTimKiem.Hide();
            btnXoaNV.Enabled = false;
            btnSuaNV.Enabled = false;
            btnThemNV.Enabled = false;
            btnSuaNV.Hide();
            btnXoaNV.Hide();
            btnThemNV.Hide();


            this.btnCancel_NhanVien.Location = new System.Drawing.Point(btnXoaNV.Location.X + 100, btnXoaNV.Location.Y + 20);
            this.btnOK_NhanVien.Location = new System.Drawing.Point(btnThemNV.Location.X + 100, btnThemNV.Location.Y + 20);

            this.btnOK_NhanVien.Show();
            this.btnCancel_NhanVien.Show();
        }

        private void HideButtonOK_Cancel()
        {
            btnTimKiem.Enabled = true;
            btnXoaNV.Enabled = true;
            btnSuaNV.Enabled = true;
            btnThemNV.Enabled = true;
            btnThemNV.Show();
            btnTimKiem.Show();
            btnXoaNV.Show();
            btnSuaNV.Show();

            txtTimKiem.Show();
            cbxTimKiem.Show();

            BindingDGVIntoTextbox_Default();
            btnCancel_NhanVien.Hide();
            btnOK_NhanVien.Hide();

        }



        private void SetTextEmpty(Control control)
        {

            foreach (var ctrl in control.Controls)
            {
                if (ctrl is TextBox)
                    ((TextBox)ctrl).Text = String.Empty;
            }
        }

        public string CreatePassword(int length)
        {
            const string valid = "abcdefghijklmnopqrstuvwxyzABCDEFGHIJKLMNOPQRSTUVWXYZ1234567890";
            StringBuilder res = new StringBuilder();
            Random rnd = new Random();
            while (0 < length--)
            {
                res.Append(valid[rnd.Next(valid.Length)]);
            }
            return res.ToString();
        }

        #endregion

        #endregion

        #region TAB QUẢN LÍ PHIẾU MƯỢN


        #region Xử Lí Sự Kiện Tab Mượn Sách
        private void btnLapPM_frmMuon_Click(object sender, EventArgs e)
        {
            frmThemSach frmMuon = new frmThemSach(this);
            frmMuon.StartPosition = FormStartPosition.CenterParent;
            
            frmMuon.ShowDialog();

            LoadDSPhieuMuon_Into_DGV_QLMuon(ListPhieuMuon);

        }

        private void btnXoa_QLMuon_Click(object sender, EventArgs e)
        {
            XoaPhieuMuon_GUI();
        }

        private void btnSua_QLMuon_Click(object sender, EventArgs e)
        {
            frmThemSach frmMuon = new frmThemSach(this, phieuMuonDTO_CellClick);
            frmMuon.StartPosition = FormStartPosition.CenterParent;
            frmMuon.ShowDialog();
            LoadDSPhieuMuon_Into_DGV_QLMuon(ListPhieuMuon);
        }

        private void btnTimKiem_QLMuon_Click(object sender, EventArgs e)
        {


            sKeyword = txtTimKiem_QLMuon.Text.Trim();
            if (sKeyword == null || sKeyword == string.Empty || sKeyword.Length == 0) // tìm tất cả
            {
                List<PhieuMuonDTO> ListPhieuMuon = phieuMuonBus.Select();
                this.LoadDSPhieuMuon_Into_DGV_QLMuon(ListPhieuMuon);
            }
            else
            {
                List<PhieuMuonDTO> ListPhieuMuon = phieuMuonBus.SelectByKeyWord(sKeyword);
                if (ListPhieuMuon == null)
                {
                    MessageBox.Show("KHÔNG TÌM THẤY PHIẾU MƯỢN!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                else
                {
                    this.LoadDSPhieuMuon_Into_DGV_QLMuon(ListPhieuMuon);

                }

            }
        }

        #endregion

        #region Load Dữ Liệu Tab QL Mượn

        public void LoadDSPhieuMuon_Into_DGV_QLMuon(List<PhieuMuonDTO> ListPhieuMuon)
        {
            ListPhieuMuon = phieuMuonBus.Select();


            if (ListPhieuMuon == null)
            {
                MessageBox.Show("XẢY RA LỖI KHI LẤY DỮ LIỆU! ", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            dgvQLMuon.Columns.Clear();
            dgvQLMuon.DataSource = null;

            dgvQLMuon.AutoGenerateColumns = false;
            dgvQLMuon.AllowUserToAddRows = false;

            Create_DGV_QLMuon();

            dgvQLMuon.DataSource = ListPhieuMuon;
           // dgvQLMuon.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            CurrencyManager myCurrencyManager = (CurrencyManager)this.BindingContext[dgvQLMuon.DataSource];
            myCurrencyManager.Refresh();
            BindingDGVIntoTextbox_Default();

        }


        #endregion

        #region ĐỊnh Dạng Giao Diện

        private void Create_DGV_QLMuon()
        {
            dgvQLMuon.AutoGenerateColumns = false;
            dgvQLMuon.AllowUserToAddRows = false;


            DataGridViewTextBoxColumn MaPM = new DataGridViewTextBoxColumn();
            MaPM.Name = "MaPM";
            MaPM.HeaderText = "Mã Phiếu Mượn";
            MaPM.DataPropertyName = "mapm";
            // MaPM.Width = (dgvThemSach_frmMuon.Width / 4) / 3;
            dgvQLMuon.Columns.Add(MaPM);


            DataGridViewTextBoxColumn MaDG = new DataGridViewTextBoxColumn();
            MaDG.Name = "MaDG";
            MaDG.HeaderText = "Mã Độc Giả";
            MaDG.DataPropertyName = "madg";
            //MaDG.Width = ((dgvThemSach_frmMuon.Width - 3 * (MaSach.Width)) - 25);
            dgvQLMuon.Columns.Add(MaDG);

            DataGridViewTextBoxColumn NgayMuon = new DataGridViewTextBoxColumn();
            NgayMuon.Name = "NgayMuon";
            NgayMuon.HeaderText = "Ngày Mượn Sách";
            NgayMuon.DataPropertyName = "ngaymuon";
            //MaDG.Width = ((dgvThemSach_frmMuon.Width - 3 * (MaSach.Width)) - 25);
            dgvQLMuon.Columns.Add(NgayMuon);

            DataGridViewTextBoxColumn HanTra = new DataGridViewTextBoxColumn();
            HanTra.Name = "HanTra";
            HanTra.HeaderText = "Hạn Trả Sách";
            HanTra.DataPropertyName = "hantra";
            //MaDG.Width = ((dgvThemSach_frmMuon.Width - 3 * (MaSach.Width)) - 25);
            dgvQLMuon.Columns.Add(HanTra);

            DataGridViewTextBoxColumn Soluong = new DataGridViewTextBoxColumn();
            Soluong.Name = "Soluong";
            Soluong.HeaderText = "Số Sách Đang Mượn";
            Soluong.DataPropertyName = "soluong";
            //MaDG.Width = ((dgvThemSach_frmMuon.Width - 3 * (MaSach.Width)) - 25);
            dgvQLMuon.Columns.Add(Soluong);

            DevComponents.DotNetBar.Controls.DataGridViewButtonXColumn ChiTiet = new DevComponents.DotNetBar.Controls.DataGridViewButtonXColumn();
            Bitmap image = new Bitmap(Properties.Resources.plus64);
            ChiTiet.DisabledImage = image;
            ChiTiet.HeaderText = "Chi Tiết";
            ChiTiet.HoverImage = Properties.Resources.plus64;
            ChiTiet.Image = Properties.Resources.Add;
            ChiTiet.Name = "ChiTiet";
            ChiTiet.PressedImage = image;
            ChiTiet.Shape = new DevComponents.DotNetBar.RoundRectangleShapeDescriptor(10, 10, 10, 9);
            ChiTiet.Style = DevComponents.DotNetBar.eDotNetBarStyle.Office2007;
            ChiTiet.Text = null;
            ChiTiet.ToolTipText = "Chi Tiết";
            ChiTiet.Width = 20;
            
            ChiTiet.Click += ChiTiet_Click;

            dgvQLMuon.Columns.Add(ChiTiet);
            dgvQLMuon.Columns["ChiTiet"].DefaultCellStyle.BackColor = Color.FloralWhite ;
            
        }


        #endregion

        #endregion


        


        #region Xử Lí Sự Kiện Binding

        private void ChiTiet_Click(object sender, EventArgs e)
        {
            frmChiTietPhieuMuon frmChiTiet = new frmChiTietPhieuMuon(phieuMuonDTO_CellClick);
            frmChiTiet.StartPosition = FormStartPosition.CenterParent;
            frmChiTiet.ShowDialog();
        }

        private void dgvQLMuon_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            int ind = e.RowIndex;
            try
            {
                DataGridViewRow selectedRows = dgvQLMuon.Rows[ind];

                //binding dgv to textbox
                txtMaPhieuMuon_QLMuon.Text = selectedRows.Cells[0].Value.ToString();
                txtMaDG_QLMuon.Text = selectedRows.Cells[1].Value.ToString();
                dtpNgayMuon_QLMuon.Value = (DateTime)(selectedRows.Cells[2].Value);
                dtpHanTra.Value = (DateTime)(selectedRows.Cells[3].Value);
                txtSoLuong_QLMuon.Text = selectedRows.Cells[4].Value.ToString();

                //Get data into phieuMuon_CellClick_DTO
               
                phieuMuonDTO_CellClick.Mapm = selectedRows.Cells[0].Value.ToString();
                phieuMuonDTO_CellClick.Madg = selectedRows.Cells[1].Value.ToString();
                phieuMuonDTO_CellClick.Ngaymuon = (DateTime)(selectedRows.Cells[2].Value);
                phieuMuonDTO_CellClick.Hantra = (DateTime)(selectedRows.Cells[3].Value);
                phieuMuonDTO_CellClick.Soluong = Int32.Parse(selectedRows.Cells[4].Value.ToString());

                ListPhieuMuon = phieuMuonBus.Select();
                phieuMuonDTO_CellClick.Masach = ListPhieuMuon[ind].Masach.ToString();
            }
            catch
            {

            }
        }

        #region Xử Lí Các Tác Vụ Trên GUI

        private void XoaPhieuMuon_GUI()
        {

            //Tạo List string chứ MaNV
            List<string> selectedRowsID = new List<string>();
            ListPhieuMuon = phieuMuonBus.Select();
            List<string> listMaSach = new List<string>();
            List<string> listMaDG = new List<string>();
            //add MaPhieuMuon của những row đang được select vào List
            foreach (DataGridViewRow row in dgvQLMuon.SelectedRows)
            {
                string id = row.Cells[0].Value.ToString();
                string maDG = row.Cells[1].Value.ToString();

                //Lấy mã sách của row đang được chọn
                string strMaSach = ListPhieuMuon[row.Index].Masach.ToString();
                selectedRowsID.Add(id);
                listMaSach.Add(strMaSach);
                listMaDG.Add(maDG);
            }


            //1. Map data from GUI
            //Ờ đây khi xóa pm -> xóa số sách đang mượn và cập nhật lại số lượng sách
            PhieuMuonDTO phieuMuonDTO = new PhieuMuonDTO();
            SachDTO sachDTO = new SachDTO();
            TheDocGiaDTO theDocGiaDTO = new TheDocGiaDTO();


            if (selectedRowsID.Count == 0)
            {
                MessageBox.Show("HÃY CHỌN ÍT NHẤT MỘT HÀNG DỮ LIỆU ĐỂ XÓA!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else
            {


                DialogResult result_ = MessageBox.Show("BẠN CHẮC CHẮN MUỐN XÓA PHIẾU MƯỢN NÀY CHỨ ?", "Warning!", MessageBoxButtons.OKCancel, MessageBoxIcon.Warning);

                if (result_ == DialogResult.OK)
                {
                    List<string> List_Masach = new List<string>();
                    //List ma sach này để chứa các mã sách được phân tách từ listMaSach
                    //vd listMaSach có 5 phần từ str[0] str[1] str[2] str[3] str[4]
                    //mỗi str[0] str[1] str[2] str[3] str[4] lại chứ các substring con gồm nhiều từ tách nhau bởi dấu trắng
                    //vd str[0] chứa sub[0] [sub1] [sub 2] .... 
                    //Qua mỗi vòng lặp List_MaSach sẽ chứa các substring của dãy trên và truy vấn vè sql để cập nhật dữ liệu

                    int flag = 0;

                    foreach (string strID in selectedRowsID)
                    {
                        phieuMuonDTO.Mapm = strID;
                        theDocGiaDTO.Madg = listMaDG[selectedRowsID.IndexOf(strID)];

                        //Trình tự xóa :: Xóa phiếu mượn -> Cập Nhật Sách -> Cập Nhật ĐG
                        //Nếu xóa pm không thành công thì sẽ không xóa những thứ còn lại

                        bool Result = phieuMuonBus.XoaPhieuMuon(phieuMuonDTO);

                        if (Result) // Nếu xóa Thành Công -> Cập Nhật Sách
                        {
                            //index  là chỉ số của strID đang có
                            int index = selectedRowsID.IndexOf(strID);
                            List_Masach = InputChecking.Instance.SeparateWords(listMaSach[index]);

                            foreach (string strMa in List_Masach)
                            {
                                //Cập nhật dữ liệu sách
                                sachDTO.Masach = strMa;
                                if (sachBus.UpdateData_XoaPM(sachDTO))
                                {
                                    flag = 1;
                                }
                            }

                            //Xác Định xem Update thành công hay không
                            flag *= 1;

                            //Update Thẻ Độc Giả
                            //List_MaSach.Count là số lượng sách mà mỗi Dg đang mượn
                            //Kiem tra tren tang database
                            bool resultTheDG = theDGBus.UpdateSoSachMuon_XoaPM(theDocGiaDTO, List_Masach.Count);
                            if (resultTheDG && flag == 1)
                            {
                                flag = 1;
                            }
                        }

                        else
                        {
                            MessageBox.Show("XẢY RA LỖI KHI XÓA NHÂN VIÊN!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }
                    }

                    if (flag == 1)
                    {
                        LoadDSPhieuMuon_Into_DGV_QLMuon(ListPhieuMuon);
                        MessageBox.Show("ĐÃ XÓA PHIẾU MƯỢN THÀNH CÔNG", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Information);

                    }

                }

                else
                {
                    //Roll back to Phieu Muon
                }
            }
        }


        private void GetQuyDinh_PhieuMuon()
        {
            Qd = new QuyDinhPhieuMuonDTO();
            DataTable dtQd = new DataTable();

            dtQd = QdPhieuMuonBus.LoadBangQDPM();
            try
            {
                DataRow row = dtQd.Rows[dtQd.Rows.Count - 1];

                Qd.Songaymuontoida = Int32.Parse(row[2].ToString());
                Qd.Sosachtoida = Int32.Parse(row[1].ToString());

                txtSachMuonToiDa.Text =
                txtHanMuon_QLMuon.Text = Qd.Songaymuontoida.ToString();
            }
            catch
            {
                txtSachMuonToiDa.Text = "4";
                txtHanMuon_QLMuon.Text = "4";
            }

        }

        #endregion

        #region Phuc
        private void Form1_Load(object sender, EventArgs e)
        {
            
            tdgBUS.LoadTabQLDG(ref dgvDG, ref txtMaDG, ref txtHoTen, ref dtpNgaySinh, ref txtDiaChi, ref txtEmail, ref cbxLoaiDG, ref dtpNgayLapTheDG, ref dtpNgayHetHanDG, ref txtSoSachDangMuonDG, ref txtTongTienNoDG, ref txtTuoiToiThieuDG, ref txtTuoiToiDaDG, ref cbxTimKiemDG, ref txtThoiHanTheDG, ldgBUS, tdgBUS, qddgBUS);

            #endregion

            LoadChucVu_Combobox();
            LoadDanhSachNhanVien_VaoDGV();
            LoadDSPhieuMuon_Into_DGV_QLMuon(ListPhieuMuon);

        }

        #endregion

       

        #region Phuc _ QUẢN LÍ ĐỘC GIẢ - BÁO CÁO THỐNG KÊ - QUY ĐỊNH
        // ========== Tab Doc Gia ==========
        private void TabDG_Click(object sender, EventArgs e)
        {
            tdgBUS.LoadTabQLDG(ref dgvDG, ref txtMaDG, ref txtHoTenDG, ref dtpNgaySinhDG, ref txtDiaChiDG, ref txtEmailDG, ref cbxLoaiDG, ref dtpNgayLapTheDG, ref dtpNgayHetHanDG, ref txtSoSachDangMuonDG, ref txtTongTienNoDG, ref txtTuoiToiThieuDG, ref txtTuoiToiDaDG, ref cbxTimKiemDG, ref txtThoiHanTheDG, ldgBUS, tdgBUS, qddgBUS);
        }

        private void btnThemDG_Click(object sender, EventArgs e)
        {
            #region
            //TheDocGiaDTO tdgDTO = new TheDocGiaDTO();
            //LoaiDocGiaDTO ldgDTO = new LoaiDocGiaDTO();

            //tdgBUS.MapDataDGFromGUI(ref tdgDTO, txtMaDG, txtHoTen, dtpNgaySinh, txtDiaChi, txtEmail);
            //ldgBUS.MapDataLDGFromGUIDG(ref ldgDTO, cbxLoaiDG);
            ////this.MapDataDGFromGUI(tdgDTO);
            ////this.MapDataLDGFromGUIDG(ldgDTO);
            ////if (IsDataPanelDGInValid(tdgDTO, ldgDTO))
            ////    MessageBox.Show("Kiểm tra lại dữ liệu", "", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
            //List<string> listQuyDinh = new List<string>() { txtTuoiToiThieuDG.Text, txtTuoiToiDaDG.Text, txtThoiHanTheDG.Text };

            //if (tdgBUS.IsTrungKhopKhoaChinh(tdgDTO.Madg, dgvDG))
            //    return;


            //if (tdgBUS.CheckDataPanelDGInValid(tdgDTO, ldgDTO) == false)
            //    return;

            //if (tdgBUS.CheckQuyDinhDG(tdgDTO, listQuyDinh) == false)
            //    return;


            //if (tdgBUS.Them(tdgDTO, ldgDTO, int.Parse(txtThoiHanTheDG.Text), listQuyDinh))
            //{
            //    MessageBox.Show("Thêm thành công");
            //    tdgBUS.LoadTabQLDG(ref dgvDG, ref txtMaDG, ref txtHoTen, ref dtpNgaySinh, ref txtDiaChi, ref txtEmail, ref cbxLoaiDG, ref dtpNgayLapTheDG, ref dtpNgayHetHanDG, ref txtSoSachDangMuonDG, ref txtTongTienNoDG, ref txtTuoiToiThieuDG, ref txtTuoiToiDaDG, ref cbxTimKiemDG, ref txtThoiHanTheDG, ldgBUS, tdgBUS, qddgBUS);
            //}
            //else
            //{
            //    MessageBox.Show("Thêm không thành công", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            //}
            #endregion

            TheDocGiaGUI.Instance.Them(ref dgvDG, ref txtMaDG, ref txtHoTenDG, ref dtpNgaySinhDG, ref txtDiaChiDG, ref txtEmailDG, ref cbxLoaiDG, ref dtpNgayLapTheDG, ref dtpNgayHetHanDG, ref txtSoSachDangMuonDG, ref txtTongTienNoDG, ref txtTuoiToiThieuDG, ref txtTuoiToiDaDG, ref cbxTimKiemDG, ref txtThoiHanTheDG, ldgBUS, tdgBUS, qddgBUS);
        }

        private void btnXoaDG_Click(object sender, EventArgs e)
        {
            #region
            //if (dgvDG.RowCount != 0)
            //{
            //    TheDocGiaDTO tdgDTO = new TheDocGiaDTO();
            //    foreach (DataGridViewRow row in dgvDG.SelectedRows)
            //    {
            //        tdgDTO.Madg = row.Cells["MADG"].Value.ToString();
            //        tdgBUS.Xoa(tdgDTO);
            //    }
            //    dgvDG.DataSource = tdgBUS.GetBangDocGia();
            //    tdgBUS.LoadDgvDG(ref dgvDG, tdgBUS);
            //    if (dgvDG.RowCount != 0)
            //        tdgBUS.GetDataWhenClickDGVDG(dgvDG.Rows[0], ref txtMaDG, ref txtHoTen, ref dtpNgaySinh, ref txtDiaChi, ref txtEmail, ref cbxLoaiDG, ref dtpNgayLapTheDG, ref dtpNgayHetHanDG, ref txtSoSachDangMuonDG, ref txtTongTienNoDG);
            //}
            ////Sau khi delete
            //if (dgvDG.RowCount == 0)
            //{
            //    tdgBUS.ResetSTT();
            //    tdgBUS.ClearPanelDG(tdgBUS, ref txtMaDG, ref txtHoTen, ref dtpNgaySinh, ref txtDiaChi, ref txtEmail, ref cbxLoaiDG, ref dtpNgayLapTheDG, ref dtpNgayHetHanDG, ref txtSoSachDangMuonDG, ref txtTongTienNoDG, ref cbxTimKiemDG);
            //}
            #endregion
            TheDocGiaGUI.Instance.Xoa(ref dgvDG, ref txtMaDG, ref txtHoTenDG, ref dtpNgaySinhDG, ref txtDiaChiDG, ref txtEmailDG, ref cbxLoaiDG, ref dtpNgayLapTheDG, ref dtpNgayHetHanDG, ref txtSoSachDangMuonDG, ref txtTongTienNoDG, ref cbxTimKiemDG, tdgBUS);
        }

        private void btnSuaDG_Click(object sender, EventArgs e)
        {
            #region
            //TheDocGiaDTO tdgDTO = new TheDocGiaDTO();
            //LoaiDocGiaDTO ldgDTO = new LoaiDocGiaDTO();

            //tdgBUS.MapDataDGFromGUI(ref tdgDTO, txtMaDG, txtHoTen, dtpNgaySinh, txtDiaChi, txtEmail);
            //ldgBUS.MapDataLDGFromGUIDG(ref ldgDTO, cbxLoaiDG);
            ////MapDataDGFromGUI(tdgDTO);
            ////MapDataLDGFromGUIDG(ldgDTO);
            //if (tdgBUS.Sua(tdgDTO, ldgDTO) == true)
            //{
            //    MessageBox.Show("Cập nhật thành công");
            //    tdgBUS.LoadTabQLDG(ref dgvDG, ref txtMaDG, ref txtHoTen, ref dtpNgaySinh, ref txtDiaChi, ref txtEmail, ref cbxLoaiDG, ref dtpNgayLapTheDG, ref dtpNgayHetHanDG, ref txtSoSachDangMuonDG, ref txtTongTienNoDG, ref txtTuoiToiThieuDG, ref txtTuoiToiDaDG, ref cbxTimKiemDG, ref txtThoiHanTheDG, ldgBUS, tdgBUS, qddgBUS);
            //}
            //else
            //{
            //    MessageBox.Show("Cập nhật không thành công", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            //}
            #endregion

            TheDocGiaGUI.Instance.Sua(ref dgvDG, ref txtMaDG, ref txtHoTenDG, ref dtpNgaySinhDG, ref txtDiaChiDG, ref txtEmailDG, ref cbxLoaiDG, ref dtpNgayLapTheDG, ref dtpNgayHetHanDG, ref txtSoSachDangMuonDG, ref txtTongTienNoDG, ref txtTuoiToiThieuDG, ref txtTuoiToiDaDG, ref cbxTimKiemDG, ref txtThoiHanTheDG, ldgBUS, tdgBUS, qddgBUS);

        }

        private void btnClearDG_Click(object sender, EventArgs e)
        {
            tdgBUS.ClearPanelDG(tdgBUS, ref txtMaDG, ref txtHoTenDG, ref dtpNgaySinhDG, ref txtDiaChiDG, ref txtEmailDG, ref cbxLoaiDG, ref dtpNgayLapTheDG, ref dtpNgayHetHanDG, ref txtSoSachDangMuonDG, ref txtTongTienNoDG, ref cbxTimKiemDG);
        }

        private void btnTimKiemDG_Click(object sender, EventArgs e)
        {
            dgvDG.DataSource = tdgBUS.TimKiem(dgvDG, txtTimKiemDG.Text, cbxTimKiemDG.Text);

        }
        

        private void dgvDG_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                tdgBUS.GetDataWhenClickDGVDG(dgvDG.SelectedCells[0].OwningRow, ref txtMaDG, ref txtHoTenDG, 
                    ref dtpNgaySinhDG, ref txtDiaChiDG, ref txtEmailDG, ref cbxLoaiDG, ref dtpNgayLapTheDG, ref dtpNgayHetHanDG, ref txtSoSachDangMuonDG, ref txtTongTienNoDG);
            }
            catch { }
           
         

        }


        // ========== Tab Bao Cao Thong Ke ==========
        private void cbxTKDG_SelectedIndexChanged(object sender, EventArgs e)
        {
            ComboBox cbx = sender as ComboBox;
            if (cbx.SelectedIndex == 0)
                dgvTKDG.DataSource = tkdgBUS.GetDocGiaTraTre();

            else if (cbx.SelectedIndex == 1)
                dgvTKDG.DataSource = tkdgBUS.GetDocGiaLuotMuonNhieu();
        }

        private void cbxTKS_SelectedIndexChanged(object sender, EventArgs e)
        {
            ComboBox cbx = sender as ComboBox;
            if (cbx.SelectedIndex == 0)
                dgvTKS.DataSource = tksBUS.GetSachDuocMuonNhieu();

            else if (cbx.SelectedIndex == 1)
                dgvTKS.DataSource = tksBUS.GetLuotMuonSachTheoTheLoai();
        }

        // ========== Tab Quy Dinh ==========
        private void TabQuyDinh_Click(object sender, EventArgs e)
        {
            //Load Tab Quy Dinh Doc Gia
            qddgBUS.LoadPanelQDDG(ref dgvQDDG, ref txtMaQDDG, ref txtQDDGHanThe, ref txtQDDGTuoiToiThieu, ref txtQDDGTuoiToiDa, qddgBUS);
            ldgBUS.LoadPanelLoaiDG(ref dgvLoaiDG, ref txtMaLoaiDGQDDG, ref txtTenLoaiDGQDDG, ldgBUS);
            //Load Tab Quy Dinh Phieu Muon
            qdpmBUS.LoadTabQDPM(ref dgvQDPM, ref txtMaQDPM, ref txtQDPMSoSachMax, ref txtQDPMSoNgayMuonMax, qdpmBUS);
        }


        // 1. Tab Quy Dinh Doc Gia
        private void tabItemQDDG_Click(object sender, EventArgs e)
        {
            qddgBUS.LoadPanelQDDG(ref dgvQDDG, ref txtMaQDDG, ref txtQDDGHanThe, ref txtQDDGTuoiToiThieu, ref txtQDNVTuoiToiDa, qddgBUS);
            ldgBUS.LoadPanelLoaiDG(ref dgvLoaiDG, ref txtMaLoaiDGQDDG, ref txtTenLoaiDGQDDG, ldgBUS);
        }

        //      a. Quy Dinh Doc Gia
        private void btnThemQDDG_Click(object sender, EventArgs e)
        {
            #region
            //QuyDinhDocGiaDTO qddgDTO = new QuyDinhDocGiaDTO();
            //if (!qddgBUS.MapDataQDDGFromGUI(ref qddgDTO, txtMaQDDG, txtQDDGHanThe, txtQDDGTuoiToiThieu, txtQDDGTuoiToiDa, qddgBUS))
            //{
            //    MessageBox.Show("Dữ liệu không hợp lệ", "", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
            //    return;
            //}
            //if (qddgBUS.IsTrungKhopKhoaChinh(qddgDTO.Maqd, dgvQDDG))
            //{
            //    MessageBox.Show("Trùng mã quy định độc giả", "", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
            //    return;
            //}
            //// Ngày kết thúc của quy định thứ n-1 cộng thêm 1 ngày là ngày ra của quy định thứ n
            //if (dgvQDDG.RowCount != 0)
            //{
            //    QuyDinhDocGiaDTO temp = new QuyDinhDocGiaDTO();
            //    qddgBUS.UpdatePreviousDataRowQDDG(ref temp, dgvQDDG);
            //    qddgBUS.Sua(temp);
            //    qddgDTO.Ngayra = qddgDTO.Ngayra.AddDays(1);
            //}
            //if (qddgBUS.Them(qddgDTO))
            //{
            //    MessageBox.Show("Thêm thành công");
            //    qddgBUS.LoadPanelQDDG(ref dgvQDDG, ref txtMaQDDG, ref txtQDDGHanThe, ref txtQDDGTuoiToiThieu, ref txtQDDGTuoiToiDa, qddgBUS);
            //}
            //else MessageBox.Show("Thêm không thành công", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            #endregion

            QuyDinhDocGiaGUI.Instance.Them(ref dgvQDDG, ref txtMaQDDG, ref txtQDDGHanThe, ref txtQDDGTuoiToiThieu, ref txtQDDGTuoiToiDa, qddgBUS);
        }

        private void btnXoaQDDG_Click(object sender, EventArgs e)
        {
            #region
            //if (dgvQDDG.RowCount != 0)
            //{
            //    QuyDinhDocGiaDTO qddgDTO = new QuyDinhDocGiaDTO();
            //    foreach (DataGridViewRow row in dgvQDDG.SelectedRows)
            //    {
            //        qddgDTO.Maqd = row.Cells["MAQD"].Value.ToString();
            //        qddgBUS.Xoa(qddgDTO);
            //    }
            //    qddgBUS.LoadPanelQDDG(ref dgvQDDG, ref txtMaQDDG, ref txtQDDGHanThe, ref txtQDDGTuoiToiThieu, ref txtQDNVTuoiToiDa, qddgBUS); // Bao gom luon ClearPanel neu row = 0
            //    //Sau khi delete
            //    if (dgvQDDG.RowCount == 0)
            //    {
            //        qddgBUS.ResetSTT();
            //    }
            //}
            #endregion

            QuyDinhDocGiaGUI.Instance.Xoa(ref dgvQDDG, ref txtMaQDDG, ref txtQDDGHanThe, ref txtQDDGTuoiToiThieu, ref txtQDDGTuoiToiDa, qddgBUS);
        }

        private void btnSuaQDDG_Click(object sender, EventArgs e)
        {
            #region
            //QuyDinhDocGiaDTO qddgDTO = new QuyDinhDocGiaDTO();
            //if (!qddgBUS.MapDataQDDGFromGUI(ref qddgDTO, txtMaQDDG, txtQDDGHanThe, txtQDDGTuoiToiThieu, txtQDDGTuoiToiDa, qddgBUS))
            //{
            //    MessageBox.Show("Dữ liệu không hợp lệ", "", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
            //    return;
            //}
            //if (qddgBUS.Sua(qddgDTO))
            //{
            //    MessageBox.Show("Cập nhật thành công");
            //    qddgBUS.LoadPanelQDDG(ref dgvQDDG, ref txtMaQDDG, ref txtQDDGHanThe, ref txtQDDGTuoiToiThieu, ref txtQDDGTuoiToiDa, qddgBUS);
            //}
            //else MessageBox.Show("Cập nhật không thành công", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            #endregion

            QuyDinhDocGiaGUI.Instance.Sua(ref dgvQDDG, ref txtMaQDDG, ref txtQDDGHanThe, ref txtQDDGTuoiToiThieu, ref txtQDDGTuoiToiDa, qddgBUS);
        }

        private void btnClearQDDG_Click(object sender, EventArgs e)
        {
            qddgBUS.ClearPanelQDDG(qddgBUS, ref txtMaQDDG, ref txtQDDGHanThe, ref txtQDDGTuoiToiThieu, ref txtQDNVTuoiToiDa);
        }

        private void dgvQDDG_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            DataGridViewRow row = new DataGridViewRow();
            row = dgvQDDG.SelectedCells[0].OwningRow;
            qddgBUS.GetDataWhenClickDGVQDDG(row, ref txtMaQDDG, ref txtQDDGHanThe, ref txtQDDGTuoiToiThieu, ref txtQDDGTuoiToiDa);
        }


        //      b. Loai Doc Gia
        private void btnThemLoaiDG_Click(object sender, EventArgs e)
        {
            #region
            //if (string.IsNullOrEmpty(txtMaLoaiDGQDDG.Text) == false || string.IsNullOrEmpty(txtTenLoaiDGQDDG.Text) == false)
            //{
            //    LoaiDocGiaDTO ldgDTO = new LoaiDocGiaDTO();
            //    ldgBUS.MapDataLoaiDGFromGUILoaiDG(ref ldgDTO, txtMaLoaiDGQDDG, txtTenLoaiDGQDDG);
            //    if (ldgBUS.IsTrungKhopKhoaChinh(ldgDTO.Maloaidg, dgvLoaiDG))
            //    {
            //        MessageBox.Show("Trùng khớp mã loại độc giả", "", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
            //        return;
            //    }
            //    if (ldgBUS.Them(ldgDTO))
            //    {
            //        MessageBox.Show("Thêm thành công");
            //        ldgBUS.LoadPanelLoaiDG(ref dgvLoaiDG, ref txtMaLoaiDGQDDG, ref txtTenLoaiDGQDDG, ldgBUS);
            //    }

            //    else MessageBox.Show("Thêm không thành công", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            //}
            //else { MessageBox.Show("Dữ liệu không đầy đủ", "Asterrisk", MessageBoxButtons.OK, MessageBoxIcon.Asterisk); }
            #endregion

            LoaiDocGiaGUI.Instance.Them(ref dgvLoaiDG, ref txtMaLoaiDGQDDG, ref txtTenLoaiDGQDDG, ldgBUS);
        }

        private void btnXoaLoaiDG_Click(object sender, EventArgs e)
        {
            #region
            //if (dgvLoaiDG.RowCount != 0)
            //{
            //    LoaiDocGiaDTO ldgDTO = new LoaiDocGiaDTO();
            //    string chuoiLDG = "";
            //    foreach (DataGridViewRow row in dgvLoaiDG.SelectedRows)
            //    {
            //        ldgDTO.Maloaidg = row.Cells["MALOAIDG"].Value.ToString();
            //        ldgBUS.Xoa(ldgDTO, ref chuoiLDG);
            //    }
            //    if (chuoiLDG != "")
            //    {
            //        MessageBox.Show("Loại độc giả có mã: " + chuoiLDG + " đang được sử dụng bởi độc giả nên không thể xóa", "", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
            //        chuoiLDG = "";
            //    }
            //    ldgBUS.LoadPanelLoaiDG(ref dgvLoaiDG, ref txtMaLoaiDGQDDG, ref txtTenLoaiDGQDDG, ldgBUS);
            //}
            #endregion

            LoaiDocGiaGUI.Instance.Xoa(ref dgvLoaiDG, ref txtMaLoaiDGQDDG, ref txtTenLoaiDGQDDG, ldgBUS);
        }

        private void btnSuaLoaiDG_Click(object sender, EventArgs e)
        {
            #region
            //if (string.IsNullOrEmpty(txtMaLoaiDGQDDG.Text) == false || string.IsNullOrEmpty(txtTenLoaiDGQDDG.Text) == false)
            //{
            //    LoaiDocGiaDTO ldgDTO = new LoaiDocGiaDTO();
            //    ldgBUS.MapDataLoaiDGFromGUILoaiDG(ref ldgDTO, txtMaLoaiDGQDDG, txtTenLoaiDGQDDG);
            //    if (ldgBUS.IsTrungKhopKhoaChinh(ldgDTO.Maloaidg, dgvLoaiDG))
            //    {
            //        MessageBox.Show("Trùng khớp mã loại độc giả", "", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
            //        return;
            //    }
            //    if (ldgBUS.Sua(ldgDTO))
            //    {
            //        MessageBox.Show("Cập nhật thành công");
            //        ldgBUS.LoadPanelLoaiDG(ref dgvLoaiDG, ref txtMaLoaiDGQDDG, ref txtTenLoaiDGQDDG, ldgBUS);
            //    }

            //    else MessageBox.Show("Cập nhật không thành công", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            //}
            //else { MessageBox.Show("Dữ liệu không đầy đủ", "Asterrisk", MessageBoxButtons.OK, MessageBoxIcon.Asterisk); }
            #endregion

            LoaiDocGiaGUI.Instance.Sua(ref dgvLoaiDG, ref txtMaLoaiDGQDDG, ref txtTenLoaiDGQDDG, ldgBUS);
        }

        private void dgvLoaiDG_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            DataGridViewRow row = new DataGridViewRow();
            row = dgvLoaiDG.SelectedCells[0].OwningRow;
            ldgBUS.GetDataWhenClickDGVLoaiDG(dgvLoaiDG.Rows[0], ref txtMaLoaiDGQDDG, ref txtTenLoaiDGQDDG);
        }

        private void btnClearLoaiDG_Click(object sender, EventArgs e)
        {
            ldgBUS.ClearPanelLoaiDG(ref txtMaLoaiDGQDDG, ref txtTenLoaiDGQDDG);
        }



        // 2. Tab Quy Dinh Sach
        private void tabItemQDSach_Click(object sender, EventArgs e)
        {
            qdsBUS.LoadPanelQDS(ref dgvQDS, ref txtMaQDS, ref txtQDThoiHanSach, qdsBUS);
            lsBUS.LoadPanelLoaiSach(ref dgvLoaiSach, ref txtMaLoaiSachQDS, ref txtTenLoaiSachQDS, lsBUS);
        }

        //      a. Quy Dinh Sach
        private void btnThemQDS_Click(object sender, EventArgs e)
        {
            #region
            //QuyDinhSachDTO qdsDTO = new QuyDinhSachDTO();

            //if (!qdsBUS.MapDataQDSFromGUI(ref qdsDTO, txtMaQDS, txtQDThoiHanSach, qdsBUS))
            //{
            //    MessageBox.Show("Dữ liệu không hợp lệ", "", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
            //    return;
            //}
            //if (qdsBUS.IsTrungKhopKhoaChinh(qdsDTO.Maqd, dgvQDS))
            //{
            //    MessageBox.Show("Trùng mã quy định sách", "", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
            //    return;
            //}
            //if (dgvQDS.RowCount != 0)
            //{
            //    QuyDinhSachDTO temp = new QuyDinhSachDTO();
            //    qdsBUS.UpdatePreviousDataRowQDS(ref temp, dgvQDS);
            //    qdsBUS.Sua(temp);
            //    qdsDTO.Ngayra = qdsDTO.Ngayra.AddDays(1);
            //}

            //if (qdsBUS.Them(qdsDTO))
            //{
            //    MessageBox.Show("Thêm thành công");
            //    qdsBUS.LoadDgvQDS(ref dgvQDS, qdsBUS);
            //}
            //else MessageBox.Show("Thêm không thành công", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            #endregion
            QuyDinhSachGUI.Instance.Them(ref dgvQDS, ref txtMaQDS, ref txtQDThoiHanSach, qdsBUS);
        }

        private void btnXoaQDS_Click(object sender, EventArgs e)
        {
            #region
            //if (dgvQDS.RowCount != 0)
            //{
            //    QuyDinhSachDTO qdsDTO = new QuyDinhSachDTO();
            //    foreach (DataGridViewRow row in dgvQDS.Rows)
            //    {
            //        qdsDTO.Maqd = row.Cells["MAQD"].Value.ToString();
            //        qdsBUS.Xoa(qdsDTO);
            //    }
            //    qdsBUS.LoadPanelQDS(ref dgvQDS, ref txtMaQDS, ref txtQDThoiHanSach, qdsBUS);// Bao gom luon ClearPanel neu row = 0
            //    if (dgvQDS.RowCount == 0)
            //    {
            //        qdsBUS.ResetSTT();
            //    }
            //}
            #endregion
            QuyDinhSachGUI.Instance.Xoa(ref dgvQDS, ref txtMaQDS, ref txtQDThoiHanSach, qdsBUS);
        }

        private void btnSuaQDS_Click(object sender, EventArgs e)
        {
            #region
            //QuyDinhSachDTO qdsDTO = new QuyDinhSachDTO();
            //if (!qdsBUS.MapDataQDSFromGUI(ref qdsDTO, txtMaQDS, txtQDThoiHanSach, qdsBUS))
            //{
            //    MessageBox.Show("Dữ liệu không hợp lệ", "", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
            //    return;
            //}
            //if (qdsBUS.Sua(qdsDTO))
            //{
            //    qdsBUS.LoadBangQDS();
            //    MessageBox.Show("Cập nhật thành công");
            //}
            //else
            //{
            //    MessageBox.Show("Cập nhật không thành công", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            //}
            #endregion
            QuyDinhSachGUI.Instance.Sua(ref dgvQDS, ref txtMaQDS, ref txtQDThoiHanSach, qdsBUS);
        }

        private void dgvQDS_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            qdsBUS.GetDataWhenClickDGVQDS(dgvQDS.SelectedCells[0].OwningRow, ref txtMaQDS, ref txtQDThoiHanSach);
        }

        private void btnClearQDS_Click(object sender, EventArgs e)
        {
            qdsBUS.ClearPanelQDS(ref txtMaQDS, ref txtQDThoiHanSach, qdsBUS);
        }


        //      b. Loai Sach
        private void btnThemLoaiSach_Click(object sender, EventArgs e)
        {
            #region
            //if (string.IsNullOrEmpty(txtMaLoaiSachQDS.Text) == false || string.IsNullOrEmpty(txtTenLoaiSachQDS.Text) == false)
            //{
            //    LoaiSachDTO lsDTO = new LoaiSachDTO();
            //    lsBUS.MapDataLSFromGUILoaiSach(ref lsDTO, txtMaLoaiSachQDS, txtTenLoaiSachQDS);
            //    if (lsBUS.IsTrungKhopKhoaChinh(lsDTO.Matheloai, dgvLoaiSach))
            //    {
            //        MessageBox.Show("Trùng khớp mã thể loại", "", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
            //        return;
            //    }

            //    if (lsBUS.Them(lsDTO))
            //    {
            //        MessageBox.Show("Thêm thành công");
            //        lsBUS.LoadPanelLoaiSach(ref dgvLoaiSach, ref txtMaLoaiSachQDS, ref txtTenLoaiSachQDS, lsBUS);
            //    }

            //    else MessageBox.Show("Thêm không thành công", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            //}
            //else { MessageBox.Show("Dữ liệu không đầy đủ", "Asterrisk", MessageBoxButtons.OK, MessageBoxIcon.Asterisk); }
            #endregion
            LoaiSachGUI.Instance.Them(ref dgvLoaiSach, ref txtMaLoaiSachQDS, ref txtTenLoaiSachQDS, lsBUS);
        }

        private void btnXoaLoaiSach_Click(object sender, EventArgs e)
        {
            #region
            //if (dgvLoaiSach.RowCount != 0)
            //{
            //    LoaiSachDTO lsDTO = new LoaiSachDTO();
            //    string chuoiLS = "";
            //    foreach (DataGridViewRow row in dgvLoaiSach.SelectedRows)
            //    {
            //        lsDTO.Matheloai = row.Cells["MATHELOAI"].Value.ToString();
            //        lsBUS.Xoa(lsDTO, ref chuoiLS);
            //    }
            //    if (chuoiLS != "")
            //    {
            //        MessageBox.Show("Thể loại sách có mã: " + chuoiLS + " đang được sử dụng cho sách nên không thể xóa", "", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
            //        chuoiLS = "";
            //    }
            //    lsBUS.LoadPanelLoaiSach(ref dgvLoaiSach, ref txtMaLoaiSachQDS, ref txtTenLoaiSachQDS, lsBUS);
            //}
            #endregion
            LoaiSachGUI.Instance.Xoa(ref dgvLoaiSach, ref txtMaLoaiSachQDS, ref txtTenLoaiSachQDS, lsBUS);
        }

        private void btnSuaLoaiSach_Click(object sender, EventArgs e)
        {
            #region
            //if (string.IsNullOrEmpty(txtMaLoaiSachQDS.Text) == false || string.IsNullOrEmpty(txtTenLoaiSachQDS.Text) == false)
            //{
            //    LoaiSachDTO lsDTO = new LoaiSachDTO();
            //    lsBUS.MapDataLSFromGUILoaiSach(ref lsDTO, txtMaLoaiSachQDS, txtTenLoaiSachQDS);
            //    if (lsBUS.IsTrungKhopKhoaChinh(lsDTO.Matheloai, dgvLoaiSach))
            //    {
            //        MessageBox.Show("Trùng mã quy định sách", "", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
            //        return;
            //    }

            //    if (lsBUS.Sua(lsDTO))
            //    {
            //        MessageBox.Show("Cập nhật thành công");
            //        lsBUS.LoadPanelLoaiSach(ref dgvLoaiSach, ref txtMaLoaiSachQDS, ref txtTenLoaiSachQDS, lsBUS);
            //    }

            //    else MessageBox.Show("Cập nhật không thành công", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            //}
            //else { MessageBox.Show("Dữ liệu không đầy đủ", "Asterrisk", MessageBoxButtons.OK, MessageBoxIcon.Asterisk); }
            #endregion
            LoaiSachGUI.Instance.Sua(ref dgvLoaiSach, ref txtMaLoaiSachQDS, ref txtTenLoaiSachQDS, lsBUS);
        }

        private void dgvLoaiSach_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            DataGridViewRow row = dgvLoaiSach.SelectedCells[0].OwningRow;
            lsBUS.GetDataWhenClickDGVLoaiSach(row, ref txtMaLoaiSachQDS, ref txtTenLoaiSachQDS);
        }

        private void btnClearLoaiSach_Click(object sender, EventArgs e)
        {
            lsBUS.ClearPanelLoaiSach(ref txtMaLoaiSachQDS, ref txtTenLoaiSachQDS);
        }


        // 3. Tab Quy Dinh Nhan Vien
        private void tabItemQDNV_Click(object sender, EventArgs e)
        {
            qdnvBUS.LoadPanelQDNV(ref dgvQDNV, ref txtMaQDNV, ref txtQDNVTuoiToiThieu, ref txtQDNVTuoiToiDa, qdnvBUS);
            cvnvBUS.LoadPanelCVNV(ref dgvChucVu, ref txtMaChucVuQDNV, ref txtTenChucVuQDNV, cvnvBUS);
        }

        //      a. Quy Dinh Nhan Vien
        private void btnThemQDNV_Click(object sender, EventArgs e)
        {
            #region
            //QuyDinhNhanVienDTO qdnvDTO = new QuyDinhNhanVienDTO();

            //if (!qdnvBUS.MapDataQDNVFromGUI(ref qdnvDTO, txtMaQDNV, txtQDNVTuoiToiThieu, txtQDNVTuoiToiDa, qdnvBUS))
            //{
            //    MessageBox.Show("Dữ liệu không hợp lệ", "", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
            //    return;
            //}
            //if (qdnvBUS.IsTrungKhopKhoaChinh(qdnvDTO.Maqd, dgvQDNV))
            //{
            //    MessageBox.Show("Trùng mã quy định nhân viên", "", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
            //    return;
            //}

            //if (dgvQDNV.RowCount != 0)
            //{
            //    QuyDinhNhanVienDTO temp = new QuyDinhNhanVienDTO();
            //    qdnvBUS.UpdatePreviousDataRowQDNV(ref temp, dgvQDNV);
            //    qdnvBUS.Sua(temp);
            //    qdnvDTO.Ngayra = qdnvDTO.Ngayra.AddDays(1);
            //}

            //if (qdnvBUS.Them(qdnvDTO))
            //{
            //    MessageBox.Show("Thêm thành công");
            //    qdnvBUS.LoadDgvQDNV(ref dgvQDNV, qdnvBUS);
            //}
            //else MessageBox.Show("Thêm không thành công", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            #endregion
            QuyDinhNhanVienGUI.Instance.Them(ref dgvQDNV, ref txtMaQDNV, ref txtQDNVTuoiToiThieu, ref txtQDNVTuoiToiDa, qdnvBUS);
        }

        private void btnXoaQDNV_Click(object sender, EventArgs e)
        {
            #region
            //if (dgvQDNV.RowCount != 0)
            //{
            //    QuyDinhNhanVienDTO qdnvDTO = new QuyDinhNhanVienDTO();
            //    foreach (DataGridViewRow row in dgvQDNV.SelectedRows)
            //    {
            //        qdnvDTO.Maqd = row.Cells["MAQD"].Value.ToString();
            //        qdnvBUS.Xoa(qdnvDTO);
            //    }
            //    qdnvBUS.LoadPanelQDNV(ref dgvQDNV, ref txtMaQDNV, ref txtQDNVTuoiToiThieu, ref txtQDNVTuoiToiDa, qdnvBUS); // Bao gom luon ClearPanel neu row = 0
            //    //Sau khi delete
            //    if (dgvQDNV.RowCount == 0)
            //    {
            //        qdnvBUS.ResetSTT();
            //    }
            //}
            #endregion
            QuyDinhNhanVienGUI.Instance.Xoa(ref dgvQDNV, ref txtMaQDNV, ref txtQDNVTuoiToiThieu, ref txtQDNVTuoiToiDa, qdnvBUS);
        }

        private void btnSuaQDNV_Click(object sender, EventArgs e)
        {
            #region
            //QuyDinhNhanVienDTO qdnvDTO = new QuyDinhNhanVienDTO();

            //if (!qdnvBUS.MapDataQDNVFromGUI(ref qdnvDTO, txtMaQDNV, txtQDNVTuoiToiThieu, txtQDNVTuoiToiDa, qdnvBUS))
            //{
            //    MessageBox.Show("Dữ liệu không hợp lệ", "", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
            //    return;
            //}
            //if (qdnvBUS.Sua(qdnvDTO))
            //{
            //    MessageBox.Show("Cập nhật thành công");
            //    qdnvBUS.LoadPanelQDNV(ref dgvQDNV, ref txtMaQDNV, ref txtQDNVTuoiToiThieu, ref txtQDNVTuoiToiDa, qdnvBUS);
            //}
            //else MessageBox.Show("Cập nhật không thành công", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            #endregion
            QuyDinhNhanVienGUI.Instance.Sua(ref dgvQDNV, ref txtMaQDNV, ref txtQDNVTuoiToiThieu, ref txtQDNVTuoiToiDa, qdnvBUS);
        }

        private void btnClearQDNV_Click(object sender, EventArgs e)
        {
            qdnvBUS.CLearPanelQDNV(ref txtMaQDNV, ref txtQDNVTuoiToiThieu, ref txtQDNVTuoiToiDa, qdnvBUS);
        }

        private void dgvQDNV_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            DataGridViewRow row = new DataGridViewRow();
            row = dgvQDNV.SelectedCells[0].OwningRow;
            qdnvBUS.GetDataWhenClickDGVQDNV(row, ref txtMaQDNV, ref txtQDNVTuoiToiThieu, ref txtQDNVTuoiToiDa);
        }


        //      b. Chuc Vu Nhan Vien
        private void btnThemChucVu_Click(object sender, EventArgs e)
        {
            #region
            //if (string.IsNullOrEmpty(txtMaChucVuQDNV.Text) == false || string.IsNullOrEmpty(txtTenChucVuQDNV.Text) == false)
            //{
            //    ChucVuNhanVienDTO cvnvDTO = new ChucVuNhanVienDTO();
            //    cvnvBUS.MapDataCVNVFromGUICVNV(ref cvnvDTO, txtMaChucVuQDNV, txtTenChucVuQDNV);
            //    if (cvnvBUS.IsTrungKhopKhoaChinh(cvnvDTO.Macv,dgvChucVu))
            //    {
            //        MessageBox.Show("Trùng khớp mã chức vụ", "", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
            //        return;
            //    }

            //    if (cvnvBUS.Them(cvnvDTO))
            //    {
            //        MessageBox.Show("Thêm thành công");
            //        cvnvBUS.LoadPanelCVNV(ref dgvChucVu, ref txtMaChucVuQDNV, ref txtTenChucVuQDNV, cvnvBUS);
            //    }

            //    else MessageBox.Show("Thêm không thành công", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            //}
            //else { MessageBox.Show("Dữ liệu không đầy đủ", "Asterrisk", MessageBoxButtons.OK, MessageBoxIcon.Asterisk); }
            #endregion
            ChucVuNhanVienGUI.Instance.Them(ref dgvChucVu, ref txtMaChucVuQDNV, ref txtTenChucVuQDNV, cvnvBUS);
        }

        private void btnXoaChucVu_Click(object sender, EventArgs e)
        {
            #region
            //if (dgvChucVu.RowCount != 0)
            //{
            //    ChucVuNhanVienDTO cvnvDTO = new ChucVuNhanVienDTO();
            //    string chuoiCVNV = "";
            //    foreach (DataGridViewRow row in dgvChucVu.SelectedRows)
            //    {
            //        cvnvDTO.Macv = row.Cells["MACHUCVU"].Value.ToString();
            //        cvnvBUS.Xoa(cvnvDTO, ref chuoiCVNV);
            //    }
            //    if (chuoiCVNV != "")
            //    {
            //        MessageBox.Show("Chức vụ có mã: " + chuoiCVNV + " đang được sử dụng bởi nhân viên nên không thể xóa", "", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
            //        chuoiCVNV = "";
            //    }
            //    cvnvBUS.LoadPanelCVNV(ref dgvChucVu, ref txtMaChucVuQDNV, ref txtTenChucVuQDNV, cvnvBUS);
            //}
            #endregion
            ChucVuNhanVienGUI.Instance.Xoa(ref dgvChucVu, ref txtMaChucVuQDNV, ref txtTenChucVuQDNV, cvnvBUS);
        }

        private void btnSuaChucVu_Click(object sender, EventArgs e)
        {
            #region
            //if (string.IsNullOrEmpty(txtMaChucVuQDNV.Text) == false || string.IsNullOrEmpty(txtTenChucVuQDNV.Text) == false)
            //{
            //    ChucVuNhanVienDTO cvnvDTO = new ChucVuNhanVienDTO();
            //    cvnvBUS.MapDataCVNVFromGUICVNV(ref cvnvDTO, txtMaChucVuQDNV, txtTenChucVuQDNV);
            //    if (cvnvBUS.IsTrungKhopKhoaChinh(cvnvDTO.Macv, dgvChucVu))
            //    {
            //        MessageBox.Show("Trùng khớp mã chức vụ", "", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
            //        return;
            //    }

            //    if (cvnvBUS.Sua(cvnvDTO))
            //    {
            //        MessageBox.Show("Cập nhật thành công");
            //        cvnvBUS.LoadPanelCVNV(ref dgvChucVu, ref txtMaChucVuQDNV, ref txtTenChucVuQDNV, cvnvBUS);
            //    }

            //    else MessageBox.Show("Cập nhật không thành công", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            //}
            //else { MessageBox.Show("Dữ liệu không đầy đủ", "Asterrisk", MessageBoxButtons.OK, MessageBoxIcon.Asterisk); }
            #endregion
            ChucVuNhanVienGUI.Instance.Sua(ref dgvChucVu, ref txtMaChucVuQDNV, ref txtTenChucVuQDNV, cvnvBUS);
        }

        private void btnClearChucVu_Click(object sender, EventArgs e)
        {
            cvnvBUS.ClearPanelCVNV(ref txtMaChucVuQDNV, ref txtTenChucVuQDNV);
        }

        private void dgvChucVu_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            DataGridViewRow row = new DataGridViewRow();
            row = dgvChucVu.SelectedCells[0].OwningRow;
            cvnvBUS.GetDataWhenClickDGVCVNV(row, ref txtMaChucVuQDNV, ref txtTenChucVuQDNV);
        }


        // 4. Tab Quy Dinh Phieu Muon
        private void tabItemQDPM_Click(object sender, EventArgs e)
        {
            qdpmBUS.LoadTabQDPM(ref dgvQDPM, ref txtMaQDPM, ref txtQDPMSoSachMax, ref txtQDPMSoNgayMuonMax, qdpmBUS);
        }

        private void btnThemQDPM_Click(object sender, EventArgs e)
        {
            #region
            //QuyDinhPhieuMuonDTO qdpmDTO = new QuyDinhPhieuMuonDTO();

            //if (!qdpmBUS.MapDataQDPMFromGUIQDPM(ref qdpmDTO, txtMaQDPM, txtQDPMSoSachMax, txtQDPMSoNgayMuonMax, qdpmBUS))
            //{
            //    MessageBox.Show("Dữ liệu không hợp lệ", "", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
            //    return;
            //}
            //if (qdpmBUS.IsTrungKhopKhoaChinh(qdpmDTO.Maqd.ToString(), dgvQDPM))
            //{
            //    MessageBox.Show("Trùng mã quy định phiếu mượn", "", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
            //    return;
            //}
            //if (dgvQDPM.RowCount != 0)
            //{
            //    QuyDinhPhieuMuonDTO temp = new QuyDinhPhieuMuonDTO();
            //    qdpmBUS.UpdatePreviousDataRowQDPM(ref temp, dgvQDPM);
            //    qdpmBUS.Sua(temp);
            //    qdpmDTO.Ngayra = qdpmDTO.Ngayra.AddDays(1);
            //}

            //if (qdpmBUS.Them(qdpmDTO))
            //{
            //    MessageBox.Show("Thêm thành công");
            //    qdpmBUS.LoadDgvQDPM(ref dgvQDPM, qdpmBUS);
            //}
            //else MessageBox.Show("Thêm không thành công", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            #endregion
            QuyDinhPhieuMuonGUI.Instance.Them(ref dgvQDPM, ref txtMaQDPM, ref txtQDPMSoSachMax, ref txtQDPMSoNgayMuonMax, qdpmBUS);
        }

        private void btnXoaQDPM_Click(object sender, EventArgs e)
        {
            #region
            //if(dgvQDPM.RowCount != 0)
            //{
            //    QuyDinhPhieuMuonDTO qdpmDTO = new QuyDinhPhieuMuonDTO();
            //    foreach(DataGridViewRow row in dgvQDPM.SelectedRows)
            //    {
            //        qdpmDTO.Maqd = row.Cells["MAQD"].Value.ToString();
            //        qdpmBUS.Xoa(qdpmDTO);
            //    }
            //    qdpmBUS.LoadTabQDPM(ref dgvQDPM, ref txtMaQDPM, ref txtQDPMSoSachMax, ref txtQDPMSoNgayMuonMax, qdpmBUS);
            //    if (dgvQDPM.RowCount == 0)
            //        qdpmBUS.ResetSTT();
            //}
            #endregion
            QuyDinhPhieuMuonGUI.Instance.Xoa(ref dgvQDPM, ref txtMaQDPM, ref txtQDPMSoSachMax, ref txtQDPMSoNgayMuonMax, qdpmBUS);
        }

        private void btnSuaQDPM_Click(object sender, EventArgs e)
        {
            #region
            //QuyDinhPhieuMuonDTO qdpmDTO = new QuyDinhPhieuMuonDTO();
            //if (!qdpmBUS.MapDataQDPMFromGUIQDPM(ref qdpmDTO, txtMaQDPM, txtQDPMSoSachMax, txtQDPMSoNgayMuonMax, qdpmBUS))
            //{
            //    MessageBox.Show("Dữ liệu không hợp lệ", "", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
            //    return;
            //}
            //if (qdpmBUS.Sua(qdpmDTO))
            //{
            //    MessageBox.Show("Cập nhật thành công");
            //    qdpmBUS.LoadTabQDPM(ref dgvQDPM, ref txtMaQDPM, ref txtQDPMSoSachMax, ref txtQDPMSoNgayMuonMax, qdpmBUS);
            //}
            //else MessageBox.Show("Cập nhật không thành công", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            #endregion
            QuyDinhPhieuMuonGUI.Instance.Sua(ref dgvQDPM, ref txtMaQDPM, ref txtQDPMSoSachMax, ref txtQDPMSoNgayMuonMax, qdpmBUS);
        }

        private void btnClearQDPM_Click(object sender, EventArgs e)
        {
            qdpmBUS.ClearPanelQDPM(ref txtMaQDPM, ref txtQDPMSoSachMax, ref txtQDPMSoNgayMuonMax, qdpmBUS);
        }

        private void dgvQDPM_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            DataGridViewRow row = new DataGridViewRow();
            row = dgvQDPM.SelectedCells[0].OwningRow;
            qdpmBUS.GetDataWhenClickDGVQDPM(row, ref txtMaQDPM, ref txtQDPMSoSachMax, ref txtQDPMSoNgayMuonMax);

        }

        // 5. Quy Dinh Phieu Tra
        private void tabItemQDPT_Click(object sender, EventArgs e)
        {
            qdptBUS.LoadTabQDPT(ref dgvQDPT, ref txtMaQDPT, ref txtQDPTTienPhat, qdptBUS);
        }

        private void btnThemQDPT_Click(object sender, EventArgs e)
        {
            #region
            //QuyDinhPhieuTraDTO qdptDTO = new QuyDinhPhieuTraDTO();
            //if (!qdptBUS.MapDataQDPTFromGUIQDPT(ref qdptDTO, txtMaQDPT, txtQDPTTienPhat, qdptBUS))
            //{
            //    MessageBox.Show("Dữ liệu không hợp lệ", "", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
            //    return;
            //}
            //if (qdptBUS.IsTrungKhopKhoaChinh(qdptDTO.Maqd, dgvQDPT))
            //{
            //    MessageBox.Show("Trùng mã quy định phiếu trả", "", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
            //    return;
            //}
            //if (dgvQDPT.RowCount != 0)
            //{
            //    QuyDinhPhieuTraDTO temp = new QuyDinhPhieuTraDTO();
            //    qdptBUS.UpdatePreviousDataRowQDPT(ref temp, dgvQDPT);
            //    qdptBUS.Sua(temp);
            //    qdptDTO.Ngayra = qdptDTO.Ngayra.AddDays(1);
            //}
            //if (qdptBUS.Them(qdptDTO))
            //{
            //    MessageBox.Show("Thêm thành công");
            //    qdptBUS.LoadDgvQDPT(ref dgvQDPT, qdptBUS);
            //}
            //else MessageBox.Show("Thêm không thành công", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            #endregion
            QuyDinhPhieuTraGUI.Instance.Them(ref dgvQDPT, ref txtMaQDPT, ref txtQDPTTienPhat, qdptBUS);
        }

        private void btnXoaQDPT_Click(object sender, EventArgs e)
        {
            #region
            //if (dgvQDPT.RowCount != 0)
            //{
            //    QuyDinhPhieuTraDTO qdptDTO = new QuyDinhPhieuTraDTO();
            //    foreach (DataGridViewRow row in dgvQDPT.SelectedRows)
            //    {
            //        qdptDTO.Maqd = row.Cells["MAQD"].Value.ToString();
            //        qdptBUS.Xoa(qdptDTO);
            //    }
            //    qdptBUS.LoadTabQDPT(ref dgvQDPT, ref txtMaQDPT, ref txtQDPTTienPhat, qdptBUS);
            //    if (dgvQDPT.RowCount == 0)
            //        qdptBUS.ResetSTT();
            //}
            #endregion
            QuyDinhPhieuTraGUI.Instance.Xoa(ref dgvQDPT, ref txtMaQDPT, ref txtQDPTTienPhat, qdptBUS);
        }

        private void btnSuaQDPT_Click(object sender, EventArgs e)
        {
            #region
            //    QuyDinhPhieuTraDTO qdptDTO = new QuyDinhPhieuTraDTO();
            //    if (!qdptBUS.MapDataQDPTFromGUIQDPT(ref qdptDTO, txtMaQDPT, txtQDPTTienPhat, qdptBUS))
            //    {
            //        MessageBox.Show("Dữ liệu không hợp lệ", "", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
            //        return;
            //    }
            //    if (qdptBUS.Sua(qdptDTO))
            //    {
            //        MessageBox.Show("Cập nhật thành công");
            //        qdptBUS.LoadTabQDPT(ref dgvQDPT, ref txtMaQDPT, ref txtQDPTTienPhat, qdptBUS);
            //    }
            //    else MessageBox.Show("Cập nhật không thành công", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            #endregion
            QuyDinhPhieuTraGUI.Instance.Sua(ref dgvQDPT, ref txtMaQDPT, ref txtQDPTTienPhat, qdptBUS);
        }

        private void btnClearQDPT_Click(object sender, EventArgs e)
        {
            qdptBUS.ClearPanelQDPT(ref txtMaQDPT, ref txtQDPTTienPhat, qdptBUS);
        }

        private void dgvQDPT_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            DataGridViewRow row = new DataGridViewRow();
            row = dgvQDPT.SelectedCells[0].OwningRow;
            qdptBUS.GetDataWhenClickDGVQDPT(row, ref txtMaQDPT, ref txtQDPTTienPhat);
        }
        #endregion


        #region Nghia
        string account_type;

        public string Account_type { get => account_type; set => account_type = value; }
        
        SachBUS sachBUS;
        TheLoaiSachBUS theloaisachBUS;
        List<string> SelectedBooks;
        bool pressed_once = false;
        InputChecking inputchecker;

        void Decentralise()
        {
            if (Account_type == "3")
            {
                TabQLSach.Enabled = false;
                TabQuyDinh.Enabled = false;
                TabNhanVien.Enabled = false;
            }
            if (Account_type == "4")
            {
                TabNhanVien.Enabled = false;
                TabDG.Enabled = false;
                TabQuyDinh.Enabled = false;
            }
        }

        protected override void OnLoad(EventArgs e)
        {
            Decentralise();
        }

        protected override void OnActivated(EventArgs e)
        {
            LoadTabSach();
            LoadTabTraSach();
        }

        private void superTabItem2_Click(object sender, EventArgs e)
        {
            LoadTabSach();
        }

        public void DisplayListBooks(List<SachDTO> ListBooks)
        {
            formatDGVSach(ListBooks);
        }

        public void formatDGVSach(List<SachDTO> ListBooks)
        {
            dgvSach.Columns.Clear();
            dgvSach.DataSource = null;

            dgvSach.AutoGenerateColumns = false;
            dgvSach.AllowUserToAddRows = false;
            dgvSach.DataSource = ListBooks;

            DataGridViewTextBoxColumn clMa = new DataGridViewTextBoxColumn();
            clMa.Name = "MaSach";
            clMa.HeaderText = "Mã Sách";
            clMa.DataPropertyName = "MaSach";
            clMa.Width = dgvSach.Width / 20;
            dgvSach.Columns.Add(clMa);

            DataGridViewTextBoxColumn clTen = new DataGridViewTextBoxColumn();
            clTen.Name = "TenSach";
            clTen.HeaderText = "Tên Sách";
            clTen.DataPropertyName = "TenSach";
            clTen.Width = (3 * dgvSach.Width) / 18;
            dgvSach.Columns.Add(clTen);

            DataGridViewTextBoxColumn clTacGia = new DataGridViewTextBoxColumn();
            clTacGia.Name = "TacGia";
            clTacGia.HeaderText = "Tác Giả";
            clTacGia.DataPropertyName = "TacGia";
            clTacGia.Width = (3 * dgvSach.Width) / 18;
            dgvSach.Columns.Add(clTacGia);

            DataGridViewTextBoxColumn clTheLoai = new DataGridViewTextBoxColumn();
            clTheLoai.Name = "TheLoai";
            clTheLoai.HeaderText = "Thể Loại";
            clTheLoai.DataPropertyName = "TheLoai";
            clTheLoai.Width = (3 * dgvSach.Width) / 18;
            dgvSach.Columns.Add(clTheLoai);

            DataGridViewTextBoxColumn clNXB = new DataGridViewTextBoxColumn();
            clNXB.Name = "NXB";
            clNXB.HeaderText = "Nhà Xuất Bản";
            clNXB.DataPropertyName = "NXB";
            clNXB.Width = (3 * dgvSach.Width) / 18;
            dgvSach.Columns.Add(clNXB);

            DataGridViewTextBoxColumn clNAMXB = new DataGridViewTextBoxColumn();
            clNAMXB.Name = "NAMXB";
            clNAMXB.HeaderText = "Năm Xuất Bản";
            clNAMXB.DataPropertyName = "NAMXB";
            clNAMXB.Width = dgvSach.Width / 20;
            dgvSach.Columns.Add(clNAMXB);

            DataGridViewTextBoxColumn clNgayNhap = new DataGridViewTextBoxColumn();
            clNgayNhap.Name = "NgayNhap";
            clNgayNhap.HeaderText = "Ngày Nhập";
            clNgayNhap.DataPropertyName = "NgayNhap";
            clNgayNhap.Width = (3 * dgvSach.Width) / 45;
            dgvSach.Columns.Add(clNgayNhap);

            DataGridViewTextBoxColumn clDonGia = new DataGridViewTextBoxColumn();
            clDonGia.Name = "DonGia";
            clDonGia.HeaderText = "Đơn Giá";
            clDonGia.DataPropertyName = "DonGia";
            clDonGia.Width = dgvSach.Width / 20;
            dgvSach.Columns.Add(clDonGia);

            DataGridViewTextBoxColumn clSoLuong = new DataGridViewTextBoxColumn();
            clSoLuong.Name = "SoLuong";
            clSoLuong.HeaderText = "Số Lượng";
            clSoLuong.DataPropertyName = "SoLuong";
            clSoLuong.Width = dgvSach.Width / 20;
            dgvSach.Columns.Add(clSoLuong);

            DataGridViewTextBoxColumn clLuotMuon = new DataGridViewTextBoxColumn();
            clLuotMuon.Name = "LuotMuon";
            clLuotMuon.HeaderText = "Lượt Mượn";
            clLuotMuon.DataPropertyName = "LuotMuon";
            clLuotMuon.Width = dgvSach.Width / 20;
            dgvSach.Columns.Add(clLuotMuon);
        }

        private void btThemSach_Click(object sender, EventArgs e)
        {
            if (pressed_once)
            {
                if (inputchecker.IsNumber(txtNamXB.Text) && inputchecker.IsNumber(txtDonGia.Text) && inputchecker.IsNumber(txtSoLuong.Text) && inputchecker.IsNumber(txtLuotMuon.Text)
                    && inputchecker.IsOnlyAlphabet(txtTacGia.Text))
                {
                    SachDTO sachDTO = new SachDTO();

                    sachDTO.Masach = txtMaSach.Text;
                    sachDTO.Tensach = txtTenSach.Text;
                    sachDTO.Tacgia = txtTacGia.Text;
                    sachDTO.Theloai = theloaisachBUS.GetMaTheLoai(cbTheLoai.Text);
                    sachDTO.Nxb = txtNhaXB.Text;
                    sachDTO.Namxb = int.Parse(txtNamXB.Text);
                    sachDTO.Ngaynhap = DateTime.Parse(dtNgayNhap.Text);
                    sachDTO.Dongia = int.Parse(txtDonGia.Text);
                    sachDTO.Soluong = int.Parse(txtSoLuong.Text);
                    sachDTO.Luotmuon = int.Parse(txtLuotMuon.Text);

                    if (!sachDTO.IsValid())
                    {
                        MessageBox.Show("Dữ liệu không hợp lệ !");

                        return;
                    }

                    if (sachBUS.Add(sachDTO))
                    {
                        MessageBox.Show("Đã thêm thành công !");
                    }
                    else
                    {
                        MessageBox.Show("Thêm thất bại !");
                    }
                }
                else
                {
                    MessageBox.Show("Dữ liệu không hợp lệ !");
                }

                BookTxtReset();
                pressed_once = false;
            }
            else
            {
                pressed_once = true;
                BookTxtReset();
            }
        }

        public void LoadTabSach()
        {
            DisplayListBooks(sachBUS.LoadListBooks());
            txtMaSach.Text = sachBUS.IDGenerator().ToString();
            txtMaSach.ReadOnly = true;
            cbTheLoai.DataSource = theloaisachBUS.LoadListCategory();
            if (dgvSach.SelectedCells.Count > 0)
            {
                UpdateTextboxSachInfo(dgvSach.SelectedCells[0].OwningRow);
            }
        }

        private void dgvSach_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (dgvSach.SelectedCells.Count > 1)
            {
                UpdateTextboxSachInfo(dgvSach.SelectedCells[0].OwningRow);
            }
            else
            {
                UpdateTextboxSachInfo(dgvSach.SelectedCells[0].OwningRow);
            }

            foreach (DataGridViewCell item in dgvSach.SelectedCells)
            {
                SelectedBooks.Add(item.OwningRow.Cells[0].Value.ToString());
            }
        }

        public void UpdateTextboxSachInfo(DataGridViewRow selectedrow)
        {
            txtMaSach.Text = selectedrow.Cells[0].Value.ToString();
            txtTenSach.Text = selectedrow.Cells[1].Value.ToString();
            txtTacGia.Text = selectedrow.Cells[2].Value.ToString();
            cbTheLoai.Text = selectedrow.Cells[3].Value.ToString();
            txtNhaXB.Text = selectedrow.Cells[4].Value.ToString();
            txtNamXB.Text = selectedrow.Cells[5].Value.ToString();
            dtNgayNhap.Text = selectedrow.Cells[6].Value.ToString();
            txtDonGia.Text = selectedrow.Cells[7].Value.ToString();
            txtSoLuong.Text = selectedrow.Cells[8].Value.ToString();
            txtLuotMuon.Text = selectedrow.Cells[9].Value.ToString();
        }

        private void btSuaSach_Click(object sender, EventArgs e)
        {
            SachDTO sachDTO = new SachDTO();

            sachDTO.Masach = txtMaSach.Text;
            if (inputchecker.IsNumber(txtNamXB.Text) && inputchecker.IsNumber(txtDonGia.Text) && inputchecker.IsNumber(txtSoLuong.Text) && inputchecker.IsNumber(txtLuotMuon.Text)
                    && inputchecker.IsOnlyAlphabet(txtTacGia.Text))
            {
                sachDTO.Tensach = txtTenSach.Text;
                sachDTO.Tacgia = txtTacGia.Text;
                sachDTO.Theloai = theloaisachBUS.GetMaTheLoai(cbTheLoai.Text);
                sachDTO.Nxb = txtNhaXB.Text;
                sachDTO.Namxb = int.Parse(txtNamXB.Text);
                sachDTO.Ngaynhap = DateTime.Parse(dtNgayNhap.Text);
                sachDTO.Dongia = int.Parse(txtDonGia.Text);
                sachDTO.Soluong = int.Parse(txtSoLuong.Text);
                sachDTO.Luotmuon = int.Parse(txtLuotMuon.Text);

                if (!sachDTO.IsValid())
                {
                    MessageBox.Show("Dữ liệu không hợp lệ !");

                    return;
                }
            }
            else
            {
                MessageBox.Show("Dữ liệu không hợp lệ !");

                return;
            }
            DialogResult dialogresult = MessageBox.Show("Bạn có muốn lưu thay đổi không ?", "", MessageBoxButtons.YesNo);

            if (dialogresult == DialogResult.Yes)
            {
                sachBUS.Edit(sachDTO);
                DisplayListBooks(sachBUS.LoadListBooks());
            }
            BookTxtReset();
        }

        public void BookTxtReset()
        {
            txtMaSach.Text = sachBUS.IDGenerator().ToString();
            txtTenSach.Text = "";
            txtTacGia.Text = "";
            cbTheLoai.Text = "";
            txtNhaXB.Text = "";
            txtNamXB.Text = "";
            dtNgayNhap.Text = "";
            txtDonGia.Text = "";
            txtSoLuong.Text = "";
            txtLuotMuon.Text = "";
        }

        private void btXoaSach_Click(object sender, EventArgs e)
        {
            foreach (DataGridViewCell item in dgvSach.SelectedCells)
            {
                SachDTO sachDTO = new SachDTO();

                sachDTO.Masach = item.OwningRow.Cells[0].Value.ToString();
                sachBUS.Delete(sachDTO);
            }

            DisplayListBooks(sachBUS.LoadListBooks());
            BookTxtReset();
        }

        private void btTimKiemSach_Click(object sender, EventArgs e)
        {
            List<SachDTO> result = new List<SachDTO>();
            SachDTO sach = new SachDTO();

            if (cbCategory.SelectedItem.ToString() == "Tên Sách")
            {
                sach.Tensach = txtSearch.Text;
                result = sachBUS.Search(sach, "Ten");
            }
            else
            {
                sach.Masach = txtSearch.Text;
                result = sachBUS.Search(sach, "Ma");
            }

            DisplayListBooks(result);
            BookTxtReset();
        }

        /* Tab Trả Sách */
        PhieuMuonBUS phieumuonBUS;
        PhieuTraBUS phieutraBUS;

        public void formatDGVReceipt(List<PhieuMuonDTO> ListReceipt)
        {
            dgvReceipt.Columns.Clear();
            dgvReceipt.DataSource = null;

            dgvReceipt.AutoGenerateColumns = false;
            dgvReceipt.AllowUserToAddRows = false;
            dgvReceipt.DataSource = ListReceipt;

            DataGridViewTextBoxColumn clMa = new DataGridViewTextBoxColumn();
            clMa.Name = "MaPM";
            clMa.HeaderText = "Mã Phiếu Mượn";
            clMa.DataPropertyName = "MaPM";
            clMa.Width = dgvReceipt.Width / 14;
            dgvReceipt.Columns.Add(clMa);

            DataGridViewTextBoxColumn clMaDG = new DataGridViewTextBoxColumn();
            clMaDG.Name = "MaDG";
            clMaDG.HeaderText = "Mã Đọc Giả";
            clMaDG.DataPropertyName = "MaDG";
            clMaDG.Width = dgvReceipt.Width / 14;
            dgvReceipt.Columns.Add(clMaDG);

            DataGridViewTextBoxColumn clTen = new DataGridViewTextBoxColumn();
            clTen.Name = "HoTen";
            clTen.HeaderText = "Họ Tên";
            clTen.DataPropertyName = "HoTen";
            clTen.Width = (5 * dgvReceipt.Width) / 21;
            dgvReceipt.Columns.Add(clTen);

            DataGridViewTextBoxColumn clNgayMuon = new DataGridViewTextBoxColumn();
            clNgayMuon.Name = "NgayMuon";
            clNgayMuon.HeaderText = "Ngày Mượn";
            clNgayMuon.DataPropertyName = "NgayMuon";
            clNgayMuon.Width = (5 * dgvReceipt.Width) / 22;
            dgvReceipt.Columns.Add(clNgayMuon);

            DataGridViewTextBoxColumn clHanTra = new DataGridViewTextBoxColumn();
            clHanTra.Name = "HanTra";
            clHanTra.HeaderText = "Hạn Trả";
            clHanTra.DataPropertyName = "HanTra";
            clHanTra.Width = (5 * dgvReceipt.Width) / 22;
            dgvReceipt.Columns.Add(clHanTra);

            DataGridViewTextBoxColumn clSoLuong = new DataGridViewTextBoxColumn();
            clSoLuong.Name = "SoLuong";
            clSoLuong.HeaderText = "Số sách mượn";
            clSoLuong.DataPropertyName = "SoLuong";
            clSoLuong.Width = dgvReceipt.Width / 14;
            dgvReceipt.Columns.Add(clSoLuong);

            DataGridViewTextBoxColumn clMucPhat = new DataGridViewTextBoxColumn();
            clMucPhat.Name = "MucPhat";
            clMucPhat.HeaderText = "Mức phạt";
            clMucPhat.DataPropertyName = "MucPhat";
            clMucPhat.Width = dgvReceipt.Width / 14;
            dgvReceipt.Columns.Add(clMucPhat);
        }

        public void DisplayListReceipt(List<PhieuMuonDTO> ListReceipt)
        {
            formatDGVReceipt(ListReceipt);

            CurrencyManager myCurrencyManager = (CurrencyManager)this.BindingContext[dgvReceipt.DataSource];
            myCurrencyManager.Refresh();
        }

        public void LoadTabTraSach()
        {
            phieumuonBUS = new PhieuMuonBUS();
            phieutraBUS = new PhieuTraBUS();

            DisplayListReceipt(phieumuonBUS.DisplayListReceipt());
            if (dgvReceipt.SelectedCells.Count > 0)
            {
                UpdateTextboxPhieuTraInfo(dgvReceipt.SelectedCells[0].OwningRow);
            }
            else
            {
                txtMaPhieu.Text = phieutraBUS.IDGenerator().ToString();
            }
            txtMaPhieu.ReadOnly = true;
        }

        private void superTabItem7_Click(object sender, EventArgs e)
        {
            LoadTabTraSach();

        }

        public void UpdateTextboxPhieuTraInfo(DataGridViewRow selectedrow)
        {
            txtMaPhieu.Text = selectedrow.Cells[0].Value.ToString();
            txtMaPhieu.ReadOnly = true;
            txtMaDG.Text = selectedrow.Cells[2].Value.ToString();
            txtMaDG.ReadOnly = true;
            txtTenDG.Text = selectedrow.Cells[5].Value.ToString();
            txtTenDG.ReadOnly = true;
            dtNgayMuon.Text = selectedrow.Cells[3].Value.ToString();
            dtNgayMuon.Enabled = false;
           // dtHanTra.Text = DateTime.Parse(selectedrow.Cells[4].Value.ToString());
            string hantra = selectedrow.Cells[4].Value.ToString();
            dtHanTra.Value = DateTime.Parse(hantra);
            dtHanTra.Enabled = false;
            txtSL.Text = selectedrow.Cells[6].Value.ToString();
            txtSL.ReadOnly = true;
        }

        public void ReturnReceiptTxtReset()
        {
            txtMaPhieu.Text = "";
            txtMaDG.Text = "";
            txtTenDG.Text = "";
            dtNgayMuon.Text = "";
            dtHanTra.Text = "";
            txtSL.Text = "";
        }

        private void dgvReceipt_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (dgvReceipt.SelectedCells.Count > 1)
            {
                UpdateTextboxPhieuTraInfo(dgvReceipt.SelectedCells[dgvReceipt.SelectedCells.Count - 1].OwningRow);
            }
            else
            {
                UpdateTextboxPhieuTraInfo(dgvReceipt.SelectedCells[0].OwningRow);
            }
        }

        private void buttonX27_Click(object sender, EventArgs e)
        {
            if (dgvReceipt.Rows.Count == 0 || dgvReceipt.SelectedCells.Count == 0)
            {
                MessageBox.Show("Không có phiếu mượn cần trả !");
            }
            else
            {
                DataGridViewRow SelectedRow = dgvReceipt.SelectedCells[0].OwningRow;
                frmTraSach form = new frmTraSach(new PhieuMuonDTO(SelectedRow.Cells["MaPM"].Value.ToString(), "1", 
                    SelectedRow.Cells["MaDG"].Value.ToString(), 
                    DateTime.Parse(SelectedRow.Cells["NgayMuon"].Value.ToString()),
                    DateTime.Parse(SelectedRow.Cells["HanTra"].Value.ToString()), 
                    SelectedRow.Cells["HoTen"].Value.ToString(), 
                    decimal.Parse(SelectedRow.Cells["MucPhat"].Value.ToString())));

                form.ShowDialog();
            }
        }

        private void btnSearch_TraSach_Click(object sender, EventArgs e)
        {
            DisplayListReceipt(phieumuonBUS.Search(txtSearch.Text, cbCategory.SelectedText));
            ReturnReceiptTxtReset();
        }

        #endregion
    }
}
