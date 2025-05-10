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
using System.Data.SqlClient;

namespace QuanLyKyTucXa_main
{
    public partial class FrmDangKyPhong : Form
    {
        private SinhVienDangKy_BL sinhVienDangKy_BL;
        public FrmDangKyPhong()
        {
            InitializeComponent();
            sinhVienDangKy_BL = new SinhVienDangKy_BL();

        }

        // Phương thức xóa form
        private void ClearForm()
        {
            txtMasv.Clear();
            txtTensv.Clear();
            cbGioitinh.SelectedIndex = -1;
            dtpNgaysinh.Value = DateTime.Now;
            txtQuequan.Clear();
            cbKhoa.SelectedIndex = -1;
            txtLop.Clear();
            cbLoaiuutien.SelectedIndex = -1;
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void GBtnDangky_Click(object sender, EventArgs e)
        {
            // Kiểm tra dữ liệu nhập
            if (string.IsNullOrEmpty(txtMasv.Text) ||
                string.IsNullOrEmpty(txtTensv.Text) ||
                string.IsNullOrEmpty(cbGioitinh.Text) ||
                string.IsNullOrEmpty(txtQuequan.Text) ||
                string.IsNullOrEmpty(txtEmail.Text) ||
                string.IsNullOrEmpty(cbKhoa.Text) ||
                string.IsNullOrEmpty(txtLop.Text) ||
                string.IsNullOrEmpty(cbLoaiuutien.Text))
            {
                MessageBox.Show("Vui lòng nhập đầy đủ thông tin!", "Cảnh báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            // Kiểm tra trùng mã sinh viên
            if (sinhVienDangKy_BL.KiemTraTrungMa(txtMasv.Text))
            {
                MessageBox.Show("Mã sinh viên đã tồn tại!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            // Tạo đối tượng sinh viên
            SinhVienDangKy sv = new SinhVienDangKy(
                txtMasv.Text,
                txtTensv.Text,
                cbGioitinh.Text,
                dtpNgaysinh.Value.ToString("yyyy-MM-dd"), // Định dạng ngày
                txtQuequan.Text,
                txtEmail.Text,
                cbKhoa.Text,
                txtLop.Text,
                cbLoaiuutien.Text
            );
            // Thêm vào database
            try
            {
                bool result = sinhVienDangKy_BL.ThemSinhVienDangKy(sv);
                if (result)
                {
                    MessageBox.Show("Đăng ký thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    // Xóa form sau khi đăng ký
                    ClearForm();
                }
                else
                {
                    MessageBox.Show("Đăng ký thất bại!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi: " + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void GBtnHuybo_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
