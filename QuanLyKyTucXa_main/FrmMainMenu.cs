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
    public partial class FrmMainMenu : Form
    {
        //Fields
        private Button currentButton;
        private Form activeForm = null;
       


        public FrmMainMenu()
        {
            InitializeComponent();
            

            customizeDesign();           
        }
   //đổi màu nút
        private void ActivateButton(object btnSender, int r, int g, int b)
        {
            if (btnSender != null && currentButton != (Button)btnSender)
            {
                DisableButton();
                Color color = Color.FromArgb(r, g, b);
                currentButton = (Button)btnSender;
                currentButton.BackColor = color;
                currentButton.ForeColor = Color.White;
                currentButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 12.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            }
        }
        private void DisableButton()
        {
            foreach (Control previousBtn in panelSidebar.Controls)
            {
                if (previousBtn.GetType() == typeof(Button))
                {
                    previousBtn.BackColor = SystemColors.ButtonFace;
                    previousBtn.ForeColor = SystemColors.ControlText;
                    previousBtn.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
                }
            }
        }

  //ẩn hiện panel
        private void openChildForm(Form childForm, Size size, Point point)
        {
            if (activeForm != null)
                activeForm.Close();
            //panelControl.Visible = false;
            activeForm = childForm;
            childForm.TopLevel = false;
            childForm.FormBorderStyle = FormBorderStyle.None;
            childForm.Dock = DockStyle.Fill;
            panelMain.Controls.Add(childForm);
            panelMain.Tag = childForm;
            childForm.BringToFront();
            childForm.Show();
//thay doi title
            lblTitle.Text = childForm.Text;
            lblTitle.Size = size;
            lblTitle.Location = point;
            btnClose.Visible = true;
        }

        private void customizeDesign()
        {
            panelTaikhoanSubmenu.Visible = false;
            panelDanhmucSubmenu.Visible = false;
            panelPhongSubmenu.Visible = false;
            panelBaocaoSubmenu.Visible = false;
        }

        private void showSubMenu(Panel subMenu)
        {
            if (subMenu.Visible == false)
            {
                hideSubmenu();
                subMenu.Visible = true;
            }
            else
                subMenu.Visible = false;
        }

        private void hideSubmenu()
        {
            if (panelTaikhoanSubmenu.Visible == true)
            {
                panelTaikhoanSubmenu.Visible = false;
            }
            if (panelDanhmucSubmenu.Visible == true)
            {
                panelDanhmucSubmenu.Visible = false;
            }
            if (panelPhongSubmenu.Visible == true)
            {
                panelPhongSubmenu.Visible = false;
            }
            if (panelBaocaoSubmenu.Visible == true)
            {
                panelBaocaoSubmenu.Visible = false;
            }
        }

        private void FrmMainMenu_Load(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Maximized;
        }



        //QLPhong
        private void btnDanhsachphong_Click(object sender, EventArgs e)
        {
            //openChildForm(new DanhSachDangKy(), new Size(156, 26), new Point(325, 15));
            ////hideSubmenu();
        }

        private void btnDanhsachday_Click(object sender, EventArgs e)
        {
            openChildForm(new FrmQuanLyDay(), new Size(129, 26), new Point(308, 15));
            //hideSubmenu();
        }

        private void btnPhong_Click(object sender, EventArgs e)
        {
            ActivateButton(sender, 199, 220, 91);
            showSubMenu(panelPhongSubmenu);
        }
 //QLSV
        private void btnSinhvien_Click_1(object sender, EventArgs e)
        {
            //ActivateButton(sender, 255, 152, 0);
            //openChildForm(new FrmQuanLySinhVien(), new Size(180, 26), new Point(325, 15));
        }       

//danhmuc
        private void btnDanhmuc_Click(object sender, EventArgs e)
        {
            ActivateButton(sender, 0, 150, 136);
            showSubMenu(panelDanhmucSubmenu);
            //if (nguoiDung.quyen == "User")
            //    btnNguoidung.Enabled = false;
        }
        private void btnNhanvien_Click(object sender, EventArgs e)
        {
            openChildForm(new FrmQuanLyNhanVien(), new Size(192, 26), new Point(325, 15));
            //hideSubmenu();

        }
        private void btnLuongNV_Click(object sender, EventArgs e)
        {
            openChildForm(new FrmThanhToanLuongNhanVien(), new Size(192, 26), new Point(325, 15));

        }
        private void btnKyluat_Click(object sender, EventArgs e)
        {
            //openChildForm(new FrmQuanLyKyLuat(), new Size(156, 26), new Point(325, 15));
            //hideSubmenu();
        }
        private void btnDanhSachDangKy_Click(object sender, EventArgs e)
        {
            openChildForm(new DanhSachDangKy(), new Size(205, 26), new Point(325, 15));
            //hideSubmenu();

        }

 //BaoCao
        private void btnBaocao_Click(object sender, EventArgs e)
        {
            ActivateButton(sender, 3, 150, 243);
            showSubMenu(panelBaocaoSubmenu);
        }

        private void btnBaoCaoSinhVien_Click(object sender, EventArgs e)
        {
            //openChildForm(new FrmBaoCaoSinhVien(), new Size(129, 26), new Point(308, 15));
            ////hideSubmenu();
        }

        private void btnBaoCaoNhanVien_Click(object sender, EventArgs e)
        {
            //openChildForm(new FrmThanhToanLuongNhanVien(), new Size(129, 26), new Point(308, 15));
            ////hideSubmenu();
        }

//dangxuat
        private void btnDangxuat_Click(object sender, EventArgs e)
        {
            this.Hide(); // Ẩn tạm FrmMainMenu đi trước
            FrmDangNhap dangNhap = new FrmDangNhap();
            dangNhap.ShowDialog(); // Chờ đăng nhập xong
            this.Close(); // Đóng hẳn FrmMainMenu sau
        }
//taikhoan
        private void btnTaikhoan_Click(object sender, EventArgs e)
        {
            ActivateButton(sender, 89, 120, 187);
            showSubMenu(panelTaikhoanSubmenu);
        }

        private void btnDoimatkhau_Click(object sender, EventArgs e)
        {
            //FrmDoiMatKhau frmDoiMk = new FrmDoiMatKhau();
            //frmDoiMk.id = this.idNguoiDung;
            //frmDoiMk.Show();
        }

       
        private void btnBaoCaoTienDien_Click(object sender, EventArgs e)
        {
            openChildForm(new FrmThongKeTienDien(), new Size(129, 26), new Point(308, 15));
            //hideSubmenu();
        }
    }
}
