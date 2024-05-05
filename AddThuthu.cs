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
    public partial class AddThuthu : Form
    {
        private string stringConnection = @"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\Users\hanng\Downloads\ThưVien\ThưVien\Library.mdf;Integrated Security=True";
        public AddThuthu()
        {
            InitializeComponent();
            LoadData();
        }
        private void LoadData()
        {
            // Tạo câu lệnh SQL để lấy thông tin từ bảng Register
            string query = "SELECT LibrarianID, Username, Password FROM Librarians";

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

        private void btnDangky_Click(object sender, EventArgs e)
        {
            string id = txtID.Text;
            string username = txbUsername.Text;
            string password = txbPass.Text;
            // Tạo câu lệnh SQL INSERT
            string query = "INSERT INTO Librarians (LibrarianID, Username, Password) " +
                           "VALUES (@LibrarianID, @Username, @Password)";

            // Mở kết nối đến cơ sở dữ liệu và thực hiện lệnh SQL INSERT
            using (SqlConnection connection = new SqlConnection(stringConnection))
            {
                SqlCommand command = new SqlCommand(query, connection);

                command.Parameters.AddWithValue("@LibrarianID", id);
                command.Parameters.AddWithValue("@Username", username);
                command.Parameters.AddWithValue("@Password", password);

                try
                {
                    connection.Open();
                    int rowsAffected = command.ExecuteNonQuery();
                    if (rowsAffected > 0)
                    {
                        MessageBox.Show("Thêm thủ thư thành công!");
                        LoadData(); // Cập nhật dữ liệu trong DataGridView
                    }
                    else
                    {
                        MessageBox.Show("Thêm thủ thư thất bại!");
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Lỗi: " + ex.Message);
                }
            }
        }
    }
}
