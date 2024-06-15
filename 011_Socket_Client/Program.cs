using System;
using System.Net.Sockets;
using System.Text;
using System.Threading;

namespace ChatClient
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Connecting to server...");

            // Настройка клиента
            TcpClient client = new TcpClient("127.0.0.1", 5555);
            NetworkStream stream = client.GetStream();

            // Создание потоков для отправки и получения сообщений
            Thread sendThread = new Thread(() => SendMessages(stream));
            Thread receiveThread = new Thread(() => ReceiveMessages(stream));

            sendThread.Start();
            receiveThread.Start();
        }

        static void SendMessages(NetworkStream stream)
        {
            while (true)
            {
                string message = Console.ReadLine();
                byte[] data = Encoding.UTF8.GetBytes(message);
                stream.Write(data, 0, data.Length);
            }
        }

        static void ReceiveMessages(NetworkStream stream)
        {
            byte[] buffer = new byte[1024];
            int bytesRead;

            while ((bytesRead = stream.Read(buffer, 0, buffer.Length)) > 0)
            {
                string message = Encoding.UTF8.GetString(buffer, 0, bytesRead);
                Console.WriteLine("Received: " + message);
            }
        }
    }
}
