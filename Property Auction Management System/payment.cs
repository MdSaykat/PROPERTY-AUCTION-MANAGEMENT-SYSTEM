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
    public partial class payment : Form
    {
        string ConnectionString = " Data Source=LAPTOP-1USDA8V1\\SQLEXPRESS;Initial Catalog=PropertyDb;Integrated Security=True";
        public payment()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            using (SqlConnection connection = new SqlConnection(ConnectionString))
            {
                string query = " INSERT INTO PaymentTable(UserID,PropertyId,PaymentAmount)\r\n\t VALUES(@UserID,@PropertyId,@PaymentAmount)UPDATE Property SET UserID=@UserID, Status = CASE WHEN @PaymentAmount = ISNULL(CurrentHighestBid, 0) THEN 'Sold' ELSE 'UnSold' END WHERE PropertyId = @PropertyId";
                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    connection.Open();
                    command.Parameters.AddWithValue("@UserID", textBox1.Text);
                    command.Parameters.AddWithValue("@PropertyId", textBox2.Text);
                    command.Parameters.AddWithValue("PaymentAmount", textBox3.Text);
                    MessageBox.Show("Add Payment is Successful");
                    command.ExecuteNonQuery();
                    connection.Close();
                }
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {

            using (SqlConnection sqlCon = new SqlConnection(ConnectionString))
            {
                sqlCon.Open();


                string query = "Select * from PaymentTable";
                SqlCommand cmd = new SqlCommand(query, sqlCon);
                var reader = cmd.ExecuteReader();
                DataTable payment = new DataTable();
                payment.Load(reader);
                dataGridView1.DataSource = payment;
                sqlCon.Close();
            }
        }

        private void label5_Click(object sender, EventArgs e)
        {

        }

        private void button3_Click(object sender, EventArgs e)
        {
            BuyerDashboard buyerDashboard = new BuyerDashboard();   
            buyerDashboard.Show();  
            this.Hide();
        }

        private void payment_Load(object sender, EventArgs e)
        {

        }
    }
}
