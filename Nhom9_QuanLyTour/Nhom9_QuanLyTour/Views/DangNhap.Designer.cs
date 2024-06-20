namespace Nhom9_QuanLyTour.Views
{
    partial class DangNhap
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
            this.buttonDangNhap = new System.Windows.Forms.Button();
            this.buttonthoat = new System.Windows.Forms.Button();
            this.panel1 = new System.Windows.Forms.Panel();
            this.panel2 = new System.Windows.Forms.Panel();
            this.text_MK = new System.Windows.Forms.TextBox();
            this.text_TK = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.panel1.SuspendLayout();
            this.panel2.SuspendLayout();
            this.SuspendLayout();
            // 
            // buttonDangNhap
            // 
            this.buttonDangNhap.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.buttonDangNhap.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(202)))), ((int)(((byte)(240)))), ((int)(((byte)(248)))));
            this.buttonDangNhap.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(163)));
            this.buttonDangNhap.ForeColor = System.Drawing.Color.Black;
            this.buttonDangNhap.Image = global::Nhom9_QuanLyTour.Properties.Resources.icons8_user_30;
            this.buttonDangNhap.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.buttonDangNhap.Location = new System.Drawing.Point(32, 220);
            this.buttonDangNhap.Margin = new System.Windows.Forms.Padding(4);
            this.buttonDangNhap.Name = "buttonDangNhap";
            this.buttonDangNhap.Size = new System.Drawing.Size(134, 34);
            this.buttonDangNhap.TabIndex = 185;
            this.buttonDangNhap.Text = "Đăng Nhập";
            this.buttonDangNhap.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.buttonDangNhap.UseVisualStyleBackColor = false;
            this.buttonDangNhap.Click += new System.EventHandler(this.buttonDangNhap_Click);
            // 
            // buttonthoat
            // 
            this.buttonthoat.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(202)))), ((int)(((byte)(240)))), ((int)(((byte)(248)))));
            this.buttonthoat.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.buttonthoat.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(163)));
            this.buttonthoat.ForeColor = System.Drawing.Color.Black;
            this.buttonthoat.Image = global::Nhom9_QuanLyTour.Properties.Resources.icons8_close_40;
            this.buttonthoat.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.buttonthoat.Location = new System.Drawing.Point(298, 220);
            this.buttonthoat.Margin = new System.Windows.Forms.Padding(4);
            this.buttonthoat.Name = "buttonthoat";
            this.buttonthoat.Size = new System.Drawing.Size(107, 34);
            this.buttonthoat.TabIndex = 184;
            this.buttonthoat.Text = "Thoát";
            this.buttonthoat.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.buttonthoat.UseVisualStyleBackColor = false;
            this.buttonthoat.Click += new System.EventHandler(this.buttonthoat_Click);
            // 
            // panel1
            // 
            this.panel1.BackgroundImage = global::Nhom9_QuanLyTour.Properties.Resources.backrouge;
            this.panel1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.panel1.Controls.Add(this.panel2);
            this.panel1.Location = new System.Drawing.Point(-3, -2);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(871, 551);
            this.panel1.TabIndex = 1;
            // 
            // panel2
            // 
            this.panel2.BackColor = System.Drawing.Color.Transparent;
            this.panel2.BackgroundImage = global::Nhom9_QuanLyTour.Properties.Resources.vietnam_top_famous_landmark_silhouette_style_island_travel_tourism_vector_illustration_133558817_e1588825047766;
            this.panel2.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.panel2.Controls.Add(this.buttonDangNhap);
            this.panel2.Controls.Add(this.buttonthoat);
            this.panel2.Controls.Add(this.text_MK);
            this.panel2.Controls.Add(this.text_TK);
            this.panel2.Controls.Add(this.label2);
            this.panel2.Controls.Add(this.label1);
            this.panel2.Location = new System.Drawing.Point(235, 80);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(405, 270);
            this.panel2.TabIndex = 0;
            // 
            // text_MK
            // 
            this.text_MK.Location = new System.Drawing.Point(168, 136);
            this.text_MK.Name = "text_MK";
            this.text_MK.PasswordChar = '•';
            this.text_MK.Size = new System.Drawing.Size(185, 22);
            this.text_MK.TabIndex = 183;
            // 
            // text_TK
            // 
            this.text_TK.Location = new System.Drawing.Point(176, 77);
            this.text_TK.Multiline = true;
            this.text_TK.Name = "text_TK";
            this.text_TK.Size = new System.Drawing.Size(185, 24);
            this.text_TK.TabIndex = 182;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.BackColor = System.Drawing.Color.Aqua;
            this.label2.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(163)));
            this.label2.ForeColor = System.Drawing.SystemColors.WindowText;
            this.label2.Location = new System.Drawing.Point(70, 136);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(96, 23);
            this.label2.TabIndex = 181;
            this.label2.Text = "Mật khẩu ";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.BackColor = System.Drawing.Color.Aqua;
            this.label1.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.label1.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(163)));
            this.label1.ForeColor = System.Drawing.SystemColors.WindowText;
            this.label1.ImageAlign = System.Drawing.ContentAlignment.TopRight;
            this.label1.Location = new System.Drawing.Point(32, 76);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(142, 25);
            this.label1.TabIndex = 180;
            this.label1.Text = "Tên Đăng Nhập";
            // 
            // DangNhap
            // 
            this.AcceptButton = this.buttonDangNhap;
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.CancelButton = this.buttonthoat;
            this.ClientSize = new System.Drawing.Size(869, 561);
            this.Controls.Add(this.panel1);
            this.Name = "DangNhap";
            this.Text = "DangNhap";
            this.panel1.ResumeLayout(false);
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Button buttonDangNhap;
        private System.Windows.Forms.Button buttonthoat;
        private System.Windows.Forms.TextBox text_MK;
        private System.Windows.Forms.TextBox text_TK;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
    }
}