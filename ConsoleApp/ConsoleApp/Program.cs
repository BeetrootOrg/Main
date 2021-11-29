using System;
namespace ConsoleApp
{
    class Program
    {
        static void Main()
        {
            string str1 = "Ola Senior";
            string str2 = "Hello";

            Console.WriteLine(CompareStr(str1, str2));
        }
        static int CompareStr(string str1, string str2)
        {
            int str1Sum = 0;
            int str2Sum = 0;
            foreach (char c in str1)
            {
                str1Sum += c;
            }
            foreach (char c in str2)
            {
                str2Sum += c;
            }
            if (str1Sum > str2Sum)
            {
                return 1;
            }
            if (str1Sum < str2Sum)
            {
                return -1;
            }
            return 0;
        }

        static int CompareStrOther(string str1, string str2) => SumOfSymbols(str1) - SumOfSymbols(str2);
        static int SumOfSymbols(string arr)
        {
            var sum = 0;
            foreach (char c in arr)
            {
                sum += c;
            }
            return sum;
        }
    }
}

}