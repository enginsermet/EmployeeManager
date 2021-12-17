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
    public partial class department : Form
    {
        OleDbConnection connect = new OleDbConnection();
        public static string accountId { get; set; }
        public static string companyId { get; set; }

        public department()
        {
            InitializeComponent();
            connect.ConnectionString = (@"Provider=Microsoft.ACE.OLEDB.12.0;Data Source=C:\Users\Engin\Documents\EmployeeManager.accdb");

            label1.BackColor = System.Drawing.Color.Transparent;
        }

        private void department_Load(object sender, EventArgs e)
        {
            try
            {

                connect.Open();

                OleDbCommand acccmd = new OleDbCommand("SELECT [AccountID] FROM Account WHERE username = @username", connect);
                acccmd.Parameters.AddWithValue("@username", login.userName);
                OleDbDataReader reader = acccmd.ExecuteReader();

                while (reader.Read())
                {
                    accountId = reader.GetValue(0).ToString();
                   
                    
                }

                OleDbCommand scmd = new OleDbCommand("SELECT [CompanyID] FROM Company WHERE AccountID = @accountID", connect);
                scmd.Parameters.AddWithValue("@accountID", accountId);
                OleDbDataReader sreader = scmd.ExecuteReader();

                while (sreader.Read())
                {
                    companyId = sreader.GetValue(0).ToString();
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
            if (txt_Department.Text == "")
            {
                MessageBox.Show("Department Name field can not be empty", "", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            try
            {
                connect.Open();
                OleDbCommand command = new OleDbCommand("insert into Department([CompanyID], [DepartmentName]) values(@companyid, @departmentName)", connect);
                command.Parameters.AddWithValue("@companyid", companyId);
                command.Parameters.AddWithValue("@departmentName", txt_Department.Text);
    



                command.ExecuteNonQuery();
                connect.Close();
                MessageBox.Show("Department has been added successfuly", "", MessageBoxButtons.OK);
                this.Close();


            }
            catch (Exception ex)
            {
                MessageBox.Show("Error" + ex);
            }
        }

        private void department_FormClosed(object sender, FormClosedEventArgs e)
        {
            Departments dpts = new Departments();
            dpts.Show();
        }

        private void department_FormClosing(object sender, FormClosingEventArgs e)
        {        

        }
    }
}
