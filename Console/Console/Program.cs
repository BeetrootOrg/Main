namespace Console
{
    using System;
    public class Program
    {
        static void Main()
        {

        }


        //обчислити значення функцій F та M для будь-якого N
        public static double Ff(double N)
        {
            if (N == 0) return 1;
            else
            {
                return N - Mf(Ff(N - 1));
            }
        }

        public static double Mf(double N)
        {
            if (N == 0) return 0;
            else
            {
                return N - Ff(Mf(N - 1));
            }
        }

        //створити функцію Pow(x, y) що буде підносити X в степінь Y(x та y цілі невід'ємні числа)

        public static int Pow(int val, int pow)
        {
            if (pow == 1) return val;
            else
                return val * Pow(val,pow-1);
        }


        //вивести в консоль всі числа від 1 до N за допомогою рекурсії,
        public static void Print(int num)
        {
            if(num >= 1)
            {
                Print(num,1);
            }
            
        }

        public static void Print(int num, int cnum)
        {
            if (cnum <= num)
            {
                Console.WriteLine(cnum);
                Print(num,++cnum);
            }
        }
    }


}