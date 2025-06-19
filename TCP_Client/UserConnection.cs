using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;

namespace TCP_Client
{
    internal class UserConnection
    {
        TcpClient? tcpClient;
        IPAddress IPAddress;
        int port;
        public string Name { get; set; }

        public bool Connected => tcpClient != null && tcpClient.Connected;

        public event Action<bool>? ConnectedEstablished;

        public event Action<string>? IncomingMessage;


        public UserConnection(string name, IPAddress address, int port)
        {
            Name = name;
            IPAddress = address;
            this.port = port;
            tcpClient = new TcpClient();
        }


        public async Task ConnectAsync() => await Task.Factory.StartNew(Connect); 

        public void Connect()
        {
            if (tcpClient != null && tcpClient.Connected)
            {
                return;
            }

            try
            {
                tcpClient!.Connect(IPAddress, port);
                ConnectedEstablished?.Invoke(true);
            }
            catch (Exception)
            {
                tcpClient = null;
                ConnectedEstablished?.Invoke(false);
            }
        }

        public void Disconnect()
        {
            try
            {
                if(tcpClient != null && tcpClient.Connected)
                {
                    SendMessage("Disconnect");
                    tcpClient.Close();  
                }
            }
            finally
            {
                tcpClient = null;
                ConnectedEstablished?.Invoke(false);
            }
        }


        public async Task SendMessageAsync(string message) => await Task.Run(() => SendMessage(message));

        public void SendMessage(string message)
        {
            if(tcpClient == null || !tcpClient.Connected)
            {
                return;
            }

            NetworkStream networkStream = tcpClient.GetStream();

            try
            {
                byte[] buffer = Encoding.UTF8.GetBytes(message);
                networkStream.Write(buffer, 0, buffer.Length);

            }
            catch (Exception)
            {

            }
        }




    }
}
