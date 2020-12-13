using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace TodoList
{
    public partial class TodoList : Form
    {
        bool On;

        Point Pos;

        int poss = 10;

        public static object seesionId;

        public TodoList()
        {
            InitializeComponent();

            GetItem(seesionId);

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

        //List item 추가
        public void AddItem(string Text)
        {
            del item = new del(Text);

            panel2.Controls.Add(item);

            item.Top = poss;

            poss = (item.Top + item.Height + 10);
        }

        // Insert버튼 이벤트 
        private void pictureBox1_Click(object sender, EventArgs e)
        {
            if (textBox1.Text.Trim().Length == 0)
            {
                MessageBox.Show("문자를 적어주세요");

                return;
            }
            AddItem(textBox1.Text);

            AddList(textBox1.Text, seesionId);

            textBox1.Text = "";
        }

        // DB연동후 LIST 가져오기
        public void GetItem(object seesionId)
        {
            SqlConnection connection = new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\Users\GeonHa\Documents\TodoList.mdf;Integrated Security=True;Connect Timeout=30");

            string sql = "SELECT * FROM ITEMLIST where ID='" + seesionId + "'";

            try
            {
                using (connection)
                {
                    connection.Open();

                    SqlCommand command = new SqlCommand(sql, connection);

                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            AddItem("" + reader["text"]);
                        }
                        connection.Close();
                    }
                    
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }


        }
        // DB LIST 추가
        public void AddList(string text, object sessionId)
        {
            SqlConnection connection = new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\Users\GeonHa\Documents\TodoList.mdf;Integrated Security=True;Connect Timeout=30");

            String sql = "INSERT INTO ITEMLIST (TEXT,ID) VALUES( '" + text + "','" + seesionId + "')";

            using (connection)
            {
                try
                {
                    connection.Open();

                    SqlCommand command = new SqlCommand(sql, connection);

                    command.ExecuteNonQuery();

                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
                connection.Close();
            }
        }

    }
}


