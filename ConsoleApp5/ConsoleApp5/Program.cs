using System;
/// <summary>
/// 1. округлити до наступного цілого, що ділиться на 5,
/// наприклад 0 -> 5; 1 -> 5; 5 -> 10; 6 -> 10; 9 -> 10; 10 -> 15
///static int RoundToNext5(int n){}
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
        }
        public static double RoundToNext5(double x)
        {
            return ((x / 5) +1) * 5 + ((x % 5) > 0 ? 5 : 0);
        }
    }
}