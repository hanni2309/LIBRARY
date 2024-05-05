using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ThưVien
{
    public partial class AddUser : Form
    {
        private string stringConnection = @"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\Users\hanng\Downloads\ThưVien\ThưVien\Library.mdf;Integrated Security=True";
        public AddUser()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            AddBook book = new AddBook();
            this.Hide();
            book.ShowDialog();
            this.Show();
        }

        private void btnHome_Click(object sender, EventArgs e)
        {
            ThuthuLog thuthu = new ThuthuLog();
            this.Hide();
            thuthu.ShowDialog();
            this.Show();
        }

        private void AddUser_Load(object sender, EventArgs e)
        {
            LoadData();

            cboGioitinh.DataSource = new List<string>() { "Nam", "Nữ", "Khác" };
        }

        private void LoadData()
        {
            // Tạo câu lệnh SQL để lấy thông tin từ bảng Register
            string query = "SELECT ReaderID, Username, Password, Name, Email, DateOfBirth, Gender FROM Readers";

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
            if (!KiemtraNhap())
            {
                return;
            }

            // Lấy giá trị từ các điều khiển
            string id = txtID.Text;
            string name = txbName.Text;
            string dateOfBirth = dateofbirth.Value.ToString("yyyy-MM-dd");
            string username = txbUsername.Text;
            string password = txbPass.Text;
            string email = txbEmail.Text;
            string gender = cboGioitinh.SelectedItem.ToString();
            // Tạo câu lệnh SQL INSERT
            string query = "INSERT INTO Readers (ReaderID, Username, Password, Name, Email, DateOfBirth, Gender) " +
                           "VALUES (@ReaderID, @Username, @Password, @Name, @Email, @DateOfBirth, @Gender)";

            // Mở kết nối đến cơ sở dữ liệu và thực hiện lệnh SQL INSERT
            using (SqlConnection connection = new SqlConnection(stringConnection))
            {
                SqlCommand command = new SqlCommand(query, connection);

                command.Parameters.AddWithValue("@ReaderID", id);
                command.Parameters.AddWithValue("@Username", username);
                command.Parameters.AddWithValue("@Password", password);
                command.Parameters.AddWithValue("@Name", name);
                command.Parameters.AddWithValue("@Email", email);
                command.Parameters.AddWithValue("@DateOfBirth", dateOfBirth);
                command.Parameters.AddWithValue("@Gender", gender);

                try
                {
                    connection.Open();
                    int rowsAffected = command.ExecuteNonQuery();
                    if (rowsAffected > 0)
                    {
                        MessageBox.Show("Thêm độc giả thành công!");
                        LoadData(); // Cập nhật dữ liệu trong DataGridView
                    }
                    else
                    {
                        MessageBox.Show("Thêm độc giả thất bại!");
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Lỗi: " + ex.Message);
                }
            }
        }

        bool KiemtraNhap()
        {
            if (txbName.Text == "")
            {
                MessageBox.Show("Hãy nhập họ và tên", "Thông báo");
                txbName.Focus();
                return false;
            }
            if (dateofbirth.Text == "")
            {
                MessageBox.Show("Hãy nhập ngày sinh", "Thông báo");
                txbName.Focus();
                return false;
            }

            if (txbEmail.Text == "")
            {
                MessageBox.Show("Hãy nhập Email", "Thông báo");
                txbEmail.Focus();
                return false;
            }

            if (txbPass.Text == "")
            {
                MessageBox.Show("Hãy nhập Password", "Thông báo");
                txbPass.Focus();
                return false;
            }

            if (txbUsername.Text == "")
            {
                MessageBox.Show("Hãy nhập tên người dùng", "Thông báo");
                txbUsername.Focus();
                return false;
            }

            return true;
        }

        private void btnUser_Click(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {

        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void dateofbirth_ValueChanged(object sender, EventArgs e)
        {

        }
    }
}
