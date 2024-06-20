using Nhom9_QuanLyTour.Views;
using System;
using System.Data.SqlClient;
using System.Data;
using System.Windows.Forms;
using System.Collections.Generic;
using Nhom9_QuanLyTour.Models;
using NhanVien = Nhom9_QuanLyTour.Models.NhanVien;
using System.ComponentModel;
using System.Xml.Serialization;
using System.Runtime.Remoting.Contexts;

namespace Nhom9_QuanLyTour
{
    public partial class Tour : Form
    {
        bool them = false;
        SqlConnection _Connsql = new SqlConnection("Data Source=LAPTOP-FJCFKP1C;Initial Catalog=QLTour;Integrated Security=True");
        DataSet ds_QLTour = new DataSet();
        List<string> diemThamQuans = new List<string>();
        List<string> diemThamQuansBiXoa = new List<string>();
        private object uniqueChucVuList;


        public Tour()
        {
            InitializeComponent();
        }

        public void Load_comboboxmatour()
        {
            List<string> uniqueMaTourList = new List<string>();

            try
            {
                if (_Connsql.State != ConnectionState.Open)
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
        public void Load_comboboxphuongtien()
        {
            List<PhuongTien> list = new List<PhuongTien>();

            try
            {
                _Connsql.Open();
                string sql = "select * from Phuongtien";
                SqlCommand cmd = new SqlCommand(sql, _Connsql);
                var reader = cmd.ExecuteReader();

                while (reader.Read())
                {
                    PhuongTien pt = new PhuongTien()
                    {
                        MaPhuongTien = reader["MaPhuongTien"].ToString(),
                        TenPhuongTien = reader["TenPhuongTien"].ToString(),
                        LoaiPhuongTien = reader["LoaiPhuongTien"].ToString(),
                        SoChoNgoi = int.Parse(reader["SoChoNgoi"].ToString()),
                    };

                    list.Add(pt);
                }
                reader.Close();

                cbo_phuongtien.DataSource = list;
                cbo_phuongtien.DisplayMember = "TenPhuongTien";
                cbo_phuongtien.ValueMember = "MaPhuongTien";
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
        public void Load_comboboxHDV()
        {
            List<NhanVien> list = new List<NhanVien>();

            list.Add(new NhanVien()
            {
                MaNhanVien = "",
                HoTen = ""
            });

            try
            {
                _Connsql.Open();
                string sql = "select * from NhanVien where ChucVu = N'Hướng dẫn viên'";
                SqlCommand cmd = new SqlCommand(sql, _Connsql);
                var reader = cmd.ExecuteReader();

                while (reader.Read())
                {
                    NhanVien nv = new NhanVien()
                    {
                        MaNhanVien = reader["MaNhanVien"].ToString(),
                        HoTen = reader["HoTen"].ToString()
                    };

                    list.Add(nv);
                }
                reader.Close();

                cbo_HDV.DataSource = list;
                cbo_HDV.DisplayMember = "HoTen";
                cbo_HDV.ValueMember = "MaNhanVien";
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
        public void Load_comboboxdiemthamquan()
        {
            List<DiemThamQuan> list = new List<DiemThamQuan>();

            try
            {
                _Connsql.Open();
                string sql = "select * from DiemThamQuan";
                SqlCommand cmd = new SqlCommand(sql, _Connsql);
                var reader = cmd.ExecuteReader();

                while (reader.Read())
                {
                    DiemThamQuan dtq = new DiemThamQuan()
                    {
                        MaDiemThamQuan = reader["MaDiemThamQuan"].ToString(),
                        TenDiemThamQuan = reader["TenDiemThamQuan"].ToString()
                    };

                    list.Add(dtq);
                }
                reader.Close();

                cbo_diemthamquan.DataSource = list;
                cbo_diemthamquan.DisplayMember = "TenDiemThamQuan";
                cbo_diemthamquan.ValueMember = "MaDiemThamQuan";
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
            Load_comboboxdiemthamquan();
            Load_comboboxphuongtien();
            Load_comboboxHDV();
            Load_comboboxmatour();
            LoadDuLieuDataGTour();
            dataGridViewTour.ReadOnly = true;
            dataGridViewTour.AllowUserToAddRows = false;
            dataGridView_DTQ.ReadOnly = true;
            dataGridView_DTQ.AllowUserToAddRows = false;

            load_control(false);
        }
        void LoadDuLieuDataGTour()
        {
            if (ds_QLTour.Tables["Tours"] != null)
            {
                ds_QLTour.Tables["Tours"].Clear();
            }

            string strsel = "select * from Tours ";
            SqlDataAdapter da_Tours = new SqlDataAdapter(strsel, _Connsql);
            da_Tours.Fill(ds_QLTour, "Tours");
            dataGridViewTour.DataSource = ds_QLTour.Tables["Tours"];
        }



        void load_control(bool enable)
        {
            text_matour.Visible = enable;
            text_matour.Enabled = enable;
            text_tentour.Enabled = enable;
            text_ngaybatdau.Enabled = enable;
            text_ngayketthuc.Enabled = enable;
            text_gia.Enabled = enable;
            cbo_HDV.Enabled = enable;

            cbo_matour.Enabled = !enable;

            //comboBoxPT.Enabled = !enable;
            buttonthemdiemthamquan.Enabled = enable;
            buttonxoadiemthamquan.Enabled = enable;
            cbo_diemthamquan.Enabled = enable;
            cbo_phuongtien.Enabled = enable;
            cbo_HDV.Enabled = enable;

            buttonluu.Enabled = enable;
        }

        void load_dgvdiemthamquan_ao()
        {

            if (dataGridView_DTQ.DataSource != null)
            {
                dataGridView_DTQ.DataSource = null; // Set DataGridView's DataSource to null
            }

            dataGridView_DTQ.Columns.Add("col1", "MaDiemThamQuan");
            dataGridView_DTQ.Columns.Add("col2", "TenDiemThamQuan");
        }

        private void buttonthem_Click(object sender, EventArgs e)
        {
            them = true;
            text_matour.Visible = true;
            cbo_matour.Visible = false;

            load_control(true);
            text_matour.Focus();
            buttonhuy.Visible = true;
            buttonthem.Visible = false;
            buttonxoa.Enabled = false;
            buttonsua.Enabled = false;

            text_tentour.Clear();
            text_gia.Clear();

            diemThamQuans.Clear();
            load_dgvdiemthamquan_ao();
        }


        private void buttonsua_Click(object sender, EventArgs e)
        {
            load_control(true);
            text_matour.Text = cbo_matour.Text;
            them = false;
            buttonxoa.Enabled = false;
            buttonsua.Enabled = false;
            buttonthem.Visible = false;
            buttonhuy.Visible = true;

            diemThamQuans.Clear();
            List<DiemThamQuan> list = new List<DiemThamQuan>();
            foreach (DataGridViewRow row in dataGridView_DTQ.Rows)
            {
                string maDTQ = row.Cells[0].Value.ToString();
                list.Add(new DiemThamQuan(
                    maDTQ,
                     row.Cells[1].Value.ToString())
                    );
                diemThamQuans.Add(maDTQ);
            }

            load_dgvdiemthamquan_ao();
            foreach (DiemThamQuan dtq in list)
            {
                dataGridView_DTQ.Rows.Add(dtq.MaDiemThamQuan, dtq.TenDiemThamQuan);
            }
        }

        private void buttonhuy_Click(object sender, EventArgs e)
        {
            load_nhanvien();

            them = false;
            text_matour.Visible = false;
            cbo_matour.Visible = true;

            load_control(false);
            buttonhuy.Visible = false;
            buttonxoa.Enabled = true;
            buttonthem.Visible = true;
            buttonsua.Enabled = true;
            buttonxoa.Enabled = true;

            dataGridView_DTQ.Columns.Clear();
            load_dgvdiemthamquan(cbo_matour.Text);
        }

        private void buttonxem_Click(object sender, EventArgs e)
        {
            string matour = cbo_matour.SelectedItem.ToString();
            Chitiettour chitiet = new Chitiettour(matour);
            chitiet.Visible = true;




        }

        void load_dgvdiemthamquan(string matour)
        {
            if (ds_QLTour.Tables["DiemThamQuan"] != null)
                ds_QLTour.Tables["DiemThamQuan"].Clear();

            string strsel = "SELECT DCT.MaDiemThamQuan, TenDiemThamQuan FROM DiemThamQuanCuaTour DCT,DiemThamQuan D WHERE DCT.MaDiemThamQuan=D.MaDiemThamQuan and  DCT.MaTour = @code";
            SqlCommand command = new SqlCommand(strsel, _Connsql);
            command.Parameters.AddWithValue("@code", matour);
            SqlDataAdapter da_Tours = new SqlDataAdapter(command);
            da_Tours.Fill(ds_QLTour, "DiemThamQuan");

            dataGridView_DTQ.DataSource = ds_QLTour.Tables["DiemThamQuan"];

        }

        void load_nhanvien()
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
                    cbo_phuongtien.SelectedValue = reader["MaPhuongTien"].ToString();
                    cbo_HDV.SelectedValue = reader["MaNhanvien"].ToString();
                }
            }

            _Connsql.Close();
        }

        private void cbo_matour_SelectedIndexChanged(object sender, EventArgs e)
        {
            load_nhanvien();
            load_dgvdiemthamquan(cbo_matour.Text);
        }

        void themTour()
        {
            // Kiểm tra trùng chỉ khi thêm mới
            try
            {
                _Connsql.Open();
                string sql = "select * from Tours where MaTour = @MaTour";
                SqlCommand cmd = new SqlCommand(sql, _Connsql)
                {
                    CommandType = CommandType.Text
                };
                SqlParameter paraMaTour = new SqlParameter("@MaTour", text_matour.Text);
                cmd.Parameters.Add(paraMaTour);

                var reader = cmd.ExecuteReader();
                if (reader.HasRows)
                {
                    MessageBox.Show("Trùng mã.", "Thông báo");
                    reader.Close();
                    return;
                }
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
                command2.Parameters.AddWithValue("@MaNV", cbo_HDV.SelectedValue.ToString()); // Chú ý thay thế @MaKhachHang bằng @MaNV

                int count2 = (int)command2.ExecuteScalar();

                if (count2 > 0)
                {
                    MessageBox.Show("Nhân viên bạn chọn đã có tour trùng ngày với tour này!");
                    return;
                }




            

                // Cập nhật giá trị oldMaKhachHang cho lần thêm mới
                cmd = new SqlCommand(sql, _Connsql)
                {
                    CommandType = CommandType.Text
                };
                string matour = text_matour.Text.Trim(),
                tentour = text_tentour.Text.Trim();
                DateTime ngaybatdau = text_ngaybatdau.Value,
                    ngayketthuc = text_ngayketthuc.Value;
                int gia = int.Parse(text_gia.Text.Trim());
                string maphuongtien = cbo_phuongtien.SelectedValue.ToString(),
                    manhanvien = cbo_HDV.SelectedValue.ToString();
                SqlParameter[] paras;

                sql = "insert into Tours(MaTour, TenTour, NgayBatDau, NgayKetThuc, Gia, MaPhuongTien";
                if (manhanvien != "")
                {
                    sql += ", MaNhanvien) values (@MaTour, @TenTour, @NgayBatDau, @NgayKetThuc, @Gia, @MaPhuongtien, @MaNhanVien)";

                    paras = new SqlParameter[]{
                            new SqlParameter("@MaTour", matour),
                            new SqlParameter("@TenTour", tentour),
                            new SqlParameter("@NgayBatDau", ngaybatdau),
                            new SqlParameter("@NgayKetThuc", ngayketthuc),
                            new SqlParameter("@Gia", gia),
                            new SqlParameter("@MaPhuongtien", maphuongtien),
                            new SqlParameter("@MaNhanVien", manhanvien)
                        };
                }
                else
                {
                    sql += ") values (@MaTour, @TenTour, @NgayBatDau, @NgayKetThuc, @Gia, @MaPhuongtien)";
                    paras = new SqlParameter[]{
                            new SqlParameter("@MaTour", matour),
                            new SqlParameter("@TenTour", tentour),
                            new SqlParameter("@NgayBatDau", ngaybatdau),
                            new SqlParameter("@NgayKetThuc", ngayketthuc),
                            new SqlParameter("@Gia", gia),
                            new SqlParameter("@MaPhuongtien", maphuongtien),
                        };
                }
                cmd.CommandText = sql;
                cmd.Parameters.AddRange(paras);
                var result = cmd.ExecuteNonQuery();

                if (result > 0)
                {
                    LoadDuLieuDataGTour();
                }

                themDiemThamQuanVaoTour();

            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi: " + ex.Message);
            }
            finally
            {
                if (_Connsql.State != ConnectionState.Open)
                {
                    _Connsql.Close();
                }
            }
        }

        void suaTour()
        {
            try
            {
                _Connsql.Open();
                //if (_Connsql.State == ConnectionState.Closed)
                //{
                //    _Connsql.Open();
                //}
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
                command2.Parameters.AddWithValue("@MaNV", cbo_HDV.SelectedValue.ToString()); // Chú ý thay thế @MaKhachHang bằng @MaNV

                int count2 = (int)command2.ExecuteScalar();

                if (count2 > 0)
                {
                    MessageBox.Show("Nhân viên bạn chọn đã có tour trùng ngày với tour này!");
                    return;
                }

               
                string maPhuongTien = cbo_phuongtien.SelectedValue.ToString();
                string maNV = cbo_HDV.SelectedValue.ToString();
                string matour = cbo_matour.SelectedValue.ToString(),
                tentour = text_tentour.Text.ToString();
                DateTime ngaybatdau = text_ngaybatdau.Value,
                    ngayketthuc = text_ngayketthuc.Value;
                int gia = (int)double.Parse(text_gia.Text.Trim());

                string sql = "UPDATE Tours SET ";
                sql += "TenTour = @TenTour, ";
                sql += "NgayBatDau = @NgayBatDau, ";
                sql += "NgayKetThuc = @NgayKetThuc, ";
                sql += "Gia = @Gia, ";
                sql += "MaPhuongTien = @MaPhuongTien, ";
                sql += "MaNhanvien = @MaNhanVien";

                // Thêm điều kiện WHERE
                sql += " WHERE MaTour = @MaTour";

                SqlCommand cmd = new SqlCommand(sql, _Connsql);
                SqlParameter[] paras = new SqlParameter[]{
                    new SqlParameter("@MaTour", matour),
                    new SqlParameter("@TenTour", tentour),
                    new SqlParameter("@NgayBatDau", ngaybatdau),
                    new SqlParameter("@NgayKetThuc", ngayketthuc),
                    new SqlParameter("@Gia", gia),
                    new SqlParameter("@MaPhuongTien", maPhuongTien),
                    new SqlParameter("@MaNhanVien", maNV),
                    };

                cmd.Parameters.AddRange(paras);


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
                if (_Connsql.State != ConnectionState.Open)
                {
                    _Connsql.Close();
                }

            }

        }


        private void buttonluu_Click(object sender, EventArgs e)
        {
            if (them)
            {
                themTour();
                Load_comboboxmatour();
            }
            else
            {
                suaTour();
                suaDiemThamQuanCuaTour();

            }

            Load_comboboxdiemthamquan();
            LoadDuLieuDataGTour();

            buttonhuy_Click(this, EventArgs.Empty);
        }

        private void buttonthemdiemthamquan_Click(object sender, EventArgs e)
        {
            string maDTQ = cbo_diemthamquan.SelectedValue.ToString();
            string tenDTQ = ((DiemThamQuan)cbo_diemthamquan.SelectedItem).TenDiemThamQuan;

            if (!diemThamQuans.Contains(maDTQ))
            {
                diemThamQuans.Add(maDTQ);
                dataGridView_DTQ.Rows.Add(maDTQ, tenDTQ);
            }

        }

        private void buttonxoadiemthamquan_Click(object sender, EventArgs e)
        {
            string maDTQ = cbo_diemthamquan.SelectedValue.ToString();

            if (diemThamQuans.Contains(maDTQ))
            {
                diemThamQuans.Remove(maDTQ);
                foreach (DataGridViewRow row in dataGridView_DTQ.Rows)
                {
                    if (row.Cells[0].Value.ToString() == maDTQ)
                    {
                        dataGridView_DTQ.Rows.Remove(row);
                        break;
                    }
                }
            }

        }

        private void buttonxoa_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Xác nhận xóa tour " + text_tentour.Text, "Thông báo", MessageBoxButtons.YesNo, MessageBoxIcon.Question) != DialogResult.Yes)
            {
                return;
            }

            string maTour = cbo_matour.SelectedValue.ToString(); // Get the selected tour code
            _Connsql.Open();
            // Delete the tour from the database
            string sql = "DELETE FROM Tours WHERE MaTour = @MaTour";
            SqlCommand cmd = new SqlCommand(sql, _Connsql);
            cmd.Parameters.AddWithValue("@MaTour", maTour);

            string sql1 = "DELETE FROM KhachHangDatTour WHERE MaTour = @MaTour";
            SqlCommand cmd1 = new SqlCommand(sql1, _Connsql);
            cmd1.Parameters.AddWithValue("@MaTour", maTour);


            string sql2 = "DELETE FROM DiemThamQuanCuaTour WHERE MaTour = @MaTour";
            SqlCommand cmd2 = new SqlCommand(sql2, _Connsql);
            cmd2.Parameters.AddWithValue("@MaTour", maTour);

            try
            {

                cmd2.ExecuteNonQuery();
                cmd1.ExecuteNonQuery();
                cmd.ExecuteNonQuery();
                MessageBox.Show("Xóa tour thành công", "Thông báo");
                LoadDuLieuDataGTour();
                Load_comboboxmatour();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi: " + ex.Message, "Lỗi");
            }
            finally
            {
                if (_Connsql.State != ConnectionState.Closed)
                {
                    _Connsql.Close();
                }
            }
        }

        void themDiemThamQuanVaoTour()
        {
            string matour = text_matour.Text;

            if (_Connsql.State != ConnectionState.Open)
                _Connsql.Open();
            foreach (DataGridViewRow row in dataGridView_DTQ.Rows)
            {
                string sql = "INSERT INTO DIEMTHAMQUANCUATOUR VALUES(@MaTour, @MaDiemThamQuan)";
                SqlCommand cmd = new SqlCommand(sql, _Connsql);
                cmd.Parameters.Add(new SqlParameter("@MaTour", matour));
                cmd.Parameters.Add(new SqlParameter("@MaDiemThamQuan", row.Cells[0].Value.ToString()));

                cmd.ExecuteNonQuery();
            }
            _Connsql.Close();

        }

        void suaDiemThamQuanCuaTour()
        {
            string matour = text_matour.Text;

            if (_Connsql.State != ConnectionState.Open)
                _Connsql.Open();

            string sql = "DELETE FROM DIEMTHAMQUANCUATOUR WHERE MaTour = @MaTour";
            SqlCommand cmd = new SqlCommand(sql, _Connsql);
            cmd.Parameters.Add(new SqlParameter("@MaTour", matour));
            cmd.ExecuteNonQuery();


            themDiemThamQuanVaoTour();

            if (_Connsql.State == ConnectionState.Open)
                _Connsql.Close();
        }

        private void dataGridView_DTQ_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex > 0 && e.RowIndex < dataGridView_DTQ.Rows.Count)
            {
                cbo_diemthamquan.SelectedValue = dataGridView_DTQ.Rows[e.RowIndex].Cells[0].Value.ToString();
            }
        }

        private void btnIn_Click(object sender, EventArgs e)
        {
            string sql = "select MaTour, TenTour, NgayBatDau, NgayKetThuc, Gia, MaPhuongTien, MaNhanVien from Tours where Tours.MaTour = @MaTour";
            SqlCommand cmd = new SqlCommand(sql, _Connsql);
            cmd.Parameters.Clear();
            cmd.Parameters.AddWithValue("@MaTour", cbo_matour.SelectedValue.ToString());
            DataTable dtb = new DataTable("TTInTour");
            SqlDataAdapter da_Tours = new SqlDataAdapter(cmd);
            da_Tours.Fill(dtb);
            CrystalReport1 Tour = new CrystalReport1();
            Tour.SetDataSource(dtb);
            InHD HD = new InHD();
            HD.crystalReportViewer1.ReportSource = Tour;
            HD.ShowDialog();
            //---------------------------------------------------------
            string sql2 = "SELECT KH.MaKhachHang, KH.TenKhachHang, KH.GioiTinh, KH.DiaChi, KH.SoDienThoai FROM KhachHang KH JOIN KhachHangDatTour KHT ON KH.MaKhachHang = KHT.MaKhachHang where KHT.MaTour = @MaTour;";
            SqlCommand cmd2 = new SqlCommand(sql2, _Connsql);
            cmd2.Parameters.Clear();
            cmd2.Parameters.AddWithValue("@MaTour", cbo_matour.SelectedValue.ToString());
            DataTable dtb2 = new DataTable("TTInTour");
            SqlDataAdapter da_KhachHangDatTour = new SqlDataAdapter(cmd);
            da_KhachHangDatTour.Fill(dtb2);
            CrystalReport1 KHT = new CrystalReport1();
            KHT.SetDataSource(dtb2);
            InHD KH = new InHD();
            KH.crystalReportViewer1.ReportSource = KHT;
            KH.ShowDialog();
        }
    }
}
