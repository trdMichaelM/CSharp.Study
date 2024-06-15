using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;

namespace _002_UseSplit2;

class Program
{
    static void Main()
    {
        string str = Console.ReadLine();

        string[] normStr = str.Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);
        Console.WriteLine(string.Join(" ", normStr));
    }
}
