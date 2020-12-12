using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace TodoList 
{
     class DAO 
    {
        SqlConnection connection = new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\Users\GeonHa\Documents\TodoList.mdf;Integrated Security=True;Connect Timeout=30");
        
        public void SignUp(string email ,string username, string password)
        {
            String sql = "INSERT INTO USERINFO VALUES('"+email.Trim()+"' ,N'"+username.Trim()+"', '"+password.Trim()+"' )";

            connection.Open();

            SqlCommand command = new SqlCommand(sql, connection);

            //예외 처리
            try
            {
                if (command.ExecuteNonQuery() == 1)
                {
                    //MessageBox.Show("DB CONNECTION");
                }
                else
                {
                    MessageBox.Show("NOT DB CONNECTION");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }

            connection.Close();
        }

        public void Login(string email, string password)
        { 
            string sql = "SELECT * FROM userinfo where email='" + email + "' AND password='" + password + "'";

            connection.Open();

            SqlCommand comand = new SqlCommand(sql, connection);

            SqlDataReader dataReader = comand.ExecuteReader();

            if (dataReader.Read())
            {
                
            }
            else
            {
                //MessageBox.Show("아이디와패스워드를 확인해주세요");
            }
            connection.Close();

        }

        public void AddItem(string item, bool check)
        {
            String sql = "INSERT INTO USERINFO VALUES(N'" + item.Trim() + "')";

            connection.Open();

            SqlCommand command = new SqlCommand(sql, connection);
        }

    }
}
