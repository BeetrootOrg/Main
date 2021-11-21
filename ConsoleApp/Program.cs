using System;
/*
1 створити методи Max та Min що приймають від 2 до 5 аргументів та повертають max та min відповідно 
значення серед цих аргументів
2. створити метод TryMulIfDividedByThree що повертає булеве значення true/false 
якщо хоче б одне з чисел ділиться на 3. за допомогою out параметру повернути результат добутку 
(або нуль якщо обидва числа не діляться на 3)

3. створити метод Repeat що приймає строку str та число n і повертає строку str, 
що повторюється n разів (e.g. Repeat(‘str’, 3) returns ‘strstrstr’ = ‘str’ three times)
*/
namespace ConsoleApp
{

    class Program
    {
        static void Main()
        {
            Console.WriteLine($"try find Minimum among argumets of function (2 to 5 argu): {FindMin(12,11)}\n");
            Console.WriteLine($"try find Max among argumets of function (2 to 5 argu): {FindMax(-1,-123, 11)}\n");
            Console.WriteLine("try find multiple of argu, if argu can be divided on 3");

            double multiply;
            if (TryMulIfDividedByThree(3, 12, out multiply))
            {
                Console.WriteLine($"Good one, multiply is {multiply}\n");
            } else 
            {
                Console.WriteLine($"Bad try, multiply error is {multiply}\n");
            }
 
            Console.WriteLine(Repeat("tc",1));
        }
        static int FindMin(int a, int b, int c= 32767, int d= 32767, int e= 32767)
        {
            return (Math.Min(Math.Min(Math.Min(Math.Min(a, b),c),d),e));
        }
        static int FindMax(int a, int b, int c = -32767, int d = -32767, int e = -32767)
        {
            return (Math.Max(Math.Max(Math.Max(Math.Max(a, b), c), d), e));
        }
        static bool TryMulIfDividedByThree(int a, int b, out double multiply)
        {
            if (a % 3 == 0 || b % 3 == 0)
            {
                multiply = a * b;
                return true;
            } else 
            {
                multiply = 0;
                return false;
            }
        }
        static string Repeat(string str, int n)
        {
             if (n > 0)
            {
                for (int a=2; a <= n; a++)
                {
                    str += str;
                }
                return str;
            }
            return "n<1, can't create string";
        }

    }
}

