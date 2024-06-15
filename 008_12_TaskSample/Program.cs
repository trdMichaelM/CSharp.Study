using System;
using System.Net.Http;
using System.Threading.Tasks;

namespace _008_12_TaskSample
{
    public class AsyncSampleClass
    {
        public async Task<string> AccessTheWebAsync()
        {
            HttpClient httpClient = new HttpClient();

            Task<string> getStringTask = httpClient.GetStringAsync("http://www.flenov.info/robots.txt");

            return await getStringTask;
        }
    }

    public class Program
    {
        static void Main(string[] args)
        {
            AsyncSampleClass asyncSampleClass = new AsyncSampleClass();

            Task<string> asyncContent = asyncSampleClass.AccessTheWebAsync();

            Console.WriteLine($"State: {asyncContent.Status}");

            string webContent = asyncContent.Result;

            Console.WriteLine($"State: {asyncContent.Status}");

            Console.WriteLine("Result form site:");
            Console.WriteLine(webContent);
            Console.ReadLine();
        }
    }
}
