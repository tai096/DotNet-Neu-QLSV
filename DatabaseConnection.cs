using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;

namespace TrinhDangTai_Bai3_Test
{
    class DatabaseConnection
    {
        public SqlConnection cnn;
        public SqlCommand cmd;
        public DataTable dta;
        public SqlDataAdapter ada;

        public void Connect_Db()
        {
            string dbUrl = @"Data Source= Admin\SQLEXPRESS;Initial Catalog=DOTNETK63_QUANLYSV;Integrated Security=True";
            cnn = new SqlConnection(dbUrl);
            cnn.Open();
        }

        public void Disconnect_Db()
        {
            if (cnn.State == ConnectionState.Open)
            {
                cnn.Close();
            }
        }

        public DataTable Get_Table(string Sql)
        {
            Connect_Db();
            ada = new SqlDataAdapter(Sql, cnn);
            dta = new DataTable();
            ada.Fill(dta);

            return dta;
        }

        public void Insert_Data(string Sql)
        {
            Connect_Db();
            cmd = new SqlCommand(Sql, cnn);
            cmd.ExecuteNonQuery();
            Disconnect_Db();
        }
    }
}
