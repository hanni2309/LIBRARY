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
using System.IO;

namespace ThưVien
{
    public partial class AddBook : Form
    {

        private string stringConnection = @"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\Users\hanng\Downloads\ThưVien\ThưVien\Library.mdf;Integrated Security=True";
        public AddBook()
        {
            InitializeComponent();
        }
        bool KiemtraNhap()
        {

            if (txtTitle.Text == "")
            {
                MessageBox.Show("Hãy nhập tên sách", "Thông báo");
                txtTitle.Focus();
                return false;
            }
            if (txtAuthor.Text == "")
            {
                MessageBox.Show("Hãy nhập tên tác giả của sách", "Thông báo");
                txtAuthor.Focus();
                return false;
            }

            return true;
        }
        private void label3_Click(object sender, EventArgs e)
        {

        }
    
        private void btnTao_Click(object sender, EventArgs e)
        {
            string bookid = txbId.Text;
            string title = txtTitle.Text;
            string author = txtAuthor.Text;
            string genre = txtGenre.Text;
            int stockQuantity = int.Parse(txtStockQuantity.Text);

    


            string query = "INSERT INTO Books (BookID, Title, Author, Genre, StockQuantity) " +
                           "VALUES (@BookID, @Title, @Author, @Genre, @StockQuantity)";

            using (SqlConnection connection = new SqlConnection(stringConnection))
            {
                SqlCommand command = new SqlCommand(query, connection);
                command.Parameters.AddWithValue("@BookID", bookid);
                command.Parameters.AddWithValue("@Title", title);
                command.Parameters.AddWithValue("@Author", author);
                command.Parameters.AddWithValue("@Genre", genre);
                command.Parameters.AddWithValue("@StockQuantity", stockQuantity);

                try
                {
                    connection.Open();
                    int rowsAffected = command.ExecuteNonQuery();
                    if (rowsAffected > 0)
                    {
                        MessageBox.Show("Thêm sách thành công!");
                        // Xử lý các tác vụ sau khi thêm sách thành công
                    }
                    else
                    {
                        MessageBox.Show("Thêm sách không thành công!");
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Lỗi: " + ex.Message);
                }
            }
            }
        private void LoadData()
        {
            // Tạo câu lệnh SQL để lấy thông tin từ bảng Register
            string query = "SELECT BookID, Title, Author, Genre, StockQuantity FROM Books";

            using (SqlConnection connection = new SqlConnection(stringConnection))
            {
                SqlDataAdapter adapter = new SqlDataAdapter(query, connection);
                DataTable dataTable = new DataTable();

                try
                {
                    connection.Open();
                    adapter.Fill(dataTable);

                    // Thiết lập dữ liệu trong DataGridView
                    dataGridView1.DataSource = dataTable;
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Lỗi: " + ex.Message);
                }
            }
        }

        private void btnHome_Click_1(object sender, EventArgs e)
        {
            ThuthuLog thuthu = new ThuthuLog();
            this.Hide();
            thuthu.ShowDialog();
            this.Show();
        }

        private void AddBook_Load(object sender, EventArgs e)
        {
            LoadData();
        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

    }
}
