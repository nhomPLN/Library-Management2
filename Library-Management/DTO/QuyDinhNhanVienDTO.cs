using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTO
{
    public class QuyDinhNhanVienDTO
    {
        private string maqd;
        private int tuoitoithieu;
        private int tuoitoida;
        private DateTime ngayra;
        private DateTime ngayketthuc;

        public string Maqd { get => maqd; set => maqd = value; }
        public int Tuoitoithieu { get => tuoitoithieu; set => tuoitoithieu = value; }
        public int Tuoitoida { get => tuoitoida; set => tuoitoida = value; }
        public DateTime Ngayra { get => ngayra; set => ngayra = value; }
        public DateTime Ngayketthuc { get => ngayketthuc; set => ngayketthuc = value; }
    }
}
