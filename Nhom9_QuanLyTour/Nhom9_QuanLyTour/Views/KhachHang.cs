using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;
using System.Data.Sql;
using Tour_Model = Nhom9_QuanLyTour.Models.KhachHang;
namespace Nhom9_QuanLyTour.Views
{
    public partial class KhachHang : Form
    {

        SqlConnection connect = new SqlConnection("Data Source=LAPTOP-FJCFKP1C;Initial Catalog=QLTour;Integrated Security=True");
      
        SqlDataAdapter da;
        DataSet ds;
        DataColumn[] key;
        private Bitmap bmp;
        public KhachHang()
        {
         
            InitializeComponent();
        }
        public void Load_DATA()
        {
            string sql = "select MaKhachHang, TenKhachHang, GioiTinh, DiaChi, SoDienThoai from KhachHang";
            da = new SqlDataAdapter(sql, connect);
            ds = new DataSet();
            da.Fill(ds, "KhachHang");
            dtgv_kh.DataSource = ds.Tables["KhachHang"];
            DataColumn[] key = new DataColumn[1];
            key[0] = ds.Tables["KhachHang"].Columns[0];
            ds.Tables["KhachHang"].PrimaryKey = key;
        }
        private string oldMaKhachHang;
        private void KhachHang_Load(object sender, EventArgs e)
        {
            Load_DATA();
            text_makhachhang.Enabled = true;
            text_tenkhachhang.Enabled = false;
            text_gioitinh.Enabled = false;
            text_diachi.Enabled = false;
            text_sodienthoai.Enabled = false;
          
            oldMaKhachHang = text_makhachhang.Text;
        }

        private void buttonthem_Click(object sender, EventArgs e)
        {
            text_makhachhang.Focus();
            text_makhachhang.Enabled = true;
            text_tenkhachhang.Enabled = true;
            text_gioitinh.Enabled = true;
            text_diachi.Enabled = true;
            text_sodienthoai.Enabled = true;
             btnluusua.Visible = false;
             buttonluu.Visible = true;
        }

        private void buttonluu_Click(object sender, EventArgs e)
        {
            if (text_makhachhang.Enabled == true)
            {
                // Kiểm tra trùng chỉ khi thêm mới
                try
                {
                    connect.Open();
                    string sql = "select * from KhachHang where MaKhachHang = @MaKhachHang";
                    SqlCommand cmd = new SqlCommand(sql, connect);
                    cmd.CommandType = CommandType.Text;
                    SqlParameter paraMaKhachHang = new SqlParameter("@MaKhachHang", text_makhachhang.Text);
                    SqlParameter paraTenKhachHang = new SqlParameter("@TenKhachHang", text_tenkhachhang.Text);
                    SqlParameter paraGioiTinh = new SqlParameter("@GioiTinh", text_gioitinh.Text);
                    SqlParameter paraDiaChi = new SqlParameter("@DiaChi", text_diachi.Text);
                    SqlParameter paraSDT = new SqlParameter("@SoDienThoai", text_sodienthoai.Text);
                    cmd.Parameters.Add(paraMaKhachHang);
                    cmd.Parameters.Add(paraTenKhachHang);
                    cmd.Parameters.Add(paraGioiTinh);
                    cmd.Parameters.Add(paraDiaChi);
                    cmd.Parameters.Add(paraSDT);

                    var reader = cmd.ExecuteReader();
                    if (reader.HasRows)
                    {
                        MessageBox.Show("Dữ liệu trùng.", "Thông báo");
                        reader.Close();
                        return;
                    }
                    reader.Close();

                    // Cập nhật giá trị oldMaKhachHang cho lần thêm mới
                    oldMaKhachHang = text_makhachhang.Text;

                    cmd.CommandText = "insert into KhachHang(MaKhachHang, TenKhachHang, GioiTinh, DiaChi, SoDienThoai) values (@MaKhachHang, @TenKhachHang, @GioiTinh, @DiaChi, @SoDienThoai)";
                    var result = cmd.ExecuteNonQuery();
                    if (result > 0)
                    {
                        MessageBox.Show("Thêm thành công");
                    }
                }
                catch
                {
                    MessageBox.Show("Lỗi");
                }
                finally
                {
                    if (connect.State != ConnectionState.Closed)
                    {
                        connect.Close();
                    }
                    Load_DATA();
                }
            }
            else
            {

            }
        }

        private void buttonxoa_Click(object sender, EventArgs e)
        {
            try
            {
                connect.Open();
                string sql = "delete KhachHang  where MaKhachHang = @MaKhachHang";
                SqlCommand cmd = new SqlCommand(sql, connect);
                SqlParameter paraMaKhachHang = new SqlParameter("@MaKhachHang", text_makhachhang.Text);
                SqlParameter paraTenKhachHang = new SqlParameter("@TenKhachHang", text_tenkhachhang.Text);
                SqlParameter paraGioiTinh = new SqlParameter("@GioiTinh", text_gioitinh.Text);
                SqlParameter paraDiaChi = new SqlParameter("@DiaChi", text_diachi.Text);
                SqlParameter paraSDT = new SqlParameter("@SoDienThoai", text_sodienthoai.Text);
                cmd.Parameters.Add(paraMaKhachHang);
                cmd.Parameters.Add(paraTenKhachHang);
                cmd.Parameters.Add(paraGioiTinh);
                cmd.Parameters.Add(paraDiaChi);
                cmd.Parameters.Add(paraSDT);

                if (cmd.ExecuteNonQuery() > 0)
                {
                    MessageBox.Show("xóa thành công", "Thông báo");
                }
            }
            catch
            {
                MessageBox.Show("Dữ liệu không thể xóa", "Thông báo");
            }
            finally
            {
                if (connect.State != ConnectionState.Closed)
                {
                    connect.Close();
                }
                Load_DATA();
            }
        }

        private void buttonsua_Click(object sender, EventArgs e)
        {
            text_makhachhang.Enabled = true;
            text_tenkhachhang.Enabled = true;
            text_gioitinh.Enabled = true;
            text_diachi.Enabled = true;
            text_sodienthoai.Enabled = true;
            btnluusua.Visible = true;
            buttonluu.Visible = false;
        }

        private void dtgv_kh_SelectionChanged(object sender, EventArgs e)
        {
            buttonxoa.Enabled = true;
            buttonsua.Enabled = true;
            if (dtgv_kh.SelectedRows.Count > 0)
            {
                DataGridViewRow selectedRow = dtgv_kh.SelectedRows[0];
                oldMaKhachHang = selectedRow.Cells["MaKhachHang"].Value.ToString();
            }
        }

        private void btnluusua_Click(object sender, EventArgs e)
        {

            try
            {
                connect.Open();
                string sql = "update KhachHang set ";

                // Kiểm tra từng trường và thêm vào câu lệnh UPDATE nếu có giá trị được nhập
                if (!string.IsNullOrEmpty(text_tenkhachhang.Text))
                {
                    sql += "TenKhachHang = @TenKhachHang, ";
                }
                if (!string.IsNullOrEmpty(text_diachi.Text))
                {
                    sql += "DiaChi = @DiaChi, ";
                }
                if (!string.IsNullOrEmpty(text_sodienthoai.Text))
                {
                    sql += "SoDienThoai = @SoDienThoai, ";
                }

                // Loại bỏ dấu ',' cuối cùng nếu có
                sql = sql.TrimEnd(',', ' ');

                // Thêm điều kiện WHERE
                sql += " where MaKhachHang = @MaKhachHang";

                SqlCommand cmd = new SqlCommand(sql, connect);
                SqlParameter paraMaNhanVien = new SqlParameter("@MaKhachHang", text_makhachhang.Text);
                SqlParameter paraTenNhanVien = new SqlParameter("@TenKhachHang", text_tenkhachhang.Text);
                SqlParameter paraDiaChi = new SqlParameter("@DiaChi", text_diachi.Text);
                SqlParameter paraSDT = new SqlParameter("@SoDienThoai", text_sodienthoai.Text);

                cmd.Parameters.Add(paraMaNhanVien);
                cmd.Parameters.Add(paraTenNhanVien);
                cmd.Parameters.Add(paraDiaChi);
                cmd.Parameters.Add(paraSDT);

                if (cmd.ExecuteNonQuery() > 0)
                {
                    MessageBox.Show("Update thành công", "Thông báo");
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
                Load_DATA();
            }
        }

        private void btnSearch_Click(object sender, EventArgs e)
        {
            string sql = "SELECT MaKhachHang, TenKhachHang, GioiTinh, DiaChi, SoDienThoai FROM KhachHang WHERE MaKhachHang = @MaKH";
            SqlCommand cmd = new SqlCommand(sql, connect);
            SqlParameter paraMAHD = new SqlParameter("@MaKH", text_makhachhang.Text);
            cmd.Parameters.Add(paraMAHD);
            DataTable dt = new DataTable();
            using (SqlDataAdapter da = new SqlDataAdapter(cmd))
            {
                da.Fill(dt);
            }
            dtgv_kh.DataSource = dt;
        }
    }
}
