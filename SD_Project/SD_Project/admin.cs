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
    public partial class admin : Form
    {
        int i = 0;
        int j = 0;
        public admin()
        {
            InitializeComponent();
            
        }

       


        private void product_id_KeyPress(object sender, KeyPressEventArgs e) //PRODUCT ID TEXTBOX
        {
            if (e.KeyChar < '0' || e.KeyChar > '9')
            {
                if (e.KeyChar != (char)8)
                {
                    MessageBox.Show("Please Enter only Number value", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    e.KeyChar = (char)0;
                }
            }
        }

        private void product_price_KeyPress(object sender, KeyPressEventArgs e) //PRODUCT PRICE TEXTBOX
        {
            if (e.KeyChar < '0' || e.KeyChar > '9')
            {

                if (e.KeyChar == (char)46 && i == 0)
                {
                    i++;

                }
                else if (e.KeyChar == (char)8)
                {

                }
                else
                {
                    if (e.KeyChar == (char)46)
                    {
                        MessageBox.Show("you use . once", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        e.KeyChar = (char)0;
                    }
                    else
                    {
                        MessageBox.Show("Please Enter only Number value", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        e.KeyChar = (char)0;
                    }
                }



            }
        }

        private void product_quantity_KeyPress(object sender, KeyPressEventArgs e) // PRODUCT QUANTITY TEXTBOX
        {
            if (e.KeyChar < '0' || e.KeyChar > '9')
            {

                if (e.KeyChar == (char)46 && j == 0)
                {
                    j++;

                }
                else if (e.KeyChar == (char)8)
                {

                }
                else
                {
                    if (e.KeyChar == (char)46)
                    {
                        MessageBox.Show("you use . once", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        e.KeyChar = (char)0;
                    }
                    else
                    {
                        MessageBox.Show("Please Enter only Number value", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        e.KeyChar = (char)0;
                    }
                }
            }
        }

        private void member_number_KeyPress(object sender, KeyPressEventArgs e) //MEMBER CARD ID TEXTBOX
        {
            if (e.KeyChar < '0' || e.KeyChar > '9')
            {
                if (e.KeyChar != (char)8)
                {
                    MessageBox.Show("Please Enter only Number value", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    e.KeyChar = (char)0;
                }
            }
        }

        private void member_dis_KeyPress(object sender, KeyPressEventArgs e) //MEMBER DISCOUNT TEXTBOX
        {
            if (e.KeyChar < '0' || e.KeyChar > '9')
            {
                if (e.KeyChar != (char)8)
                {
                    MessageBox.Show("Please Enter only Number value", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    e.KeyChar = (char)0;
                }
            }
        }

        private void combo_pro_name_SelectedIndexChanged(object sender, EventArgs e) //PRODUCT COMBOBOX FUNCTION
        {
            combo_pro_name.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDown;
            combo_pro_name.AutoCompleteMode = AutoCompleteMode.SuggestAppend;
            combo_pro_name.AutoCompleteSource = AutoCompleteSource.ListItems;
            //SqlConnection cn = new SqlConnection(@"Data Source=192.168.0.105,1433;Initial Catalog=ProjectDB;Integrated Security=False;User ID=sa;Password=123456789;Connect Timeout=15;Encrypt=False;TrustServerCertificate=False");
            SqlConnection cn = new SqlConnection(@"Data Source=192.168.0.105,1433;Initial Catalog=ProjectDB;Integrated Security=False;User ID=sa;Password=123456789;Connect Timeout=15;Encrypt=False;TrustServerCertificate=False");
            try
            {
                object h = combo_pro_name.SelectedItem;
                string pro_name = h.ToString();
                SqlCommand hy = new SqlCommand("select * from product_table where productName = '" + pro_name + "'", cn);
                cn.Open();
                SqlDataReader ds;
                ds = hy.ExecuteReader();

                if (ds.Read())
                {

                    product_id.Text = ds["productID"].ToString();

                    ds.Close();


                }
                else
                {

                }

            }

            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                cn.Close();
                combo_pro_name.Visible = false;
                product_name.Visible = true;
            }
        }

       

        private void main_page_bt_Click(object sender, EventArgs e) //MAIN PAGE BUTTON
        {
            this.Hide();
            Form2 fr = new Form2();
            fr.ShowDialog();
            this.Close();
        }

        private void admin_exit_Click(object sender, EventArgs e) //EXIT BUTTON
        {
            this.Close();
        }

        private void productInsert_Click(object sender, EventArgs e) //PRODUCT INSERT BUTTON
        {
            
            if(string.IsNullOrEmpty(product_id.Text)||string.IsNullOrEmpty(product_name.Text)||string.IsNullOrEmpty(product_price.Text)||string.IsNullOrEmpty(product_quantity.Text)||comboBox1.SelectedItem==null)
            {

                MessageBox.Show("All the fields are not filled", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            
            else
            {

                SqlConnection cn = new SqlConnection(@"Data Source=192.168.0.105,1433;Initial Catalog=ProjectDB;Integrated Security=False;User ID=sa;Password=123456789;Connect Timeout=15;Encrypt=False;TrustServerCertificate=False");
                
                try
                   {
                       SqlCommand ct = new SqlCommand("select * from product_table where productID = '" + product_id.Text + "'", cn);
                       
                       cn.Open(); //product id cheaking
                       
                       SqlDataReader dn;
                       dn = ct.ExecuteReader();


                       if (dn.Read())
                       {

                           MessageBox.Show("Product ID or Name Already Exsit", "Message", MessageBoxButtons.OK, MessageBoxIcon.Error);
                       }
                       else
                       {
                           cn.Close();
                           SqlCommand cu = new SqlCommand("select * from product_table where productName = '" + product_name.Text + "'", cn);
                           cn.Open(); //product name cheaking
                           SqlDataReader du;
                           du = cu.ExecuteReader();

                           if (du.Read())
                           {
                               MessageBox.Show("Product Name Already Exsit", "Message", MessageBoxButtons.OK, MessageBoxIcon.Error);
                           }

                           else
                           {
                               cn.Close();
                               object y = comboBox1.SelectedItem;
                               string productUnit = y.ToString();
                               string sqll = "INSERT INTO product_table (productID,productName,price,quantity,unit) values('" + product_id.Text + "','" + product_name.Text + "','" + product_price.Text + "','" + product_quantity.Text + "','" + productUnit + "')";
                               SqlCommand exesqll = new SqlCommand(sqll, cn);
                               cn.Open(); //product insert
                               exesqll.ExecuteNonQuery();
                               MessageBox.Show("Add New Record Done!!!", "Message", MessageBoxButtons.OK, MessageBoxIcon.Information);

                               product_id.Text = "";
                               product_name.Text = "";
                               product_price.Text = "";
                               product_quantity.Text = "";
                               comboBox1.Text = "";
                           }
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

        private void productShow_Click(object sender, EventArgs e) //PRODUCT SHOW BUTTON
        {
            if (string.IsNullOrEmpty(product_id.Text))
            {
                MessageBox.Show("Product ID is not filled", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else
            {
                SqlConnection cn = new SqlConnection(@"Data Source=192.168.0.105,1433;Initial Catalog=ProjectDB;Integrated Security=False;User ID=sa;Password=123456789;Connect Timeout=15;Encrypt=False;TrustServerCertificate=False");
                try
                {

                    SqlCommand hm = new SqlCommand("select * from product_table where productID = '" + product_id.Text + "'", cn);
                    cn.Open();
                    SqlDataReader dt;
                    dt = hm.ExecuteReader();

                    if (dt.Read())
                    {
                        product_name.Text = dt["productName"].ToString();
                        product_price.Text = dt["price"].ToString();
                        product_quantity.Text = dt["quantity"].ToString();
                       // quantity_show.Visible = true;
                       
                        comboBox1.SelectedText = dt["unit"].ToString();
                        

                        dt.Close();
                       
                        
                    }
                    else
                    {
                        MessageBox.Show("Not Found!!!", "Message", MessageBoxButtons.OK, MessageBoxIcon.Information);
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

        private void product_delete_Click(object sender, EventArgs e) // PRODUCT DELETE BUTTON
        {
            if(string.IsNullOrEmpty(product_id.Text))
            {
                MessageBox.Show("Product ID is not filled", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else
            {
                SqlConnection cn = new SqlConnection(@"Data Source=192.168.0.105,1433;Initial Catalog=ProjectDB;Integrated Security=False;User ID=sa;Password=123456789;Connect Timeout=15;Encrypt=False;TrustServerCertificate=False");
                try
                {
                    SqlCommand ch = new SqlCommand("select * from product_table where productID = '" + product_id.Text + "'", cn);
                    cn.Open(); //product id cheaking 
                    SqlDataReader dw;
                    dw = ch.ExecuteReader();

                    if (dw.Read())
                    {
                        cn.Close();
                        string delete = "delete from product_table where productID= '" + product_id.Text + "'";
                        SqlCommand delsql = new SqlCommand(delete, cn);
                        cn.Open();
                        delsql.ExecuteNonQuery();

                        MessageBox.Show("One Product Deleted", "Message", MessageBoxButtons.OK, MessageBoxIcon.Information);

                        product_id.Text = "";

                    }

                    else
                    {
                        MessageBox.Show("Product ID Does Not Exsit", "Message", MessageBoxButtons.OK, MessageBoxIcon.Error);
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

        private void product_update_Click(object sender, EventArgs e) //PRODUCT UPDATE BUTTON
        {
            if (string.IsNullOrEmpty(product_id.Text) || string.IsNullOrEmpty(product_name.Text) || string.IsNullOrEmpty(product_price.Text) || string.IsNullOrEmpty(product_quantity.Text) || comboBox1.SelectedItem == null)
            {
                MessageBox.Show("All the fields are not filled", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

            else
            {
                SqlConnection cn = new SqlConnection(@"Data Source=192.168.0.105,1433;Initial Catalog=ProjectDB;Integrated Security=False;User ID=sa;Password=123456789;Connect Timeout=15;Encrypt=False;TrustServerCertificate=False");
                try
                {
                    SqlCommand co = new SqlCommand("select * from product_table where productID = '" + product_id.Text + "'", cn);
                    cn.Open(); //product id cheaking
                    SqlDataReader di;
                    di = co.ExecuteReader();

                    if (di.Read()) 
                    {
                        cn.Close();
                        object m = comboBox1.SelectedItem;
                        string productUnit2 = m.ToString();
                        string update = "update product_table set productName='" + product_name.Text + "', price='" + product_price.Text + "',quantity='"+product_quantity.Text+"', unit='"+productUnit2+"' where productID= '" + product_id.Text + "'";
                        SqlCommand upsql = new SqlCommand(update, cn);
                        cn.Open();
                        upsql.ExecuteNonQuery();
                        MessageBox.Show("Updated", "Message", MessageBoxButtons.OK, MessageBoxIcon.Information);

                        product_id.Text = "";
                        product_name.Text = "";
                        product_price.Text = "";
                        product_quantity.Text = "";
                        comboBox1.Text = "";
                    }

                    else
                    {
                        MessageBox.Show("Product ID Does Not Exsit", "Message", MessageBoxButtons.OK, MessageBoxIcon.Error);
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

        private void product_clear_Click(object sender, EventArgs e) //PRODUCT CLEAR BUTTON
        {
            product_id.Text = "";
            product_name.Text = "";
            product_price.Text = "";
            product_quantity.Text = "";
            comboBox1.Text = "";
            product_name.Visible = true;
            combo_pro_name.Visible = false;

            i = 0;
            j = 0;
        }

        

        private void forget_id_Click(object sender, EventArgs e) //PRODUCT FORGET ID BUTTON
        {
            combo_pro_name.Visible = true;
            product_name.Visible = false;
            combo_pro_name.Text = "Here Select Product Name";


            SqlConnection cn = new SqlConnection(@"Data Source=192.168.0.105,1433;Initial Catalog=ProjectDB;Integrated Security=False;User ID=sa;Password=123456789;Connect Timeout=15;Encrypt=False;TrustServerCertificate=False");
            try
            {
                combo_pro_name.Items.Clear();
                SqlCommand hm = new SqlCommand("select * from product_table ORDER BY productName", cn);
                cn.Open();
                SqlDataReader dt;
                dt = hm.ExecuteReader();

                while (dt.Read())
                {
                    string name = dt["productName"].ToString();
                    combo_pro_name.Items.Add(name);
                    
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

        private void member_insert_Click(object sender, EventArgs e)
        {
            if(string.IsNullOrEmpty(member_number.Text)|| string.IsNullOrEmpty(member_name.Text)||string.IsNullOrEmpty(member_add.Text)||string.IsNullOrEmpty(member_dis.Text))
            {
                MessageBox.Show("All the fields are not filled", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else
            {
                SqlConnection cn = new SqlConnection(@"Data Source=192.168.0.105,1433;Initial Catalog=ProjectDB;Integrated Security=False;User ID=sa;Password=123456789;Connect Timeout=15;Encrypt=False;TrustServerCertificate=False");

                try
                {
                    SqlCommand memcmd1 = new SqlCommand("select * from member_table where memberID = '" + member_number.Text + "'", cn);

                    cn.Open(); //product id cheaking

                    SqlDataReader memdatareader1;
                    memdatareader1 = memcmd1.ExecuteReader();


                    if (memdatareader1.Read())
                    {

                        MessageBox.Show("Product ID Already Exsit", "Message", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                    else
                    {
                        cn.Close();
                        
                        string memsql1 = "INSERT INTO member_table (memberID,memberName,memberAddress,memberDiscount) values('" + member_number.Text + "','" + member_name.Text + "','" + member_add.Text + "','" + member_dis.Text + "')";
                        SqlCommand memcmdinsert = new SqlCommand(memsql1, cn);
                        cn.Open(); //product insert
                        memcmdinsert.ExecuteNonQuery();
                        MessageBox.Show("Add New Record Done!!!", "Message", MessageBoxButtons.OK, MessageBoxIcon.Information);

                        member_number.Text = "";
                        member_name.Text = "";
                        member_add.Text = "";
                        member_dis.Text = "";
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

        private void nember_name_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(member_number.Text))
            {
                MessageBox.Show("Card Number is not filled", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else
            {
                SqlConnection cn = new SqlConnection(@"Data Source=192.168.0.105,1433;Initial Catalog=ProjectDB;Integrated Security=False;User ID=sa;Password=123456789;Connect Timeout=15;Encrypt=False;TrustServerCertificate=False");
                try
                {

                    SqlCommand memcmdshow = new SqlCommand("select * from member_table where memberID = '" + member_number.Text + "'", cn);
                    cn.Open();
                    SqlDataReader memdatareadershow;
                    memdatareadershow = memcmdshow.ExecuteReader();

                    if (memdatareadershow.Read())
                    {
                        member_name.Text = memdatareadershow["memberName"].ToString();
                        member_add.Text = memdatareadershow["memberAddress"].ToString();
                        member_dis.Text = memdatareadershow["memberDiscount"].ToString();

                        memdatareadershow.Close();
                    }
                    else
                    {
                        MessageBox.Show("Not Found!!!", "Message", MessageBoxButtons.OK, MessageBoxIcon.Information);
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

        private void member_update_bt_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(member_number.Text) || string.IsNullOrEmpty(member_name.Text) || string.IsNullOrEmpty(member_add.Text) || string.IsNullOrEmpty(member_dis.Text))
            {
                MessageBox.Show("All the fields are not filled", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

            else
            {
                SqlConnection cn = new SqlConnection(@"Data Source=192.168.0.105,1433;Initial Catalog=ProjectDB;Integrated Security=False;User ID=sa;Password=123456789;Connect Timeout=15;Encrypt=False;TrustServerCertificate=False");
                try
                {
                    SqlCommand memcmd3 = new SqlCommand("select * from member_table where memberID = '" + member_number.Text + "'", cn);
                    cn.Open();
                    SqlDataReader memdatareader3;
                    memdatareader3 = memcmd3.ExecuteReader();

                    if (memdatareader3.Read())
                    {
                        cn.Close();
                        string memsqlupdate = "update member_table set memberName='" + member_name.Text + "', memberAddress='" + member_add.Text + "',memberDiscount='" + member_dis.Text + "' where memberID= '" + member_number.Text + "'";
                        SqlCommand memcmdupdate = new SqlCommand(memsqlupdate, cn);
                        cn.Open();
                        memcmdupdate.ExecuteNonQuery();
                        MessageBox.Show("Updated", "Message", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        
                        member_number.Text = "";
                        member_name.Text = "";
                        member_add.Text = "";
                        member_dis.Text = "";
                    }

                    else
                    {
                        MessageBox.Show("Card Number Does Not Exsit", "Message", MessageBoxButtons.OK, MessageBoxIcon.Error);
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

        private void member_delete_bt_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(member_number.Text))
            {
                MessageBox.Show("Card Number is not filled", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else
            {
                SqlConnection cn = new SqlConnection(@"Data Source=192.168.0.105,1433;Initial Catalog=ProjectDB;Integrated Security=False;User ID=sa;Password=123456789;Connect Timeout=15;Encrypt=False;TrustServerCertificate=False");
                try
                {
                    SqlCommand memcmd4 = new SqlCommand("select * from member_table where memberID = '" + member_number.Text + "'", cn);
                    cn.Open(); 
                    SqlDataReader memdatareader4;
                    memdatareader4 = memcmd4.ExecuteReader();

                    if (memdatareader4.Read())
                    {
                        cn.Close();
                        string memsqldelete = "delete from member_table where memberID= '" + member_number.Text + "'";
                        SqlCommand memcmddelete = new SqlCommand(memsqldelete, cn);
                        cn.Open();
                        memcmddelete.ExecuteNonQuery();

                        MessageBox.Show("One Member Information Deleted", "Message", MessageBoxButtons.OK, MessageBoxIcon.Information);

                        member_number.Text = "";
                        member_name.Text = "";
                        member_add.Text = "";
                        member_dis.Text = "";

                    }

                    else
                    {
                        MessageBox.Show("Card Number Does Not Exsit", "Message", MessageBoxButtons.OK, MessageBoxIcon.Error);
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

        private void member_clear_Click(object sender, EventArgs e)
        {
            member_number.Text = "";
            member_name.Text = "";
            member_add.Text = "";
            member_dis.Text = "";
        }

        private void com_mem_name_SelectedIndexChanged(object sender, EventArgs e)
        {
            com_mem_name.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDown;
            com_mem_name.AutoCompleteMode = AutoCompleteMode.SuggestAppend;
            com_mem_name.AutoCompleteSource = AutoCompleteSource.ListItems;

            SqlConnection cn = new SqlConnection(@"Data Source=192.168.0.105,1433;Initial Catalog=ProjectDB;Integrated Security=False;User ID=sa;Password=123456789;Connect Timeout=15;Encrypt=False;TrustServerCertificate=False");
            try
            {
                object u = com_mem_name.SelectedItem;
                string mem_name = u.ToString();
                SqlCommand memcmdcombo = new SqlCommand("select * from member_table where memberName = '" + mem_name + "'", cn);
                cn.Open();
                SqlDataReader memdatareadercombo;
                memdatareadercombo = memcmdcombo.ExecuteReader();

                if (memdatareadercombo.Read())
                {

                    member_number.Text = memdatareadercombo["memberID"].ToString();

                    memdatareadercombo.Close();


                }
                else
                {

                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                cn.Close();
                com_mem_name.Visible = false;
                member_name.Visible = true;
            }
        }

        private void forget_card_id_Click(object sender, EventArgs e)
        {
            com_mem_name.Visible = true;
            member_name.Visible = false;
            com_mem_name.Text = "Here Select Member Name";


            SqlConnection cn = new SqlConnection(@"Data Source=192.168.0.105,1433;Initial Catalog=ProjectDB;Integrated Security=False;User ID=sa;Password=123456789;Connect Timeout=15;Encrypt=False;TrustServerCertificate=False");
            try
            {
                com_mem_name.Items.Clear();
                SqlCommand memforcmdcombo = new SqlCommand("select * from member_table ORDER BY memberName", cn);
                cn.Open();
                SqlDataReader memfordatareadercombo;
                memfordatareadercombo = memforcmdcombo.ExecuteReader();

                while (memfordatareadercombo.Read())
                {
                    string mem_name = memfordatareadercombo["memberName"].ToString();
                    com_mem_name.Items.Add(mem_name);

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

        private void button1_Click(object sender, EventArgs e)
        {
            this.Hide();
            AdminPanel adp = new AdminPanel();
            adp.ShowDialog();
            this.Close();
        }

        

    }
}
