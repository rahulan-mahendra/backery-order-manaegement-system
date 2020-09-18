using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsFormsApp1
{
    public partial class adminDashboard : Form
    {
        public adminDashboard()
        {
            InitializeComponent();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Dashboard db = new Dashboard();
            db.Show();
            this.Hide();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            employeeControl ec = new employeeControl();
            ec.Show();
            this.Hide();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            login li = new login();
            li.Show();
            this.Hide();
        }

        private void button3_Click_1(object sender, EventArgs e)
        {
            login li = new login();
            li.Show();
            this.Hide();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            SalesReport2 sr = new SalesReport2();
            sr.Show();
            this.Hide();
        }

        private void adminDashboard_Load(object sender, EventArgs e)
        {

        }
    }
}
