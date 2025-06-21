using System.Net;
using System.Net.Sockets;
using System.Text;

namespace MulticastClient
{
    public partial class Form1 : Form
    {
        delegate void AppendText(string text);

        Thread thread;

        public Form1()
        {
            InitializeComponent();
            thread = new Thread(new ThreadStart(MulticastReceive)); 
            thread.IsBackground = true;
            thread.Start();
        }



        void MulticastReceive()
        {
            while (true)
            {
                Socket socket = new Socket(AddressFamily.InterNetwork, SocketType.Dgram, ProtocolType.Udp);
                IPEndPoint endPoint = new IPEndPoint(IPAddress.Any, 4567);
                socket.Bind(endPoint);
                IPAddress ip = IPAddress.Parse("224.5.5.5");
                socket.SetSocketOption(SocketOptionLevel.IP, SocketOptionName.AddMembership, new MulticastOption(ip, IPAddress.Any));
                byte[] buffer = new byte[1024];
                socket.Receive(buffer);
                Invoke(new AppendText(AppendTextToTextBox), Encoding.UTF8.GetString(buffer));
                socket.Close();
            }
        }

        void AppendTextToTextBox(string message)
        {
            textBox1.Text = message;
        }
    }
}
