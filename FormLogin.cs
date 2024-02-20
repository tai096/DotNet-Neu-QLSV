using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;

namespace TrinhDangTai_Bai3_Test
{
    public partial class FormLogin : Form
    {
        DatabaseConnection connectDb = new DatabaseConnection();

        public FormLogin()
        {
            InitializeComponent();
        }

        private void txtName_Click(object sender, EventArgs e)
        {

        }

        private void btnLogin_Click(object sender, EventArgs e)
        {
            connectDb.Connect_Db();

            string name = inputName.Text;
            string password = inputPassword.Text;
            string sql_login;

            sql_login = "SELECT acc, pass FROM LOGIN WHERE acc ='" + name + "' and pass = '" + password + "'";

            SqlCommand cmd = new SqlCommand(sql_login, connectDb.cnn);
            SqlDataReader dataReader = cmd.ExecuteReader();

            Console.WriteLine(name);
            Console.WriteLine(password);

            if (dataReader.Read() == true)
            {
                MessageBox.Show("Login successfully");
            }
            else
            {
                MessageBox.Show("Login failed");
            }
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            Application.Exit();

        }

        private void inputPassword_TextChanged(object sender, EventArgs e)
        {

        }

        private void inputName_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
