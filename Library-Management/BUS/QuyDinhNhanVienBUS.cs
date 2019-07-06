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
    public class QuyDinhNhanVienBUS
    {
        private QuyDinhNhanVienDAL qdnvDAL;
        public QuyDinhNhanVienBUS()
        {
            qdnvDAL = new QuyDinhNhanVienDAL();
        }

        public DataTable LoadBangQDNV()
        {
            return qdnvDAL.LoadBangQDNV();
        }

        public void LoadDgvQDNV(ref DataGridViewX dgvQDNV, QuyDinhNhanVienBUS qdnvBUS)
        {
            try
            {
                dgvQDNV.DataSource = LoadBangQDNV();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
        }

        public void LoadPanelQDNV(ref DataGridViewX dgvQDNV, ref TextBoxX txtMaQDNV, ref TextBoxX txtQDNVTuoiToiThieu, ref TextBoxX txtQDNVTuoiToiDa, QuyDinhNhanVienBUS qdnvBUS)
        {
            LoadDgvQDNV(ref dgvQDNV, qdnvBUS);
            if (dgvQDNV.RowCount != 0)
                GetDataWhenClickDGVQDNV(dgvQDNV.Rows[0], ref txtMaQDNV, ref txtQDNVTuoiToiThieu, ref txtQDNVTuoiToiDa);
            else CLearPanelQDNV(ref txtMaQDNV, ref txtQDNVTuoiToiThieu, ref txtQDNVTuoiToiDa, qdnvBUS);
        }

        public bool Them(QuyDinhNhanVienDTO qdnvDTO)
        {
            return qdnvDAL.Them(qdnvDTO);
        }

        public bool Xoa(QuyDinhNhanVienDTO qdnvDTO)
        {
            return qdnvDAL.Xoa(qdnvDTO);
        }

        public bool Sua(QuyDinhNhanVienDTO qdnvDTO)
        {
            return qdnvDAL.Sua(qdnvDTO);
        }

        public int GetNewSTT()
        {
            return qdnvDAL.GetNewSTT();
        }

        public bool ResetSTT()
        {
            return qdnvDAL.ResetSTT();
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

        public bool MapDataQDNVFromGUI(ref QuyDinhNhanVienDTO qdnvDTO, TextBoxX txtMaQDNV, TextBoxX txtQDNVTuoiToiThieu, TextBoxX txtQDNVTuoiToiDa, QuyDinhNhanVienBUS qdnvBUS)
        {
            qdnvDTO.Maqd = txtMaQDNV.Text;

            if (qdnvBUS.IsOnlyNumber(txtQDNVTuoiToiThieu.Text))
                qdnvDTO.Tuoitoithieu = int.Parse(txtQDNVTuoiToiThieu.Text);
            else return false;

            if (qdnvBUS.IsOnlyNumber(txtQDNVTuoiToiDa.Text))
                qdnvDTO.Tuoitoida = int.Parse(txtQDNVTuoiToiDa.Text);
            else return false;

            qdnvDTO.Ngayra = DateTime.Today;
            qdnvDTO.Ngayketthuc = DateTime.MaxValue;
            return true;
        }

        public void GetDataWhenClickDGVQDNV(DataGridViewRow row, ref TextBoxX txtMaQDNV, ref TextBoxX txtQDNVTuoiToiThieu, ref TextBoxX txtQDNVTuoiToiDa)
        {
            txtMaQDNV.Text = row.Cells["MAQD"].Value.ToString();
            txtQDNVTuoiToiThieu.Text = row.Cells["TUOITOITHIEU"].Value.ToString();
            txtQDNVTuoiToiDa.Text = row.Cells["TUOITOIDA"].Value.ToString();
        }

        public void CLearPanelQDNV(ref TextBoxX txtMaQDNV, ref TextBoxX txtQDNVTuoiToiThieu, ref TextBoxX txtQDNVTuoiToiDa, QuyDinhNhanVienBUS qdnvBUS)
        {
            txtMaQDNV.Text = "QDNV" + qdnvBUS.GetNewSTT();
            txtQDNVTuoiToiThieu.Text = "0";
            txtQDNVTuoiToiDa.Text = "0";
        }

        public void UpdatePreviousDataRowQDNV(ref QuyDinhNhanVienDTO qdnvDTO, DataGridViewX dgvQDNV)
        {
            int count = dgvQDNV.RowCount - 1;
            qdnvDTO.Maqd = dgvQDNV.Rows[count].Cells["MAQD"].Value.ToString();
            qdnvDTO.Tuoitoithieu = int.Parse(dgvQDNV.Rows[count].Cells["TUOITOITHIEU"].Value.ToString());
            qdnvDTO.Tuoitoida = int.Parse(dgvQDNV.Rows[count].Cells["TUOITOIDA"].Value.ToString());
            qdnvDTO.Ngayra = Convert.ToDateTime(dgvQDNV.Rows[count].Cells["NGAYRA"].Value);
            if (DateTime.Today < qdnvDTO.Ngayra)
                qdnvDTO.Ngayketthuc = qdnvDTO.Ngayra;
            else
            {
                qdnvDTO.Ngayketthuc = DateTime.Today;
            }
        }

    }
}
