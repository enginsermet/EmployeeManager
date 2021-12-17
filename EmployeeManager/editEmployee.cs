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
    public partial class editEmployee : Form
    {
        OleDbConnection connect = new OleDbConnection();

        public static int ID { get; set; }

        public static string accountId { get; set; }
        public static string companyId { get; set; }
        public static string departmentName { get; set; }
        public static string imagefile { get; set; }

        public Regex regex = new Regex(@"^([0-9a-zA-Z](?>[-.\w]*[0-9a-zA-Z])*@(?>[0-9a-zA-Z][-\w]*[0-9a-zA-Z]\.)+[a-zA-Z]{2,9})$", RegexOptions.Compiled);

        public Regex phone_regex = new Regex("^[0-9]+$");

        public editEmployee()
        {
            InitializeComponent();
            connect.ConnectionString = (@"Provider=Microsoft.ACE.OLEDB.12.0;Data Source=C:\Users\Engin\Documents\EmployeeManager.accdb");

        }

        private void editEmployee_Load(object sender, EventArgs e)
        {
            /*DateTime dob = DateTime.ParseExact(employees.e_dob, "dd/MM/yyyy hh:mm:ss", CultureInfo.InvariantCulture);
            dateTimePicker_DOB.Value = dob;*/




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
                    comboBox1.Items.Add(creader["DepartmentName"].ToString());


                }


                connect.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error" + ex);
            }      

        ID = employees.e_ID;
            label_Department.Text = employees.e_department;
            pictureBox1.Image = Image.FromFile(employees.e_imageFileName);
            pictureBox1.SizeMode = PictureBoxSizeMode.Zoom;
            imagefile = employees.e_imageFileName;
            label_Firstname.Text = employees.e_firstname;
            label_LastName.Text = employees.e_lastname;
            label_Gender.Text = employees.e_gender;
            label_Marital.Text = employees.e_marital;
            label_DOB.Text = employees.e_dob;
            label_Position.Text = employees.e_postion;
            label_Phone.Text = employees.e_phonenumber.ToString();
            label_Address.Text = employees.e_address;
            label_City.Text = employees.e_city;
            label_Town.Text = employees.e_town;
            label_Mail.Text = employees.e_mailaddress;
            label_Hire.Text = employees.e_hireDate;
            label_Start.Text = employees.e_startDate;
            label_Salary.Text = employees.e_salary.ToString();


            txt_FirstName.Text = employees.e_firstname;
            txt_LastName.Text = employees.e_lastname;
            comboBox_Gender.SelectedItem = employees.e_gender;
            comboBox_Marital.SelectedItem = employees.e_marital;

            dateTimePicker_DOB.Value = Convert.ToDateTime(employees.e_dob);
            comboBox1.SelectedItem = employees.e_department;
            txt_Position.Text = employees.e_postion;
            txt_PhoneNumber.Text = employees.e_phonenumber.ToString();
            txt_Address.Text = employees.e_address;
            txt_City.Text = employees.e_city;
            txt_Town.Text = employees.e_town;
            txt_MailAddress.Text = employees.e_mailaddress;
            dateTimePicker_Hire.Value = Convert.ToDateTime(employees.e_hireDate);
            dateTimePicker_Start.Value = Convert.ToDateTime(employees.e_startDate);
            numericUpDown1.Text = employees.e_salary.ToString();
                 

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
            if (comboBox1.SelectedItem == null)
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
                    OleDbCommand command = new OleDbCommand("update Employees set [DepartmentName]= @department, [image]= @image, [firstName]= @firstName, [lastName]= @lastName, [gender]= @gender, [maritalStatus]= @maritalStatus, [DOB]= @dob, [position]= @position, [phoneNumber]= @phone, [address]= @address, [city]= @city, [town]= @town, [mailAddress]= @mailAddress, [hireDate]= @hire, [startDate]= @start, [salary]= @salary where [ID] = @id", connect);

                    command.Parameters.AddWithValue("@department", comboBox1.SelectedItem);
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
                    command.Parameters.AddWithValue("@id", ID);
                    command.ExecuteNonQuery();

                    MessageBox.Show("Employee has been updated");
                    connect.Close();
                

            }
            catch (Exception ex)
            {
                MessageBox.Show("Error" + ex);
            }
            

           


        }

        private void btn_Edit_Click(object sender, EventArgs e)
        {
            btn_Save.Visible = true;
            btn_Edit.Visible = false;
            btn_Details.Visible = true;
            button2.Visible = true;

            txt_FirstName.Visible = true;
            txt_LastName.Visible = true;
            comboBox_Gender.Visible = true;
            comboBox_Marital.Visible = true;
            txt_Position.Visible = true;
            txt_PhoneNumber.Visible = true;
            txt_Address.Visible = true;
            txt_City.Visible = true;
            txt_Town.Visible = true;
            txt_MailAddress.Visible = true;
            numericUpDown1.Visible = true;
            dateTimePicker_DOB.Visible = true;
            dateTimePicker_Hire.Visible = true;
            dateTimePicker_Start.Visible = true;
            comboBox1.Visible = true;


            txt_FirstName.ReadOnly=false;
            txt_LastName.ReadOnly=false;
            txt_Position.ReadOnly=false;
            txt_PhoneNumber.ReadOnly=false;
            txt_Address.ReadOnly = false;
            txt_City.ReadOnly=false;
            txt_Town.ReadOnly=false;
            txt_MailAddress.ReadOnly=false;
            numericUpDown1.ReadOnly=false;

            label_Department.Visible = false;
            label_Firstname.Visible = false; 
            label_LastName.Visible = false;
            label_Gender.Visible = false;
            label_Marital.Visible = false;
            label_DOB.Visible = false;
            label_Position.Visible = false;
            label_Phone.Visible = false;
            label_Address.Visible = false;
            label_City.Visible = false;
            label_Town.Visible = false;
            label_Mail.Visible = false;
            label_Hire.Visible = false;
            label_Start.Visible = false;
            label_Salary.Visible = false;
            label16.Visible = false;
        }

        private void btn_Details_Click(object sender, EventArgs e)
        {
            btn_Details.Visible = false;
            btn_Edit.Visible = true;
            btn_Save.Visible = false;
            button2.Visible = false;

            txt_FirstName.Visible = false;
            txt_LastName.Visible = false;
            comboBox_Gender.Visible = false;
            comboBox_Marital.Visible = false;
            txt_Position.Visible = false;
            txt_PhoneNumber.Visible = false;
            txt_Address.Visible = false;
            txt_City.Visible = false;
            txt_Town.Visible = false;
            txt_MailAddress.Visible = false;
            numericUpDown1.Visible = false;
            dateTimePicker_DOB.Visible = false;
            dateTimePicker_Hire.Visible = false;
            dateTimePicker_Start.Visible = false;


            txt_FirstName.ReadOnly = true;
            txt_LastName.ReadOnly = true;
            txt_Position.ReadOnly = true;
            txt_PhoneNumber.ReadOnly = true;
            txt_City.ReadOnly = true;
            txt_Town.ReadOnly = true;
            txt_MailAddress.ReadOnly = true;
            numericUpDown1.ReadOnly = true;

            label_Department.Visible = true;
            label_Firstname.Visible = true;
            label_LastName.Visible = true;
            label_Gender.Visible = true;
            label_Marital.Visible = true;
            label_DOB.Visible = true;
            label_Position.Visible = true;
            label_Phone.Visible = true;
            label_Address.Visible = true;
            label_City.Visible = true;
            label_Town.Visible = true;
            label_Mail.Visible = true;
            label_Hire.Visible = true;
            label_Start.Visible = true;
            label_Salary.Visible = true;
            label16.Visible = true;
        }

        private void editEmployee_FormClosed(object sender, FormClosedEventArgs e)
        {
            employees ee = new employees();
            ee.Show();
            this.Hide();
        }

        private void label_City_Click(object sender, EventArgs e)
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

        private void label_LastName_Click(object sender, EventArgs e)
        {

        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {

        }

        private void txt_PhoneNumber_TextChanged(object sender, EventArgs e)
        {
            if (!phone_regex.IsMatch(txt_PhoneNumber.Text))
            {
                errorProvider2.SetError(txt_PhoneNumber, "Please enter a valid phone number");
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
