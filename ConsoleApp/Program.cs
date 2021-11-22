namespace ConsoleApp
{
    using System;
    class ConsoleApp
    {

        // 1.округлити до наступного цілого, що ділиться на 5, наприклад 0-> 5; 1-> 5; 5-> 10; 6-> 10; 9-> 10; 10-> 15
        static int RoundToNext5(int n)
        {
            return ((n / 5) + 1) * 5;
        }
        // 2.найбільший спільний дільник для a &b, наприклад, (30, 12)-> 6; (8, 9)-> 1, (1, 1)-> 1
        static int Gcd(int a, int b)
        {
            int min = Math.Min(a, b);
            int max = Math.Max(a, b);
            int result = 0;
            int i = min;
            Console.WriteLine("Min: {0}", min);
            do
            {
                if ((min % i == 0) && (max % i == 0))
                {
                    result = i;
                    break;
                }
                else
                {
                    result = 1;
                }
            } while (--i > 0);
            return result;
        }

        //static int Gcd(int a, int b)
        //{
        //    for (int i = Math.Min(a, b); i > 1; --i)
        //    {
        //        if (a % i == 0 && b % i == 0)
        //        {
        //            return i;
        //        }
        //    }

        //    return 1;
        //}

        static void Main(string[] args)
        {
            Console.WriteLine("\r\n a.tkachenko/classrom/05-debug \r\n");

            Console.WriteLine(RoundToNext5(0));
            Console.WriteLine(RoundToNext5(1));
            Console.WriteLine(RoundToNext5(5));
            Console.WriteLine(RoundToNext5(6));
            Console.WriteLine(RoundToNext5(10));
            Console.WriteLine(RoundToNext5(15));
            Console.WriteLine(RoundToNext5(20));

            Console.Write("\r\n");

            Console.WriteLine(Gcd(30, 12));
            Console.WriteLine(Gcd(8, 9));
            Console.WriteLine(Gcd(1, 1));
            Console.WriteLine(Gcd(15, 5));

            Console.Write("\r\n");
        }
    }
}
