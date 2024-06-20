using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Nhom9_QuanLyTour.Models
{
    public class Tour
    {
        public string MaTour { get; set; }
        public string TenTour { get; set; }
        public DateTime NgayBatDau { get; set; }
        public DateTime NgayKetThuc { get; set; }
        public int Gia { get; set; }
        public string MaPhuongTien{ get; set; }
        public string MaNhanVien{ get; set; }


        public Tour()
        { }
        public Tour(String MaTour, string TenTour, DateTime NgayBatDau, DateTime NgayKetThuc, int Gia, string MaPhuongTien,string MaNhanVien)
        {
            this.MaTour = MaTour;
            this.TenTour = TenTour;
            this.NgayBatDau = NgayBatDau;
            this.NgayKetThuc = NgayKetThuc;
            this.Gia = Gia;
            this.MaPhuongTien = MaPhuongTien;
            this.MaNhanVien = MaNhanVien;
        }
        public Tour(Tour tour)
        {
            this.MaTour = tour.MaTour;
            this.TenTour = tour.TenTour;
            this.NgayBatDau = tour.NgayBatDau;
            this.NgayKetThuc = tour.NgayKetThuc;
            this.Gia = tour.Gia;
            this.MaPhuongTien = tour.MaPhuongTien;
            this.MaNhanVien = tour.MaNhanVien;
        }
    }
}
