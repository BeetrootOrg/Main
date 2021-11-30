using System;

namespace ConsoleApp06homeworkArray
{
    class ConsoleApp06homeworkArray
    {
        static void Main(string[] args)
        {
            Sort(new int[10] { 26, 11, 9, 6, 29, 77, 37, 33, 8, 72 }, SortAlgorithmType.Selection, OrderBy.Desc);
            Sort(new int[10] { 26, 11, 9, 6, 29, 77, 37, 33, 8, 72 }, SortAlgorithmType.Bubble, OrderBy.Desc);
            Sort(new int[10] { 26, 11, 9, 6, 29, 77, 37, 33, 8, 72 }, SortAlgorithmType.Insertion, OrderBy.Desc);
            Sort(new int[10] { 26, 11, 9, 6, 29, 77, 37, 33, 8, 72 }, SortAlgorithmType.Selection, OrderBy.Asc);
            Sort(new int[10] { 26, 11, 9, 6, 29, 77, 37, 33, 8, 72 }, SortAlgorithmType.Bubble, OrderBy.Asc);
            Sort(new int[10] { 26, 11, 9, 6, 29, 77, 37, 33, 8, 72 }, SortAlgorithmType.Insertion, OrderBy.Asc);
        }
        static int[] Insertion(int[] arr)
        {
            Console.WriteLine("Insertion sorting");
            PrintArray(arr);
            for (int i = 0; i < arr.Length - 1; i++)
            {
                for (int j = i + 1; j > 0; j--)
                {
                    if (arr[j - 1] > arr[j])
                    {
                        int temp = arr[j - 1];
                        arr[j - 1] = arr[j];
                        arr[j] = temp;
                    }
                }
            }
            return arr;
        }
        static int[] Bubble(int[] arr)
        {
            Console.WriteLine("Bubble sorting");
            PrintArray(arr);
            for (int write = 0; write < arr.Length; write++)
            {
                for (int sort = 0; sort < arr.Length - 1; sort++)
                {
                    if (arr[sort] > arr[sort + 1])
                    {
                        int temp = arr[sort + 1];
                        arr[sort + 1] = arr[sort];
                        arr[sort] = temp;
                    }
                }
            }
            return arr;
        }

        static int[] Selection(int[] arr)
        {
            Console.WriteLine("Selection Sorting");
            PrintArray(arr);
            int count = arr.Length;
            int temp, smallest;
            for (int i = 0; i < count - 1; i++)
            {
                smallest = i;
                for (int j = i + 1; j < count; j++)
                {
                    if (arr[j] < arr[smallest])
                    {
                        smallest = j;
                    }
                }
                temp = arr[smallest];
                arr[smallest] = arr[i];
                arr[i] = temp;
            }
            return arr;
        }

        static private void PrintArray(int[] arr)
        {
            Console.Write("Array is:\t");
            for (int i = 0; i < arr.Length; i++)
            {
                Console.Write(arr[i] + " ");
            }
            Console.WriteLine();
        }
        static int[] Sort(int[] arr, SortAlgorithmType sort, OrderBy orderBy)
        {
            switch (sort)
            {
                case SortAlgorithmType.Selection:
                    Selection(arr);
                    break;
                case SortAlgorithmType.Bubble:
                    Bubble(arr);
                    break;
                case SortAlgorithmType.Insertion:
                    Insertion(arr);
                    break;
                default:
                    break;
            }
            if (orderBy == OrderBy.Desc)
            {
               Array.Reverse(arr);
            }
            PrintArray(arr);
            return arr;
        }

    }
   public enum SortAlgorithmType
    {
        Selection,
        Bubble,
        Insertion
    }
    public enum OrderBy
    {
        Asc,
        Desc
    }
}