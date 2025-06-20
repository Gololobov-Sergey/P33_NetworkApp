using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;

namespace TCP_Server
{
    internal class TCP_ClientConnection
    {
        static int count = 0;

        public int Id { get; private set; }

        TcpClient client;

        public event Action<TCP_ClientConnection, string> IncomingMessage;

        public event Action<TCP_ClientConnection> DisconnectMessage;

        public TCP_ClientConnection(TcpClient client)
        {
            Id = ++count;
            this.client = client;
        }

        public Task WorkAsync() => Task.Run(Work);

        public void Work()
        {
            if (client == null || !client.Connected)
                return;

            NetworkStream stream = client.GetStream();
            byte[] buffer;
            if (stream != null)
            {
                buffer = Encoding.UTF8.GetBytes($"Hello, current time {DateTime.Now}");
                stream.Write(buffer, 0, buffer.Length);
            }


            buffer = new byte[4096];
            int bytes;
            

            try
            {
                while (true)
                {
                    
                    StringBuilder? builder = new StringBuilder();
                    do
                    {
                        bytes = stream.Read(buffer, 0, buffer.Length);
                        
                        builder.Append(Encoding.UTF8.GetString(buffer));
                    } while (stream.DataAvailable);

                    if (bytes == 0)
                        break;
                    IncomingMessage?.Invoke(this, builder.ToString());

                    if (builder.ToString().CompareTo("exit") == 0)
                    {
                        break;
                    }

                    builder = null;
                }
            }
            catch (Exception)
            {

            }

            try
            {
                client.Close();
            }
            catch (Exception)
            {

            }

        }
    }
}
