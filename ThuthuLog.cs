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



        private void button3_Click_1(object sender, EventArgs e)
        {
            AddUser user = new AddUser();
            this.Hide();
            user.ShowDialog();
            this.Show();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            AddBook book = new AddBook();
            this.Hide();
            book.ShowDialog();
            this.Show();
        }

        private void button5_Click(object sender, EventArgs e)
        {
            MuonSach book = new MuonSach();
            this.Hide();
            book.ShowDialog();
            this.Show();
        }

        private void btntra_Click(object sender, EventArgs e)
        {
            TraSach book = new TraSach();
            this.Hide();
            book.ShowDialog();
            this.Show();
        }
    }
}
