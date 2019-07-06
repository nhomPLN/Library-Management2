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
    public class QuyDinhPhieuTraGUI
    {
        private static QuyDinhPhieuTraGUI instance;
        public static QuyDinhPhieuTraGUI Instance
        {
            get
            {
                if (instance == null)
                    instance = new QuyDinhPhieuTraGUI();
                return instance;
            }
        }
        public QuyDinhPhieuTraGUI()
        {

        }

        public void Them(ref DataGridViewX dgvQDPT, ref TextBoxX txtMaQDPT, ref TextBoxX txtQDPTTienPhat, QuyDinhPhieuTraBUS qdptBUS)
        {
            QuyDinhPhieuTraDTO qdptDTO = new QuyDinhPhieuTraDTO();

            if (!qdptBUS.MapDataQDPTFromGUIQDPT(ref qdptDTO, txtMaQDPT, txtQDPTTienPhat, qdptBUS))
            {
                MessageBox.Show("Dữ liệu không hợp lệ", "", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
                return;
            }
            if (qdptBUS.IsTrungKhopKhoaChinh(qdptDTO.Maqd, dgvQDPT))
            {
                MessageBox.Show("Trùng mã quy định phiếu trả", "", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
                return;
            }
            if (dgvQDPT.RowCount != 0)
            {
                QuyDinhPhieuTraDTO temp = new QuyDinhPhieuTraDTO();
                qdptBUS.UpdatePreviousDataRowQDPT(ref temp, dgvQDPT);
                qdptBUS.Sua(temp);
                qdptDTO.Ngayra = qdptDTO.Ngayra.AddDays(1);
            }
            if (qdptBUS.Them(qdptDTO))
            {
                MessageBox.Show("Thêm thành công");
                qdptBUS.LoadTabQDPT(ref dgvQDPT, ref txtMaQDPT, ref txtQDPTTienPhat, qdptBUS);
            }
            else MessageBox.Show("Thêm không thành công", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }

        public void Xoa(ref DataGridViewX dgvQDPT, ref TextBoxX txtMaQDPT, ref TextBoxX txtQDPTTienPhat, QuyDinhPhieuTraBUS qdptBUS)
        {
            if (dgvQDPT.RowCount != 0)
            {
                QuyDinhPhieuTraDTO qdptDTO = new QuyDinhPhieuTraDTO();
                foreach (DataGridViewRow row in dgvQDPT.SelectedRows)
                {
                    qdptDTO.Maqd = row.Cells["MAQD"].Value.ToString();
                    qdptBUS.Xoa(qdptDTO);
                }
                qdptBUS.LoadTabQDPT(ref dgvQDPT, ref txtMaQDPT, ref txtQDPTTienPhat, qdptBUS);
                if (dgvQDPT.RowCount == 0)
                    qdptBUS.ResetSTT();
            }
        }

        public void Sua(ref DataGridViewX dgvQDPT, ref TextBoxX txtMaQDPT, ref TextBoxX txtQDPTTienPhat, QuyDinhPhieuTraBUS qdptBUS)
        {
            QuyDinhPhieuTraDTO qdptDTO = new QuyDinhPhieuTraDTO();
            if (!qdptBUS.MapDataQDPTFromGUIQDPT(ref qdptDTO, txtMaQDPT, txtQDPTTienPhat, qdptBUS))
            {
                MessageBox.Show("Dữ liệu không hợp lệ", "", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
                return;
            }
            if (qdptBUS.Sua(qdptDTO))
            {
                MessageBox.Show("Cập nhật thành công");
                qdptBUS.LoadTabQDPT(ref dgvQDPT, ref txtMaQDPT, ref txtQDPTTienPhat, qdptBUS);
            }
            else MessageBox.Show("Cập nhật không thành công", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);

        }
    }
}
