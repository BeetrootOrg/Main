using System;

namespace ConsoleApp06_Arrays
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] someArray = new int[] { 22, 43, 15, 52, 76, 12, 78, 30, 28 };
            Bubble_Sort(someArray);
        }
        static void Bubble_Sort(int[] anArray)
        {
            Console.WriteLine("Unsorted Array:");
            PrintArray(anArray);
            for (int i = 0; i < anArray.Length; i++)
            {
                for (int j = 0; j < anArray.Length - 1; j++)
                {
                    if (anArray[j] > anArray[j + 1])
                    {
                        Swap(ref anArray[j], ref anArray[j + 1]);
                    }
                }
            }
            Console.WriteLine("Sorted Array:");
            PrintArray(anArray);
        }
        static void Swap(ref int aFirstArg, ref int aSecondArg)
        {
            int tmpParam = aFirstArg;
            aFirstArg = aSecondArg;
            aSecondArg = tmpParam;
        }
        static void PrintArray(int[] anArray)
        {
            for (int i = 0; i < anArray.Length; i++)
            {
                Console.WriteLine(anArray[i]);
            }
        }
    }
}
