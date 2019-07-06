using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTO
{
    public class PhieuTraDTO
    {
        string mapm;
        string masach;
        string madg;
        DateTime ngaytra;
        int tienphat;

        public string Mapm { get => mapm; set => mapm = value; }
        public string Masach { get => masach; set => masach = value; }
        public string Madg { get => madg; set => madg = value; }
        public DateTime Ngaytra { get => ngaytra; set => ngaytra = value; }
        public int Tienphat { get => tienphat; set => tienphat = value; }

        public PhieuTraDTO() { }

        public PhieuTraDTO(string mapm1, string masach1, string madg1, DateTime ngaytra1, int tienphat1)
        {
            Mapm = mapm1;
            Masach = masach1;
            Madg = madg1;
            Ngaytra = ngaytra1;
            Tienphat = tienphat1;
        }

        public void NewReturnReceipt(DataRow row)
        {
            Mapm = row[0].ToString();
            Masach = row[1].ToString();
            Madg = row[2].ToString();
            Ngaytra = DateTime.Parse(row[3].ToString());
            Tienphat = int.Parse(row[4].ToString());
        }

        public int CalLibraryFine(int coefficient)
        {
            return coefficient * int.Parse((DateTime.Now.Date - Ngaytra.Date).TotalDays.ToString());
        }
    }
}
