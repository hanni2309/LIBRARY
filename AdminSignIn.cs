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
    public partial class AdminSignIn : Form
    {
        public AdminSignIn()
        {
            InitializeComponent();
        }
        bool KiemtraNhap()
        {
            if (txtUsername.Text == "" || txbPass.Text == "")
            {
                MessageBox.Show("Vui lòng không để trống", "Thông báo");
                txtUsername.Focus();
                txbPass.Focus();
                return false;
            }

            return true;
        }
        private void txtUsername_TextChanged(object sender, EventArgs e)
        {

        }

        private void btnDangnhap_Click(object sender, EventArgs e)
        {
            if (!KiemtraNhap())
            {
                return;
            }

            string connectionString = @"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\Users\hanng\Downloads\ThưVien\ThưVien\Library.mdf;Integrated Security=True";
            string username = txtUsername.Text;
            string password = txbPass.Text;

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();
                string query = "SELECT COUNT(*) FROM Admins WHERE Username = @Username AND Password = @Password";
                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@Username", username);
                    command.Parameters.AddWithValue("@Password", password);
                    int result = (int)command.ExecuteScalar();
                    if (result > 0)
                    {
                        MessageBox.Show("Đăng nhập thành công!");
                        MessageBox.Show("Đăng nhập thành công!");
                        // Chuyển hướng đến form DocgiaForm
                        Admin docgiaForm = new Admin();
                        docgiaForm.Show();
                        this.Hide(); // Ẩn form đăng nhập
                    }
                    else
                    {
                        MessageBox.Show("Tên người dùng hoặc mật khẩu không đúng!");
                    }
                }
            }
            }
    }
}
