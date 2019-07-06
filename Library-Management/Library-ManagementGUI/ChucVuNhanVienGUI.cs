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
    public class ChucVuNhanVienGUI
    {
        private static ChucVuNhanVienGUI instance;
        public static ChucVuNhanVienGUI Instance
        {
            get
            {
                if (instance != null)
                    instance = new ChucVuNhanVienGUI();
                return instance;
            }
        }
        public ChucVuNhanVienGUI()
        {

        }

        public void Them(ref DataGridViewX dgvChucVu, ref TextBoxX txtMaChucVuQDNV, ref TextBoxX txtTenChucVuQDNV, QDChucVuNhanVienBUS cvnvBUS)
        {
            if (string.IsNullOrEmpty(txtMaChucVuQDNV.Text) == false || string.IsNullOrEmpty(txtTenChucVuQDNV.Text) == false)
            {
                QDChucVuNhanVienDTO cvnvDTO = new QDChucVuNhanVienDTO();
                cvnvBUS.MapDataCVNVFromGUICVNV(ref cvnvDTO, txtMaChucVuQDNV, txtTenChucVuQDNV);
                if (cvnvBUS.IsTrungKhopKhoaChinh(cvnvDTO.Macv, dgvChucVu))
                {
                    MessageBox.Show("Trùng khớp mã chức vụ", "", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
                    return;
                }

                if (cvnvBUS.Them(cvnvDTO))
                {
                    MessageBox.Show("Thêm thành công");
                    cvnvBUS.LoadPanelCVNV(ref dgvChucVu, ref txtMaChucVuQDNV, ref txtTenChucVuQDNV, cvnvBUS);
                }

                else MessageBox.Show("Thêm không thành công", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else { MessageBox.Show("Dữ liệu không đầy đủ", "Asterrisk", MessageBoxButtons.OK, MessageBoxIcon.Asterisk); }
        }

        public void Xoa(ref DataGridViewX dgvChucVu, ref TextBoxX txtMaChucVuQDNV, ref TextBoxX txtTenChucVuQDNV, QDChucVuNhanVienBUS cvnvBUS)
        {
            if (dgvChucVu.RowCount != 0)
            {
                QDChucVuNhanVienDTO cvnvDTO = new QDChucVuNhanVienDTO();
                string chuoiCVNV = "";
                foreach (DataGridViewRow row in dgvChucVu.SelectedRows)
                {
                    cvnvDTO.Macv = row.Cells["MACHUCVU"].Value.ToString();
                    cvnvBUS.Xoa(cvnvDTO, ref chuoiCVNV);
                }
                if (chuoiCVNV != "")
                {
                    MessageBox.Show("Chức vụ có mã: " + chuoiCVNV + " đang được sử dụng bởi nhân viên nên không thể xóa", "", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
                    chuoiCVNV = "";
                }
                cvnvBUS.LoadPanelCVNV(ref dgvChucVu, ref txtMaChucVuQDNV, ref txtTenChucVuQDNV, cvnvBUS);
            }
        }

        public void Sua(ref DataGridViewX dgvChucVu, ref TextBoxX txtMaChucVuQDNV, ref TextBoxX txtTenChucVuQDNV, QDChucVuNhanVienBUS cvnvBUS)
        {
            if (string.IsNullOrEmpty(txtMaChucVuQDNV.Text) == false || string.IsNullOrEmpty(txtTenChucVuQDNV.Text) == false)
            {
                QDChucVuNhanVienDTO cvnvDTO = new QDChucVuNhanVienDTO();
                cvnvBUS.MapDataCVNVFromGUICVNV(ref cvnvDTO, txtMaChucVuQDNV, txtTenChucVuQDNV);
                if (cvnvBUS.IsTrungKhopKhoaChinh(cvnvDTO.Macv, dgvChucVu))
                {
                    MessageBox.Show("Trùng khớp mã chức vụ", "", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
                    return;
                }

                if (cvnvBUS.Sua(cvnvDTO))
                {
                    MessageBox.Show("Cập nhật thành công");
                    cvnvBUS.LoadPanelCVNV(ref dgvChucVu, ref txtMaChucVuQDNV, ref txtTenChucVuQDNV, cvnvBUS);
                }

                else MessageBox.Show("Cập nhật không thành công", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else { MessageBox.Show("Dữ liệu không đầy đủ", "Asterrisk", MessageBoxButtons.OK, MessageBoxIcon.Asterisk); }
        }
    }
}
