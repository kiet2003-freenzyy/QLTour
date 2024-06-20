using Nhom9_QuanLyTour.Models;
using System;
using System.Data;
using System.Data.SqlClient;
using System.Windows.Forms;
using NhanVien_Model = Nhom9_QuanLyTour.Models.NhanVien;

namespace Nhom9_QuanLyTour.Views
{
    public partial class TrangChu : Form
    {
        SqlConnection _Connsql = new SqlConnection("Data Source=LAPTOP-FJCFKP1C;Initial Catalog=QLTour;Integrated Security=True");

        NhanVien_Model nhanvien = new NhanVien_Model();
        public TrangChu(string maNhanvien)
        {
            InitializeComponent();
            layNhanVien(maNhanvien);
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

        private void button1_Click(object sender, EventArgs e)
        {
            _Connsql.Open();

            // Tạo truy vấn SQL để lấy dữ liệu chức vụ của nhân viên có mã là maNhanVien
            string sql = "SELECT ChucVu FROM NhanVien WHERE MaNhanVien = @maNhanVien";

            // Tạo đối tượng SqlCommand để thực thi truy vấn SQL
            SqlCommand cmd = new SqlCommand(sql, _Connsql);

            // Gán giá trị của maNhanVien cho tham số @maNhanVien
            cmd.Parameters.AddWithValue("@maNhanVien", nhanvien.MaNhanVien);

            // Thực thi truy vấn SQL
            SqlDataReader reader = cmd.ExecuteReader();

            // Nếu kết quả của truy vấn không rỗng
            string chucVu = "";
            if (reader.Read())
                // Lấy chức vụ của nhân viên
                chucVu = reader[0].ToString();
            _Connsql.Close();


            if (chucVu == "Nhân viên" || chucVu == "Quản trị viên") 
            {
                Tour t = new Tour();
                t.Enabled = true;
                t.Show();
            }
           else
            {
                string data= nhanvien.MaNhanVien.ToString();
                DangKyTour dk=new DangKyTour(data);
                dk.Show();
                
                
            }


        }



        private void btnKhachHang_MouseClick(object sender, MouseEventArgs e)
        {
            KhachHang kh = new KhachHang();
            //kh.Enabled = true;
            kh.Show();


        }

        private void btnnhanvien_Click(object sender, EventArgs e)
        {
            NhanVien nv = new NhanVien();
            //nv.Enabled = true;
            nv.Show();
        }

        private void buttonthoat_Click(object sender, EventArgs e)
        {
            DialogResult dialogResult = MessageBox.Show("Bạn có chắc chắn muốn thoát không?", "Xác nhận thoát", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

            // Kiểm tra xem người dùng đã chọn Yes hay No
            if (dialogResult == DialogResult.Yes)
            {
                DangNhap dn = new DangNhap();
                dn.Show();
                this.Close();   
            }

        }

        private void TrangChu_Load(object sender, EventArgs e)
        {
            lb_tennhanvien.Text = nhanvien.HoTen;

            _Connsql.Open();

            // Tạo truy vấn SQL để lấy dữ liệu chức vụ của nhân viên có mã là maNhanVien
            string sql = "SELECT ChucVu FROM NhanVien WHERE MaNhanVien = @maNhanVien";

            // Tạo đối tượng SqlCommand để thực thi truy vấn SQL
            SqlCommand cmd = new SqlCommand(sql, _Connsql);

            // Gán giá trị của maNhanVien cho tham số @maNhanVien
            cmd.Parameters.AddWithValue("@maNhanVien", nhanvien.MaNhanVien);

            // Mở kết nối với cơ sở dữ liệu


            // Thực thi truy vấn SQL
            SqlDataReader reader = cmd.ExecuteReader();

            // Nếu kết quả của truy vấn không rỗng
            string chucVu = "";
            if (reader.Read())
                // Lấy chức vụ của nhân viên
                chucVu = reader[0].ToString();
            _Connsql.Close();
            // Load button tương ứng
            if (chucVu == "Nhân viên" || chucVu == "Quản trị viên")
            {
                if (chucVu == "Quản trị viên")
                { btnTTCN.Enabled = false;
                    btnnhanvien.Enabled = true;
                    btnKhachHang.Enabled = true;
                
                    btnTour.Enabled = true;
                    bt_KHcuaTour.Enabled = true;
                }
                if(chucVu == "Nhân viên")
                {
                    btnKhachHang.Enabled = true;
                    btnnhanvien.Enabled = false;
                    btnTour.Enabled = true;
                    bt_KHcuaTour.Enabled = true;
                }
              

            }
            else
            {
                btnKhachHang.Enabled = false;
                btnnhanvien.Enabled = false;
                btnTour.Enabled = true;
                bt_KHcuaTour.Enabled = false;
            }
        }

        //private void TrangChu_FormClosing(object sender, FormClosingEventArgs e)
        //{
        //    Environment.Exit(0);
        //}
        private void TrangChu_FormClosing(object sender, FormClosingEventArgs e)
        {
            // Check if the form is being closed by user action
            if (e.CloseReason == CloseReason.UserClosing)
            {
                // Ask the user for confirmation
                DialogResult result = MessageBox.Show("Bạn có chắc chắn muốn thoát?", "Xác nhận", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

                // If the user chooses not to exit, cancel the form closing event
                if (result == DialogResult.No)
                {
                    e.Cancel = true;
                    return;
                }
            }

            // Perform any cleanup or additional tasks before closing the form

            // Continue with the form closing process
            // (This will close the form and release associated resources)
        }

        private void button4_Click(object sender, EventArgs e)
        {
            QLKH ql = new QLKH();
            ; ql.Show();

        }

        private void btnTTCN_Click(object sender, EventArgs e)
        {
            string data = nhanvien.MaNhanVien.ToString();
            TTCN dk = new TTCN(data);
            dk.Show();
        }
    }
}
