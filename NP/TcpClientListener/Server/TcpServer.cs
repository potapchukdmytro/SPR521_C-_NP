using System.Net;
using System.Net.Sockets;
using System.Text;

namespace Server
{
    public class TcpServer
    {
        private readonly TcpListener listener;
        private readonly List<Client> clients;

        public TcpServer(string ip, int port)
        {
            listener = new TcpListener(IPAddress.Parse(ip), port);
            clients = new List<Client>();
        }

        public void ClientWork(TcpClient client)
        {
            string clientName = "noname";
            Console.WriteLine("Client connected: " + client.Client.RemoteEndPoint);
            try
            {
                byte[] buffer = new byte[1024];
                string welcomeMessage = "Enter your name: ";
                byte[] bytesMessage = Encoding.UTF8.GetBytes(welcomeMessage);
                var stream = client.GetStream();
                stream.Write(bytesMessage);

                int len = stream.Read(buffer);
                clientName = Encoding.UTF8.GetString(buffer, 0, len);

                Client clientObj = new Client { Name = clientName, TcpClient = client };
                clients.Add(clientObj);

                while (client.Connected)
                {
                    len = stream.Read(buffer);
                    string clientMessage = Encoding.UTF8.GetString(buffer, 0, len);
                    string responseMessage = $"{clientObj.Name}: {clientMessage}";
                    Console.WriteLine(responseMessage);

                    SendAll(client, responseMessage);
                }
            }
            catch (Exception ex)
            {
                clients.RemoveAll(c => c.TcpClient.Equals(client));
                Console.WriteLine("Client disconnected: " + clientName);
                Console.WriteLine(ex.Message);
            }
            
        }

        private void SendAll(TcpClient client, string message)
        {
            byte[] responseBytes = Encoding.UTF8.GetBytes(message);

            foreach (var c in clients)
            {
                if (c.TcpClient != client)
                {
                    var streamClient = c.TcpClient.GetStream();
                    streamClient.Write(responseBytes);
                }
            }
        }

        public void Start()
        {
            listener.Start(10);
            Console.WriteLine("Server started");

            while(true)
            {
                try
                {
                    TcpClient client = listener.AcceptTcpClient();
                    Task.Run(() => ClientWork(client));

                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                }
            }
        }
    }
}
