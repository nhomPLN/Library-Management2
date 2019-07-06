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
    public class QDLoaiDocGiaBUS
    {
        QDLoaiDocGiaDAL ldgDAL;
        public QDLoaiDocGiaBUS()
        {
            ldgDAL = new QDLoaiDocGiaDAL();
        }

        public DataTable LoadBangLoaiDG()
        {
            return ldgDAL.LoadBangLoaiDG();
        }

        public void LoadDgvLoaiDG(ref DataGridViewX dgvLoaiDG, QDLoaiDocGiaBUS ldgBUS)
        {
            dgvLoaiDG.DataSource = ldgBUS.LoadBangLoaiDG();
        }

        public void LoadPanelLoaiDG(ref DataGridViewX dgvLoaiDG, ref TextBoxX txtMaLoaiDGQDDG, ref TextBoxX txtTenLoaiDGQDDG, QDLoaiDocGiaBUS ldgBUS)
        {
            LoadDgvLoaiDG(ref dgvLoaiDG, ldgBUS);
            if (dgvLoaiDG.RowCount != 0)
            {
                GetDataWhenClickDGVLoaiDG(dgvLoaiDG.Rows[0], ref txtMaLoaiDGQDDG, ref txtTenLoaiDGQDDG);
            }
            else { ClearPanelLoaiDG(ref txtMaLoaiDGQDDG, ref txtTenLoaiDGQDDG); }
        }

        public bool Them(QDLoaiDocGiaDTO ldgDTO)
        {
            return ldgDAL.Them(ldgDTO);
        }

        public bool Xoa(QDLoaiDocGiaDTO ldgDTO, ref string chuoiLDG)
        {
            if (ldgDAL.IsLDGCoTonTaiTrongDG(ldgDTO))
            {
                chuoiLDG = chuoiLDG + ldgDTO.Maloaidg;
                chuoiLDG += " ";
                return false;
            }

            return ldgDAL.Xoa(ldgDTO);
        }

        public bool Sua(QDLoaiDocGiaDTO ldgDTO)
        {
            return ldgDAL.Sua(ldgDTO);
        }

        public bool IsTrungKhopKhoaChinh(string id, DataGridView dgv)
        {
            if (dgv.RowCount == 0)
                return false;
            for (int i = 0; i < dgv.RowCount; ++i)
            {
                if (id == dgv.Rows[i].Cells["MALOAIDG"].Value.ToString())
                    return true;
            }
            return false;
        }

        public void MapDataLDGFromGUIDG(ref QDLoaiDocGiaDTO ldgDTO, ComboBoxEx cbxLoaiDG)
        {
            ldgDTO.Loaidg = cbxLoaiDG.Text;
        }

        public void MapDataLoaiDGFromGUILoaiDG(ref QDLoaiDocGiaDTO ldgDTO, TextBoxX txtMaLoaiDGQDDG, TextBoxX txtTenLoaiDGQDDG)
        {
            ldgDTO.Maloaidg = txtMaLoaiDGQDDG.Text;
            ldgDTO.Loaidg = txtTenLoaiDGQDDG.Text;
        }


        public void GetDataWhenClickDGVLoaiDG(DataGridViewRow row, ref TextBoxX txtMaLoaiDGQDDG, ref TextBoxX txtTenLoaiDGQDDG)
        {
            txtMaLoaiDGQDDG.Text = row.Cells["MALOAIDG"].Value.ToString();
            txtTenLoaiDGQDDG.Text = row.Cells["TENLOAIDG"].Value.ToString();
        }

        public void ClearPanelLoaiDG(ref TextBoxX txtMaLoaiDGQDDG, ref TextBoxX txtTenLoaiDGQDDG)
        {
            txtMaLoaiDGQDDG.Text = "";
            txtTenLoaiDGQDDG.Text = "";
        }
    }
}
