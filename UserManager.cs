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
    public partial class UserManager : Form
    {
        private string stringConnection = @"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\Users\hanng\Downloads\ThưVien\ThưVien\Library.mdf;Integrated Security = True";
        public UserManager()
        {
            InitializeComponent();
        }

        private void btnHome_Click(object sender, EventArgs e)
        {
            Admin thuthu = new Admin();
            this.Hide();
            thuthu.ShowDialog();
            this.Show();
        }

        private void LoadData()
        {
            // Tạo câu lệnh SQL để lấy thông tin từ bảng Readers
            string query = "SELECT ReaderID AS Id, Name, Password, Username, Email, DateOfBirth, Gender FROM Readers";

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

        private void UserManager_Load(object sender, EventArgs e)
        {
            LoadData();
            dataGridView1.CellClick += dataGridView1_CellClick;
        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0 && e.ColumnIndex >= 0)
            {
                // Lấy hàng được chọn
                DataGridViewRow row = dataGridView1.Rows[e.RowIndex];

                // Gán thông tin từ hàng được chọn vào các TextBox tương ứng
                txbID.Text = row.Cells["Id"].Value.ToString();
                txbName.Text = row.Cells["Name"].Value.ToString();
                txbEmail.Text = row.Cells["Email"].Value.ToString();
                txbngaysinh.Text = row.Cells["DateOfBirth"].Value.ToString();
                txbPass.Text = row.Cells["Password"].Value.ToString(); // Đổi từ "pass" thành "Password"
                txbUsername.Text = row.Cells["Username"].Value.ToString();
                cboGioitinh.Text = row.Cells["Gender"].Value.ToString(); // Đổi từ "gioitinh" thành "Gender"
            }
        

    }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            if (dataGridView1.SelectedCells.Count > 0)
            {
                DialogResult result = MessageBox.Show("Bạn có chắc chắn muốn xóa người dùng này không?", "Xác nhận", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (result == DialogResult.Yes)
                {
                    int selectedRowIndex = dataGridView1.SelectedCells[0].RowIndex;
                    DataGridViewRow selectedRow = dataGridView1.Rows[selectedRowIndex];

                    int id = int.Parse(selectedRow.Cells["Id"].Value.ToString());

                    using (SqlConnection connection = new SqlConnection(stringConnection))
                    {
                        string deleteBorrowingsQuery = "DELETE FROM Borrowings WHERE UserID = @id";
                        string deleteReaderQuery = "DELETE FROM Readers WHERE ReaderID = @id";

                        try
                        {
                            connection.Open();

                            // Xóa các mục mượn liên quan đến người dùng
                            SqlCommand deleteBorrowingsCommand = new SqlCommand(deleteBorrowingsQuery, connection);
                            deleteBorrowingsCommand.Parameters.AddWithValue("@id", id);
                            deleteBorrowingsCommand.ExecuteNonQuery();

                            // Sau đó mới xóa người dùng
                            SqlCommand deleteReaderCommand = new SqlCommand(deleteReaderQuery, connection);
                            deleteReaderCommand.Parameters.AddWithValue("@id", id);
                            deleteReaderCommand.ExecuteNonQuery();

                            MessageBox.Show("Xóa người dùng thành công!");
                            LoadData();
                        }
                        catch (Exception ex)
                        {
                            MessageBox.Show("Lỗi: " + ex.Message);
                        }
                    }
                }
            }
            else
            {
                MessageBox.Show("Vui lòng chọn một người dùng để xóa.");
            }
        }

        private void button4_Click(object sender, EventArgs e)
        {
            BookAdmin book = new BookAdmin();
            this.Hide();
            book.ShowDialog();
            this.Show();
        }

        private void btnHome_Click_1(object sender, EventArgs e)
        {
            Admin thuthu = new Admin();
            this.Hide();
            thuthu.ShowDialog();
            this.Show();
        }

        private void button5_Click(object sender, EventArgs e)
        {

        }
    }
}
