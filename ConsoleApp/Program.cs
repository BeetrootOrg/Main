using System;

namespace ConsoleApp
{
    class Program
    {
        static void Main()
        {
         //Comparing strings by sum of their signs in UTF16

            string str1 = "AD123f";
            string str2 = "BC123sa";
            string formatted = "Result of comparing {0} and {1} is {2}";

            Console.WriteLine(formatted,str1,str2,Compare(str1,str2));

            static int Compare(string first, string second)
            {
                int sum1 = 0;
                int sum2 = 0;

                for (int i = 0; i < first.Length; i++)
                    sum1 += first[i];

                for (int i = 0; i < second.Length; i++)
                    sum2 += second[i];

                return sum1 - sum2;
            }
        }
    }
}