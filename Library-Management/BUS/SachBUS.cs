using DAL;
using DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BUS
{
    public class SachBUS
    {
        SachDAL sachdal = new SachDAL();
        List<SachDTO> listBooks = new List<SachDTO>();

        public List<SachDTO> ListBooks { get => listBooks; set => listBooks = value; }
        public SachDAL Sachdal { get => sachdal; set => sachdal = value; }

        public List<SachDTO> LoadListBooks()
        {
            ListBooks = sachdal.LoadListBooks();

            return ListBooks;
        }



        public int IDGenerator()
        {
            return int.Parse(ListBooks[ListBooks.Count-1].Masach) + 1;
        }

        public bool Add(SachDTO sachDTO)
        {
            return sachdal.Add(sachDTO);
        }

        public bool Edit(SachDTO sachDTO)
        {
            return sachdal.Edit(sachDTO);
        }

        public bool Delete(SachDTO sachDTO)
        {
            return sachdal.Delete(sachDTO);
        }

        public List<SachDTO> Search(SachDTO sachDTO, string Category)
        {
            List<SachDTO> ans = new List<SachDTO>();

            if (Category == "Ten")
            {
                foreach (SachDTO item in ListBooks)
                {
                    if (item.Tensach.Contains(sachDTO.Tensach))
                    {
                        ans.Add(item);
                    }
                }
            }
            else
            {
                foreach (SachDTO item in ListBooks)
                {
                    if (item.Masach.Contains(sachDTO.Masach))
                    {
                        ans.Add(item);
                    }
                }
            }
            

            return ans;
        }

        public List<SachDTO> SelectByKeyWord(string sKeyword)
        {
            return sachdal.SelectByKeyWord(sKeyword);
        }

        public List<SachDTO> LoadListBooks_ForfrmMuon()
        {
            ListBooks = sachdal.LoadListBooks_ForfrmMuon();

            return ListBooks;
        }

        public bool UpdateData(SachDTO sach)
        {
            return sachdal.UpdateLuotMuon_SoLuong(sach);
        }

        public bool UpdateData_XoaPM(SachDTO sach)
        {
            return sachdal.Update_SoLuong_Khi_XoaPM(sach);
        }

        public SachDTO GetBookDetails(string BookID)
        {
            SachDTO ans = new SachDTO();

            if (ListBooks.Count == 0)
            {
                ListBooks = LoadListBooks();
            }

            foreach (SachDTO item in ListBooks)
            {
                if (item.Masach == BookID)
                {
                    return item;
                }
            }

            return ans;
        }
    }
}
