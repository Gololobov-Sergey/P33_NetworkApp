using System.Net;

namespace TCP_Server
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.Title = "TCP Server";
            int port = 1000;
            //Console.Write("Enter port : ");
            //port = int.Parse(Console.ReadLine());   

            TCP_Server server = new TCP_Server(IPAddress.Any, port);
            server.Message += Server_Message;

            server.StartAsync();

            string command;
            do
            {
                command = Console.ReadLine();
                


            }while (!command.Equals("exit"));
        }

        private static void Server_Message(string message)
        {
            Console.WriteLine(message);
        }
    }
}
