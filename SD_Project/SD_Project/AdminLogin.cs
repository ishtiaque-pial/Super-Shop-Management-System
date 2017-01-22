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
namespace SD_Project
{
    public partial class AdminLogin : Form
    {
        public AdminLogin()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            SqlConnection cn = new SqlConnection(@"Data Source=192.168.0.105,1433;Initial Catalog=ProjectDB;Integrated Security=False;User ID=sa;Password=123456789;Connect Timeout=15;Encrypt=False;TrustServerCertificate=False");

            try
            {
                string owner = "Admin";
                SqlCommand cmd = new SqlCommand("select * from log_table where username = '" + textBox1.Text + "' and password = '" + textBox2.Text + "' and userinfo = '" + owner + "'", cn);
                cn.Open();
                SqlDataReader dr;
                dr = cmd.ExecuteReader();
                int count = 0;
                while (dr.Read())
                {
                    count = 1;

                }
                if (count == 1)
                {
                    this.Hide();
                    //Form2 fr = new Form2();
                    AdminPanel adpanel = new AdminPanel();
                    adpanel.ShowDialog();
                    this.Close();

                }
                else
                {
                    MessageBox.Show("USERNAME OR PASSWORD IS WRONG", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }

            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                cn.Close();
            }
        }
    }
}
