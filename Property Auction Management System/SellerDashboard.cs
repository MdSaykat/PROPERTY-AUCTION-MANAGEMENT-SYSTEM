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
    public partial class SellerDashboard : Form
    {
        string ConnectionString = " Data Source=LAPTOP-1USDA8V1\\SQLEXPRESS;Initial Catalog=PropertyDb;Integrated Security=True";
        public SellerDashboard()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            propertyDetails propertyDetails = new propertyDetails();
            propertyDetails.Show();
            this.Hide();    
        }

        private void button4_Click(object sender, EventArgs e)
        {
           Form1 exit = new Form1();  
            exit.Show();
            this.Hide();
        }

        private void button3_Click(object sender, EventArgs e)
        {

            using (SqlConnection sqlCon = new SqlConnection(ConnectionString))
            {
                sqlCon.Open();


                string query = "Select * from Comment";
                SqlCommand cmd = new SqlCommand(query, sqlCon);
                var reader = cmd.ExecuteReader();
                DataTable Property = new DataTable();
                Property.Load(reader);
                dataGridView2.DataSource = Property;
                sqlCon.Close();
            }
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

        private void SellerDashboard_Load(object sender, EventArgs e)
        {

        }
    }
}
