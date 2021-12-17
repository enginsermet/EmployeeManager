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
using System.Text.RegularExpressions;

namespace EmployeeManager
{
    public partial class Signup : Form
    {

        OleDbConnection connect = new OleDbConnection();
        public static string imagefile { get; set; }

        public Signup()
        {
            InitializeComponent();
            connect.ConnectionString = (@"Provider=Microsoft.ACE.OLEDB.12.0;Data Source=C:\Users\Engin\Documents\EmployeeManager.accdb");
        }
        private void Signup_Load(object sender, EventArgs e)
        {
           
        }

        private void btn_Signup_Click(object sender, EventArgs e)
        {
            var regex = new Regex(@"^([0-9a-zA-Z](?>[-.\w]*[0-9a-zA-Z])*@(?>[0-9a-zA-Z][-\w]*[0-9a-zA-Z]\.)+[a-zA-Z]{2,9})$",RegexOptions.Compiled);
            try
            {
                if (txt_s_Username.Text == "" || txt_s_Password.Text == "")
                {
                    txt_s_Username.Focus();
                    MessageBox.Show("You did not enter Username or Password!", " ", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
                else if (txt_s_Password.Text != txt_s_Re_Enter.Text) {
                    MessageBox.Show("The passwords you entered do not match, please try again.", " ", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    checkBox1.Visible=true;
                    txt_s_Re_Enter.Focus();
                }
                else if (!regex.IsMatch(txt_s_MailAddress.Text))
                {  
                    errorProvider1.SetError(this.txt_s_MailAddress, "Please enter valid mail address");
                    txt_s_MailAddress.Focus();
                }             
                else
                {
                    connect.Open();
                    OleDbCommand cmd = new OleDbCommand("insert into Account([firstName], [lastName], [username], [password], [mailAddress]) values(@firstName, @lastName, @username, @password, @mailAddress)", connect);
                    cmd.Parameters.AddWithValue("@firstName", txt_s_firstName.Text);
                    cmd.Parameters.AddWithValue("@lastName", txt_s_LastName.Text);
                    cmd.Parameters.AddWithValue("@username", txt_s_Username.Text);
                    cmd.Parameters.AddWithValue("@password", txt_s_Password.Text);
                    cmd.Parameters.AddWithValue("@mailAddress", txt_s_MailAddress.Text);


                    //cmd.CommandText = ";
                    //
                    //insert into Account(firstName, lastName, username, password, mailAddress) values('" + txt_firstName.Text + "', '" + txt_LastName.Text + "', '" + txt_Username.Text + "', '" + txt_Password.Text + "', '" + txt_MailAddress.Text + "')
                    cmd.ExecuteNonQuery();

                    connect.Close();
                    MessageBox.Show("Your account has been successfully created","",MessageBoxButtons.OK, MessageBoxIcon.Information);
                    Welcome we = new Welcome();
                    we.Hide();
                    login l = new login();
                    l.Show();
                    this.Hide();
                    
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error" + ex);
            }
        }

        private void txt_s_Password_TextChanged(object sender, EventArgs e)
        {

        }

        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBox1.CheckState == CheckState.Checked)
            {
                txt_s_Password.PasswordChar = '\0';
            }
        }

        private void checkBox1_CheckStateChanged(object sender, EventArgs e)
        {
            if (checkBox1.CheckState==CheckState.Unchecked)
            {
                txt_s_Password.PasswordChar = '*';
            }


        }

        private void txt_s_Re_Enter_TextChanged(object sender, EventArgs e)
        {
            
        }

        private void Signup_FormClosed(object sender, FormClosedEventArgs e)
        {
            Welcome we = new Welcome();
            we.Show();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            OpenFileDialog ofd = new OpenFileDialog();

            ofd.Title = "Select an Image";
            ofd.Filter = "JPG Image(*.jpg)| *.jpg";
            ofd.FilterIndex = 2;
            ofd.Multiselect = false;
            DialogResult result = ofd.ShowDialog();

            if (result == DialogResult.Cancel)
                return;

            Image image = Image.FromFile(ofd.FileName);
            imagefile = ofd.FileName.ToString();
            pictureBox1.Image = image;
            pictureBox1.SizeMode = PictureBoxSizeMode.Zoom;
        }

        private void txt_s_MailAddress_Leave(object sender, EventArgs e)
        {

        }

        private void txt_s_MailAddress_TextChanged(object sender, EventArgs e)
        {
        
        }
    }
}
