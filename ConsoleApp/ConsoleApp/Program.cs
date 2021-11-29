using System;
using System.Text;

namespace ConsoleApp
{
    class Program
    {
        static void Main()
        {
        }

        static int Compare(string str1, string str2) => SumOfSymbols(str1) - SumOfSymbols(str2);

        static int SumOfSymbols(string str)
        {
            int sum = 0;
            foreach (char symbol in str)
            {
                sum += symbol;
            }

            return sum;
        }
    }
}