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
    public class QuyDinhSachBUS
    {
        private QuyDinhSachDAL qdsDAL;
        public QuyDinhSachBUS()
        {
            qdsDAL = new QuyDinhSachDAL();
        }

        public DataTable LoadBangQDS()
        {
            return qdsDAL.LoadBangQDS();
        }

        public void LoadDgvQDS(ref DataGridViewX dgvQDS, QuyDinhSachBUS qdsBUS)
        {
            dgvQDS.DataSource = qdsBUS.LoadBangQDS();
        }

        public void LoadPanelQDS(ref DataGridViewX dgvQDS, ref TextBoxX txtMaQDS, ref TextBoxX txtQDThoiHanSach, QuyDinhSachBUS qdsBUS)
        {
            qdsBUS.LoadBangQDS();
            if (dgvQDS.RowCount != 0)
                GetDataWhenClickDGVQDS(dgvQDS.Rows[0], ref txtMaQDS, ref txtMaQDS);
            else ClearPanelQDS(ref txtMaQDS, ref txtQDThoiHanSach, qdsBUS);
        }

        public bool Them(QuyDinhSachDTO qdsDTO)
        {
            return qdsDAL.Them(qdsDTO);
        }

        public bool Xoa(QuyDinhSachDTO qdsDTO)
        {
            return qdsDAL.Xoa(qdsDTO);
        }

        public bool Sua(QuyDinhSachDTO qdsDTO)
        {
            return qdsDAL.Sua(qdsDTO);
        }

        public bool ResetSTT()
        {
            return qdsDAL.ResetSTT();
        }

        public int GetNewSTT()
        {
            return qdsDAL.GetNewSTT();
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

        public bool MapDataQDSFromGUI(ref QuyDinhSachDTO qdsDTO, TextBoxX txtMaQDS, TextBoxX txtQDThoiHanSach, QuyDinhSachBUS qdsBUS)
        {
            qdsDTO.Maqd = txtMaQDS.Text;
            if (qdsBUS.IsOnlyNumber(txtQDThoiHanSach.Text))
                qdsDTO.Thoihansach = int.Parse(txtQDThoiHanSach.Text);
            else return false;
            qdsDTO.Ngayra = DateTime.Today;
            qdsDTO.Ngayketthuc = DateTime.MaxValue;
            return true;
        }

        public void GetDataWhenClickDGVQDS(DataGridViewRow row, ref TextBoxX txtMaQDS, ref TextBoxX txtQDThoiHanSach)
        {
            txtMaQDS.Text = row.Cells["MAQD"].Value.ToString();
            txtQDThoiHanSach.Text = row.Cells["THOIHANSACH"].Value.ToString();
        }

        public void ClearPanelQDS(ref TextBoxX txtMaQDS, ref TextBoxX txtQDThoiHanSach, QuyDinhSachBUS qdsBUS)
        {
            txtMaQDS.Text = "QDS" + qdsBUS.GetNewSTT().ToString();
            txtQDThoiHanSach.Text = "0";
        }

        public void UpdatePreviousDataRowQDS(ref QuyDinhSachDTO qdsDTO, DataGridViewX dgvQDS)
        {
            int count = dgvQDS.RowCount - 1;
            qdsDTO.Maqd = dgvQDS.Rows[count].Cells["MAQD"].Value.ToString();
            qdsDTO.Thoihansach = int.Parse(dgvQDS.Rows[count].Cells["THOIHANSACH"].Value.ToString());
            qdsDTO.Ngayra = Convert.ToDateTime(dgvQDS.Rows[count].Cells["NGAYRA"].Value.ToString());
            if (DateTime.Today < qdsDTO.Ngayra)
                qdsDTO.Ngayketthuc = qdsDTO.Ngayra;
            else
            {
                qdsDTO.Ngayketthuc = DateTime.Today;
            }

            qdsDTO.Maqd = dgvQDS.Rows[count].Cells["MAQD"].Value.ToString();
        }

    }
}
