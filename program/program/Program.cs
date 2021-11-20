using System;
namespace  ConsoleApp
{
    class Program
    {
        static void Main()
        {    
            //First task
            Console.WriteLine(Max(1,4,6,8,4));

            //Second task
        }
               
        //First task
        public static int Max(int a, int b) => Math.Max(a, b);        
        public static int Max(int a,int b, int c) => Math.Max(a, Math.Max(b, c));
        public static int Max(int a, int b, int c, int d) => Math.Max(a, Math.Max(b, Math.Max(c, d)));
        public static int Max(int a, int b, int c, int d, int e) => Math.Max(a, Math.Max(b, Math.Max(c,Math.Max(d,e))));

        //Second task
        
    }
}