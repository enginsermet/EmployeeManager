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
    public partial class login : Form
    {
        OleDbConnection connect = new OleDbConnection();
        OleDbDataReader dr;

        public static string userName { get; set; }

        public login()
        {
            InitializeComponent();
            connect.ConnectionString = (@"Provider=Microsoft.ACE.OLEDB.12.0;Data Source=C:\Users\Engin\Documents\EmployeeManager.accdb");
            userName = txt_L_Username.Text;

        }

        private void login_Load(object sender, EventArgs e)
        {
        }

        private void btn_Login_Click(object sender, EventArgs e)
        {
            Welcome we = new Welcome();
            we.Hide();
            we.Enabled = false;
            try
            {
                if (txt_L_Username.Text == "" && txt_L_Password.Text == "")
                {
                    MessageBox.Show("Username and Password fields are empty");
                }
                else
                {
                    connect.Open();
                    OleDbCommand cmd = new OleDbCommand("SELECT * FROM Account WHERE username='" + txt_L_Username.Text + "' and password = '" + txt_L_Password.Text + "'", connect);


                    /*cmd.Parameters.AddWithValue("@username", txt_L_Username.Text);
                    cmd.Parameters.AddWithValue("@password", txt_L_Password.Text);*/


                    dr = cmd.ExecuteReader();
                    if (dr.Read())
                    {
                        home h = new home();
                        h.Show();
                        this.Hide();
                      
                    }
                    else
                    {
                        MessageBox.Show("Username or password is incorrect", "", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        txt_L_Username.Focus();
                        txt_L_Password.Text = "";
                    }
                    connect.Close();
                }
            

            }
            catch (Exception ex)
            {
                MessageBox.Show("Error" + ex);
            }

        }

        private void txt_L_Username_TextChanged(object sender, EventArgs e)
        {
            userName = txt_L_Username.Text;

        }

        private void login_FormClosed(object sender, FormClosedEventArgs e)
        {
            Welcome we = new Welcome();
            we.Show();
        }
    }
}
