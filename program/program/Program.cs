using System;
namespace  ConsoleApp
{
    class Program
    {
        static void Main()
        {
            //bublle sort
            int[] array = {30,89,1,8,46,98};
            Sort(array);
            Console.WriteLine("Sorted array");
            printArray(array);
            
        }


         static void Sort(int[] array)
        {
            int n = array.Length;

            for (int i = 0; i < n - 1; i++)
                for (int j = 0; j < n - i - 1;j++)
            if (array[j] > array[j+1])
            {
                int temp = array[j];
                array[j] = array[j + 1];
                array[j + 1] = temp;
            }

            
        }
        static void printArray(int[] array)
        {
            int n = array.Length;
            for (int i = 0; i < n; ++i)
                Console.Write(array[i] + ",");
            Console.WriteLine();
        }


    }
}