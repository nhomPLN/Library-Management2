using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DTO;
namespace DAL
{
    public class QDChucVuNhanVienDAL
    {
        public QDChucVuNhanVienDAL()
        {

        }

        public DataTable LoadBangCVNV()
        {
            string query = @"SELECT MACHUCVU, CHUCVU FROM CHUCVUNV";
            return DataProvider.Instance.Excutequery(query);
        }

        public bool Them(QDChucVuNhanVienDTO cvnvDTO)
        {
            string query = @"INSERT INTO CHUCVUNV (MACHUCVU, CHUCVU) VALUES ( @MACHUCVU , @CHUCVU )";
            object[] para = new object[] { cvnvDTO.Macv, cvnvDTO.Chucvu };
            return DataProvider.Instance.excuteNonQuery(query, para);
        }

        public bool Xoa(QDChucVuNhanVienDTO cvnvDTO)
        {
            string query = @"DELETE CHUCVUNV WHERE MACHUCVU = @MACHUCVU";
            object[] para = new object[] { cvnvDTO.Macv };
            return DataProvider.Instance.excuteNonQuery(query, para);
        }

        public bool Sua(QDChucVuNhanVienDTO cvnvDTO)
        {
            string query = @"UPDATE CHUCVUNV SET CHUCVU = @CHUCVU WHERE MACHUCVU = @MACHUCVU";
            object[] para = new object[] { cvnvDTO.Macv, cvnvDTO.Chucvu };
            return DataProvider.Instance.excuteNonQuery(query, para);
        }

        public bool IsCVNVCoTonTaiTrongNV(QDChucVuNhanVienDTO cvnvDTO)
        {
            DataTable data = DataProvider.Instance.Excutequery("SELECT DISTINCT MACHUCVU FROM NHANVIEN");
            for (int i = 0; i < data.Rows.Count; ++i)
            {
                if (cvnvDTO.Macv == data.Rows[i]["MACHUCVU"].ToString())
                    return true;
            }
            return false;
        }


    }
}
