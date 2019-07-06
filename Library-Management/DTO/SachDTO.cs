using System;
using System.Collections.Generic;
using System.Data;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTO
{
    public class SachDTO
    {
        string masach;
        string tensach;
        string tacgia;
        string theloai;
        string nxb;
        int namxb;
        DateTime ngaynhap;
        int dongia;
        int soluong;
        int luotmuon;

        public string Tensach { get => tensach; set => tensach = value; }
        public string Tacgia { get => tacgia; set => tacgia = value; }
        public string Theloai { get => theloai; set => theloai = value; }
        public string Nxb { get => nxb; set => nxb = value; }
        public int Namxb { get => namxb; set => namxb = value; }
        public DateTime Ngaynhap { get => ngaynhap; set => ngaynhap = value; }
        public int Dongia { get => dongia; set => dongia = value; }
        public int Soluong { get => soluong; set => soluong = value; }
        public int Luotmuon { get => luotmuon; set => luotmuon = value; }
        public string Masach { get => masach; set => masach = value; }

        public void NewBook(DataRow temp)
        {
            Masach = temp[0].ToString();
            Tensach = temp[1].ToString();
            Tacgia = temp[2].ToString();
            Theloai = temp[3].ToString();
            Nxb = temp[4].ToString();
            Namxb = int.Parse(temp[5].ToString());
            Ngaynhap = DateTime.Parse(temp[6].ToString());
            Dongia = int.Parse(temp[7].ToString(), NumberStyles.Currency);
            Soluong = int.Parse(temp[8].ToString());
            Luotmuon = int.Parse(temp[9].ToString());
        }

        public bool IsValid()
        {
            int current_year = DateTime.Now.Year;

            return ((current_year - namxb) <= 8);
        }
    }
}
