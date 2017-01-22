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
using System.Globalization;

namespace SD_Project
{
    public partial class mainpage : Form
    {

        string productUnitt, quntityCheak,unitCheak,row1,row2,row3,row4,row5,row6,taka;
        double totalprice = 0, tempprice,g,y,bg;
        double perdis, disprice, pvat;
        int q = 0, s = 0;
        string[] a;
        
        double sum = 0;
        public mainpage()
        {
            InitializeComponent();
            combo_product();
            invoice();
            dis();
        }
        void dis()
        {
            card_dis_tx.Text = "0";
        }

        void invoice()
        {
            SqlConnection cn = new SqlConnection(@"Data Source=192.168.0.105,1433;Initial Catalog=ProjectDB;Integrated Security=False;User ID=sa;Password=123456789;Connect Timeout=15;Encrypt=False;TrustServerCertificate=False");
            try
            {
                SqlCommand hm = new SqlCommand("SELECT COUNT(*) as count FROM selling_table", cn);
                cn.Open();
                SqlDataReader dt;
                dt = hm.ExecuteReader();

                while (dt.Read())
                {
                    string co = dt["count"].ToString();
                    int invo = 1001 + Convert.ToInt32(co);
                    invoice_lab.Text = invo.ToString();

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
        void combo_product()
        {
            SqlConnection cn = new SqlConnection(@"Data Source=192.168.0.105,1433;Initial Catalog=ProjectDB;Integrated Security=False;User ID=sa;Password=123456789;Connect Timeout=15;Encrypt=False;TrustServerCertificate=False");
            try
            {
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

        void pro(string productUnit)
        {
            if (productUnit.Equals("KILOGRAM") || productUnit.Equals("GRAM")) //KILOGRAM GRAM
            {
                combounit.Items.Clear();
                combounit.Text = "";
                combounit.SelectedText = "UNIT";
                combounit.Items.Add("KILOGRAM");
                combounit.Items.Add("GRAM");
            }
            else if (productUnit.Equals("LETEER") || productUnit.Equals("MELELITTER"))  //LETEER MELELITTER
            {
                combounit.Items.Clear();
                combounit.Text = "";
                combounit.SelectedText = "UNIT";
                combounit.Items.Add("LETEER");
                combounit.Items.Add("MELELITTER");
            }
            else
            {
                //PIECE
                combounit.Items.Clear();
                combounit.Text = "";
                combounit.Items.Add("PIECE");
                combounit.SelectedItem = "PIECE";
            }
        }
        private void radioButton1_CheckedChanged(object sender, EventArgs e)
        {
            card_num.Enabled = true;
            card_name.Enabled = true;
            card_st.Enabled = true;
            card_dis.Enabled = true;

            card_numb_tx.Enabled = true;
            card_name_tx.Enabled = true;
            card_st_tx.Enabled = true;
           // card_dis_tx.Enabled = true;

           // card_dis_tx.BackColor = Color.White;
            
        }

        private void radioButton2_CheckedChanged(object sender, EventArgs e)
        {
            card_numb_tx.Text = "";
            card_name_tx.Text = "";
            card_st_tx.Text = "";
           // card_dis_tx.Text = "";

            card_num.Enabled = false;
            card_name.Enabled = false;
            card_st.Enabled = false;
            card_dis.Enabled = false;

            card_numb_tx.Enabled = false;
            card_name_tx.Enabled = false;
            card_st_tx.Enabled = false;
           // card_dis_tx.Enabled = false;

            //card_dis_tx.BackColor = Color.WhiteSmoke;

        }

        private void pro_id_tx_KeyPress(object sender, KeyPressEventArgs e)
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

        private void card_numb_tx_KeyPress(object sender, KeyPressEventArgs e)
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

        private void cas_main_manu_Click(object sender, EventArgs e)
        {
            this.Hide();
            Form2 ob = new Form2();
            ob.ShowDialog();
            this.Close();
        }

        private void cas_exit_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void combo_pro_name_SelectedIndexChanged(object sender, EventArgs e)
        {
            combo_pro_name.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDown;
            combo_pro_name.AutoCompleteMode = AutoCompleteMode.SuggestAppend;
            combo_pro_name.AutoCompleteSource = AutoCompleteSource.ListItems;

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

                    pro_id_tx.Text = ds["productID"].ToString();
                    productUnitt = ds["unit"].ToString();
                    ds.Close();
                }


                pro(productUnitt);

                
                

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

        private void pro_id_tx_TextChanged(object sender, EventArgs e)
        {
            SqlConnection cn = new SqlConnection(@"Data Source=192.168.0.105,1433;Initial Catalog=ProjectDB;Integrated Security=False;User ID=sa;Password=123456789;Connect Timeout=15;Encrypt=False;TrustServerCertificate=False");
            try
            {
                SqlCommand ch = new SqlCommand("select * from product_table where productID = '" + pro_id_tx.Text + "'", cn);
                cn.Open(); 
                SqlDataReader dw;
                dw = ch.ExecuteReader();

                if (dw.Read())
                {
                    combo_pro_name.Text = "";
                    combo_pro_name.SelectedText = dw["productName"].ToString();
                    productUnitt = dw["unit"].ToString();
                    pro(productUnitt);
                }

                else
                {
                    combounit.Text = "UNIT";
                    combounit.Items.Clear();
                    combo_pro_name.Text = "";
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

        private void card_numb_tx_TextChanged(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(card_numb_tx.Text))
            {
                card_st_tx.Text = "";
                card_name_tx.Text = "";
                card_dis_tx.Text = "0";
            }
            else
            {
                SqlConnection cn = new SqlConnection(@"Data Source=192.168.0.105,1433;Initial Catalog=ProjectDB;Integrated Security=False;User ID=sa;Password=123456789;Connect Timeout=15;Encrypt=False;TrustServerCertificate=False");
                try
                {

                    SqlCommand memcmdshow = new SqlCommand("select * from member_table where memberID = '" + card_numb_tx.Text + "'", cn);
                    cn.Open();
                    SqlDataReader memdatareadershow;
                    memdatareadershow = memcmdshow.ExecuteReader();

                    if (memdatareadershow.Read())
                    {
                        card_name_tx.Text = memdatareadershow["memberName"].ToString();
                        card_dis_tx.Text = memdatareadershow["memberDiscount"].ToString();
                        card_st_tx.Text = "VALID";

                       

                        memdatareadershow.Close();
                    }
                    else
                    {
                        card_st_tx.Text = "INVALID";
                        card_name_tx.Text = "";
                        card_dis_tx.Text = "0";
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

        private void enter_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(pro_id_tx.Text) || combo_pro_name.SelectedText==null ||string.IsNullOrEmpty(pro_quantity_tx.Text) || combounit.SelectedItem==null)
            {
                MessageBox.Show("All the fields are not filled", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else
            {
                SqlConnection cn = new SqlConnection(@"Data Source=192.168.0.105,1433;Initial Catalog=ProjectDB;Integrated Security=False;User ID=sa;Password=123456789;Connect Timeout=15;Encrypt=False;TrustServerCertificate=False");
                try
                {

                    SqlCommand hm = new SqlCommand("select * from product_table where productID = '" + pro_id_tx.Text + "'", cn);
                    cn.Open();
                    SqlDataReader dt;
                    dt = hm.ExecuteReader();

                    if(dt.Read())
                    {
                        
                        quntityCheak = dt["quantity"].ToString();
                        unitCheak = dt["unit"].ToString();
                        taka=dt["price"].ToString();
                        dt.Close();
                    }
                    string getunit=combounit.Text;
                    double textQuantity = Convert.ToDouble(pro_quantity_tx.Text);
                    double dataQuantity = Convert.ToDouble(quntityCheak);
                    double realtaka= Convert.ToDouble(taka);
                    
                    if(unitCheak.Equals(getunit))
                    {
                        

                        if(textQuantity>dataQuantity)
                        {
                            MessageBox.Show("We don't have this Quantity", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }
                        else
                        {
                            row1 = pro_id_tx.Text;
                            row2 = combo_pro_name.Text;
                            row3 = pro_quantity_tx.Text;
                            row4 = combounit.Text;
                            row5 = taka;
                            double res1 = textQuantity * realtaka;
                            totalprice = totalprice + res1;

                            row6 = res1.ToString();

                            string[] row = { row1, row2, row3, row4, row5, row6 };
                            dataGridView1.Rows.Add(row);
                        }
                    }
                    else
                    {

                        if (unitCheak == "GRAM" || unitCheak == "MELELITTER")
                        {
                            g = textQuantity * 1000;
                            
                        }
                        else
                        {
                            g = textQuantity;
                        }
                        
                        if (g > dataQuantity)
                        {
                            MessageBox.Show("We don't have this Quantity", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }
                        else
                        {
                            row1 = pro_id_tx.Text;
                            row2 = combo_pro_name.Text;
                            row3 = pro_quantity_tx.Text;
                            row4 = combounit.Text;
                            row5 = taka;

                            double res2 = g * realtaka;
                            totalprice = totalprice + res2;

                            row6 = res2.ToString();

                            string[] roww = { row1, row2, row3, row4, row5, row6 };
                            dataGridView1.Rows.Add(roww);
                        }
                    }

                    pro_id_tx.Text = "";
                    combo_pro_name.Text = "";
                    pro_quantity_tx.Text = "";

                    
                    
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
            if (totalprice < 500)
            {
                radioButton1.Enabled = false;

            }
            else
            {
                radioButton1.Enabled = true;
                radioButton2.Enabled = true;
            }
        }

        private void total_bt_Click(object sender, EventArgs e)
        {
            if (q == 0)
            {
                for (int i = 0; i < dataGridView1.Rows.Count; i++)
                {
                    sum = sum + Convert.ToDouble(dataGridView1.Rows[i].Cells[5].Value);
                }
                price_without_vat.Text = sum.ToString();
                
                if (radioButton1.Checked == true)
                {
                    if(string.IsNullOrEmpty(card_numb_tx.Text))
                    {
                        MessageBox.Show("Please Inset Member Card Number", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                    else
                    {
                        tempprice = Convert.ToDouble(price_without_vat.Text);
                        perdis = Convert.ToDouble(card_dis_tx.Text);
                        disprice = (sum * perdis) / 100;
                        discount.Text = disprice.ToString();

                        sum = sum - disprice;

                        price_with_dis.Text = sum.ToString();

                        pvat = (sum * 15) / 100;
                        vat.Text = pvat.ToString();
                        sum = sum + pvat;
                        price_with_vat.Text = sum.ToString();
                        s++;

                       /*radioButton1.Enabled = false;
                        radioButton2.Enabled = false;
                        card_dis.Enabled = false;
                       // card_dis_tx.Enabled = false;
                        card_dis_tx.Text = "";
                        card_num.Enabled = false;
                        card_numb_tx.Enabled = false;
                        //card_numb_tx.Text = "";
                        card_name.Enabled = false;
                        card_name_tx.Enabled = false;
                        //card_name_tx.Text = "";
                        card_st.Enabled = false;
                        card_st_tx.Enabled = false;
                        card_st_tx.Text = "";
                        pro_id_tx.Enabled = false;
                        combo_pro_name.Enabled = false;
                        pro_quantity_tx.Enabled = false;
                        combounit.Enabled = false;
                        //card_dis_tx.BackColor = Color.WhiteSmoke;
                        delete_bt.Enabled = false;*/
                        
                    }
                }
                else if(radioButton2.Checked==true)
                {
                    perdis = Convert.ToDouble(card_dis_tx.Text);
                    disprice = (sum * perdis) / 100;
                    discount.Text = disprice.ToString();

                    sum = sum - disprice;

                    price_with_dis.Text = sum.ToString();

                    pvat = (sum * 15) / 100;
                    vat.Text = pvat.ToString();
                    sum = sum + pvat;
                    price_with_vat.Text = sum.ToString();

                    //disprice = 0;
                    //discount.Text = disprice.ToString();

                    
                    
                    
                }
               total.Text = Math.Round((decimal)sum).ToString();
               // total.Text = sum.ToString();
                q++;
            }
            else
            {
                if(s==0)
                {
                    if (radioButton1.Checked == true)
                    {
                        if (string.IsNullOrEmpty(card_numb_tx.Text))
                        {
                            MessageBox.Show("Please Inset Member Card Number", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }
                        else
                        {
                            tempprice = Convert.ToDouble(price_without_vat.Text);
                            sum = tempprice;
                            perdis = Convert.ToDouble(card_dis_tx.Text);
                            disprice = (sum * perdis) / 100;
                            discount.Text = disprice.ToString();

                            sum = sum - disprice;

                            price_with_dis.Text = sum.ToString();

                            pvat = (sum * 15) / 100;
                            vat.Text = pvat.ToString();
                            sum = sum + pvat;
                            price_with_vat.Text = sum.ToString();
                            s++;

                           /*radioButton1.Enabled = false;
                            radioButton2.Enabled = false;
                            card_dis.Enabled = false;
                            //card_dis_tx.Enabled = false;
                            card_dis_tx.Text = "";
                            card_num.Enabled = false;
                            card_numb_tx.Enabled = false;
                           // card_numb_tx.Text = "";
                            card_name.Enabled = false;
                            card_name_tx.Enabled = false;
                            //card_name_tx.Text = "";
                            card_st.Enabled = false;
                            card_st_tx.Enabled = false;
                            card_st_tx.Text = "";
                            pro_id_tx.Enabled = false;
                            combo_pro_name.Enabled = false;
                            pro_quantity_tx.Enabled = false;
                            combounit.Enabled = false;
                            //card_dis_tx.BackColor = Color.WhiteSmoke;
                            delete_bt.Enabled = false;*/

                        }
                    }
                    else
                    {
                       
                    }
                }
                else
                {

                }
            }

        }

        private void delete_bt_Click(object sender, EventArgs e)
        {
            int a = dataGridView1.Rows.Count;
            int b = a - 1;

            if (b < 0)
            {
                MessageBox.Show("You don't have anything to delete");
                sum = 0;
            }
            else
            {
                dataGridView1.Rows.RemoveAt(b);
                sum = 0;
            }
           q = 0;
        }

        private void clear_bt_Click(object sender, EventArgs e)
        {
            pro_id_tx.Enabled = true;
            combo_pro_name.Enabled = true;
            pro_quantity_tx.Enabled = true;
            combounit.Enabled = true;

            radioButton1.Enabled = true;
            radioButton2.Enabled = true;
            radioButton2.Checked = true;

            delete_bt.Enabled = true;

            dataGridView1.Rows.Clear();
            dataGridView1.Refresh();

            price_without_vat.Text = "";
            vat.Text = "";
            price_with_vat.Text = "";
            price_with_dis.Text = "";
            discount.Text = "";
            total.Text = "";
            q = 0;
            s = 0;
            sum = 0;
            dis();

        }

        private void void_bt_Click(object sender, EventArgs e)
        {
            string[] arr_name = new string[100];
            string[] arr_quantity = new string[100];
            string[] arr_data_quantity = new string[100];
            string[] arr_unit = new string[100];
            string[] arr_data_unit = new string[100];
            string[] arr_price = new string[100];
            string[] arr_rate = new string[100];


            for (int i = 0; i < dataGridView1.Rows.Count; i++)
            {
                arr_name[i] = dataGridView1.Rows[i].Cells[1].Value.ToString();
                arr_quantity[i] = dataGridView1.Rows[i].Cells[2].Value.ToString();
                arr_unit[i] = dataGridView1.Rows[i].Cells[3].Value.ToString();
                arr_rate[i] = dataGridView1.Rows[i].Cells[4].Value.ToString();
                arr_price[i] = dataGridView1.Rows[i].Cells[5].Value.ToString();

                SqlConnection cn = new SqlConnection(@"Data Source=192.168.0.105,1433;Initial Catalog=ProjectDB;Integrated Security=False;User ID=sa;Password=123456789;Connect Timeout=15;Encrypt=False;TrustServerCertificate=False");
                try
                {
                    SqlCommand ch = new SqlCommand("select * from product_table where productName = '" + arr_name[i] + "'", cn);
                    cn.Open();
                    SqlDataReader dw;
                    dw = ch.ExecuteReader();

                    if (dw.Read())
                    {

                        arr_data_quantity[i] = dw["quantity"].ToString();
                        arr_data_unit[i] = dw["unit"].ToString();
                    }
                    if (arr_unit[i] == arr_data_unit[i])
                    {
                        bg = Convert.ToDouble(arr_data_quantity[i]) - Convert.ToDouble(arr_quantity[i]);

                    }
                    else
                    {
                        if (arr_data_unit[i] == "GRAM" || arr_data_unit[i] == "MELELITTER")
                        {
                            g = Convert.ToDouble(arr_quantity[i]) * 1000;
                            arr_quantity[i] = g.ToString();
                        }
                        bg = Convert.ToDouble(arr_data_quantity[i]) - Convert.ToDouble(arr_quantity[i]);



                    }

                    cn.Close();

                    if (bg <= 0)
                    {
                        bg = 0;
                    }

                    string update = "update product_table set quantity='" + bg.ToString() + "' where productName= '" + arr_name[i] + "'";
                    SqlCommand upsql = new SqlCommand(update, cn);
                    cn.Open();
                    upsql.ExecuteNonQuery();




                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                finally
                {
                    cn.Close();


                }

                try
                {
                    string sqll = "INSERT INTO invoice_table (InvoiceId,InProductName,InQuantity,InUnit,InRate,InPrice) values('" + invoice_lab.Text + "','" + arr_name[i] + "','" + arr_quantity[i] + "','" + arr_unit[i] + "','" + arr_rate[i] + "','" + arr_price[i] + "')";
                    SqlCommand exesqll = new SqlCommand(sqll, cn);
                    cn.Open(); //product insert
                    exesqll.ExecuteNonQuery();
                    

                }

                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                finally
                {
                    cn.Close();
                    //MessageBox.Show("Done!!!", "Message", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
            SqlConnection cnn = new SqlConnection(@"Data Source=192.168.0.105,1433;Initial Catalog=ProjectDB;Integrated Security=False;User ID=sa;Password=123456789;Connect Timeout=15;Encrypt=False;TrustServerCertificate=False");
            try
            {
                

                if (card_name_tx.Enabled == true)
                {
                    //DateTime datee = Convert.ToDateTime(dateTimePicker1);
                   
                    string day = DateTime.Now.ToString("dd", CultureInfo.InvariantCulture); ;
                    string month = DateTime.Now.ToString("MMMM", CultureInfo.InvariantCulture);
                    string year = DateTime.Now.ToString("yyyy", CultureInfo.InvariantCulture);

                    string sqll = "INSERT INTO selling_table (WithOutVat,Vat,WithVat,MemberId,MemberName,Discount,Total,Day,Month,Year) values('" + price_without_vat.Text + "','" + vat.Text + "','" + price_with_vat.Text + "','" + card_numb_tx.Text + "','" + card_name_tx.Text + "','" + discount.Text + "','" + total.Text + "','" + day + "','" + month + "','" + year + "')";
                    SqlCommand exesqll = new SqlCommand(sqll, cnn);
                    cnn.Open();
                    exesqll.ExecuteNonQuery();
                    MessageBox.Show("ok", "Message", MessageBoxButtons.OK, MessageBoxIcon.Information);

                }
                else
                {
                    // DateTime datee = Convert.ToDateTime(dateTimePicker1);
                   
                    string day = DateTime.Now.ToString("dd", CultureInfo.InvariantCulture); ;
                    string month = DateTime.Now.ToString("MMMM", CultureInfo.InvariantCulture);
                    string year = DateTime.Now.ToString("yyyy", CultureInfo.InvariantCulture);

                    string sqll = "INSERT INTO selling_table (WithOutVat,Vat,WithVat,Discount,Total,Day,Month,Year) values('" + price_without_vat.Text + "','" + vat.Text + "','" + price_with_vat.Text + "','" + discount.Text + "','" + total.Text + "','" + day + "','" + month + "','" + year + "')";
                    SqlCommand exesqll = new SqlCommand(sqll, cnn);
                    cnn.Open();
                    exesqll.ExecuteNonQuery();
                    MessageBox.Show("ok", "Message", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }

            }





            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                cnn.Close();

                invoice();
                pro_id_tx.Enabled = true;
                combo_pro_name.Enabled = true;
                pro_quantity_tx.Enabled = true;
                combounit.Enabled = true;

                radioButton1.Enabled = true;
                radioButton2.Enabled = true;
                radioButton2.Checked = true;

                delete_bt.Enabled = true;

                dataGridView1.Rows.Clear();
                dataGridView1.Refresh();

                price_without_vat.Text = "";
                vat.Text = "";
                price_with_vat.Text = "";
                price_with_dis.Text = "";
                discount.Text = "";
                total.Text = "";
                q = 0;
                s = 0;
                sum = 0;
                dis();


            }

        }

       
    }
}
