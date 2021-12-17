using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;


namespace EmployeeManager
{
    public partial class Welcome : Form
    {       
        public Welcome()
        {
            InitializeComponent();
            label1.BackColor = System.Drawing.Color.Transparent;
            pictureBox1.BackColor = System.Drawing.Color.Transparent;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Hide();
            Signup sgn = new Signup();
            sgn.ShowDialog();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Hide();
            login l = new login();
            l.Show();
        }

        private void Welcome_Load(object sender, EventArgs e)
        {

        }

        private void Welcome_FormClosed(object sender, FormClosedEventArgs e)
        {
           
        }

        private void Welcome_FormClosing(object sender, FormClosingEventArgs e)
        {
            Application.Exit();
        }
    }
}
