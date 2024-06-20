using System;
using System.Collections.Generic;
using System.Data;
using System.Drawing;
using System.Windows.Forms;
using System.Data.SqlClient;
using NhanVien_Model = Nhom9_QuanLyTour.Models.NhanVien;
using Taikhoan_Model = Nhom9_QuanLyTour.Models.Taikhoan;
namespace Nhom9_QuanLyTour.Views
{
    public partial class TTCN : Form
    {
       
        SqlConnection connect;
        NhanVien_Model nhanvien = new NhanVien_Model();
        Taikhoan_Model taikhoan = new Taikhoan_Model();
       
        public TTCN(string manhanvien)
        {
            connect = new SqlConnection("Data Source=LAPTOP-FJCFKP1C;Initial Catalog=QLTour;Integrated Security=True");
            InitializeComponent();
            layNhanVien(manhanvien);
        }
        void layNhanVien(string manhanvien)
        {
            SqlCommand command = new SqlCommand("SELECT * FROM NhanVien WHERE Manhanvien = @code", connect);

            command.Parameters.AddWithValue("@code", manhanvien);
            if (connect.State == ConnectionState.Closed)
            {
                connect.Open();
            }
            using (SqlDataReader reader = command.ExecuteReader())
            {
                while (reader.Read())
                {
                    nhanvien.MaNhanVien = reader["Manhanvien"].ToString();
                    // Use the reader here
                    nhanvien.HoTen = reader["HoTen"].ToString();
                    nhanvien.DiaChi = reader["DiaChi"].ToString();
                    nhanvien.DienThoai = reader["SoDienThoai"].ToString();
                    nhanvien.GioiTinh = reader["GioiTinh"].ToString();
                  
                }
                reader.Close();
            }
           
            SqlCommand command1 = new SqlCommand("SELECT MatKhau FROM TaiKhoan WHERE MaNhanVien = @code1", connect);

            command1.Parameters.AddWithValue("@code1", manhanvien);
          
            using (SqlDataReader reader1 = command1.ExecuteReader())
            {
                while (reader1.Read())
                {
                    taikhoan.MatKhau= reader1["MatKhau"].ToString();
              

                }
            }





            connect.Close();
        }
        private void NhanVien_Load(object sender, EventArgs e)
        {

            
            text_diachi.Text = nhanvien.DiaChi;
            text_gioitinh.Text = nhanvien.GioiTinh;
            text_sodienthoai.Text = nhanvien.DienThoai;
            text_hoten.Text = nhanvien.HoTen;
            textBox_mk.Text = taikhoan.MatKhau;
        
            text_hoten.Enabled = false;
            text_gioitinh.Enabled = false;
            text_diachi.Enabled = false;
            text_sodienthoai.Enabled = false;
            textBox_mk.Enabled = false;
        }


        private void buttonsua_Click(object sender, EventArgs e)
        {
            text_hoten.Enabled = true;
            text_gioitinh.Enabled = true;
            text_diachi.Enabled = true;
            text_sodienthoai.Enabled = true;
            textBox_mk.Enabled = true;
            btnluusua.Visible = true;

        }


       

        private void btnluusua_Click(object sender, EventArgs e)
        {
            try
            {
                connect.Open();
                string sql = "update NhanVien set ";

                // Kiểm tra từng trường và thêm vào câu lệnh UPDATE nếu có giá trị được nhập
                if (!string.IsNullOrEmpty(text_hoten.Text))
                {
                    sql += "HoTen = @HoTen, ";
                }
                if (!string.IsNullOrEmpty(text_diachi.Text))
                {
                    sql += "DiaChi = @DiaChi, ";
                }
                if (!string.IsNullOrEmpty(text_sodienthoai.Text))
                {
                    sql += "SoDienThoai = @SoDienThoai, ";
                }
                if (!string.IsNullOrEmpty(text_sodienthoai.Text))
                {
                    sql += "GioiTinh = @GioiTinh, ";
                }

                // Loại bỏ dấu ',' cuối cùng nếu có
                sql = sql.TrimEnd(',', ' ');

                // Thêm điều kiện WHERE
                sql += " where MaNhanVien = @MaNhanVien";

                SqlCommand cmd = new SqlCommand(sql, connect);
                SqlParameter paramaNhanVien = new SqlParameter("@MaNhanVien", nhanvien.MaNhanVien);
                SqlParameter paraTenNhanVien = new SqlParameter("@HoTen", text_hoten.Text);
                SqlParameter paraGioiTinh = new SqlParameter("@GioiTinh", text_gioitinh.Text);
                SqlParameter paraDiaChi = new SqlParameter("@DiaChi", text_diachi.Text);
                SqlParameter paraSDT = new SqlParameter("@SoDienThoai", text_sodienthoai.Text);
                cmd.Parameters.Add(paramaNhanVien);
                cmd.Parameters.Add(paraTenNhanVien);
                cmd.Parameters.Add(paraGioiTinh);
                cmd.Parameters.Add(paraDiaChi);
                cmd.Parameters.Add(paraSDT);


                string sql1 = "update TaiKhoan set ";

                // Kiểm tra từng trường và thêm vào câu lệnh UPDATE nếu có giá trị được nhập
                if (!string.IsNullOrEmpty(text_hoten.Text))
                {
                    sql1 += "MatKhau = @mk ";
                }
                sql1 += " where MaNhanVien = @MaNhanVien1";

                SqlCommand cmd1 = new SqlCommand(sql1, connect);
                SqlParameter paramamanv = new SqlParameter("@MaNhanVien1", nhanvien.MaNhanVien);
                SqlParameter paramk = new SqlParameter("@mk", textBox_mk.Text);
                cmd1.Parameters.Add(paramamanv);
                cmd1.Parameters.Add(paramk);

                if (cmd.ExecuteNonQuery() > 0 && cmd1.ExecuteNonQuery() > 0)
                {
                    MessageBox.Show("Update thành công", "Thông báo");
                    layNhanVien(nhanvien.MaNhanVien);
                }
                else
                {
                    MessageBox.Show("Không update được", "Lỗi");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi: " + ex.Message);
            }
            finally
            {
                if (connect.State != ConnectionState.Closed)
                {
                    connect.Close();
                }
            }
        }

        
    }
}
