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
    public partial class propertyDetails : Form
    {
        string ConnectionString = " Data Source=LAPTOP-1USDA8V1\\SQLEXPRESS;Initial Catalog=PropertyDb;Integrated Security=True";
        public propertyDetails()
        {
            InitializeComponent();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            using (SqlConnection sqlCon = new SqlConnection(ConnectionString))
            {
                sqlCon.Open();
                string query = "UPDATE Property SET Property_address = @Property_address,Property_Type = @Property_Type,BasePrice = @BasePrice,StartDateTime = @StartDateTime,EndDateTime = @EndDateTime,CurrentHighestBid = @CurrentHighestBid WHERE PropertyID=@PropertyID";
                SqlCommand sqlCmd = new SqlCommand(query, sqlCon);
                sqlCmd.Parameters.AddWithValue("@Property_address", textBox2.Text);
                sqlCmd.Parameters.AddWithValue("@Property_Type", textBox3.Text);
                sqlCmd.Parameters.AddWithValue("@BasePrice", textBox4.Text);
                sqlCmd.Parameters.AddWithValue("@StartDateTime", textBox5.Text);
                sqlCmd.Parameters.AddWithValue("@EndDateTime", textBox6.Text);
                sqlCmd.Parameters.AddWithValue("@CurrentHighestBid", textBox7.Text);
                sqlCmd.Parameters.AddWithValue("@PropertyId", textBox1.Text);
                sqlCmd.ExecuteNonQuery();
                MessageBox.Show("Update is Successful");
                sqlCon.Close();
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            using (SqlConnection sqlCon = new SqlConnection(ConnectionString))
            {
                sqlCon.Open();
                SqlCommand sqlCmd = new SqlCommand("PropertyAdd", sqlCon);
                sqlCmd.CommandType = CommandType.StoredProcedure;
                sqlCmd.Parameters.AddWithValue("@PropertyId", textBox1.Text.Trim());
                sqlCmd.Parameters.AddWithValue("@Property_address", textBox2.Text.Trim());
                sqlCmd.Parameters.AddWithValue("@Property_Type", textBox3.Text.Trim());
                sqlCmd.Parameters.AddWithValue("@BasePrice", textBox4.Text.Trim());
                sqlCmd.Parameters.AddWithValue("@StartDateTime", textBox5.Text.Trim());
                sqlCmd.Parameters.AddWithValue("@EndDateTime", textBox6.Text.Trim());
                sqlCmd.Parameters.AddWithValue("@CurrentHighestBid", textBox7.Text.Trim());
                sqlCmd.ExecuteNonQuery();
                MessageBox.Show("Add Property is Successful");

                Clear();

            }
            void Clear()
            {
                textBox1.Text = textBox2.Text = textBox3.Text = textBox4.Text = textBox5.Text =textBox6.Text =textBox7.Text ="";

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

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void button4_Click(object sender, EventArgs e)
        {

            using (SqlConnection sqlCon = new SqlConnection(ConnectionString))
            {
                sqlCon.Open();
                string query = "DELETE FROM Property WHERE propertyID=@propertyID";
                SqlCommand sqlCmd = new SqlCommand(query, sqlCon);
                sqlCmd.Parameters.AddWithValue("@propertyId", textBox1.Text);
                sqlCmd.ExecuteNonQuery();
                MessageBox.Show("Delete Rows");
                sqlCon.Close();
            }
        }

        private void button5_Click(object sender, EventArgs e)
        {
            SellerDashboard sellerDashboards = new SellerDashboard();
            sellerDashboards.Show();
        }

        private void propertyDetails_Load(object sender, EventArgs e)
        {

        }
    }
}

