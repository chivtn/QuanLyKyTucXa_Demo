using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using QuanLy_BLL;

namespace QuanLyKyTucXa_main
{
    public partial class FrmThongKeTienDien : Form
    {
         ThongKeTienDien_BL thongkeBL  = new ThongKeTienDien_BL();
        public FrmThongKeTienDien()
        {
            InitializeComponent();
        }

        private void FrmThongKeTienDien_Load(object sender, EventArgs e)
        {
            dateTimePicker1.Format = DateTimePickerFormat.Custom;
            dateTimePicker1.CustomFormat = "yyyy";
        }

        private void btnThongke_Click(object sender, EventArgs e)
        {
            int nam = int.Parse(dateTimePicker1.Text);
            fillchart_thang(nam);
        }

        private void fillchart_thang(int nam)
        {
            chart1.Series["Lượng điện"].Points.Clear();
            chart1.ChartAreas["ChartArea1"].AxisX.Title = "Tháng";
            chart1.ChartAreas["ChartArea1"].AxisY.Title = "Lượng điện tiêu thụ";
            chart1.ChartAreas["ChartArea1"].AxisX.Maximum = 12;
            chart1.ChartAreas["ChartArea1"].AxisX.Minimum = 1;
            chart1.ChartAreas["ChartArea1"].AxisX.Interval = 1;
            chart1.ChartAreas["ChartArea1"].AxisX.MajorGrid.Enabled = false;

            var danhSach = thongkeBL.LayLuongDienCacThang(nam);
            foreach (var item in danhSach)
            {
                chart1.Series["Lượng điện"].Points.AddXY(item.Thang, item.SoDienTieuThu);
            }
        }
    }
}
