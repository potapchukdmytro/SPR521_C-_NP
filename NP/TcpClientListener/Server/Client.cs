using System.Net.Sockets;

namespace Server
{
    public class Client
    {
        public string Name { get; set; } = "noname";
        public TcpClient? TcpClient { get; set; } = null;
        public ConsoleColor Color { get; set; } = ConsoleColor.Gray;
    }
}
