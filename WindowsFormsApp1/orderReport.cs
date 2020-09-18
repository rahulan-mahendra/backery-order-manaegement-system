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

    public partial class orderReport : UserControl
    {
        SqlConnection con = new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\Users\rahulan\Desktop\off_Project\WindowsFormsApp1\Database1.mdf;Integrated Security=True");
       
        public orderReport()
        {
            InitializeComponent();
        }

        private void orderReport_Load(object sender, EventArgs e)
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
            //cmd.CommandText = "Select order_id, firstName, lastName, product, price, quantity, total, orderDate from order_user, order_item";
            //cmd.CommandText = "Select * from order_item";
            cmd.CommandText = "Select * from fullOrderDetails";

            cmd.ExecuteNonQuery();
            DataTable dt = new DataTable();
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            dataGridView1.DataSource = dt;
            da.Fill(dt);

            /*foreach (DataRow dr in dt.Rows)
            {
                i = i + Convert.ToInt32(dr["total"].ToString());
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
            cmd.CommandText = "select order_id, firstName, note, product, price, quantity, total, orderDate from order_user, order_item where orderDate >= '" + startDate.ToString() + "' AND orderDate <= '" + endDate.ToString() + "' ";
            cmd.ExecuteNonQuery();
            DataTable dt = new DataTable();
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            dataGridView1.DataSource = dt;
            da.Fill(dt);

            /*foreach (DataRow dr in dt.Rows)
            {
                i = i + Convert.ToInt32(dr["total"].ToString());
            }

            label1.Text = i.ToString();*/
        }

        private void button1_Click(object sender, EventArgs e)
        {
           
        }

        private void button4_Click(object sender, EventArgs e)
        {
            int id = Convert.ToInt32(dataGridView1.SelectedCells[0].Value.ToString());
            SqlCommand cmd = con.CreateCommand();
            cmd.CommandType = CommandType.Text;
            cmd.CommandText = "UPDATE fullOrderDetails SET complete = '" + Convert.ToBoolean(1) + "' where Id = " + id + "";
            cmd.ExecuteNonQuery();

            cmd.CommandType = CommandType.Text;
            cmd.CommandText = "Select * from fullOrderDetails where complete = '"+Convert.ToBoolean(0)+"'";

            cmd.ExecuteNonQuery();
            DataTable dt = new DataTable();
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            dataGridView1.DataSource = dt;
            da.Fill(dt);

            MessageBox.Show("Order Completed");
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void button5_Click(object sender, EventArgs e)
        {
            Dashboard db = new Dashboard();
            db.Show();
            this.Hide();
        }
    }
}
