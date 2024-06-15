using System;
using System.Threading;

class Program
{
    static void Main()
    {
        Thread thread1 = new Thread(BackgroundTask);
        thread1.IsBackground = true; // Устанавливаем поток как фоновый
        thread1.Start();

        Thread thread2 = new Thread(ForegroundTask);
        thread2.Start();
        thread2.Join(); // Ожидаем завершения thread2

        Console.WriteLine("Main thread has finished execution.");
    }

    static void BackgroundTask()
    {
        for (int i = 0; i < 5; i++)
        {
            Console.WriteLine("Background task is running...");
            Thread.Sleep(1000);
        }
    }

    static void ForegroundTask()
    {
        for (int i = 0; i < 5; i++)
        {
            Console.WriteLine("Foreground task is running...");
            Thread.Sleep(2000);
        }
    }
}
