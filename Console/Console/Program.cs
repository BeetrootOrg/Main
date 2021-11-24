using System;


namespace Program
{

    class Program
    {
        static void Main()
        {
            int[] array = { 1, 2, 3, 4, 5, 6, 7, 8, };
            array = new[] { 1, 2, 3, 4 };
            array = new int[] { 1, 2 };
            array = new int[4] { 1, 2, 3, 4 };

            int[] array1 = array;
            PrintArray(array);

            Array.Resize(ref array, 10);
            PrintArray(array);
            PrintArray(array1);

            Program[] programs = new Program[2];
            array = new int[4] { 1, 2, 3, 4 };
            PrintArray(Sort(array));
            array = new int[4] { 4, 3, 2, 1 };
            PrintArray(Sort(array));
            array = new int[4] { 122, 22, 33, 4 };
            PrintArray(Sort(array));
        }


        static void PrintArray(int[] array)
        {
            for (int i = 0; i < array.Length; i++)
            {
                Console.WriteLine(array[i]);
            }
        }

        static void UpdateFirstElement(int[] arr)
        {
            arr[0] = 42;
        }

        static int[] Sort(int[] original)
        {
            int[] copy = new int[original.Length];
            Array.Copy(original, copy, original.Length);

            for(int i = 0; i < copy.Length-1; i++)
            {
                int minIndex = i;
                for(int j = 0; j < copy.Length; j++)
                {
                    if(copy[j] < copy[minIndex])
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
    }
}