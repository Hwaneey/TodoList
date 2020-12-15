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

        public object sessionId = null;

        private void SignUpSuccess()
        {
            SignUpForm signUpForm = new SignUpForm();
            signUpForm.BackButton();
        }

        public void SignUp(string email, string username, string password)
        {
            String sql = "INSERT INTO USERINFO VALUES('" + email.Trim() + "' ,N'" + username.Trim() + "', '" + password.Trim() + "' )";

            try
            {
                connection.Open();

                SqlCommand command = new SqlCommand(sql, connection);
                
                if (command.ExecuteNonQuery() == 1)
                {
                    MessageBox.Show("회원가입이 성공하였습니다!");

                    SignUpSuccess();
                }

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }

            connection.Close();
        }

        private void LoginSuccess()
        {
            TodoList mainTodoList = new TodoList();
            LoginForm loginForm = new LoginForm();
            loginForm.Hide();
            mainTodoList.ShowDialog();
            loginForm.Close();
        }

        public void Login(string email, string password)
        {
            string sql = "SELECT * FROM userinfo where email='" + email + "' AND password='" + password + "'";

            try
            {
                connection.Open();

                SqlCommand comand = new SqlCommand(sql, connection);

                SqlDataReader dataReader = comand.ExecuteReader();

                if (dataReader.Read())
                {
                    MessageBox.Show("어서오세요 " + dataReader["username"] + "님");

                    TodoList.seesionId = dataReader["id"];

                    LoginSuccess();

                }
                else
                {
                    MessageBox.Show("아이디와패스워드를 확인해주세요");

                    return;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }

            connection.Close();

        }


    }
}