using System.Net;
using System.Net.Sockets;

namespace Server
{
    internal class Program
    {
        static void Main(string[] args)
        {
            IPAddress ip = IPAddress.Parse("127.0.0.1");
            int port = 5000;

            IPEndPoint endPoint = new IPEndPoint(ip, port);
            Socket server = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);

            server.Bind(endPoint);

            try
            {
                server.Listen(10);
                Console.WriteLine("Server is listening...");

                Socket client = server.Accept();

                byte[] imageBytes = new byte[0];
                byte[] buffer = new byte[1024];

                while (true)
                {
                    int bytesRead = client.Receive(buffer);
                    for (int i = 0; i < bytesRead; i++)
                    {
                        imageBytes = imageBytes.Append(buffer[i]).ToArray();
                    }


                    if(bytesRead < 1024)
                    {
                        break;
                    }
                }

                File.WriteAllBytes("bird.webp", imageBytes);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
           
        }
    }
}
