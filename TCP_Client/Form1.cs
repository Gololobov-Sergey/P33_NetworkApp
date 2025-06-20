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

                await client.ConnectAsync();

              

                
            }
            catch (Exception)
            {

                throw;
            }
           
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
                if(client != null)
                {
                    client.Disconnect();
                }
            }
            catch { }
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