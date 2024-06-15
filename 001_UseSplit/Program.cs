using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;

namespace _001_UseSplit;

class Program
{
    static void Main()
    {
        int n = Convert.ToInt32(Console.ReadLine());
        string s = Console.ReadLine();

        string[] ss = s.Split(' ');
        int[] arr = new int[n];
        for (int i = 0; i < n; i++)
            arr[i] = Convert.ToInt32(ss[i]);

        int[] result = new int[n];
        for (int i = 0; i < n; i++)
        {
            int j = (i + 1) % n;
            result[j] = arr[i];
        }

        for (int i = 0; i < n; i++)
            Console.Write($"{result[i]} ");
    }
}
