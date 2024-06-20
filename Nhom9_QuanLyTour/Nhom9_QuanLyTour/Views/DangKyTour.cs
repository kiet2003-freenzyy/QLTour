using Nhom9_QuanLyTour.Models;
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
using NhanVien_Model = Nhom9_QuanLyTour.Models.NhanVien;

namespace Nhom9_QuanLyTour.Views
{
    public partial class DangKyTour : Form
    {

        SqlConnection _Connsql = new SqlConnection("Data Source=LAPTOP-FJCFKP1C;Initial Catalog=QLTour;Integrated Security=True");
        DataSet ds_QLTour = new DataSet();
        NhanVien_Model nhanvien = new NhanVien_Model();
        public DangKyTour(string matour)
        {
            InitializeComponent();
            layNhanVien(matour);
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
        void load_control(bool enable)
        {
            text_matour.Visible = enable;
            text_matour.Enabled = enable;
            text_tentour.Enabled = enable;
            text_ngaybatdau.Enabled = enable;
            text_ngayketthuc.Enabled = enable;
            text_gia.Enabled = enable;
            text_phuongtien.Enabled = enable;
            text_HDV.Enabled = enable;


            cbo_matour.Enabled = !enable;
            //cbo_diemthamquan.Enabled = enable;


        }
        void LoadDuLieuDataGTour()
        {
            string strsel = "select * from Tours ";
            SqlDataAdapter da_Tours = new SqlDataAdapter(strsel, _Connsql);
            da_Tours.Fill(ds_QLTour, "Tours");
            dataGridViewtour.DataSource = ds_QLTour.Tables["Tours"];
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

        private void buttonxem_Click(object sender, EventArgs e)
        {
            string matour = cbo_matour.SelectedItem.ToString();
            Chitiettour ct = new Chitiettour(matour);
            ct.Visible = true;
        }

        private void DangKyTour_Load(object sender, EventArgs e)
        {
            LoadDuLieuDataGTour();
            dataGridViewtour.ReadOnly = true;
            dataGridViewtour.AllowUserToAddRows = false;
            load_control(false);
            Load_comboboxmatour();
            LoadDuLieuDataGDSTourDK();

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
                    text_phuongtien.Text = reader["MaPhuongTien"].ToString();
                    text_HDV.Text = reader["MaNhanvien"].ToString();
                }
            }
            _Connsql.Close(); // Đóng kết nối sau khi sử dụng DataReader
        }

        public string Data;
        private void buttondangky_Click(object sender, EventArgs e)
        {
            string matour = cbo_matour.SelectedItem.ToString();


            if (_Connsql.State == ConnectionState.Closed)
            {
                _Connsql.Open();
            }
            SqlCommand dn = new SqlCommand("SELECT MaNhanvien FROM Tours WHERE MaTour = @matour", _Connsql);
            dn.Parameters.AddWithValue("@maTour", matour);
            SqlDataReader reader = dn.ExecuteReader();
            if (reader.Read() && !string.IsNullOrEmpty(reader[0].ToString()))
            {
                MessageBox.Show("Đã có hướng dẫn dẫn viện phụ trách tour này!.");
            }
            else
            {
                reader.Close();
                if (_Connsql.State == ConnectionState.Closed)
                {
                    _Connsql.Open();
                }
                DateTime ngayBatDau = Convert.ToDateTime(this.text_ngaybatdau.Text);
                DateTime ngayKetThuc = Convert.ToDateTime(this.text_ngayketthuc.Text);
                string query2 = @"
                SELECT COUNT(*) FROM Tours
                 WHERE MaNhanVien = @MaNV
                 AND ((@NgayBatDau BETWEEN NgayBatDau AND NgayKetThuc)
                 OR (@NgayKetThuc BETWEEN NgayBatDau AND NgayKetThuc)
                 OR (NgayBatDau BETWEEN @NgayBatDau AND @NgayKetThuc))
                ";

                SqlCommand command2 = new SqlCommand(query2, _Connsql);

                command2.Parameters.AddWithValue("@NgayBatDau", ngayBatDau);
                command2.Parameters.AddWithValue("@NgayKetThuc", ngayKetThuc);
                command2.Parameters.AddWithValue("@MaNV", nhanvien.MaNhanVien); // Chú ý thay thế @MaKhachHang bằng @MaNV
            
                int count2 = (int)command2.ExecuteScalar();

                if (count2 > 0)
                {
                    MessageBox.Show("Bạn đã có tour trùng ngày với tour này!");
                }
                else
                {
                    //reader.Close();
                    if (_Connsql.State == ConnectionState.Closed)
                    {
                        _Connsql.Open();
                    }
                    SqlCommand cmdUpdate = new SqlCommand("UPDATE Tours SET MaNhanvien = @maNhanVien WHERE MaTour = @maTour", _Connsql);
                    cmdUpdate.Parameters.AddWithValue("@maNhanVien", nhanvien.MaNhanVien);
                    cmdUpdate.Parameters.AddWithValue("@maTour", matour);
                    cmdUpdate.ExecuteNonQuery();
                    MessageBox.Show("Bạn đã đăng ký thành công!.");
                    LoadDuLieuDataGTour();
                    _Connsql.Close();
                }
            }
            _Connsql.Close();
        }

        private void buttonhuy_Click(object sender, EventArgs e)
        {
            // Display a confirmation dialog
            DialogResult result = MessageBox.Show("Bạn có chắc chắn muốn thoát?", "Xác nhận", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

            // Check the user's response
            if (result == DialogResult.Yes)
            {
                // User chose to exit, perform any cleanup or additional tasks here

                // Close the form
                this.Close();
            }
            // If the user chooses not to exit, do nothing
        }


        void LoadDuLieuDataGDSTourDK()
        {
            try
            {
                if (_Connsql.State == ConnectionState.Closed)
                {
                    _Connsql.Open();
                }
                DataSet ds_QLTour2 = new DataSet();
                // Tạo đối tượng SqlCommand với câu truy vấn SQL và kết nối
                string strsel = "select MaTour from Tours where MaNhanVien = @MaNhanVien";
                SqlCommand command = new SqlCommand(strsel, _Connsql);

                // Thêm tham số @MaNhanVien và đặt giá trị cho nó
                command.Parameters.AddWithValue("@MaNhanVien", nhanvien.MaNhanVien);

                // Sử dụng SqlDataAdapter để lấy dữ liệu từ câu truy vấn và điền vào DataSet
                SqlDataAdapter da_Tours1 = new SqlDataAdapter(command);
                ds_QLTour2.Clear(); // Xóa dữ liệu cũ trước khi điền dữ liệu mới
                da_Tours1.Fill(ds_QLTour2, "Tours");

                // Đặt nguồn dữ liệu cho DataGridView
                dtgv_DSTourPT.DataSource = ds_QLTour2.Tables["Tours"];
            }
            catch (Exception ex)
            {
                // Bạn có thể in ra hoặc xử lý lỗi tại đây
                MessageBox.Show("Lỗi: " + ex.Message);
            }
            finally
            {
                if (_Connsql.State == ConnectionState.Open)
                {
                    _Connsql.Close();
                }
            }
        }
    }
}