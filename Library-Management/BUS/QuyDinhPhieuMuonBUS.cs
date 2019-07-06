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
    public class QuyDinhPhieuMuonBUS
    {
        private QuyDinhPhieuMuonDAL qdpmDAL;
        public QuyDinhPhieuMuonBUS()
        {
            qdpmDAL = new QuyDinhPhieuMuonDAL();
        }

        public DataTable LoadBangQDPM()
        {
            return qdpmDAL.LoadBangQDPM();
        }

        public void LoadDgvQDPM(ref DataGridViewX dgvQDPM, QuyDinhPhieuMuonBUS qdpmBUS)
        {
            dgvQDPM.DataSource = qdpmBUS.LoadBangQDPM();
        }

        public void LoadTabQDPM(ref DataGridViewX dgvQDPM, ref TextBoxX txtMaQDPM, ref TextBoxX txtQDPMSoSachMax, ref TextBoxX txtQDPMSoNgayMuonMax, QuyDinhPhieuMuonBUS qdpmBUS)
        {
            LoadDgvQDPM(ref dgvQDPM, qdpmBUS);
            if (dgvQDPM.RowCount != 0)
                GetDataWhenClickDGVQDPM(dgvQDPM.Rows[0], ref txtMaQDPM, ref txtQDPMSoSachMax, ref txtQDPMSoNgayMuonMax);
            else ClearPanelQDPM(ref txtMaQDPM, ref txtQDPMSoSachMax, ref txtQDPMSoNgayMuonMax, qdpmBUS);
        }

        public bool Them(QuyDinhPhieuMuonDTO qdpmDTO)
        {
            return qdpmDAL.Them(qdpmDTO);
        }

        public bool Xoa(QuyDinhPhieuMuonDTO qdpmDTO)
        {
            return qdpmDAL.Xoa(qdpmDTO);
        }

        public bool Sua(QuyDinhPhieuMuonDTO qdpmDTO)
        {
            return qdpmDAL.Sua(qdpmDTO);
        }

        public int GetNewSTT()
        {
            return qdpmDAL.GetNewSTT();
        }

        public bool ResetSTT()
        {
            return qdpmDAL.ResetSTT();
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



        public bool MapDataQDPMFromGUIQDPM(ref QuyDinhPhieuMuonDTO qdpmDTO, TextBoxX txtMaQDPM, TextBoxX txtQDPMSoSachMax, TextBoxX txtQDPMSoNgayMuonMax, QuyDinhPhieuMuonBUS qdpmBUS)
        {
            qdpmDTO.Maqd = txtMaQDPM.Text;
            if (qdpmBUS.IsOnlyNumber(txtQDPMSoSachMax.Text))
                qdpmDTO.Sosachtoida = int.Parse(txtQDPMSoSachMax.Text);
            else return false;
            if (qdpmBUS.IsOnlyNumber(txtQDPMSoNgayMuonMax.Text))
                qdpmDTO.Songaymuontoida = int.Parse(txtQDPMSoNgayMuonMax.Text);
            else return false;
            qdpmDTO.Ngayra = DateTime.Today;
            qdpmDTO.Ngayketthuc = DateTime.MaxValue;
            return true;
        }

        public void GetDataWhenClickDGVQDPM(DataGridViewRow row, ref TextBoxX txtMaQDPM, ref TextBoxX txtQDPMSoSachMax, ref TextBoxX txtQDPMSoNgayMuonMax)
        {
            txtMaQDPM.Text = row.Cells["MAQD"].Value.ToString();
            txtQDPMSoSachMax.Text = row.Cells["SOSACHTOIDA"].Value.ToString();
            txtQDPMSoNgayMuonMax.Text = row.Cells["SONGAYMUONTOIDA"].Value.ToString();
        }

        public void ClearPanelQDPM(ref TextBoxX txtMaQDPM, ref TextBoxX txtQDPMSoSachMax, ref TextBoxX txtQDPMSoNgayMuonMax, QuyDinhPhieuMuonBUS qdpmBUS)
        {
            txtMaQDPM.Text = "QDPM" + qdpmBUS.GetNewSTT();
            txtQDPMSoSachMax.Text = "0";
            txtQDPMSoNgayMuonMax.Text = "0";
        }

        public void UpdatePreviousDataRowQDPM(ref QuyDinhPhieuMuonDTO qdpmDTO, DataGridViewX dgvQDPM)
        {
            int count = dgvQDPM.RowCount - 1;
            qdpmDTO.Maqd = dgvQDPM.Rows[count].Cells["MAQD"].Value.ToString();
            qdpmDTO.Sosachtoida = int.Parse(dgvQDPM.Rows[count].Cells["SOSACHTOIDA"].Value.ToString());
            qdpmDTO.Songaymuontoida = int.Parse(dgvQDPM.Rows[count].Cells["SONGAYMUONTOIDA"].Value.ToString());
            qdpmDTO.Ngayra = DateTime.Today;
            if (DateTime.Today < qdpmDTO.Ngayra)
                qdpmDTO.Ngayketthuc = qdpmDTO.Ngayra;
            else
            {
                qdpmDTO.Ngayketthuc = DateTime.Today;
            }
        }
    }
}
