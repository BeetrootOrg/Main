using System;

namespace ConsoleApp
{
    class Program
    {
        static void Main()
        {
            //Max Method
            Console.WriteLine("Max Method");
            Console.WriteLine(Max(4, 8));
            Console.WriteLine(Max(4, 8, 2));
            Console.WriteLine(Max(400, 21, 47));
            Console.WriteLine(Max(51, 34, 49, 15));
            Console.WriteLine(Max(51, 34, 49, 27, 19));

            //Min Method
            Console.WriteLine("Min Method");
            Console.WriteLine(Min(4, 8));
            Console.WriteLine(Min(4, 8, 2));
            Console.WriteLine(Min(400, 21, 47));
            Console.WriteLine(Min(51, 34, 49, 15));
            Console.WriteLine(Min(51, 34, 49, 27, 19));

            //TryMulIfDividedByThree Method
            Console.WriteLine("TryMulIfDividedByThree Method");
            int x = SetIntVar("X");
            int y = SetIntVar("Y");
            int sum;

            if (TryMulIfDividedByThree(x, y, out sum))
            {
                Console.WriteLine($"Multiplication of {x} and {y} equals {sum}");
            }
            else
            {
                Console.WriteLine($"Both numbers can't be divided by 3");
            }

            //Repeat Method
            Console.WriteLine("Repeat Method");
            Console.WriteLine(Repeat("Test", 5));
        }

        //Max Method
        static int Max(int a, int b) => Math.Max(a, b);
        static int Max(int a, int b, int c) => Math.Max(a, Math.Max(b, c));
        static int Max(int a, int b, int c, int d) => Math.Max(a, Math.Max(b, Math.Max(c, d)));
        static int Max(int a, int b, int c, int d, int e) => Math.Max(a, Math.Max(b, Math.Max(c, Math.Max(d, e))));

        //Min Method
        static int Min(int a, int b) => Math.Min(a, b);
        static int Min(int a, int b, int c) => Math.Min(a, Math.Min(b, c));
        static int Min(int a, int b, int c, int d) => Math.Min(a, Math.Min(b, Math.Min(c, d)));
        static int Min(int a, int b, int c, int d, int e) => Math.Min(a, Math.Min(b, Math.Min(c, Math.Min(d, e))));

        //TryMulIfDividedByThree Method with input method from previous HW
        static int SetIntVar(string varName)
        {
            bool success = true;
            string? varInput;
            int intInput;
            do
            {
                Console.WriteLine(success ? $"Please define {varName} variable" : $"{varName} should be a number, so please define {varName} variable again");
                varInput = Console.ReadLine();
                success = int.TryParse(varInput, out intInput);
            }
            while (!success);
            return intInput;
        }

        static bool TryMulIfDividedByThree(int a, int b, out int sum)
        {
            if (a % 3 == 0 || b % 3 == 0)
            {
                sum = a * b;
                return true;
            }
            sum = 0;
            return false;
        }

        //Repeat Method
        static string Repeat(string str, int n)
        {
            string originalStr = str;
            for (int i = 1; i < n; ++i)
            {
                str += " " + originalStr;
            }
            return str;
        }

    }
}