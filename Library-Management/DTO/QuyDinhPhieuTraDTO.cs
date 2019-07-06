using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTO
{
    public class QuyDinhPhieuTraDTO
    {
        private string maqd;
        private int tienphat;
        private DateTime ngayra;
        private DateTime ngayketthuc;

        public string Maqd { get => maqd; set => maqd = value; }
        public DateTime Ngayra { get => ngayra; set => ngayra = value; }
        public DateTime Ngayketthuc { get => ngayketthuc; set => ngayketthuc = value; }
        public int Tienphat { get => tienphat; set => tienphat = value; }
    }
}
