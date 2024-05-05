using System;
using System.Data;
using System.Data.SqlClient;
using System.Windows.Forms;
using System.Windows.Forms.DataVisualization.Charting;

namespace ThưVien
{
    public partial class ThongKe : Form
    {
        private string stringConnection = @"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\Users\hanng\Downloads\ThưVien\ThưVien\Library.mdf;Integrated Security=True";
        private enum ThongKeType { Tuan, Thang, Nam }; // Liệt kê các loại thời gian muốn thống kê

        private ThongKeType thongKeType; // Biến lưu trữ loại thời gian được chọn

        public ThongKe()
        {
            InitializeComponent();
        }

        private void ThongKeForm_Load(object sender, EventArgs e)
        {
            thongKeType = ThongKeType.Tuan; // Mặc định thống kê theo tuần khi mở form
            ThongKeSachMuonTheoThoiGian();
            ThongKeNguoiDungMuonNhieuSach();
        }

        private void ThongKeSachMuonTheoThoiGian()
        {
            // Xóa các Series trước đó trong Chart (nếu có)
            chart1.Series.Clear();

            // Tạo một Series mới cho biểu đồ cột
            Series series = new Series("Số Lượng Mượn");
            series.ChartType = SeriesChartType.Column;

            // Tạo biến để lưu trữ ngày bắt đầu và kết thúc của thời gian được chọn
            DateTime startDate = DateTime.Today;
            DateTime endDate = DateTime.Today;

            // Thiết lập ngày bắt đầu và kết thúc dựa trên loại thời gian được chọn
            switch (thongKeType)
            {
                case ThongKeType.Tuan:
                    startDate = DateTime.Today.AddDays(-((int)DateTime.Today.DayOfWeek - 1)); // Ngày bắt đầu là ngày đầu tiên của tuần
                    endDate = startDate.AddDays(6); // Ngày kết thúc là ngày cuối cùng của tuần
                    break;
                case ThongKeType.Thang:
                    startDate = new DateTime(DateTime.Today.Year, DateTime.Today.Month, 1); // Ngày bắt đầu là ngày đầu tiên của tháng
                    endDate = startDate.AddMonths(1).AddDays(-1); // Ngày kết thúc là ngày cuối cùng của tháng
                    break;
                case ThongKeType.Nam:
                    startDate = new DateTime(DateTime.Today.Year, 1, 1); // Ngày bắt đầu là ngày đầu tiên của năm
                    endDate = new DateTime(DateTime.Today.Year, 12, 31); // Ngày kết thúc là ngày cuối cùng của năm
                    break;
            }

            // Thực hiện truy vấn để lấy số lượng sách mượn theo thời gian
            string query = @"
                SELECT Title, COUNT(Title) AS SoLuongMuon
                FROM Borrowings
                INNER JOIN Books ON Borrowings.BookID = Books.BookID
                WHERE BorrowedDate BETWEEN @StartDate AND @EndDate
                GROUP BY Title";

            using (SqlConnection connection = new SqlConnection(stringConnection))
            {
                SqlCommand command = new SqlCommand(query, connection);
                command.Parameters.AddWithValue("@StartDate", startDate);
                command.Parameters.AddWithValue("@EndDate", endDate);

                try
                {
                    connection.Open();
                    SqlDataReader reader = command.ExecuteReader();

                    while (reader.Read())
                    {
                        // Thêm dữ liệu vào Series
                        series.Points.AddXY(reader["Title"].ToString(), reader["SoLuongMuon"]);
                    }
                    reader.Close();
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Lỗi khi thực hiện truy vấn: " + ex.Message);
                }
            }

            // Thêm Series vào Chart
            chart1.Series.Add(series);

            // Cài đặt tiêu đề và nhãn cho trục x và trục y
            chart1.ChartAreas[0].AxisX.Title = "Title";
            chart1.ChartAreas[0].AxisY.Title = "Số Lượng Mượn";
        }

        private void ThongKeNguoiDungMuonNhieuSach()
        {
            // Xóa các Series trước đó trong Chart (nếu có)
            chart2.Series.Clear();

            // Tạo một Series mới cho biểu đồ cột
            Series series = new Series("Số Lượng Mượn");
            series.ChartType = SeriesChartType.Column;

            // Thực hiện truy vấn để lấy số lượng sách mượn của từng người dùng
            string query = @"
        SELECT r.Username, COUNT(b.UserID) AS SoLuongMuon
        FROM Borrowings b
        INNER JOIN Readers r ON b.UserID = r.ReaderID
        GROUP BY r.Username
        ORDER BY COUNT(b.UserID) DESC";

            using (SqlConnection connection = new SqlConnection(stringConnection))
            {
                SqlCommand command = new SqlCommand(query, connection);

                try
                {
                    connection.Open();
                    SqlDataReader reader = command.ExecuteReader();

                    while (reader.Read())
                    {
                        // Thêm dữ liệu vào Series
                        series.Points.AddXY(reader["Username"].ToString(), reader["SoLuongMuon"]);
                    }
                    reader.Close();
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Lỗi khi thực hiện truy vấn: " + ex.Message);
                }
            }

            // Thêm Series vào Chart
            chart2.Series.Add(series);

            // Cài đặt tiêu đề và nhãn cho trục x và trục y
            chart2.ChartAreas[0].AxisX.Title = "Tên Người Dùng";
            chart2.ChartAreas[0].AxisY.Title = "Số Lượng Mượn";
        }


        private void btnTuan_Click_1(object sender, EventArgs e)
        {
            thongKeType = ThongKeType.Tuan;
            ThongKeSachMuonTheoThoiGian();
            ThongKeNguoiDungMuonNhieuSach();
        }

        private void btnThang_Click(object sender, EventArgs e)
        {
            thongKeType = ThongKeType.Thang;
            ThongKeSachMuonTheoThoiGian();
            ThongKeNguoiDungMuonNhieuSach();
        }

        private void btnNam_Click_1(object sender, EventArgs e)
        {
            thongKeType = ThongKeType.Nam;
            ThongKeSachMuonTheoThoiGian();
            ThongKeNguoiDungMuonNhieuSach();
        }
    }
}
