using DTO;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL
{
    public class TaiKhoanDAL
    {
        private string connectionString;

        public string ConnectionString
        {
            get { return connectionString; }
            set { connectionString = value; }
        }


        //public string ConnectionString { get => connectionString; set => connectionString = value; }

        public TaiKhoanDAL()
        {
            connectionString = System.Configuration.ConfigurationManager.AppSettings["ConnectionString"];
        }

        public bool ThemTK(TaiKhoanDTO TaiKhoanDTO)
        {
           

            string query = @"INSERT INTO TAIKHOANNV (TENTK, MATKHAU, MACHUCVU, MANV) ";
            query += "VALUES( @TENTK , @MATKHAU , @MACHUCVU , @MANV )";
            
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    //command.Parameters.AddWithValue("@MANV", NhanVienDTO.StrMaNhanVien);
                    command.Parameters.AddWithValue("@TENTK", TaiKhoanDTO.StrTenTk);
                    command.Parameters.AddWithValue("@MATKHAU", TaiKhoanDTO.StrMatKhau);
                    command.Parameters.AddWithValue("@MACHUCVU", TaiKhoanDTO.StrMaChucVu);
                    command.Parameters.AddWithValue("@MANV", TaiKhoanDTO.IntMaNV);
                   
                    try
                    {
                        connection.Open();
                        command.ExecuteNonQuery();
                        connection.Close();
                        connection.Dispose();
                    }
                    catch (Exception ex)
                    {
                        connection.Close();
                        return false;
                    }
                }

            }

            return true;

        }

        public bool SuaTK(TaiKhoanDTO TaiKhoanDTO)
        {
            string query = string.Empty;

            query+= "UPDATE TAIKHOANNV ";
            query += "SET TENTK = @TENTK, MATKHAU = @MATKHAU, MACHUCVU = @MACHUCVU ";
            query += "WHERE MANV = @MANV";

            using (SqlConnection con = new SqlConnection(ConnectionString))
            {

                using (SqlCommand command = new SqlCommand())
                {
                    command.Connection = con;
                    command.CommandType = System.Data.CommandType.Text;
                    command.CommandText = query;

                    //command.Parameters.AddWithValue("@MANV", NhanVienDTO.StrMaNhanVien);
                    command.Parameters.AddWithValue("@TENTK", TaiKhoanDTO.StrTenTk);
                    command.Parameters.AddWithValue("@MATKHAU", TaiKhoanDTO.StrMatKhau);
                    command.Parameters.AddWithValue("@MACHUCVU", TaiKhoanDTO.StrMaChucVu);
                    command.Parameters.AddWithValue("@MANV", TaiKhoanDTO.IntMaNV);
                    command.Parameters.AddWithValue("@MATK", TaiKhoanDTO.IntMaTk);
                  
                    try
                    {
                        con.Open();
                        command.ExecuteNonQuery();
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
        
        public bool XoaTK(TaiKhoanDTO TaiKhoanDTO)
        {
            string query = string.Empty;
            query += "DELETE FROM TAIKHOANNV WHERE MANV = @MANV";
            using (SqlConnection con = new SqlConnection(ConnectionString))
            {

                using (SqlCommand cmd = new SqlCommand())
                {
                    cmd.Connection = con;
                    cmd.CommandType = System.Data.CommandType.Text;
                    cmd.CommandText = query;
                    cmd.Parameters.AddWithValue("@MANV", TaiKhoanDTO.IntMaNV);
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

        

        public List<TaiKhoanDTO> SelectByKeyWord(string sKeyword)
        {
            string query = string.Empty;
            query += "SELECT TENTK, MATKHAU, MATK, MANV, MACHUCVU ";
            query += "FROM TAIKHOANNV ";
            query += " WHERE MANV = @sKeyword";


            List<TaiKhoanDTO> ListTaiKhoan = new List<TaiKhoanDTO>();

            using (SqlConnection con = new SqlConnection(ConnectionString))
            {

                using (SqlCommand cmd = new SqlCommand())
                {
                    cmd.Connection = con;
                    cmd.CommandType = System.Data.CommandType.Text;
                    cmd.CommandText = query;
                    cmd.Parameters.AddWithValue("@sKeyword", sKeyword);
                    try
                    {
                        con.Open();
                        SqlDataReader reader = null;
                        reader = cmd.ExecuteReader();
                        if (reader.HasRows == true)
                        {
                            while (reader.Read())
                            {
                                TaiKhoanDTO taiKhoan = new TaiKhoanDTO();
                                taiKhoan.IntMaTk = Int32.Parse(reader["MATK"].ToString());
                                taiKhoan.StrTenTk = reader["TENTK"].ToString();
                                taiKhoan.StrMatKhau = reader["MATKHAU"].ToString();
                                taiKhoan.StrMaChucVu = reader["MACHUCVU"].ToString();
                                taiKhoan.IntMaNV = Int32.Parse(reader["MANV"].ToString());

                               
                                //Add to List
                                ListTaiKhoan.Add(taiKhoan);
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
            return ListTaiKhoan;
        }
    }
}
