using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Tour_Model = Nhom9_QuanLyTour.Models.Tour;
using Nhanvien_Model = Nhom9_QuanLyTour.Models.NhanVien;
using Nhom9_QuanLyTour.Models;

namespace Nhom9_QuanLyTour.Views
{
    public partial class Chitiettour : Form
    {
        SqlConnection _Connsql = new SqlConnection("Data Source=LAPTOP-FJCFKP1C;Initial Catalog=QLTour;Integrated Security=True");
        DataSet ds_QLTour = new DataSet();
        Tour_Model tour = new Tour_Model();
        Nhanvien_Model nhanvien = new Nhanvien_Model();
        PhuongTien phuongtien = new PhuongTien();

        void layChiTietTour(string matour)
        {
            SqlCommand command = new SqlCommand("SELECT * FROM Tours WHERE MaTour = @code", _Connsql);

            command.Parameters.AddWithValue("@code", matour);
            if (_Connsql.State == ConnectionState.Closed)
            {
                _Connsql.Open();
            }
            using (SqlDataReader reader = command.ExecuteReader())
            {
                while (reader.Read())
                {
                    // Use the reader here
                    tour.MaTour = reader[0].ToString();
                    tour.NgayBatDau = ((DateTime)reader["NgayBatDau"]);
                    tour.NgayKetThuc = ((DateTime)reader["NgayKetThuc"]);
                    tour.Gia = (int)double.Parse(reader["Gia"].ToString());
                    tour.MaPhuongTien = reader["MaPhuongTien"].ToString();
                    tour.MaNhanVien = reader["MaNhanvien"].ToString();
                }
            }
            _Connsql.Close();
        }

        void layNhanVien(string manhanvien)
        {
            SqlCommand command = new SqlCommand("SELECT * FROM NhanVien WHERE Manhanvien = @code", _Connsql);

            command.Parameters.AddWithValue("@code", manhanvien);
            if (_Connsql.State == ConnectionState.Closed)
            {
                _Connsql.Open();
            }
            using (SqlDataReader reader = command.ExecuteReader())
            {
                while (reader.Read())
                {
                    // Use the reader here
                    nhanvien.MaNhanVien = reader["MaNhanVien"].ToString();
                    nhanvien.HoTen = reader["HoTen"].ToString();
                    nhanvien.DiaChi = reader["DiaChi"].ToString();
                    nhanvien.ChucVu = reader["ChucVu"].ToString();
                    nhanvien.DienThoai = reader["SoDienThoai"].ToString();
                    nhanvien.GioiTinh = reader["GioiTinh"].ToString();
                }
            }
            _Connsql.Close();
        }

        void layPhuongTien(string maphuongtien)
        {
            SqlCommand command = new SqlCommand("SELECT * FROM PhuongTien WHERE maphuongtien = @code", _Connsql);

            command.Parameters.AddWithValue("@code", maphuongtien);
            if (_Connsql.State == ConnectionState.Closed)
            {
                _Connsql.Open();
            }
            using (SqlDataReader reader = command.ExecuteReader())
            {
                while (reader.Read())
                {
                    // Use the reader here
                    phuongtien.MaPhuongTien = reader["MaPhuongTien"].ToString();
                    phuongtien.TenPhuongTien = reader["TenPhuongTien"].ToString();
                    phuongtien.LoaiPhuongTien = reader["LoaiPhuongTien"].ToString();
                    phuongtien.SoChoNgoi = int.Parse(reader["SoChoNgoi"].ToString());

                }
            }
            _Connsql.Close();
        }

        public Chitiettour(string matour)
        {
            InitializeComponent();

            layChiTietTour(matour);
            layNhanVien(tour.MaNhanVien);
            layPhuongTien(tour.MaPhuongTien);

            LoadDuLieuNV();
            LoadDuLieuPT();
        }

        void LoadDuLieuNV()
        {
            text_MaHDV.Text = nhanvien.MaNhanVien;
            text_diachi.Text = nhanvien.DiaChi;
            text_gioitinh.Text = nhanvien.GioiTinh;
            text_sodienthoai.Text = nhanvien.DienThoai;
            text_hoten.Text = nhanvien.HoTen;
            text_chucvu.Text = nhanvien.ChucVu;
        }

        void LoadDuLieuPT()
        {
            text_maphuongtien.Text = phuongtien.MaPhuongTien;
            text_tenphuongtien.Text = phuongtien.TenPhuongTien;
            text_loaiphuongtien.Text = phuongtien.LoaiPhuongTien;
            text_soghe.Text = phuongtien.SoChoNgoi.ToString();
        }


        void LoadDuLieuDataGKH()
        {
            string strsel = "select kh.MaKhachHang, TenKhachHang, GioiTinh, DiaCHi, SoDienThoai  from KhachHang kh, KhachHangDatTour khdt where kh.MaKhachHang = khdt.MaKhachHang and khdt.MaTour = @code";
            SqlCommand command = new SqlCommand(strsel, _Connsql);
            command.Parameters.AddWithValue("@code", tour.MaTour);
            SqlDataAdapter da_Tours = new SqlDataAdapter(command);
            da_Tours.Fill(ds_QLTour, "KhachHang");
            dataGridViewkhach.DataSource = ds_QLTour.Tables["KhachHang"];
        }

        void LoadDuLieuDataDTQ()
        {
            string strsel = "SELECT DCT.MaDiemThamQuan, TenDiemThamQuan FROM DiemThamQuanCuaTour DCT,DiemThamQuan D WHERE DCT.MaDiemThamQuan=D.MaDiemThamQuan and DCT.MaTour = @code";
            SqlCommand command = new SqlCommand(strsel, _Connsql);
            command.Parameters.AddWithValue("@code", tour.MaTour);
            SqlDataAdapter da_Tours = new SqlDataAdapter(command);
            da_Tours.Fill(ds_QLTour, "DiemThamQuan");
            dataGridView_DTQ.DataSource = ds_QLTour.Tables["DiemThamQuan"];
        }


        private void Chitiettour_Load(object sender, EventArgs e)
        {
            text_MaHDV.Text = tour.MaNhanVien;
            //text_hoten.Text=model.

            LoadDuLieuDataGKH();

            dataGridViewkhach.ReadOnly = true;
            dataGridViewkhach.AllowUserToAddRows = false;



            LoadDuLieuDataDTQ();

            dataGridView_DTQ.ReadOnly = true;
            dataGridView_DTQ.AllowUserToAddRows = false;




        }

       
    }
}
