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
    public partial class BuyerDashboard : Form
    {
        string ConnectionString = " Data Source=LAPTOP-1USDA8V1\\SQLEXPRESS;Initial Catalog=PropertyDb;Integrated Security=True";
        public BuyerDashboard()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {
            using (SqlConnection sqlCon = new SqlConnection(ConnectionString))
            {
                sqlCon.Open();


                string query = "Select * from Property";
                SqlCommand cmd = new SqlCommand(query, sqlCon);
                var reader = cmd.ExecuteReader();
                DataTable Property = new DataTable();
                Property.Load(reader);
                dataGridView1.DataSource = Property;
                sqlCon.Close();
            }
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void button3_Click(object sender, EventArgs e)
        {
            BidProcess bids = new BidProcess();
            bids.Show();
            this.Hide();
        }

        private void button6_Click(object sender, EventArgs e)
        {
            payment Payment = new payment();    
            Payment.Show();
            this.Hide();    
        }

        private void button4_Click(object sender, EventArgs e)
        {
            Form1 exit = new Form1();  
            exit .Show();
            this.Hide();
        }

        private void button5_Click(object sender, EventArgs e)
        {
            comment Comment = new comment();        
            Comment.Show();
            this.Hide();
        }

        private void BuyerDashboard_Load(object sender, EventArgs e)
        {

        }
    }
}
