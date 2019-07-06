using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DTO;
using System.Data;
namespace DAL
{
    public class QuyDinhPhieuTraDAL
    {
        public QuyDinhPhieuTraDAL()
        {

        }

        public DataTable LoadBangQDPT()
        {
            string query = @"SELECT STT, MAQD, TIENPHAT, NGAYRA, NGAYKETTHUC FROM QUYDINHPHIEUTRA";
            return DataProvider.Instance.Excutequery(query);
        }

        public bool Them(QuyDinhPhieuTraDTO qdptDTO)
        {
            string query = @"INSERT INTO QUYDINHPHIEUTRA (MAQD, TIENPHAT, NGAYRA, NGAYKETTHUC) VALUES( @MAQD , @TIENPHAT , @NGAYRA , @NGAYKETTHUC )";
            object[] para = new object[] { qdptDTO.Maqd, qdptDTO.Tienphat, qdptDTO.Ngayra, qdptDTO.Ngayketthuc };
            return DataProvider.Instance.excuteNonQuery(query, para);
        }

        public bool Xoa(QuyDinhPhieuTraDTO qdptDTO)
        {
            string query = @"DELETE QUYDINHPHIEUTRA WHERE MAQD = @MAQD";
            object[] para = new object[] { qdptDTO.Maqd };
            return DataProvider.Instance.excuteNonQuery(query, para);
        }

        public bool Sua(QuyDinhPhieuTraDTO qdptDTO)
        {
            string query = @"UPDATE QUYDINHPHIEUTRA SET TIENPHAT = @TIENPHAT , NGAYRA = @NGAYRA , NGAYKETTHUC = @NGAYKETTHUC WHERE MAQD = @MAQD";
            object[] para = new object[] { qdptDTO.Tienphat, qdptDTO.Ngayra, qdptDTO.Ngayketthuc, qdptDTO.Maqd };
            return DataProvider.Instance.excuteNonQuery(query, para);
        }

        public bool ResetSTT()
        {
            string query = @"DBCC CHECKIDENT (QUYDINHPHIEUTRA, RESEED, 0)";
            return DataProvider.Instance.excuteNonQuery(query);
        }

        public int GetNewSTT()
        {
            string query = @"SELECT MAX(STT) FROM QUYDINHPHIEUTRA";
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
