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
using System.Windows.Forms.DataVisualization.Charting;
using TransferObject;

namespace QuanLyKyTucXa_main
{
    public partial class FrmHome : Form
    {
        public FrmHome()
        {
            InitializeComponent();
        }
        ThongKeTienDien_BL thongkedBL = new ThongKeTienDien_BL();
        ThongKeLuongNuoc_BL thongkenBL = new ThongKeLuongNuoc_BL();
        ThongKe_BL thongKeHeThongBL = new ThongKe_BL();

        private void FrmHome_Load(object sender, EventArgs e)
        {
            dateTimePicker1.Format = DateTimePickerFormat.Custom;
            dateTimePicker1.CustomFormat = "yyyy";

            var thongKe = thongKeHeThongBL.LayThongKe();
            lblSLsinhvien.Text = thongKe.SoLuongSinhVien.ToString();
            lblSLphong.Text = thongKe.SoLuongPhong.ToString();
            lblSLThietB.Text = thongKe.SoLuongThietBi.ToString();

        }

        private void btnThongKeDien_Click(object sender, EventArgs e)
        {
            int nam = int.Parse(dateTimePicker1.Text);
            fillchart_thang(nam);
        }
        private void fillchart_thang(int nam)
        {
            chart1.Series.Clear(); 

            // Thiết lập trục X
            chart1.ChartAreas["ChartArea1"].AxisX.Title = "Tháng";
            chart1.ChartAreas["ChartArea1"].AxisY.Title = "Lượng tiêu thụ";
            chart1.ChartAreas["ChartArea1"].AxisX.Maximum = 12;
            chart1.ChartAreas["ChartArea1"].AxisX.Minimum = 1;
            chart1.ChartAreas["ChartArea1"].AxisX.Interval = 1;
            chart1.ChartAreas["ChartArea1"].AxisX.MajorGrid.Enabled = false;

            
            Series seriesDien = new Series("Lượng điện");
            seriesDien.ChartType = SeriesChartType.Column;
            seriesDien.Color = Color.DeepSkyBlue;

            var danhSachDien = thongkedBL.LayLuongDienCacThang(nam);
            foreach (var item in danhSachDien)
            {
                seriesDien.Points.AddXY(item.Thang, item.SoDienTieuThu);
            }

            
            Series seriesNuoc = new Series("Lượng nước");
            seriesNuoc.ChartType = SeriesChartType.Column;
            seriesNuoc.Color = Color.LightGreen;

            var danhSachNuoc = thongkenBL.LayLuongNuocCacThang(nam);
            foreach (var item in danhSachNuoc)
            {
                seriesNuoc.Points.AddXY(item.Thang, item.SoKhoiTieuThu);
            }

            
            chart1.Series.Add(seriesDien);
            chart1.Series.Add(seriesNuoc);

            
            double maxDien = danhSachDien.Max(x => x.SoDienTieuThu);
            double maxNuoc = danhSachNuoc.Max(x => x.SoKhoiTieuThu);
            double maxValue = Math.Max(maxDien, maxNuoc);
            double roundedMax = Math.Ceiling((maxValue + 1) / 10.0) * 10;

            chart1.ChartAreas["ChartArea1"].AxisY.Minimum = 0;
            chart1.ChartAreas["ChartArea1"].AxisY.Maximum = roundedMax;
            chart1.ChartAreas["ChartArea1"].AxisY.Interval = roundedMax / 5;
        }

    }
}
