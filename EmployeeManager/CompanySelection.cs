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
    public partial class CompanySelection : Form
    {
        public static string accountId { get; set; }

        OleDbConnection connect = new OleDbConnection();
        public CompanySelection()
        {
            InitializeComponent();
            connect.ConnectionString = (@"Provider=Microsoft.ACE.OLEDB.12.0;Data Source=C:\Users\Engin\Documents\EmployeeManager.accdb");

        }

        private void btn_Add_Click(object sender, EventArgs e)
        {
            try
            {
                connect.Open();

                OleDbCommand scmd = new OleDbCommand("SELECT * FROM Account WHERE username = '" + login.userName + "' ", connect);
                scmd.Parameters.AddWithValue("@username", login.userName);
                OleDbDataReader reader = scmd.ExecuteReader();

                while (reader.Read())
                {
                    //accountId = reader.GetInt32(0).ToString();
                    //accountId = reader[0].ToString();
                    accountId = reader.GetValue(0).ToString();
                }

                reader.Close();

                Form1 f1 = new Form1();
                f1.Show();

                connect.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error" + ex);
            }
            this.Hide();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            editCompany ec = new editCompany();
            ec.Show();
            this.Hide();
        }

        private void CompanySelection_FormClosed(object sender, FormClosedEventArgs e)
        {

        }

        private void CompanySelection_Load(object sender, EventArgs e)
        {

        }
    }
}
