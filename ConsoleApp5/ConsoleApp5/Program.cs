using System;
/// <summary>
/// 1. округлити до наступного цілого, що ділиться на 5,
/// наприклад 0 -> 5; 1 -> 5; 5 -> 10; 6 -> 10; 9 -> 10; 10 -> 15
///static int RoundToNext5(int n){}
///
/// найбільший спільний дільник для a & b, наприклад, (30, 12) -> 6; (8, 9) -> 1, (1, 1) -> 1
///static int Gcd(int a, int b){}
/// </summary>
/// 
namespace MyApp
{
    public class Program
    {
        static void Main() 
        {
            int x = 0;
            Console.WriteLine(RoundToNext5(x));

            int a = 30;
            int b = 12;
            Console.WriteLine(Gcd(30, 12));
        }

        //------------------------------------------------------------------

        public static double RoundToNext5(double x)
        {
            return ((x / 5) +1) * 5 + ((x % 5) > 0 ? 5 : 0);
        }
        //------------------------------------------------------------------

        public static int Gcd(int a, int b) 
        {
            if (b == 0)
                return a;

            return Gcd(b, a % b);
          
        }
    }
}