using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;
using System.Windows.Forms;
using TinHocDaiCuong.DAL;

namespace TinHocDaiCuong.GUI
{
    
    public partial class Form_EXCEL : Form
    {
        public DAL.DataHelper dh { get; set; }

        public Form_EXCEL()
        {
            InitializeComponent();
            this.dh = new DataHelper("Data Source=DESKTOP-8A7T99L;Initial Catalog=CuoiKi;Integrated Security=True");
        }

        private void button1_Click(object sender, EventArgs e)
        {
            string query = "SELECT s.MSSV, s.[Tên SV], s.[Mã Lớp], s.[Đề Thi], s.Điểm FROM SV s WHERE s.[Mã Lớp] = '16T1'";
            System.Data.DataTable dt = dh.getTable(query);
            dataGridView1.DataSource = dt;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Form_EXCEL ex = new Form_EXCEL();
            DataTable dt = new DataTable();
            dt = dataGridView1.DataSource as DataTable;
            ex.Export(dt,"Danh Sach","DANH SÁCH THI CUỐI KỲ VÀ BÀI TẬP");
        }

        private void Export(DataTable dt, string sheetName, string title)
        {
            //Tao cac doi tuong Excel
            Microsoft.Office.Interop.Excel.Application oExcel = new Microsoft.Office.Interop.Excel.Application();
            Microsoft.Office.Interop.Excel.Workbooks oBooks;

            Microsoft.Office.Interop.Excel.Sheets oSheets;

            Microsoft.Office.Interop.Excel.Workbook oBook;

            Microsoft.Office.Interop.Excel.Worksheet oSheet;
            //Tạo mới một Excel WorkBook 

            oExcel.Visible = true;

            oExcel.DisplayAlerts = false;

            oExcel.Application.SheetsInNewWorkbook = 1;

            oBooks = oExcel.Workbooks;

            oBook = (Microsoft.Office.Interop.Excel.Workbook)(oExcel.Workbooks.Add(Type.Missing));

            oSheets = oBook.Worksheets;

            oSheet = (Microsoft.Office.Interop.Excel.Worksheet)oSheets.get_Item(1);

            oSheet.Name = sheetName;
            // Tạo phần đầu nếu muốn
            Microsoft.Office.Interop.Excel.Range tenTruong = oSheet.get_Range("A1", "B1");
            tenTruong.MergeCells = true;
            tenTruong.Value2 = "ĐẠI HỌC ĐÀ NẴNG";
            tenTruong.Font.Name = "Tahoma";
            tenTruong.Font.Size = "10";
            tenTruong.HorizontalAlignment = Microsoft.Office.Interop.Excel.XlHAlign.xlHAlignCenter;

            Microsoft.Office.Interop.Excel.Range tenBK = oSheet.get_Range("A2", "B2");
            tenBK.MergeCells = true;
            tenBK.Value2 = "TRƯỜNG ĐẠI HỌC BÁCH KHOA";
            tenBK.Font.Name = "Tahoma";
            tenBK.Font.Underline = true;
            tenBK.Font.Size = "10";
            tenBK.HorizontalAlignment = Microsoft.Office.Interop.Excel.XlHAlign.xlHAlignCenter;

            Microsoft.Office.Interop.Excel.Range congHoa = oSheet.get_Range("C1", "E1");
            congHoa.MergeCells = true;
            congHoa.Value2 = "CỘNG HÒA XÃ HỘI CHỦ NGHĨA VIỆT NAM";
            congHoa.Font.Name = "Tahoma";
            congHoa.Font.Size = "10";
            congHoa.HorizontalAlignment = Microsoft.Office.Interop.Excel.XlHAlign.xlHAlignCenter;

            Microsoft.Office.Interop.Excel.Range docLap = oSheet.get_Range("C2", "E2");
            docLap.MergeCells = true;
            docLap.Value2 = "Độc lập - Tự do - Hạnh phúc";
            docLap.Font.Name = "Tahoma";
            docLap.Font.Underline = true;
            docLap.Font.Size = "10";
            docLap.HorizontalAlignment = Microsoft.Office.Interop.Excel.XlHAlign.xlHAlignCenter;

            Microsoft.Office.Interop.Excel.Range head = oSheet.get_Range("A4", "E4");

            head.MergeCells = true;

            head.Value2 = title;

            head.Font.Bold = true;

            head.Font.Name = "Tahoma";

            head.Font.Size = "18";

            head.HorizontalAlignment = Microsoft.Office.Interop.Excel.XlHAlign.xlHAlignCenter;
            
            //Lop

            Microsoft.Office.Interop.Excel.Range lop = oSheet.get_Range("A7", "B7");

            lop.MergeCells = true;

            lop.Value2 = "LỚP : .............";

            lop.Font.Bold = false;

            lop.Font.Name = "Tahoma";

            lop.Font.Size = "10";

            lop.HorizontalAlignment = Microsoft.Office.Interop.Excel.XlHAlign.xlHAlignLeft;
            //Giang Vien
            Microsoft.Office.Interop.Excel.Range giangVien = oSheet.get_Range("C7", "E7");
            giangVien.MergeCells = true;
            giangVien.Value2 = "GIẢNG VIÊN: .............";
            giangVien.Font.Name = "Tahoma";
            giangVien.Font.Size = "10";
            giangVien.HorizontalAlignment = Microsoft.Office.Interop.Excel.XlHAlign.xlHAlignLeft;

            //Hoc Phan
            Microsoft.Office.Interop.Excel.Range hocPhan = oSheet.get_Range("A8", "B8");
            hocPhan.MergeCells = true;
            hocPhan.Value2 = "HỌC PHẦN: .............";
            hocPhan.Font.Name = "Tahoma";
            hocPhan.Font.Size = "10";
            hocPhan.HorizontalAlignment = Microsoft.Office.Interop.Excel.XlHAlign.xlHAlignLeft;

            //ngay thi
            Microsoft.Office.Interop.Excel.Range ngayThi = oSheet.get_Range("C8", "E8");
            ngayThi.MergeCells = true;
            ngayThi.Value2 = "NGÀY THI: .............";
            ngayThi.Font.Name = "Tahoma";
            ngayThi.Font.Size = "10";
            ngayThi.HorizontalAlignment = Microsoft.Office.Interop.Excel.XlHAlign.xlHAlignLeft;

            //Phong Dao Tao
            Microsoft.Office.Interop.Excel.Range phongDaoTao = oSheet.get_Range("A9", "B9");
            phongDaoTao.MergeCells = true;
            phongDaoTao.Value2 = "PHÒNG ĐÀO TẠO: .............";
            phongDaoTao.Font.Name = "Tahoma";
            phongDaoTao.Font.Size = "10";
            phongDaoTao.HorizontalAlignment = Microsoft.Office.Interop.Excel.XlHAlign.xlHAlignLeft;

            //Phong Thi
            Microsoft.Office.Interop.Excel.Range phongThi = oSheet.get_Range("C9", "E9");
            phongThi.MergeCells = true;
            phongThi.Value2 = "PHÒNG THI: .............";
            phongThi.Font.Name = "Tahoma";
            phongThi.Font.Size = "10";
            phongThi.HorizontalAlignment = Microsoft.Office.Interop.Excel.XlHAlign.xlHAlignLeft;

            // Tạo tiêu đề cột 

            Microsoft.Office.Interop.Excel.Range cl1 = oSheet.get_Range("A11", "A11");

            cl1.Value2 = "MSSV";

            cl1.ColumnWidth = 13.5;

            Microsoft.Office.Interop.Excel.Range cl2 = oSheet.get_Range("B11", "B11");

            cl2.Value2 = "Tên Sinh Viên";

            cl2.ColumnWidth = 25.0;

            Microsoft.Office.Interop.Excel.Range cl3 = oSheet.get_Range("C11", "C11");

            cl3.Value2 = "Mã Lớp";

            cl3.ColumnWidth = 13.5;

            Microsoft.Office.Interop.Excel.Range cl4 = oSheet.get_Range("D11", "D11");

            cl4.Value2 = "Đề Thi";

            cl4.ColumnWidth = 13.5;
            Microsoft.Office.Interop.Excel.Range cl5 = oSheet.get_Range("E11", "E11");
            cl5.Value2 = "Điểm";

            Microsoft.Office.Interop.Excel.Range rowHead = oSheet.get_Range("A11", "E11");

            rowHead.Font.Bold = true;
            // Kẻ viền

            rowHead.Borders.LineStyle = Microsoft.Office.Interop.Excel.Constants.xlSolid;

            // Thiết lập màu nền

            rowHead.Interior.ColorIndex = 15;

            rowHead.HorizontalAlignment = Microsoft.Office.Interop.Excel.XlHAlign.xlHAlignCenter;

            // Tạo mẳng đối tượng để lưu dữ toàn bồ dữ liệu trong DataTable,

            // vì dữ liệu được được gán vào các Cell trong Excel phải thông qua object thuần.

            object[,] arr = new object[dt.Rows.Count, dt.Columns.Count];

            //Chuyển dữ liệu từ DataTable vào mảng đối tượng
            for (int r = 0; r < dt.Rows.Count; r++)

            {

                DataRow dr = dt.Rows[r];

                for (int c = 0; c < dt.Columns.Count; c++)

                {
                    arr[r, c] = dr[c];
                }
            }
            //Thiết lập vùng điền dữ liệu

            int rowStart = 12;

            int columnStart = 1;

            int rowEnd = rowStart + dt.Rows.Count - 1;

            int columnEnd = dt.Columns.Count;

            // Ô bắt đầu điền dữ liệu

            Microsoft.Office.Interop.Excel.Range c1 = (Microsoft.Office.Interop.Excel.Range)oSheet.Cells[rowStart, columnStart];

            // Ô kết thúc điền dữ liệu

            Microsoft.Office.Interop.Excel.Range c2 = (Microsoft.Office.Interop.Excel.Range)oSheet.Cells[rowEnd, columnEnd];

            // Lấy về vùng điền dữ liệu

            Microsoft.Office.Interop.Excel.Range range = oSheet.get_Range(c1, c2);

            //Điền dữ liệu vào vùng đã thiết lập

            range.Value2 = arr;

            // Kẻ viền

            range.Borders.LineStyle = Microsoft.Office.Interop.Excel.Constants.xlSolid;

            // Căn giữa cột STT

            Microsoft.Office.Interop.Excel.Range c3 = (Microsoft.Office.Interop.Excel.Range)oSheet.Cells[rowEnd, columnStart];

            Microsoft.Office.Interop.Excel.Range c4 = oSheet.get_Range(c1, c3);

            oSheet.get_Range(c3, c4).HorizontalAlignment = Microsoft.Office.Interop.Excel.XlHAlign.xlHAlignCenter;

            Microsoft.Office.Interop.Excel.Range truongKhoa = oSheet.get_Range("A30", "B30");
            truongKhoa.MergeCells = true;
            truongKhoa.Value2 = "TRƯỞNG KHOA/BỘ MÔN";
            truongKhoa.Font.Name = "Tahoma";
            truongKhoa.Font.Size = "10";
            truongKhoa.HorizontalAlignment = Microsoft.Office.Interop.Excel.XlHAlign.xlHAlignCenter;

            Microsoft.Office.Interop.Excel.Range daNang = oSheet.get_Range("C30", "E30");
            daNang.MergeCells = true;
            daNang.Value2 = "ĐÀ NẴNG, Ngày.......Tháng.......Năm.....";
            daNang.Font.Name = "Tahoma";
            daNang.Font.Size = "10";
            daNang.HorizontalAlignment = Microsoft.Office.Interop.Excel.XlHAlign.xlHAlignCenter;

            Microsoft.Office.Interop.Excel.Range canBo = oSheet.get_Range("C31", "E31");
            canBo.MergeCells = true;
            canBo.Value2 = "CÁN BỘ COI THI";
            canBo.Font.Name = "Tahoma";
            canBo.Font.Size = "10";
            canBo.HorizontalAlignment = Microsoft.Office.Interop.Excel.XlHAlign.xlHAlignCenter;
        }


    }
}
