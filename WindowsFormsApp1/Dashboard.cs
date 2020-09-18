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

namespace WindowsFormsApp1
{
    public partial class Dashboard : Form
    {
        SqlConnection con = new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\Users\rahulan\Desktop\off_Project\WindowsFormsApp1\Database1.mdf;Integrated Security=True");
        public Dashboard()
        {
            InitializeComponent();
        }

        private void orderItems1_Load(object sender, EventArgs e)
        {
            
        }

        private void productInsert1_Load(object sender, EventArgs e)
        {
      
        }

        private void button5_Click(object sender, EventArgs e)
        {
            productInsert pi = new productInsert();
            MainControlClass.showControl(pi,Content);

            button8.Visible = false;
            /*button9.Visible = false;*/
            button10.Visible = false;
            button11.Visible = true;
            button12.Visible = false;
            button13.Visible = false;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            /*salestems si = new salestems();
            MainControlClass.showControl(si, Content);

            button8.Visible = false;
            button9.Visible = true;
            button10.Visible = false;
            button11.Visible = false;
            button12.Visible = false;
            button13.Visible = false;*/

        }

        private void Content_Paint(object sender, PaintEventArgs e)
        {

        }

        private void button4_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void button6_Click(object sender, EventArgs e)
        {
            manufactureReport mr = new manufactureReport();
            MainControlClass.showControl(mr, Content);

            button8.Visible = false;
            /*button9.Visible = false;*/
            button10.Visible = false;
            button11.Visible = false;
            button12.Visible = true;
            button13.Visible = false;
        }

        private void button3_Click(object sender, EventArgs e)
        {
            orderItems oi = new orderItems();
            MainControlClass.showControl(oi, Content);

            button8.Visible = false;
            /*button9.Visible = false;*/
            button10.Visible = true;
            button11.Visible = false;
            button12.Visible = false;
            button13.Visible = false;
        }

        private void button7_Click(object sender, EventArgs e)
        {
            orderReport or = new orderReport();
            MainControlClass.showControl(or, Content);

            button8.Visible = false;
            /*button9.Visible = false;*/
            button10.Visible = false;
            button11.Visible = false;
            button12.Visible = false;
            button13.Visible = true;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            /*Dashboard db = new Dashboard();
            MainControlClass.showControl(db, Content);*/

            NewItems ni = new NewItems();
            MainControlClass.showControl(ni, Content);

            button8.Visible = true;
            /*button9.Visible = false;*/
            button10.Visible = false;
            button11.Visible = false;
            button12.Visible = false;
            button13.Visible = false;
        }

        private void button14_Click(object sender, EventArgs e)
        {
            login li = new login();
            li.Show();
            this.Hide();
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {

        }

        private void panel2_Paint(object sender, PaintEventArgs e)
        {

        }
    }
}
