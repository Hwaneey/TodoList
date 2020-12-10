using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace TodoList
{
    public partial class SignUpForm : Form
    {
        bool On;
        Point Pos;
        LoginForm loginForm = new LoginForm();

        public SignUpForm()
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
        private void SignUpForm_Load(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Hide();
            LoginForm loginForm= new LoginForm();
            loginForm.ShowDialog();
            this.Close();
        }

        private void usernameForm_TextChanged(object sender, EventArgs e)
        {
       
        }

        private void SignUpEmailForm_TextChanged(object sender, EventArgs e)
        {
        }

        private void passwordForm_TextChanged(object sender, EventArgs e)
        {
         
        }

        private void panel4_Paint(object sender, PaintEventArgs e)
        {

        }
    }
}
