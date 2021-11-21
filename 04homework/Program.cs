namespace Homework4
{
    using System;

    class Homework4
    {

        static int MaxValue(params int[] numbers)
        {
            return numbers.Max();
        }

        static int MinValue(params int[] numbers)
        {
            return numbers.Min();
        }

        static int TrySumIfOdd(int x, int y, out bool isOdd)
        {
            int xValue = x, yValue = y;
            int sum = xValue;
            while (xValue != yValue)
            {
                sum += xValue > yValue ? --xValue : ++xValue;
            }
            isOdd = sum % 2 != 0;
            return sum;
        }

        static bool TryMulIfDividedByThree(int x, int y, out int multiplication)
        {
            bool canDivideX = x % 3 == 0;
            bool canDivideY = y % 3 == 0;
            multiplication = canDivideX && canDivideY ? x * y : 0;
            return canDivideX || canDivideY;
        }

        //Is this from CodeWars?
        static string Repeat(string str, int repeat)
        {
            return string.Concat(Enumerable.Repeat(str, repeat));
        }

        static void Main(string[] args)
        {
            Console.WriteLine(MaxValue(2, 3, 4, 8, 2));
            Console.WriteLine(MinValue(2, 3, 4, 8, -2));

            TrySumIfOdd(6, 9, out bool isOdd);
            Console.WriteLine((isOdd) ? "The sum is odd" : "The sum is even");

            bool canDivideAtLeastOne = TryMulIfDividedByThree(5, 9, out int multi);
            Console.WriteLine((canDivideAtLeastOne) ? "At least one number can be divided by 3" : "No numbers can be divided by 3");
            Console.WriteLine($"The multiplication of numbers is {multi}");

            Console.WriteLine(Repeat("test", 5));
        }
    }
}
