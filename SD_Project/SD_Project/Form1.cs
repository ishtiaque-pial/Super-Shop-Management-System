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
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

       

        private void log_button_Click(object sender, EventArgs e)
        {

            //SqlConnection cn = new SqlConnection(@"Data Source=PIAL-PC\SQLEXPRESS;Initial Catalog=ProjectDB;Integrated Security=True;Connect Timeout=15;Encrypt=False;TrustServerCertificate=False");
            SqlConnection cn = new SqlConnection(@"Data Source=192.168.0.105,1433;Initial Catalog=ProjectDB;Integrated Security=False;User ID=sa;Password=123456789;Connect Timeout=15;Encrypt=False;TrustServerCertificate=False");

            try
            {
                string owner="Salesman";
                SqlCommand cmd = new SqlCommand("select * from log_table where username = '" + userbox.Text + "' and password = '" + passbox.Text + "' and userinfo = '" + owner + "'", cn);
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
                    Form2 fr = new Form2();
                    fr.ShowDialog();
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
