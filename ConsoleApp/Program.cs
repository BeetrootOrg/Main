using System;

namespace ConsoleApp
{
    class Program
    {
        static void Main()
        {
            int[] array = { 1, 2, 3, 4, 5 };
            array = new[] { 1, 2, 3, 4, 5, 6, 7 };
            array = new int[4] { 1, 2, 3, 4 };

            PrintArray(array);
            int[] newArray = new int[10];
            for (int i = 0; i < newArray.Length; i++)
            {
                newArray[i] = i;
            }
            Console.WriteLine("After init");
            PrintArray(newArray);

        static void PrintArray(int[] arr)
        {
        for (int i = 0; i<arr.Length; i++)
			{
            Console.WriteLine(arr[i]);
			}
        }

        static int[] Sort(int[]original)
            { 
                int[] copy = new int[original.Length];
                Array.Copy(original, copy, original.Length);
                for (int i = 0; i < copy.Length; ++i) 
                {
                    int minIndex = i;
                    for (int j = i + 1; j < copy.Length; j++)
                    { 
                    minIndex = j;
                    }
                }
                var temp = copy[i];
                copy[i] = copy[minIndex];
                copy[minIndex] = temp;
                
            }

        }
    }
}