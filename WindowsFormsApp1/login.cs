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
using CrystalDecisions.Shared.Json;

namespace WindowsFormsApp1
{
    public partial class login : Form
    {
        SqlConnection con = new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\Users\rahulan\Desktop\off_Project\WindowsFormsApp1\Database1.mdf;Integrated Security=True");
        
        public login()
        {
            InitializeComponent();
        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void login_Load(object sender, EventArgs e)
        {

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void button3_Click(object sender, EventArgs e)
        {
            
            if (textBox1.Text==""|| textBox2.Text=="" || comboBox1.SelectedItem.ToString() == ""  )
            {
                MessageBox.Show("Fill the username or password", "User account control pannel", MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1);
            }
            else
            {
                SqlCommand cmd = con.CreateCommand();
                cmd.CommandText = ("select * from login where username = '" + textBox1.Text + "' and password = '" + textBox2.Text + "'");

                SqlDataAdapter da = new SqlDataAdapter(cmd);
                DataTable dt = new DataTable();
                da.Fill(dt);
                string cmbValue = comboBox1.SelectedItem.ToString();

                if (dt.Rows.Count > 0)
                {
                    for (int i = 0; i < dt.Rows.Count; i++)
                    {
                        if (dt.Rows[i]["usertype"].ToString() == cmbValue)
                        {
                            MessageBox.Show("You are login as a " + dt.Rows[i]["usertype"], "User account control pannel", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1);
                            if (comboBox1.SelectedIndex == 0)
                            {
                                adminDashboard ad = new adminDashboard();
                                ad.Show();
                                this.Hide();
                            }
                            else
                            {
                                Dashboard db = new Dashboard();
                                db.Show();
                                this.Hide();
                            }
                        }
                        if (dt.Rows[i]["usertype"].ToString() != cmbValue)
                        {
                            MessageBox.Show("Wrong credentials", "User account control pannel", MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1);
                        }
                    }
                }
                else
                {
                    MessageBox.Show("Wrong username or password", "User account control pannel", MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1);
                }
            }
            
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Maximized;
        }

        private void textBox1_Enter(object sender, EventArgs e)
        {
            textBox1.Text = "";
        }

        private void textBox2_Enter(object sender, EventArgs e)
        {
            textBox2.Text = "";
        }

        private void textBox1_Leave(object sender, EventArgs e)
        {
            if (textBox1.Text == "")
            {
                textBox1.Text = "Username";
            }
        }

        private void textBox2_Leave(object sender, EventArgs e)
        {
            if (textBox2.Text == "")
            {
                textBox2.Text = "Password";
            }
        }

        private void comboBox1_Leave(object sender, EventArgs e)
        {
            if (comboBox1.Text == "")
            {
                comboBox1.Text = "User Type";
            }
        }

        private void comboBox1_Enter(object sender, EventArgs e)
        {
            comboBox1.Text = "";
        }

        private void button3_Enter(object sender, EventArgs e)
        {
           /* SqlCommand cmd = con.CreateCommand();
            cmd.CommandText = ("select * from login where username = '" + textBox1.Text + "' and password = '" + textBox2.Text + "'");

            SqlDataAdapter da = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            da.Fill(dt);
            string cmbValue = comboBox1.SelectedItem.ToString();

            if (dt.Rows.Count > 0)
            {
                for (int i = 0; i < dt.Rows.Count; i++)
                {
                    if (dt.Rows[i]["usertype"].ToString() == cmbValue)
                    {
                        MessageBox.Show("you are login as a " + dt.Rows[i]["usertype"], "User account control pannel", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1);
                        if (comboBox1.SelectedIndex == 0)
                        {
                            adminDashboard ad = new adminDashboard();
                            ad.Show();
                            this.Hide();
                        }
                        else
                        {
                            Dashboard db = new Dashboard();
                            db.Show();
                            this.Hide();
                        }
                    }
                    if (dt.Rows[i]["usertype"].ToString() != cmbValue)
                    {
                        MessageBox.Show("Wrong credentials", "User account control pannel",MessageBoxButtons.OK,MessageBoxIcon.Error,MessageBoxDefaultButton.Button1);
                    }
                }
            }
            else
            {
                MessageBox.Show("Wrong username or password", "User account control pannel", MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1);
            }*/
        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {

        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {

        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
    }
}
