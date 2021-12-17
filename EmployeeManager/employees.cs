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
    public partial class employees : Form
    {
        public static int e_ID { get; set; }
        public static string e_department { get; set; }
        public static string e_imageFileName { get; set; }
        public static string e_firstname { get; set; }
        public static string e_lastname { get; set; }
        public static string e_gender { get; set; }
        public static string e_marital { get; set; }
        public static string e_dob { get; set; }
        public static string e_postion { get; set; }
        public static int e_phonenumber { get; set; }
        public static string e_address { get; set; }
        public static string e_city { get; set; }
        public static string e_town { get; set; }
        public static string  e_hireDate { get; set; }
        public static string e_startDate { get; set; }
        public static string e_mailaddress { get; set; }
        public static int e_salary { get; set; }
        public static string accountId { get; set; }
        public static string companyID { get; set; }



        OleDbConnection connect = new OleDbConnection();

        public employees()
        {
            InitializeComponent();
            connect.ConnectionString = (@"Provider=Microsoft.ACE.OLEDB.12.0;Data Source=C:\Users\Engin\Documents\EmployeeManager.accdb");
        }

        private void employees_Load(object sender, EventArgs e)
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

                    OleDbCommand comcmd = new OleDbCommand("SELECT [CompanyID] FROM Company WHERE [AccountID] = @accountID", connect);
                    comcmd.Parameters.AddWithValue("@accountID", accountId);

                    OleDbDataReader comreader = comcmd.ExecuteReader();
                    while (comreader.Read())
                    {
                        companyID = reader.GetValue(0).ToString();
                    }

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
                OleDbCommand tcmd = new OleDbCommand("SELECT [ID], [DepartmentName], [image], [firstName], [lastName], [gender], [maritalStatus], [DOB], [position], [phoneNumber], [address], [city], [town], [mailAddress], [hireDate], [startDate], [salary] from Employees WHERE [CompanyID] = @companyid", connect);
                tcmd.Parameters.AddWithValue("@companyid", companyID);
               
                //cmd.CommandText = query;
                OleDbDataAdapter da = new OleDbDataAdapter(tcmd);
                DataTable dt = new DataTable();
                da.Fill(dt);
                dataGridView1.DataSource = dt;
                connect.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error" + ex);
            }

        }
        private void btn_Add_Click(object sender, EventArgs e)
        {
            employee em = new employee();
            em.Show();
            this.Hide();
        }

        private void btn_Edit_Click(object sender, EventArgs e)
        {
            editEmployee ee = new editEmployee();
            ee.Show();
            this.Hide();
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void dataGridView1_SelectionChanged(object sender, EventArgs e)
        {
                foreach (DataGridViewRow row in dataGridView1.SelectedRows)
                {
                foreach (DataGridViewCell cell in row.Cells)
                {
                    if (DBNull.Value == cell.Value)
                    {
                        return;
                    }
                    else
                    {
                        e_ID = Convert.ToInt32(row.Cells[0].Value);
                        e_department = row.Cells[1].Value.ToString();
                        e_imageFileName = row.Cells[2].Value.ToString();
                        e_firstname = row.Cells[3].Value.ToString();
                        e_lastname = row.Cells[4].Value.ToString();
                        e_gender = row.Cells[5].Value.ToString();
                        e_marital = row.Cells[6].Value.ToString();
                        e_dob = row.Cells[7].Value.ToString();
                        e_postion = row.Cells[8].Value.ToString();
                        e_phonenumber = (int)Convert.ToInt64(row.Cells[9].Value);
                        e_address = row.Cells[10].Value.ToString();
                        e_city = row.Cells[11].Value.ToString();
                        e_town = row.Cells[12].Value.ToString();
                        e_mailaddress = row.Cells[13].Value.ToString();
                        e_hireDate = row.Cells[14].Value.ToString();
                        e_startDate = row.Cells[15].Value.ToString();
                        e_salary = Convert.ToInt32(row.Cells[16].Value);
                    }
                
             
                }
            }

        }
        private void employees_FormClosed(object sender, FormClosedEventArgs e)
        {
            
        }

        private void btn_Delete_Click(object sender, EventArgs e)
        {
            if (DialogResult.Yes == MessageBox.Show("Are you sure you want to delete selected employee?","Are you sure?", MessageBoxButtons.YesNo, MessageBoxIcon.Question))
            {
                try
                {

                    connect.Open();
                    OleDbCommand dcmd = new OleDbCommand("delete from Employees where ID =@id", connect);
                    dcmd.Parameters.AddWithValue("@id", e_ID);
                    dcmd.ExecuteNonQuery();
                    MessageBox.Show("Employee record has been deleted sucessfuly");                
                    OleDbCommand tcmd = new OleDbCommand("SELECT [ID], [DepartmentName], [image], [firstName], [lastName], [gender], [maritalStatus], [DOB], [position], [phoneNumber], [address], [city], [town], [mailAddress], [hireDate], [startDate], [salary] from Employees WHERE [CompanyID] = @companyid", connect);
                    tcmd.Parameters.AddWithValue("@companyid", companyID);
                    tcmd.ExecuteNonQuery();
                    OleDbDataAdapter da = new OleDbDataAdapter(tcmd);
                    DataTable dt = new DataTable();
                    da.Fill(dt);
                    dataGridView1.DataSource = dt;
                    connect.Close();
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error" + ex);
                }
            }
           
          
        
    }

        private void textBox1_Click(object sender, EventArgs e)
        {
            if (textBox1.Text == "" || textBox1.Text == "  Search")
            {
                textBox1.Clear();
            }
            textBox1.ForeColor = Color.Black;
            panel1.Visible = false;
            /*if (radioButton_firstName.Checked)
            {
                panel1.Visible = false;

                (dataGridView1.DataSource as DataTable).DefaultView.RowFilter = string.Format("firstName LIKE '{0}%' OR firstName LIKE '% {0}%'", textBox1.Text);
            }
            else
            {
                panel1.Visible = false;

                (dataGridView1.DataSource as DataTable).DefaultView.RowFilter = string.Format("DepartmentName LIKE '{0}%' OR DepartmentName LIKE '% {0}%'", textBox1.Text);

            }*/
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            textBox1.ForeColor = Color.Black;
            if (checkBox_firstName.Checked)
            {
                panel1.Visible = false;
              
                (dataGridView1.DataSource as DataTable).DefaultView.RowFilter = string.Format("firstName LIKE '{0}%' OR firstName LIKE '% {0}%'", textBox1.Text);
            }
            else if (checkBox_Department.Checked)
            {            
                
                panel1.Visible = false;
                checkBox_firstName.Checked = false;
                (dataGridView1.DataSource as DataTable).DefaultView.RowFilter = string.Format("DepartmentName LIKE '{0}%' OR DepartmentName LIKE '% {0}%'", textBox1.Text);

            }
            else
            {
                (dataGridView1.DataSource as DataTable).DefaultView.RowFilter = string.Format("firstName LIKE '{0}%' OR firstName LIKE '% {0}%'", "");
            }
        }

        private void textBox1_Leave(object sender, EventArgs e)
        {
            if (textBox1.Text == "")
            {
                textBox1.Text = "  Search";
                textBox1.ForeColor = SystemColors.ControlDark;
            }
            
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            textBox1.Text = "  Search";
            textBox1.ForeColor = SystemColors.ControlDark;
            if (panel1.Visible==true)
            {
                panel1.Visible = false;
            }
        }

        private void pictureBox2_Click(object sender, EventArgs e)
        {
            panel1.Visible = true;
        }

        private void checkBox_Department_CheckedChanged(object sender, EventArgs e)
        {
          
                checkBox_firstName.CheckState = CheckState.Unchecked;
           
        }

        private void checkBox_firstName_CheckedChanged(object sender, EventArgs e)
        {
 
            
                checkBox_Department.CheckState = CheckState.Unchecked;
            
        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex==-1)
            {
                return;
            }
        }
    }
}


