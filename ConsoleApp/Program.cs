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
        static void PrintArray(int [] arr, string comment)
        {
            for(int i = 0; i < arr.Length; i++)
            {
                Console.Write("{0} ", arr[i]);
            }
            Console.Write(" // {0}\r\n", comment);
        }
        static void PrintArray(int[] arr, int length, string comment)
        {
            for (int i = 0; i < length; i++)
            {
                Console.Write("{0} ", arr[i]);
            }
            Console.Write(" // {0}\r\n", comment);
        }
        static void PrintArray(int[] arr, int start, int end, string comment)
        {
            if (end <= start) return;
            for (int i = start; i < end; i++)
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

                PrintArray(arr, n, "cycle " + k.ToString());

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
        static int Partation(ref int[] arr, int start, int end)
        {
            int pivot = arr[end];
            int m = start;

            PrintArray(arr, start, end, "Pivot " + pivot);

            for (int i = start; i < end; i++)
            {
                if (arr[i] < pivot)
                {
                    SwapElements(ref arr[i], ref arr[m]);
                    m++;
                }
            }
            SwapElements(ref arr[m], ref arr[end]);
            return m;
        }
        static void QuickSort(ref int [] arr, int start, int end)
        {
            if (start < end)
            {
                int pivot = Partation(ref arr, start, end);
                QuickSort(ref arr, start, pivot - 1);
                QuickSort(ref arr, pivot + 1, end);
            }
        }
        static void Main(string[] args)
        {
            Console.WriteLine("\r\n a.tkachenko/homework/06-arrays \r\n");


            Console.WriteLine("1. Selection Sort:");
            int[] array = { 45, 78, 12, 45, 27, 0, 1, 1, 1, 0, 0, 4, 75 };
            PrintArray(array, "-- Input array");
            SelectionSort(array);
            PrintArray(array, "-- Sorted array\r\n");

            Console.WriteLine("2. Buble Sort:");
            int[] BubbleArray = { 45, 78, 12, 35, 27, 0, 13, 0, 57, 0 };
            int n = BubbleArray.Length;
            PrintArray(BubbleArray, "-- Input array");
            bubbleSort(BubbleArray, n);
            PrintArray(BubbleArray, "-- Sorted array\r\n");

            Console.WriteLine("3. Insertion Sort:");
            int[] InsertionArray = { 4, 3, 2, 1, 0 };
            PrintArray(InsertionArray, "-- Input array");
            InsertionSort(InsertionArray);
            PrintArray(InsertionArray, "-- Sorted array\r\n");

            Console.WriteLine("4. Quick Sort:");
            int[] QuickArr = { 5, 1, 3, 0, 7, 6, 2, 9, 4};
            PrintArray(QuickArr, "-- Input array");
            QuickSort(ref QuickArr, 0, QuickArr.Length - 1);
            PrintArray(QuickArr, "-- Sorted array\r\n");
            QuickArr = new int[] { 45, 78, 12, 35, 27, 0, 13, 0, 57, 0 };
            PrintArray(QuickArr, "-- Input array");
            QuickSort(ref QuickArr, 0, QuickArr.Length - 1);
            PrintArray(QuickArr, "-- Sorted array\r\n");

            Console.Write("\r\n");
        }
    }
}
