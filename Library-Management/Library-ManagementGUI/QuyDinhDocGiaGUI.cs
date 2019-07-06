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
    public class QuyDinhDocGiaGUI
    {
        private static QuyDinhDocGiaGUI instance;
        public static QuyDinhDocGiaGUI Instance
        {
            get
            {
                if (instance == null)
                    instance = new QuyDinhDocGiaGUI();
                return instance;
            }
        }
        public QuyDinhDocGiaGUI()
        {

        }

        public void Them(ref DataGridViewX dgvQDDG, ref TextBoxX txtMaQDDG, ref TextBoxX txtQDDGHanThe, ref TextBoxX txtQDDGTuoiToiThieu, ref TextBoxX txtQDDGTuoiToiDa, QuyDinhDocGiaBUS qddgBUS)
        {
            QuyDinhDocGiaDTO qddgDTO = new QuyDinhDocGiaDTO();

            if (!qddgBUS.MapDataQDDGFromGUI(ref qddgDTO, txtMaQDDG, txtQDDGHanThe, txtQDDGTuoiToiThieu, txtQDDGTuoiToiDa, qddgBUS))
            {
                MessageBox.Show("Dữ liệu không hợp lệ", "", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
                return;
            }

            if (qddgBUS.IsTrungKhopKhoaChinh(qddgDTO.Maqd, dgvQDDG))
            {
                MessageBox.Show("Trùng mã quy định độc giả", "", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
                return;
            }
            // Ngày kết thúc của quy định thứ n-1 cộng thêm 1 ngày là ngày ra của quy định thứ n
            if (dgvQDDG.RowCount != 0)
            {
                QuyDinhDocGiaDTO temp = new QuyDinhDocGiaDTO();
                qddgBUS.UpdatePreviousDataRowQDDG(ref temp, dgvQDDG);
                qddgBUS.Sua(temp);
                qddgDTO.Ngayra = qddgDTO.Ngayra.AddDays(1);
            }
            if (qddgBUS.Them(qddgDTO))
            {
                MessageBox.Show("Thêm thành công");
                qddgBUS.LoadPanelQDDG(ref dgvQDDG, ref txtMaQDDG, ref txtQDDGHanThe, ref txtQDDGTuoiToiThieu, ref txtQDDGTuoiToiDa, qddgBUS);
            }
            else MessageBox.Show("Thêm không thành công", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }

        public void Xoa(ref DataGridViewX dgvQDDG, ref TextBoxX txtMaQDDG, ref TextBoxX txtQDDGHanThe, ref TextBoxX txtQDDGTuoiToiThieu, ref TextBoxX txtQDDGTuoiToiDa, QuyDinhDocGiaBUS qddgBUS)
        {
            if (dgvQDDG.RowCount != 0)
            {
                QuyDinhDocGiaDTO qddgDTO = new QuyDinhDocGiaDTO();
                foreach (DataGridViewRow row in dgvQDDG.SelectedRows)
                {
                    qddgDTO.Maqd = row.Cells["MAQD"].Value.ToString();
                    qddgBUS.Xoa(qddgDTO);
                }
                qddgBUS.LoadPanelQDDG(ref dgvQDDG, ref txtMaQDDG, ref txtQDDGHanThe, ref txtQDDGTuoiToiThieu, ref txtQDDGTuoiToiDa, qddgBUS); // Bao gom luon ClearPanel neu row = 0
                //Sau khi delete
                if (dgvQDDG.RowCount == 0)
                {
                    qddgBUS.ResetSTT();
                }
            }
        }

        public void Sua(ref DataGridViewX dgvQDDG, ref TextBoxX txtMaQDDG, ref TextBoxX txtQDDGHanThe, ref TextBoxX txtQDDGTuoiToiThieu, ref TextBoxX txtQDDGTuoiToiDa, QuyDinhDocGiaBUS qddgBUS)
        {
            QuyDinhDocGiaDTO qddgDTO = new QuyDinhDocGiaDTO();
            if (!qddgBUS.MapDataQDDGFromGUI(ref qddgDTO, txtMaQDDG, txtQDDGHanThe, txtQDDGTuoiToiThieu, txtQDDGTuoiToiDa, qddgBUS))
            {
                MessageBox.Show("Dữ liệu không hợp lệ", "", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
                return;
            }
            if (qddgBUS.Sua(qddgDTO))
            {
                MessageBox.Show("Cập nhật thành công");
                qddgBUS.LoadPanelQDDG(ref dgvQDDG, ref txtMaQDDG, ref txtQDDGHanThe, ref txtQDDGTuoiToiThieu, ref txtQDDGTuoiToiDa, qddgBUS);
            }
            else MessageBox.Show("Cập nhật không thành công", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }

    }
}
