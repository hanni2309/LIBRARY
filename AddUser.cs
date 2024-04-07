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
        private string stringConnection = @"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=E:\LapTrinhWindows\ThưVien\Database1.mdf;Integrated Security=True";

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
            cboGioitinh.DataSource = new List<string>() { "Nam", "Nữ", "Khác" };
        }

        private void LoadData()
        {
            // Tạo câu lệnh SQL để lấy thông tin từ bảng Register
            string query = "SELECT Id, name, cccd, username, email, gioitinh FROM Register";

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
            string name = txbName.Text;
            string cccd = txbCccd.Text;
            string username = txbUsername.Text;
            string pass = txbPass.Text;
            string email = txbEmail.Text;
            string gioitinh = cboGioitinh.SelectedItem.ToString();
            string phanquyen = "Đọc giả"; // Phân quyền mặc định

            // Tạo câu lệnh SQL để chèn dữ liệu vào bảng Register
            string query = "INSERT INTO Register (name, cccd, pass, username, email, gioitinh, phanquyen) " +
                           "VALUES (@name, @cccd, @pass, @username, @email, @gioitinh, @phanquyen)";

            using (SqlConnection connection = new SqlConnection(stringConnection))
            {
                SqlCommand command = new SqlCommand(query, connection);
                command.Parameters.AddWithValue("@name", name);
                command.Parameters.AddWithValue("@cccd", cccd);
                command.Parameters.AddWithValue("@pass", pass);
                command.Parameters.AddWithValue("@username", username);
                command.Parameters.AddWithValue("@email", email);
                command.Parameters.AddWithValue("@gioitinh", gioitinh);
                command.Parameters.AddWithValue("@phanquyen", phanquyen);

                try
                {
                    connection.Open();
                    int rowsAffected = command.ExecuteNonQuery();
                    if (rowsAffected > 0)
                    {
                        MessageBox.Show("Thêm người dùng thành công");
                        LoadData(); // Sau khi thêm thành công, load lại dữ liệu
                    }
                    else
                    {
                        MessageBox.Show("Thêm người dùng thất bại");
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

            if (txbCccd.Text == "")
            {
                MessageBox.Show("Hãy nhập số căn cước công dân hoặc chứng minh nhân dân", "Thông báo");
                txbCccd.Focus();
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

        }
    }
}
