using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTO
{
    public class QuyDinhPhieuMuonDTO
    {
        

        private string maqd;
        private int sosachtoida;
        private int songaymuontoida;
        private DateTime ngayra;
        private DateTime ngayketthuc;

        public string Maqd { get => maqd; set => maqd = value; }
        public int Sosachtoida { get => sosachtoida; set => sosachtoida = value; }
        public int Songaymuontoida { get => songaymuontoida; set => songaymuontoida = value; }
        public DateTime Ngayra { get => ngayra; set => ngayra = value; }
        public DateTime Ngayketthuc { get => ngayketthuc; set => ngayketthuc = value; }
    }
}
