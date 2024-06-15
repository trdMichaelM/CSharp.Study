using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;

namespace _003_Globalization;

class Program
{
    static void Main()
    {
        int n = Convert.ToInt32(Console.ReadLine());

        double sum = 0;
        for (int i = 0; i < n; i++)
        {
            string s = Console.ReadLine();
            string[] ss = s.Split('#');
            sum += Convert.ToDouble(ss[2], CultureInfo.GetCultureInfo("en-US").NumberFormat);
        }
        Console.WriteLine("{0:F2}", sum);
    }
}
