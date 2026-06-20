using System.Net;
using System.Net.Sockets;
using System.Text;

namespace UdpServer
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int port = 5000;
            UdpClient server = new UdpClient();

            // Сервер отримує всі повідомлення та виводить їх
            //while (true)
            //{
            //    IPEndPoint clientEndP = new IPEndPoint(IPAddress.Any, 0);
            //    byte[] receviedBytes = server.Receive(ref clientEndP);
            //    string clientMessage = Encoding.UTF8.GetString(receviedBytes);
            //    Console.WriteLine($"Client {clientEndP} sent: " + clientMessage);
            //}


            // Сервер відправляє всім повідомлення
            //while(true)
            //{
            //    Console.Write("Enter message: ");
            //    string serverMessage = Console.ReadLine();
            //    byte[] messageBytes = Encoding.UTF8.GetBytes(serverMessage);

            //    var broadcastEndP = new IPEndPoint(IPAddress.Broadcast, port);
            //    server.Send(messageBytes, broadcastEndP);
            //}



            // Сервер відправляє зображення
            while (true)
            {
                int packageSize = 1024 * 32;

                //Console.Write("Enter image path: ");
                //string imagePath = Console.ReadLine();
                string imagePath = "";
                Console.WriteLine("Enter for start");
                Console.ReadLine();

                byte[] imageBytes = File.ReadAllBytes(imagePath);
                int imageLength = imageBytes.Length;
                int packageCount = (int)Math.Ceiling((double)imageLength / packageSize);
                string countStr = packageCount.ToString();
                byte[] countBytes = Encoding.UTF8.GetBytes(countStr);

                var broadcastEndP = new IPEndPoint(IPAddress.Broadcast, port);

                server.Send(countBytes, broadcastEndP);

                Thread.Sleep(100);

                Console.WriteLine("Package count: " + packageCount);
                for (int i = 0; i < packageCount; i++)
                {
                    server.Send(imageBytes.Skip(i * packageSize).Take(packageSize).ToArray(), broadcastEndP);
                    Thread.Sleep(1);
                    double loadProcent = (i + 1) / (double)packageCount * 100;
                    Console.WriteLine($"{loadProcent:0.0}%");
                }

                Console.WriteLine("Image sent");
            }
        }
    }
}
