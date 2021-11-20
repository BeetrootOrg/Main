using System;

namespace ConsoleApp
{
    class Program
    {

        static void Main(string[] args)
        {
            double result = Program.Func(3);//class Program- might be using without Program.
            System.Console.WriteLine(result);//using System;- might be using without System.
            Concat("Hello", "Ivan");

            int i = 0;
            Increment(i);
            Console.WriteLine(i);
            IncrementRef(ref i);
            Console.WriteLine(i);

            string str = "Hello";
            Add(str, "Ivan");
            Console.WriteLine(str);

            AddRef(ref str, "Ivan");
            Console.WriteLine(str);
            Console.WriteLine(AddIfOdd(2, 4));
            Console.WriteLine(AddIfOdd(1, 4));
            Console.WriteLine(AddIfOdd(2, 1));

            Console.WriteLine(AddIfOdd(2, -2));//?
            Console.WriteLine(AddIfOdd(0, 0));//?

            const int i1 = 2;
            const int i2 = 4;
            int sum;
            if(TryAddIfOdd(i1,i2,out sum))
            {
                Console.WriteLine($"Sum equale to {sum}");
            }
            else
            {
                Console.WriteLine("Cannot count sum bacause inputs are not odd");
            }

            //int.TryParse("1", out int res);
            Console.WriteLine(AddThree(2));
            Console.WriteLine(AddThree(2,6));

            Console.WriteLine("\n");

            Console.WriteLine(Summ(1,3));
        }

        static double Func(double value)=> value * value * value + 5 * value * value + 6;//static because static Main() cant call non-static function
        static void Concat(string str1, string str2) => Console.WriteLine($"{str1} , {str2}");

        static void Increment(int value)//ref- ссылка, указатель 
        {
            ++value;
            Console.WriteLine($"In Increment: {value}");
        }
        static void IncrementRef(ref int value)//ref- ссылка, указатель 
        {
            ++value;
            Console.WriteLine($"In IncrementRef: {value}");
        }

        static void Add(string str1, string str2)
        {
            str1 += str2;
            Console.WriteLine($"In Add: {str1}");
        }
        static void AddRef(ref string str1, string str2)
        {
            str1 += str2;
            Console.WriteLine($"In AddRef: {str1}");
        }

        static int AddIfOdd(int a, int b) => a % 2 == 0 && b % 2 == 0 ? a + b : 0;
        static bool TryAddIfOdd(int a, int b, out int sum)
        {
            if(a % 2 == 0 && b % 2 == 0)
            {
                sum = a + b;
                return true;
            }

            sum = 0;
            return false;
        }

        static int AddThree(int a, int b = 3) => a + b;
        static int AddThree(int a, int b, int c) => a + b + c;

        
        static int Summ(int from, int to)
        {
            if (from > to) return Summ(to, from);
            if (from == to) return from;
            return from + Summ(from + 1, to);
        }
    }
}
