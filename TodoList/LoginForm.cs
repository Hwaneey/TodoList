using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace TodoList
{
    public partial class LoginForm : Form
    {
        bool On;

        Point Pos;

        Security security = new Security();

        DAO dao = new DAO();


        public LoginForm()
        {
            InitializeComponent();

            //폼 모서리 둥글게
            Region = System.Drawing.Region.FromHrgn(CreateRoundRectRgn(0, 0, Width, Height, 20, 20));

            //폼 마우스 클릭시 이동
            MouseDown += (o, e) => { if (e.Button == MouseButtons.Left) { On = true; Pos = e.Location; } };
            MouseMove += (o, e) => { if (On) Location = new Point(Location.X + (e.X - Pos.X), Location.Y + (e.Y - Pos.Y)); };
            MouseUp += (o, e) => { if (e.Button == MouseButtons.Left) { On = false; Pos = e.Location; } };
        }

        [DllImport("Gdi32.dll", EntryPoint = "CreateRoundRectRgn")]
        private static extern IntPtr CreateRoundRectRgn
        (
            int nLeftRect, // x-coordinate of upper-left corner
            int nTopRect, // y-coordinate of upper-left corner
            int nRightRect, // x-coordinate of lower-right corner
            int nBottomRect, // y-coordinate of lower-right corner
            int nWidthEllipse, // height of ellipse
            int nHeightEllipse // width of ellipse
         );
 
        private void button2_Click_1(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void label1_Click(object sender, EventArgs e)
        {
            this.Hide();

            SignUpForm signUpForm = new SignUpForm();

            signUpForm.ShowDialog();

            this.Close();
        }

        private void loginButton_Click(object sender, EventArgs e)
        {
            if (emailForm.Text == "")
            {
                MessageBox.Show("E-mail을 입력해주세요", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                emailForm.Focus();
                return;
            }
            if (passwordForm.Text == "")
            {
                MessageBox.Show("비밀번호를 입력해주세요", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                passwordForm.Focus();
                return;
            }
            dao.Login(emailForm.Text, security.EncryptSHA256_EUCKR(passwordForm.Text));

            this.Hide();

            TodoList mainTodoList = new TodoList();
            
            mainTodoList.ShowDialog();
            
            this.Close();
        }



        private void passwordForm_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                loginButton_Click(sender, e);
                loginButton.Select();
            }
            
        }
    }
}
 