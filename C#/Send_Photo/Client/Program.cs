using System.Net;
using System.Net.Sockets;

namespace Client
{
    internal class Program
    {
        static void Main(string[] args)
        {
            IPAddress ip = IPAddress.Parse("127.0.0.1");
            int port = 5000;

            IPEndPoint endPoint = new IPEndPoint(ip, port);
            Socket server = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);

            try
            {
                Console.ReadLine();
                server.Connect(endPoint);

                string imagePath = @"C:\Users\traig\Downloads\image.webp";
                byte[] bytes = File.ReadAllBytes(imagePath);

                server.Send(bytes);

                Console.ReadLine();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            
        }
    }
}
