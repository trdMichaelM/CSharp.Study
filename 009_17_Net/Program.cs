using System;
using System.IO;
using System.Net;
using System.Text;

namespace _009_17_HttpClient
{
    internal class Program
    {
        static void Main(string[] args)
        {
            WebRequest request;
            try
            {
                request = HttpWebRequest.Create("http://www.flenov.info");

                HttpWebResponse response = (HttpWebResponse)request.GetResponse();
                StreamReader reader = new StreamReader(response.GetResponseStream());
                StringBuilder pageBuilder = new StringBuilder();

                string line;
                while ((line = reader.ReadLine()) != null)
                    pageBuilder.Append(line);

                response.Close();
                reader.Close();

                Console.WriteLine(pageBuilder.ToString());
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }

        }
    }
}
