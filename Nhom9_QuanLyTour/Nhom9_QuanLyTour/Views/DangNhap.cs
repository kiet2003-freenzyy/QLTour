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

namespace Nhom9_QuanLyTour.Views
{
    public partial class DangNhap : Form
    {

        private string _maNhanVien;
        public DangNhap()
        {
            InitializeComponent();
        }

        //public bool CheckLogin()
        //{
        //    // Lấy dữ liệu từ text box
        //    string username = text_TK.Text;
        //    string password = text_MK.Text;

        //    // Tạo kết nối đến cơ sở dữ liệu
        //    SqlConnection _Connsql = new SqlConnection("Data Source=THUHOA\\MAYAO;Initial Catalog=QLTour;Integrated Security=True");
        //    _Connsql.Open();

        //    // Tạo truy vấn SELECT
        //    string sql = "SELECT * FROM TaiKhoan WHERE TenDangNhap = @username AND MatKhau = @password";
        //    SqlCommand command = new SqlCommand(sql, _Connsql);

        //    // Gán giá trị cho tham số
        //    command.Parameters.AddWithValue("@username", username);
        //    command.Parameters.AddWithValue("@password", password);

        //    // Thực thi truy vấn
        //    SqlDataReader reader = command.ExecuteReader();

        //    // Kiểm tra kết quả
        //    if (reader.HasRows)
        //    {

        //        reader.Read();
        //        _maNhanVien = reader["MaNhanVien"].ToString();
        //        return true;
        //    }


        //    _Connsql.Close();
        //    return false;
        //}
        public bool CheckLogin()
        {
            // Lấy dữ liệu từ text box
            string username = text_TK.Text;
            string password = text_MK.Text;

            // Tạo kết nối đến cơ sở dữ liệu
            SqlConnection _Connsql = new SqlConnection("Data Source=LAPTOP-FJCFKP1C;Initial Catalog=QLTour;Integrated Security=True");
            _Connsql.Open();

            // Tạo truy vấn SELECT
            string sql = "SELECT * FROM TaiKhoan WHERE TenDangNhap = @username AND MatKhau = @password";
            SqlCommand command = new SqlCommand(sql, _Connsql);

            // Gán giá trị cho tham số
            command.Parameters.AddWithValue("@username", username);
            command.Parameters.AddWithValue("@password", password);

            // Thực thi truy vấn
            SqlDataReader reader = command.ExecuteReader();

            // Kiểm tra kết quả
            if (reader.HasRows)
            {
                reader.Read();
                _maNhanVien = reader["MaNhanVien"].ToString();
                _Connsql.Close();
                return true;
            }
            else
            {
                _Connsql.Close();

                // Hiển thị thông báo hoặc thực hiện hành động phù hợp khi mã nhân viên không tồn tại
                MessageBox.Show("Mã nhân viên không tồn tại trong cơ sở dữ liệu. Vui lòng kiểm tra lại tài khoản và mật khẩu.", "Thông báo");

                // Xóa dữ liệu đã nhập trong trường tài khoản và mật khẩu
                text_TK.Text = "";
                text_MK.Text = "";

                // Tập trung trỏ vào trường tài khoản để người dùng có thể nhập lại
                text_TK.Focus();

                return false;
            }
        }

        private void buttonthoat_Click(object sender, EventArgs e)
        {
            // Hiển thị hộp thoại xác nhận trước khi thoát
            DialogResult result = MessageBox.Show("Bạn có chắc chắn muốn thoát?", "Xác nhận", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

            // Kiểm tra xác nhận từ người dùng
            if (result == DialogResult.Yes)
            {
                // Đóng form nếu người dùng chọn "Yes"
                this.Close();
            }
            // Ngược lại, không làm gì nếu người dùng chọn "No"
        }


        private void buttonDangNhap_Click(object sender, EventArgs e)
        {


            if (CheckLogin() == true)
            {
                string data = _maNhanVien.ToString();
                // Mở form 2
                TrangChu form2 = new TrangChu(data);
                form2.Show();
                Visible = false;
            }
            else
            {
                MessageBox.Show("Vui lòng nhập đúng thông tin về tài khoản và mật khẩu", "Thông báo!", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }

        }
    }
}
