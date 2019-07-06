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
    public class QuyDinhSachGUI
    {
        private static QuyDinhSachGUI instance;
        public static QuyDinhSachGUI Instance
        {
            get
            {
                if (instance == null)
                    instance = new QuyDinhSachGUI();
                return instance;
            }
        }
        public QuyDinhSachGUI()
        {

        }

        public void Them(ref DataGridViewX dgvQDS, ref TextBoxX txtMaQDS, ref TextBoxX txtQDThoiHanSach, QuyDinhSachBUS qdsBUS)
        {
            QuyDinhSachDTO qdsDTO = new QuyDinhSachDTO();

            if (!qdsBUS.MapDataQDSFromGUI(ref qdsDTO, txtMaQDS, txtQDThoiHanSach, qdsBUS))
            {
                MessageBox.Show("Dữ liệu không hợp lệ", "", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
                return;
            }
            if (qdsBUS.IsTrungKhopKhoaChinh(qdsDTO.Maqd, dgvQDS))
            {
                MessageBox.Show("Trùng mã quy định sách", "", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
                return;
            }
            if (dgvQDS.RowCount != 0)
            {
                QuyDinhSachDTO temp = new QuyDinhSachDTO();
                qdsBUS.UpdatePreviousDataRowQDS(ref temp, dgvQDS);
                qdsBUS.Sua(temp);
                qdsDTO.Ngayra = qdsDTO.Ngayra.AddDays(1);
            }

            if (qdsBUS.Them(qdsDTO))
            {
                MessageBox.Show("Thêm thành công");
                qdsBUS.LoadPanelQDS(ref dgvQDS, ref txtMaQDS, ref txtQDThoiHanSach, qdsBUS);
            }
            else MessageBox.Show("Thêm không thành công", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }

        public void Xoa(ref DataGridViewX dgvQDS, ref TextBoxX txtMaQDS, ref TextBoxX txtQDThoiHanSach, QuyDinhSachBUS qdsBUS)
        {
            if (dgvQDS.RowCount != 0)
            {
                QuyDinhSachDTO qdsDTO = new QuyDinhSachDTO();
                foreach (DataGridViewRow row in dgvQDS.Rows)
                {
                    qdsDTO.Maqd = row.Cells["MAQD"].Value.ToString();
                    qdsBUS.Xoa(qdsDTO);
                }
                qdsBUS.LoadPanelQDS(ref dgvQDS, ref txtMaQDS, ref txtQDThoiHanSach, qdsBUS); // Bao gom luon ClearPanel neu row = 0
                if (dgvQDS.RowCount == 0)
                {
                    qdsBUS.ResetSTT();
                }
            }
        }

        public void Sua(ref DataGridViewX dgvQDS, ref TextBoxX txtMaQDS, ref TextBoxX txtQDThoiHanSach, QuyDinhSachBUS qdsBUS)
        {
            QuyDinhSachDTO qdsDTO = new QuyDinhSachDTO();
            if (!qdsBUS.MapDataQDSFromGUI(ref qdsDTO, txtMaQDS, txtQDThoiHanSach, qdsBUS))
            {
                MessageBox.Show("Dữ liệu không hợp lệ", "", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
                return;
            }
            if (qdsBUS.Sua(qdsDTO))
            {
                qdsBUS.LoadBangQDS();
                MessageBox.Show("Cập nhật thành công");
            }
            else
            {
                MessageBox.Show("Cập nhật không thành công", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
