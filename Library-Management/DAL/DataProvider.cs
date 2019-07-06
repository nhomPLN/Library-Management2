using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Windows.Forms;

namespace DAL
{
    public class DataProvider
    {
        private static DataProvider instance;
        public static DataProvider Instance
        {
            get
            {
                if (instance == null)
                    instance = new DataProvider();
                return instance;
            }

        }

        private static string connection_string = ConfigurationManager.AppSettings["ConnectionString"];
        public static string Connection_string { get => connection_string; set => connection_string = value; }

        /// <summary>
        // Load Data from Sql Server into DataTable
        public DataTable Excutequery(string query, object[] para = null)
        {
            //ConfigurationManager.AppSettings["Connection String"];
            DataTable data_table = new DataTable();
            //Connection_string = @"Data Source=DESKTOP-8SR6FTI\SQLEXPRESS;Initial Catalog=QLTV;Integrated Security=True";
            using (SqlConnection connection = new SqlConnection(Connection_string))
            {
                //try
                //{
                    connection.Open();

                    SqlCommand command = new SqlCommand(query, connection);
                    if (para != null)
                    {
                        string[] temp = query.Split(' ');

                        List<string> listpara = new List<string>();

                        foreach (string item in temp)
                        {
                            if (item != "")
                            {
                                if (item[0] == '@')
                                    listpara.Add(item);
                            }
                        }
                        for (int i = 0; i < para.Length; ++i)
                        {
                            command.Parameters.AddWithValue(listpara[i], para[i]);
                        }
                    }

                    SqlDataAdapter adapter = new SqlDataAdapter(command);
                    adapter.Fill(data_table);
                    connection.Close();
                //}
                //catch
                //{
                //    MessageBox.Show("ĐÃ XẢY RA LỖI VỚI DỮ LIỆU, VUI LÒNG KIỂM TRA LẠI!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                //}
                

                
            }

            return data_table;
        }
        //--------------------------------------------------------------------------
        public bool excuteNonQuery(string query, object[] para = null)
        {
            //Connection_string = @"Data Source=DESKTOP-8SR6FTI\SQLEXPRESS;Initial Catalog=QLTV;Integrated Security=True";
            using (SqlConnection connection = new SqlConnection(Connection_string))
            {
                connection.Open();

                SqlCommand command = new SqlCommand(query, connection);

                if (para != null)
                {
                    string[] temp = query.Split(' ');

                    List<string> listpara = new List<string>();

                    foreach (string item in temp)
                    {
                        if (item != string.Empty && item[0] == '@')
                            listpara.Add(item);
                    }
                    for (int i = 0; i < para.Length; ++i)
                    {
                        command.Parameters.AddWithValue(listpara[i], para[i]);
                    }
                }
                try
                {
                    command.ExecuteNonQuery();
                }
                catch (Exception ex)
                {
                    //Console.WriteLine(ex.GetType());
                    connection.Dispose();
                    connection.Close();
                    return false;
                }

                connection.Close();
            }
            return true;
        }

        public bool IsOnlyNumber(string temp)
        {
            for (int i = 0; i < temp.Length; ++i)
            {
                if (temp[i] > '9' || temp[i] < '0')
                {
                    return false;
                }
            }
            return true;
        }
    }
}
