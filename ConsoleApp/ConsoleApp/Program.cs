using System;

namespace ConsoleApp
{
    class Program
    {
        static void Main()
        {
            int[] arr = { 1, 3, 2, 6, 4, 5, 8, 0, 9, 7 };
            BubleSort(arr);
            InsertionSort(arr);
        }
        static void PrintArray(int[] arr)
        {
            for (int i = 0; i < arr.Length; i++)
            {
                Console.WriteLine(arr[i]);
            }
        }
        static void BubleSort(int[] arr)
        {
            int temp;
            for (int i = 0; i < arr.Length - 1; ++i)
            {
                for (int j = 0; j < arr.Length; ++i)
                {
                    if (arr[j] > arr[j + 1])
                    {
                        temp = arr[j + 1];
                        arr[j + 1] = arr[j];
                        arr[j] = temp;
                        
                    }
                }
            }
            
        }
        static void InsertionSort(int[] arr)
        {
            int MinIndex = 0;
            int MinValFound = 0;

            for (int i = 0; i < arr.Length; i++)
            {
                MinIndex = i;
                for (int j = i + 1; j < arr.Length; j++)
                {
                    if (arr[j]<arr[MinIndex])
                    {
                        MinIndex = j;
                    }
                }
                MinValFound = arr[MinIndex];
                arr[MinIndex] = arr[i];
                arr[i] = MinValFound;
            }   
        }

    }
}