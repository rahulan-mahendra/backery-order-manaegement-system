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
    public partial class productInsert : UserControl
    {
        SqlConnection con = new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\Users\rahulan\Desktop\off_Project\WindowsFormsApp1\Database1.mdf;Integrated Security=True");
        public productInsert()
        {
            InitializeComponent();
        }

        

        private void textBox7_TextChanged(object sender, EventArgs e)
        {

        }

        private void dateTimePicker1_ValueChanged(object sender, EventArgs e)
        {

        }

        private void dateTimePicker2_ValueChanged(object sender, EventArgs e)
        {

        }

        private void label8_Click(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (textBox1.Text == "" || textBox2.Text == "" || textBox3.Text == "" || dateTimePicker1.Value.ToString()=="" || dateTimePicker2.Value.ToString() == "" )
            {
                MessageBox.Show("Fill all the fields", "User account control pannel", MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1);
            }
            else
            {
                con.Open();
                int i = 0;
                SqlCommand cmd = con.CreateCommand();
                cmd.CommandType = CommandType.Text;
                cmd.CommandText = "select * from productDetails where product_name = '" + textBox1.Text + "'";
                cmd.ExecuteNonQuery();
                con.Close();
                DataTable dt = new DataTable();
                SqlDataAdapter da = new SqlDataAdapter(cmd);
                da.Fill(dt);
                i = Convert.ToInt32(dt.Rows.Count.ToString());
                
                if (i == 0)
                {
                    con.Open();
                    SqlCommand cmd1 = con.CreateCommand();
                    cmd1.CommandType = CommandType.Text;
                    cmd1.CommandText = "Insert into productDetails values('" + textBox1.Text + "','" + textBox2.Text + "','" + textBox3.Text + "','" + dateTimePicker1.Value.ToString("dd-MM-yyyy") + "','" + dateTimePicker2.Value.ToString("dd-MM-yyyy") + "')";
                    cmd1.ExecuteNonQuery();

                    textBox1.Text = "";
                    textBox2.Text = "";
                    textBox3.Text = "";
                    textBox4.Text = "";
                    /*textBox5.Text = "";
                    textBox6.Text = "";*/
                    
                    con.Close();
                    fill_dg();

                    MessageBox.Show("User record inserted successfully", "User account control pannel", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1);
                }
                else
                {
                    MessageBox.Show("Product is already registered", "User account control pannel", MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1);
                }
                /*con.Open();

                int i;
                SqlCommand cmd1 = con.CreateCommand();
                cmd1.CommandType = CommandType.Text;
                cmd1.CommandText = "Select * from stock where product_name = '" + comboBox1.Text + "'";
                cmd1.ExecuteNonQuery();
                DataTable dt1 = new DataTable();
                SqlDataAdapter da1 = new SqlDataAdapter(cmd1);
                da1.Fill(dt1);
                i = Convert.ToInt32(dt1.Rows.Count.ToString());

                if (i == 0)
                {
                    SqlCommand cmd = con.CreateCommand();
                    cmd.CommandType = CommandType.Text;
                    cmd.CommandText = "Insert into productDetails values('" + comboBox1.Text + "','" + textBox2.Text + "','" + textBox3.Text + "','" + textBox4.Text + "','" + dateTimePicker1.Value.ToString("dd-MM-yyyy") + "','" + dateTimePicker2.Value.ToString("dd-MM-yyyy") + "','" + textBox7.Text + "')";
                    cmd.ExecuteNonQuery();

                    SqlCommand cmd3 = con.CreateCommand();
                    cmd3.CommandType = CommandType.Text;
                    cmd3.CommandText = "Insert into stock values('" + comboBox1.Text + "','" + textBox2.Text + "')";
                    cmd3.ExecuteNonQuery();
                }
                else
                {
                    SqlCommand cmd2 = con.CreateCommand();
                    cmd2.CommandType = CommandType.Text;
                    cmd2.CommandText = "Insert into productDetails values('" + comboBox1.Text + "','" + textBox2.Text + "','" + textBox3.Text + "','" + textBox4.Text + "','" + dateTimePicker1.Value.ToString("dd-MM-yyyy") + "','" + dateTimePicker2.Value.ToString("dd-MM-yyyy") + "','" + textBox7.Text + "')";
                    cmd2.ExecuteNonQuery();

                    SqlCommand cmd5 = con.CreateCommand();
                    cmd5.CommandType = CommandType.Text;
                    cmd5.CommandText = "Update stock set product_quantity = product_quantity + " + textBox2.Text + " where product_name = '" + comboBox1.Text + "'";
                    cmd5.ExecuteNonQuery();
                }

                comboBox1.Text = "";
                textBox2.Text = "";
                textBox3.Text = "";
                textBox4.Text = "";
                dateTimePicker1.Text = "";
                dateTimePicker2.Text = "";
                

                con.Close();
                MessageBox.Show("Record inserted successfuly", "Inventory control pannel", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1);
            */
            }
        }

        private void textBox4_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox3_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void label6_Click(object sender, EventArgs e)
        {

        }

        private void label5_Click(object sender, EventArgs e)
        {

        }

        private void label4_Click(object sender, EventArgs e)
        {

        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void productInsert_Load(object sender, EventArgs e)
        {
          /* if (con.State == ConnectionState.Open)
            {
                con.Close();
            }
            con.Open();*/
            fill_dg();
            //fill_product_name();
        }

        public void fill_product_name()
        {
            con.Open();
            SqlCommand cmd = con.CreateCommand();
            cmd.CommandType = CommandType.Text;
            cmd.CommandText = "Select * from product_name";
            cmd.ExecuteNonQuery();
            DataTable dt = new DataTable();
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            da.Fill(dt);

            foreach(DataRow dr in dt.Rows)
            {
                comboBox1.Items.Add(dr["product_name"].ToString());
            }
            con.Close();
        }


        private void button2_Click(object sender, EventArgs e)
        {
            try
            {
                con.Open();
                SqlCommand cmd = con.CreateCommand();
                cmd.CommandType = CommandType.Text;
                cmd.CommandText = "Insert into product_name values ('" + textBox10.Text + "')";
                cmd.ExecuteNonQuery();

                textBox10.Text = "";
                //fill_dg();

                con.Close();
                fill_dg();
                fill_product_name();
                MessageBox.Show("Record inserted successfully", "Inventory control pannel", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }

        }

        public void fill_dg()
        {
            con.Open();
            SqlCommand cmd = con.CreateCommand();
            cmd.CommandType = CommandType.Text;
            cmd.CommandText = "Select * from productDetails";
            cmd.ExecuteNonQuery();

            DataTable dt = new DataTable();
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            da.Fill(dt);
            dataGridView1.DataSource = dt;
            con.Close();
        }

        private void textBox5_TextChanged(object sender, EventArgs e)
        {

        }

        private void label7_Click(object sender, EventArgs e)
        {

        }

        private void button3_Click(object sender, EventArgs e)
        {
            con.Open();
            dataGridView1.Visible = true;

            int i = Convert.ToInt32(dataGridView1.SelectedCells[0].Value.ToString());

            SqlCommand cmd = con.CreateCommand();
            cmd.CommandType = CommandType.Text;
            cmd.CommandText = "Update product_name set product_name ='"+ textBox5.Text +"' where id = '" + i + "'";
            cmd.ExecuteNonQuery();
            con.Close();
            fill_dg();
            fill_product_name();
            MessageBox.Show("Record updated successfully", "Inventory control pannel", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1);
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
           
            textBox1.Text = dataGridView1.SelectedCells[1].Value.ToString();
            textBox2.Text = dataGridView1.SelectedCells[2].Value.ToString();
            textBox3.Text = dataGridView1.SelectedCells[3].Value.ToString();
            
            
            textBox6.Text = dataGridView1.SelectedCells[0].Value.ToString();
            
        }

        private void groupBox1_Enter(object sender, EventArgs e)
        {

        }

        private void textBox4_Leave(object sender, EventArgs e)
        {
            textBox4.Text = Convert.ToString(Convert.ToInt32(textBox2.Text) * Convert.ToInt32(textBox3.Text));
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void button4_Click(object sender, EventArgs e)
        {
           /* con.Open();

            SqlCommand cmd = con.CreateCommand();
            cmd.CommandType = CommandType.Text;
            cmd.CommandText = "Delete from product_name ='" + textBox5.Text + "'";
            cmd.ExecuteNonQuery();

            con.Close();
            fill_dg();
            MessageBox.Show("Record deleted successfully");*/
        }

        private void groupBox2_Enter(object sender, EventArgs e)
        {

        }

        private void button4_Click_1(object sender, EventArgs e)
        {
            Dashboard db = new Dashboard();
            db.Show();
            this.Hide();
        }

        private void textBox10_TextChanged(object sender, EventArgs e)
        {

        }

        private void button5_Click(object sender, EventArgs e)
        {
            
                con.Open();
                int user_id = Convert.ToInt32(textBox6.Text.ToString());
                
                SqlCommand cmd = con.CreateCommand();
                cmd.CommandType = CommandType.Text;
                cmd.CommandText = "UPDATE productDetails SET product_name='" + textBox1.Text + "', product_quantity='" + textBox2.Text + "', product_price='" + textBox3.Text + "', manufactured_date='" + dateTimePicker1.Value.ToString("dd-MM-yyyy") + "', expired_date='" + dateTimePicker2.Value.ToString("dd-MM-yyyy") + "' WHERE id='" + user_id + "'";
                cmd.ExecuteNonQuery();
                textBox1.Text = "";
                textBox2.Text = "";
                textBox3.Text = "";
                textBox4.Text = "";
                /*textBox5.Text = "";
                textBox6.Text = "";*/
                
                con.Close();
                fill_dg();
                MessageBox.Show("Record updated succefully", "User account control pannel", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1);
            
            /*catch (Exception ex)
            {
                MessageBox.Show("Record update failed", "User account control pannel", MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1);
            }*/
        }

        private void button6_Click(object sender, EventArgs e)
        {
            try
            {
                con.Open();
                int id = Convert.ToInt32(dataGridView1.SelectedCells[0].Value.ToString());
                SqlCommand cmd = con.CreateCommand();
                cmd.CommandType = CommandType.Text;
                cmd.CommandText = "Delete from productDetails where id = " + id + "";
                cmd.ExecuteNonQuery();

                textBox1.Text = "";
                textBox2.Text = "";
                textBox3.Text = "";
                //textBox4.Text = "";
                textBox5.Text = "";
                textBox6.Text = "";

                con.Close();
                fill_dg();
                MessageBox.Show("Record deleted succefully", "User account control pannel", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1);

            }
            catch (NullReferenceException ex)
            {
                MessageBox.Show("Record deletion failed", "User account control pannel", MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1);
            }
           
        }

        private void textBox6_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox2_KeyPress(object sender, KeyPressEventArgs e)
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

        private void textBox3_KeyPress(object sender, KeyPressEventArgs e)
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
