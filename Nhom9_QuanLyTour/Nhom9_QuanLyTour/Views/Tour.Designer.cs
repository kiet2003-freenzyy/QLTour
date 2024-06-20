namespace Nhom9_QuanLyTour
{
    partial class Tour
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Tour));
            this.dataGridViewTour = new System.Windows.Forms.DataGridView();
            this.text_gia = new System.Windows.Forms.TextBox();
            this.text_matour = new System.Windows.Forms.TextBox();
            this.text_tentour = new System.Windows.Forms.TextBox();
            this.labelmatour = new System.Windows.Forms.Label();
            this.labeltentour = new System.Windows.Forms.Label();
            this.labelngaybatdau = new System.Windows.Forms.Label();
            this.labelngayketthuc = new System.Windows.Forms.Label();
            this.labelgia = new System.Windows.Forms.Label();
            this.labelmaphuongtien = new System.Windows.Forms.Label();
            this.cbo_phuongtien = new System.Windows.Forms.ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.cbo_diemthamquan = new System.Windows.Forms.ComboBox();
            this.label3 = new System.Windows.Forms.Label();
            this.dataGridView_DTQ = new System.Windows.Forms.DataGridView();
            this.cbo_matour = new System.Windows.Forms.ComboBox();
            this.cbo_HDV = new System.Windows.Forms.ComboBox();
            this.text_ngaybatdau = new System.Windows.Forms.DateTimePicker();
            this.text_ngayketthuc = new System.Windows.Forms.DateTimePicker();
            this.buttonxem = new System.Windows.Forms.Button();
            this.buttonluu = new System.Windows.Forms.Button();
            this.buttonsua = new System.Windows.Forms.Button();
            this.buttonxoa = new System.Windows.Forms.Button();
            this.buttonxoadiemthamquan = new System.Windows.Forms.Button();
            this.buttonthemdiemthamquan = new System.Windows.Forms.Button();
            this.buttonthem = new System.Windows.Forms.Button();
            this.buttonhuy = new System.Windows.Forms.Button();
            this.btnIn = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewTour)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView_DTQ)).BeginInit();
            this.SuspendLayout();
            // 
            // dataGridViewTour
            // 
            this.dataGridViewTour.BackgroundColor = System.Drawing.SystemColors.Control;
            this.dataGridViewTour.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridViewTour.Location = new System.Drawing.Point(16, 402);
            this.dataGridViewTour.Margin = new System.Windows.Forms.Padding(4);
            this.dataGridViewTour.Name = "dataGridViewTour";
            this.dataGridViewTour.RowHeadersWidth = 51;
            this.dataGridViewTour.RowTemplate.DefaultCellStyle.BackColor = System.Drawing.Color.White;
            this.dataGridViewTour.RowTemplate.DefaultCellStyle.ForeColor = System.Drawing.Color.Black;
            this.dataGridViewTour.Size = new System.Drawing.Size(1352, 391);
            this.dataGridViewTour.TabIndex = 0;
            // 
            // text_gia
            // 
            this.text_gia.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F);
            this.text_gia.Location = new System.Drawing.Point(215, 250);
            this.text_gia.Margin = new System.Windows.Forms.Padding(4);
            this.text_gia.Name = "text_gia";
            this.text_gia.Size = new System.Drawing.Size(385, 30);
            this.text_gia.TabIndex = 123;
            // 
            // text_matour
            // 
            this.text_matour.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F);
            this.text_matour.Location = new System.Drawing.Point(215, 89);
            this.text_matour.Margin = new System.Windows.Forms.Padding(4);
            this.text_matour.Name = "text_matour";
            this.text_matour.Size = new System.Drawing.Size(385, 30);
            this.text_matour.TabIndex = 122;
            // 
            // text_tentour
            // 
            this.text_tentour.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F);
            this.text_tentour.Location = new System.Drawing.Point(215, 128);
            this.text_tentour.Margin = new System.Windows.Forms.Padding(4);
            this.text_tentour.Name = "text_tentour";
            this.text_tentour.Size = new System.Drawing.Size(385, 30);
            this.text_tentour.TabIndex = 119;
            // 
            // labelmatour
            // 
            this.labelmatour.BackColor = System.Drawing.Color.Transparent;
            this.labelmatour.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(163)));
            this.labelmatour.ForeColor = System.Drawing.Color.Black;
            this.labelmatour.Location = new System.Drawing.Point(29, 92);
            this.labelmatour.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.labelmatour.Name = "labelmatour";
            this.labelmatour.Size = new System.Drawing.Size(177, 25);
            this.labelmatour.TabIndex = 116;
            this.labelmatour.Text = "Mã Tour";
            this.labelmatour.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // labeltentour
            // 
            this.labeltentour.BackColor = System.Drawing.Color.Transparent;
            this.labeltentour.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(163)));
            this.labeltentour.ForeColor = System.Drawing.Color.Black;
            this.labeltentour.Location = new System.Drawing.Point(29, 130);
            this.labeltentour.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.labeltentour.Name = "labeltentour";
            this.labeltentour.Size = new System.Drawing.Size(177, 25);
            this.labeltentour.TabIndex = 114;
            this.labeltentour.Text = "Tên Tour";
            this.labeltentour.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // labelngaybatdau
            // 
            this.labelngaybatdau.BackColor = System.Drawing.Color.Transparent;
            this.labelngaybatdau.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(163)));
            this.labelngaybatdau.ForeColor = System.Drawing.Color.Black;
            this.labelngaybatdau.Location = new System.Drawing.Point(29, 170);
            this.labelngaybatdau.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.labelngaybatdau.Name = "labelngaybatdau";
            this.labelngaybatdau.Size = new System.Drawing.Size(177, 25);
            this.labelngaybatdau.TabIndex = 128;
            this.labelngaybatdau.Text = "Ngày bắt đầu";
            this.labelngaybatdau.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // labelngayketthuc
            // 
            this.labelngayketthuc.BackColor = System.Drawing.Color.Transparent;
            this.labelngayketthuc.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(163)));
            this.labelngayketthuc.ForeColor = System.Drawing.Color.Black;
            this.labelngayketthuc.Location = new System.Drawing.Point(29, 213);
            this.labelngayketthuc.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.labelngayketthuc.Name = "labelngayketthuc";
            this.labelngayketthuc.Size = new System.Drawing.Size(177, 25);
            this.labelngayketthuc.TabIndex = 129;
            this.labelngayketthuc.Text = "Ngày kết thúc";
            this.labelngayketthuc.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // labelgia
            // 
            this.labelgia.BackColor = System.Drawing.Color.Transparent;
            this.labelgia.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(163)));
            this.labelgia.ForeColor = System.Drawing.Color.Black;
            this.labelgia.Location = new System.Drawing.Point(20, 255);
            this.labelgia.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.labelgia.Name = "labelgia";
            this.labelgia.Size = new System.Drawing.Size(177, 25);
            this.labelgia.TabIndex = 131;
            this.labelgia.Text = "Giá";
            this.labelgia.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // labelmaphuongtien
            // 
            this.labelmaphuongtien.BackColor = System.Drawing.Color.Transparent;
            this.labelmaphuongtien.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(163)));
            this.labelmaphuongtien.ForeColor = System.Drawing.Color.Black;
            this.labelmaphuongtien.Location = new System.Drawing.Point(29, 292);
            this.labelmaphuongtien.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.labelmaphuongtien.Name = "labelmaphuongtien";
            this.labelmaphuongtien.Size = new System.Drawing.Size(177, 25);
            this.labelmaphuongtien.TabIndex = 132;
            this.labelmaphuongtien.Text = "Phương tiện";
            this.labelmaphuongtien.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // cbo_phuongtien
            // 
            this.cbo_phuongtien.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F);
            this.cbo_phuongtien.FormattingEnabled = true;
            this.cbo_phuongtien.Location = new System.Drawing.Point(215, 290);
            this.cbo_phuongtien.Margin = new System.Windows.Forms.Padding(4);
            this.cbo_phuongtien.Name = "cbo_phuongtien";
            this.cbo_phuongtien.Size = new System.Drawing.Size(385, 30);
            this.cbo_phuongtien.TabIndex = 133;
            // 
            // label1
            // 
            this.label1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(119)))), ((int)(((byte)(182)))));
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 20F, System.Drawing.FontStyle.Bold);
            this.label1.ForeColor = System.Drawing.Color.White;
            this.label1.Location = new System.Drawing.Point(-1, 1);
            this.label1.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(1383, 69);
            this.label1.TabIndex = 116;
            this.label1.Text = "QUẢN LÝ TOUR";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label2
            // 
            this.label2.BackColor = System.Drawing.Color.Transparent;
            this.label2.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(163)));
            this.label2.ForeColor = System.Drawing.Color.Black;
            this.label2.Location = new System.Drawing.Point(8, 331);
            this.label2.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(201, 25);
            this.label2.TabIndex = 132;
            this.label2.Text = "Hướng dẫn viên";
            this.label2.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // cbo_diemthamquan
            // 
            this.cbo_diemthamquan.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F);
            this.cbo_diemthamquan.FormattingEnabled = true;
            this.cbo_diemthamquan.Location = new System.Drawing.Point(983, 91);
            this.cbo_diemthamquan.Margin = new System.Windows.Forms.Padding(4);
            this.cbo_diemthamquan.Name = "cbo_diemthamquan";
            this.cbo_diemthamquan.Size = new System.Drawing.Size(280, 30);
            this.cbo_diemthamquan.TabIndex = 133;
            // 
            // label3
            // 
            this.label3.BackColor = System.Drawing.Color.Transparent;
            this.label3.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(163)));
            this.label3.ForeColor = System.Drawing.Color.Black;
            this.label3.Location = new System.Drawing.Point(776, 94);
            this.label3.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(201, 25);
            this.label3.TabIndex = 132;
            this.label3.Text = "Điểm tham quan";
            this.label3.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // dataGridView_DTQ
            // 
            this.dataGridView_DTQ.BackgroundColor = System.Drawing.SystemColors.ControlLightLight;
            this.dataGridView_DTQ.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView_DTQ.Location = new System.Drawing.Point(811, 130);
            this.dataGridView_DTQ.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.dataGridView_DTQ.Name = "dataGridView_DTQ";
            this.dataGridView_DTQ.RowHeadersWidth = 51;
            this.dataGridView_DTQ.RowTemplate.DefaultCellStyle.ForeColor = System.Drawing.Color.Black;
            this.dataGridView_DTQ.RowTemplate.Height = 24;
            this.dataGridView_DTQ.Size = new System.Drawing.Size(549, 251);
            this.dataGridView_DTQ.TabIndex = 136;
            this.dataGridView_DTQ.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridView_DTQ_CellClick);
            // 
            // cbo_matour
            // 
            this.cbo_matour.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F);
            this.cbo_matour.FormattingEnabled = true;
            this.cbo_matour.Location = new System.Drawing.Point(215, 90);
            this.cbo_matour.Margin = new System.Windows.Forms.Padding(4);
            this.cbo_matour.Name = "cbo_matour";
            this.cbo_matour.Size = new System.Drawing.Size(385, 30);
            this.cbo_matour.TabIndex = 133;
            this.cbo_matour.SelectedIndexChanged += new System.EventHandler(this.cbo_matour_SelectedIndexChanged);
            // 
            // cbo_HDV
            // 
            this.cbo_HDV.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F);
            this.cbo_HDV.FormattingEnabled = true;
            this.cbo_HDV.Location = new System.Drawing.Point(215, 329);
            this.cbo_HDV.Margin = new System.Windows.Forms.Padding(4);
            this.cbo_HDV.Name = "cbo_HDV";
            this.cbo_HDV.Size = new System.Drawing.Size(385, 30);
            this.cbo_HDV.TabIndex = 133;
            // 
            // text_ngaybatdau
            // 
            this.text_ngaybatdau.CalendarFont = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(163)));
            this.text_ngaybatdau.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F);
            this.text_ngaybatdau.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.text_ngaybatdau.Location = new System.Drawing.Point(215, 167);
            this.text_ngaybatdau.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.text_ngaybatdau.Name = "text_ngaybatdau";
            this.text_ngaybatdau.Size = new System.Drawing.Size(385, 30);
            this.text_ngaybatdau.TabIndex = 138;
            // 
            // text_ngayketthuc
            // 
            this.text_ngayketthuc.CalendarFont = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(163)));
            this.text_ngayketthuc.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(163)));
            this.text_ngayketthuc.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.text_ngayketthuc.Location = new System.Drawing.Point(215, 210);
            this.text_ngayketthuc.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.text_ngayketthuc.Name = "text_ngayketthuc";
            this.text_ngayketthuc.Size = new System.Drawing.Size(385, 30);
            this.text_ngayketthuc.TabIndex = 138;
            // 
            // buttonxem
            // 
            this.buttonxem.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(202)))), ((int)(((byte)(240)))), ((int)(((byte)(248)))));
            this.buttonxem.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(163)));
            this.buttonxem.ForeColor = System.Drawing.Color.Black;
            this.buttonxem.Image = global::Nhom9_QuanLyTour.Properties.Resources.icons8_eye_30;
            this.buttonxem.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.buttonxem.Location = new System.Drawing.Point(647, 74);
            this.buttonxem.Margin = new System.Windows.Forms.Padding(4);
            this.buttonxem.Name = "buttonxem";
            this.buttonxem.Size = new System.Drawing.Size(121, 44);
            this.buttonxem.TabIndex = 135;
            this.buttonxem.Text = "Xem";
            this.buttonxem.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.buttonxem.UseVisualStyleBackColor = false;
            this.buttonxem.Click += new System.EventHandler(this.buttonxem_Click);
            // 
            // buttonluu
            // 
            this.buttonluu.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(202)))), ((int)(((byte)(240)))), ((int)(((byte)(248)))));
            this.buttonluu.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(163)));
            this.buttonluu.ForeColor = System.Drawing.Color.Black;
            this.buttonluu.Image = ((System.Drawing.Image)(resources.GetObject("buttonluu.Image")));
            this.buttonluu.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.buttonluu.Location = new System.Drawing.Point(647, 286);
            this.buttonluu.Margin = new System.Windows.Forms.Padding(4);
            this.buttonluu.Name = "buttonluu";
            this.buttonluu.Size = new System.Drawing.Size(121, 44);
            this.buttonluu.TabIndex = 130;
            this.buttonluu.Text = "Lưu";
            this.buttonluu.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.buttonluu.UseVisualStyleBackColor = false;
            this.buttonluu.Click += new System.EventHandler(this.buttonluu_Click);
            // 
            // buttonsua
            // 
            this.buttonsua.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(202)))), ((int)(((byte)(240)))), ((int)(((byte)(248)))));
            this.buttonsua.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(163)));
            this.buttonsua.ForeColor = System.Drawing.Color.Black;
            this.buttonsua.Image = global::Nhom9_QuanLyTour.Properties.Resources.icons8_pen_30;
            this.buttonsua.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.buttonsua.Location = new System.Drawing.Point(647, 234);
            this.buttonsua.Margin = new System.Windows.Forms.Padding(4);
            this.buttonsua.Name = "buttonsua";
            this.buttonsua.Size = new System.Drawing.Size(121, 44);
            this.buttonsua.TabIndex = 8;
            this.buttonsua.Text = "Sửa";
            this.buttonsua.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.buttonsua.UseVisualStyleBackColor = false;
            this.buttonsua.Click += new System.EventHandler(this.buttonsua_Click);
            // 
            // buttonxoa
            // 
            this.buttonxoa.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(202)))), ((int)(((byte)(240)))), ((int)(((byte)(248)))));
            this.buttonxoa.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(163)));
            this.buttonxoa.ForeColor = System.Drawing.Color.Black;
            this.buttonxoa.Image = global::Nhom9_QuanLyTour.Properties.Resources.icons8_delete_30;
            this.buttonxoa.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.buttonxoa.Location = new System.Drawing.Point(647, 182);
            this.buttonxoa.Margin = new System.Windows.Forms.Padding(4);
            this.buttonxoa.Name = "buttonxoa";
            this.buttonxoa.Size = new System.Drawing.Size(121, 44);
            this.buttonxoa.TabIndex = 7;
            this.buttonxoa.Text = "Xóa";
            this.buttonxoa.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.buttonxoa.UseVisualStyleBackColor = false;
            this.buttonxoa.Click += new System.EventHandler(this.buttonxoa_Click);
            // 
            // buttonxoadiemthamquan
            // 
            this.buttonxoadiemthamquan.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(202)))), ((int)(((byte)(240)))), ((int)(((byte)(248)))));
            this.buttonxoadiemthamquan.BackgroundImage = global::Nhom9_QuanLyTour.Properties.Resources.icons8_delete_30;
            this.buttonxoadiemthamquan.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.buttonxoadiemthamquan.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F);
            this.buttonxoadiemthamquan.ForeColor = System.Drawing.Color.Black;
            this.buttonxoadiemthamquan.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.buttonxoadiemthamquan.Location = new System.Drawing.Point(1319, 89);
            this.buttonxoadiemthamquan.Margin = new System.Windows.Forms.Padding(4);
            this.buttonxoadiemthamquan.Name = "buttonxoadiemthamquan";
            this.buttonxoadiemthamquan.Size = new System.Drawing.Size(40, 37);
            this.buttonxoadiemthamquan.TabIndex = 6;
            this.buttonxoadiemthamquan.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.buttonxoadiemthamquan.UseVisualStyleBackColor = false;
            this.buttonxoadiemthamquan.Click += new System.EventHandler(this.buttonxoadiemthamquan_Click);
            // 
            // buttonthemdiemthamquan
            // 
            this.buttonthemdiemthamquan.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(202)))), ((int)(((byte)(240)))), ((int)(((byte)(248)))));
            this.buttonthemdiemthamquan.BackgroundImage = global::Nhom9_QuanLyTour.Properties.Resources.icons8_plus_30;
            this.buttonthemdiemthamquan.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.buttonthemdiemthamquan.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F);
            this.buttonthemdiemthamquan.ForeColor = System.Drawing.Color.Black;
            this.buttonthemdiemthamquan.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.buttonthemdiemthamquan.Location = new System.Drawing.Point(1271, 89);
            this.buttonthemdiemthamquan.Margin = new System.Windows.Forms.Padding(4);
            this.buttonthemdiemthamquan.Name = "buttonthemdiemthamquan";
            this.buttonthemdiemthamquan.Size = new System.Drawing.Size(40, 37);
            this.buttonthemdiemthamquan.TabIndex = 6;
            this.buttonthemdiemthamquan.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.buttonthemdiemthamquan.UseVisualStyleBackColor = false;
            this.buttonthemdiemthamquan.Click += new System.EventHandler(this.buttonthemdiemthamquan_Click);
            // 
            // buttonthem
            // 
            this.buttonthem.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(202)))), ((int)(((byte)(240)))), ((int)(((byte)(248)))));
            this.buttonthem.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(163)));
            this.buttonthem.ForeColor = System.Drawing.Color.Black;
            this.buttonthem.Image = global::Nhom9_QuanLyTour.Properties.Resources.icons8_plus_30;
            this.buttonthem.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.buttonthem.Location = new System.Drawing.Point(647, 130);
            this.buttonthem.Margin = new System.Windows.Forms.Padding(4);
            this.buttonthem.Name = "buttonthem";
            this.buttonthem.Size = new System.Drawing.Size(121, 44);
            this.buttonthem.TabIndex = 6;
            this.buttonthem.Text = "Thêm";
            this.buttonthem.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.buttonthem.UseVisualStyleBackColor = false;
            this.buttonthem.Click += new System.EventHandler(this.buttonthem_Click);
            // 
            // buttonhuy
            // 
            this.buttonhuy.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(202)))), ((int)(((byte)(240)))), ((int)(((byte)(248)))));
            this.buttonhuy.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F);
            this.buttonhuy.ForeColor = System.Drawing.Color.Black;
            this.buttonhuy.Image = global::Nhom9_QuanLyTour.Properties.Resources.icons8_x_30;
            this.buttonhuy.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.buttonhuy.Location = new System.Drawing.Point(647, 130);
            this.buttonhuy.Margin = new System.Windows.Forms.Padding(4);
            this.buttonhuy.Name = "buttonhuy";
            this.buttonhuy.Size = new System.Drawing.Size(121, 44);
            this.buttonhuy.TabIndex = 137;
            this.buttonhuy.Text = "Hủy";
            this.buttonhuy.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.buttonhuy.UseVisualStyleBackColor = false;
            this.buttonhuy.Click += new System.EventHandler(this.buttonhuy_Click);
            // 
            // btnIn
            // 
            this.btnIn.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(202)))), ((int)(((byte)(240)))), ((int)(((byte)(248)))));
            this.btnIn.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(163)));
            this.btnIn.ForeColor = System.Drawing.Color.Black;
            this.btnIn.Image = ((System.Drawing.Image)(resources.GetObject("btnIn.Image")));
            this.btnIn.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnIn.Location = new System.Drawing.Point(647, 337);
            this.btnIn.Margin = new System.Windows.Forms.Padding(4);
            this.btnIn.Name = "btnIn";
            this.btnIn.Size = new System.Drawing.Size(121, 44);
            this.btnIn.TabIndex = 139;
            this.btnIn.Text = "In";
            this.btnIn.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnIn.UseVisualStyleBackColor = false;
            this.btnIn.Click += new System.EventHandler(this.btnIn_Click);
            // 
            // Tour
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(173)))), ((int)(((byte)(232)))), ((int)(((byte)(244)))));
            this.ClientSize = new System.Drawing.Size(1381, 800);
            this.Controls.Add(this.btnIn);
            this.Controls.Add(this.dataGridView_DTQ);
            this.Controls.Add(this.buttonxem);
            this.Controls.Add(this.cbo_matour);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.labelmaphuongtien);
            this.Controls.Add(this.cbo_diemthamquan);
            this.Controls.Add(this.cbo_HDV);
            this.Controls.Add(this.cbo_phuongtien);
            this.Controls.Add(this.labelgia);
            this.Controls.Add(this.buttonluu);
            this.Controls.Add(this.labelngayketthuc);
            this.Controls.Add(this.labelngaybatdau);
            this.Controls.Add(this.text_gia);
            this.Controls.Add(this.text_matour);
            this.Controls.Add(this.text_tentour);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.labelmatour);
            this.Controls.Add(this.labeltentour);
            this.Controls.Add(this.buttonsua);
            this.Controls.Add(this.buttonxoa);
            this.Controls.Add(this.buttonxoadiemthamquan);
            this.Controls.Add(this.buttonthemdiemthamquan);
            this.Controls.Add(this.dataGridViewTour);
            this.Controls.Add(this.buttonthem);
            this.Controls.Add(this.buttonhuy);
            this.Controls.Add(this.text_ngayketthuc);
            this.Controls.Add(this.text_ngaybatdau);
            this.ForeColor = System.Drawing.Color.White;
            this.Margin = new System.Windows.Forms.Padding(4);
            this.Name = "Tour";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Tour";
            this.Load += new System.EventHandler(this.Tour_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewTour)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView_DTQ)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataGridView dataGridViewTour;
        private System.Windows.Forms.Button buttonsua;
        private System.Windows.Forms.Button buttonxoa;
        private System.Windows.Forms.Button buttonthem;
        private System.Windows.Forms.TextBox text_gia;
        private System.Windows.Forms.TextBox text_matour;
        private System.Windows.Forms.TextBox text_tentour;
        private System.Windows.Forms.Label labelmatour;
        private System.Windows.Forms.Label labeltentour;
        private System.Windows.Forms.Label labelngaybatdau;
        private System.Windows.Forms.Label labelngayketthuc;
        private System.Windows.Forms.Button buttonluu;
        private System.Windows.Forms.Label labelgia;
        private System.Windows.Forms.Label labelmaphuongtien;
        private System.Windows.Forms.ComboBox cbo_phuongtien;
        private System.Windows.Forms.Button buttonxem;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.ComboBox cbo_diemthamquan;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.DataGridView dataGridView_DTQ;
        private System.Windows.Forms.Button buttonthemdiemthamquan;
        private System.Windows.Forms.Button buttonhuy;
        private System.Windows.Forms.Button buttonxoadiemthamquan;
        private System.Windows.Forms.ComboBox cbo_matour;
        private System.Windows.Forms.ComboBox cbo_HDV;
        private System.Windows.Forms.DateTimePicker text_ngaybatdau;
        private System.Windows.Forms.DateTimePicker text_ngayketthuc;
        private System.Windows.Forms.Button btnIn;
    }
}