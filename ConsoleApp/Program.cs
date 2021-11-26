using System;

namespace ConsoleApp
{
    class Program
    {
        static void Main()
        {
            //пузырьковый метод сортировки
            
            //declare array at first

            int[] array = { 5,6,2,1,0,23,12,32 };
            Console.WriteLine("Array before:");
            PrintArray(array);
            var sortedArray = Sort(array);
            PrintArray(sortedArray);

            static void PrintArray(int[] arr)
            {
                string str = "";
                for (int i = 0; i < arr.Length; i++)
                {
                    str=str+" "+(arr[i]);
                }
                Console.WriteLine(str);
            }

            static int[] Sort(int[] original)
            {
                int[] copy = new int[original.Length];
                Array.Copy(original, copy, original.Length);

                for (int j=0; j<copy.Length;++j)//проверить длину перебора
                {
               
                for (int i =0; i < j ; ++i) //проверить длину перебора
                {
                        if (copy[i] > copy[i+1])
                        {
                            int tempInt = copy[i];
                            copy[i]=copy[i+1];
                            copy[i + 1] = tempInt;
                        };
                }
                }


                return copy;
            }





        }
    }
}