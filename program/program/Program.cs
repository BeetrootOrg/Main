using System;
namespace  ConsoleApp
{
    class Program
    {
        static void Main()
        {    
            //First task
            Console.WriteLine($"Max:{ Max(1, 4, 6, 8, 4)}");
            Console.WriteLine($"Min:{ Min(1,8,4,6,7)}");

            //Second task
        }
               
        //First task
        //Max
        public static int Max(int a, int b) => Math.Max(a, b);        
        public static int Max(int a,int b, int c) => Math.Max(a, Math.Max(b, c));
        public static int Max(int a, int b, int c, int d) => Math.Max(a, Math.Max(b, Math.Max(c, d)));
        public static int Max(int a, int b, int c, int d, int e) => Math.Max(a, Math.Max(b, Math.Max(c,Math.Max(d,e))));
        //Min
        public static int Min(int a, int b) => Math.Min(a, b);
        public static int Min(int a, int b, int c) => Math.Min(a, Math.Min(b, c));
        public static int Min(int a, int b, int c, int d) => Math.Min(a, Math.Min(b, Math.Min(c, d)));
        public static int Min(int a, int b, int c, int d, int e) => Math.Min(a, Math.Min(b, Math.Min(c, Math.Min(d, e))));

        //Second task

    }
}