using System;
using System.Collections.Generic;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading;

namespace ChatServer
{
    class Program
    {
        static List<Socket> clients = new List<Socket>();
        static void Main(string[] args)
        {
            Console.WriteLine("Starting server...");

            // Настройка сервера
            IPEndPoint endPoint = new IPEndPoint(IPAddress.Any, 5555);
            Socket serverSocket = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);
            serverSocket.Bind(endPoint);
            serverSocket.Listen(5);

            while (true)
            {
                // Принятие нового соединения
                Socket clientSocket = serverSocket.Accept();
                clients.Add(clientSocket);
                Console.WriteLine("Client connected");

                // Создание потока для обработки клиента
                Thread clientThread = new Thread(() => HandleClient(clientSocket));
                clientThread.Start();
            }
        }

        static void HandleClient(Socket clientSocket)
        {
            byte[] buffer = new byte[1024];
            int bytesRead;

            while ((bytesRead = clientSocket.Receive(buffer)) > 0)
            {
                string message = Encoding.UTF8.GetString(buffer, 0, bytesRead);
                Console.WriteLine("Received: " + message);

                // Пересылка сообщения всем клиентам
                foreach (Socket client in clients)
                {
                    if (client != clientSocket)
                    {
                        client.Send(Encoding.UTF8.GetBytes(message));
                    }
                }
            }

            // Отключение клиента
            clients.Remove(clientSocket);
            clientSocket.Close();
            Console.WriteLine("Client disconnected");
        }
    }
}
