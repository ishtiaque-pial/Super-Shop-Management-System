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
    public partial class stock_info : Form
    {
        public stock_info()
        {
            InitializeComponent();
        }

        void st()
        {
            SqlConnection cn = new SqlConnection(@"Data Source=192.168.0.105,1433;Initial Catalog=ProjectDB;Integrated Security=False;User ID=sa;Password=123456789;Connect Timeout=15;Encrypt=False;TrustServerCertificate=False");
            try
            {
                cn.Close();
                //SqlCommand hmm = new SqlCommand("select * from product_table where quantity<5", cn);
                SqlCommand hmm = new SqlCommand("select * from product_table", cn);
                cn.Open();
                SqlDataReader dr;
                dr = hmm.ExecuteReader();
                int count = 0;
                while (dr.Read())
                {
                    count = 1;


                }
                dr.Close();
                if (count == 1)
                {
                    SqlDataAdapter sdaa = new SqlDataAdapter();
                    sdaa.SelectCommand = hmm;
                    DataTable dbdatatablee = new DataTable();
                    sdaa.Fill(dbdatatablee);

                    BindingSource bsourcee = new BindingSource();

                    bsourcee.DataSource = dbdatatablee;
                    dataGridView1.DataSource = bsourcee;
                    sdaa.Update(dbdatatablee);
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
        void stock()
        {
            SqlConnection cn = new SqlConnection(@"Data Source=192.168.0.105,1433;Initial Catalog=ProjectDB;Integrated Security=False;User ID=sa;Password=123456789;Connect Timeout=15;Encrypt=False;TrustServerCertificate=False");
            try
            {
                cn.Close();
                //SqlCommand hmm = new SqlCommand("select * from product_table where quantity<5", cn);
                SqlCommand hmm = new SqlCommand("select * from product_table where quantity<5", cn);
                cn.Open();
                SqlDataReader dr;
                dr = hmm.ExecuteReader();
                int count = 0;
                while (dr.Read())
                {
                    count = 1;


                }
               dr.Close();
                if (count == 1)
                {
                    SqlDataAdapter sdaa = new SqlDataAdapter();
                    sdaa.SelectCommand = hmm;
                    DataTable dbdatatablee = new DataTable();
                    sdaa.Fill(dbdatatablee);

                    BindingSource bsourcee = new BindingSource();

                    bsourcee.DataSource = dbdatatablee;
                    dataGridView1.DataSource = bsourcee;
                    sdaa.Update(dbdatatablee);
                }
                else
                {
                    SqlDataAdapter sdaa = new SqlDataAdapter();
                    sdaa.SelectCommand = hmm;
                    DataTable dbdatatablee = new DataTable();
                    sdaa.Fill(dbdatatablee);

                    BindingSource bsourcee = new BindingSource();

                    bsourcee.DataSource = dbdatatablee;
                    dataGridView1.DataSource = bsourcee;
                    sdaa.Update(dbdatatablee);
                    MessageBox.Show("All Products Have Full of Stock", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                cn.Close();
            }
        }
        private void button1_Click(object sender, EventArgs e)
        {
            this.Hide();
            AdminPanel asd = new AdminPanel();
            asd.ShowDialog();
            this.Close();

        }

        private void stock_info_Load(object sender, EventArgs e)
        {
            //stock();
            st();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            stock();
        }
    }
}
