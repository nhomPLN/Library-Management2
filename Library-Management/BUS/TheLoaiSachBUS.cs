using DAL;
using DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BUS
{
    public class TheLoaiSachBUS
    {
        List<TheLoaiSachDTO> ListTheLoai = new List<TheLoaiSachDTO>();
        Dictionary<string, string> TheLoai;
        TheLoaiSachDAL theloaisachDAL = new DAL.TheLoaiSachDAL();

        public string GetMaTheLoai(string ten)
        {
            return TheLoai[ten];
        }

        public void DictionaryGenerator()
        {
            TheLoai = new Dictionary<string, string>();
            ListTheLoai = theloaisachDAL.LoadTheLoai();

            foreach(TheLoaiSachDTO item in ListTheLoai)
            {
                TheLoai.Add(item.Tentheloai, item.Matheloai);
            }
        }

        public List<string> LoadListCategory()
        {
            List<string> ans = new List<string>();

            ListTheLoai=theloaisachDAL.LoadTheLoai();
            foreach(TheLoaiSachDTO item in ListTheLoai)
            {
                ans.Add(item.Tentheloai);
            }
            DictionaryGenerator();

            return ans;
        }
    }
}
