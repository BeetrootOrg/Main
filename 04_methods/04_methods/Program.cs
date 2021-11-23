using System;

namespace Homework04_methods
{
    class Program
    {
        static void Main()
        {
            Console.WriteLine("Homework_04_methods");
            int maxValue = Max(0, 404, 568, 89854, 45646568);
            int minValue = Min(586, 4568749, 15668, 3568, 64686);
            Console.WriteLine($"Max value = {maxValue}, Min value = {minValue}");
            Console.WriteLine(Repeat("Evgeniy", 6));
            int result;
            int firstNum = 9;
            int secondNum = 3;
            if (TryMulIfDividedByThree(firstNum, secondNum, out result))
            {
                Console.WriteLine($"result = {result}");
            }
            else
            {
                Console.WriteLine("0");
            }
        }
        // First Task 
        static int Max(int a, int b) => Math.Max(a, b);
        static int Max(int a, int b, int c) => Math.Max(a, (Math.Max(b, c)));
        static int Max(int a, int b, int c, int d) => Math.Max(Math.Max(a, Math.Max(b, c)), d);
        static int Max(int a, int b, int c, int d, int e) => Math.Max(Math.Max(Math.Max(a, Math.Max(b, c)), d), e);

        static int Min(int a, int b) => Math.Min(a, b);
        static int Min(int a, int b, int c) => Math.Min(a, (Math.Min(b, c)));
        static int Min(int a, int b, int c, int d) => Math.Min(Math.Min(a, Math.Min(b, c)), d);
        static int Min(int a, int b, int c, int d, int e) => Math.Min(Math.Min(Math.Min(a, Math.Min(b, c)), d), e);

        // Third Task

        static string Repeat(string str, int n)
        {
            if (n > 0)
            {
                for (int i = 0; i < n; i++)
                {
                    return str + Repeat(str, n - 1);
                }
            }
            return "";
        }

        // Second Task

        static bool TryMulIfDividedByThree(int firstNum, int secondNum, out int result)
        {
            if (firstNum % 3 == 0 || secondNum % 3 == 0)
            {
                result = firstNum * secondNum;
                return true;
            }
            result = 0;
            return false;
        }
    }
}
