using Nhom9_QuanLyTour.Views;
using System;
using System.Data.SqlClient;
using System.Data;
using System.Drawing;
using System.Windows.Forms;
using Tour_Model = Nhom9_QuanLyTour.Models.Tour;
using System.Collections.Generic;
using System.Runtime.Remoting.Contexts;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;
using System.Runtime.Remoting.Messaging;
using Nhom9_QuanLyTour.Models;
using System.Data.Common;
using System.Collections.ObjectModel;
using System.Net.NetworkInformation;

namespace Nhom9_QuanLyTour
{
    public partial class QLKH : Form
    {
        SqlDataAdapter da;
        //DataSet ds=new DataSet();
        //DataSet ds_QLTour = new DataSet();
        DataColumn[] key;
        Tour_Model tour = new Tour_Model();
        bool them = false;
        SqlConnection _Connsql = new SqlConnection("Data Source=LAPTOP-FJCFKP1C;Initial Catalog=QLTour;Integrated Security=True");


        private object uniqueChucVuList;
        private SqlCommand SelectCommand;

        public QLKH()
        {
            InitializeComponent();

        }
        public void Load_comboboxmaKH()
        {
            List<string> uniqueMaKHList = new List<string>();

            try
            {
                _Connsql.Open();
                string sql = "select  MaKhachHang from KhachHang";
                SqlCommand cmd = new SqlCommand(sql, _Connsql);
                var reader = cmd.ExecuteReader();

                while (reader.Read())
                {
                    string matour = reader["MaKhachHang"].ToString();
                    uniqueMaKHList.Add(matour);
                }
                reader.Close();

                comboBox_KH.DataSource = uniqueMaKHList;
                comboBox_KH.DisplayMember = "MaKhachHang";
                comboBox_KH.ValueMember = "MaKhachHang";
            }
            catch (Exception ex)
            {
                // Xử lý lỗi nếu cần
            }
            finally
            {
                _Connsql.Close();
            }
        }
        private void Tour_Load(object sender, EventArgs e)
        {
            Load_comboboxmaKH();
            Load_comboboxmatour();
            //LoadDuLieuDataGKHcuatuor();
            LoadDulieuData_KH();
            dataGridViewKh.ReadOnly = true;
            dataGridViewKh.AllowUserToAddRows = false;


        }
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
        public void Load_comboboxmatour()
        {
            List<string> uniqueMaTourList = new List<string>();

            try
            {
                _Connsql.Open();
                string sql = "select  MaTour from Tours";
                SqlCommand cmd = new SqlCommand(sql, _Connsql);
                var reader = cmd.ExecuteReader();

                while (reader.Read())
                {
                    string matour = reader["MaTour"].ToString();
                    uniqueMaTourList.Add(matour);
                }
                reader.Close();

                cbo_matour.DataSource = uniqueMaTourList;
                cbo_matour.DisplayMember = "MaTour";
                cbo_matour.ValueMember = "MaTour";
            }
            catch (Exception ex)
            {
                // Xử lý lỗi nếu cần
            }
            finally
            {
                _Connsql.Close();
            }
        }

        void LoadDuLieuDataGKHcuatuor()
        {
            DataSet ds_QLTour = new DataSet();
            DataSet ds = new DataSet();
            string matour = cbo_matour.SelectedItem.ToString();
            string strsel = "select kh.MaKhachHang, TenKhachHang, GioiTinh, DiaCHi, SoDienThoai from KhachHang kh, KhachHangDatTour khdt where kh.MaKhachHang = khdt.MaKhachHang and khdt.MaTour = @code";
            SqlCommand command = new SqlCommand(strsel, _Connsql);
            command.Parameters.AddWithValue("@code", matour);
            SqlDataAdapter da_Tours = new SqlDataAdapter(command);
            da_Tours.Fill(ds, "KhachHang");
            dataGridView_KHcauTOUR.DataSource = ds.Tables["KhachHang"];


        }

        void LoadDulieuData_KH()
        {

            string sql = "select * from KhachHang";
            DataSet ds = new DataSet();
            SqlDataAdapter da_Tours = new SqlDataAdapter(sql, _Connsql);
            da_Tours.Fill(ds, "KhachHang");
            dataGridViewKh.DataSource = ds.Tables["KhachHang"];
        }

        private void buttonthem_Click(object sender, EventArgs e)
        {
            // Lấy thông tin từ các điều khiển trên giao diện
            string maKhachHang = comboBox_KH.SelectedItem.ToString();
            string matour = cbo_matour.SelectedItem.ToString();
            // Các thông tin khác nếu cần thiết

            // Mở kết nối tới cơ sở dữ liệu
            if (_Connsql.State == ConnectionState.Closed)
            {
                _Connsql.Open();
            }

            // Query SQL để thêm khách hàng vào bảng KhachHangCuaTour
            string query = "INSERT INTO KhachHangDatTour (MaKhachHang, MaTour) VALUES (@maKhachHang, @matour )";
            string query1 = "SELECT COUNT(*) FROM KhachHangDatTour WHERE MaKhachHang = @MaKhachHang AND MaTour = @MaTour";
            SqlCommand command = new SqlCommand(query, _Connsql);
            SqlCommand command1 = new SqlCommand(query1, _Connsql);

            // Thay thế tham số trong câu truy vấn SQL bằng giá trị thực tế
            command.Parameters.AddWithValue("@maKhachHang", maKhachHang);
            command.Parameters.AddWithValue("@matour", matour);

            command1.Parameters.AddWithValue("@maKhachHang", maKhachHang);
            command1.Parameters.AddWithValue("@matour", matour);

            int count = (int)command1.ExecuteScalar();
            if (count > 0)
            {

                MessageBox.Show(string.Format("Đã có khách hàng mã {0} trong mã tour {1} !", maKhachHang, matour));

            }
            else
            {
                DateTime ngayBatDau = Convert.ToDateTime(this.text_ngaybatdau.Text);
                DateTime ngayKetThuc = Convert.ToDateTime(this.text_ngayketthuc.Text);
                string query2 = @"
                 SELECT COUNT(*) FROM KhachHangDatTour KHT
                 INNER JOIN Tours T ON KHT.MaTour = T.MaTour
                 WHERE T.MaTour != @MaTour
                 AND KHT.MaKhachHang = @MaKhachHang
                 AND (
                 (@NgayBatDau BETWEEN T.NgayBatDau AND T.NgayKetThuc)
                 OR (@NgayKetThuc BETWEEN T.NgayBatDau AND T.NgayKetThuc)
                 OR (T.NgayBatDau BETWEEN @NgayBatDau AND @NgayKetThuc)
                                                            )";


                SqlCommand command2 = new SqlCommand(query2, _Connsql);

                command2.Parameters.AddWithValue("@NgayBatDau", ngayBatDau);
                command2.Parameters.AddWithValue("@NgayKetThuc", ngayKetThuc);
                command2.Parameters.AddWithValue("@MaTour", matour);
                command2.Parameters.AddWithValue("@MaKhachHang", maKhachHang);


                int count2 = (int)command2.ExecuteScalar();


                if (count2 > 0)
                {
                    MessageBox.Show("Khách hàng này đã có tour trùng với tour hiện tại !");

                }
                else
                {

                    int rowsAffected = command.ExecuteNonQuery();

                    if (rowsAffected > 0)
                    {
                        // Thêm thành công
                        MessageBox.Show("Đã thêm khách hàng thành công!");
                        LoadDuLieuDataGKHcuatuor();
                        // Cập nhật lại DataGridView hoặc làm gì đó cần thiết sau khi thêm thành công
                    }
                }
            }


            //Đóng kết nối sau khi thêm dữ liệu
            _Connsql.Close();


        }

        private void cbo_matour_SelectedIndexChanged(object sender, EventArgs e)
        {

            string matour = cbo_matour.SelectedItem.ToString();
            SqlCommand command = new SqlCommand("SELECT TenTour, NgayBatDau, NgayKetThuc, Gia, MaPhuongTien, MaNhanvien FROM Tours WHERE MaTour = @code", _Connsql);

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
                    text_tentour.Text = reader[0].ToString();
                    text_ngaybatdau.Text = ((DateTime)reader["NgayBatDau"]).ToShortDateString();
                    text_ngayketthuc.Text = ((DateTime)reader["NgayKetThuc"]).ToShortDateString();
                    text_gia.Text = reader["Gia"].ToString();
                    textBox_Phuongtien.Text = reader["MaPhuongTien"].ToString();
                    textBoxHDV.Text = reader["MaNhanvien"].ToString();
                }
            }
            LoadDuLieuDataGKHcuatuor();
        }

        private void buttonxoa_Click(object sender, EventArgs e)
        {
            // Lấy thông tin từ các điều khiển trên giao diện
            string maKhachHang = comboBox_KH.SelectedItem.ToString();
            string matour = cbo_matour.SelectedItem.ToString();
            // Các thông tin khác nếu cần thiết

            // Mở kết nối tới cơ sở dữ liệu
            if (_Connsql.State == ConnectionState.Closed)
            {
                _Connsql.Open();
            }

            // Query SQL để thêm khách hàng vào bảng KhachHangCuaTour
            string query = "DELETE FROM KhachHangDatTour WHERE MaKhachHang = @maKhachHang AND MaTour = @matour ";
            string query1 = "SELECT COUNT(*) FROM KhachHangDatTour WHERE MaKhachHang = @MaKhachHang AND MaTour = @MaTour";
            SqlCommand command = new SqlCommand(query, _Connsql);
            SqlCommand command1 = new SqlCommand(query1, _Connsql);

            // Thay thế tham số trong câu truy vấn SQL bằng giá trị thực tế
            command.Parameters.AddWithValue("@maKhachHang", maKhachHang);
            command.Parameters.AddWithValue("@matour", matour);

            command1.Parameters.AddWithValue("@maKhachHang", maKhachHang);
            command1.Parameters.AddWithValue("@matour", matour);

            int count = (int)command1.ExecuteScalar();
            if (count == 0)
            {

                MessageBox.Show("Không có khách hàng mã {0} trong mã tour {1} !", maKhachHang);

            }
            else
            {
                DateTime ngayBatDau = Convert.ToDateTime(this.text_ngaybatdau.Text);
                DateTime ngayKetThuc = Convert.ToDateTime(this.text_ngayketthuc.Text);

                int rowsAffected = command.ExecuteNonQuery();

                if (rowsAffected > 0)
                {
                    // Thêm thành công
                    MessageBox.Show("Đã xóa khách hàng thành công!");

                    // Cập nhật lại DataGridView 
                    LoadDuLieuDataGKHcuatuor();
                }


            }


            //Đóng kết nối sau khi thêm dữ liệu
            _Connsql.Close();


        }
    }
}
