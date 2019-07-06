using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DTO;
namespace DAL
{
    public class QuyDinhSachDAL
    {
        public QuyDinhSachDAL()
        {

        }

        public DataTable LoadBangQDS()
        {
            string query = @"SELECT MAQD, THOIHANSACH, NGAYRA, NGAYKETTHUC FROM QUYDINHSACH";
            return DataProvider.Instance.Excutequery(query);
        }

        public bool Them(QuyDinhSachDTO qdsDTO)
        {
            string query = @"INSERT INTO QUYDINHSACH ( MAQD, THOIHANSACH, NGAYRA, NGAYKETTHUC ) VALUES ( @MAQD , @THOIHANSACH , @NGAYRA , @NGAYKETTHUC )";
            object[] para = new object[] { qdsDTO.Maqd, qdsDTO.Thoihansach, qdsDTO.Ngayra, qdsDTO.Ngayketthuc };
            return DataProvider.Instance.excuteNonQuery(query, para);
        }

        public bool Xoa(QuyDinhSachDTO qdsDTO)
        {
            string query = @"DELETE QUYDINHSACH WHERE MAQD = @MAQD ";
            object[] para = new object[] { qdsDTO.Maqd };
            return DataProvider.Instance.excuteNonQuery(query, para);
        }

        public bool Sua(QuyDinhSachDTO qdsDTO)
        {
            string query = @" UPDATE QUYDINHSACH SET THOIHANSACH = @THOIHANSACH , NGAYRA = @NGAYRA , NGAYKETTHUC = @NGAYKETTHUC WHERE MAQD = @MAQD ";
            object[] para = new object[] { qdsDTO.Thoihansach, qdsDTO.Ngayra, qdsDTO.Ngayketthuc, qdsDTO.Maqd };
            return DataProvider.Instance.excuteNonQuery(query, para);
        }

        public bool ResetSTT()
        {
            string query = @"DBCC CHECKIDENT (QUYDINHSACH, RESEED, 0)";
            return DataProvider.Instance.excuteNonQuery(query);
        }

        public int GetNewSTT()
        {
            string query = @"SELECT MAX(STT) FROM QUYDINHSACH";
            DataTable data = DataProvider.Instance.Excutequery(query);
            int a = 1;
            try
            {
                a = int.Parse(data.Rows[0][0].ToString());
                a += 1;
            }
            catch { }
            return a;
        }
    }
}
