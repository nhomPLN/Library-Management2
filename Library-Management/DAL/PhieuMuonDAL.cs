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
    public class PhieuMuonDAL
    {
        string ConnectionString = ConfigurationManager.AppSettings["ConnectionString"];
        DataProvider dataprovider = new DataProvider();

        public List<PhieuMuonDTO> LoadListReceipt()
        {
            List<PhieuMuonDTO> ans = new List<PhieuMuonDTO>();
            string query = string.Empty;

            query += "SELECT temp.MAPM, MASACH, PHIEUMUON.MADG, NGAYMUON, HANTRA, DOCGIA.HOTEN, temp.SOLUONG, MUCPHAT ";
            query += "FROM PHIEUMUON, DOCGIA, (SELECT MAPM, count(MASACH) as SOLUONG FROM PHIEUMUON GROUP BY MAPM) as temp ";
            query += "WHERE DOCGIA.MADG = PHIEUMUON.MADG and PHIEUMUON.MAPM = temp.MAPM";
            DataTable temp = dataprovider.Excutequery(query);

            if (temp == null)
            {
                return ans;
            }

            for (int i = 0; i < temp.Rows.Count; ++i)
            {
                PhieuMuonDTO receipt = new PhieuMuonDTO(temp.Rows[i]);

                ans.Add(receipt);
            }

            return ans;
        }

        public bool DeleteReceipt(string bookID, string receiptID)
        {
            string query = string.Empty;
            object[] para = { receiptID, bookID };

            query += "DELETE FROM  PHIEUMUON WHERE MAPM = @MAPM AND MASACH = @MASACH";

            return dataprovider.excuteNonQuery(query, para);
        }

        public List<PhieuMuonDTO> ConvertToList(DataTable temp)
        {
            List<PhieuMuonDTO> ans = new List<PhieuMuonDTO>();

            if (temp == null)
            {
                return ans;
            }

            for (int i = 0; i < temp.Rows.Count; ++i)
            {
                PhieuMuonDTO receipt = new PhieuMuonDTO(temp.Rows[i]);

                if (ans.Count == 0)
                {
                    ans.Add(receipt);
                }
                else if (receipt.Mapm != ans[ans.Count - 1].Mapm)
                {
                    ans.Add(receipt);
                }
            }

            return ans;
        }

        public List<PhieuMuonDTO> DisplayListReceipt()
        {
            string query = string.Empty;

            query += "SELECT temp.MAPM, MASACH, PHIEUMUON.MADG, NGAYMUON, HANTRA, DOCGIA.HOTEN, temp.SOLUONG, MUCPHAT ";
            query += "FROM PHIEUMUON, DOCGIA, (SELECT MAPM, count(MASACH) as SOLUONG FROM PHIEUMUON GROUP BY MAPM) as temp ";
            query += "WHERE DOCGIA.MADG = PHIEUMUON.MADG and PHIEUMUON.MAPM = temp.MAPM";
            DataTable temp = dataprovider.Excutequery(query);

            return ConvertToList(temp);
        }

        public List<PhieuMuonDTO> Search(string keyword, string selectedCategory)
        {
            string query = string.Empty;
            object[] listpara = { keyword };
            List<PhieuMuonDTO> result = new List<PhieuMuonDTO>();
            DataTable temp = new DataTable();

            if (selectedCategory == "Tên đọc giả")
            {
                query += "SELECT temp.MAPM, MASACH, PHIEUMUON.MADG, NGAYMUON, HANTRA, DOCGIA.HOTEN, SOLUONG, MUCPHAT ";
                query += "FROM PHIEUMUON, DOCGIA, (SELECT MAPM, count(MASACH) as SOLUONG FROM PHIEUMUON GROUP BY MAPM) as temp ";
                query += "WHERE DOCGIA.MADG = PHIEUMUON.MADG and PHIEUMUON.MAPM = temp.MAPM AND DOCGIA.HOTEN LIKE %@Tendg%";

                temp = dataprovider.Excutequery(query, listpara);
            }
            if (selectedCategory == "Mã phiếu mượn")
            {
                query += "SELECT temp.MAPM, MASACH, PHIEUMUON.MADG, NGAYMUON, HANTRA, DOCGIA.HOTEN, SOLUONG, MUCPHAT ";
                query += "FROM PHIEUMUON, DOCGIA, (SELECT MAPM, count(MASACH) as SOLUONG FROM PHIEUMUON GROUP BY MAPM) as temp ";
                query += "WHERE DOCGIA.MADG = PHIEUMUON.MADG and PHIEUMUON.MAPM = temp.MAPM AND temp.MAPM LIKE %@Mapm%";

                temp = dataprovider.Excutequery(query, listpara);
            }

            return ConvertToList(temp);
        }

        public List<PhieuMuonDTO> Select()
        {
            List<PhieuMuonDTO> ListPhieuMuon = new List<PhieuMuonDTO>();

            string query = "SELECT[MAPM],[MASACH],[MADG],[NGAYMUON],[HANTRA] ,[SOLUONG] FROM[PHIEUMUON]";


            DataTable DtPhieuMuon = DataProvider.Instance.Excutequery(query);

            foreach(DataRow row in DtPhieuMuon.Rows)
            {
                PhieuMuonDTO phieuMuon= new PhieuMuonDTO();

                phieuMuon.NewReceipt(row);
                ListPhieuMuon.Add(phieuMuon);
            }
          
            return ListPhieuMuon;
        }

        public List<PhieuMuonDTO> SelectByKeyWord(string sKeyword)
        {
            string query = string.Empty;
            query = "SELECT[MAPM],[MASACH],[MADG],[NGAYMUON],[HANTRA] ,[SOLUONG] FROM[PHIEUMUON]";
            query += " WHERE (MADG LIKE CONCAT('%',@sKeyword,'%'))";
            query += " OR (MAPM LIKE CONCAT('%',@sKeyword,'%'))";
            query += " OR (NGAYMUON LIKE CONCAT('%',@sKeyword,'%'))";
            query += " OR (HANTRA LIKE CONCAT('%',@sKeyword,'%'))";
            query += " ORDER BY MAPM  ASC";


            List<PhieuMuonDTO> ListPhieuMuon = new List<PhieuMuonDTO>();

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
                                PhieuMuonDTO PhieuMuon = new PhieuMuonDTO();
                                PhieuMuon.Mapm = (reader["MAPM"].ToString());
                                PhieuMuon.Masach = reader["MASACH"].ToString();
                                PhieuMuon.Madg = reader["MADG"].ToString();

                                string strNgayMuon = reader["NGAYMUON"].ToString();
                                PhieuMuon.Ngaymuon = DateTime.Parse(strNgayMuon);

                                string strNgayTra = reader["HANTRA"].ToString();
                                PhieuMuon.Hantra = DateTime.Parse(strNgayTra);

                                PhieuMuon.Soluong = Int32.Parse(reader["SOLUONG"].ToString());



                                ListPhieuMuon.Add(PhieuMuon);

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
            return ListPhieuMuon;
        }



        public List<PhieuMuonDTO> Select_MaSach_By_MaPhieuMuon(string sKeyword)
        {
            List<PhieuMuonDTO> ListPhieuMuon = new List<PhieuMuonDTO>();

            string query = "SELECT[MAPM],[MASACH],[MADG],[NGAYMUON],[HANTRA] FROM[PHIEUMUON] ";
            query += "WHERE MAPM = @sKeyword ";

            DataTable DtPhieuMuon = dataprovider.Excutequery(query);

            foreach (DataRow row in DtPhieuMuon.Rows)
            {
                PhieuMuonDTO phieuMuon = new PhieuMuonDTO();

                phieuMuon.NewReceipt(row);
                ListPhieuMuon.Add(phieuMuon);
            }

            return ListPhieuMuon;

        }

        public bool SuaPhieuMuon(PhieuMuonDTO phieuMuon)
        {
            string query = string.Empty;
            object[] listpara = {  phieuMuon.Masach, phieuMuon.Madg, phieuMuon.Soluong , phieuMuon.Mapm };

            query += "UPDATE PHIEUMUON ";
            query += "SET MASACH = @MASACH , MADG = @MADG , SOLUONG = @SOLUONG ";
            query += " WHERE MAPM = @MAPM";


            return dataprovider.excuteNonQuery(query, listpara);
        }

        public bool ThemPhieuMuon(PhieuMuonDTO phieuMuon)
        {
            string query = string.Empty;
            object[] listpara = { phieuMuon.Masach, phieuMuon.Madg, phieuMuon.Ngaymuon, phieuMuon.Hantra, phieuMuon.Soluong, phieuMuon.Mucphat};

            query += "INSERT INTO PHIEUMUON(MASACH, MADG, NGAYMUON, HANTRA, SOLUONG, MUCPHAT) ";
            query += "VALUES ( @MASACH , @MADG , @NGAYMUON , @HANTRA , @SOLUONG , @MUCPHAT  )";

            return dataprovider.excuteNonQuery(query, listpara);
        }

        public bool XoaPhieuMuon(PhieuMuonDTO phieuMuon)
        {
            string query = string.Empty;
            object[] para = { phieuMuon.Mapm };

            query += "DELETE FROM  PHIEUMUON WHERE MAPM = @MAPM";

            return dataprovider.excuteNonQuery(query, para);
        }

    }
}
