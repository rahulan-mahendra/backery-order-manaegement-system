using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;

namespace WindowsFormsApp1
{
    public partial class manufactureReport : UserControl
    {
        SqlConnection con = new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\Users\rahulan\Desktop\off_Project\WindowsFormsApp1\Database1.mdf;Integrated Security=True");

        public manufactureReport()
        {
            InitializeComponent();
        }

        private void manufactureReport_Load(object sender, EventArgs e)
        {
            if (con.State == ConnectionState.Open)
            {
                con.Close();
            }
            con.Open();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            int i = 0;

            SqlCommand cmd = con.CreateCommand();
            cmd.CommandType = CommandType.Text;
            cmd.CommandText = "Select * from productDetails";
            cmd.ExecuteNonQuery();
            DataTable dt = new DataTable();
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            dataGridView1.DataSource = dt;
            da.Fill(dt);

            /*foreach (DataRow dr in dt.Rows)
            {
                i = i + Convert.ToInt32(dr["product_total"].ToString());
            }

           label1.Text = i.ToString();*/
        }

        private void button3_Click(object sender, EventArgs e)
        {
            string startDate;
            string endDate;
            int i = 0;

            startDate = dateTimePicker2.Value.ToString("dd/MM/yyyy");
            endDate = dateTimePicker1.Value.ToString("dd/MM/yyyy");


            SqlCommand cmd = con.CreateCommand();
            cmd.CommandType = CommandType.Text;
            cmd.CommandText = "select * from productDetails where manufactured_date >= '" + startDate.ToString() + "' AND manufactured_date <= '" + endDate.ToString() +"' ";
            cmd.ExecuteNonQuery();
            DataTable dt = new DataTable();
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            dataGridView1.DataSource = dt;
            da.Fill(dt);

            /*foreach (DataRow dr in dt.Rows)
            {
                i = i + Convert.ToInt32(dr["product_total"].ToString());
            }

            label1.Text = i.ToString();*/
        }

        private void button1_Click(object sender, EventArgs e)
        {

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void button4_Click(object sender, EventArgs e)
        {
            Dashboard db = new Dashboard();
            db.Show();
            this.Hide();
        }
    }
}
