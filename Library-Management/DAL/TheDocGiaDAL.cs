using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DTO;
namespace DAL
{
    public class TheDocGiaDAL
    {
        public TheDocGiaDAL()
        {

        }

        public DataTable LoadBangDocGia()
        {
            string query = @"SELECT STT, MADG, TENLOAIDG, HOTEN, NGAYSINH, DIACHI, EMAIL, NGAYLAPTHE, NGAYHETHAN, SOSACHDANGMUON, TONGTIENNO FROM DOCGIA INNER JOIN LOAIDOCGIA ON DOCGIA.MALOAIDG=LOAIDOCGIA.MALOAIDG";
            //string query = @"SELECT * FROM DOCGIA";
            return DataProvider.Instance.Excutequery(query);
        }

        public bool Them(TheDocGiaDTO tdgDTO)
        {
            string query = @"INSERT INTO DOCGIA (MADG, MALOAIDG, HOTEN, NGAYSINH, DIACHI, EMAIL, NGAYLAPTHE, NGAYHETHAN, SOSACHDANGMUON, TONGTIENNO, LUOTMUON) VALUES( @MADG , @MALOAIDG , @HOTEN , @NGAYSINH , @DIACHI , @EMAIL , @NGAYLAPTHE , @NGAYHETHAN , @SOSACHDANGMUON , @TONGTIENNO , @LUOTMUON )";
            object[] para = new object[] { tdgDTO.Madg, tdgDTO.Maloaidg, tdgDTO.Hoten, tdgDTO.Ngaysinh, tdgDTO.Diachi, tdgDTO.Email, tdgDTO.Ngaylapthe, tdgDTO.Ngayhethan, tdgDTO.Sosachdangmuon, tdgDTO.Tongtienno, tdgDTO.Luotmuon };
            return DataProvider.Instance.excuteNonQuery(query, para);
        }

        public bool Xoa(TheDocGiaDTO tdgDTO)
        {
            string query = @"DELETE DOCGIA WHERE MADG = @MADG ";
            object[] para = new object[] { tdgDTO.Madg };
            return DataProvider.Instance.excuteNonQuery(query, para);
        }

        public bool Sua(TheDocGiaDTO tdgDTO)
        {
            string query = @"UPDATE DOCGIA SET MALOAIDG = @MALOAIDG , HOTEN = @HOTEN , NGAYSINH = @NGAYSINH , DIACHI = @DIACHI , EMAIL = @EMAIL WHERE MADG = @MADG ";
            object[] para = new object[] { tdgDTO.Maloaidg, tdgDTO.Hoten, tdgDTO.Ngaysinh, tdgDTO.Diachi, tdgDTO.Email, tdgDTO.Madg };
            return DataProvider.Instance.excuteNonQuery(query, para);

        }

        public DataTable TimKiem(string chuoiTimKiem, string loaiTimKiem)
        {
            string query = @"SELECT * FROM DOCGIA WHERE " + loaiTimKiem + @" LIKE '%@CHUOI%'";
            object[] para = new object[] { chuoiTimKiem };
            return DataProvider.Instance.Excutequery(query, para);
        }

        public bool ResetSTT()
        {
            string query = @"DBCC CHECKIDENT (DOCGIA, RESEED, 0)";
            return DataProvider.Instance.excuteNonQuery(query);
        }

        public string GetNewSTT()
        {
            string query = @"SELECT MAX(STT) FROM DOCGIA";
            DataTable data = DataProvider.Instance.Excutequery(query);
            int a = 1;
            try
            {
                a = int.Parse(data.Rows[0][0].ToString());
                a += 1;
            }
            catch { }
            return a.ToString();
        }

        public DataTable GetDocGiaTraTre()
        {
            string query = @"SELECT * FROM DOCGIA WHERE ";
            return DataProvider.Instance.Excutequery(query);
        }

        public bool UpdateSachDangMuon(TheDocGiaDTO tdgDTO, int SoSachMuon)
        {
            string query = @"UPDATE DOCGIA SET SOSACHDANGMUON = SOSACHDANGMUON + " + SoSachMuon.ToString();
            query += " WHERE  MADG = @MADG ";
            object[] para = new object[] { tdgDTO.Madg };
            return DataProvider.Instance.excuteNonQuery(query, para);

        }


        public bool UpdateSachDangMuon_XoaPM(TheDocGiaDTO tdgDTO, int SoSachMuon)
        {
            string query = @"UPDATE DOCGIA SET SOSACHDANGMUON = SOSACHDANGMUON - " + SoSachMuon.ToString();
            query += " WHERE  MADG = @MADG ";
            object[] para = new object[] { tdgDTO.Madg };
            return DataProvider.Instance.excuteNonQuery(query, para);

        }


        public DataTable SelectByKeyword(string sKeyword)
        {
            string query = @"SELECT * FROM DOCGIA WHERE MADG = " + sKeyword.ToString();
            return DataProvider.Instance.Excutequery(query);
        }
    }
}



/////////////////////////////////////////////
///
