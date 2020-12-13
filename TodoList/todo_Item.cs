using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

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
            //key = Key;
            value = Text;
            label1.Text = Text;
            checkBox1.Checked = false;
        }

        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBox1.Checked)
            {
                //this.BackColor = Color.LightGreen;
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

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            this.BackColor = Color.Tomato;
            label1.Text = "Deleted";
            checkBox1.Enabled = false;

            if (onDelete != null)
            {
                onDelete.Invoke(this, new EventArgs());
            }
        }
    }
}
