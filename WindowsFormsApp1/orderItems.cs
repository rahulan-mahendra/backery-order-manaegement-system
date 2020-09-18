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
    public partial class orderItems : UserControl
    {
        SqlConnection con = new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\Users\rahulan\Desktop\off_Project\WindowsFormsApp1\Database1.mdf;Integrated Security=True");
        DataTable dt = new DataTable();
        int tot = 0;

        public orderItems()
        {
            InitializeComponent();
        }

        private void label8_Click(object sender, EventArgs e)
        {

        }

        private void textBox5_TextChanged(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {

        }
 

        private void orderItems_Load(object sender, EventArgs e)
        {
            if (con.State == ConnectionState.Open)
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
            cmd.CommandText = "select * from productDetails where product_name like('" + textBox4.Text + "%')";
            cmd.ExecuteNonQuery();
            DataTable dt = new DataTable();
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            da.Fill(dt);
            foreach (DataRow dr in dt.Rows)
            {
                listBox1.Items.Add(dr["product_name"].ToString());
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

        private void listBox1_ImeModeChanged(object sender, EventArgs e)
        {

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
                if (e.KeyCode == Keys.Enter)
                {
                    textBox4.Text = listBox1.SelectedItem.ToString();
                    listBox1.Visible = false;
                }
            }
            catch (Exception ex)
            {

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

        private void button1_Click_1(object sender, EventArgs e)
        {
            if (textBox1.Text == "" || textBox2.Text == "" || textBox3.Text == "" || dateTimePicker1.Value.ToString() == "" || textBox4.Text == "" || textBox5.Text == "" || textBox6.Text == "" || textBox7.Text == "" || textBox8.Text == "" || textBox9.Text == "" || textBox10.Text == "" || textBox11.Text == "" || textBox12.Text == ""  ) 
            {
                MessageBox.Show("Fill all the fields", "User account control pannel", MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1);
            }
            else
            {
                int stock = 0;
                SqlCommand cmd1 = con.CreateCommand();
                cmd1.CommandType = CommandType.Text;
                cmd1.CommandText = "select * from productDetails where product_name ='" + textBox4.Text + "'";
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
                    MessageBox.Show("This much of quantity is not available in the stock. You have to bake!");
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

                //textBox3.Text = "";
                //textBox4.Text = "";
                //textBox5.Text = "";
                //textBox6.Text = "";
                listBox1.Visible = false;
            }
            
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
            MessageBox.Show("Record deleted successfully");
            textBox3.Text = "";
            textBox4.Text = "";
            textBox5.Text = "";
            textBox6.Text = "";
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (textBox1.Text == "" || textBox2.Text == "" || textBox3.Text == "" || dateTimePicker1.Value.ToString() == "" || textBox4.Text == "" || textBox5.Text == "" || textBox6.Text == "" || textBox7.Text == "" || textBox8.Text == "" || textBox9.Text == "" || textBox10.Text == "" || textBox11.Text == "" || textBox12.Text == "")
            {
                MessageBox.Show("Fill all the fields", "User account control pannel", MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1);
            }
            else
            {
                //string orderid = "";
                SqlCommand cmd1 = con.CreateCommand();
                cmd1.CommandType = CommandType.Text;
                cmd1.CommandText = "Insert into fullOrderDetails values('" + textBox1.Text + "', '" + textBox2.Text + "', '" + dateTimePicker1.Value.ToString("dd/mm/yyyy") + "', '" + textBox8.Text + "', '" + textBox7.Text + "', '" + textBox9.Text + "', '" + textBox12.Text + "', '" + textBox11.Text + "', '" + textBox10.Text + "', '" + textBox4.Text + "', '" + textBox3.Text + "', '" + textBox6.Text + "', '" + textBox5.Text + "', '" + Convert.ToBoolean(0) + "' )";
                cmd1.ExecuteNonQuery();

                /* SqlCommand cmd2 = con.CreateCommand();
                 cmd2.CommandType = CommandType.Text;
                 cmd2.CommandText = "Select top 1 * from order_user order by id desc";
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
                     cmd3.CommandText = "Insert into order_item values('" + orderid.ToString() + "', '" + dr["Product"].ToString() + "', '" + dr["Price"].ToString() + "', '" + dr["Quantity"].ToString() + "', '" + dr["Total"].ToString() + "')";
                     cmd3.ExecuteNonQuery();

                     //////////
                     SqlCommand cmd4 = con.CreateCommand();
                     cmd4.CommandType = CommandType.Text;
                     //cmd4.CommandText = "Insert into fullOrderDetails values('" + orderid.ToString() + "', '" + textBox1.Text + "', '" + textBox2.Text + "', '" + dateTimePicker1.Value.ToString("dd/mm/yyyy") + "', '" + textBox8.Text + "', '"+ textBox8.Text  +"', '" +textBox7.Text +"', '" +textBox9.Text +"', '" + textBox12.Text + "', '" + textBox11.Text + "', '" + textBox10.Text + "','"+ textBox4.Text + "','"+ textBox3.Text + "','"+ textBox6.Text + "', '"+textBox5.Text +"')";
                     cmd4.CommandText = "Insert into fullOrderDetails values('" + orderid.ToString() + "', '" + textBox1.Text + "', '" + textBox2.Text + "', '" + dateTimePicker1.Value.ToString("dd/mm/yyyy") + "', '" + textBox8.Text + "',  '" + textBox7.Text + "', '" + textBox9.Text + "', '" + textBox12.Text + "', '" + textBox11.Text + "', '" + textBox10.Text + "','" + dr["Product"].ToString() + "', '" + dr["Price"].ToString() + "', '" + dr["Quantity"].ToString() + "', '" + dr["Total"].ToString() + "')";
                     cmd4.ExecuteNonQuery();
                     ///////////

                     /*
                     qty = Convert.ToInt32(dr["Quantity"].ToString());
                     pname = dr["Product"].ToString();


                     SqlCommand cmd6 = con.CreateCommand();
                     cmd6.CommandType = CommandType.Text;
                     cmd6.CommandText = "Update stock set product_quantity = product_quantity  - " + qty + "  where product_name = '" + pname.ToString() + "'";
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
                 dataGridView1.DataSource = dt;*/

                MessageBox.Show("Record inserted successfully");
            }
        }

        private void textBox8_TextChanged(object sender, EventArgs e)
        {

        }

        private void label9_Click(object sender, EventArgs e)
        {

        }

        private void label10_Click(object sender, EventArgs e)
        {

        }

        private void button4_Click(object sender, EventArgs e)
        {
            Dashboard db = new Dashboard();
            db.Show();
            this.Hide();
        }

        private void listBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void textBox4_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox8_KeyPress(object sender, KeyPressEventArgs e)
        {
            // Verify that the pressed key isn't CTRL or any non-numeric digit
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar) && (e.KeyChar != '.'))
            {
                e.Handled = true;
            }

            // If you want, you can allow decimal (float) numbers
            if ((e.KeyChar == '.') && ((sender as TextBox).Text.IndexOf('.') > -1))
            {
                e.Handled = true;
            }
        }

        private void textBox6_KeyPress(object sender, KeyPressEventArgs e)
        {
            // Verify that the pressed key isn't CTRL or any non-numeric digit
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar) && (e.KeyChar != '.'))
            {
                e.Handled = true;
            }

            // If you want, you can allow decimal (float) numbers
            if ((e.KeyChar == '.') && ((sender as TextBox).Text.IndexOf('.') > -1))
            {
                e.Handled = true;
            }
        }
    }
}
