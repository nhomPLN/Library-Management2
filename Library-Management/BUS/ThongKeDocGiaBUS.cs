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
    public class ThongKeDocGiaBUS
    {
        private ThongKeDocGiaDAL tkdgDAL;
        public ThongKeDocGiaBUS()
        {
            tkdgDAL = new ThongKeDocGiaDAL();
        }
        public DataTable GetDocGiaTraTre()
        {
            return tkdgDAL.GetDocGiaTraTre();
        }

        public DataTable GetDocGiaLuotMuonNhieu()
        {
            return tkdgDAL.GetDocGiaLuotMuonNhieu();
        }
    }
}
