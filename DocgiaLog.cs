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
    public partial class DocgiaLog : Form
    {
        public DocgiaLog()
        {
            InitializeComponent();
        }

        private void button5_Click(object sender, EventArgs e)
        {
            ReaderMuon muon = new ReaderMuon();
            this.Hide();
            muon.ShowDialog();
            this.Show();
        }

        private void btntra_Click(object sender, EventArgs e)
        {
            ReaderTra tra = new ReaderTra();
            this.Hide();
            tra.ShowDialog();
            this.Show();
        }

        private void button6_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }
    }
}
