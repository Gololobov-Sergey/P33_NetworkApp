using MailKit.Net.Imap;
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
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace MailClientForm
{
    public partial class Form1 : Form
    {
        List<string> emailTo = new List<string>
        {
            "gololobov.seghiy@gmail.com",
            "probogdan88 @gmail.com"
        };

        List<EmailMessage> emailMessages = new List<EmailMessage>();    

        public Form1()
        {
            InitializeComponent();
            // load emails to emailTo

            // load email
            LoadEmailMessage();
        }


        void LoadEmailMessage()
        {
            string email = "gololobov.serhiy@gmail.com";
            string password = "lovk iojp teup gdsz";
            string imapServer = "imap.gmail.com";
            int port = 993;

            using (var client = new ImapClient())
            {
                try
                {
                    client.Connect(imapServer, port, MailKit.Security.SecureSocketOptions.SslOnConnect);
                    client.Authenticate(email, password);
                    var inbox = client.Inbox;
                    inbox.Open(MailKit.FolderAccess.ReadOnly);
                    Console.WriteLine($"Листів у вхідних : {inbox.Count}");

                    for (int i = inbox.Count - 1; i >= 0; i--)
                    {
                        var message = inbox.GetMessage(i);

                        EmailMessage message2 = new EmailMessage
                        {
                            From = message.From.ToString(),
                            To = message.To.ToString(),
                            Subject = message.Subject,
                            Date = message.Date.DateTime,
                            Body = message.TextBody?.ToString(),
                            HTML = message.HtmlBody?.ToString()
                        };

                        ListViewItem lvi = new ListViewItem(message2.From);
                        lvi.SubItems.Add(message2.To);
                        lvi.SubItems.Add(message2.Date.ToString());
                        lvi.SubItems.Add(message2.Subject);
                        lvi.SubItems.Add(message2.Body ?? message2.HTML);
                        listView1.Items.Add(lvi);

                        emailMessages.Add(message2);
                    }

                    client.Disconnect(true);
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                }
            }
        }


        private void aboutToolStripMenuItem_Click(object sender, EventArgs e)
        {
            //Process.Start("chrome.exe", "http://google.com");

            Form form = new AboutForm();
            form.ShowDialog();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            int count = emailTo.Count;
            SendMessageForm sendForm = new SendMessageForm();
            sendForm.EmailTo = emailTo;
            if(sendForm.ShowDialog() == DialogResult.OK)
            {
                emailTo = sendForm.EmailTo;
                if (emailTo.Count != count)
                {
                    // save to file
                }
            }
        }

        private void listView1_SelectedIndexChanged(object sender, EventArgs e)
        {
            System.Windows.Forms.ListView item = ((System.Windows.Forms.ListView)sender);
            int index = item.FocusedItem.Index;
            richTextBox1.Text = emailMessages[index].Body ?? emailMessages[index].HTML;

            // Fix for CS1729: Use the existing HtmlDocument instance from the WebBrowser control  
            var html = webBrowser1.Document;
            if (html != null)
            {
                html.Body.InnerHtml = emailMessages[index].HTML;
            }
        }
    }
}
