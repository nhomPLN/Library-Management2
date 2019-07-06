using DAL;
using DTO;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL
{
    public class TheLoaiSachDAL
    {
        string ConnectionString = ConfigurationManager.AppSettings["ConnectionString"];
        DataProvider dataprovider = new DataProvider();

        public List<TheLoaiSachDTO> LoadTheLoai()
        {
            List<TheLoaiSachDTO> ans = new List<TheLoaiSachDTO>();
            string query = "SELECT *";
            query += " FROM THELOAISACH";
            DataTable temp = dataprovider.Excutequery(query);

            for (int i = 0; i < temp.Rows.Count; ++i)
            {
                TheLoaiSachDTO tmp = new TheLoaiSachDTO();

                tmp.NewCategory(temp.Rows[i]);
                ans.Add(tmp);
            }

            return ans;
        }


    }
}
