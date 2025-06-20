using System.Net;
using System.Net.Sockets;

namespace UDP_Chat
{
    internal class Program
    {
        static int localPort;
        static int remotePort;

        static void Main(string[] args)
        {

            Console.SetWindowSize(30, 20);
            try
            {
                
                Console.Write("Local Port : ");
                while (!int.TryParse(Console.ReadLine(), out localPort) || localPort < 0 || localPort > 65535)
                {
                    Console.WriteLine("Invalid port. Please enter a valid port number (0-65535):");
                }

               
                Console.Write("Remote Port : ");
                while (!int.TryParse(Console.ReadLine(), out remotePort) || remotePort < 0 || remotePort > 65535)
                {
                    Console.WriteLine("Invalid port. Please enter a valid port number (0-65535):");
                }

                IPAddress remoteAddress = IPAddress.Loopback;

                Thread serverThread = new Thread(new ThreadStart(StartServer));

                serverThread.IsBackground = true;   
                serverThread.Start();

                while(true)
                {
                    SendData(Console.ReadLine());
                }

            }
            catch (Exception ex)
            {
                Console.WriteLine("Error : " + ex.Message);
            }

        }

        static void StartServer()
        {
            try
            {
                while(true)
                {
                    UdpClient udpServer = new UdpClient(localPort);
                    IPEndPoint remoteEndPoint = null;

                    byte[] responce = udpServer.Receive(ref remoteEndPoint);
                    string message = System.Text.Encoding.UTF8.GetString(responce);
                    Console.ForegroundColor = ConsoleColor.Green;
                    Console.WriteLine(message);
                    Console.ForegroundColor = ConsoleColor.Red;
                    udpServer.Close();
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error Server: " + ex.Message);
            }
            
        }

        static void SendData(string message)
        {
            UdpClient udpClient = new UdpClient();
            try
            {
                


                IPEndPoint remoteEndPoint = new IPEndPoint(IPAddress.Loopback, remotePort);
                byte[] data = System.Text.Encoding.UTF8.GetBytes(message);
                udpClient.Send(data, data.Length, remoteEndPoint);
                udpClient.Close();
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error Client: " + ex.Message);
            }
            finally
            {
                udpClient.Close();
            }
        }

    }
}
