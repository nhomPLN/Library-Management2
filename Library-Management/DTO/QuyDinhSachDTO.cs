using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTO
{
    public class QuyDinhSachDTO
    {
        private string maqd;
        private int thoihansach;
        private DateTime ngayra;
        private DateTime ngayketthuc;

        public string Maqd { get => maqd; set => maqd = value; }
        public int Thoihansach { get => thoihansach; set => thoihansach = value; }
        public DateTime Ngayra { get => ngayra; set => ngayra = value; }
        public DateTime Ngayketthuc { get => ngayketthuc; set => ngayketthuc = value; }
    }
}
