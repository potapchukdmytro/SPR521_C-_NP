using System.Net;
using System.Net.Sockets;

namespace Server
{
    internal class Program
    {
        static void Main(string[] args)
        {
            TcpServer server = new TcpServer("127.0.0.1", 5000);
            server.Start();

            Console.ReadKey();
        }
    }
}
