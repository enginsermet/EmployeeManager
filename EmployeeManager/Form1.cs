using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;
using System.Data.OleDb;
using System.Text.RegularExpressions;

namespace EmployeeManager
{
    public partial class Form1 : Form
    {
        OleDbConnection connect = new OleDbConnection();
        //OpenFileDialog ofd = new OpenFileDialog();
        public static string accountId { get; set; }

        public int ID { get; private set; }

        public Regex regex = new Regex(@"^([0-9a-zA-Z](?>[-.\w]*[0-9a-zA-Z])*@(?>[0-9a-zA-Z][-\w]*[0-9a-zA-Z]\.)+[a-zA-Z]{2,9})$", RegexOptions.Compiled);
        public Regex phone_regex = new Regex("^[0-9]+$");
        public Regex webregex = new Regex(@"^([0-9a-zA-Z](?>[-.\w]*[0-9a-zA-Z])*.(?>[0-9a-zA-Z][-\w]*[0-9a-zA-Z]\.)+[a-zA-Z]{2,9})$", RegexOptions.Compiled);

        public Form1()
        {
            InitializeComponent();
            connect.ConnectionString = (@"Provider=Microsoft.ACE.OLEDB.12.0;Data Source=C:\Users\Engin\Documents\EmployeeManager.accdb");
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            try
            {
                connect.Open();
                OleDbCommand scmd = new OleDbCommand("SELECT [AccountID] FROM Account WHERE username = @username", connect);
                scmd.Parameters.AddWithValue("@username", login.userName);
                OleDbDataReader reader = scmd.ExecuteReader();

                while (reader.Read())
                {
                    accountId = reader.GetValue(0).ToString();
                }

                connect.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error" + ex);
            }

        }
        private void txt_MailAddress_TextChanged(object sender, EventArgs e)
        {
            if (regex.IsMatch(txt_MailAddress.Text))
            {
                errorProvider1.Clear();
            }
        }

        private void txt_MailAddress_Leave(object sender, EventArgs e)
        {
            if (!regex.IsMatch(txt_MailAddress.Text))
            {
                errorProvider1.SetError(this.txt_MailAddress, "Please enter a valid mail address");
            }
     

        }

        private void txt_PhoneNumber_Leave(object sender, EventArgs e)
        {
            if (!phone_regex.IsMatch(txt_PhoneNumber.Text))
            {
                errorProvider2.SetError(txt_PhoneNumber, "Please enter a valid phone number");
            }
        }

        private void txt_PhoneNumber_TextChanged(object sender, EventArgs e)
        {
            if (phone_regex.IsMatch(txt_PhoneNumber.Text))
            {
                errorProvider2.Clear();
            }
        }

        private void txt_WebAddress_TextChanged(object sender, EventArgs e)
        {
            if (webregex.IsMatch(this.txt_WebAddress.Text))
            {
                errorProvider3.Clear();
            }
        }

        private void button1_Click_1(object sender, EventArgs e)
        {
            editCompany ec = new editCompany();
            ec.Show();
            this.Hide();
        }

        private void Form1_FormClosed(object sender, FormClosedEventArgs e)
        {
            CompanySelection cs = new CompanySelection();
            cs.Show();
            this.Hide();
        }

        private void txt_WebAddress_Leave(object sender, EventArgs e)
        {
            if (!webregex.IsMatch(this.txt_WebAddress.Text))
            {
                errorProvider3.SetError(this.txt_WebAddress, "Please enter a valid web address");
            }
           

        }

        private void btn_Add_Click(object sender, EventArgs e)
        {
            foreach (Control c in this.Controls)
            {
                if (c is TextBox)
                {
                    TextBox textBox = c as TextBox;
                    if (textBox.Text == string.Empty)
                    {
                        MessageBox.Show("Please fill out all required fields", " ", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return;
                    }
                }
            }
            if (!phone_regex.IsMatch(txt_PhoneNumber.Text) || !webregex.IsMatch(this.txt_WebAddress.Text) || !regex.IsMatch(txt_MailAddress.Text))
            {
                return;
            }

            try
            {
                connect.Open();

                OleDbCommand command = new OleDbCommand("insert into Company([AccountID], [firstname], [lastname], [companyTitle], [phoneNumber], [address], [city], [town], [mailAddress], [webAddress], [taxNumber], [taxOffice]) values(@accountID, @firstName, @lastName, @companytitle, @phone, @address, @city, @town, @mailAddress, @web, @taxnumber, @office)", connect);
                command.Parameters.AddWithValue("@accountID", accountId);
                command.Parameters.AddWithValue("@firstName", txt_FirstName.Text);
                command.Parameters.AddWithValue("@lastName", txt_LastName.Text.ToString());
                command.Parameters.AddWithValue("@companytitle", txt_CompanyTitle.Text);
                command.Parameters.AddWithValue("@phone", Convert.ToInt64(txt_PhoneNumber.Text));
                command.Parameters.AddWithValue("@address", txt_Address.Text);
                command.Parameters.AddWithValue("@city", txt_City.Text);
                command.Parameters.AddWithValue("@town", txt_Town.Text);
                command.Parameters.AddWithValue("@mailAddress", txt_MailAddress.Text);
                command.Parameters.AddWithValue("@web", txt_WebAddress.Text);
                command.Parameters.AddWithValue("@taxnumber", Convert.ToInt64(txt_TaxNumber.Text));
                command.Parameters.AddWithValue("@office", txt_Office.Text);
                command.ExecuteNonQuery();
                MessageBox.Show("Company added successfully", " ", MessageBoxButtons.OK, MessageBoxIcon.Information);

                connect.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error" + ex);
            }

        }
    }
    }

   
    

