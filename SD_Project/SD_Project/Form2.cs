using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SD_Project
{
    public partial class Form2 : Form
    {
        public Form2()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Hide();
            //admin ad = new admin();
            AdminLogin adlog = new AdminLogin();
            adlog.ShowDialog();
            this.Close();
        }

        private void exit_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void customer_care_Click(object sender, EventArgs e)
        {
            this.Hide();
            mainpage mp = new mainpage();
            mp.ShowDialog();
            this.Close();
        }
    }
}
