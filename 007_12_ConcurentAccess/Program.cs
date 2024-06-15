using System;
using System.Threading;

namespace _007_12_ConcurentAccess
{
    public class ThreadTester
    {
        public ThreadTester()
        {
            for(int i = 0; i < 5; i++)
            {
                Thread thread = new Thread(new ThreadStart(ThreadFunc));
                thread.Name = $"Thread: {i}";
                thread.Start();
            }
            Console.ReadLine();
        }

        private void ThreadFunc()
        {
            lock (this)
            {
                for (int i = 0; i < 5; i++)
                {
                    Console.WriteLine($"{Thread.CurrentThread.Name} - {i}");
                    Thread.Sleep(100);
                }
            }
     
        }
    }

    public class Program
    {
        static void Main(string[] args)
        {
            new ThreadTester();
        }
    }
}
