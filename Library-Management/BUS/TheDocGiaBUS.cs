using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using DevComponents.DotNetBar.Controls;
using DevComponents.Editors.DateTimeAdv;
using DAL;
using DTO;
namespace BUS
{
    public class TheDocGiaBUS
    {
        private TheDocGiaDAL tdgDAL;
        private QDLoaiDocGiaDAL ldgDAL;

        public TheDocGiaBUS()
        {
            tdgDAL = new TheDocGiaDAL();
            ldgDAL = new QDLoaiDocGiaDAL();
        }
        public DataTable GetBangDocGia()
        {
            return tdgDAL.LoadBangDocGia();
        }

        public void LoadListLoaiDG(ref ComboBoxEx cbxLoaiDG, QDLoaiDocGiaBUS ldgBUS)
        {
            try
            {
                cbxLoaiDG.DataSource = ldgBUS.LoadBangLoaiDG();

                cbxLoaiDG.DisplayMember = "TENLOAIDG";
            }
            catch { }
        }

        public void LoadDgvDG(ref DataGridViewX dgvDG, TheDocGiaBUS tdgBUS)
        {
            dgvDG.DataSource = tdgBUS.GetBangDocGia();
        }

        public void LoadQDDG(ref TextBoxX txtTuoiToiThieu, ref TextBoxX txtTuoiToiDa, ref TextBoxX txtThoiHanThe, QuyDinhDocGiaBUS qddgBUS)
        {
            DataTable data = qddgBUS.LoadBangQDDG();
            if (data.Rows.Count != 0)
            {
                DataRow row = data.Rows[data.Rows.Count - 1];
                txtTuoiToiThieu.Text = row["TUOITOITHIEU"].ToString();
                txtTuoiToiDa.Text = row["TUOITOIDA"].ToString();
                txtThoiHanThe.Text = row["THOIHANTHE"].ToString();
            }
            else
            {
                txtTuoiToiThieu.Text = "";
                txtTuoiToiDa.Text = "";
                txtThoiHanThe.Text = "";
            }
        }

        public void LoadTabQLDG(ref DataGridViewX dgvDG, ref TextBoxX txtMaDG, ref TextBoxX txtHoTen, ref DateTimeInput dtpNgaySinh, ref TextBoxX txtDiaChi, ref TextBoxX txtEmail, ref ComboBoxEx cbxLoaiDG, ref DateTimeInput dtpNgayLapThe, ref DateTimeInput dtpNgayHetHan, ref TextBoxX txtSoSachDangMuon, ref TextBoxX txtTongTienNo, ref TextBoxX txtTuoiToiThieu, ref TextBoxX txtTuoiToiDa, ref ComboBoxEx cbxTimKiemDG, ref TextBoxX txtThoiHanThe, QDLoaiDocGiaBUS ldgBUS, TheDocGiaBUS tdgBUS, QuyDinhDocGiaBUS qddgBUS)
        {
            LoadListLoaiDG(ref cbxLoaiDG, ldgBUS);
            LoadDgvDG(ref dgvDG, tdgBUS);
            LoadQDDG(ref txtTuoiToiThieu, ref txtTuoiToiDa, ref txtThoiHanThe, qddgBUS);
            if (dgvDG.RowCount != 0)
                GetDataWhenClickDGVDG(dgvDG.Rows[0], ref txtMaDG, ref txtHoTen, ref dtpNgaySinh, ref txtDiaChi, ref txtEmail, ref cbxLoaiDG, ref dtpNgayLapThe, ref dtpNgayHetHan, ref txtSoSachDangMuon, ref txtTongTienNo);//Load data từ datagridview vào panel
            else
            {
                tdgBUS.ResetSTT();
                ClearPanelDG(tdgBUS, ref txtMaDG, ref txtHoTen, ref dtpNgaySinh, ref txtDiaChi, ref txtEmail, ref cbxLoaiDG, ref dtpNgayLapThe, ref dtpNgayHetHan, ref txtSoSachDangMuon, ref txtTongTienNo, ref cbxTimKiemDG);
            }
        }

        public bool Them(TheDocGiaDTO tdgDTO, QDLoaiDocGiaDTO ldgDTO, int thoiHanThe, List<string> listQD)
        {
            GetMaLoaiDGFromLoaiDG(tdgDTO, ldgDTO);
            //CheckDataPanelDGInValid(tdgDTO, ldgDTO);
            tdgDTO.Luotmuon = 0;
            tdgDTO.Ngayhethan = tdgDTO.Ngaylapthe.AddMonths(thoiHanThe);
            tdgDTO.Sosachdangmuon = 0;
            tdgDTO.Tongtienno = 0;
            tdgDTO.Luotmuon = 0;


            return tdgDAL.Them(tdgDTO);
        }

        public bool Xoa(TheDocGiaDTO tdgDTO)
        {
            return tdgDAL.Xoa(tdgDTO);
        }

        public bool Sua(TheDocGiaDTO tdgDTO, QDLoaiDocGiaDTO ldgDTO)
        {
            GetMaLoaiDGFromLoaiDG(tdgDTO, ldgDTO);
            return tdgDAL.Sua(tdgDTO);
        }

        public DataTable TimKiem(DataGridView dgv, string chuoiTimKiem, string loaiTimKiem)
        {

            dgv.DataSource = tdgDAL.LoadBangDocGia();
            DataTable data = new DataTable();
            foreach (DataGridViewColumn column in dgv.Columns)
            {
                data.Columns.Add(column.Name);
            }
            if (loaiTimKiem == "Mã ĐG")
                loaiTimKiem = "MADG";
            else if (loaiTimKiem == "Họ tên")
                loaiTimKiem = "HOTEN";
            else if (loaiTimKiem == "Ngày sinh")
                loaiTimKiem = "NGAYSINH";
            else if (loaiTimKiem == "Loại ĐG")
                loaiTimKiem = "MALOAIDG";

            foreach (DataGridViewRow row in dgv.Rows)
            {
                if (row.Cells[loaiTimKiem].Value.ToString().Contains(chuoiTimKiem))
                {
                    DataRow dataRow = data.NewRow();
                    foreach (DataGridViewCell cell in row.Cells)
                    {
                        dataRow[cell.ColumnIndex] = cell.Value;
                    }
                    data.Rows.Add(dataRow);
                }

            }
            return data;
        }

        public bool ResetSTT()
        {
            return tdgDAL.ResetSTT();
        }

        public void MapDataDGFromGUI(ref TheDocGiaDTO tdgDTO, TextBoxX txtMaDG, TextBoxX txtHoTen, DateTimeInput dtpNgaySinh, TextBoxX txtDiaChi, TextBoxX txtEmail)
        {
            tdgDTO.Madg = txtMaDG.Text;
            tdgDTO.Hoten = txtHoTen.Text;
            tdgDTO.Ngaysinh = dtpNgaySinh.Value;
            tdgDTO.Diachi = txtDiaChi.Text;
            tdgDTO.Email = txtEmail.Text;
            tdgDTO.Ngaylapthe = DateTime.Now;
        }



        public void GetMaLoaiDGFromLoaiDG(TheDocGiaDTO tdgDTO, QDLoaiDocGiaDTO ldgDTO)
        {
            Dictionary<string, string> temp = new Dictionary<string, string>();
            DataTable data = ldgDAL.LoadBangLoaiDG();
            for (int i = 0; i < data.Rows.Count; ++i)
            {
                // key: Ten loai doc gia - value: Ma loai doc gia
                temp.Add(data.Rows[i][1].ToString(), data.Rows[i][0].ToString());
            }
            if (temp.ContainsKey(ldgDTO.Loaidg))
            {
                tdgDTO.Maloaidg = temp[ldgDTO.Loaidg];
            }
        }

        public void GetDataWhenClickDGVDG(DataGridViewRow row, ref TextBoxX txtMaDG, ref TextBoxX txtHoTen, ref DateTimeInput dtpNgaySinh, ref TextBoxX txtDiaChi, ref TextBoxX txtEmail, ref ComboBoxEx cbxLoaiDG, ref DateTimeInput dtpNgayLapThe, ref DateTimeInput dtpNgayHetHan, ref TextBoxX txtSoSachDangMuon, ref TextBoxX txtTongTienNo)
        {
            txtMaDG.Text = row.Cells["MADG"].Value.ToString();
            txtHoTen.Text = row.Cells["HOTEN"].Value.ToString();
            dtpNgaySinh.Value = System.DateTime.Parse(row.Cells["NGAYSINH"].Value.ToString());
            txtDiaChi.Text = row.Cells["DIACHI"].Value.ToString();
            txtEmail.Text = row.Cells["EMAIL"].Value.ToString();
            cbxLoaiDG.Text = row.Cells["TENLOAIDG"].Value.ToString();
            dtpNgayLapThe.Value = System.DateTime.Parse(row.Cells["NGAYLAPTHE"].Value.ToString());
            dtpNgayHetHan.Value = System.DateTime.Parse(row.Cells["NGAYHETHAN"].Value.ToString());
            txtSoSachDangMuon.Text = row.Cells["SOSACHDANGMUON"].Value.ToString();
            txtTongTienNo.Text = row.Cells["TONGTIENNO"].Value.ToString();
        }

        public string GetNewSTT()
        {
            return tdgDAL.GetNewSTT();
        }

        public bool IsTrungKhopKhoaChinh(string id, DataGridView dgv)
        {
            if (dgv.RowCount == 0)
                return false;
            for (int i = 0; i < dgv.RowCount; ++i)
            {
                if (id == dgv.Rows[i].Cells["MADG"].Value.ToString())
                {

                    MessageBox.Show("Trùng mã độc giả", "", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
                    return true;
                }
            }
            return false;
        }

        public bool CheckDataPanelDGInValid(TheDocGiaDTO tdgDTO, QDLoaiDocGiaDTO ldgDTO)
        {

            //if (tdgDTO.Ngaysinh = null)
            //    return true;
            if (tdgDTO.Ngaysinh.Year == 1 || tdgDTO.Ngaysinh > DateTime.Today)
            {
                MessageBox.Show("Ngày sinh không hợp lệ", "", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
                return false;
            }
            if (ldgDTO.Loaidg == "")
            {
                MessageBox.Show("Chưa nhập loại độc giả", "", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
                return false;
            }
            return true;

        }

        public bool CheckQuyDinhDG(TheDocGiaDTO tdgDTO, List<string> listQD)
        {
            if (listQD[0] == "" || listQD[1] == "" || listQD[2] == "")// TuoiToiThieu - TuoiToiDa - ThoiHanThe
            {
                MessageBox.Show("Cần bổ sung quy định trước", "", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
                return false;
            }
            int tuoiDG = DateTime.Today.Year - tdgDTO.Ngaysinh.Year;
            if (tuoiDG < int.Parse(listQD[0].ToString()) || tuoiDG > int.Parse(listQD[1].ToString()))
            {
                MessageBox.Show("Tuổi độc giả không đạt quy định");
                return false;
            }
            return true;
        }

        public void ClearPanelDG(TheDocGiaBUS tdgBUS, ref TextBoxX txtMaDG, ref TextBoxX txtHoTen, ref DateTimeInput dtpNgaySinh, ref TextBoxX txtDiaChi, ref TextBoxX txtEmail, ref ComboBoxEx cbxLoaiDG, ref DateTimeInput dtpNgayLapThe, ref DateTimeInput dtpNgayHetHan, ref TextBoxX txtSoSachDangMuon, ref TextBoxX txtTongTienNo, ref ComboBoxEx cbxTimKiemDG)
        {
            txtMaDG.Text =  tdgBUS.GetNewSTT();
            txtHoTen.Text = null;
            DateTime date = new DateTime();
            dtpNgaySinh.Value = date; //DevComponents.Editors.DateTimeAdv.DateTimeInput.DateTimeDefaults;
            txtDiaChi.Text = null;
            txtEmail.Text = null;
            try
            {
                cbxLoaiDG.Text = cbxLoaiDG.Items[0].ToString();
            }
            catch
            { }

            dtpNgayLapThe.Value = date; //DevComponents.Editors.DateTimeAdv.DateTimeInput.DateTimeDefaults;
            dtpNgayHetHan.Value = date; //DevComponents.Editors.DateTimeAdv.DateTimeInput.DateTimeDefaults;
            txtSoSachDangMuon.Text = "0";
            txtTongTienNo.Text = "0";
            cbxTimKiemDG.Text = cbxTimKiemDG.Items[0].ToString();
        }

        public bool UpdateSoSachMuon(TheDocGiaDTO TheDG, int SoSachMuon)
        {
            return tdgDAL.UpdateSachDangMuon(TheDG, SoSachMuon);
        }

        public DataTable SelectByKeyWord(string sKeyWord)
        {
            return tdgDAL.SelectByKeyword(sKeyWord);
        }

        public bool UpdateSoSachMuon_XoaPM(TheDocGiaDTO TheDG, int SoSachMuon)
        {
            return tdgDAL.UpdateSachDangMuon_XoaPM(TheDG, SoSachMuon);
        }
    }
}




