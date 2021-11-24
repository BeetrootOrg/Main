using System;

namespace ConsoleApp
{
    class Program
    {
        static void Main()
        {
            int[] array = { 1, 2, 3, 4, 5, 6 };
            array = new[] { 1, 2, 3 };
            array = new int[] { 1, 2, 3 };
            array = new int[4] { 1, 2, 3, 4 };

            PrintArray(array);
        }

        static void PrintArray(int[] arr)
        {
            for (int i = 0; i < arr.Length; i++)
            {
                Console.WriteLine(arr[i]);
            }
        }
    }
}