using System;

namespace ConsoleApp
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine($"Enter the array length: \n");
            int n=Convert.ToInt32(Console.ReadLine());

            int[] array1 = new int[n];
            Console.WriteLine($"Enter the elements of the array: \n");
            for(int i = 0; i < n; i++)
            {
                array1[i]=Convert.ToInt32(Console.ReadLine());
            }
            BubbleSort(array1);
            Console.WriteLine($"Array after bubble sorting: ");
            for (int i = 0; i < n; i++)
            {
                Console.WriteLine($"\n{array1[i]}");
            }
        }
        static void Swap(ref int a,ref int b)
        {
            int temp = a;
            a = b;
            b = temp;
        }
        static int[] BubbleSort(int [] array)
        {
            int arrayLength=array.Length;
            for(int i = 1; i < arrayLength; i++)
            {
                for(int j = 0; j < arrayLength - i; j++)
                {
                    if (array[j] > array[j + 1])
                    {
                        Swap(ref array[j], ref array[j + 1]);
                    }
                }
            }
            return array;
        }
    }
}
