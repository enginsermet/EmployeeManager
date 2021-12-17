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
    public partial class Departments : Form
    {

        OleDbConnection connect = new OleDbConnection();
        public static string accountId { get; set; }
        public static string companyID { get; set; }

        public static int departmentID { get; set; }
        public Departments()
        {
            InitializeComponent();
            connect.ConnectionString = (@"Provider=Microsoft.ACE.OLEDB.12.0;Data Source=C:\Users\Engin\Documents\EmployeeManager.accdb");
        }

        private void btn_Add_Click(object sender, EventArgs e)
        {
            department de = new department();
            de.Show();
            this.Close();
        }

        private void Departments_Load(object sender, EventArgs e)
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
                        companyID = comreader.GetValue(0).ToString();
                    }

                }

                connect.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error" + ex);
            }
            try {
                connect.Open();

                OleDbCommand tcmd = new OleDbCommand("SELECT [DepartmentID], [DepartmentName] FROM Department WHERE [CompanyID] = @companyid", connect);
                tcmd.Parameters.AddWithValue("@companyid", companyID);
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

        private void btn_Delete_Click(object sender, EventArgs e)
        {
            if (DialogResult.Yes == MessageBox.Show("Are you sure you want to delete selected department?", "Are you sure?", MessageBoxButtons.YesNo, MessageBoxIcon.Question))
            {
                try
                {
                    connect.Open();
                    OleDbCommand dcmd = new OleDbCommand("delete from Department where [DepartmentID] = @departmentID", connect);
                    dcmd.Parameters.AddWithValue("@departmentID", departmentID);
                    dcmd.ExecuteNonQuery();
                    MessageBox.Show("Department has been deleted sucessfuly");
                    OleDbCommand tcmd = new OleDbCommand("SELECT [DepartmentID], [DepartmentName] from Department WHERE [CompanyID] = @companyid", connect);
                    tcmd.Parameters.AddWithValue("@companyid", companyID);
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

        private void Departments_FormClosed(object sender, FormClosedEventArgs e)
        {

        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void dataGridView1_SelectionChanged(object sender, EventArgs e)
        {
            foreach (DataGridViewRow row in dataGridView1.SelectedRows)
            {
                if (row.Cells[0].Value == DBNull.Value)
                {
                    return;
                }
                else
                {
                    departmentID = (int)Convert.ToInt64(row.Cells[0].Value);
                }
                


            }

        }
    }
}
