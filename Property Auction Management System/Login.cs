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
    public partial class Login : Form
    {
        string ConnectionString = " Data Source=LAPTOP-1USDA8V1\\SQLEXPRESS;Initial Catalog=PropertyDb;Integrated Security=True";
        public Login()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Registration registration = new Registration();
            registration.Show();
            this.Hide();
        }

        private void label4_Click(object sender, EventArgs e)
        {

        }

        private void button3_Click(object sender, EventArgs e)
        {
            Form1 form = new Form1();   
            form.Show();
            this.Hide();
        }

        private void button1_Click_1(object sender, EventArgs e)
        {

            SqlConnection sqlCon = new SqlConnection(ConnectionString);
            string check = "select count(*) from [User] where UserName = '" + textBox1.Text + "' and password = '" + textBox2.Text + "'";
            SqlCommand com = new SqlCommand(check, sqlCon);
            sqlCon.Open();
            int temp = Convert.ToInt32(com.ExecuteScalar().ToString());
            sqlCon.Close();
            if (temp == 1)
            {
                SellerDashboard sellerDashboard = new SellerDashboard();
                sellerDashboard.Show();
            }
        }

        private void label4_Click_1(object sender, EventArgs e)
        {

        }

        private void button2_Click_1(object sender, EventArgs e)
        {
            Registration registrations = new Registration();    
            registrations.Show();
        }

        private void Login_Load(object sender, EventArgs e)
        {

        }
    }
}
