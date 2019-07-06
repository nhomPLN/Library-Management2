using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DTO;
namespace DAL
{
    public class ThongKeDocGiaDAL
    {
        public ThongKeDocGiaDAL()
        {

        }
        public DataTable GetDocGiaTraTre()
        {
            string query = @"SELECT * FROM DOCGIA WHERE DOCGIA.MADG IN(SELECT PT.MADG FROM PHIEUTRA AS PT, PHIEUMUON AS PM WHERE PT.MADG= PM.MADG AND PT.NGAYTRA > PM.HANTRA)";
            return DataProvider.Instance.Excutequery(query);
        }

        public DataTable GetDocGiaLuotMuonNhieu()
        {
            string query = @"SELECT * FROM DOCGIA ORDER BY LUOTMUON ASC";
            return DataProvider.Instance.Excutequery(query);
        }
    }
}
