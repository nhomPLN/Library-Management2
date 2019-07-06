using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using DAL;

namespace BUS
{
    public class LoginBUS
    {
        LoginDAL loginDAL = new DAL.LoginDAL();

        public bool IsValid(string accountID, string password)
        {
            string pass = (password);

            DataTable temp = loginDAL.CheckAccount(accountID, password);

            return temp.Rows.Count != 0;
        }

        public string GetAccountType(string accountID)
        {
            return loginDAL.GetAccountType(accountID);
        }
    }
}
