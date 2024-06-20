using Nhom9_QuanLyTour.Views;
using System;
using System.Collections.Generic;
using System.Diagnostics.Contracts;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Nhom9_QuanLyTour.Models
{
    public class PhuongTien
    {
        public string MaPhuongTien { get; set; }
        public string TenPhuongTien { get; set; }
        public string LoaiPhuongTien { get; set; }
        public int SoChoNgoi { get; set; }



        public PhuongTien() { }
        public PhuongTien(string MaPhuongTien, string TenPhuongTien, string LoaiPhuongTien, int SoChoNgoi) 
        {
            this.MaPhuongTien = MaPhuongTien;
            this.TenPhuongTien = TenPhuongTien;
            this.LoaiPhuongTien = LoaiPhuongTien ;
            this.SoChoNgoi = SoChoNgoi;
        }

        public PhuongTien(PhuongTien phuongtien) 
        {
            this.MaPhuongTien = phuongtien.MaPhuongTien;
            this.TenPhuongTien = phuongtien.TenPhuongTien;
            this.LoaiPhuongTien = phuongtien.LoaiPhuongTien;
            this.SoChoNgoi = phuongtien.SoChoNgoi; ;
        }

    }
}
