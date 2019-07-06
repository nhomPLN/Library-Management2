using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DTO;

namespace DAL
{
    public class QDLoaiDocGiaDAL
    {
        public QDLoaiDocGiaDAL()
        {

        }

        public DataTable LoadBangLoaiDG()
        {
            string query = @"SELECT MALOAIDG, TENLOAIDG FROM LOAIDOCGIA";
            return DataProvider.Instance.Excutequery(query);
        }

        public bool Them(QDLoaiDocGiaDTO ldgDTO)
        {
            string query = @"INSERT INTO LOAIDOCGIA ( MALOAIDG, TENLOAIDG ) VALUES ( @MALOAIDG , @TENLOAIDG )";
            object[] para = new object[] { ldgDTO.Maloaidg, ldgDTO.Loaidg };
            return DataProvider.Instance.excuteNonQuery(query, para);
        }

        public bool Xoa(QDLoaiDocGiaDTO ldgDTO)
        {
            string query = @"DELETE LOAIDOCGIA WHERE MALOAIDG = @MALOAIDG ";
            object[] para = new object[] { ldgDTO.Maloaidg };
            return DataProvider.Instance.excuteNonQuery(query, para);
        }

        public bool Sua(QDLoaiDocGiaDTO ldgDTO)
        {
            string query = @" UPDATE LOAIDOCGIA SET TENLOAIDG = @TENLOAIDG WHERE MALOAIDG = @MALOAIDG ";
            object[] para = new object[] { ldgDTO.Loaidg, ldgDTO.Maloaidg };
            return DataProvider.Instance.excuteNonQuery(query, para);
        }

        public bool IsLDGCoTonTaiTrongDG(QDLoaiDocGiaDTO ldgDTO)
        {
            DataTable data = DataProvider.Instance.Excutequery("SELECT DISTINCT MALOAIDG FROM DOCGIA");
            for (int i = 0; i < data.Rows.Count; ++i)
            {
                if (ldgDTO.Maloaidg == data.Rows[i]["MALOAIDG"].ToString())
                    return true;
            }
            return false;
        }
    }
}
