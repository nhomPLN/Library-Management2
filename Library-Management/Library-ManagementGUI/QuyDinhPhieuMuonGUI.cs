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
    public class QuyDinhPhieuMuonGUI
    {
        private static QuyDinhPhieuMuonGUI instance;
        public static QuyDinhPhieuMuonGUI Instance
        {
            get
            {
                if (instance == null)
                    instance = new QuyDinhPhieuMuonGUI();
                return instance;
            }
        }
        public QuyDinhPhieuMuonGUI()
        {

        }

        public void Them(ref DataGridViewX dgvQDPM, ref TextBoxX txtMaQDPM, ref TextBoxX txtQDPMSoSachMax, ref TextBoxX txtQDPMSoNgayMuonMax, QuyDinhPhieuMuonBUS qdpmBUS)
        {
            QuyDinhPhieuMuonDTO qdpmDTO = new QuyDinhPhieuMuonDTO();

            if (!qdpmBUS.MapDataQDPMFromGUIQDPM(ref qdpmDTO, txtMaQDPM, txtQDPMSoSachMax, txtQDPMSoNgayMuonMax, qdpmBUS))
            {
                MessageBox.Show("Dữ liệu không hợp lệ", "", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
                return;
            }
            if (qdpmBUS.IsTrungKhopKhoaChinh(qdpmDTO.Maqd.ToString(), dgvQDPM))
            {
                MessageBox.Show("Trùng mã quy định phiếu mượn", "", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
                return;
            }
            if (dgvQDPM.RowCount != 0)
            {
                QuyDinhPhieuMuonDTO temp = new QuyDinhPhieuMuonDTO();
                qdpmBUS.UpdatePreviousDataRowQDPM(ref temp, dgvQDPM);
                qdpmBUS.Sua(temp);
                qdpmDTO.Ngayra = qdpmDTO.Ngayra.AddDays(1);
            }

            if (qdpmBUS.Them(qdpmDTO))
            {
                MessageBox.Show("Thêm thành công");
                qdpmBUS.LoadTabQDPM(ref dgvQDPM, ref txtMaQDPM, ref txtQDPMSoSachMax, ref txtQDPMSoNgayMuonMax, qdpmBUS);
            }
            else MessageBox.Show("Thêm không thành công", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);

        }

        public void Xoa(ref DataGridViewX dgvQDPM, ref TextBoxX txtMaQDPM, ref TextBoxX txtQDPMSoSachMax, ref TextBoxX txtQDPMSoNgayMuonMax, QuyDinhPhieuMuonBUS qdpmBUS)
        {
            if (dgvQDPM.RowCount != 0)
            {
                QuyDinhPhieuMuonDTO qdpmDTO = new QuyDinhPhieuMuonDTO();
                foreach (DataGridViewRow row in dgvQDPM.SelectedRows)
                {
                    qdpmDTO.Maqd = row.Cells["MAQD"].Value.ToString();
                    qdpmBUS.Xoa(qdpmDTO);
                }
                qdpmBUS.LoadTabQDPM(ref dgvQDPM, ref txtMaQDPM, ref txtQDPMSoSachMax, ref txtQDPMSoNgayMuonMax, qdpmBUS);
                if (dgvQDPM.RowCount == 0)
                    qdpmBUS.ResetSTT();
            }
        }

        public void Sua(ref DataGridViewX dgvQDPM, ref TextBoxX txtMaQDPM, ref TextBoxX txtQDPMSoSachMax, ref TextBoxX txtQDPMSoNgayMuonMax, QuyDinhPhieuMuonBUS qdpmBUS)
        {
            QuyDinhPhieuMuonDTO qdpmDTO = new QuyDinhPhieuMuonDTO();
            if (!qdpmBUS.MapDataQDPMFromGUIQDPM(ref qdpmDTO, txtMaQDPM, txtQDPMSoSachMax, txtQDPMSoNgayMuonMax, qdpmBUS))
            {
                MessageBox.Show("Dữ liệu không hợp lệ", "", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
                return;
            }
            if (qdpmBUS.Sua(qdpmDTO))
            {
                MessageBox.Show("Cập nhật thành công");
                qdpmBUS.LoadTabQDPM(ref dgvQDPM, ref txtMaQDPM, ref txtQDPMSoSachMax, ref txtQDPMSoNgayMuonMax, qdpmBUS);
            }
            else MessageBox.Show("Cập nhật không thành công", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }
    }
}
