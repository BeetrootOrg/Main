using System;
namespace  ConsoleApp
{
    class Program
    {
        static void Main()
        {           
            //first task
            Console.WriteLine("First task:");
            Console.WriteLine($"F(n)={ sumF(1, 0, 5)}");
            Console.WriteLine($"M(n)={ sumM(1, 0, 8)}");

            //second task

            Console.WriteLine("Second task:");
            Console.WriteLine(Pow(4, 3));


            //third task
            
            Console.WriteLine($"Count number:");
            Count(1,10);


        }
        //first task
        static int sumF(int F, int M, int n)
        {
             
             return n - M * (F * (n - 1));
           
        }

        static int sumM(int F, int M, int n)
        {
            
            return n - F * (M * (n - 1));
        }

        //second task

        static double Pow(int x, int y)
        {
            if (y == 0)
                return 1;
            if (y > 0)
                return Pow(x, y - 1) * x;
            return 1.0 / (Pow(x, -y));
        }



        //third task

        static void Count(int i, int l)
        {
            Console.WriteLine(i);
            {                
                if (i >= l)
                    return;
                i++;

                Count(i,l);
            }
        }



    }
}