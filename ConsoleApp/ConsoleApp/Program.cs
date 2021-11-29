using System;
using System.Diagnostics;

namespace ConsoleApp
{
    public class Program
    {
        static void Main()
        {
            string strA = "AD";
            string strB = "DD";

            Console.WriteLine(Compare(strA, strB));
        }

        static int Compare(string a, string b)
        {
            int sumA = 0;
            int sumB = 0;

            for (int i = 0; i < a.Length; i++)
            {
                sumA += a[i];
                sumB += b[i];
            }

            if (sumA == sumB)
            {
                return 0;
            }
            else if (sumA > sumB)
            {
                return 1;
            }
            else return -1;
        }
    }
}