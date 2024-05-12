using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Property_Auction_Management_System
{
    public partial class Registration : Form
    {
        string ConnectionString = " Data Source=LAPTOP-1USDA8V1\\SQLEXPRESS;Initial Catalog=PropertyDb;Integrated Security=True";    
        public Registration()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            {
                if (textBox6.Text == "" || textBox7.Text == "")
                    MessageBox.Show("Please fill Mandatory fields");
                else if (textBox7.Text != textBox8.Text)
                    MessageBox.Show("password do not match");
                else
                {
                    using (SqlConnection sqlCon = new SqlConnection(ConnectionString))
                    {
                        sqlCon.Open();
                        SqlCommand sqlCmd = new SqlCommand("UsersAdd", sqlCon);
                        sqlCmd.CommandType = CommandType.StoredProcedure;
                        sqlCmd.Parameters.AddWithValue("@FirstName", textBox1.Text.Trim());
                        sqlCmd.Parameters.AddWithValue("@LastName", textBox2.Text.Trim());
                        sqlCmd.Parameters.AddWithValue("Address", textBox3.Text.Trim());
                        sqlCmd.Parameters.AddWithValue("Email", textBox4.Text.Trim());
                        sqlCmd.Parameters.AddWithValue("UserType", textBox5.Text.Trim());
                        sqlCmd.Parameters.AddWithValue("UserName", textBox6.Text.Trim());
                        sqlCmd.Parameters.AddWithValue("@Password", textBox7.Text.Trim());
                        sqlCmd.ExecuteNonQuery();
                        MessageBox.Show("Registration is Successful");
                        Clear();

                    }
                }


            }
            void Clear()
            {
                textBox1.Text = textBox2.Text = textBox3.Text = textBox4.Text = textBox5.Text = textBox6.Text = textBox7.Text = "";
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
        }

        private void Registration_Load(object sender, EventArgs e)
        {

        }
    }
}
