using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;

namespace TCP_Server
{
    internal class TCP_Server
    {
        TcpListener? tcpListener;

        List<TCP_ClientConnection> clientConnections;

        public event Action<string>? Message;

        public TCP_Server(IPAddress iPAddress, int port)
        {
            tcpListener = new TcpListener(iPAddress, port);

            clientConnections = new List<TCP_ClientConnection>();
        }

        public Task StartAsync() => Task.Run(Start);

        public void Start()
        {
            try
            {
                Message?.Invoke($"Start server on {tcpListener!.LocalEndpoint}");
                tcpListener?.Start();
                Message?.Invoke("Wait connection...");
                while (true)
                {
                    TcpClient client = tcpListener!.AcceptTcpClient();

                    if (client != null)
                    {
                        Message?.Invoke($"Accept connection : {client.Client.RemoteEndPoint}");


                        //// v1
                        //NetworkStream networkStream = client.GetStream();
                        //if (networkStream != null)
                        //{
                        //    byte[] buffer = Encoding.UTF8.GetBytes($"Hello, current time {DateTime.Now}");
                        //    networkStream.Write( buffer, 0, buffer.Length );
                        //    client.Close();
                        //}


                        //// v2
                        TCP_ClientConnection clientConnection = new TCP_ClientConnection(client);
                        clientConnection.IncomingMessage += ClientConnection_IncomingMessage;
                        clientConnections.Add(clientConnection);
                        clientConnection.WorkAsync();


                    }
                }
            }
            catch (Exception ex)
            {
                Message?.Invoke(ex.Message);
            }
            finally
            {
                tcpListener?.Stop();
            }
            
        }

        private void ClientConnection_IncomingMessage(TCP_ClientConnection client, string message)
        {
            Message?.Invoke($"{DateTime.Now.ToShortTimeString()} {client.Id} {message}");
        }
    }
}
