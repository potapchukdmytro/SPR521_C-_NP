using System.Net;
using System.Net.Sockets;
using System.Text;

namespace Client
{
    internal class Program
    {
        static void Main(string[] args)
        {
            IPAddress serverIp = IPAddress.Parse("26.164.81.5");
            int serverPort = 4000;

            IPEndPoint serverEndPoint = new IPEndPoint(serverIp, serverPort);
            Socket server = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);

            try
            {
                Console.ReadLine();
                server.Connect(serverEndPoint);
                byte[] buffer = new byte[1024];

                // Читаємо повідомлення від сервера
                // receive - повертає кількість байтів, які були отримані
                int len = server.Receive(buffer);

                string serverMessage = Encoding.UTF8.GetString(buffer, 0, len);
                Console.WriteLine("Server: " + serverMessage);

                while (true)
                {
                    // Відправляємо повідомлення серверу
                    Console.Write("Enter message: ");
                    string clientMessage = Console.ReadLine();
                    byte[] messageBytes = Encoding.UTF8.GetBytes(clientMessage);
                    server.Send(messageBytes);
                }
                
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            finally
            {
                server.Disconnect(false);
                server.Close();
            }
        }
    }
}
