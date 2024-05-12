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
    public partial class comment : Form
    {
        string ConnectionString = " Data Source=LAPTOP-1USDA8V1\\SQLEXPRESS;Initial Catalog=PropertyDb;Integrated Security=True";
      
        public comment()
        {
            InitializeComponent();
        }

        private void label5_Click(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            using (SqlConnection sqlCon = new SqlConnection(ConnectionString))
            {
                sqlCon.Open();
                SqlCommand sqlCmd = new SqlCommand("AddComment", sqlCon);
                sqlCmd.CommandType = CommandType.StoredProcedure;
                sqlCmd.Parameters.AddWithValue("@UserID", textBox1.Text.Trim());
                sqlCmd.Parameters.AddWithValue("@PropertyId", textBox2.Text.Trim());
                sqlCmd.Parameters.AddWithValue("@Comment", textBox3.Text.Trim());
                sqlCmd.ExecuteNonQuery();
                MessageBox.Show("Add Comment is Successful");
                Clear();
            }
            void Clear()
            {
                textBox1.Text = textBox2.Text = textBox3.Text =  "";

            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            BuyerDashboard buyerDashboard = new BuyerDashboard();
            buyerDashboard.Show();
            this.Hide();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            using (SqlConnection sqlCon = new SqlConnection(ConnectionString))
            {
                sqlCon.Open();


                string query = "Select * from Comment";
                SqlCommand cmd = new SqlCommand(query, sqlCon);
                var reader = cmd.ExecuteReader();
                DataTable comment = new DataTable();
                comment.Load(reader);
                dataGridView1.DataSource =comment;
                sqlCon.Close();
            }
        }

        private void comment_Load(object sender, EventArgs e)
        {

        }
    }
}
