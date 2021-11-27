namespace ConsoleApp
{
    using System;
    class ConsoleApp
    {
        static void SelectionSort(int[] arr)
        {
            int founMinValue;
            for (int i = 0, j = 0; i < arr.Length; i++)
            {
                founMinValue = arr[i];
                int minIndex = 0;
                int replaceElement = arr[i];
                for (j = i+1; j < arr.Length; j++)
                {
                    if(arr[j] < founMinValue)
                    {
                        minIndex = j;
                        founMinValue = arr[j];
                        arr[i] = founMinValue;
                    }
                }
                if (minIndex != 0)
                {
                    arr[minIndex] = replaceElement;
                }
            }
        }
        static void printArray(int [] arr, string comment)
        {
            for(int i = 0; i < arr.Length; i++)
            {
                Console.Write("{0} ", arr[i]);
            }
            Console.Write(" // {0}\r\n", comment);
        }
        static void printArray(int[] arr, int length, string comment)
        {
            for (int i = 0; i < length; i++)
            {
                Console.Write("{0} ", arr[i]);
            }
            Console.Write(" // {0}\r\n", comment);
        }
        static void SwapElements(ref int a, ref int b)
        {
            int temp = a;
            a = b; 
            b = temp;
        }
        static void bubbleSort(int[] arr, int n)
        {
            int i, j, k;
            bool ArraySorted;

            for (k = 0; k < n; k++)
            {
                ArraySorted = true;
                for (i = 0, j = 1; j < n; i++, j++)
                {
                    if (arr[i] > arr[j])
                    {
                        ArraySorted = false;
                        SwapElements(ref arr[j], ref arr[i]);
                    }
                }

                printArray(arr, n, "cycle " + k.ToString());

                if(ArraySorted == true)
                {
                    break;
                }
            }
        }
        static void InsertionSort(int[] arr)
        {
            if(arr.Length < 2)
            {
                return;
            }
            for(int i = 2; i <= arr.Length; i++)
            {
                bubbleSort(arr, i);
            }
        }
        static void Main(string[] args)
        {
            Console.WriteLine("\r\n a.tkachenko/homework/06-arrays \r\n");


            Console.WriteLine("1. Selection Sort:");
            // int[] array = { 64, 25, 12, 22, 11 , 7};
            int[] array = { 45, 78, 12, 45, 27, 0, 1, 1, 1, 0, 0, 4, 75 };
            printArray(array, "-- Input array");
            SelectionSort(array);
            printArray(array, "-- Sorted array\r\n");

            Console.WriteLine("2. Buble Sort:");
            int[] BubbleArray = { 45, 78, 12, 35, 27, 0, 13, 0, 57, 0 };
            int n = BubbleArray.Length;
            printArray(BubbleArray, "-- Input array");
            bubbleSort(BubbleArray, n);
            printArray(BubbleArray, "-- Sorted array\r\n");

            Console.WriteLine("3. Insertion Sort:");
            int[] InsertionArray = { 4, 3, 2, 1, 0 /*45, 13, 1, 57, 0*/ };
            printArray(InsertionArray, "-- Input array");
            InsertionSort(InsertionArray);
            printArray(InsertionArray, "-- Sorted array\r\n");
            Console.Write("\r\n");
        }
    }
}
