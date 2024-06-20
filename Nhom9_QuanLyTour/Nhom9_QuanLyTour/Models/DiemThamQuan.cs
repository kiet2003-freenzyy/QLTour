using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Nhom9_QuanLyTour.Models
{
    public class DiemThamQuan
    {
        public string MaDiemThamQuan { get; set; }
        public string TenDiemThamQuan { get; set; }

        public DiemThamQuan() { }

        public DiemThamQuan(string maDiemThamQuan, string tenDiemThamQuan) {
            MaDiemThamQuan = maDiemThamQuan;
            TenDiemThamQuan= tenDiemThamQuan;
        }
        public DiemThamQuan(DiemThamQuan diemThamQuan) {
            MaDiemThamQuan = diemThamQuan.MaDiemThamQuan;
            TenDiemThamQuan = diemThamQuan.TenDiemThamQuan;
        }

    }
}
