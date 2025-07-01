using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Form_Test
{
    public partial class Parent : Form
    {
        public Parent()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            //1

            //Form form = new Child(textBox1.Text);
            //form.ShowDialog();

            // 2
            //Child form = new Child();
            //form.ChText = textBox1.Text;
            //form.ShowDialog();

            // 3
            //Child form = new Child();
            //form.ShowDialog(textBox1.Text);
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            Child form = new Child("", true);
            if (form.ShowDialog() == DialogResult.OK)
            {
                listBox1.Items.Add(form.ChText);
            }
        }

        private void btnEdit_Click(object sender, EventArgs e)
        {
            if(listBox1.SelectedIndex == -1)
            {
                MessageBox.Show("Enter list item!");
                return;
            }

            int n = listBox1.SelectedIndex;

            Child form = new Child(listBox1.Items[n].ToString(), false);
            if (form.ShowDialog() == DialogResult.OK)
            {
                listBox1.Items.RemoveAt(n);
                listBox1.Items.Insert(n, form.ChText);
            }
        }
    }
}
