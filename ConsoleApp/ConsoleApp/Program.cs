using System;

namespace ConsoleApp
{
    class Program
    {
        static void Main()
        {
            // init array (all same options)
            // 1 option
            int[] array = { 1, 2, 3 };

            // 2 option
            array = new[] { 1, 2, 3 };

            // 3 option
            array = new int[] { 1, 2, 3 };

            // 4 option
            array = new int[3] { 1, 2, 3 };

            UpdateFirstElement(array);
            PrintArray(array);

            UpdateFirstElementRef(ref array);
            PrintArray(array);

            int[] newArr = new int[10];
            Console.WriteLine("Before init");
            PrintArray(newArr);

            for (int i = 0; i < newArr.Length; i++)
            {
                newArr[i] = i;
            }

            Console.WriteLine("After init");
            PrintArray(newArr);
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
    }
}