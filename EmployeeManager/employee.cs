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
    public partial class employee : Form
    {
        public int salary { get; set; }
        public static string accountId { get; set; }
        public static string companyId { get; set; }
        public static string departmentName { get; set; }
        public static string imagefile { get; set; }

        public Regex regex = new Regex(@"^([0-9a-zA-Z](?>[-.\w]*[0-9a-zA-Z])*@(?>[0-9a-zA-Z][-\w]*[0-9a-zA-Z]\.)+[a-zA-Z]{2,9})$", RegexOptions.Compiled);

        public Regex phone_regex = new Regex("^[0-9]+$");



        OleDbConnection connect = new OleDbConnection();

        public employee()
        {
            InitializeComponent();
            connect.ConnectionString = (@"Provider=Microsoft.ACE.OLEDB.12.0;Data Source=C:\Users\Engin\Documents\EmployeeManager.accdb");

        }

        private void employee_Load(object sender, EventArgs e)
        {
           

            numericUpDown1.Maximum = decimal.MaxValue;

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

                OleDbCommand dcmd = new OleDbCommand("SELECT [CompanyID] FROM Company WHERE AccountID = @accountID", connect);
                dcmd.Parameters.AddWithValue("@accountID", accountId);
                OleDbDataReader dreader = dcmd.ExecuteReader();

                while (dreader.Read())
                {
                    companyId = dreader.GetValue(0).ToString();
                }

                OleDbCommand companycmd = new OleDbCommand("SELECT * FROM Department WHERE CompanyID = @companyID", connect);
                companycmd.Parameters.AddWithValue("@companyID", companyId);
                OleDbDataReader creader = companycmd.ExecuteReader();

                while (creader.Read())
                {
                    departmentName = creader.GetValue(0).ToString();
                    comboBox_Department.Items.Add(creader["DepartmentName"].ToString());
                    

                }

              
                connect.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error" + ex);
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
            if (comboBox_Department.SelectedItem == null)
            {
                MessageBox.Show("Please fill out all required fields", " ", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            if (!phone_regex.IsMatch(txt_PhoneNumber.Text) || !regex.IsMatch(txt_MailAddress.Text))
            {
                return;
            }

            try
            {
                    connect.Open();
                    OleDbCommand command = new OleDbCommand("insert into Employees([CompanyID], [DepartmentName], [image], [firstName], [lastName], [gender], [maritalStatus], [DOB], [position], [phoneNumber], [address], [city], [town], [mailAddress], [hireDate], [startDate], [salary]) values(@companyid, @departmentname, @image, @firstName, @lastName, @gender, @maritalStatus, @dob, @position, @phone, @address, @city, @town, @mailAddress, @hire, @start, @salary)", connect);
                                    
                    command.Parameters.AddWithValue("@companyid", accountId);
                    command.Parameters.AddWithValue("@departmentname", comboBox_Department.SelectedItem.ToString());
                    command.Parameters.AddWithValue("@image", imagefile.ToString());
                    command.Parameters.AddWithValue("@firstName", txt_FirstName.Text);
                    command.Parameters.AddWithValue("@lastName", txt_LastName.Text);
                    command.Parameters.AddWithValue("@gender", comboBox_Gender.SelectedItem.ToString());
                    command.Parameters.AddWithValue("@maritalStatus", comboBox_Marital.SelectedItem.ToString());
                    command.Parameters.AddWithValue("@dob", dateTimePicker_DOB.Text.ToString());
                    command.Parameters.AddWithValue("@position ", txt_Position.Text);
                    command.Parameters.AddWithValue("@phone", txt_PhoneNumber.Text);
                    command.Parameters.AddWithValue("@address", txt_Address.Text);
                    command.Parameters.AddWithValue("@city", txt_City.Text);
                    command.Parameters.AddWithValue("@town", txt_Town.Text);
                    command.Parameters.AddWithValue("@mailAddress", txt_MailAddress.Text);
                    command.Parameters.AddWithValue("@hire", dateTimePicker_Hire.Text.ToString());
                    command.Parameters.AddWithValue("@start", dateTimePicker_Start.Text.ToString());
                    command.Parameters.AddWithValue("@salary", numericUpDown1.Value);



                command.ExecuteNonQuery();
                    connect.Close();
                MessageBox.Show("Employee has been added successfuly", "", MessageBoxButtons.OK);
                this.Close();

                
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error" + ex);
            }
        }

        private void numericUpDown1_ValueChanged(object sender, EventArgs e)
        {

        }

        private void groupBox1_Enter(object sender, EventArgs e)
        {

        }

        private void dateTimePicker_DOB_ValueChanged(object sender, EventArgs e)
        {

        }

        private void dateTimePicker_Hire_ValueChanged(object sender, EventArgs e)
        {
        }

        private void dateTimePicker_Start_ValueChanged(object sender, EventArgs e)
        {
        }

        private void comboBox_Department_SelectedIndexChanged(object sender, EventArgs e)
        {
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

        private void employee_FormClosed(object sender, FormClosedEventArgs e)
        {
            employees ee = new employees();
            ee.Show();
            this.Hide();
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
    }
}

