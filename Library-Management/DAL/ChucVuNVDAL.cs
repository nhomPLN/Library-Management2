using DTO;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL
{
    public class ChucVuNVDAL
    {
        private string connectionString;

        public string ConnectionString
        {
            get { return connectionString; }
            set { connectionString = value; }
        }


        public ChucVuNVDAL()
        {
            connectionString = System.Configuration.ConfigurationManager.AppSettings["ConnectionString"];
        }

        public bool ThemChucVu(ChucVuNVDTO chucVu)
        {
            string query = string.Empty;
            query += "INSERT INTO CHUCVUNV";
            query += "VALUES (@MACHUCVU,@CHUCVU)";
            using (SqlConnection con = new SqlConnection(ConnectionString))
            {

                using (SqlCommand cmd = new SqlCommand())
                {
                    cmd.Connection = con;
                    cmd.CommandType = System.Data.CommandType.Text;
                    cmd.CommandText = query;
                    cmd.Parameters.AddWithValue("@MACHUCVU", chucVu.StrMaLoaiChucVu);
                    cmd.Parameters.AddWithValue("@CHUCVU", chucVu.StrTenLoaiChucVu);
                  
                    try
                    {
                        con.Open();
                        cmd.ExecuteNonQuery();
                        con.Close();
                        con.Dispose();
                    }
                    catch (Exception ex)
                    {
                        con.Close();
                        return false;
                    }
                }
            }
            return true;
        }

        public bool XoaChucVu(ChucVuNVDTO chucVu)
        {
            string query = string.Empty;
            query += "DELETE FROM CHUCVUNV WHERE [MACHUCVU] = @MACHUCVU";
            using (SqlConnection con = new SqlConnection(ConnectionString))
            {

                using (SqlCommand cmd = new SqlCommand())
                {
                    cmd.Connection = con;
                    cmd.CommandType = System.Data.CommandType.Text;
                    cmd.CommandText = query;
                    cmd.Parameters.AddWithValue("@MACHUCVU", chucVu.StrMaLoaiChucVu);
                    try
                    {
                        con.Open();
                        cmd.ExecuteNonQuery();
                        con.Close();
                        con.Dispose();
                    }
                    catch (Exception ex)
                    {
                        con.Close();
                        return false;
                    }
                }
            }
            return true;
        }

        public bool SuaChucVu(ChucVuNVDTO chucVu)
        {
            string query = string.Empty;
            query += "UPDATE CHUCVUNV SET CHUCVU = @CHUCVU WHERE MACHUCVU = @MACHUCVU";
            using (SqlConnection con = new SqlConnection(ConnectionString))
            {

                using (SqlCommand cmd = new SqlCommand())
                {
                    cmd.Connection = con;
                    cmd.CommandType = System.Data.CommandType.Text;
                    cmd.CommandText = query;
                    cmd.Parameters.AddWithValue("@MACHUCVU", chucVu.StrMaLoaiChucVu);
                    cmd.Parameters.AddWithValue("@CHUCVU", chucVu.StrTenLoaiChucVu);
                    
                    try
                    {
                        con.Open();
                        cmd.ExecuteNonQuery();
                        con.Close();
                        con.Dispose();
                    }
                    catch (Exception ex)
                    {
                        con.Close();
                        return false;
                    }
                }
            }
            return true;
        }

        public List<ChucVuNVDTO> Select()
        {
            string query = string.Empty;
            query += "SELECT MACHUCVU, CHUCVU ";
            query += "FROM CHUCVUNV";

            List<ChucVuNVDTO> ListChucVu = new List<ChucVuNVDTO>();

            using (SqlConnection con = new SqlConnection(ConnectionString))
            {

                using (SqlCommand cmd = new SqlCommand())
                {
                    cmd.Connection = con;
                    cmd.CommandType = System.Data.CommandType.Text;
                    cmd.CommandText = query;

                    try
                    {
                        con.Open();
                        SqlDataReader reader = null;
                        reader = cmd.ExecuteReader();
                        if (reader.HasRows == true)
                        {
                            while (reader.Read())
                            {
                                ChucVuNVDTO chucVu = new ChucVuNVDTO();
                                chucVu.StrMaLoaiChucVu = (reader["MACHUCVU"].ToString());
                                chucVu.StrTenLoaiChucVu = reader["CHUCVU"].ToString();
                                ListChucVu.Add(chucVu);
                            }
                        }

                        con.Close();
                        con.Dispose();
                    }
                    catch (Exception ex)
                    {
                        con.Close();
                        return null;
                    }
                }
            }
            return ListChucVu;
        }

    }
}
