using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DTO;

namespace DAL
{
    public class QuyDinhNhanVienDAL
    {
        public QuyDinhNhanVienDAL()
        {

        }

        public DataTable LoadBangQDNV()
        {
            string query = @"SELECT STT, MAQD, TUOITOITHIEU, TUOITOIDA, NGAYRA, NGAYKETTHUC FROM QUYDINHNHANVIEN";
            return DataProvider.Instance.Excutequery(query);
        }

        public bool Them(QuyDinhNhanVienDTO qdnvDTO)
        {
            string query = @"INSERT INTO QUYDINHNHANVIEN ( MAQD, TUOITOITHIEU, TUOITOIDA, NGAYRA, NGAYKETTHUC ) VALUES ( @MAQD , @TUOITOITHIEU , @TUOITOIDA , @NGAYRA , @NGAYKETTHUC )";
            object[] para = new object[] { qdnvDTO.Maqd, qdnvDTO.Tuoitoithieu, qdnvDTO.Tuoitoida, qdnvDTO.Ngayra, qdnvDTO.Ngayketthuc };
            return DataProvider.Instance.excuteNonQuery(query, para);
        }

        public bool Xoa(QuyDinhNhanVienDTO qdnvDTO)
        {
            string query = @"DELETE QUYDINHNHANVIEN WHERE MAQD = @MAQD ";
            object[] para = new object[] { qdnvDTO.Maqd };
            return DataProvider.Instance.excuteNonQuery(query, para);
        }

        public bool Sua(QuyDinhNhanVienDTO qdnvDTO)
        {
            string query = @" UPDATE QUYDINHNHANVIEN SET TUOITOITHIEU = @TUOITOITHIEU , TUOITOIDA = @TUOITOIDA , NGAYRA = @NGAYRA , NGAYKETTHUC = @NGAYKETTHUC WHERE MAQD = @MAQD ";
            object[] para = new object[] { qdnvDTO.Tuoitoithieu, qdnvDTO.Tuoitoida, qdnvDTO.Ngayra, qdnvDTO.Ngayketthuc, qdnvDTO.Maqd };
            return DataProvider.Instance.excuteNonQuery(query, para);
        }

        public bool ResetSTT()
        {
            string query = @"DBCC CHECKIDENT (QUYDINHNHANVIEN, RESEED, 0)";
            return DataProvider.Instance.excuteNonQuery(query);
        }

        public int GetNewSTT()
        {
            string query = @"SELECT MAX(STT) FROM QUYDINHNHANVIEN";
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
