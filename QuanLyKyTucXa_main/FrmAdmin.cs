using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace QuanLyKyTucXa_main
{
    public partial class FrmAdmin: Form
    {
        public FrmAdmin()
        {
            InitializeComponent();
        }

        private void btnQuanLyDay_Click(object sender, EventArgs e)
        {
            FrmQuanLyDay quanLyDay = new FrmQuanLyDay();
            quanLyDay.Show();
        }

        private void btnQuanLyNhanVien_Click(object sender, EventArgs e)
        {
            FrmQuanLyNhanVien quanLyNhanVien = new FrmQuanLyNhanVien();
            quanLyNhanVien.Show();
        }

        private void btnThanhtoanluong_Click(object sender, EventArgs e)
        {
            FrmThanhToanLuongNhanVien thanhToanLuongNhanVien = new FrmThanhToanLuongNhanVien();
            thanhToanLuongNhanVien.Show();
        }

        private void btnDanhSachPhong_Click(object sender, EventArgs e)
        {
            DanhSachDangKy danhSachDangKy = new DanhSachDangKy();
            danhSachDangKy.Show();
        }

        private void btnGuimaiThongbao_Click(object sender, EventArgs e)
        {
            FrmThongBaoSinhVien frmThongBaoSinhVien =  new FrmThongBaoSinhVien();
            frmThongBaoSinhVien.Show();
        }

        private void btnQuanlynguoidung_Click(object sender, EventArgs e)
        {
            FrmQuanLyNguoiDung frmQuanLyNguoiDung = new FrmQuanLyNguoiDung();
            frmQuanLyNguoiDung.Show();
        }
    }
}
