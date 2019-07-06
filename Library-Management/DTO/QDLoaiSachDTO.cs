using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTO
{
    public class QDLoaiSachDTO
    {
        private string matheloai;
        private string tentheloai;

        public string Matheloai { get => matheloai; set => matheloai = value; }
        public string Tentheloai { get => tentheloai; set => tentheloai = value; }
    }
}
