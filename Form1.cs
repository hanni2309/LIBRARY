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
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }


        private void btnDangnhap_Click_1(object sender, EventArgs e)
        {
            Login login = new Login();
            this.Hide();
            login.ShowDialog();
            this.Show();
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void adminToolStripMenuItem_Click(object sender, EventArgs e)
        {
            AdminSignIn admin = new AdminSignIn();
            this.Hide();
            admin.ShowDialog();
            this.Show();
        }

        private void đọcGiảToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Login login = new Login();
            this.Hide();
            login.ShowDialog();
            this.Show();
        }

        private void thủThưToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ThuthuSignIn thuthu = new ThuthuSignIn();
            this.Hide();
            thuthu.ShowDialog();
            this.Show();
        }
    }
}
