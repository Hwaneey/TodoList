using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Runtime.InteropServices;
using System.Security.Cryptography;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace TodoList
{
    public partial class SignUpForm : Form
    {
        bool On;
        Point Pos;
        DAO dao = new DAO();
        Security security = new Security();

        public SignUpForm()
        {
            InitializeComponent();

            //폼 모서리 둥글게
            Region = System.Drawing.Region.FromHrgn(CreateRoundRectRgn(0, 0, Width, Height, 20, 20));

            //폼 마우스 클릭시 이동
            formMoving();
        }

        private void formMoving()
        {
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

        public void BackButton()
        {
            this.Hide();
            LoginForm loginForm = new LoginForm();
            loginForm.ShowDialog();
            this.Close();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            BackButton();
        }


        private void button1_Click(object sender, EventArgs e)
        {
            if (security.IsValidEmail(SignUpEmailForm.Text) == false)
            {
                MessageBox.Show("이메일 형식에 어긋났습니다. 다시 작성해주세요","Error");
                return;
            }
            if (signUpusernameForm.Text == "")
            {
                MessageBox.Show("이름 을 입력해주세요", "Error");
                signUpusernameForm.Focus();
                return;
            }
            if (!passwordForm.Text.Equals(rePasswordForm.Text))
            {
                MessageBox.Show("비밀번호를 다시 확인해주세요 ","Error");
                return;
            }
            dao.SignUp(SignUpEmailForm.Text, signUpusernameForm.Text, security.EncryptSHA256_EUCKR(passwordForm.Text));

        }
    }
}
