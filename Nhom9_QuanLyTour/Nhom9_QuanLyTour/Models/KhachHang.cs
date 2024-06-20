using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Nhom9_QuanLyTour.Models
{
    public class KhachHang
    {
        public string MaKhachHang{ get; set; }
        public string HoTen { get; set; }
        public string GioiTinh { get; set; }
        public string DienThoai { get; set; }
        public string DiaChi { get; set; }
        
        public KhachHang()
        { }
        public KhachHang(String MaKhachHang, string HoTen, string GioiTinh,string DienThoai,string DiaChi)
        {
            this.MaKhachHang = MaKhachHang;
            this.HoTen  = HoTen;
            this.GioiTinh = GioiTinh;
            this.DienThoai = DienThoai;
            this.DiaChi = DiaChi;
        }
        public KhachHang(KhachHang khachHang) 
        {
            this.MaKhachHang = khachHang.MaKhachHang;
            this.HoTen = khachHang.HoTen;
            this.GioiTinh = khachHang.GioiTinh;
            this.DienThoai = khachHang.DienThoai;
            this.DiaChi = khachHang.DiaChi;
        }

    }
}
