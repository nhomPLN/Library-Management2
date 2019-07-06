using DAL;
using DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace BUS
{
    public class PhieuMuonBUS
    {
        public PhieuMuonDAL phieuMuonDAL;
        List<PhieuMuonDTO> ListReceipt = new List<PhieuMuonDTO>();
        SachBUS sachBUS = new SachBUS();

        public PhieuMuonBUS()
        {
            phieuMuonDAL = new PhieuMuonDAL();
        }

        public bool ThemPhieuMuon(PhieuMuonDTO phieuMuonDTO)
        {
            bool result = phieuMuonDAL.ThemPhieuMuon(phieuMuonDTO);
            return result;
        }

        public bool XoaPhieuMuon(PhieuMuonDTO phieuMuonDTO)
        {
            bool result = phieuMuonDAL.XoaPhieuMuon(phieuMuonDTO);
            return result;
        }

        public bool SuaPhieuMuon(PhieuMuonDTO phieuMuonDTO)
        {
            bool result = phieuMuonDAL.SuaPhieuMuon(phieuMuonDTO);
            return result;
        }

        public List<PhieuMuonDTO> Select()
        {
            return phieuMuonDAL.Select();
        }

        public List<PhieuMuonDTO> SelectByKeyWord(string sKeyword)
        {
            return phieuMuonDAL.SelectByKeyWord(sKeyword);
        }

        public List<PhieuMuonDTO> DisplayListReceipt()
        {
            return ListReceipt = phieuMuonDAL.DisplayListReceipt();
        }

        public List<SachDTO> GetSelectedReceiptBooks(string ReceiptID)
        {
            List<SachDTO> results = new List<SachDTO>();

            if (ListReceipt.Count == 0)
            {
                ListReceipt = phieuMuonDAL.LoadListReceipt();
            }

            foreach (PhieuMuonDTO item in ListReceipt)
            {
                if (item.Mapm == ReceiptID)
                {
                    string[] masach = item.Masach.Split(' ');
                    for(int i=0; i<masach.Length; ++i)
                    {
                        results.Add(sachBUS.GetBookDetails(masach[i]));
                    }
                }
            }

            return results;
        }

        public List<PhieuMuonDTO> Search(string keyword, string selectedCategory)
        {
            List<PhieuMuonDTO> result = new List<PhieuMuonDTO>();

            if (ListReceipt.Count > 0)
            {
                foreach (PhieuMuonDTO item in ListReceipt)
                {
                    if (item.GetProperty(selectedCategory).Contains(keyword))
                    {
                        result.Add(item);
                    }
                }
            }
            else
            {
                phieuMuonDAL.Search(keyword, selectedCategory);
            }

            return result;
        }
    }
}
