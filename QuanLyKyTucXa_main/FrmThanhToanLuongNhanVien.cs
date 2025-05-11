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

        private void FrmThanhToanLuongNhanVien_Load_1(object sender, EventArgs e)
        {
            dgvLuongnhanvien.DataSource = thanhToanLuongNhanVien_BL.LayDanhSachLuongNhanVien();
            

            dtpThang.Value = DateTime.Now;
            dtpNgaythanhtoan.Value = DateTime.Now;

            LoadPhuCapCombobox();
            LoadLuongCoBanCombobox();

        }

        private void LoadPhuCapCombobox()
        {
            cbPhucap.Items.Clear();
            cbPhucap.Items.Add("100000");
            cbPhucap.Items.Add("200000");
            cbPhucap.Items.Add("300000");
            cbPhucap.Items.Add("400000");
            cbPhucap.Items.Add("500000");
        }

        private void LoadLuongCoBanCombobox()
        {
            cbLuongcoban.Items.Clear();
            cbLuongcoban.Items.Add("5000000");
            cbLuongcoban.Items.Add("6000000");
            cbLuongcoban.Items.Add("7000000");
            cbLuongcoban.Items.Add("8000000");
            cbLuongcoban.Items.Add("9000000");
            cbLuongcoban.Items.Add("10000000");
        }

        public void SetNhanVien(string manv, string tennv)
        {
            txtManv.Text = manv;
            txtTennv.Text = tennv;
        }
        private void GBtnTinhluong_Click(object sender, EventArgs e)
        {
            try
            {
                decimal luongCoBan = decimal.Parse(cbLuongcoban.Text);
                decimal phuCap = decimal.Parse(cbPhucap.Text);
                decimal thuongPhat = decimal.Parse(txtThuongphat.Text);
                decimal tongLuong = luongCoBan + phuCap + thuongPhat;

                txtTongluong.Text = tongLuong.ToString("N0");

                LuongNhanVien luongNV = new LuongNhanVien(
                    txtMaluong.Text,
                    txtManv.Text,
                    txtTennv.Text,
                    dtpThang.Value.ToString("MM-yyyy"), // Định dạng tháng
                    cbLuongcoban.Text,
                    cbPhucap.Text,
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
                    cbLuongcoban.Text,
                    cbPhucap.Text,
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

        private void dgvLuongnhanvien_CellClick_1(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                DataGridViewRow row = dgvLuongnhanvien.Rows[e.RowIndex];
                txtMaluong.Text = row.Cells["maluong"].Value.ToString();
                txtManv.Text = row.Cells["manv"].Value.ToString();
                txtTennv.Text = row.Cells["tennv"].Value.ToString();
                dtpThang.Value = DateTime.ParseExact(row.Cells["thang"].Value.ToString(), "MM-yyyy", null);
                cbLuongcoban.Text = row.Cells["luongcoban"].Value.ToString();
                cbPhucap.Text = row.Cells["phucap"].Value.ToString();
                txtThuongphat.Text = row.Cells["thuongphat"].Value.ToString();
                dtpNgaythanhtoan.Value = DateTime.Parse(row.Cells["ngaythanhtoan"].Value.ToString());
                txtTongluong.Text = row.Cells["tongluong"].Value.ToString();
            }
        }

        private void GBtnLamsach_Click(object sender, EventArgs e)
        {
            txtMaluong.Text = "";
            txtManv.Text = "";
            cbPhucap.Text = "";
            txtTennv.Text = "";
            cbLuongcoban.Text = "";
            txtTongluong.Text = "";
            txtThuongphat.Text = "";
        }

        private void GBtnChonnhanvien_Click(object sender, EventArgs e)
        {
            DanhSachNhanVien dsNhanVien = new DanhSachNhanVien(this);
            dsNhanVien.ShowDialog();
        }

        private void GBtnTimkiem_Click(object sender, EventArgs e)
        {
            try
            {
                string keyword = txtTimkiem.Text.Trim();
                bool timTheoMa = rbTktheoma.Checked;

                if (string.IsNullOrEmpty(keyword))
                {
                    // Nếu ô tìm kiếm trống, load lại toàn bộ danh sách
                    dgvLuongnhanvien.DataSource = thanhToanLuongNhanVien_BL.LayDanhSachLuongNhanVien();
                    return;
                }

                // Gọi BLL để tìm kiếm
                List<LuongNhanVien> ketQua = thanhToanLuongNhanVien_BL.TimKiemLuongNhanVien(keyword, timTheoMa);

                // Hiển thị kết quả lên DataGridView
                dgvLuongnhanvien.DataSource = ketQua;

                if (ketQua.Count == 0)
                    MessageBox.Show("Không tìm thấy nhân viên phù hợp!");
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi: " + ex.Message);
            }
        }
    }
}

