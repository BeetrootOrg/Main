using System;
namespace FirstProject
{
    class Program
    {
        static void Main()
        {
            int [] arr ={ 9,12,15,32,2,7};
            int[] arr2 = { 5, 6, 1, 8, 32, 9, 12 };
            int[] sortArr = QuickSort(arr,0,arr.Length -1);\
            //
            Console.WriteLine("QuickSort arr: ");
            PrintArr(sortArr);
            //
            BubbleSort(arr2);
            Console.WriteLine("BubbleSort arr: ");
            PrintArr(arr2);

        }
         static int[] QuickSort(int [] array,int minIn , int maxIn)
        {
            if (minIn >= maxIn)
            {
                return array;
            }
            int pivIn = GetPivIn(array,minIn,maxIn);
            QuickSort(array, minIn, pivIn - 1);
            QuickSort(array, pivIn + 1, maxIn);

            return array;
        }
        private static int GetPivIn(int[] array,int minIn,int maxIn)
        {
            int piv = minIn-1;
            for(int i=minIn; i<=maxIn; i++)
            {
                if (array[i] < array[maxIn])
                {
                    piv++;
                    Swap(ref array[piv], ref array[i]);
                }
            }
            piv++;
            Swap(ref array[piv], ref array[maxIn]);

            return piv;
        }
         static void Swap(ref int leftIn,ref int rightIn)
        {
            int temp=leftIn;
            leftIn=rightIn;
            rightIn=temp;
        }
        static void PrintArr(int[] arr)
        {
            for(int i = 0; i < arr.Length; i++)
            {
                Console.WriteLine(arr[i]);  
            }
        }

        static void BubbleSort(int [] arr)
        {
            for (var i = 1; i < arr.Length; i++)
            {
                for (var j = 0; j < arr.Length - i; j++)
                {
                    if (arr[j] > arr[j + 1])
                    {
                        Swap(ref arr[j], ref arr[j + 1]);
                    }
                }
            }
        }




    }

}