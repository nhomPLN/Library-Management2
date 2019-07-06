using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using DAL;
using DevComponents.DotNetBar.Controls;
using DTO;
namespace BUS
{
    public class QuyDinhPhieuTraBUS
    {
        private QuyDinhPhieuTraDAL qdptDAL;
        public QuyDinhPhieuTraBUS()
        {
            qdptDAL = new QuyDinhPhieuTraDAL();
        }

        public DataTable LoadBangQDPT()
        {
            return qdptDAL.LoadBangQDPT();
        }

        public void LoadDgvQDPT(ref DataGridViewX dgvQDPT, QuyDinhPhieuTraBUS qdptBUS)
        {
            dgvQDPT.DataSource = qdptBUS.LoadBangQDPT();
        }

        public void LoadTabQDPT(ref DataGridViewX dgvQDPT, ref TextBoxX txtMaQDPT, ref TextBoxX txtQDPTTienPhat, QuyDinhPhieuTraBUS qdptBUS)
        {
            LoadDgvQDPT(ref dgvQDPT, qdptBUS);
            if (dgvQDPT.RowCount != 0)
                GetDataWhenClickDGVQDPT(dgvQDPT.Rows[0], ref txtMaQDPT, ref txtQDPTTienPhat);
            else ClearPanelQDPT(ref txtMaQDPT, ref txtQDPTTienPhat, qdptBUS);
        }


        public bool Them(QuyDinhPhieuTraDTO qdptDTO)
        {
            return qdptDAL.Them(qdptDTO);
        }

        public bool Xoa(QuyDinhPhieuTraDTO qdptDTO)
        {
            return qdptDAL.Xoa(qdptDTO);
        }

        public bool Sua(QuyDinhPhieuTraDTO qdptDTO)
        {
            return qdptDAL.Sua(qdptDTO);
        }

        public int GetNewSTT()
        {
            return qdptDAL.GetNewSTT();
        }

        public bool ResetSTT()
        {
            return qdptDAL.ResetSTT();
        }

        public bool IsOnlyNumber(string temp)
        {
            return DataProvider.Instance.IsOnlyNumber(temp);
        }

        public bool IsTrungKhopKhoaChinh(string id, DataGridView dgv)
        {
            if (dgv.RowCount == 0)
                return false;
            for (int i = 0; i < dgv.RowCount; ++i)
            {
                if (id == dgv.Rows[i].Cells["MAQD"].Value.ToString())
                    return true;
            }
            return false;
        }

        public bool MapDataQDPTFromGUIQDPT(ref QuyDinhPhieuTraDTO qdptDTO, TextBoxX txtMaQDPT, TextBoxX txtQDPTTienPhat, QuyDinhPhieuTraBUS qdptBUS)
        {
            qdptDTO.Maqd = txtMaQDPT.Text;
            if (qdptBUS.IsOnlyNumber(txtQDPTTienPhat.Text))
                qdptDTO.Tienphat = int.Parse(txtQDPTTienPhat.Text);
            else return false;
            qdptDTO.Ngayra = DateTime.Today;
            qdptDTO.Ngayketthuc = DateTime.MaxValue;
            return true;
        }

        public void GetDataWhenClickDGVQDPT(DataGridViewRow row, ref TextBoxX txtMaQDPT, ref TextBoxX txtQDPTTienPhat)
        {
            txtMaQDPT.Text = row.Cells["MAQD"].Value.ToString();
            txtQDPTTienPhat.Text = row.Cells["TIENPHAT"].Value.ToString();
        }

        public void ClearPanelQDPT(ref TextBoxX txtMaQDPT, ref TextBoxX txtQDPTTienPhat, QuyDinhPhieuTraBUS qdptBUS)
        {
            txtMaQDPT.Text = "QDPT" + qdptBUS.GetNewSTT();
            txtQDPTTienPhat.Text = "0";
        }

        public void UpdatePreviousDataRowQDPT(ref QuyDinhPhieuTraDTO qdptDTO, DataGridViewX dgvQDPT)
        {
            int count = dgvQDPT.RowCount - 1;
            qdptDTO.Maqd = dgvQDPT.Rows[count].Cells["MAQD"].Value.ToString();
            qdptDTO.Tienphat = int.Parse(dgvQDPT.Rows[count].Cells["TIENPHAT"].Value.ToString());
            qdptDTO.Ngayra = DateTime.Today;
            if (DateTime.Today < qdptDTO.Ngayra)
                qdptDTO.Ngayketthuc = qdptDTO.Ngayra;
            else
            {
                qdptDTO.Ngayketthuc = DateTime.Today;
            }
        }

    }
}
