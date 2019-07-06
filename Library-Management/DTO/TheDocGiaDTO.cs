using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTO
{
    public class TheDocGiaDTO
    {
        private string madg;
        private string maloaidg;
        private string hoten;
        private DateTime ngaysinh;
        private string diachi;
        private string email;
        private DateTime ngaylapthe;
        private DateTime ngayhethan;
        private int sosachdangmuon;
        private double tongtienno;
        private int luotmuon;

        public string Madg { get => madg; set => madg = value; }
        public string Hoten { get => hoten; set => hoten = value; }
        public DateTime Ngaysinh { get => ngaysinh; set => ngaysinh = value; }
        public string Diachi { get => diachi; set => diachi = value; }
        public string Email { get => email; set => email = value; }
        public DateTime Ngaylapthe { get => ngaylapthe; set => ngaylapthe = value; }
        public DateTime Ngayhethan { get => ngayhethan; set => ngayhethan = value; }
        public int Sosachdangmuon { get => sosachdangmuon; set => sosachdangmuon = value; }
        public double Tongtienno { get => tongtienno; set => tongtienno = value; }
        public string Maloaidg { get => maloaidg; set => maloaidg = value; }
        public int Luotmuon { get => luotmuon; set => luotmuon = value; }
    }
}
