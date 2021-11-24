using System;

namespace ConsoleApp
{
    class Program
    {
        static void Main()
        {
            /*
            1
            F(0) = 1
            M(0) = 0
            F(n) = n - M(F(n - 1))
            M(n) = n - F(M(n - 1))
            обчислити значення функцій F та M для будь-якого N
             
            2 інше:
            створити функцію Pow(x, y) що буде підносити X в степінь Y(x та y цілі невід'ємні числа)
            
            3 ще одне:
            вивести в консоль всі числа від 1 до N за допомогою рекурсії, сигнатуру метода можете самі вигадати
            */
            int a = 3;
            Console.WriteLine($"First one. Result of method F(n) is {F(a)}\n");
            static int F(int n)
            {
                {
                    return (n > 0) ? n - M(F(n - 1)) : 1;
                }
                static int M(int n)
                {
                    return (n > 0) ? n - F(M(n - 1)) : 0;
                }
            }

            int b = 3;
            
            Console.WriteLine($"Second one. Result of homemade multiplication method:{Pow(a,b)}");

            static int Pow(int n, int o)
            {
                return (o > 0) ? n*Pow(n, --o): 1;  
            }
            
            int c = 12;
            
            Number(c);
            static void Number(int a,int d=1)
            { 
                if (a > d)
                {
                    Console.WriteLine(d);
                    Number(a,++d);
                }

                                
            }



        }
    } 
}