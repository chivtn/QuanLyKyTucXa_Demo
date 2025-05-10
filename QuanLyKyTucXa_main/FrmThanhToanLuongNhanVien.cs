using QuanLy_BLL;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using TransferObject;

namespace QuanLyKyTucXa_main
{
    public partial class FrmThanhToanLuongNhanVien : Form
    {
        private ThanhToanLuongNhanVien_BL thanhToanLuongNhanVien_BL;
        public FrmThanhToanLuongNhanVien()
        {
            InitializeComponent();
            thanhToanLuongNhanVien_BL = new ThanhToanLuongNhanVien_BL();
        }

        private void GBtnTinhluong_Click(object sender, EventArgs e)
        {
            try
            {
                decimal luongCoBan = decimal.Parse(txtLuongcoban.Text);
                decimal phuCap = decimal.Parse(txtPhucap.Text);
                decimal thuongPhat = decimal.Parse(txtThuongphat.Text);
                decimal tongLuong = luongCoBan + phuCap + thuongPhat;

                txtTongluong.Text = tongLuong.ToString("N0");

                LuongNhanVien luongNV = new LuongNhanVien(
                    txtMaluong.Text,
                    txtManv.Text,
                    txtTennv.Text,
                    dtpThang.Value.ToString("MM-yyyy"), // Định dạng tháng
                    txtLuongcoban.Text,
                    txtPhucap.Text,
                    txtThuongphat.Text,
                    dtpNgaythanhtoan.Value.ToString("yyyy-MM-dd"), // Ngày thanh toán
                    tongLuong.ToString()
                );

                thanhToanLuongNhanVien_BL.ThemHoacCapNhatLuong(luongNV);
                dgvLuongnhanvien.DataSource = thanhToanLuongNhanVien_BL.LayDanhSachLuongNhanVien();
            }
            catch (Exception ex) { MessageBox.Show("Lỗi: " + ex.Message); }
        }

        private void GBtnSua_Click(object sender, EventArgs e)
        {
            try
            {
                if (string.IsNullOrEmpty(txtMaluong.Text))
                    throw new Exception("Vui lòng chọn hóa đơn cần sửa");

                // Tạo đối tượng cập nhật
                LuongNhanVien luongNV = new LuongNhanVien(
                    txtMaluong.Text,
                    txtManv.Text,
                    txtTennv.Text,
                    dtpThang.Value.ToString("yyyy-MM-dd"),
                    txtLuongcoban.Text,
                    txtPhucap.Text,
                    txtThuongphat.Text,
                    dtpNgaythanhtoan.Value.ToString("yyyy-MM-dd"),
                    txtTongluong.Text
                );

                // Gọi phương thức cập nhật
                thanhToanLuongNhanVien_BL.CapNhatLuongNhanVien(luongNV);

                // Làm mới DataGridView
                dgvLuongnhanvien.DataSource = thanhToanLuongNhanVien_BL.LayDanhSachLuongNhanVien();
                MessageBox.Show("Cập nhật thành công!");
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi: " + ex.Message);
            }
        }

        private void GBtnXoa_Click(object sender, EventArgs e)
        {
            try
            {
                if (string.IsNullOrEmpty(txtMaluong.Text))
                    throw new Exception("Vui lòng chọn hóa đơn cần xóa");

                // Gọi phương thức xóa
                thanhToanLuongNhanVien_BL.XoaLuongNhanVien(txtMaluong.Text);

                // Làm mới DataGridView
                dgvLuongnhanvien.DataSource = thanhToanLuongNhanVien_BL.LayDanhSachLuongNhanVien();
                MessageBox.Show("Xóa thành công!");
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi: " + ex.Message);
            }
        }


        private void dgvNhanvien_CellClick_1(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                DataGridViewRow row = dgvNhanvien.Rows[e.RowIndex];
                txtManv.Text = row.Cells["maNhanVien"].Value.ToString();
                txtTennv.Text = row.Cells["tenNhanVien"].Value.ToString();
            }
        }

        private void FrmThanhToanLuongNhanVien_Load_1(object sender, EventArgs e)
        {
            dgvLuongnhanvien.DataSource = thanhToanLuongNhanVien_BL.LayDanhSachLuongNhanVien();
            dgvNhanvien.DataSource = thanhToanLuongNhanVien_BL.LayDanhSachNhanVien();
        }

        private void dgvLuongnhanvien_CellClick_1(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                DataGridViewRow row = dgvLuongnhanvien.Rows[e.RowIndex];
                txtMaluong.Text = row.Cells["maluong"].Value.ToString();
                txtManv.Text = row.Cells["manv"].Value.ToString();
                txtTennv.Text = row.Cells["tennv"].Value.ToString();
                dtpThang.Value = DateTime.ParseExact(row.Cells["thang"].Value.ToString(), "MM-yyyy", null);
                txtLuongcoban.Text = row.Cells["luongcoban"].Value.ToString();
                txtPhucap.Text = row.Cells["phucap"].Value.ToString();
                txtThuongphat.Text = row.Cells["thuongphat"].Value.ToString();
                dtpNgaythanhtoan.Value = DateTime.Parse(row.Cells["ngaythanhtoan"].Value.ToString());
                txtTongluong.Text = row.Cells["tongluong"].Value.ToString();
            }
        }

        private void dgvNhanvien_CellClick_2(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                DataGridViewRow row = dgvNhanvien.Rows[e.RowIndex];
                //txtManv.Text = row.Cells["manv"].Value.ToString();
                //txtTennv.Text = row.Cells["tennv"].Value.ToString();

                txtManv.Text = row.Cells[0].Value?.ToString() ?? "";
                txtTennv.Text = row.Cells[1].Value?.ToString() ?? "";

            }
        }
    }
}

