using System;

namespace ConsoleApp
{
    public class Program
    {
        static void Main()
        {
            int[] arr = { 8, 9, 7, 6, -5, 0, -7, 7, -9, 3, 6 };

            PrintArray(arr);

            PrintArray(BubbleSort(arr));
            PrintArray(QuickSort(arr, 0, arr.Length - 1));        }

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
                        int temp = copyArr[j + 1];
                        copyArr[j + 1] = copyArr[j];
                        copyArr[j] = temp;
                    }
                }
            }
            return copyArr;
        }

        //Method to print array
        static void PrintArray(int[] arr)
        {
            for (int i = 0; i < arr.Length; i++)
            {
                Console.Write(arr[i] + " ");
            }
            Console.WriteLine();
        }

        //QUICK SORT
        static int[] QuickSort(int[] arr, int start, int end)
        {
            if (start < end)
            {
                int divideIndex = Partition(arr, start, end);

                QuickSort(arr, start, divideIndex - 1);
                QuickSort(arr, divideIndex, end);
            }

            return arr;
        }

        static int Partition(int[] arr, int start, int end)
        {
            int leftIndex = start;
            int rightIndex = end;

            int pivot = (end - 1) / 2;

            while (leftIndex <= rightIndex)
            {
                while(arr[leftIndex] < pivot)
                    leftIndex++;

                while(arr[rightIndex] > pivot)
                    rightIndex--;

                if(leftIndex <= rightIndex)
                {
                    int temp = arr[leftIndex];
                    arr[leftIndex] = arr[rightIndex];
                    arr[rightIndex] = temp;

                    leftIndex++;
                    rightIndex++;
                }
            }

            return leftIndex;
        }
    }
}