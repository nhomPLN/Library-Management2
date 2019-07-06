using DAL;
using DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BUS
{
    public class ChucVuNVBUS
    {
         private ChucVuNVDAL ChucVuDAL;

        public ChucVuNVBUS()
        {
            ChucVuDAL = new ChucVuNVDAL();
        }


        public bool ThemNV(ChucVuNVDTO ChucVuDTO)
        {
            bool result = ChucVuDAL.ThemChucVu(ChucVuDTO);
            return result;
        }

        public bool XoaNV(ChucVuNVDTO ChucVuDTO)
        {
            bool result = ChucVuDAL.SuaChucVu(ChucVuDTO);
            return result;
        }

        public bool SuaNV(ChucVuNVDTO ChucVuDTO)
        {
            bool result = ChucVuDAL.XoaChucVu(ChucVuDTO);
            return result;
        }

        public List<ChucVuNVDTO> Select()
        {
            return ChucVuDAL.Select();
        }
    }
}
