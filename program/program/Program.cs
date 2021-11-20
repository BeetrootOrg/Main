﻿using System;
namespace  ConsoleApp
{
    class Program
    {
        static void Main()
        {
            int a;
            int b;
            int c;
            int sum;
            const int i1 = 4;
            const int i2 = 5;
            int n = 4;
            string str = "str ";
            



            //First task
            Console.WriteLine($"Max:{ Max(1, 4, 6, 8, 4)}");
            Console.WriteLine($"Min:{ Min(1,8,4,6,7)}");
            

            //Second task            
            if (TryAddIfOdd(i1,i2, out sum))
            {
                Console.WriteLine($"Multiplication equals: {sum}");
            }
            else
            {
                Console.WriteLine(sum);
            }

            //Third task

            Repeat(str, n);            

        }
               
        //First task
        //Max
        static int Max(int a, int b) => Math.Max(a, b);        
        static int Max(int a,int b, int c) => Math.Max(a, Math.Max(b, c));
        static int Max(int a, int b, int c, int d) => Math.Max(a, Math.Max(b, Math.Max(c, d)));
        static int Max(int a, int b, int c, int d, int e) => Math.Max(a, Math.Max(b, Math.Max(c,Math.Max(d,e))));
        //Min
        static int Min(int a, int b) => Math.Min(a, b);
        static int Min(int a, int b, int c) => Math.Min(a, Math.Min(b, c));
        static int Min(int a, int b, int c, int d) => Math.Min(a, Math.Min(b, Math.Min(c, d)));
        static int Min(int a, int b, int c, int d, int e) => Math.Min(a, Math.Min(b, Math.Min(c, Math.Min(d, e))));

        //Second task
        static bool TryAddIfOdd(int i1, int i2, out int sum)
        {
            if (i1 % 3 == 0 || i2 % 3 == 0)
            {
                sum = i1 * i2;
                return true;
            }
            sum = 0;
            return false;
        }

        //Third task
        
        static void Repeat(string str, int n)
        {
            if (n > 0)
            { 
                for (int i = 0; i < n; i++)
                {
                    Console.Write(str);                       
                }
            }            
            

        }

    }
}