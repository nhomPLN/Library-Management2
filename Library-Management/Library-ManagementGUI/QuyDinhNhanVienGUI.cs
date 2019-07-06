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
    public class QuyDinhNhanVienGUI
    {
        private static QuyDinhNhanVienGUI instance;
        public static QuyDinhNhanVienGUI Instance
        {
            get
            {
                if (instance == null)
                    instance = new QuyDinhNhanVienGUI();
                return instance;
            }
        }
        public QuyDinhNhanVienGUI()
        {

        }

        public void Them(ref DataGridViewX dgvQDNV, ref TextBoxX txtMaQDNV, ref TextBoxX txtQDNVTuoiToiThieu, ref TextBoxX txtQDNVTuoiToiDa, QuyDinhNhanVienBUS qdnvBUS)
        {
            QuyDinhNhanVienDTO qdnvDTO = new QuyDinhNhanVienDTO();

            if (!qdnvBUS.MapDataQDNVFromGUI(ref qdnvDTO, txtMaQDNV, txtQDNVTuoiToiThieu, txtQDNVTuoiToiDa, qdnvBUS))
            {
                MessageBox.Show("Dữ liệu không hợp lệ", "", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
                return;
            }
            if (qdnvBUS.IsTrungKhopKhoaChinh(qdnvDTO.Maqd, dgvQDNV))
            {
                MessageBox.Show("Trùng mã quy định nhân viên", "", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
                return;
            }

            if (dgvQDNV.RowCount != 0)
            {
                QuyDinhNhanVienDTO temp = new QuyDinhNhanVienDTO();
                qdnvBUS.UpdatePreviousDataRowQDNV(ref temp, dgvQDNV);
                qdnvBUS.Sua(temp);
                qdnvDTO.Ngayra = qdnvDTO.Ngayra.AddDays(1);
            }

            if (qdnvBUS.Them(qdnvDTO))
            {
                MessageBox.Show("Thêm thành công");
                qdnvBUS.LoadPanelQDNV(ref dgvQDNV, ref txtMaQDNV, ref txtQDNVTuoiToiThieu, ref txtQDNVTuoiToiDa, qdnvBUS);
            }
            else MessageBox.Show("Thêm không thành công", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }

        public void Xoa(ref DataGridViewX dgvQDNV, ref TextBoxX txtMaQDNV, ref TextBoxX txtQDNVTuoiToiThieu, ref TextBoxX txtQDNVTuoiToiDa, QuyDinhNhanVienBUS qdnvBUS)
        {
            if (dgvQDNV.RowCount != 0)
            {
                QuyDinhNhanVienDTO qdnvDTO = new QuyDinhNhanVienDTO();
                foreach (DataGridViewRow row in dgvQDNV.SelectedRows)
                {
                    qdnvDTO.Maqd = row.Cells["MAQD"].Value.ToString();
                    qdnvBUS.Xoa(qdnvDTO);
                }
                qdnvBUS.LoadPanelQDNV(ref dgvQDNV, ref txtMaQDNV, ref txtQDNVTuoiToiThieu, ref txtQDNVTuoiToiDa, qdnvBUS); // Bao gom luon ClearPanel neu row = 0
                //Sau khi delete
                if (dgvQDNV.RowCount == 0)
                {
                    qdnvBUS.ResetSTT();
                }
            }
        }

        public void Sua(ref DataGridViewX dgvQDNV, ref TextBoxX txtMaQDNV, ref TextBoxX txtQDNVTuoiToiThieu, ref TextBoxX txtQDNVTuoiToiDa, QuyDinhNhanVienBUS qdnvBUS)
        {
            QuyDinhNhanVienDTO qdnvDTO = new QuyDinhNhanVienDTO();
            if (!qdnvBUS.MapDataQDNVFromGUI(ref qdnvDTO, txtMaQDNV, txtQDNVTuoiToiThieu, txtQDNVTuoiToiDa, qdnvBUS))
            {
                MessageBox.Show("Dữ liệu không hợp lệ", "", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
                return;
            }
            if (qdnvBUS.Sua(qdnvDTO))
            {
                MessageBox.Show("Cập nhật thành công");
                qdnvBUS.LoadPanelQDNV(ref dgvQDNV, ref txtMaQDNV, ref txtQDNVTuoiToiThieu, ref txtQDNVTuoiToiDa, qdnvBUS);
            }
            else MessageBox.Show("Cập nhật không thành công", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }
    }
}
