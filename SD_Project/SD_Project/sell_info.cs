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
    public partial class sell_info : Form
    {
        int counter;
        double sum;
        string row1, row2, row3, row4, row5, row6, row7;
        public sell_info()
        {
            InitializeComponent();
            
        }

        void sell()
        {
            SqlConnection cn = new SqlConnection(@"Data Source=192.168.0.105,1433;Initial Catalog=ProjectDB;Integrated Security=False;User ID=sa;Password=123456789;Connect Timeout=15;Encrypt=False;TrustServerCertificate=False");
            try
            {
                SqlCommand hm = new SqlCommand("select count(*) as cou from selling_table", cn);
                cn.Open();
                SqlDataReader dt;
                dt = hm.ExecuteReader();

                if (dt.Read())
                {
                    string ab = dt["cou"].ToString();
                    counter =1000+ Convert.ToInt32(ab.ToString());
                    dt.Close();


                }
               

            }
            catch(Exception exx)
            {
                MessageBox.Show(exx.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                cn.Close();
               
            }

            for (int i = 1001; i <= counter; i++)
            {
                try
                {

                    SqlCommand hmm = new SqlCommand("select * from selling_table where InvoiceId='"+i+"'", cn);
                    cn.Open();
                   /* SqlDataAdapter sdaa = new SqlDataAdapter();
                    sdaa.SelectCommand = hmm;
                    DataTable dbdatatablee = new DataTable();
                    sdaa.Fill(dbdatatablee);

                    BindingSource bsourcee = new BindingSource();

                    bsourcee.DataSource = dbdatatablee;
                    dataGridView1.DataSource = bsourcee;
                    sdaa.Update(dbdatatablee);*/

                    
                    SqlDataReader dt;
                    dt = hmm.ExecuteReader();

                    if (dt.Read())
                    {
                        row1 = dt["InvoiceId"].ToString();
                        row2 = dt["WithOutVat"].ToString();
                        row3 = dt["Vat"].ToString();
                        row4 = dt["WithVat"].ToString();
                        row5 = dt["MemberName"].ToString();
                        row6 = dt["Discount"].ToString();
                        row7 = dt["Total"].ToString();
                        string[] row = { row1,row2,row3,row4,row5,row6,row7 };
                        dataGridView1.Rows.Add(row);
                        
                        dt.Close();


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
            sum = 0;
            for (int i = 0; i < dataGridView1.Rows.Count; i++)
            {
                sum = sum + Convert.ToDouble(dataGridView1.Rows[i].Cells[6].Value);

            }
            lab.Text = sum.ToString()+" Taka Only";
        }

        private void sell_info_Load(object sender, EventArgs e)
        {
            sell();
            
            
            
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (comboBox1.SelectedItem==null || comboBox2.SelectedItem == null || comboBox3.SelectedItem == null)
            {
                MessageBox.Show("Plese Select Date", "Error", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
            {
                sum = 0;
                dataGridView1.Visible = false;
                dataGridView2.Visible = true;
                SqlConnection cn = new SqlConnection(@"Data Source=192.168.0.105,1433;Initial Catalog=ProjectDB;Integrated Security=False;User ID=sa;Password=123456789;Connect Timeout=15;Encrypt=False;TrustServerCertificate=False");
                try
                {
                    SqlCommand hmm;
                    if (comboBox1.SelectedText == "ALL")
                    {
                        object ob1 = comboBox2.SelectedItem;
                        string month = ob1.ToString();

                        object ob2 = comboBox3.SelectedItem;
                        string year = ob2.ToString();

                        hmm = new SqlCommand("select InvoiceId,WithOutVat,Vat,WithVat,MemberName,Discount,Total from selling_table where Month='" + month + "'and Year='" + year + "'", cn);
                    }
                    else if (comboBox2.SelectedText == "ALL")
                    {
                        object ob1 = comboBox1.SelectedItem;
                        string day = ob1.ToString();

                        object ob2 = comboBox3.SelectedItem;
                        string year = ob2.ToString();

                        hmm = new SqlCommand("select InvoiceId,WithOutVat,Vat,WithVat,MemberName,Discount,Total from selling_table where Day='" + day + "'and Year='" + year + "'", cn);

                    }
                    else
                    {
                        object ob1 = comboBox1.SelectedItem;
                        string day = ob1.ToString();

                        object ob2 = comboBox2.SelectedItem;
                        string month = ob2.ToString();

                        object ob3 = comboBox3.SelectedItem;
                        string year = ob3.ToString();
                        hmm = new SqlCommand("select InvoiceId,WithOutVat,Vat,WithVat,MemberName,Discount,Total from selling_table where Day='" + day + "'and Month='" + month + "'and Year='" + year + "'", cn);
                    }
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
                        dataGridView2.DataSource = bsourcee;
                        sdaa.Update(dbdatatablee);
                    }
                    else
                    {
                        MessageBox.Show("Not Found", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                finally
                {
                    cn.Close();
                }

                for (int i = 0; i < dataGridView2.Rows.Count; i++)
                {
                    sum = sum + Convert.ToDouble(dataGridView2.Rows[i].Cells[6].Value);

                }
                lab.Text = sum.ToString() + " Taka Only";
            }
           
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            MessageBox.Show(dataGridView1.Rows[e.RowIndex].Cells[e.ColumnIndex].Value.ToString());
        }

        private void button2_Click(object sender, EventArgs e)
        {
            dataGridView2.Visible = false;
            dataGridView1.Visible = true;
            dataGridView1.Rows.Clear();
            dataGridView1.Refresh();
            sell();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            this.Hide();
            AdminPanel ad = new AdminPanel();
            ad.ShowDialog();
            this.Close();
        }
    }
}
