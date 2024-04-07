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
    public partial class ThuthuLog : Form
    {
        public ThuthuLog()
        {
            InitializeComponent();
        }


        private void btnUser_Click(object sender, EventArgs e)
        {
            AddUser user = new AddUser();
            this.Hide();
            user.ShowDialog();
            this.Show();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            AddBook book = new AddBook();
            this.Hide();
            book.ShowDialog();
            this.Show();
        }
    }
}
