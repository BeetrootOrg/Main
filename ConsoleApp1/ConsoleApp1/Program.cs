using System;
using System.Collections.Generic;
using System.IO;

namespace Console
{
    class Program
    {
        static void Main()
        {
            double result = FuncWithABigName(5.5);
            System.Console.WriteLine($"{result}");
            ConCat("Hello", "Dima");
        }

        static double FuncWithABigName(double x)
        {
            return x * x * x + 5 * x * x + 6;
        }

        static void ConCat(string str1,string str2)
        {
            System.Console.WriteLine(str2+" , "+str1);
        }
    }
}