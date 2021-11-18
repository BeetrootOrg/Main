namespace Homework4
{
    using System;

    class Homework4
    {
        static int MaxValue(int x, int y)
        {
            return Math.Max(x, y);
        }

        static int MaxValue(params int[] numbers)
        {
            return numbers.Max();
        }

        static int MinValue(int x, int y)
        {
            return Math.Min(x, y);
        }

        static int MinValue(params int[] numbers)
        {
            return numbers.Min();
        }

        static long TrySumIfOdd(int x, int y, out bool isOdd)
        {
            int xValue = x, yValue = y;
            long sum = xValue;
            while (xValue != yValue)
            {
                sum += xValue > yValue ? --xValue : ++xValue;
            }
            isOdd = sum % 2 != 0;
            return sum;
        }

        //Is this from CodeWars?
        static string Repeat(string str, int repeat)
        {
            return string.Concat(Enumerable.Repeat(str, repeat));
        }

        static void Main(string[] args)
        {
            Console.WriteLine(MaxValue(2,3,4,8,2));

            TrySumIfOdd(6, 9, out bool isOdd);
            Console.WriteLine((isOdd) ? "The sum is odd" : "The sum is even");

            Console.WriteLine(Repeat("test", 5));
        }
    }
}