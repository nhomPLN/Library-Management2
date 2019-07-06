using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DTO;

namespace DAL
{
    public class QDLoaiSachDAL
    {
        public QDLoaiSachDAL()
        {

        }

        public DataTable LoadBangTheLoaiSach()
        {
            string query = "SELECT MATHELOAI, TENTHELOAI FROM THELOAISACH";
            return DataProvider.Instance.Excutequery(query);
        }

        public bool Them(QDLoaiSachDTO lsDTO)
        {
            string query = @"INSERT INTO THELOAISACH ( MATHELOAI, TENTHELOAI ) VALUES ( @MATHELOAI , @TENTHELOAI )";
            object[] para = new object[] { lsDTO.Matheloai, lsDTO.Tentheloai };
            return DataProvider.Instance.excuteNonQuery(query, para);
        }

        public bool Xoa(QDLoaiSachDTO lsDTO)
        {
            string query = @"DELETE THELOAISACH WHERE MATHELOAI = @MATHELOAI";
            object[] para = new object[] { lsDTO.Matheloai };
            return DataProvider.Instance.excuteNonQuery(query, para);
        }

        public bool Sua(QDLoaiSachDTO lsDTO)
        {
            string query = @"UPDATE THELOAISACH SET TENTHELOAI = @TENTHELOAI WHERE MATHELOAI = @MATHELOAI";
            object[] para = new object[] { lsDTO.Tentheloai, lsDTO.Matheloai };
            return DataProvider.Instance.excuteNonQuery(query, para);
        }

        public bool IsLSCoTonTaiTrongSach(QDLoaiSachDTO lsDTO)
        {
            DataTable data = DataProvider.Instance.Excutequery("SELECT DISTINCT MATHELOAI FROM SACH");
            for (int i = 0; i < data.Rows.Count; ++i)
            {
                if (lsDTO.Matheloai == data.Rows[i]["MATHELOAI"].ToString())
                    return true;
            }
            return false;
        }



    }
}
