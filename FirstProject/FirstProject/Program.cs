// ФИБОНАЧЧИ

//int n = 2;
//int f1=0, f2=1;
//int sum = 0;
//if (n == 1) sum = f1;
//else if (n == 2) sum = f2;
//for (int i = 2; i <= n; i++)
//{
//    sum = f1 + f2;
//    f1 = f2;
//    f2 = sum;
//}
//Console.WriteLine(sum);

using System;
namespace FirstProject
{

    class Program
    {
        static void Main()
        {
            double result = Foo(5.5);
            Console.WriteLine(result);
            Concat("Hello", "Dima");
            string str = "Hello";
            Console.WriteLine(AddIfOdd(2,4));
        }
        static double Foo(double x) => x * x * x + 5 * x * x + 6;


        static void Concat(string str1, string str2)
        {
            Console.WriteLine($"{str1},{str2}");
        }
        static void Increment(int i)
        {
            i++;
            Console.WriteLine(i);
        }
        static void Add(string str1, string str2)
        {
            str1 += str2;
            Console.WriteLine($"In add:{ str1}");

        }
        static void AddRef(ref string str1, string str2)
        {
            str1 += str2;
            Console.WriteLine($"In Ref add:{ str1}");

        }
        static int AddIfOdd(int i1,int i2)
        {
            return i1 % 2 == 0 && i2 % 2 == 0 ? i1+i2 :  0;
            
        }
    }

}

