using System.Net;
using System.Net.Sockets;
using System.Text;

namespace Server
{
    internal class Program
    {
        static void ClientHandler(Socket client)
        {
            byte[] buffer = new byte[1024];
            while (true)
            {
                // Читаємо повідомлення від клієнта
                int len = client.Receive(buffer);
                string clientMessage = Encoding.UTF8.GetString(buffer, 0, len);
                Console.WriteLine($"Client ({client.RemoteEndPoint}): " + clientMessage);

                // Відправляємо повідомлення клієнту
                //Console.Write("Enter message: ");
                //string serverMessage = Console.ReadLine();
                //byte[] messageBytes = Encoding.UTF8.GetBytes(serverMessage);
                //client.Send(messageBytes);
            }
        }

        static void Main(string[] args)
        {
            IPAddress ip = IPAddress.Parse("26.164.81.5");
            int port = 4000;

            IPEndPoint endPoint = new IPEndPoint(ip, port);

            Socket server = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);
            server.Bind(endPoint);

            try
            {
                server.Listen(10);
                Console.WriteLine("Server running...");

                while(true)
                {
                    Socket client = server.Accept();
                    Console.WriteLine($"Client connected: {client.RemoteEndPoint}");

                    // Віддправляємо повідомлення клієнту
                    string message = "Hello from server!";
                    byte[] bytes = Encoding.UTF8.GetBytes(message);
                    client.Send(bytes);

                    Task.Run(() => ClientHandler(client));
                }
                
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            finally
            {
                server.Close();
                Console.WriteLine("Server stoped");
            }
        }
    }



    // Один потік
    //internal class Program
    //{
    //    static void Main(string[] args)
    //    {
    //        IPAddress ip = IPAddress.Parse("10.10.21.100");
    //        int port = 4000;

    //        IPEndPoint endPoint = new IPEndPoint(ip, port);

    //        Socket server = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);
    //        server.Bind(endPoint);

    //        try
    //        {
    //            server.Listen(10);
    //            Console.WriteLine("Server running...");

    //            Socket client = server.Accept();
    //            Console.WriteLine($"Client connected: {client.RemoteEndPoint}");

    //            // Віддправляємо повідомлення клієнту
    //            string message = "Hello from server!";
    //            byte[] bytes = Encoding.UTF8.GetBytes(message);
    //            client.Send(bytes);

    //            byte[] buffer = new byte[1024];
    //            while (true)
    //            {
    //                // Читаємо повідомлення від клієнта
    //                int len = client.Receive(buffer);
    //                string clientMessage = Encoding.UTF8.GetString(buffer, 0, len);
    //                Console.WriteLine("Client: " + clientMessage);

    //                // Відправляємо повідомлення клієнту
    //                Console.Write("Enter message: ");
    //                string serverMessage = Console.ReadLine();
    //                byte[] messageBytes = Encoding.UTF8.GetBytes(serverMessage);
    //                client.Send(messageBytes);
    //            }
    //        }
    //        catch (Exception ex)
    //        {
    //            Console.WriteLine(ex.Message);
    //        }
    //        finally
    //        {
    //            server.Close();
    //            Console.WriteLine("Server stoped");
    //        }
    //    }
    //}
}
