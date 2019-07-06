using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTO
{
    public class NhanVienDTO
    {
        private string strMaNhanVien;
        private string strHoTen;
        private DateTime dtNgaySinh;
        private string strMaChucVu;
        private DateTime dtNgayVaoLam;
        private string strEmail;
        private string strDiaChi;
        private string strSoDT;
        private double flLuong;
        private float flTienPhat;

        public string StrMaNhanVien { get => strMaNhanVien; set => strMaNhanVien = value; }
        public string StrHoTen { get => strHoTen; set => strHoTen = value; }
        public DateTime DtNgaySinh { get => dtNgaySinh; set => dtNgaySinh = value; }
        public string StrMaChucVu { get => strMaChucVu; set => strMaChucVu = value; }
        public DateTime DtNgayVaoLam { get => dtNgayVaoLam; set => dtNgayVaoLam = value; }
        public string StrEmail { get => strEmail; set => strEmail = value; }
        public string StrDiaChi { get => strDiaChi; set => strDiaChi = value; }
        public string StrSoDT { get => strSoDT; set => strSoDT = value; }
        public double FlLuong { get => flLuong; set => flLuong = value; }
        public float FlTienPhat { get => flTienPhat; set => flTienPhat = value; }
    }
}
