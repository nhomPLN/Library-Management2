using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DTO;
namespace DAL
{
    public class ThongKeSachDAL
    {
        public ThongKeSachDAL()
        {

        }

        public DataTable GetSachDuocMuonNhieu()
        {
            string query = @"SELECT * FROM SACH ORDER BY LUOTMUON DESC";
            return DataProvider.Instance.Excutequery(query);
        }

        public DataTable GetLuotMuonSachTheoTheLoai()
        {
            string query = @"SELECT TENTHELOAI, SUM(LUOTMUON) AS SOLUOTMUON FROM SACH INNER JOIN THELOAISACH ON SACH.MATHELOAI = THELOAISACH.MATHELOAI GROUP BY (TENTHELOAI)";
            return DataProvider.Instance.Excutequery(query);
        }

    }
}
