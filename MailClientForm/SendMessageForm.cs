using MailKit.Net.Smtp;
using MimeKit;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MailClientForm
{
    public partial class SendMessageForm : Form
    {
        public SendMessageForm()
        {
            InitializeComponent();
            comboBox1.SelectedIndex = 0;
            comboBox2.SelectedIndex = 0;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            var message = new MimeMessage();
            message.From.Add(new MailboxAddress("Від кого", comboBox2.SelectedItem.ToString()));
            message.To.Add(new MailboxAddress("Кому", comboBox1.SelectedItem.ToString()));
            message.Subject = textBox1.Text;

            

            message.Body = new TextPart("plain")
            {
                Text = textBox4.Text
            };

            using (var client = new SmtpClient())
            {
                try
                {
                    client.Connect("smtp.gmail.com", 587, MailKit.Security.SecureSocketOptions.StartTls);

                    client.Authenticate("gololobov.serhiy@gmail.com", "lovk iojp teup gdsz");

                    client.Send(message);

                    MessageBox.Show("Повідомлення відправлене", "MailClient", MessageBoxButtons.OK ,MessageBoxIcon.Information);

                    client.Disconnect(true);

                    this.Visible = false;   
                    this.Close();
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message, "MailClient", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }

            }
        }
    }
}
