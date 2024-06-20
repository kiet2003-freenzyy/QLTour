using System;
using System.Collections.Generic;
using System.Data;
using System.Drawing;
using System.Windows.Forms;
using System.Data.SqlClient;
namespace Nhom9_QuanLyTour.Views
{
    public partial class NhanVien : Form
    {
       
        SqlConnection connect;
        SqlDataAdapter da;
        DataSet ds;
        DataColumn[] key;
        private Bitmap bmp;
        public NhanVien()
        {
            connect = new SqlConnection("Data Source=LAPTOP-FJCFKP1C;Initial Catalog=QLTour;Integrated Security=True");
            InitializeComponent();
        }
        public void Load_combobox_ChucVu()
        {
            List<string> uniqueChucVuList = new List<string>();

            try
            {
                connect.Open();
                string sql = "select distinct ChucVu from NhanVien";
                SqlCommand cmd = new SqlCommand(sql, connect);
                var reader = cmd.ExecuteReader();

                while (reader.Read())
                {
                    string chucVu = reader["ChucVu"].ToString();
                    uniqueChucVuList.Add(chucVu);
                }

                cbo_chucvu.DataSource = uniqueChucVuList;
                cbo_chucvu.DisplayMember = "ChucVu";
                cbo_chucvu.ValueMember = "ChucVu";
            }
            catch (Exception ex)
            {
                // Xử lý lỗi nếu cần
            }
            finally
            {
                connect.Close();
            }
        }
        public void Load_DATA()
        {
            string sql = "select MaNhanVien, HoTen, GioiTinh, DiaChi, SoDienThoai, ChucVu  from NhanVien";
            da = new SqlDataAdapter(sql, connect);
            ds = new DataSet();
            da.Fill(ds, "NhanVien");
            dtgv_nv.DataSource = ds.Tables["NhanVien"];
            DataColumn[] key = new DataColumn[1];
            key[0] = ds.Tables["NhanVien"].Columns[0];
            ds.Tables["NhanVien"].PrimaryKey = key;
        }
        private void NhanVien_Load(object sender, EventArgs e)
        {
            Load_combobox_ChucVu();
            Load_DATA();
            text_manhanvien.Enabled = true;
            text_hoten.Enabled = false;
            text_gioitinh.Enabled = false;
            text_diachi.Enabled = false;
            text_sodienthoai.Enabled = false;
            cbo_chucvu.Enabled = false;
       
        }

        private void buttonthem_Click(object sender, EventArgs e)
        {
            text_manhanvien.Focus();
            text_manhanvien.Enabled = true;
            text_hoten.Enabled = true;
            text_gioitinh.Enabled = true;
            text_diachi.Enabled = true;
            text_sodienthoai.Enabled = true;
            cbo_chucvu.Enabled = true;
            btnluusua.Visible = false;
            buttonluu.Visible = true;

        }

        private void buttonluu_Click(object sender, EventArgs e)
        {
            if (text_manhanvien.Enabled == true)
            {
                try
                {
                    connect.Open();
                    string sql = "select * from NhanVien where MaNhanVien = @MaNhanVien";
                    SqlCommand cmd = new SqlCommand(sql, connect);
                    cmd.CommandType = CommandType.Text;
                    SqlParameter paraMaNhanVien = new SqlParameter("@MaNhanVien", text_manhanvien.Text);
                    SqlParameter paraTenNhanVien = new SqlParameter("@HoTen", text_hoten.Text);
                    SqlParameter paraGioiTinh = new SqlParameter("@GioiTinh", text_gioitinh.Text);
                    SqlParameter paraDiaChi = new SqlParameter("@DiaChi", text_diachi.Text);
                    SqlParameter paraSDT = new SqlParameter("@SoDienThoai", text_sodienthoai.Text);
                    SqlParameter paraChucVu = new SqlParameter("@ChucVu", cbo_chucvu.SelectedValue.ToString());
                    cmd.Parameters.Add(paraMaNhanVien);
                    cmd.Parameters.Add(paraTenNhanVien);
                    cmd.Parameters.Add(paraGioiTinh);
                    cmd.Parameters.Add(paraDiaChi);
                    cmd.Parameters.Add(paraSDT);
                    cmd.Parameters.Add(paraChucVu);

                    var reade = cmd.ExecuteReader();
                    if (reade.HasRows)
                    {
                        MessageBox.Show("Dữ liệu trùng.", "thông báo");
                        return;
                    }
                    reade.Close();
                    cmd.CommandText = "insert into NhanVien(MaNhanVien, HoTen, GioiTinh, DiaChi, SoDienThoai, ChucVu) values (@MaNhanVien, @HoTen, @GioiTinh, @DiaChi, @SoDienThoai, @ChucVu)";
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

        private void buttonsua_Click(object sender, EventArgs e)
        {
            text_manhanvien.Enabled = true;
            text_hoten.Enabled = true;
            text_gioitinh.Enabled = true;
            text_diachi.Enabled = true;
            text_sodienthoai.Enabled = true;
            cbo_chucvu.Enabled = true;
            buttonluu.Visible = false;
            btnluusua.Visible = true;

        }

        private void buttonxoa_Click(object sender, EventArgs e)
        {
            try
            {
                connect.Open();
                string sql = "delete NhanVien  where MaNhanVien = @MaNhanVien";
                SqlCommand cmd = new SqlCommand(sql, connect);
                SqlParameter paraMaNhanVien = new SqlParameter("@MaNhanVien", text_manhanvien.Text);
                SqlParameter paraTenNhanVien = new SqlParameter("@HoTen", text_hoten.Text);
                SqlParameter paraGioiTinh = new SqlParameter("@GioiTinh", text_gioitinh.Text);
                SqlParameter paraDiaChi = new SqlParameter("@DiaChi", text_diachi.Text);
                SqlParameter paraSDT = new SqlParameter("@SoDienThoai", text_sodienthoai.Text);
                SqlParameter paraChucVu = new SqlParameter("@ChucVu", cbo_chucvu.SelectedValue.ToString());
                cmd.Parameters.Add(paraMaNhanVien);
                cmd.Parameters.Add(paraTenNhanVien);
                cmd.Parameters.Add(paraGioiTinh);
                cmd.Parameters.Add(paraDiaChi);
                cmd.Parameters.Add(paraSDT);
                cmd.Parameters.Add(paraChucVu);

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

        private void dtgv_nv_SelectionChanged(object sender, EventArgs e)
        {
            buttonxoa.Enabled = true;
            buttonsua.Enabled = true;
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
                if (!string.IsNullOrEmpty(cbo_chucvu.SelectedValue.ToString()))
                {
                    sql += "ChucVu = @ChucVu, ";
                }
                // Loại bỏ dấu ',' cuối cùng nếu có
                sql = sql.TrimEnd(',', ' ');

                // Thêm điều kiện WHERE
                sql += " where MaNhanVien = @MaNhanVien";

                SqlCommand cmd = new SqlCommand(sql, connect);
                SqlParameter paraMaNhanVien = new SqlParameter("@MaNhanVien", text_manhanvien.Text);
                SqlParameter paraTenNhanVien = new SqlParameter("@HoTen", text_hoten.Text);
                SqlParameter paraGioiTinh = new SqlParameter("@GioiTinh", text_gioitinh.Text);
                SqlParameter paraDiaChi = new SqlParameter("@DiaChi", text_diachi.Text);
                SqlParameter paraSDT = new SqlParameter("@SoDienThoai", text_sodienthoai.Text);
                SqlParameter paraChucVu = new SqlParameter("@ChucVu", cbo_chucvu.SelectedValue.ToString());
                cmd.Parameters.Add(paraMaNhanVien);
                cmd.Parameters.Add(paraTenNhanVien);
                cmd.Parameters.Add(paraGioiTinh);
                cmd.Parameters.Add(paraDiaChi);
                cmd.Parameters.Add(paraSDT);
                cmd.Parameters.Add(paraChucVu);

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

        private void btnIn_Click(object sender, EventArgs e)
        {
            string sql = "select MaNhanVien, HoTen, GioiTinh, DiaChi, SoDienThoai, ChucVu  from NhanVien";
            SqlCommand cmd = new SqlCommand(sql, connect);
            cmd.Parameters.Clear();
            DataTable dtb = new DataTable("TTInNV");
            SqlDataAdapter da_NhanVien = new SqlDataAdapter(cmd);
            da_NhanVien.Fill(dtb);
            CrystalReport2 Tour = new CrystalReport2();
            Tour.SetDataSource(dtb);
            InNV HD = new InNV();
            HD.crystalReportViewer2.ReportSource = Tour;
            HD.ShowDialog();
        }

        private void btnSearch_Click(object sender, EventArgs e)
        {
            string sql = "select MaNhanVien, HoTen, GioiTinh, DiaChi, SoDienThoai, ChucVu  from NhanVien WHERE MaNhanVien = @MaNV";
            SqlCommand cmd = new SqlCommand(sql, connect);
            SqlParameter paraMAHD = new SqlParameter("@MaNV", text_manhanvien.Text);
            cmd.Parameters.Add(paraMAHD);
            DataTable dt = new DataTable();
            using (SqlDataAdapter da = new SqlDataAdapter(cmd))
            {
                da.Fill(dt);
            }
            dtgv_nv.DataSource = dt;
        }
    }
}
