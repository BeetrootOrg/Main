using System;

namespace ConsoleApp
{
    class Program
    {

        static void Main(string[] args)
        {
            int[] array1 = { 1, 2, 3, 4, 5, 6 };
            array1 = new[] { 1, 2, 3, 4, 5, 6, 7, };
            array1 = new int[] { 1, 2, 3, 4 };
            array1 = new int[4] { 1, 2, 3, 4 };
            PrintArr(array1);
            UpdateFirstElementInArr(array1);
            PrintArr(array1);
            UpdateFirstElementInArrRef(ref array1);
            PrintArr(array1);

            int[] newArr = new int[10];
            for (int i = 0; i < newArr.Length; i++)
            {
                newArr[i] = i;
            }
            PrintArr(newArr);
            UpdateLength(ref newArr);
            PrintArr(newArr);

            //Sorting
            int[] newArr2 = { 1, 7, 5, 9, 2, 3, 6, 4, 8 };
            PrintArr(newArr2);
            int[] arr2 = Sort(newArr2);
            PrintArr(arr2);


            int[,] multidim = new int[,]
            {
                { 2, 3, 4 },
                { 5, 6, 7 }
            };

            foreach(var el in multidim)
            {
                Console.WriteLine(el);
            }

            int[][] jagged = new[]
            {
                new int[]{1,2,3,4},
                new int[]{5,6,7,8},

            };
            foreach(var innerArray in jagged)
            {
                foreach(var elem in innerArray)
                {
                    Console.WriteLine(elem);
                }
            }   


        }


        static void PrintArr(int[] arr)
        {
            Console.WriteLine();
            for (int i = 0; i < arr.Length; i++)
            {
                Console.WriteLine(arr[i]);
            }
            Console.WriteLine();
        }

        static void UpdateFirstElementInArr(int[] arr)
        {
            arr[0] = 42;
            arr = new[] { 5, 6, 7 }; 
        }

        static void UpdateFirstElementInArrRef(ref int[] arr)
        {
            arr[0] = 42;
            arr = new[] { 5, 6, 7 };
        }

        static void UpdateLength(ref int[] arr)
        {
            Console.WriteLine("Enter new array size: ");
            int n = Convert.ToInt32(Console.ReadLine());
            Array.Resize(ref arr, n);
        }

        static int[] Sort(int[] original)
        {
            int[] copy= new int [original.Length];
            Array.Copy(original, copy, original.Length);
            for(int i = 0; i < copy.Length - 1; i++)
            {
                int minIndex = i;
                for(int j = i + 1; j < copy.Length; j++)
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
