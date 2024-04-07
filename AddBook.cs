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
    public partial class AddBook : Form
    {
        private string stringConnection = @"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=E:\LapTrinhWindows\ThưVien\Database1.mdf;Integrated Security=True";
        public AddBook()
        {
            InitializeComponent();
        }

        private void btnHome_Click(object sender, EventArgs e)
        {
            ThuthuLog thuthu = new ThuthuLog();
            this.Hide();
            thuthu.ShowDialog();
            this.Show();
        }
        bool KiemtraNhap()
        {
         
            if (txbmota.Text == "")
            {
                MessageBox.Show("Hãy nhập phần mô tả của sách", "Thông báo");
                txbmota.Focus();
                return false;
            }

            if (txbName.Text == "")
            {
                MessageBox.Show("Hãy nhập tên sách", "Thông báo");
                txbName.Focus();
                return false;
            }

            if (txbnxb.Text == "")
            {
                MessageBox.Show("Hãy nhập NXB", "Thông báo");
                txbnxb.Focus();
                return false;
            }

            if (txbphanloai.Text == "")
            {
                MessageBox.Show("Hãy nhập phân loại", "Thông báo");
                txbphanloai.Focus();
                return false;
            }

            if (txbsoluong.Text == "")
            {
                MessageBox.Show("Hãy nhập số lượng", "Thông báo");
                txbsoluong.Focus();
                return false;
            }

            if (txbtacgia.Text == "")
            {
                MessageBox.Show("Hãy nhập tên tác giả của sách", "Thông báo");
                txbtacgia.Focus();
                return false;
            }

            return true;
        }
        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void btnTao_Click(object sender, EventArgs e)
        {
            if (!KiemtraNhap())
            {
                return;
            }

            using (SqlConnection connection = new SqlConnection(stringConnection))
            {
                try
                {
                    connection.Open();

                    // Tạo câu lệnh SQL để chèn dữ liệu vào bảng Book
                    string query = @"INSERT INTO Book (Id, name, nxb, tacgia, phanloai, mota, soluong) 
                             VALUES (@id, @name, @nxb, @tacgia, @phanloai, @mota, @soluong)";

                    // Tạo đối tượng SqlCommand để thực thi câu lệnh SQL
                    using (SqlCommand command = new SqlCommand(query, connection))
                    {
                        command.Parameters.AddWithValue("@id", txbId.Text);
                        command.Parameters.AddWithValue("@name", txbName.Text);
                        command.Parameters.AddWithValue("@nxb", txbnxb.Text);
                        command.Parameters.AddWithValue("@tacgia", txbtacgia.Text);
                        command.Parameters.AddWithValue("@phanloai", txbphanloai.Text);
                        command.Parameters.AddWithValue("@mota", txbmota.Text);
                        command.Parameters.AddWithValue("@soluong", int.Parse(txbsoluong.Text));

                        // Thực thi câu lệnh SQL
                        command.ExecuteNonQuery();

                        MessageBox.Show("Thêm sách thành công", "Thông báo");
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Lỗi: " + ex.Message, "Thông báo");
                }
            }
        }

    }
}
