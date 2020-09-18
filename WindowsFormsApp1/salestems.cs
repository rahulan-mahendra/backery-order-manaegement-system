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
    public partial class salestems : UserControl
    {
        SqlConnection con = new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\Users\rahulan\Desktop\off_Project\WindowsFormsApp1\Database1.mdf;Integrated Security=True");
        DataTable dt = new DataTable();
        int tot = 0;

        public salestems()
        {
            InitializeComponent();
        }

        private void groupBox1_Enter(object sender, EventArgs e)
        {

        }

        private void salestems_Load(object sender, EventArgs e)
        {
            if(con.State == ConnectionState.Open)
            {
                con.Close();
            }
            con.Open();

            dt.Clear();
            dt.Columns.Add("Product");
            dt.Columns.Add("Price");
            dt.Columns.Add("Quantity");
            dt.Columns.Add("Total");
        }

        private void textBox4_KeyUp(object sender, KeyEventArgs e)
        {
            listBox1.Visible = true;

            listBox1.Items.Clear();
            SqlCommand cmd = con.CreateCommand();
            cmd.CommandType = CommandType.Text;
            cmd.CommandText = "select * from stock where product_name like('" + textBox4.Text + "%')";
            cmd.ExecuteNonQuery();
            DataTable dt = new DataTable();
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            da.Fill(dt);
            foreach (DataRow dr in dt.Rows)
            {
                listBox1.Items.Add(dr["product_name"].ToString());
            }
        }

        private void listBox1_KeyDown(object sender, KeyEventArgs e)
        {
            try
            {
                if (e.KeyCode == Keys.Down)
                {
                    this.listBox1.SelectedIndex = this.listBox1.SelectedIndex + 1;
                }
                if (e.KeyCode == Keys.Up)
                {
                    this.listBox1.SelectedIndex = this.listBox1.SelectedIndex - 1;
                }
                if(e.KeyCode == Keys.Enter)
                {
                    textBox4.Text = listBox1.SelectedItem.ToString();
                    listBox1.Visible = false;
                }
            }
            catch(Exception ex)
            {
            }
        }

        private void textBox4_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Down)
            {
                listBox1.Focus();
                listBox1.SelectedIndex = 0;
            }
        }

        private void textBox3_Enter(object sender, EventArgs e)
        {
            SqlCommand cmd = con.CreateCommand();
            cmd.CommandType = CommandType.Text;
            cmd.CommandText = "select top 1 * from productDetails where product_name= '" + textBox4.Text + "' order by id desc";
            cmd.ExecuteNonQuery();
            DataTable dt = new DataTable();
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            da.Fill(dt);
            foreach (DataRow dr in dt.Rows)
            {
                textBox3.Text = dr["product_price"].ToString();
            }
        }

        private void textBox6_Leave(object sender, EventArgs e)
        {
            try
            {
                textBox5.Text = Convert.ToString(Convert.ToInt32(textBox6.Text) * Convert.ToInt32(textBox3.Text));
            }
            catch (Exception ex)
            {

            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            int stock = 0;
            SqlCommand cmd1 = con.CreateCommand();
            cmd1.CommandType = CommandType.Text;
            cmd1.CommandText = "select * from stock where product_name ='" + textBox4.Text + "'";
            cmd1.ExecuteNonQuery();
            DataTable dt1 = new DataTable();
            SqlDataAdapter da1 = new SqlDataAdapter(cmd1);
            da1.Fill(dt1);
            foreach (DataRow dr1 in dt1.Rows)
            {
                stock = Convert.ToInt32(dr1["product_quantity"].ToString());
            }

            if (Convert.ToInt32(textBox6.Text) > stock)
            {
                MessageBox.Show("This much of quantity is not available in the stock", "Inventory control pannel", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1);
            }
            else
            {
                DataRow dr = dt.NewRow();
                dr["Product"] = textBox4.Text;
                dr["Price"] = textBox3.Text;
                dr["Quantity"] = textBox6.Text;
                dr["Total"] = textBox5.Text;
                dt.Rows.Add(dr);
                dataGridView1.DataSource = dt;

                tot = tot + Convert.ToInt32(dr["Total"].ToString());

                label10.Text = tot.ToString();
            }

            textBox3.Text = "";
            textBox4.Text = "";
            textBox5.Text = "";
            textBox6.Text = "";
            listBox1.Visible = false;

        }

        private void button3_Click(object sender, EventArgs e)
        {
            try
            {
                tot = 0;
                dt.Rows.RemoveAt(Convert.ToInt32(dataGridView1.CurrentCell.RowIndex.ToString()));
                foreach (DataRow dr1 in dt.Rows)
                {
                    tot = tot + Convert.ToInt32(dr1["Total"].ToString());
                    label10.Text = tot.ToString();
                }
            }
            catch (Exception ex)
            {

            }
            MessageBox.Show("Record deleted successfully", "Inventory control pannel", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1);
        }

        private void button2_Click(object sender, EventArgs e)
        {
            string orderid = "";
            SqlCommand cmd1 = con.CreateCommand();
            cmd1.CommandType = CommandType.Text;
            cmd1.CommandText = "Insert into sales_orderUser values('" + textBox1.Text + "', '" + textBox2.Text + "', '" + dateTimePicker1.Value.ToString("dd/mm/yyyy") + "')";
            cmd1.ExecuteNonQuery();

            SqlCommand cmd2 = con.CreateCommand();
            cmd2.CommandType = CommandType.Text;
            cmd2.CommandText = "Select top 1 * from sales_orderUser order by id desc";
            cmd2.ExecuteNonQuery();

            DataTable dt2 = new DataTable();
            SqlDataAdapter da2 = new SqlDataAdapter(cmd2);
            da2.Fill(dt2);
            foreach (DataRow dr2 in dt2.Rows)
            {
                orderid = dr2["id"].ToString();
            }

            foreach (DataRow dr in dt.Rows)
            {
                int qty = 0;
                string pname = "";

                SqlCommand cmd3 = con.CreateCommand();
                cmd3.CommandType = CommandType.Text;
                cmd3.CommandText = "Insert into sales_OrderItem values('" + orderid.ToString() + "', '" + dr["Product"].ToString() + "', '" + dr["Price"].ToString() + "', '" + dr["Quantity"].ToString() + "', '" + dr["Total"].ToString() + "')";
                cmd3.ExecuteNonQuery();

                
                qty = Convert.ToInt32(dr["Quantity"].ToString());
                pname = dr["Product"].ToString();


                SqlCommand cmd6 = con.CreateCommand();
                cmd6.CommandType = CommandType.Text;
                cmd6.CommandText = "Update stock set product_quantity = product_quantity  - "+qty+"  where product_name = '" + pname.ToString() + "'";
                cmd6.ExecuteNonQuery();

            }

            textBox1.Text = "";
            textBox2.Text = "";
            textBox3.Text = "";
            textBox4.Text = "";
            textBox5.Text = "";
            textBox6.Text = "";
            label10.Text = "";

            dt.Clear();
            dataGridView1.DataSource = dt;

            MessageBox.Show("Record inserted successfully", "Inventory control pannel", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1);
        }

        private void button4_Click(object sender, EventArgs e)
        {
            Dashboard db = new Dashboard();
            db.Show();
            this.Hide();
        }
    }
}
