﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using TransferObject;
using QuanLy_BLL;

namespace QuanLyKyTucXa_main
{
    public partial class FrmQuanLyNguoiDung: Form
    {
        private QuanLyNguoiDung_BL quanLyNguoiDung_BL;
        public FrmQuanLyNguoiDung()
        {
            InitializeComponent();
            quanLyNguoiDung_BL = new QuanLyNguoiDung_BL();
        }


        private void FrmQuanLyNguoiDung_Load(object sender, EventArgs e)
        {
            dgvNguoidung.DataSource = quanLyNguoiDung_BL.LayDanhSachNguoiDung();
        }


        private void GBtnThem_Click(object sender, EventArgs e)
        {
            try
            {
                // Kiểm tra dữ liệu nhập
                if (string.IsNullOrEmpty(txtTendangnhap.Text) || string.IsNullOrEmpty(txtMatkhau.Text))
                {
                    MessageBox.Show("Vui lòng nhập đầy đủ thông tin!");
                    return;
                }

                // Tạo đối tượng người dùng
                NguoiDung nguoiDung = new NguoiDung(
                    txtTendangnhap.Text.Trim(),
                    txtMatkhau.Text.Trim()
                );

                // Thêm vào CSDL
                bool result = quanLyNguoiDung_BL.ThemNguoiDung(nguoiDung);
                if (result)
                {
                    MessageBox.Show("Thêm người dùng thành công!");
                    // Làm mới DataGridView
                    dgvNguoidung.DataSource = quanLyNguoiDung_BL.LayDanhSachNguoiDung();
                    // Xóa dữ liệu nhập
                    txtTendangnhap.Clear();
                    txtMatkhau.Clear();
                }
                else
                {
                    MessageBox.Show("Thêm thất bại!");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi: " + ex.Message);
            }
        }

        private void GBtnSua_Click(object sender, EventArgs e)
        {
            try
            {
                if (string.IsNullOrEmpty(txtId.Text))
                {
                    MessageBox.Show("Vui lòng chọn người dùng cần sửa!");
                    return;
                }

                // Tạo đối tượng người dùng từ thông tin đã chỉnh sửa
                QuanLyNguoiDung nguoiDung = new QuanLyNguoiDung(
                    txtId.Text,
                    txtTendangnhap.Text.Trim(),
                    txtMatkhau.Text.Trim()
                );

                // Gọi phương thức sửa từ BLL
                bool result = quanLyNguoiDung_BL.SuaNguoiDung(nguoiDung);
                if (result)
                {
                    MessageBox.Show("Cập nhật thành công!");
                    dgvNguoidung.DataSource = quanLyNguoiDung_BL.LayDanhSachNguoiDung();
                }
                else
                {
                    MessageBox.Show("Cập nhật thất bại!");
                }
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
                if (string.IsNullOrEmpty(txtId.Text))
                {
                    MessageBox.Show("Vui lòng chọn người dùng cần xóa!");
                    return;
                }

                // Xác nhận xóa
                DialogResult confirm = MessageBox.Show(
                    "Bạn có chắc chắn muốn xóa người dùng này?",
                    "Xác nhận",
                    MessageBoxButtons.YesNo
                );

                if (confirm == DialogResult.Yes)
                {
                    // Gọi phương thức xóa từ BLL
                    bool result = quanLyNguoiDung_BL.XoaNguoiDung(txtId.Text);
                    if (result)
                    {
                        MessageBox.Show("Xóa thành công!");
                        dgvNguoidung.DataSource = quanLyNguoiDung_BL.LayDanhSachNguoiDung();
                        // Xóa dữ liệu trên form
                        txtId.Clear();
                        txtTendangnhap.Clear();
                        txtMatkhau.Clear();
                    }
                    else
                    {
                        MessageBox.Show("Xóa thất bại!");
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi: " + ex.Message);
            }
        }

        private void rbManv_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void GBtnTimkiem_Click(object sender, EventArgs e)
        {
            try
            {
                string keyword = txtTimkiem.Text.Trim();
                bool timTheoMa = rbManv.Checked;

                if (string.IsNullOrEmpty(keyword))
                {
                    // Nếu ô tìm kiếm trống, load lại toàn bộ danh sách
                    dgvNguoidung.DataSource = quanLyNguoiDung_BL.LayDanhSachNguoiDung();
                    return;
                }

                // Gọi BLL để tìm kiếm
                List<QuanLyNguoiDung> ketQua = quanLyNguoiDung_BL.TimKiemNguoiDung(keyword, timTheoMa);

                // Hiển thị kết quả lên DataGridView
                dgvNguoidung.DataSource = ketQua;

                if (ketQua.Count == 0)
                    MessageBox.Show("Không tìm thấy nhân viên phù hợp!");
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi: " + ex.Message);
            }
        }

        private void groupBox1_Enter(object sender, EventArgs e)
        {

        }
    }
}
