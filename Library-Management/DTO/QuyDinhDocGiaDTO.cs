using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTO
{
    public class QuyDinhDocGiaDTO
    {
        private string maqd;
        private int tuoitoithieu;
        private int tuoitoida;
        private int thoihanthe;
        private DateTime ngayra;
        private DateTime ngayketthuc;

        public int Tuoitoithieu { get => tuoitoithieu; set => tuoitoithieu = value; }
        public int Tuoitoida { get => tuoitoida; set => tuoitoida = value; }
        public int Thoihanthe { get => thoihanthe; set => thoihanthe = value; }
        public DateTime Ngayra { get => ngayra; set => ngayra = value; }
        public DateTime Ngayketthuc { get => ngayketthuc; set => ngayketthuc = value; }
        public string Maqd { get => maqd; set => maqd = value; }
    }
}
