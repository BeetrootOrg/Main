using System;

namespace ConsoleApp
{
    class Program
    {
        static void Main()
        {
            // init array (all same options)
            // 1 option
            int[] array = { 1, 2, 3 };

            // 2 option
            array = new[] { 1, 2, 3 };

            // 3 option
            array = new int[] { 1, 2, 3 };

            // 4 option
            array = new int[3] { 1, 2, 3 };

            UpdateFirstElement(array);
            PrintArray(array);

            UpdateFirstElementRef(ref array);
            PrintArray(array);

            int[] newArr = new int[10];
            Console.WriteLine("Before init");
            PrintArray(newArr);

            for (int i = 0; i < newArr.Length; i++)
            {
                newArr[i] = i;
            }

            Console.WriteLine("After init");
            PrintArray(newArr);

            var original = newArr;

            Array.Resize(ref newArr, 15);
            Console.WriteLine(ReferenceEquals(original, newArr));
            Console.WriteLine("After resize to bigger");
            PrintArray(newArr);

            Array.Resize(ref newArr, 5);
            Console.WriteLine("After resize to smaller");
            PrintArray(newArr);

            var temp = newArr[1];
            temp = 43;
            newArr[0] = 42;

            Console.WriteLine("Get copy");
            PrintArray(original);

            Console.WriteLine("Sorting");

            // no sort at all
            PrintArray(Sort(new[] { 3, 5, 2, 6, 7 }));

            // already sorted
            PrintArray(Sort(new[] { 1, 2, 3, 4, 5 }));

            // sorted vice versa
            PrintArray(Sort(new[] { 5, 4, 3, 2, 1 }));

            ShowAll();
            ShowAll(1, 2, 3);
            ShowAll(new []{ 1, 2 });

            int[,] multidim = new int[,]
            {
                { 2, 3, 4 }, 
                { 5, 6, 7 }    
            };

            Console.WriteLine("MULTI");
            foreach (var item in multidim)
            {
                Console.WriteLine(item);
            }

            var three = multidim[0, 1];
        }

        static void ShowAll(params int[] arr)
        {
            foreach (var el in arr)
            {
                Console.WriteLine(el);
            }
        }

        static void PrintArray(int[] arr)
        {
            for (int i = 0; i < arr.Length; i++)
            {
                Console.WriteLine(arr[i]);
            }
        }

        static void UpdateFirstElement(int[] arr)
        {
            arr[0] = 42;
            arr = new[] { 5, 6, 7 };
        }

        static void UpdateFirstElementRef(ref int[] arr)
        {
            arr[0] = 42;
            arr = new[] { 5, 6, 7 };
        }

        // Selection sort
        static int[] Sort(int[] original)
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
    }
}