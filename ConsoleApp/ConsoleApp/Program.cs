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
            PrintArray(QuickSort(arr, 0, arr.Length - 1));
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

        static void Swap(ref int leftElement, ref int rightElement)
        {
            int temp = leftElement;
            leftElement = rightElement;
            rightElement = temp;
        }
    }
}