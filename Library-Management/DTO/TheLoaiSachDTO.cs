using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTO
{
    public class TheLoaiSachDTO
    {
        string matheloai;
        string tentheloai;

        public string Matheloai { get => matheloai; set => matheloai = value; }
        public string Tentheloai { get => tentheloai; set => tentheloai = value; }

        public void NewCategory(DataRow temp)
        {
            Matheloai = temp[0].ToString();
            Tentheloai = temp[1].ToString();
        }
    }
}
