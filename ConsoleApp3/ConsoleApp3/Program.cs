using System;
/// <summary>
/// створити методи Max та Min що приймають від 2 до 5 аргументів
/// та повертають max та min відповідно значення серед цих аргументів.
/// 
/// створити метод TryMulIfDividedByThree що повертає булеве значення
/// true/false якщо хоче б одне з чисел ділиться на 3. за допомогою 
/// out параметру повернути результат добутку 
/// (або нуль якщо обидва числа не діляться на 3)
/// 
/// створити метод Repeat що приймає строку str та число n і повертає
/// строку str, що повторюється n разів (e.g. Repeat(‘str’, 3)
/// returns ‘strstrstr’ = ‘str’ three times)
/// 
/// </summary>
namespace MyApp 
{
    public class Program
    {
        public static void Main(string[] args)
        {
            Console.WriteLine(MinFirst(-5, b: 0));
            Console.WriteLine(MaxFirst(24, d:-1));

            Console.WriteLine(new string('*', 70));
            Console.WriteLine(Repeat(" repeat ", 5));
            Console.WriteLine(new string('*', 70));


            double dob;
            if (TryMulIfDividedByThree(81.0, -20.0, 7, out dob))
            {
                Console.WriteLine($" Dob equal to {dob}");
            }
            else
            {
                Console.WriteLine($"CannotUnloadAppDomainException count dob = {dob}");
            }
           
        }

        //--------------------------------------------------------------------
        static int MinFirst( int a, int b = 2, int c = 10 ) 
        {
            return Math.Min(Math.Min(a, b), c);
        }
        static double MaxFirst(int a, int b = 2, int c = 10, double d = 10.0, double e = 5.0) 
        {
            return Math.Max(Math.Max(Math.Max(a, b),Math.Max( c, d)), e);
        }

        //--------------------------------------------------------------------

        static bool TryMulIfDividedByThree(double a, double b, double c, out double dob)
        {
            if (a % 3 == 0 || b % 3 == 0 || c % 3 == 0)
            {
                dob = a * b * c;
                return true;
            }
            dob = 0;
            return false;

        }

        //--------------------------------------------------------------------

        //буз масива, цикла та конкатенацій =_))

        static string Repeat(string str, int n)
        {
            if (n >0)
            {
                return str + Repeat(str, n - 1);
            }
            return "";
        }
    }
}