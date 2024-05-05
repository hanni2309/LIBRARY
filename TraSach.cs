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
    public partial class TraSach : Form
    {
        private string stringConnection = @"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\Users\hanng\Downloads\ThưVien\ThưVien\Library.mdf;Integrated Security=True";
        public TraSach()
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
            string query = "SELECT BorrowingID, UserID, BookID, BorrowedDate FROM Borrowings WHERE Status = @Status";

            using (SqlConnection connection = new SqlConnection(stringConnection))
            {
                SqlDataAdapter adapter = new SqlDataAdapter(query, connection);
                DataTable dataTable = new DataTable();

                try
                {
                    connection.Open();
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
            if (dataGridView1.SelectedRows.Count > 0)
            {
                int borrowingID = Convert.ToInt32(dataGridView1.SelectedRows[0].Cells["BorrowingID"].Value);
                DateTime returnDate = DateTime.Now;

                using (SqlConnection connection = new SqlConnection(stringConnection))
                {
                    string query = "UPDATE Borrowings SET Status = 'Đã trả', ReturnDate = @ReturnDate WHERE BorrowingID = @BorrowingID";

                    SqlCommand command = new SqlCommand(query, connection);
                    command.Parameters.AddWithValue("@BorrowingID", borrowingID);
                    command.Parameters.AddWithValue("@ReturnDate", returnDate);

                    try
                    {
                        connection.Open();
                        int rowsAffected = command.ExecuteNonQuery();
                        if (rowsAffected > 0)
                        {
                            MessageBox.Show("Trả sách thành công!");
                            LoadData(); // Tải lại dữ liệu sau khi cập nhật trạng thái
                        }
                        else
                        {
                            MessageBox.Show("Không thể cập nhật trạng thái.");
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
                MessageBox.Show("Vui lòng chọn một sách để trả.");
            }
        }



        private void TraSach_Load(object sender, EventArgs e)
        {
            LoadData();
        }

        private void dataGridView1_CellClick_1(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                DataGridViewRow row = dataGridView1.Rows[e.RowIndex];
                txbuserid.Text = row.Cells["UserID"].Value.ToString();
                txbbookid.Text = row.Cells["BookID"].Value.ToString();
                dtpBorrowedDate.Value = Convert.ToDateTime(row.Cells["BorrowedDate"].Value);
            }
        }
    }
}
