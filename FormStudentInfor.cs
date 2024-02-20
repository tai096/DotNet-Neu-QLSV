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
    public partial class FormStudentInfor : Form
    {
        public FormStudentInfor()
        {
            InitializeComponent();
        }

        DatabaseConnection kn = new DatabaseConnection();

        public void GetDataStudent()
        {
            DataTable data = new DataTable();
            data = kn.Get_Table("Select * From SINHVIEN");
            dataGridViewStudent.DataSource = data;
        }

        public void GetDataClass()
        {
            DataTable data = new DataTable();
            data = kn.Get_Table("Select MALOP, TENLOP From LOP");
            //comboBoxClassID.Value = data;
        }

        private void FrmStudent_Load(object sender, EventArgs e)
        {
            GetDataStudent();
        }

        private void comboBoxClassID_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void textBoxStudentID_TextChanged(object sender, EventArgs e)
        {

        }

        private void buttonAddNew_Click(object sender, EventArgs e)
        {
            textBoxStudentID.Text = "";
            textBoxStudentID.Focus();
            textBoxName.Text = "";
            textBoxAddress.Text = "";
            dTPDate.Text = "";
            radioButtonMale.Checked = false;
            radioButtonFemale.Checked = false;
        }

        private void buttonInsert_Click(object sender, EventArgs e)
        {
            String studentID = textBoxStudentID.Text;
            String name = textBoxName.Text;
            String date = dTPDate.Text;
            String address = textBoxAddress.Text;
            String sex = "1";

            if(radioButtonMale.Checked == true)
            {
                sex = "1";
            }
            if (radioButtonFemale.Checked == true)
            {
                sex = "0";
            }


            String sqlInsert = $"INSERT INTO SINHVIEN VALUES('{studentID}', '{name}', '{sex}', '{date}', '{address}', 'CNTTK63A')";
            kn.Insert_Data(sqlInsert);
            GetDataStudent();
        }
    }
}
