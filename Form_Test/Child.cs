using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Net.Mime.MediaTypeNames;

namespace Form_Test
{
    public partial class Child : Form
    {
        //2

        public string ChText
        {
            set
            {
                textBox1.Text = value;
            }
            get
            {
                return textBox1.Text;
            }
        }


        public Child(string text, bool add_edit) // add = true
        {
            InitializeComponent();
            if (add_edit)
            {
                textBox1.Text = "";
                this.Text = "Add";
            }
            else
            {
                textBox1.Text = text;
                this.Text = "Edit";
            }
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
        }

        /// #1
        //public Child(string text)
        //{
        //    InitializeComponent();
        //    textBox1.Text = text;
        //}


        //3

        //public DialogResult ShowDialog(string text)
        //{
        //    textBox1.Text = text;
        //    return ShowDialog();
        //}

        private void btnOk_Click(object sender, EventArgs e)
        {
            if(string.IsNullOrWhiteSpace(textBox1.Text))
            {
                MessageBox.Show("Enter text!", this.Text);
                return;
            }

            this.DialogResult = DialogResult.OK;
        }
    }
}
