using System.Net;
using System.Net.Sockets;
using System.Text;

namespace Client
{
    internal class Program
    {
        static void ReceiveMessage(TcpClient client)
        {

            try
            {
                while (true)
                {
                    byte[] buffer = new byte[1024];

                    var stream = client.GetStream();
                    int len = stream.Read(buffer);
                    string message = Encoding.UTF8.GetString(buffer, 0, len);
                    Console.ForegroundColor = ConsoleColor.Cyan;
                    Console.WriteLine(message);
                    Console.ResetColor();
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }

        }

        static void Main(string[] args)
        {
            IPAddress serverIp = IPAddress.Parse("127.0.0.1");
            int serverPort = 5000;

            TcpClient client = new TcpClient();

            try
            {
                client.Connect(serverIp, serverPort);

                byte[] buffer = new byte[1024];
                var stream = client.GetStream();

                int len = stream.Read(buffer);
                string serverMessage = Encoding.UTF8.GetString(buffer, 0, len);
                Console.WriteLine(serverMessage);

                string name = Console.ReadLine();
                byte[] nameBytes = Encoding.UTF8.GetBytes(name);

                stream.Write(nameBytes);


                Task.Run(() => ReceiveMessage(client));

                while (true)
                {
                    Console.WriteLine("Enter message: ");
                    string message = Console.ReadLine();
                    stream = client.GetStream();
                    byte[] messageBytes = Encoding.UTF8.GetBytes(message);
                    stream.Write(messageBytes);
                }

            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }
    }
}
