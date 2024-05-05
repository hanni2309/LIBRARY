using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ThưVien
{
    public partial class Admin : Form
    {
        public Admin()
        {
            InitializeComponent();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            UserManager capquyen = new UserManager();
            this.Hide();
            capquyen.ShowDialog();
            this.Show();
        }

        private void button6_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void btnThongke_Click(object sender, EventArgs e)
        {
            // Tạo một đối tượng của form ThongKe
            ThongKe thongKeForm = new ThongKe();

            // Hiển thị form ThongKe
            thongKeForm.Show();
            // hoặc nếu bạn muốn form ThongKe là modal (không thể tương tác với các form khác cho đến khi nó được đóng)
            // thongKeForm.ShowDialog();
        }

        private void btnHome_Click(object sender, EventArgs e)
        {
            Admin thuthu = new Admin();
            this.Hide();
            thuthu.ShowDialog();
            this.Show();
        }

        private void button7_Click(object sender, EventArgs e)
        {
            AddThuthu thuthu = new AddThuthu();
            this.Hide();
            thuthu.ShowDialog();
            this.Show();
        }
    }
}
