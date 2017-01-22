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
    public partial class change_ip : Form
    {
        string owner;
        public change_ip()
        {
            InitializeComponent();
        }

        private void ch_main_bt_Click(object sender, EventArgs e)
        {
            this.Hide();
            Form2 fo = new Form2();
            fo.ShowDialog();
            this.Close();
        }

        private void ch_admin_bt_Click(object sender, EventArgs e)
        {
            this.Hide();
            //admin ad2 = new admin();
            AdminPanel ad2 = new AdminPanel();
            ad2.ShowDialog();
            this.Close();

        }

        private void ch_exit_bt_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void change_bt_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(oldID.Text) || string.IsNullOrEmpty(old_pass.Text) || string.IsNullOrEmpty(new_ID.Text) || string.IsNullOrEmpty(new_pass.Text) || string.IsNullOrEmpty(rewrite_pass.Text))
            {
                MessageBox.Show("Fill All Box", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else
            {
                if (radioButton1.Checked == true)
                {
                    SqlConnection cn = new SqlConnection(@"Data Source=192.168.0.105,1433;Initial Catalog=ProjectDB;Integrated Security=False;User ID=sa;Password=123456789;Connect Timeout=15;Encrypt=False;TrustServerCertificate=False");

                    try
                    {
                        owner = "Admin";
                        SqlCommand cmd = new SqlCommand("select * from log_table where username = '" + oldID.Text + "' and password = '" + old_pass.Text + "' and userinfo = '" + owner + "'", cn);
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
                            cn.Close();
                            if (new_pass.Text == rewrite_pass.Text)
                            {
                                string update = "update log_table set username='" + new_ID.Text + "', password='" + new_pass.Text + "' where userinfo= '" + owner + "'";
                                SqlCommand upsql = new SqlCommand(update, cn);
                                cn.Open();
                                upsql.ExecuteNonQuery();
                                MessageBox.Show("Changed", "Message", MessageBoxButtons.OK, MessageBoxIcon.Information);
                                oldID.Text = "";
                                old_pass.Text = "";
                                new_ID.Text = "";
                                new_pass.Text = "";
                                rewrite_pass.Text = "";
                            }
                            else
                            {
                                MessageBox.Show("PASSWORD Doesn't Match", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                                new_pass.Text = "";
                                rewrite_pass.Text = "";
                            }

                        }
                        else
                        {
                            MessageBox.Show("USERNAME OR PASSWORD IS WRONG", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            old_pass.Text = "";
                            new_pass.Text = "";
                            rewrite_pass.Text = "";
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
                else
                {
                    SqlConnection cn = new SqlConnection(@"Data Source=192.168.0.105,1433;Initial Catalog=ProjectDB;Integrated Security=False;User ID=sa;Password=123456789;Connect Timeout=15;Encrypt=False;TrustServerCertificate=False");

                    try
                    {
                        owner = "Salesman";
                        SqlCommand cmd = new SqlCommand("select * from log_table where username = '" + oldID.Text + "' and password = '" + old_pass.Text + "' and userinfo = '" + owner + "'", cn);
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
                            cn.Close();
                            if (new_pass.Text == rewrite_pass.Text)
                            {
                                string update = "update log_table set username='" + new_ID.Text + "', password='" + new_pass.Text + "' where userinfo= '" + owner + "'";
                                SqlCommand upsql = new SqlCommand(update, cn);
                                cn.Open();
                                upsql.ExecuteNonQuery();
                                MessageBox.Show("Changed", "Message", MessageBoxButtons.OK, MessageBoxIcon.Information);
                                oldID.Text = "";
                                old_pass.Text = "";
                                new_ID.Text = "";
                                new_pass.Text = "";
                                rewrite_pass.Text = "";
                            }
                            else
                            {
                                MessageBox.Show("PASSWORD Doesn't Match", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                                
                                new_pass.Text = "";
                                rewrite_pass.Text = "";
                            }

                        }
                        else
                        {
                            MessageBox.Show("USERNAME OR PASSWORD IS WRONG", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            old_pass.Text = "";
                            new_pass.Text = "";
                            rewrite_pass.Text = "";
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
    }
}
