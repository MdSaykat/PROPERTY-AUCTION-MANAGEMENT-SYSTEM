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
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace Property_Auction_Management_System
{
    public partial class BidProcess : Form
    {
        string ConnectionString = " Data Source=LAPTOP-1USDA8V1\\SQLEXPRESS;Initial Catalog=PropertyDb;Integrated Security=True";
        public BidProcess()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            


                using (SqlConnection connection = new SqlConnection(ConnectionString))
                {
                    string query = "\r\n    INSERT INTO Bidtable (UserID,PropertyId,BidAmount)\r\n\tVALUES(@UserID,@PropertyId,@BidAmount) UPDATE Property SET UserID=@UserID, CurrentHighestBid = CASE WHEN @BidAmount > ISNULL(CurrentHighestBid, 0) THEN @BidAmount ELSE ISNULL(CurrentHighestBid, 0) END WHERE PropertyId = @PropertyId";

                    using (SqlCommand command = new SqlCommand(query, connection))
                {     
                    command.Parameters.AddWithValue("@UserID", textBox1.Text);

                    command.Parameters.AddWithValue("@PropertyId", textBox2.Text);
                    command.Parameters.AddWithValue("@BidAmount", textBox3.Text);

                        connection.Open();
                        command.ExecuteNonQuery();
                    }  
                }
            }

        private void button2_Click(object sender, EventArgs e)
        {
            using (SqlConnection sqlCon = new SqlConnection(ConnectionString))
            {
                sqlCon.Open();


                string query = "Select * from Bidtable";
                SqlCommand cmd = new SqlCommand(query, sqlCon);
                var reader = cmd.ExecuteReader();
                DataTable bidtable = new DataTable();
                bidtable.Load(reader);
                dataGridView1.DataSource = bidtable;
                sqlCon.Close();
            }
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void button3_Click(object sender, EventArgs e)
        {
            BuyerDashboard buyerDashboard = new BuyerDashboard();   
            buyerDashboard.Show();  
            this.Hide();
        }

        private void BidProcess_Load(object sender, EventArgs e)
        {

        }
    }
    }

    

