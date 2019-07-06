using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL
{
    public class LoginDAL
    {
        DataProvider dataprovider = new DataProvider();

        public DataTable CheckAccount(string accountID, string password)
        {
            string query = "SELECT MATK FROM TAIKHOANNV WHERE TENTK='" + accountID + "' and MATKHAU='" + password + "'";

            return dataprovider.Excutequery(query);
        }

        public string GetAccountType(string accountID)
        {
            string query = "select MACHUCVU from TAIKHOANNV where TENTK='" + accountID + "'";

            return dataprovider.Excutequery(query).Rows[0][0].ToString();
        }
    }
}
