using System;
using WebSocket4Net;

class Program
{
    static void Main(string[] args)
    {
        string url = "ws://echo.websocket.org"; // Эхо-сервер для тестирования WebSocket

        WebSocket websocket = new WebSocket(url);

        websocket.Opened += new EventHandler(WebSocket_Opened);
        websocket.Error += new EventHandler<SuperSocket.ClientEngine.ErrorEventArgs>(WebSocket_Error);
        websocket.Closed += new EventHandler(WebSocket_Closed);
        websocket.MessageReceived += new EventHandler<MessageReceivedEventArgs>(WebSocket_MessageReceived);

        websocket.Open();

        Console.WriteLine("Press any key to exit...");
        Console.ReadKey();

        websocket.Close();
    }

    static void WebSocket_Opened(object sender, EventArgs e)
    {
        Console.WriteLine("WebSocket opened.");
        WebSocket websocket = (WebSocket)sender;
        websocket.Send("Hello, WebSocket!");
    }

    static void WebSocket_Error(object sender, SuperSocket.ClientEngine.ErrorEventArgs e)
    {
        Console.WriteLine("WebSocket error: " + e.Exception.Message);
    }

    static void WebSocket_Closed(object sender, EventArgs e)
    {
        Console.WriteLine("WebSocket closed.");
    }

    static void WebSocket_MessageReceived(object sender, MessageReceivedEventArgs e)
    {
        Console.WriteLine("Message received: " + e.Message);
    }
}
