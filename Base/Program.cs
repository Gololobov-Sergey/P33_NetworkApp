using System.Net;

namespace Base
{
    internal class Program
    {
        static void Main(string[] args)
        {
            IPAddress ip = new IPAddress(new byte[] { 127, 0, 0, 1 });

            IPAddress.TryParse("127.0.0.1", out IPAddress? ip2);

            Console.WriteLine(ip2.ToString());


            IPAddress iPAddress = IPAddress.Loopback; // 127.0.0.1
            Console.WriteLine(iPAddress.ToString());
            IPAddress iPAddress1 = IPAddress.Any; // 0.0.0.0
            IPAddress iPAddress2 = IPAddress.Broadcast; // 255.255.255.255



            IPEndPoint iPEndPoint = new IPEndPoint(iPAddress, 1000);



        }
    }
}
