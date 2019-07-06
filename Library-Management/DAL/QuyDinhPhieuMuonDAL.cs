using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DTO;
namespace DAL
{
    public class QuyDinhPhieuMuonDAL
    {
        public QuyDinhPhieuMuonDAL()
        {

        }

        public DataTable LoadBangQDPM()
        {
            string query = @"SELECT MAQD, SOSACHTOIDA, SONGAYMUONTOIDA, NGAYRA, NGAYKETTHUC FROM QUYDINHPHIEUMUON";
            return DataProvider.Instance.Excutequery(query);
        }

        public bool Them(QuyDinhPhieuMuonDTO qdpmDTO)
        {
            string query = @"INSERT INTO QUYDINHPHIEUMUON ( MAQD, SOSACHTOIDA, SONGAYMUONTOIDA, NGAYRA, NGAYKETTHUC ) VALUES( @MAQD , @SOSACHTOIDA , @SONGAYMUONTOIDA , @NGAYRA , @NGAYKETTHUC )";
            object[] para = new object[] { qdpmDTO.Maqd, qdpmDTO.Sosachtoida, qdpmDTO.Songaymuontoida, qdpmDTO.Ngayra, qdpmDTO.Ngayketthuc };
            return DataProvider.Instance.excuteNonQuery(query, para);
        }

        public bool Xoa(QuyDinhPhieuMuonDTO qdpmDTO)
        {
            string query = @"DELETE QUYDINHPHIEUMUON WHERE MAQD = @MAQD";
            object[] para = new object[] { qdpmDTO.Maqd };
            return DataProvider.Instance.excuteNonQuery(query, para);
        }

        public bool Sua(QuyDinhPhieuMuonDTO qdpmDTO)
        {
            string query = @"UPDATE QUYDINHPHIEUMUON SET SOSACHTOIDA = @SOSACHTOIDA , SONGAYMUONTOIDA = @SONGAYMUONTOIDA , NGAYRA = @NGAYRA , NGAYKETTHUC = @NGAYKETTHUC WHERE MAQD = @MAQD";
            object[] para = new object[] { qdpmDTO.Sosachtoida, qdpmDTO.Songaymuontoida, qdpmDTO.Ngayra, qdpmDTO.Ngayketthuc, qdpmDTO.Maqd };
            return DataProvider.Instance.excuteNonQuery(query, para);
        }

        public bool ResetSTT()
        {
            string query = @"DBCC CHECKIDENT (QUYDINHPHIEUMUON, RESEED, 0)";
            return DataProvider.Instance.excuteNonQuery(query);
        }

        public int GetNewSTT()
        {
            string query = @"SELECT MAX(STT) FROM QUYDINHPHIEUMUON";
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
