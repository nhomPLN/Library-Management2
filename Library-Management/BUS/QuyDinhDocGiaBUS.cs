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
    public class QuyDinhDocGiaBUS
    {
        QuyDinhDocGiaDAL qddgDAL;
        public QuyDinhDocGiaBUS()
        {
            qddgDAL = new QuyDinhDocGiaDAL();
        }

        public DataTable LoadBangQDDG()
        {
            return qddgDAL.LoadBangQDDG();
        }

        public void LoadDgvQDDG(ref DataGridViewX dgvQDDG, QuyDinhDocGiaBUS qddgBUS)
        {
            dgvQDDG.DataSource = qddgBUS.LoadBangQDDG();
        }

        public void LoadPanelQDDG(ref DataGridViewX dgvQDDG, ref TextBoxX txtMaQDDG, ref TextBoxX txtQDDGHanThe, ref TextBoxX txtQDDGTuoiToiThieu, ref TextBoxX txtQDDGTuoiToiDa, QuyDinhDocGiaBUS qddgBUS)
        {
            LoadDgvQDDG(ref dgvQDDG, qddgBUS);
            if (dgvQDDG.RowCount != 0)
            {
                GetDataWhenClickDGVQDDG(dgvQDDG.Rows[0], ref txtMaQDDG, ref txtQDDGHanThe, ref txtQDDGTuoiToiThieu, ref txtQDDGTuoiToiDa); //Load data từ datagridview vào panel
            }
            else ClearPanelQDDG(qddgBUS, ref txtMaQDDG, ref txtQDDGHanThe, ref txtQDDGTuoiToiThieu, ref txtQDDGTuoiToiDa);

        }

        public bool Them(QuyDinhDocGiaDTO qddgDTO)
        {
            return qddgDAL.Them(qddgDTO);
        }

        public bool Xoa(QuyDinhDocGiaDTO qddgDTO)
        {
            return qddgDAL.Xoa(qddgDTO);
        }

        public bool Sua(QuyDinhDocGiaDTO qddgDTO)
        {
            return qddgDAL.Sua(qddgDTO);
        }


        public int GetNewSTT()
        {
            return qddgDAL.GetNewSTT();
        }

        public bool ResetSTT()
        {
            return qddgDAL.ResetSTT();
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

        public bool MapDataQDDGFromGUI(ref QuyDinhDocGiaDTO qddgDTO, TextBoxX txtMaQDDG, TextBoxX txtQDDGHanThe, TextBoxX txtQDDGTuoiToiThieu, TextBoxX txtQDDGTuoiToiDa, QuyDinhDocGiaBUS qddgBUS)
        {
            qddgDTO.Maqd = txtMaQDDG.Text;
            if (qddgBUS.IsOnlyNumber(txtQDDGHanThe.Text))
                qddgDTO.Thoihanthe = int.Parse(txtQDDGHanThe.Text);
            else return false;

            if (qddgBUS.IsOnlyNumber(txtQDDGTuoiToiThieu.Text))
                qddgDTO.Tuoitoithieu = int.Parse(txtQDDGTuoiToiThieu.Text);
            else return false;

            if (qddgBUS.IsOnlyNumber(txtQDDGTuoiToiDa.Text))
                qddgDTO.Tuoitoida = int.Parse(txtQDDGTuoiToiDa.Text);
            else return false;

            qddgDTO.Ngayra = DateTime.Today;
            qddgDTO.Ngayketthuc = DateTime.MaxValue;
            return true;
        }



        public void GetDataWhenClickDGVQDDG(DataGridViewRow row, ref TextBoxX txtMaQDDG, ref TextBoxX txtQDDGHanThe, ref TextBoxX txtQDDGTuoiToiThieu, ref TextBoxX txtQDDGTuoiToiDa)
        {
            txtMaQDDG.Text = row.Cells["MAQD"].Value.ToString();
            txtQDDGHanThe.Text = row.Cells["THOIHANTHE"].Value.ToString();
            txtQDDGTuoiToiThieu.Text = row.Cells["TUOITOITHIEU"].Value.ToString();
            txtQDDGTuoiToiDa.Text = row.Cells["TUOITOIDA"].Value.ToString();
        }

        public void ClearPanelQDDG(QuyDinhDocGiaBUS qddgBUS, ref TextBoxX txtMaQDDG, ref TextBoxX txtQDDGHanThe, ref TextBoxX txtQDDGTuoiToiThieu, ref TextBoxX txtQDDGTuoiToiDa)
        {
            txtMaQDDG.Text = "QDDG" + qddgBUS.GetNewSTT().ToString();
            txtQDDGHanThe.Text = "0";
            txtQDDGTuoiToiThieu.Text = "0";
            txtQDDGTuoiToiDa.Text = "0";
        }

        public void UpdatePreviousDataRowQDDG(ref QuyDinhDocGiaDTO qddgDTO, DataGridViewX dgvQDDG)
        {
            int count = dgvQDDG.RowCount - 1;
            qddgDTO.Maqd = dgvQDDG.Rows[count].Cells["MAQD"].Value.ToString();
            qddgDTO.Thoihanthe = int.Parse(dgvQDDG.Rows[count].Cells["THOIHANTHE"].Value.ToString());
            qddgDTO.Tuoitoithieu = int.Parse(dgvQDDG.Rows[count].Cells["TUOITOITHIEU"].Value.ToString());
            qddgDTO.Tuoitoida = int.Parse(dgvQDDG.Rows[count].Cells["TUOITOIDA"].Value.ToString());
            qddgDTO.Ngayra = Convert.ToDateTime(dgvQDDG.Rows[count].Cells["NGAYRA"].Value);
            if (DateTime.Today < qddgDTO.Ngayra)
                qddgDTO.Ngayketthuc = qddgDTO.Ngayra;
            else
            {
                qddgDTO.Ngayketthuc = DateTime.Today;
            }
        }
    }
}
