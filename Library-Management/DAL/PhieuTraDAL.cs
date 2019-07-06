using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DTO;

namespace DAL
{
    public class PhieuTraDAL
    {
        DataProvider dataprovider = new DataProvider();

        public bool CreateReturnReceipt(PhieuTraDTO returnreceipt)
        {
            string query = string.Empty;
            object[] listpara = { returnreceipt.Mapm, returnreceipt.Masach, returnreceipt.Madg, returnreceipt.Ngaytra, returnreceipt.Tienphat };

            query += "INSERT INTO PHIEUTRA (MAPM, MASACH, MADG, NGAYTRA, TIENPHAT)";
            query += " VALUES ( @MaPM , @MaSach , @MaDG , @NgayTra , @TienPhat )";

            return dataprovider.excuteNonQuery(query, listpara);
        }
    }
}
