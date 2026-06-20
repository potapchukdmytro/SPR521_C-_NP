using System.Net;
using System.Net.Sockets;
using System.Text;

namespace UpdClient
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int port = 5000;
            UdpClient udpClient = new UdpClient(port);

            // Відправка
            //while (true)
            //{
            //    Console.Write("Enter text: ");
            //    string text = Console.ReadLine();
            //    byte[] bytes = Encoding.UTF8.GetBytes(text);

            //    udpClient.Send(bytes, bytes.Length, serverEndP);
            //}

            // Отримання
            //while(true)
            //{
            //    IPEndPoint broadcastEndP = new IPEndPoint(IPAddress.Any, port);
            //    byte[] serverMessage = udpClient.Receive(ref broadcastEndP);
            //    string message = Encoding.UTF8.GetString(serverMessage);
            //    Console.WriteLine("Server sent: " + message);
            //}



            // Отримання фото
            while (true)
            {
                List<byte> imageBytes = new List<byte>();

                IPEndPoint broadcastEndP = new IPEndPoint(IPAddress.Any, port);
                byte[] packageCount = udpClient.Receive(ref broadcastEndP);
                string packagesStr = Encoding.UTF8.GetString(packageCount);
                bool res = int.TryParse(packagesStr, out int packages);

                if (res)
                {
                    for (int i = 0; i < packages; i++)
                    {
                        byte[] package = udpClient.Receive(ref broadcastEndP);
                        imageBytes.AddRange(package);
                    }

                    File.WriteAllBytes("", imageBytes.ToArray());
                    Console.WriteLine("Image saved");
                }
            }
        }
    }
}
