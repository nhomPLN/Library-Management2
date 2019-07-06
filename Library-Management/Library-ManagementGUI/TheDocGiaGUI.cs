using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using DevComponents.DotNetBar.Controls;
using DevComponents.Editors.DateTimeAdv;
using BUS;
using DTO;

namespace Library_ManagementGUI
{
    public class TheDocGiaGUI
    {
        private static TheDocGiaGUI instance;
        public static TheDocGiaGUI Instance
        {
            get
            {
                if (instance == null)
                    instance = new TheDocGiaGUI();
                return instance;
            }
        }
        public TheDocGiaGUI()
        {

        }

        public void Them(ref DataGridViewX dgvDG, ref TextBoxX txtMaDG, ref TextBoxX txtHoTen, ref DateTimeInput dtpNgaySinh, ref TextBoxX txtDiaChi, ref TextBoxX txtEmail, ref ComboBoxEx cbxLoaiDG, ref DateTimeInput dtpNgayLapThe, ref DateTimeInput dtpNgayHetHan, ref TextBoxX txtSoSachDangMuon, ref TextBoxX txtTongTienNo, ref TextBoxX txtTuoiToiThieu, ref TextBoxX txtTuoiToiDa, ref ComboBoxEx cbxTimKiemDG, ref TextBoxX txtThoiHanThe, QDLoaiDocGiaBUS ldgBUS, TheDocGiaBUS tdgBUS, QuyDinhDocGiaBUS qddgBUS)
        {
            TheDocGiaDTO tdgDTO = new TheDocGiaDTO();
            QDLoaiDocGiaDTO ldgDTO = new QDLoaiDocGiaDTO();

            tdgBUS.MapDataDGFromGUI(ref tdgDTO, txtMaDG, txtHoTen, dtpNgaySinh, txtDiaChi, txtEmail);
            ldgBUS.MapDataLDGFromGUIDG(ref ldgDTO, cbxLoaiDG);
            //this.MapDataDGFromGUI(tdgDTO);
            //this.MapDataLDGFromGUIDG(ldgDTO);
            //if (IsDataPanelDGInValid(tdgDTO, ldgDTO))
            //    MessageBox.Show("Kiểm tra lại dữ liệu", "", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
            List<string> listQuyDinh = new List<string>() { txtTuoiToiThieu.Text, txtTuoiToiDa.Text, txtThoiHanThe.Text };

            if (tdgBUS.IsTrungKhopKhoaChinh(tdgDTO.Madg, dgvDG))
                return;


            if (tdgBUS.CheckDataPanelDGInValid(tdgDTO, ldgDTO) == false)
                return;

            if (tdgBUS.CheckQuyDinhDG(tdgDTO, listQuyDinh) == false)
                return;


            if (tdgBUS.Them(tdgDTO, ldgDTO, int.Parse(txtThoiHanThe.Text), listQuyDinh))
            {
                MessageBox.Show("Thêm thành công");
                tdgBUS.LoadTabQLDG(ref dgvDG, ref txtMaDG, ref txtHoTen, ref dtpNgaySinh, ref txtDiaChi, ref txtEmail, ref cbxLoaiDG, ref dtpNgayLapThe, ref dtpNgayHetHan, ref txtSoSachDangMuon, ref txtTongTienNo, ref txtTuoiToiThieu, ref txtTuoiToiDa, ref cbxTimKiemDG, ref txtThoiHanThe, ldgBUS, tdgBUS, qddgBUS);
            }
            else
            {
                MessageBox.Show("Thêm không thành công", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        public void Xoa(ref DataGridViewX dgvDG, ref TextBoxX txtMaDG, ref TextBoxX txtHoTen, ref DateTimeInput dtpNgaySinh, ref TextBoxX txtDiaChi, ref TextBoxX txtEmail, ref ComboBoxEx cbxLoaiDG, ref DateTimeInput dtpNgayLapThe, ref DateTimeInput dtpNgayHetHan, ref TextBoxX txtSoSachDangMuon, ref TextBoxX txtTongTienNo, ref ComboBoxEx cbxTimKiemDG, TheDocGiaBUS tdgBUS)
        {
            if (dgvDG.RowCount != 0)
            {
                TheDocGiaDTO tdgDTO = new TheDocGiaDTO();
                foreach (DataGridViewRow row in dgvDG.SelectedRows)
                {
                    tdgDTO.Madg = row.Cells["MADG"].Value.ToString();
                    tdgBUS.Xoa(tdgDTO);
                }
                tdgBUS.LoadDgvDG(ref dgvDG, tdgBUS);
                if (dgvDG.RowCount != 0)
                    tdgBUS.GetDataWhenClickDGVDG(dgvDG.Rows[0], ref txtMaDG, ref txtHoTen, ref dtpNgaySinh, ref txtDiaChi, ref txtEmail, ref cbxLoaiDG, ref dtpNgayLapThe, ref dtpNgayHetHan, ref txtSoSachDangMuon, ref txtTongTienNo);
            }
            //Sau khi delete
            if (dgvDG.RowCount == 0)
            {
                tdgBUS.ResetSTT();
                tdgBUS.ClearPanelDG(tdgBUS, ref txtMaDG, ref txtHoTen, ref dtpNgaySinh, ref txtDiaChi, ref txtEmail, ref cbxLoaiDG, ref dtpNgayLapThe, ref dtpNgayHetHan, ref txtSoSachDangMuon, ref txtTongTienNo, ref cbxTimKiemDG);
            }
        }

        public void Sua(ref DataGridViewX dgvDG, ref TextBoxX txtMaDG, ref TextBoxX txtHoTen, ref DateTimeInput dtpNgaySinh, ref TextBoxX txtDiaChi, ref TextBoxX txtEmail, ref ComboBoxEx cbxLoaiDG, ref DateTimeInput dtpNgayLapThe, ref DateTimeInput dtpNgayHetHan, ref TextBoxX txtSoSachDangMuon, ref TextBoxX txtTongTienNo, ref TextBoxX txtTuoiToiThieu, ref TextBoxX txtTuoiToiDa, ref ComboBoxEx cbxTimKiemDG, ref TextBoxX txtThoiHanThe, QDLoaiDocGiaBUS ldgBUS, TheDocGiaBUS tdgBUS, QuyDinhDocGiaBUS qddgBUS)
        {
            TheDocGiaDTO tdgDTO = new TheDocGiaDTO();
            QDLoaiDocGiaDTO ldgDTO = new QDLoaiDocGiaDTO();

            tdgBUS.MapDataDGFromGUI(ref tdgDTO, txtMaDG, txtHoTen, dtpNgaySinh, txtDiaChi, txtEmail);
            ldgBUS.MapDataLDGFromGUIDG(ref ldgDTO, cbxLoaiDG);
            //MapDataDGFromGUI(tdgDTO);
            //MapDataLDGFromGUIDG(ldgDTO);
            if (tdgBUS.Sua(tdgDTO, ldgDTO) == true)
            {
                MessageBox.Show("Cập nhật thành công");
                tdgBUS.LoadTabQLDG(ref dgvDG, ref txtMaDG, ref txtHoTen, ref dtpNgaySinh, ref txtDiaChi, ref txtEmail, ref cbxLoaiDG, ref dtpNgayLapThe, ref dtpNgayHetHan, ref txtSoSachDangMuon, ref txtTongTienNo, ref txtTuoiToiThieu, ref txtTuoiToiDa, ref cbxTimKiemDG, ref txtThoiHanThe, ldgBUS, tdgBUS, qddgBUS);
            }
            else
            {
                MessageBox.Show("Cập nhật không thành công", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }




    }
}
