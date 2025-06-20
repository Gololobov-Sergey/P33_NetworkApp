using System.Net;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace TCP_Client
{
    public partial class Form1 : Form
    {
        UserConnection? client = null;

        public Form1()
        {
            InitializeComponent();

        }

        private async void btnConnect_Click(object sender, EventArgs e)
        {
            try
            {
                if (txtNameUser.Text == string.Empty)
                {
                    MessageBox.Show("Name is not define!!!", "Chat");
                    return;
                }
                client = new UserConnection(
                    txtNameUser.Text,
                    IPAddress.Parse(txtIPAddress.Text),
                    (int)numPort.Value
                    );

                client.ConnectedEstablished += Client_ConnectedEstablished;
                client.IncomingMessage += Client_IncomingMessage;

                await client.ConnectAsync();
                await client.ReadMessageAsync();
            }
            catch (Exception ex)
            {
                client = null;
                Client_IncomingMessage($"Error: {ex.Message}");
            }

        }

        private void Client_IncomingMessage(string message)
        {
            BeginInvoke(new Action(() =>
            {
                /// TODO: Update the UI with the received message
                richTextBox1.Text += $"{message}\n";
            }));
        }

        private void Client_ConnectedEstablished(bool connected)
        {
            BeginInvoke(new Action(() =>
            {
                if (connected)
                {
                    btnConnect.Enabled = false;
                    btnDisconnect.Enabled = true;
                    txtIPAddress.Enabled = false;
                    txtNameUser.Enabled = false;
                    numPort.Enabled = false;
                    tabControl.Enabled = true;
                    txtMessage.Enabled = true;
                    btnSend.Enabled = true;
                }
                else
                {
                    btnConnect.Enabled = true;
                    btnDisconnect.Enabled = false;
                    txtIPAddress.Enabled = true;
                    txtNameUser.Enabled = true;
                    numPort.Enabled = true;
                    tabControl.Enabled = false;
                    txtMessage.Enabled = false;
                    btnSend.Enabled = false;
                    //
                    //
                    richTextBox1.Text += "Disconnect\n";

                }
            }));
        }

        private void Form1_FormClosing(object sender, FormClosingEventArgs e)
        {
            try
            {
                if (client != null)
                {
                    client.Disconnect();
                }
            }
            catch { }
        }

        private void btnDisconnect_Click(object sender, EventArgs e)
        {
            Form1_FormClosing(sender, null);
        }

        private async void btnSend_Click(object sender, EventArgs e)
        {
            if (client != null && client.Connected)
            {
                if (txtMessage.Text == string.Empty)
                {
                    return;
                }

                btnSend.Enabled = false;
                await client.SendMessageAsync(txtMessage.Text);

                /// TODO: Update the UI with the sent message
                richTextBox1.Text += $"{client.Name}: {txtMessage.Text}\n";

                txtMessage.Clear();
                txtMessage.Focus();
                btnSend.Enabled = true;

                await client.ReadMessageAsync();
                
            }
            else
            {
                MessageBox.Show("You are not connected to the server!", "Chat");
            }
        }
    }
}



/////////////////
///

//TabPage tabPage = new TabPage();
//tabPage.Location = new Point(4, 24);
//tabPage.Name = $"tabPage{tabControl.TabPages.Count + 1}";
//tabPage.Padding = new Padding(3);
//tabPage.Size = new Size(572, 261);
//tabPage.TabIndex = 0;
//tabPage.Text = "Anna";

//tabControl.Controls.Add(tabPage);

//RichTextBox richTextTextBox = new RichTextBox();
//richTextTextBox.Dock = DockStyle.Fill;
//richTextTextBox.ReadOnly = true;

//tabPage.Controls.Add(richTextTextBox);