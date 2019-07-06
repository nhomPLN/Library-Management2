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
    public class QDLoaiSachBUS
    {
        private QDLoaiSachDAL lsDAL;
        public QDLoaiSachBUS()
        {
            lsDAL = new QDLoaiSachDAL();
        }

        public DataTable LoadBangTheLoaiSach()
        {
            return lsDAL.LoadBangTheLoaiSach();
        }

        public void LoadDgvLoaiSach(ref DataGridViewX dgvLoaiSach, QDLoaiSachBUS lsBUS)
        {
            dgvLoaiSach.DataSource = lsBUS.LoadBangTheLoaiSach();
        }

        public void LoadPanelLoaiSach(ref DataGridViewX dgvLoaiSach, ref TextBoxX txtMaLoaiSachQDS, ref TextBoxX txtTenLoaiSachQDS, QDLoaiSachBUS lsBUS)
        {
            LoadDgvLoaiSach(ref dgvLoaiSach, lsBUS);
            if (dgvLoaiSach.RowCount != 0)
                GetDataWhenClickDGVLoaiSach(dgvLoaiSach.Rows[0], ref txtMaLoaiSachQDS, ref txtTenLoaiSachQDS);
            else ClearPanelLoaiSach(ref txtMaLoaiSachQDS, ref txtTenLoaiSachQDS);
        }

        public bool Them(QDLoaiSachDTO lsDTO)
        {
            return lsDAL.Them(lsDTO);
        }

        public bool Xoa(QDLoaiSachDTO lsDTO, ref string chuoiLS)
        {
            if (lsDAL.IsLSCoTonTaiTrongSach(lsDTO))
            {
                chuoiLS += lsDTO.Matheloai;
                chuoiLS += " ";
                return false;
            }
            return lsDAL.Xoa(lsDTO);
        }

        public bool Sua(QDLoaiSachDTO lsDTO)
        {
            return lsDAL.Sua(lsDTO);
        }

        public bool IsTrungKhopKhoaChinh(string id, DataGridView dgv)
        {
            if (dgv.RowCount == 0)
                return false;
            for (int i = 0; i < dgv.RowCount; ++i)
            {
                if (id == dgv.Rows[i].Cells["MATHELOAI"].Value.ToString())
                    return true;
            }
            return false;
        }

        public void MapDataLSFromGUILoaiSach(ref QDLoaiSachDTO lsDTO, TextBoxX txtMaLoaiSachQDS, TextBoxX txtTenLoaiSachQDS)
        {
            lsDTO.Matheloai = txtMaLoaiSachQDS.Text;
            lsDTO.Tentheloai = txtTenLoaiSachQDS.Text;
        }

        public void GetDataWhenClickDGVLoaiSach(DataGridViewRow row, ref TextBoxX txtMaLoaiSachQDS, ref TextBoxX txtTenLoaiSachQDS)
        {
            txtMaLoaiSachQDS.Text = row.Cells["MATHELOAI"].Value.ToString();
            txtTenLoaiSachQDS.Text = row.Cells["TENTHELOAI"].Value.ToString();
        }

        public void ClearPanelLoaiSach(ref TextBoxX txtMaLoaiSachQDS, ref TextBoxX txtTenLoaiSachQDS)
        {
            txtMaLoaiSachQDS.Text = "";
            txtTenLoaiSachQDS.Text = "";
        }

    }
}
