// See https://aka.ms/new-console-template for more information
using System;

namespace ConsoleApp
{
    class Program
    {
        static void Main()
        {
            // Console.WriteLine(Factorial(5));

            int[] array = { 1, 2, 3, 4, 5, 6, };
            
            //PrintArray(array);

            PrintArray(Sort(new[] { 6, 9, 7, 5, 9 }));

            PrintArray(Sort(new[] { 1, 2, 3, 4, 5 }));

        }

        static void PrintArray(int[] arr)
        {
            for (int i = 0; i < arr.Length; i++)
            {
                Console.WriteLine(arr[i]);
            }
        }

        static void UpdateFirstElement(int[] arr)
        {
            arr[0] = 42;
            arr = new[] { 5, 6, 7 };
        }

        static void UpdateFirstElementRef(ref int[] arr)
        {
            arr[0] = 42;
            arr = new[] { 5, 6, 7 };
        }

        static int[] Sort(int[] original)
        {
            int[] copy = new int[original.Length];
            Array.Copy(original, copy, original.Length);

            for (int i = 0; i < copy.Length - 1; i++)
            {
                int minIndex = i;
                for (int j = i+1; j < copy.Length; j++)
                {
                    if (copy[j] < copy[minIndex])
                    {
                        minIndex = j;
                    }
                }

                var temp = copy[i];
                copy[i] = copy[minIndex];
                copy[minIndex] = temp;
            }

            return copy;
        }

        //OTHER
        static long Factorial(int a)
        {
            if (a > 0)
            {
                return a * (Factorial(a - 1));
            }
            else return 1;
        }

        static int Gcd(int a, int b) => Gcd(a, b, Math.Min(a,b));
        static int Gcd(int a, int b, int possibleGcd)
        {
            if (a % possibleGcd == 0 && b % possibleGcd == 0)
            {
                return possibleGcd;
            }
            else return Gcd(a, b, possibleGcd - 1);
    }
}
}