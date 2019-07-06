using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
namespace DTO
{
    public class PhieuMuonDTO
    {
        string mapm;
       // string hoten;
        DateTime ngaymuon;
        DateTime hantra;
        string masach;
        string madg;
        int soluong;
        decimal mucphat;
        string hoten;

        public string Mapm { get => mapm; set => mapm = value; }
        public string Masach { get => masach; set => masach = value; }
        public string Madg { get => madg; set => madg = value; }
        public DateTime Ngaymuon { get => ngaymuon; set => ngaymuon = value; }
        public DateTime Hantra { get => hantra; set => hantra = value; }
       // public string Hoten { get => hoten; set => hoten = value; }
        public int Soluong { get => soluong; set => soluong = value; }
        public decimal Mucphat { get => mucphat; set => mucphat = value; }
        public string Hoten { get => hoten; set => hoten = value; }

        public PhieuMuonDTO() { }

        public PhieuMuonDTO(string mapm1, string masach1, string madg1, DateTime ngaymuon1, DateTime hantra1, string hoten1 = "", decimal mucphat1 = 0)
        {
            Mapm = mapm1;
            Masach = masach1;
            Madg = madg1;
            Ngaymuon = ngaymuon1;
            Hantra = hantra1;
            Hoten = hoten1;
            Mucphat = mucphat1;
        }

        public string GetProperty(string property)
        {
            string ans = string.Empty;

            if (property == "Tên đọc giả")
            {
               // ans = Hoten;
            }
            if (property == "Mã phiếu mượn")
            {
                ans = Mapm;
            }

            return ans;
        }

        public PhieuMuonDTO(DataRow row)
        {
            Mapm = row[0].ToString();
            Masach = row[1].ToString();
            Madg = row[2].ToString();
            Ngaymuon = DateTime.Parse(row[3].ToString());
            Hantra = DateTime.Parse(row[4].ToString());
            Hoten = row[5].ToString();
            Soluong = int.Parse(row[6].ToString());
            string tmp = row[7].ToString();
            Mucphat = decimal.Parse(tmp);
          
        }

        public void NewReceipt(DataRow row)
        {
            Mapm = row[0].ToString();
            Masach = row[1].ToString();
            Madg = row[2].ToString();
            Ngaymuon = DateTime.Parse(row[3].ToString());
            Hantra = DateTime.Parse(row[4].ToString());
            Soluong= Int32.Parse(row[5].ToString());
        }

        public bool IsOverdue()
        {
            return (DateTime.Now <= Hantra);
        }

        public DateTime CalDueDate(QuyDinhPhieuMuonDTO rule)
        {
            return Ngaymuon.AddDays(rule.Songaymuontoida);
        }

    }
}