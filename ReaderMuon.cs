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
    public partial class ReaderMuon : Form
    {
        string connectionString = @"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\Users\hanng\Downloads\ThưVien\ThưVien\Library.mdf;Integrated Security=True";
      

        public ReaderMuon()
        {
            InitializeComponent();
        }

        private void ReaderMuon_Load(object sender, EventArgs e)
        {
          

        }
      

    }
}
