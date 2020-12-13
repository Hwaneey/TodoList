using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;

namespace TodoList
{
    public partial class del : UserControl
    {
        public event EventHandler onChange = null;

        public event EventHandler onDelete = null;

        public string key = null;

        public string value = null;

        public del(String Text)
        {
            InitializeComponent();

            value = Text;

            label1.Text = Text;

            checkBox1.Checked = false;
        }

        // 체크박스 체크 이벤트
        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBox1.Checked)
            {
                this.BackColor = Color.LightGreen;
                label1.Font = new Font(label1.Font.Name, label1.Font.SizeInPoints, FontStyle.Strikeout);
            }
            else
            {
                this.BackColor = Color.Gainsboro;
                label1.Font = new Font(label1.Font.Name, label1.Font.SizeInPoints, FontStyle.Regular);
            }

        }

        
        private void todo_Item_Load(object sender, EventArgs e)
        {
            if (checkBox1.Checked)
            {
                label1.Font = new Font(label1.Font.Name, label1.Font.SizeInPoints, FontStyle.Strikeout);
            }
            else
            {
                label1.Font = new Font(label1.Font.Name, label1.Font.SizeInPoints, FontStyle.Regular);
            }
            if (onChange != null)
            {
                onChange.Invoke(this, new EventArgs());
            }

        }

        // LIST 삭제
        private void pictureBox1_Click(object sender, EventArgs e)
        {
            SqlConnection connection = new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\Users\GeonHa\Documents\TodoList.mdf;Integrated Security=True;Connect Timeout=30");

            string sql = "DELETE FROM ITEMLIST WHERE text='" + label1.Text + "' ";
            try
            {
                using (connection)
                {
                    connection.Open();

                    SqlCommand command = new SqlCommand(sql, connection);

                    command.ExecuteNonQuery();

                }

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }

            connection.Close();

            if (onDelete != null)
            {
                onDelete.Invoke(this, new EventArgs());
            }

            this.BackColor = Color.Tomato;

            label1.Text = "삭제되었습니다.";

            checkBox1.Enabled = false;
        }
    }
}