using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;

namespace Server
{
    internal class Server
    {

        const int port = 1000;

        static async Task Main(string[] args)
        {
            IPEndPoint iPEndPoint = new IPEndPoint(IPAddress.Parse("10.6.6.45"), port);
            Socket socket = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);

            socket.Bind(iPEndPoint);
            socket.Listen(10);

            Console.WriteLine($"Start server on port {port}");

            while (true)
            {
                Socket listen = await socket.AcceptAsync();
                Console.WriteLine($"Client conected : {listen.RemoteEndPoint}");

                 _ = ReceivMessage(listen);
            }
        }


        static async Task ReceivMessage(Socket socket)
        {
            byte[] bytes = new byte[1024];

            try
            {
                while (true)
                {
                    int byteRead = await socket.ReceiveAsync(bytes, SocketFlags.None);
                    if (byteRead == 0)
                        return;

                    string message = Encoding.UTF8.GetString(bytes, 0, byteRead);
                    Console.WriteLine($"Receive : {message}");

                    string response = $"Received {DateTime.Now}";
                    byte[] bytesResponse = Encoding.UTF8.GetBytes(response);

                    await socket.SendAsync(bytesResponse, SocketFlags.None);
                }
            }
            catch (SocketException ex)
            {
                Console.WriteLine(ex.ToString());
            }
            finally
            {
                Console.WriteLine($"Client disconnected : {socket.RemoteEndPoint}");
                socket.Close();
            }
        }
    }
}
