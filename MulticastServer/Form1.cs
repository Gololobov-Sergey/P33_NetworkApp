using System.Net;
using System.Net.Sockets;
using System.Text;

namespace MulticastServer
{
    public partial class Form1 : Form
    {
        static int interval = 1000;
        static string message = "";


        public Form1()
        {
            InitializeComponent();
            thread.IsBackground = true;
            thread.Start();
        }

        Thread thread = new Thread(new ThreadStart(MulticastSend));

        static void MulticastSend()
        {
            while (true)
            {
                Thread.Sleep(interval);
                Socket socket = new Socket(AddressFamily.InterNetwork, SocketType.Dgram, ProtocolType.Udp);
                socket.SetSocketOption(SocketOptionLevel.Socket, SocketOptionName.Broadcast, true);
                IPAddress dest = IPAddress.Parse("224.5.5.5");
                IPEndPoint endpoin = new IPEndPoint(dest, 4567);
                socket.Connect(endpoin);
                socket.Send(Encoding.UTF8.GetBytes(message));
                socket.Close();
            }
            
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            message = textBox1.Text;
        }
    }
}
