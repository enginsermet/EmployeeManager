using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.OleDb;


namespace EmployeeManager
{
    public partial class home : Form
    {
        public static string username { get; set; }

        public static string accountId { get; set; }

        OleDbConnection connect = new OleDbConnection();

        public home()
        {
            InitializeComponent();
            connect.ConnectionString = (@"Provider=Microsoft.ACE.OLEDB.12.0;Data Source=C:\Users\Engin\Documents\EmployeeManager.accdb");
            label1.BackColor = System.Drawing.Color.Transparent;
        }

        private void home_Load(object sender, EventArgs e)
        {
            try
            {
                connect.Open();

                OleDbCommand scmd = new OleDbCommand("SELECT [username] FROM Account WHERE username = '" + login.userName + "' ", connect);
                scmd.Parameters.AddWithValue("@username", login.userName);
                OleDbDataReader reader = scmd.ExecuteReader();

                while (reader.Read())
                {
                    //accountId = reader.GetInt32(0).ToString();
                    //accountId = reader[0].ToString();
                    username = reader.GetValue(0).ToString();
                    label1.Text = "Welcome " + username;                   
                }

                reader.Close();
                 

                connect.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error" + ex);
            }


        }

        private void button1_Click(object sender, EventArgs e)
        {
            employees emp = new employees();
            emp.Show();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            CompanySelection cs = new CompanySelection();
            cs.Show();
        }

        private void home_FormClosing(object sender, FormClosingEventArgs e)
        {        
                if (MessageBox.Show("Are you sure you want to log out?", "Are you sure?", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.No)
                {
                    e.Cancel = true;
                }
            }

        private void home_FormClosed(object sender, FormClosedEventArgs e)
        {
            Welcome we = new Welcome();
            we.Show();
        }

        private void btn_Department_Click(object sender, EventArgs e)
        {
            Departments dpts = new Departments();
            dpts.Show();
        }
    }
}
