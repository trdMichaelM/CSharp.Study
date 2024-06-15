using System;
using System.Threading;

namespace _005_12_ThreadTest
{
    public class Program
    {
        static void Main(string[] args)
        {
            Thread thread = new Thread(new ThreadStart(ThreadProc));
            thread.Priority = ThreadPriority.Lowest; // Normal - default
            //thread.IsBackground = true;
            thread.Start();

            string str = string.Empty;
            do
            {
                str = Console.ReadLine();
                Console.WriteLine(str);
            } while (str != "q");

        }

        private static void ThreadProc()
        {
            for (int i = 0; i < 10; i++)
            {
                Console.WriteLine("This is a thread!");
                Thread.Sleep(1000);
            }
        }
    }
}
