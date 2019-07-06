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
    public class QDChucVuNhanVienBUS
    {
        private QDChucVuNhanVienDAL cvnvDAL;
        public QDChucVuNhanVienBUS()
        {
            cvnvDAL = new QDChucVuNhanVienDAL();
        }

        public DataTable LoadBangCVNV()
        {
            return cvnvDAL.LoadBangCVNV();
        }

        public void LoadDgvCVNV(ref DataGridViewX dgvChucVu, QDChucVuNhanVienBUS cvnvBUS)
        {
            dgvChucVu.DataSource = cvnvBUS.LoadBangCVNV();
        }

        public void LoadPanelCVNV(ref DataGridViewX dgvChucVu, ref TextBoxX txtMaChucVuQDNV, ref TextBoxX txtTenChucVuQDNV, QDChucVuNhanVienBUS cvnvBUS)
        {
            LoadDgvCVNV(ref dgvChucVu, cvnvBUS);
            if (dgvChucVu.RowCount != 0)
                GetDataWhenClickDGVCVNV(dgvChucVu.Rows[0], ref txtMaChucVuQDNV, ref txtTenChucVuQDNV);
            else ClearPanelCVNV(ref txtMaChucVuQDNV, ref txtTenChucVuQDNV);
        }

        public bool Them(QDChucVuNhanVienDTO cvnvDTO)
        {
            return cvnvDAL.Them(cvnvDTO);
        }

        public bool Xoa(QDChucVuNhanVienDTO cvnvDTO, ref string chuoiCVNV)
        {
            if (cvnvDAL.IsCVNVCoTonTaiTrongNV(cvnvDTO))
            {
                chuoiCVNV += cvnvDTO.Macv;
                chuoiCVNV += " ";
                return false;
            }
            return cvnvDAL.Xoa(cvnvDTO);

        }

        public bool Sua(QDChucVuNhanVienDTO cvnvDTO)
        {
            return cvnvDAL.Sua(cvnvDTO);
        }

        public bool IsTrungKhopKhoaChinh(string id, DataGridView dgv)
        {
            if (dgv.RowCount == 0)
                return false;
            for (int i = 0; i < dgv.RowCount; ++i)
            {
                if (id == dgv.Rows[i].Cells["MACHUCVU"].Value.ToString())
                    return true;
            }
            return false;
        }

        public void MapDataCVNVFromGUICVNV(ref QDChucVuNhanVienDTO cvnvDTO, TextBoxX txtMaChucVuQDNV, TextBoxX txtTenChucVuQDNV)
        {
            cvnvDTO.Macv = txtMaChucVuQDNV.Text;
            cvnvDTO.Chucvu = txtTenChucVuQDNV.Text;
        }

        public void GetDataWhenClickDGVCVNV(DataGridViewRow row, ref TextBoxX txtMaChucVuQDNV, ref TextBoxX txtTenChucVuQDNV)
        {
            txtMaChucVuQDNV.Text = row.Cells["MACHUCVU"].Value.ToString();
            txtTenChucVuQDNV.Text = row.Cells["CHUCVU"].Value.ToString();
        }

        public void ClearPanelCVNV(ref TextBoxX txtMaChucVuQDNV, ref TextBoxX txtTenChucVuQDNV)
        {
            txtMaChucVuQDNV.Text = "";
            txtTenChucVuQDNV.Text = "";
        }

    }
}
