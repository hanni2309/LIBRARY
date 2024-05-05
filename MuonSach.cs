using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;

namespace ThưVien
{
    public partial class MuonSach : Form
    {
        private string stringConnection = @"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\Users\hanng\Downloads\ThưVien\ThưVien\Library.mdf;Integrated Security=True";

        public MuonSach()
        {
            InitializeComponent();
        }

        private void LoadData()
        {
            // Sử dụng tham số @Status để chỉ định trạng thái cần hiển thị
            string query = "SELECT UserID, BookID, BorrowedDate, Status, ReturnDate FROM Borrowings WHERE Status = @Status";

            using (SqlConnection connection = new SqlConnection(stringConnection))
            {
                SqlDataAdapter adapter = new SqlDataAdapter(query, connection);
                DataTable dataTable = new DataTable();

                try
                {
                    connection.Open();
                    // Chỉ định giá trị cho tham số @Status
                    adapter.SelectCommand.Parameters.AddWithValue("@Status", "Chưa trả");
                    adapter.Fill(dataTable);
                    dataGridView1.DataSource = dataTable;
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Lỗi: " + ex.Message);
                }
            }
        }


        private void btnMuon_Click(object sender, EventArgs e)
        {
            if (!ValidateInput())
            {
                return;
            }

            if (!int.TryParse(txbuserid.Text, out int userID) || !int.TryParse(txbbookid.Text, out int bookID))
            {
                MessageBox.Show("Vui lòng nhập số nguyên cho UserID và BookID.");
                return;
            }

            string status = cbotinhtrang.SelectedItem.ToString();
            DateTime borrowedDate = DateTime.Now; // Lấy thời điểm hiện tại
            DateTime? returnDate = null; // Mặc định không có ngày trả

            if (status == "Đã trả")
            {
                if (dtpReturnDate.Value <= borrowedDate)
                {
                    MessageBox.Show("Ngày trả phải sau ngày mượn.");
                    return;
                }
                returnDate = dtpReturnDate.Value;
            }

            int stockQuantity = GetStockQuantity(bookID);
            int borrowedQuantity = GetBorrowedQuantity(bookID);

            if (borrowedQuantity < stockQuantity)
            {
                string query = "INSERT INTO Borrowings (UserID, BookID, BorrowedDate, Status, ReturnDate) " +
                               "VALUES (@UserID, @BookID, @BorrowedDate, @Status, @ReturnDate)";

                using (SqlConnection connection = new SqlConnection(stringConnection))
                {
                    SqlCommand command = new SqlCommand(query, connection);
                    command.Parameters.AddWithValue("@UserID", userID);
                    command.Parameters.AddWithValue("@BookID", bookID);
                    command.Parameters.AddWithValue("@BorrowedDate", borrowedDate);
                    command.Parameters.AddWithValue("@Status", status);
                    command.Parameters.AddWithValue("@ReturnDate", returnDate.HasValue ? (object)returnDate.Value : DBNull.Value);

                    try
                    {
                        connection.Open();
                        int rowsAffected = command.ExecuteNonQuery();
                        if (rowsAffected > 0)
                        {
                            MessageBox.Show("Thêm thông tin mượn sách thành công!");
                            LoadData();
                        }
                        else
                        {
                            MessageBox.Show("Thêm thông tin mượn sách không thành công!");
                        }
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("Lỗi: " + ex.Message);
                    }
                }
            }
            else
            {
                MessageBox.Show("Số lượng sách được mượn đã vượt quá số sách có sẵn trong kho.");
            }
        }

        private int GetStockQuantity(int bookID)
        {
            int stockQuantity = 0;
            string query = "SELECT StockQuantity FROM Books WHERE BookID = @BookID";

            using (SqlConnection connection = new SqlConnection(stringConnection))
            {
                SqlCommand command = new SqlCommand(query, connection);
                command.Parameters.AddWithValue("@BookID", bookID);

                try
                {
                    connection.Open();
                    object result = command.ExecuteScalar();
                    if (result != null && result != DBNull.Value)
                    {
                        stockQuantity = Convert.ToInt32(result);
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Lỗi: " + ex.Message);
                }
            }

            return stockQuantity;
        }

        private int GetBorrowedQuantity(int bookID)
        {
            int borrowedQuantity = 0;
            string query = "SELECT COUNT(*) FROM Borrowings WHERE BookID = @BookID";

            using (SqlConnection connection = new SqlConnection(stringConnection))
            {
                SqlCommand command = new SqlCommand(query, connection);
                command.Parameters.AddWithValue("@BookID", bookID);

                try
                {
                    connection.Open();
                    object result = command.ExecuteScalar();
                    if (result != null && result != DBNull.Value)
                    {
                        borrowedQuantity = Convert.ToInt32(result);
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Lỗi: " + ex.Message);
                }
            }

            return borrowedQuantity;
        }

        private bool ValidateInput()
        {
            if (string.IsNullOrWhiteSpace(txbuserid.Text) || string.IsNullOrWhiteSpace(txbbookid.Text))
            {
                MessageBox.Show("Vui lòng nhập đủ thông tin.");
                return false;
            }
            if (cbotinhtrang.SelectedItem == null)
            {
                MessageBox.Show("Vui lòng chọn trạng thái.");
                return false;
            }
            return true;
        }

        private void MuonSach_Load(object sender, EventArgs e)
        {
            cbotinhtrang.DataSource = new List<string>() { "Chưa trả", "Đã trả" };
            LoadData();
        }

        private void btnHome_Click(object sender, EventArgs e)
        {
            Admin thuthu = new Admin();
            this.Hide();
            thuthu.ShowDialog();
            this.Show();
        }

        private void button5_Click(object sender, EventArgs e)
        {

        }

        private void btntra_Click(object sender, EventArgs e)
        {
            TraSach book = new TraSach();
            this.Hide();
            book.ShowDialog();
            this.Show();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            AddUser user = new AddUser();
            this.Hide();
            user.ShowDialog();
            this.Show();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            AddBook book = new AddBook();
            this.Hide();
            book.ShowDialog();
            this.Show();
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }
    }
}