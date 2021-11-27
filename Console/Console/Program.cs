﻿namespace Console
{
    using System;
    public class Program
    {
        static void Main()
        {
            int[] arr = { 1, 2, 5, 88, 123, 15, 78, 12, 5, 6, 7, 78, 212, 23, 45, 66, 22, 12, };
            BubbleSrt(ref arr);
            PrintArr(arr);

        }

        public static void PrintArr(int[] array)
        {
            foreach (int item in array)
            {
                Console.WriteLine(item);   
            }
        }

        public static void BubbleSrt(ref int[] array)
        {
            bool val = false;
            for(int i =0; i<array.Length-1; i++)
            {
                if(val)
                {
                    val = BubbleSrt(ref array, i);
                    val = true;
                }
                else val = BubbleSrt(ref array, i);
            }
            if (val)
            {
                val = false;
                BubbleSrt(ref array);
            }           
        }
        public static bool BubbleSrt(ref int[] array, int count)
        {
            if(array[count] > array[count + 1])
            {
                int x = array[count];
                array[count] = array[count + 1];
                array[count + 1] = x;
                return true;
            }
            else if(array[count] <=  array[count + 1])
            {
                return false;
            }
            return false;

        }

    }


}