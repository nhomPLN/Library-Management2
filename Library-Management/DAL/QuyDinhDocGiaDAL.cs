using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DTO;
namespace DAL
{
    public class QuyDinhDocGiaDAL
    {
        public QuyDinhDocGiaDAL()
        {

        }

        public DataTable LoadBangQDDG()
        {
            string query = @"SELECT MAQD, TUOITOITHIEU, TUOITOIDA, THOIHANTHE, NGAYRA, NGAYKETTHUC FROM QUYDINHTHEDOCGIA";
            return DataProvider.Instance.Excutequery(query);
        }

        public bool Them(QuyDinhDocGiaDTO qddgDTO)
        {
            string query = @"INSERT INTO QUYDINHTHEDOCGIA ( MAQD, TUOITOITHIEU, TUOITOIDA, THOIHANTHE, NGAYRA, NGAYKETTHUC ) VALUES ( @MAQD , @TUOITOITHIEU , @TUOITOIDA , @THOIHANTHE , @NGAYRA , @NGAYKETTHUC )";
            object[] para = new object[] { qddgDTO.Maqd, qddgDTO.Tuoitoithieu, qddgDTO.Tuoitoida, qddgDTO.Thoihanthe, qddgDTO.Ngayra, qddgDTO.Ngayketthuc };
            return DataProvider.Instance.excuteNonQuery(query, para);
        }

        public bool Xoa(QuyDinhDocGiaDTO qddgDTO)
        {
            string query = @"DELETE QUYDINHTHEDOCGIA WHERE MAQD = @MAQD ";
            object[] para = new object[] { qddgDTO.Maqd };
            return DataProvider.Instance.excuteNonQuery(query, para);
        }

        public bool Sua(QuyDinhDocGiaDTO qddgDTO)
        {
            string query = @" UPDATE QUYDINHTHEDOCGIA SET TUOITOITHIEU = @TUOITOITHIEU , TUOITOIDA = @TUOITOIDA , THOIHANTHE = @THOIHANTHE , NGAYRA = @NGAYRA , NGAYKETTHUC = @NGAYKETTHUC WHERE MAQD = @MAQD ";
            object[] para = new object[] { qddgDTO.Tuoitoithieu, qddgDTO.Tuoitoida, qddgDTO.Thoihanthe, qddgDTO.Ngayra, qddgDTO.Ngayketthuc, qddgDTO.Maqd };
            return DataProvider.Instance.excuteNonQuery(query, para);
        }

        public bool ResetSTT()
        {
            string query = @"DBCC CHECKIDENT (QUYDINHTHEDOCGIA, RESEED, 0)";
            return DataProvider.Instance.excuteNonQuery(query);
        }

        public int GetNewSTT()
        {
            string query = @"SELECT MAX(STT) FROM QUYDINHTHEDOCGIA";
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
