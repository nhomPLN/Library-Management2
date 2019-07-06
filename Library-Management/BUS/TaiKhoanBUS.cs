using DAL;
using DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BUS
{
    public class TaiKhoanBUS
    {
        private TaiKhoanDAL TaiKhoanDAL;

        public TaiKhoanBUS()
        {
            TaiKhoanDAL = new TaiKhoanDAL();
        }


        public bool ThemTK(TaiKhoanDTO TaiKhoanDTO)
        {
            bool result = TaiKhoanDAL.ThemTK(TaiKhoanDTO);
            return result;
        }

        public bool XoaTK(TaiKhoanDTO TaiKhoanDTO)
        {
            bool result = TaiKhoanDAL.XoaTK(TaiKhoanDTO);
            return result;
        }

        public bool SuaTK(TaiKhoanDTO TaiKhoanDTO)
        {
            bool result = TaiKhoanDAL.SuaTK(TaiKhoanDTO);
            return result;
        }

        public List<TaiKhoanDTO> SelectByKeyWord(string sKeyword)
        {
            return TaiKhoanDAL.SelectByKeyWord(sKeyword);
        }

        
    }
}
