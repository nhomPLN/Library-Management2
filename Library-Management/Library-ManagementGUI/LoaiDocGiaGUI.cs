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
    public class LoaiDocGiaGUI
    {
        private static LoaiDocGiaGUI instance;
        public static LoaiDocGiaGUI Instance
        {
            get
            {
                if (instance == null)
                    instance = new LoaiDocGiaGUI();
                return instance;
            }
        }
        public LoaiDocGiaGUI()
        {

        }

        public void Them(ref DataGridViewX dgvLoaiDG, ref TextBoxX txtMaLoaiDGQDDG, ref TextBoxX txtTenLoaiDGQDDG, QDLoaiDocGiaBUS ldgBUS)
        {
            if (string.IsNullOrEmpty(txtMaLoaiDGQDDG.Text) == false || string.IsNullOrEmpty(txtTenLoaiDGQDDG.Text) == false)
            {
                QDLoaiDocGiaDTO ldgDTO = new QDLoaiDocGiaDTO();
                ldgBUS.MapDataLoaiDGFromGUILoaiDG(ref ldgDTO, txtMaLoaiDGQDDG, txtTenLoaiDGQDDG);
                if (ldgBUS.IsTrungKhopKhoaChinh(ldgDTO.Maloaidg, dgvLoaiDG))
                {
                    MessageBox.Show("Trùng khớp mã loại độc giả", "", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
                    return;
                }
                if (ldgBUS.Them(ldgDTO))
                {
                    MessageBox.Show("Thêm thành công");
                    ldgBUS.LoadPanelLoaiDG(ref dgvLoaiDG, ref txtMaLoaiDGQDDG, ref txtTenLoaiDGQDDG, ldgBUS);
                }

                else MessageBox.Show("Thêm không thành công", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else { MessageBox.Show("Dữ liệu không đầy đủ", "Asterrisk", MessageBoxButtons.OK, MessageBoxIcon.Asterisk); }
        }

        public void Xoa(ref DataGridViewX dgvLoaiDG, ref TextBoxX txtMaLoaiDGQDDG, ref TextBoxX txtTenLoaiDGQDDG, QDLoaiDocGiaBUS ldgBUS)
        {
            if (dgvLoaiDG.RowCount != 0)
            {
                QDLoaiDocGiaDTO ldgDTO = new QDLoaiDocGiaDTO();
                string chuoiLDG = "";
                foreach (DataGridViewRow row in dgvLoaiDG.SelectedRows)
                {
                    ldgDTO.Maloaidg = row.Cells["MALOAIDG"].Value.ToString();
                    ldgBUS.Xoa(ldgDTO, ref chuoiLDG);
                }
                if (chuoiLDG != "")
                {
                    MessageBox.Show("Loại độc giả có mã: " + chuoiLDG + " đang được sử dụng bởi độc giả nên không thể xóa", "", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
                    chuoiLDG = "";
                }
                ldgBUS.LoadPanelLoaiDG(ref dgvLoaiDG, ref txtMaLoaiDGQDDG, ref txtTenLoaiDGQDDG, ldgBUS);
            }
        }

        public void Sua(ref DataGridViewX dgvLoaiDG, ref TextBoxX txtMaLoaiDGQDDG, ref TextBoxX txtTenLoaiDGQDDG, QDLoaiDocGiaBUS ldgBUS)
        {
            if (string.IsNullOrEmpty(txtMaLoaiDGQDDG.Text) == false || string.IsNullOrEmpty(txtTenLoaiDGQDDG.Text) == false)
            {
                QDLoaiDocGiaDTO ldgDTO = new QDLoaiDocGiaDTO();
                ldgBUS.MapDataLoaiDGFromGUILoaiDG(ref ldgDTO, txtMaLoaiDGQDDG, txtTenLoaiDGQDDG);
                if (ldgBUS.IsTrungKhopKhoaChinh(ldgDTO.Maloaidg, dgvLoaiDG))
                {
                    MessageBox.Show("Trùng khớp mã loại độc giả", "", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
                    return;
                }
                if (ldgBUS.Sua(ldgDTO))
                {
                    MessageBox.Show("Cập nhật thành công");
                    ldgBUS.LoadPanelLoaiDG(ref dgvLoaiDG, ref txtMaLoaiDGQDDG, ref txtTenLoaiDGQDDG, ldgBUS);
                }

                else MessageBox.Show("Cập nhật không thành công", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else { MessageBox.Show("Dữ liệu không đầy đủ", "Asterrisk", MessageBoxButtons.OK, MessageBoxIcon.Asterisk); }
        }

    }
}
