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

        static bool TrySumIfOdd(int x, int y)
        {
            int xValue = x, yValue = y;
            long sum = xValue;
            while (xValue != yValue)
            {
                sum += xValue > yValue ? --xValue : ++xValue;
            }
            return sum % 2 == 0;
        }

        //Is this from CodeWars?
        static string Repeat(string str, int repeat)
        {
            return string.Concat(Enumerable.Repeat(str, repeat));
        }

        static void Main(string[] args)
        {
            Console.WriteLine(MaxValue(2,3,4,8,2));
            Console.WriteLine(TrySumIfOdd(6, 9));
            Console.WriteLine(Repeat("test", 5));
        }
    }
}