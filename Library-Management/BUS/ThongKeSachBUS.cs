using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DAL;
using DTO;
namespace BUS
{
    public class ThongKeSachBUS
    {
        private ThongKeSachDAL tksDAL;
        public ThongKeSachBUS()
        {
            tksDAL = new ThongKeSachDAL();
        }

        public DataTable GetSachDuocMuonNhieu()
        {
            return tksDAL.GetSachDuocMuonNhieu();
        }

        public DataTable GetLuotMuonSachTheoTheLoai()
        {
            return tksDAL.GetLuotMuonSachTheoTheLoai();
        }


    }
}
