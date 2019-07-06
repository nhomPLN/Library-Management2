using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DTO;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;

namespace DAL
{
    public class SachDAL
    {
        string ConnectionString = ConfigurationManager.AppSettings["ConnectionString"];
        DataProvider dataprovider = new DataProvider();

        public List<SachDTO> LoadListBooks()
        {
            List<SachDTO> ans = new List<SachDTO>();
            string query = "SELECT MASACH, TENSACH, TACGIA, TENTHELOAI, NXB, NAMXB, NGAYNHAP, DONGIA, SACH.SOLUONG, LUOTMUON";
            query += " FROM SACH, THELOAISACH";
            query += " WHERE SACH.MATHELOAI=THELOAISACH.MATHELOAI";
            query += " ORDER BY THELOAISACH.MATHELOAI  ASC";
            DataTable temp = dataprovider.Excutequery(query);

            for (int i = 0; i < temp.Rows.Count; ++i)
            {
                SachDTO tmp = new SachDTO();

                tmp.NewBook(temp.Rows[i]);
                ans.Add(tmp);
            }

            return ans;
        }

        public bool Edit(SachDTO sachDTO)
        {
            string query = string.Empty;
            object[] listpara = { sachDTO.Tensach, sachDTO.Tacgia, sachDTO.Theloai, sachDTO.Nxb, sachDTO.Namxb, sachDTO.Ngaynhap, sachDTO.Dongia, sachDTO.Soluong, sachDTO.Luotmuon, sachDTO.Masach };

            query += "UPDATE SACH ";
            query += "SET TENSACH = @Tensach , TACGIA = @Tacgia , MATHELOAI = @Matheloai , NXB = @Nxb , NAMXB = @Namxb , ";
            query += "NGAYNHAP = @Ngaynhap , DONGIA = @Dongia , SACH.SOLUONG = @Soluong , LUOTMUON = @Luotmuon ";
            query += "WHERE MASACH = @Masach ";
            
            return dataprovider.excuteNonQuery(query, listpara);
        }

        public bool UpdateSoLuong_LuotMuon(SachDTO sachDTO)
        {
            string query = string.Empty;
            object[] listpara = { sachDTO.Soluong, sachDTO.Luotmuon, sachDTO.Masach };

            query += "UPDATE SACH ";
            query += "SET SOLUONG = SOLUONG - 1 , LUOTMUON = LUOTMUON + 1 ";
            query += "WHERE MASACH = @Masach ";

            return dataprovider.excuteNonQuery(query, listpara);
        }

        public bool Add(SachDTO sachDTO)
        {
            string query = string.Empty;
            object[] listpara = { sachDTO.Masach, sachDTO.Tensach, sachDTO.Tacgia, sachDTO.Theloai, sachDTO.Nxb, sachDTO.Namxb, sachDTO.Ngaynhap, sachDTO.Dongia, sachDTO.Soluong, sachDTO.Luotmuon };

            query += "INSERT INTO SACH (MASACH, TENSACH, TACGIA, MATHELOAI, NXB, NAMXB, NGAYNHAP, DONGIA, SOLUONG, LUOTMUON)";
            query += " VALUES ( @MaSach , @TenSach , @TacGia , @MaTheLoai , @NXB , @NamXB , @NgayNhap , @DonGia , @SoLuong , @LuotMuon )";

            return dataprovider.excuteNonQuery(query, listpara);
        }

        public bool Delete(SachDTO sachDTO)
        {
            string query = string.Empty;
            object[] para = { sachDTO.Masach };

            query += "DELETE FROM SACH WHERE MASACH = @Masach";

            return dataprovider.excuteNonQuery(query, para);
        }

        public DataTable Search(SachDTO sachDTO)
        {
            string query = string.Empty;
            object[] para = { sachDTO.Tensach };

            query += "SELECT * FROM SACH WHERE TENSACH LIKE %@Tensach%";
            
            return dataprovider.Excutequery(query, para);
        }



        //--------------


        public List<SachDTO> LoadListBooks_ForfrmMuon()
        {
            List<SachDTO> ans = new List<SachDTO>();
            string query = "SELECT MASACH, TENSACH, TACGIA, TENTHELOAI, NXB, NAMXB";
            query += " FROM SACH, THELOAISACH";
            query += " WHERE SACH.MATHELOAI=THELOAISACH.MATHELOAI";
            query += " AND (SOLUONG > = 1)";
            query += " ORDER BY THELOAISACH.MATHELOAI  ASC";
            DataTable temp = dataprovider.Excutequery(query);

            for (int i = 0; i < temp.Rows.Count; ++i)
            {
                SachDTO tmp = new SachDTO();

                tmp.NewBook(temp.Rows[i]);
                ans.Add(tmp);
            }

            return ans;
        }

        //-------------



        public List<SachDTO> SelectByKeyWord(string sKeyword)
        {
            string query = string.Empty;
            query += " SELECT MASACH, TENSACH, TACGIA, THELOAISACH.TENTHELOAI ";
            query += " FROM SACH INNER JOIN THELOAISACH ";
            query += " ON SACH.MATHELOAI = THELOAISACH.MATHELOAI";
            query += " WHERE (MASACH LIKE CONCAT('%',@sKeyword,'%'))";
            query += " OR (TENSACH LIKE CONCAT('%',@sKeyword,'%'))";
            query += " OR (TACGIA LIKE CONCAT('%',@sKeyword,'%'))";
            query += " OR (THELOAISACH.TENTHELOAI LIKE CONCAT('%',@sKeyword,'%'))";
            query += " ORDER BY THELOAISACH.MATHELOAI  ASC";


            List<SachDTO> ListSach = new List<SachDTO>();

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
                                SachDTO sachDTO = new SachDTO();
                                sachDTO.Masach = (reader["MASACH"].ToString());
                                sachDTO.Tensach = reader["TENSACH"].ToString();
                                sachDTO.Theloai = reader["TENTHELOAI"].ToString();
                                sachDTO.Tacgia = reader["TACGIA"].ToString();
                                

                                ListSach.Add(sachDTO);

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
            return ListSach;
        }

        public bool UpdateLuotMuon_SoLuong(SachDTO sachDTO)
        {
            string query = string.Empty;
            object[] para = { sachDTO.Masach };

            query += "UPDATE SACH SET LUOTMUON = LUOTMUON +1, SOLUONG = SOLUONG - 1 WHERE MASACH = @Masach ";

            return dataprovider.excuteNonQuery(query, para);
        }

        public bool Update_SoLuong_Khi_XoaPM(SachDTO sachDTO)
        {
            string query = string.Empty;
            object[] para = { sachDTO.Masach };

            query += "UPDATE SACH SET  SOLUONG = SOLUONG + 1 WHERE MASACH = @Masach ";

            return dataprovider.excuteNonQuery(query, para);
        }
    }
}
