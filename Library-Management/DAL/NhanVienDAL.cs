using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Configuration;
using DTO;
using System.Data.SqlClient;

namespace DAL
{
    public class NhanVienDAL
    {

        private string connectionString;

        public string ConnectionString
        {
            get { return connectionString; }
            set { connectionString = value; }
        }


        //public string ConnectionString { get => connectionString; set => connectionString = value; }

        public NhanVienDAL()
        {
            connectionString = System.Configuration.ConfigurationManager.AppSettings["ConnectionString"];
        }

        public bool ThemNV(NhanVienDTO NhanVienDTO)
        {

            string query = @"INSERT INTO NHANVIEN( HOTEN, NGAYSINH, MACHUCVU, NGAYVAOLAM, EMAIL, SDT, DIACHI, LUONG, TIENPHAT)";
            query += "VALUES( @HOTEN , @NGAYSINH , @MACHUCVU , @NGAYVAOLAM , @EMAIL , @SDT , @DIACHI , @LUONG , @TIENPHAT )";
            //object[] para = new object[] { NhanVienDTO.StrMaNhanVien, NhanVienDTO.StrHoTen, NhanVienDTO.DtNgaySinh, NhanVienDTO.StrMaChucVu, NhanVienDTO.DtNgayVaoLam, NhanVienDTO.StrEmail, NhanVienDTO.StrSoDT, NhanVienDTO.StrDiaChi, NhanVienDTO.FlLuong, NhanVienDTO.FlTienPhat };
            //bool result = DataProvider.Instance.excuteNonQuery(query, para);

            //return result;


            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    //command.Parameters.AddWithValue("@MANV", NhanVienDTO.StrMaNhanVien);
                    command.Parameters.AddWithValue("@HOTEN", NhanVienDTO.StrHoTen);
                    command.Parameters.AddWithValue("@NGAYSINH", NhanVienDTO.DtNgaySinh);
                    command.Parameters.AddWithValue("@MACHUCVU", NhanVienDTO.StrMaChucVu);
                    command.Parameters.AddWithValue("@NGAYVAOLAM", NhanVienDTO.DtNgayVaoLam);
                    command.Parameters.AddWithValue("@EMAIL", NhanVienDTO.StrEmail);
                    command.Parameters.AddWithValue("@SDT", NhanVienDTO.StrSoDT);
                    command.Parameters.AddWithValue("@DIACHI", NhanVienDTO.StrDiaChi);
                    command.Parameters.AddWithValue("@LUONG", NhanVienDTO.FlLuong);
                    command.Parameters.AddWithValue("@TIENPHAT", NhanVienDTO.FlTienPhat);
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

        public bool SuaNV(NhanVienDTO NhanVienDTO)
        {
            string query = string.Empty;

            query += "UPDATE [NHANVIEN] ";
            query += "SET [HOTEN] = @HOTEN , [NGAYSINH] = @NGAYSINH , [MACHUCVU] = @MACHUCVU , [NGAYVAOLAM] = @NGAYVAOLAM , ";
            query += "[EMAIL] = @EMAIL , [SDT] = @SDT , [DIACHI] = @DIACHI , [LUONG] = @LUONG , [TIENPHAT] = @TIENPHAT ";
            query += "WHERE [MANV] = @MANV";

            using (SqlConnection con = new SqlConnection(ConnectionString))
            {

                using (SqlCommand command = new SqlCommand())
                {
                    command.Connection = con;
                    command.CommandType = System.Data.CommandType.Text;
                    command.CommandText = query;

                    command.Parameters.AddWithValue("@MANV", NhanVienDTO.StrMaNhanVien);
                    command.Parameters.AddWithValue("@HOTEN", NhanVienDTO.StrHoTen);
                    command.Parameters.AddWithValue("@NGAYSINH", NhanVienDTO.DtNgaySinh);
                    command.Parameters.AddWithValue("@MACHUCVU", NhanVienDTO.StrMaChucVu);
                    command.Parameters.AddWithValue("@NGAYVAOLAM", NhanVienDTO.DtNgayVaoLam);
                    command.Parameters.AddWithValue("@EMAIL", NhanVienDTO.StrEmail);
                    command.Parameters.AddWithValue("@SDT", NhanVienDTO.StrSoDT);
                    command.Parameters.AddWithValue("@DIACHI", NhanVienDTO.StrDiaChi);
                    command.Parameters.AddWithValue("@LUONG", NhanVienDTO.FlLuong);
                    command.Parameters.AddWithValue("@TIENPHAT", NhanVienDTO.FlTienPhat);
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

        public bool XoaNV(NhanVienDTO NhanVienDTO)
        {
            string query = string.Empty;
            query += "DELETE FROM NHANVIEN WHERE MANV = @MANV";
            using (SqlConnection con = new SqlConnection(ConnectionString))
            {

                using (SqlCommand cmd = new SqlCommand())
                {
                    cmd.Connection = con;
                    cmd.CommandType = System.Data.CommandType.Text;
                    cmd.CommandText = query;
                    cmd.Parameters.AddWithValue("@MANV", NhanVienDTO.StrMaNhanVien);
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

        public bool XemDanhSachNV(NhanVienDTO NhanVienDTO)
        {
            return true;
        }

        public List<NhanVienDTO> Select()
        {
            string query = string.Empty;
            query += "SELECT MANV, HOTEN, NGAYSINH, CHUCVUNV.CHUCVU, NGAYVAOLAM, EMAIL, SDT, DIACHI, LUONG, TIENPHAT ";
            query += "FROM NHANVIEN ";
            query += "INNER JOIN CHUCVUNV ON NHANVIEN.MACHUCVU = CHUCVUNV.MACHUCVU ";
            query += "ORDER BY MANV  ASC";


            List<NhanVienDTO> ListNhanVien = new List<NhanVienDTO>();

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
                                NhanVienDTO nhanVien = new NhanVienDTO();
                                nhanVien.StrMaNhanVien = (reader["MANV"].ToString());
                                nhanVien.StrHoTen = reader["HOTEN"].ToString();


                                //Map Special Type to nhanVienDTO
                                string strNgaySinh = reader["NGAYSINH"].ToString();
                                nhanVien.DtNgaySinh = DateTime.Parse(strNgaySinh);


                                nhanVien.StrMaChucVu = reader["CHUCVU"].ToString();


                                //Map Special Type to nhanVienDTO
                                string strNgayVaoLam = reader["NGAYVAOLAM"].ToString();
                                nhanVien.DtNgayVaoLam = DateTime.Parse(strNgayVaoLam);


                                nhanVien.StrEmail = reader["EMAIL"].ToString();
                                nhanVien.StrSoDT = reader["SDT"].ToString();
                                nhanVien.StrDiaChi = reader["DIACHI"].ToString();


                                //Map Special Type to nhanVienDTO
                                string strLuong = reader["LUONG"].ToString();
                                nhanVien.FlLuong = float.Parse(strLuong);
                                string strTienPhat = reader["TIENPHAT"].ToString(); ;
                                nhanVien.FlTienPhat = float.Parse(strTienPhat);

                                //Add to List
                                ListNhanVien.Add(nhanVien);
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
            return ListNhanVien;
        }

        public List<NhanVienDTO> SelectByKeyWord(string sKeyword)
        {
            string query = string.Empty;
            query += " SELECT MANV, HOTEN, NGAYSINH, CHUCVUNV.CHUCVU, NGAYVAOLAM, EMAIL, SDT, DIACHI, LUONG, TIENPHAT ";
            query += " FROM NHANVIEN ";
            query += " INNER JOIN CHUCVUNV ON NHANVIEN.MACHUCVU = CHUCVUNV.MACHUCVU";
            query += " WHERE (MANV LIKE CONCAT('%',@sKeyword,'%'))";
            query += " OR (HOTEN LIKE CONCAT('%',@sKeyword,'%'))";
            query += " OR (CHUCVUNV.CHUCVU LIKE CONCAT('%',@sKeyword,'%'))";
            query += " ORDER BY MANV  ASC";


            List<NhanVienDTO> ListNhanVien = new List<NhanVienDTO>();

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
                                NhanVienDTO nhanVien = new NhanVienDTO();
                                nhanVien.StrMaNhanVien = (reader["MANV"].ToString());
                                nhanVien.StrHoTen = reader["HOTEN"].ToString();


                                //Map Special Type to nhanVienDTO
                                string strNgaySinh = reader["NGAYSINH"].ToString();
                                nhanVien.DtNgaySinh = DateTime.Parse(strNgaySinh);


                                nhanVien.StrMaChucVu = reader["CHUCVU"].ToString();


                                //Map Special Type to nhanVienDTO
                                string strNgayVaoLam = reader["NGAYVAOLAM"].ToString();
                                nhanVien.DtNgayVaoLam = DateTime.Parse(strNgayVaoLam);


                                nhanVien.StrEmail = reader["EMAIL"].ToString();
                                nhanVien.StrSoDT = reader["SDT"].ToString();
                                nhanVien.StrDiaChi = reader["DIACHI"].ToString();


                                //Map Special Type to nhanVienDTO
                                string strLuong = reader["LUONG"].ToString();
                                nhanVien.FlLuong = float.Parse(strLuong);
                                string strTienPhat = reader["TIENPHAT"].ToString(); ;
                                nhanVien.FlTienPhat = float.Parse(strTienPhat);

                                ListNhanVien.Add(nhanVien);
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
            return ListNhanVien;
        }

        public int Select_IDENT_CURRENT(int IdentCurrent)
        {
            
            string query = string.Empty;
            query += " SELECT IDENT_CURRENT('NHANVIEN') as LastID ";

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
                                IdentCurrent = Int32.Parse(reader["LastID"].ToString());
                               
                            }
                        }

                        con.Close();
                        con.Dispose();
                    }
                    catch (Exception ex)
                    {
                        con.Close();
                        
                    }
                }
            }
            return IdentCurrent;
        }
    }
}