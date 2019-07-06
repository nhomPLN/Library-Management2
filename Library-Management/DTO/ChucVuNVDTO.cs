using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTO
{
    public class ChucVuNVDTO
    {
        private string strMaLoaiChucVu;
        private string strTenLoaiChucVu;

        public string StrMaLoaiChucVu { get => strMaLoaiChucVu; set => strMaLoaiChucVu = value; }
        public string StrTenLoaiChucVu { get => strTenLoaiChucVu; set => strTenLoaiChucVu = value; }
    }
}
