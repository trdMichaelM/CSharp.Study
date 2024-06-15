using System;
using System.Threading;

namespace _006_12_ParamThreadTest
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Thread thread = new Thread(new ParameterizedThreadStart(ThreadProc));
            thread.Priority = ThreadPriority.BelowNormal;
            thread.IsBackground = true;
            thread.Start(5);
        }

        private static void ThreadProc(object? obj)
        {
            int loop_number = (int)obj;
            for (int i = 0; i < loop_number; i++)
            {
                Console.WriteLine("This is a thread!");
                Thread.Sleep(1000);
            }
        }
    }
}
