using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Nhom9_QuanLyTour.Models
{
    public class NhanVien
    {
        public string MaNhanVien { get; set; }
        public string HoTen { get; set; }
        public string GioiTinh { get; set; }
        public string DienThoai { get; set; }
        public string DiaChi { get; set; }
        public string ChucVu { get; set; }

        public NhanVien()
        { }
        public NhanVien(String MaNhanVien, string HotTen, string GioiTinh, string DienThoai, string DiaChi)
        {
            this.MaNhanVien = MaNhanVien;
            this.HoTen = HoTen;
            this.GioiTinh = GioiTinh;
            this.DienThoai = DienThoai;
            this.DiaChi = DiaChi;
        }
        public NhanVien(NhanVien nhanvien)
        {
            this.MaNhanVien = nhanvien.MaNhanVien;
            this.HoTen = nhanvien.HoTen;
            this.GioiTinh = nhanvien.GioiTinh;
            this.DienThoai = nhanvien.DienThoai;
            this.DiaChi = nhanvien.DiaChi;
        }
    }
}
