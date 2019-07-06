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
    public class LoaiSachGUI
    {
        private static LoaiSachGUI instance;
        public static LoaiSachGUI Instance
        {
            get
            {
                if (instance == null)
                    instance = new LoaiSachGUI();
                return instance;
            }
        }
        public LoaiSachGUI()
        {

        }

        public void Them(ref DataGridViewX dgvLoaiSach, ref TextBoxX txtMaLoaiSachQDS, ref TextBoxX txtTenLoaiSachQDS, QDLoaiSachBUS lsBUS)
        {
            if (string.IsNullOrEmpty(txtMaLoaiSachQDS.Text) == false || string.IsNullOrEmpty(txtTenLoaiSachQDS.Text) == false)
            {
                QDLoaiSachDTO lsDTO = new QDLoaiSachDTO();
                lsBUS.MapDataLSFromGUILoaiSach(ref lsDTO, txtMaLoaiSachQDS, txtTenLoaiSachQDS);
                if (lsBUS.IsTrungKhopKhoaChinh(lsDTO.Matheloai, dgvLoaiSach))
                {
                    MessageBox.Show("Trùng khớp mã thể loại", "", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
                    return;
                }

                if (lsBUS.Them(lsDTO))
                {
                    MessageBox.Show("Thêm thành công");
                    lsBUS.LoadPanelLoaiSach(ref dgvLoaiSach, ref txtMaLoaiSachQDS, ref txtTenLoaiSachQDS, lsBUS);
                }

                else MessageBox.Show("Thêm không thành công", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else { MessageBox.Show("Dữ liệu không đầy đủ", "Asterrisk", MessageBoxButtons.OK, MessageBoxIcon.Asterisk); }
        }

        public void Xoa(ref DataGridViewX dgvLoaiSach, ref TextBoxX txtMaLoaiSachQDS, ref TextBoxX txtTenLoaiSachQDS, QDLoaiSachBUS lsBUS)
        {
            if (dgvLoaiSach.RowCount != 0)
            {
                QDLoaiSachDTO lsDTO = new QDLoaiSachDTO();
                string chuoiLS = "";
                foreach (DataGridViewRow row in dgvLoaiSach.SelectedRows)
                {
                    lsDTO.Matheloai = row.Cells["MATHELOAI"].Value.ToString();
                    lsBUS.Xoa(lsDTO, ref chuoiLS);
                }
                if (chuoiLS != "")
                {
                    MessageBox.Show("Thể loại sách có mã: " + chuoiLS + " đang được sử dụng cho sách nên không thể xóa", "", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
                    chuoiLS = "";
                }
                lsBUS.LoadPanelLoaiSach(ref dgvLoaiSach, ref txtMaLoaiSachQDS, ref txtTenLoaiSachQDS, lsBUS);
            }
        }

        public void Sua(ref DataGridViewX dgvLoaiSach, ref TextBoxX txtMaLoaiSachQDS, ref TextBoxX txtTenLoaiSachQDS, QDLoaiSachBUS lsBUS)
        {
            if (string.IsNullOrEmpty(txtMaLoaiSachQDS.Text) == false || string.IsNullOrEmpty(txtTenLoaiSachQDS.Text) == false)
            {
                QDLoaiSachDTO lsDTO = new QDLoaiSachDTO();
                lsBUS.MapDataLSFromGUILoaiSach(ref lsDTO, txtMaLoaiSachQDS, txtTenLoaiSachQDS);
                if (lsBUS.IsTrungKhopKhoaChinh(lsDTO.Matheloai, dgvLoaiSach))
                {
                    MessageBox.Show("Trùng mã quy định sách", "", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
                    return;
                }

                if (lsBUS.Sua(lsDTO))
                {
                    MessageBox.Show("Cập nhật thành công");
                    lsBUS.LoadPanelLoaiSach(ref dgvLoaiSach, ref txtMaLoaiSachQDS, ref txtTenLoaiSachQDS, lsBUS);
                }

                else MessageBox.Show("Cập nhật không thành công", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else { MessageBox.Show("Dữ liệu không đầy đủ", "Asterrisk", MessageBoxButtons.OK, MessageBoxIcon.Asterisk); }
        }
    }
}
