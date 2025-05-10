namespace QuanLyKyTucXa_main
{
    partial class FrmAdmin
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
            this.btnThanhtoanluong = new System.Windows.Forms.Button();
            this.btnQuanLyNhanVien = new System.Windows.Forms.Button();
            this.btnQuanLyDay = new System.Windows.Forms.Button();
            this.btnDanhSachPhong = new System.Windows.Forms.Button();
            this.btnQuanlynguoidung = new System.Windows.Forms.Button();
            this.btnGuimaiThongbao = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // btnThanhtoanluong
            // 
            this.btnThanhtoanluong.Location = new System.Drawing.Point(539, 181);
            this.btnThanhtoanluong.Name = "btnThanhtoanluong";
            this.btnThanhtoanluong.Size = new System.Drawing.Size(157, 71);
            this.btnThanhtoanluong.TabIndex = 9;
            this.btnThanhtoanluong.Text = "Thanh toán lương nhân viên";
            this.btnThanhtoanluong.UseVisualStyleBackColor = true;
            this.btnThanhtoanluong.Click += new System.EventHandler(this.btnThanhtoanluong_Click);
            // 
            // btnQuanLyNhanVien
            // 
            this.btnQuanLyNhanVien.Location = new System.Drawing.Point(539, 332);
            this.btnQuanLyNhanVien.Name = "btnQuanLyNhanVien";
            this.btnQuanLyNhanVien.Size = new System.Drawing.Size(157, 71);
            this.btnQuanLyNhanVien.TabIndex = 8;
            this.btnQuanLyNhanVien.Text = "Quản Lý Nhân Viên";
            this.btnQuanLyNhanVien.UseVisualStyleBackColor = true;
            this.btnQuanLyNhanVien.Click += new System.EventHandler(this.btnQuanLyNhanVien_Click);
            // 
            // btnQuanLyDay
            // 
            this.btnQuanLyDay.Location = new System.Drawing.Point(49, 55);
            this.btnQuanLyDay.Name = "btnQuanLyDay";
            this.btnQuanLyDay.Size = new System.Drawing.Size(157, 71);
            this.btnQuanLyDay.TabIndex = 7;
            this.btnQuanLyDay.Text = "Quản lý dãy";
            this.btnQuanLyDay.UseVisualStyleBackColor = true;
            this.btnQuanLyDay.Click += new System.EventHandler(this.btnQuanLyDay_Click);
            // 
            // btnDanhSachPhong
            // 
            this.btnDanhSachPhong.Location = new System.Drawing.Point(282, 55);
            this.btnDanhSachPhong.Name = "btnDanhSachPhong";
            this.btnDanhSachPhong.Size = new System.Drawing.Size(157, 71);
            this.btnDanhSachPhong.TabIndex = 6;
            this.btnDanhSachPhong.Text = "Danh Sách Phòng";
            this.btnDanhSachPhong.UseVisualStyleBackColor = true;
            this.btnDanhSachPhong.Click += new System.EventHandler(this.btnDanhSachPhong_Click);
            // 
            // btnQuanlynguoidung
            // 
            this.btnQuanlynguoidung.Location = new System.Drawing.Point(539, 55);
            this.btnQuanlynguoidung.Name = "btnQuanlynguoidung";
            this.btnQuanlynguoidung.Size = new System.Drawing.Size(157, 71);
            this.btnQuanlynguoidung.TabIndex = 10;
            this.btnQuanlynguoidung.Text = "Quản Lý Người Dùng";
            this.btnQuanlynguoidung.UseVisualStyleBackColor = true;
            this.btnQuanlynguoidung.Click += new System.EventHandler(this.btnQuanlynguoidung_Click);
            // 
            // btnGuimaiThongbao
            // 
            this.btnGuimaiThongbao.Location = new System.Drawing.Point(49, 181);
            this.btnGuimaiThongbao.Name = "btnGuimaiThongbao";
            this.btnGuimaiThongbao.Size = new System.Drawing.Size(161, 71);
            this.btnGuimaiThongbao.TabIndex = 11;
            this.btnGuimaiThongbao.Text = "Gửi mail thông báo";
            this.btnGuimaiThongbao.UseVisualStyleBackColor = true;
            this.btnGuimaiThongbao.Click += new System.EventHandler(this.btnGuimaiThongbao_Click);
            // 
            // FrmAdmin
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(850, 512);
            this.Controls.Add(this.btnGuimaiThongbao);
            this.Controls.Add(this.btnQuanlynguoidung);
            this.Controls.Add(this.btnThanhtoanluong);
            this.Controls.Add(this.btnQuanLyNhanVien);
            this.Controls.Add(this.btnQuanLyDay);
            this.Controls.Add(this.btnDanhSachPhong);
            this.Name = "FrmAdmin";
            this.Text = "FrmAdmin";
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button btnThanhtoanluong;
        private System.Windows.Forms.Button btnQuanLyNhanVien;
        private System.Windows.Forms.Button btnQuanLyDay;
        private System.Windows.Forms.Button btnDanhSachPhong;
        private System.Windows.Forms.Button btnQuanlynguoidung;
        private System.Windows.Forms.Button btnGuimaiThongbao;
    }
}