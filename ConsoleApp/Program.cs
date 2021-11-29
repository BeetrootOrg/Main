using System;

namespace ConsoleApp
{
    class Program
    {
        static void Main()
        {
            //пузырьковый метод сортировки

            //declare array at first

            //int[] array = { 5,6,2,1,0,23,12,32 };
            int[] array = new[] { 1, 7, 8, 1, 2, 3 };
            Console.WriteLine("Array before:");
            Console.WriteLine(string.Join(" ",array));
            //PrintArray(array);
            var sortedArray = Sort(array);
            Console.WriteLine(string.Join(" ", sortedArray));
            //PrintArray(sortedArray);

            static void PrintArray(int[] arr)
            {
                string str = "";
                for (int i = 0; i < arr.Length; i++)
                {
                    str+=" "+(arr[i]);
                }
                Console.WriteLine(str);
            }

            static int[] Sort(int[] original)
            {
                int[] copy = new int[original.Length];
                Array.Copy(original, copy, original.Length);

                for (int j= copy.Length-1; j>0;--j)//проверить длину перебора
                {     
                    for (int i =0; i < j ; ++i) //проверить длину перебора
                    {
                        if (copy[i] > copy[i+1])
                        {
                            int tempInt = copy[i];
                            copy[i]=copy[i+1];
                            copy[i + 1] = tempInt;
                        }
                    }
                }
                return copy;
            }





        }
    }
}