﻿using System;
using System.Diagnostics;

namespace ConsoleApp
{
    public class Program
    {
        static void Main()
        {
            Stopwatch timeBubbleSort = new Stopwatch();
            Stopwatch timeQuickSort = new Stopwatch();

            //Generate BIG array on 100 000 elements
            int[] arr = GenerateArray(100000);


            //Measure the execution time of the Bubble Sort
            timeBubbleSort.Start();
            int[] arrBubbleSort = BubbleSort(arr);
            timeBubbleSort.Stop();

            //Measure the execution time of the Quick Sort
            timeQuickSort.Start();
            int[] arrQuickSort = QuickSort(arr, 0, arr.Length - 1);
            timeQuickSort.Stop();


            //I dont want to print so big array)
            //PrintArray(BubbleSort(arr));
            Console.WriteLine($"Bubble sort time {arr.Length} elements: {timeBubbleSort.ElapsedMilliseconds} ms");

            //PrintArray(arrQuickSort);
            Console.WriteLine($"Quick sort time {arr.Length} elements: {timeQuickSort.ElapsedMilliseconds} ms");
        }

        //Generate array with n-elements
        static int[] GenerateArray(int n)
        {
            Random random = new Random();
            int[] arr = new int[n];

            for (int i = 0; i < n; i++)
            {
                arr[i] = random.Next(-100, 101);
            }
            return arr;
        }

        //Bubble Sort Method
        static int[] BubbleSort(int[] arr)
        {
            int[] copyArr = arr;

            for (int i = 0; i < copyArr.Length; i++)
            {
                for (int j = 0; j < copyArr.Length - 1; j++)
                {
                    if (copyArr[j] > copyArr[j + 1])
                    {
                        Swap(ref copyArr[j], ref copyArr[j + 1]);
                    }
                }
            }
            return copyArr;
        }
        
        //Method to print array
        static void PrintArray(int[] arr)
        {
            foreach(int item in arr)
            {
                Console.Write(item + " ");
            }
            Console.WriteLine();
        }

        //QUICK SORT
        static int[] QuickSort(int[] arr, int minIndex, int maxIndex)
        {
            if (minIndex >= maxIndex)
            {
                return arr;
            }

            int pivodIndex = GetPivodIndex(arr, minIndex, maxIndex);

            QuickSort(arr, minIndex, pivodIndex - 1);
            QuickSort(arr, pivodIndex + 1, maxIndex);

            return arr;
        }

        static int GetPivodIndex(int[] arr, int minIndex, int maxIndex)
        {
            int pivod = minIndex - 1;

            for (int i = minIndex; i <= maxIndex; i++)
            {
                if (arr[i] < arr[maxIndex])
                {
                    pivod++;
                    Swap(ref arr[pivod], ref arr[i]);
                    
                }
            }

            pivod++;
            Swap(ref arr[pivod], ref arr[maxIndex]);

            return pivod;
        }

        //Swap Method
        static void Swap(ref int leftElement, ref int rightElement)
        {
            int temp = leftElement;
            leftElement = rightElement;
            rightElement = temp;
        }
    }
}