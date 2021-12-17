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
    public partial class editCompany : Form
    {
        public static string accountId { get; set; }

        public Regex regex = new Regex(@"^([0-9a-zA-Z](?>[-.\w]*[0-9a-zA-Z])*@(?>[0-9a-zA-Z][-\w]*[0-9a-zA-Z]\.)+[a-zA-Z]{2,9})$", RegexOptions.Compiled);

        public Regex phone_regex = new Regex("^[0-9]+$");

        public Regex webregex = new Regex(@"^([0-9a-zA-Z](?>[-.\w]*[0-9a-zA-Z])*.(?>[0-9a-zA-Z][-\w]*[0-9a-zA-Z]\.)+[a-zA-Z]{2,9})$", RegexOptions.Compiled);



        OleDbConnection connect = new OleDbConnection();
        public editCompany()
        {
            InitializeComponent();
            connect.ConnectionString = (@"Provider=Microsoft.ACE.OLEDB.12.0;Data Source=C:\Users\Engin\Documents\EmployeeManager.accdb");

        }

        private void editCompany_Load(object sender, EventArgs e)
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

            try
            {

                connect.Open();
                OleDbCommand cmd = new OleDbCommand("SELECT [firstName], [lastName], [companyTitle], [phoneNumber], [address], [city], [town], [mailAddress], [webAddress], [taxNumber], [taxOffice] FROM Company WHERE AccountID = @accountID", connect);
                cmd.Parameters.AddWithValue("@accountID", accountId);
                OleDbDataReader compreader = cmd.ExecuteReader();
                while (compreader.Read())
                {
                   label_firstName.Text = compreader.GetValue(0).ToString();
                   label_lastName.Text = compreader.GetValue(1).ToString();
                   label_company.Text = compreader.GetValue(2).ToString();
                   label_phone.Text = compreader.GetValue(3).ToString();
                   label_address.Text = compreader.GetValue(4).ToString();
                   label_city.Text = compreader.GetValue(5).ToString();
                   label_town.Text = compreader.GetValue(6).ToString();
                   label_mail.Text = compreader.GetValue(7).ToString();
                   label_web.Text = compreader.GetValue(8).ToString();
                   label_taxNumber.Text = compreader.GetValue(9).ToString();
                   label_office.Text = compreader.GetValue(10).ToString();

                   txt_FirstName.Text = compreader.GetValue(0).ToString();
                   txt_LastName.Text = compreader.GetValue(1).ToString();
                   txt_CompanyTitle.Text = compreader.GetValue(2).ToString();
                   txt_PhoneNumber.Text = compreader.GetValue(3).ToString();
                   txt_Address.Text = compreader.GetValue(4).ToString();
                   txt_City.Text = compreader.GetValue(5).ToString();
                   txt_Town.Text = compreader.GetValue(6).ToString();
                   txt_MailAddress.Text = compreader.GetValue(7).ToString();
                   txt_WebAddress.Text = compreader.GetValue(8).ToString();
                   txt_TaxNumber.Text = compreader.GetValue(9).ToString();
                   txt_Office.Text = compreader.GetValue(10).ToString();
                }
                connect.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error" + ex);
            }
        }

        private void label_firstName_Click(object sender, EventArgs e)
        {

        }

        private void btn_Details_Click(object sender, EventArgs e)
        {
            btn_Details.Visible = false;
            btn_Edit.Visible = true;
            btn_Save.Visible = false;

            txt_FirstName.Visible = false;
            txt_LastName.Visible = false;
            txt_CompanyTitle.Visible = false;
            txt_PhoneNumber.Visible = false;
            txt_Address.Visible = false;
            txt_City.Visible = false;
            txt_Town.Visible = false;
            txt_MailAddress.Visible = false;
            txt_WebAddress.Visible = false;
            txt_TaxNumber.Visible = false;
            txt_Office.Visible = false;

            label_firstName.Visible = true;
            label_lastName.Visible = true;
            label_company.Visible = true;
            label_phone.Visible = true;
            label_address.Visible = true;
            label_city.Visible = true;
            label_town.Visible = true;
            label_mail.Visible = true;
            label_web.Visible = true;
            label_taxNumber.Visible = true;
            label_office.Visible = true;
        }

        private void btn_Edit_Click(object sender, EventArgs e)
        {
            btn_Edit.Visible = false;
            btn_Save.Visible = true;
            btn_Details.Visible = true;
            label_firstName.Visible = false;
            label_lastName.Visible = false;
            label_company.Visible = false;
            label_phone.Visible = false;
            label_address.Visible = false;
            label_city.Visible = false;
            label_town.Visible = false;
            label_mail.Visible = false;
            label_web.Visible = false;
            label_taxNumber.Visible = false;
            label_office.Visible = false;

            txt_FirstName.Visible = true;
            txt_LastName.Visible = true;
            txt_CompanyTitle.Visible = true;
            txt_PhoneNumber.Visible = true;
            txt_Address.Visible = true;
            txt_City.Visible = true;
            txt_Town.Visible = true;
            txt_MailAddress.Visible = true;
            txt_WebAddress.Visible = true;
            txt_TaxNumber.Visible = true;
            txt_Office.Visible = true;

            txt_FirstName.ReadOnly = false;
            txt_LastName.ReadOnly = false;
            txt_CompanyTitle.ReadOnly = false;
            txt_PhoneNumber.ReadOnly = false;
            txt_Address.ReadOnly = false;
            txt_City.ReadOnly = false;
            txt_Town.ReadOnly = false;
            txt_MailAddress.ReadOnly = false;
            txt_WebAddress.ReadOnly = false;
            txt_TaxNumber.ReadOnly = false;
            txt_Office.ReadOnly = false;
        }
 

        private void txt_Mail_Leave(object sender, EventArgs e)
        {
        


        }




        private void btn_Save_Click(object sender, EventArgs e)
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
                OleDbCommand command = new OleDbCommand("update Company set [firstname]= @firstName, [lastname]= @lastName, [companyTitle]= @companyTitle, [phoneNumber]= @phoneNumber, [address]= @address, [city]= @city, [town]= @town, [mailAddress]= @mailAddress, [webAddress]= @webAddress, [taxNumber]= @taxNumber, [taxOffice]= @taxOffice where [AccountID] = @accountID", connect);

                command.Parameters.AddWithValue("@firstName", txt_FirstName.Text.ToString());
                command.Parameters.AddWithValue("@lastName", txt_LastName.Text.ToString());
                command.Parameters.AddWithValue("@companyTitle", txt_CompanyTitle.Text.ToString());
                command.Parameters.AddWithValue("@phoneNumber", Convert.ToInt64(txt_PhoneNumber.Text));
                command.Parameters.AddWithValue("@address", txt_Address.Text.ToString());
                command.Parameters.AddWithValue("@city ", txt_City.Text.ToString());
                command.Parameters.AddWithValue("@town", txt_Town.Text.ToString());
                command.Parameters.AddWithValue("@mailAddress", txt_MailAddress.Text.ToString());
                command.Parameters.AddWithValue("@webAddress", txt_WebAddress.Text.ToString());
                command.Parameters.AddWithValue("@taxNumber", Convert.ToInt64(txt_TaxNumber.Text));
                command.Parameters.AddWithValue("@taxOffice", txt_Office.Text.ToString());
                command.Parameters.AddWithValue("@accountID", accountId);
                command.ExecuteNonQuery();

                MessageBox.Show("Company information has been updated");
                connect.Close();


            }
            catch (Exception ex)
            {
                MessageBox.Show("Error" + ex);
            }

        }

        private void editCompany_FormClosed(object sender, FormClosedEventArgs e)
        {
            CompanySelection cs = new CompanySelection();
            cs.Show();
        }

        private void txt_PhoneNumber_TextChanged(object sender, EventArgs e)
        {
            if (phone_regex.IsMatch(txt_PhoneNumber.Text))
            {
                errorProvider2.Clear();
            }
        }

        private void txt_PhoneNumber_Leave(object sender, EventArgs e)
        {
            if (!phone_regex.IsMatch(txt_PhoneNumber.Text))
            {
                errorProvider2.SetError(txt_PhoneNumber, "Please enter a valid phone number");
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

        private void txt_WebAddress_TextChanged(object sender, EventArgs e)
        {
            if (webregex.IsMatch(this.txt_WebAddress.Text))
            {
                errorProvider3.Clear();
            }
        }

        private void txt_WebAddress_Leave(object sender, EventArgs e)
        {
            if (!webregex.IsMatch(this.txt_WebAddress.Text))
            {
                errorProvider3.SetError(this.txt_WebAddress, "Please enter a valid web address");
            }

        }
    }
}
