namespace ConsoleApp
{
    using System;
    class ConsoleApp
    {
        static int GetStringSum(ref string str)
        {
            int sum = 0;

            for (int i = 0; i < str.Length; i++)
            {
                sum += str[i];
            }

            return sum;
        }
        static int Compare(string str1, string str2)
        {
            Console.WriteLine("Compare: {0} and {1}:", str1, str2);
            int resultStr1 = GetStringSum(ref str1);
            int resultStr2 = GetStringSum(ref str2);
            Console.WriteLine("sum Str1: {0}, sum Str2 {1}", resultStr1, resultStr2);
            if (resultStr1 > resultStr2)
            {
                Console.WriteLine("{0} > {1}", str1, str2);
                return 1;
            }
            else if (resultStr1 < resultStr2)
            {
                Console.WriteLine("{0} < {1}", str1, str2);
                return -1;
            }
            else
            {
                Console.WriteLine("{0} == {1}", str1, str2);
                return 0;
            }
        }

        static void Main(string[] args)
        {
            Console.WriteLine("\r\n a.tkachenko/classrom/08-Text \r\n");

            Console.WriteLine("Result: {0}", Compare("str1", "str2"));
        }
    }
}
