using System;



namespace ConsoleApp
{
    class Program
    {
        static void Main()
        {
            int[] array = { 9, 3, 8, 5, 2, 6, 4, 1, 7, 10, 0 };
            Console.WriteLine("Unsorted");
            PrintArray(array);
            Console.WriteLine("Insertion Sort");
            PrintArray(InsertionSort(array));
            Console.WriteLine("Bubble Sort");
            PrintArray(BubbleSort(array));
        }

        static void PrintArray(int[] arr)
        {
            for (int i = 0; i < arr.Length; i++)
            {
                Console.WriteLine(arr[i]);
            }
        }

        //Selection Sort - from classwork
        static int[] SelectionSort(int[] original)
        {
            int[] copy = new int[original.Length];
            Array.Copy(original, copy, original.Length);
            for (int i = 0; i < copy.Length - 1; ++i)
            {
                int minIndex = i;
                for (int j = i + 1; j < copy.Length; ++j)
                {
                    if (copy[j] < copy[minIndex])
                    {
                        minIndex = j;
                    }
                }

                var temp = copy[i];
                copy[i] = copy[minIndex];
                copy[minIndex] = temp;
            }
            return copy;
        }

        // Insertion Sort
        static int[] InsertionSort(int[] original)
        {
            int[] copy = new int[original.Length];
            Array.Copy(original, copy, original.Length);

            for (int i = 1; i < copy.Length; i++)
            {
                int currentElement = copy[i],
                    previousElementIndex = i - 1;
                while (previousElementIndex >= 0 && copy[previousElementIndex] > currentElement)
                {
                    copy[previousElementIndex + 1] = copy[previousElementIndex];
                    previousElementIndex = previousElementIndex - 1;
                }
                copy[previousElementIndex + 1] = currentElement;
            }
            return copy;
        }

        // Bubble Sort
        static int[] BubbleSort(int[] original)
        {
            int[] copy = new int[original.Length];
            Array.Copy(original, copy, original.Length);

            for (int i = 0; i < copy.Length - 1; i++)
                for (int j = 0; j < copy.Length - i - 1; j++)
                    if (copy[j] > copy[j + 1])
                    {
                        int temp = copy[j];
                        copy[j] = copy[j + 1];
                        copy[j + 1] = temp;
                    }
            return copy;
        }
    }
}