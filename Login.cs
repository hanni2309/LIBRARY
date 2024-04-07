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
    public partial class Login : Form
    {
        private string stringConnection = @"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=E:\LapTrinhWindows\ThưVien\Database1.mdf;Integrated Security=True";

        public Login()
        {
            InitializeComponent();
        }

        private void btnDangnhap_Click(object sender, EventArgs e)
        {
            if (!KiemtraNhap())
            {
                return;
            }

            string username = txtUsername.Text;
            string password = txbPass.Text;

            string query = "SELECT phanquyen FROM Register WHERE username = @username AND pass = @password";

            using (SqlConnection connection = new SqlConnection(stringConnection))
            {
                SqlCommand command = new SqlCommand(query, connection);
                command.Parameters.AddWithValue("@username", username);
                command.Parameters.AddWithValue("@password", password);

                try
                {
                    connection.Open();
                    string phanquyen = (string)command.ExecuteScalar();

                    if (phanquyen != null)
                    {
                        switch (phanquyen)
                        {
                            case "Admin":
                                Admin adminForm = new Admin();
                                adminForm.Show();
                                break;
                            case "Thủ thư":
                                ThuthuLog thuthuForm = new ThuthuLog();
                                thuthuForm.Show();
                                break;
                            case "Đọc giả":
                                DocgiaLog docgiaForm = new DocgiaLog();
                                docgiaForm.Show();
                                break;
                        }
                    }
                    else
                    {
                        MessageBox.Show("Tên đăng nhập hoặc mật khẩu không đúng", "Thông báo");
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Lỗi: " + ex.Message);
                }
            }

            this.Hide();
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
    }
}
