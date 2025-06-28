using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MailClientForm
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void aboutToolStripMenuItem_Click(object sender, EventArgs e)
        {
            //Process.Start("chrome.exe", "http://google.com");

            Form form = new AboutForm();
            form.ShowDialog();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Form sendForm = new SendMessageForm();
            sendForm.ShowDialog();
        }
    }
}
