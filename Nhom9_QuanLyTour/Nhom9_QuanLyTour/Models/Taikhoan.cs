using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Nhom9_QuanLyTour.Models
{
    public class Taikhoan
    {
        public string MaNhanVien { get; set; }
        public string TenTaiKhoan { get; set; }
        public string MatKhau { get; set; }
      

        public Taikhoan()
        { }
        public Taikhoan(String MaNhanVien, string TenTaiKhoan, string MatKhau)
        {
            this.MaNhanVien = MaNhanVien;
            this.TenTaiKhoan = TenTaiKhoan;
            this.MatKhau = MatKhau;
          
        }
        public Taikhoan(Taikhoan taikhoan)
        {
            this.MaNhanVien = taikhoan.MaNhanVien;
            this.TenTaiKhoan = taikhoan.TenTaiKhoan;
            this.MatKhau = taikhoan.MatKhau;
           
        }
    }
}
