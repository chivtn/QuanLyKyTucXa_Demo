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

namespace QuanLyKyTucXa_main
{
    public partial class FrmBaoCaoSinhVien : Form
    {
        public FrmBaoCaoSinhVien()
        {
            InitializeComponent();
        }
        QuanLySinhVien_BL bllsv = new QuanLySinhVien_BL();

        private void FrmBaoCaoSinhVien_Load(object sender, EventArgs e)
        {
            dgvSinhvien.DataSource = bllsv.LayDanhSachSinhVien();
        }

        private void xuấtExcelToolStripMenuItem_Click(object sender, EventArgs e)
        {
            // Khởi tạo Excel
            Microsoft.Office.Interop.Excel._Application app = new Microsoft.Office.Interop.Excel.Application();
            Microsoft.Office.Interop.Excel._Workbook workbook = app.Workbooks.Add(Type.Missing);

            // Lấy Sheet đầu tiên
            Microsoft.Office.Interop.Excel._Worksheet worksheet = (Microsoft.Office.Interop.Excel._Worksheet)workbook.Sheets[1];
            worksheet = workbook.ActiveSheet;
            app.Visible = true;

            // Ghi tiêu đề cột từ DataGridView
            for (int i = 0; i < dgvSinhvien.Columns.Count; i++)
            {
                worksheet.Cells[1, i + 1] = dgvSinhvien.Columns[i].HeaderText;
            }

            // Ghi dữ liệu từ DataGridView
            int rowExcel = 2; // bắt đầu từ dòng 2 vì dòng 1 là tiêu đề
            foreach (DataGridViewRow row in dgvSinhvien.Rows)
            {
                if (row.IsNewRow) continue;

                for (int col = 0; col < dgvSinhvien.Columns.Count; col++)
                {
                    object value = row.Cells[col].Value;
                    worksheet.Cells[rowExcel, col + 1] = value?.ToString() ?? "";
                }

                rowExcel++;
            }

            // Định dạng: in đậm, màu đỏ, căn giữa dòng tiêu đề
            string endColumn = ((char)('A' + dgvSinhvien.Columns.Count - 1)).ToString(); // Ví dụ: G
            worksheet.Range[$"A1", $"{endColumn}1"].Font.Bold = true;
            worksheet.Range[$"A1", $"{endColumn}1"].Font.ColorIndex = 3;
            worksheet.Range[$"A1", $"{endColumn}1"].HorizontalAlignment = 3;

            // Font toàn bảng và viền
            worksheet.Range[$"A1", $"{endColumn}{rowExcel - 1}"].Font.Name = "Times New Roman";
            worksheet.Range[$"A1", $"{endColumn}{rowExcel - 1}"].Borders.LineStyle = 1;

            // Tự động điều chỉnh độ rộng cột
            worksheet.Columns.AutoFit();
        }

        private void dgvSinhvien_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }
    }
}
