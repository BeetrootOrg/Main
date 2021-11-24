using System;
namespace FirstProject
{
    class Program
    {
        static void Main()
        {

            PrintArr(Sort(new[] {3,4,5,6,7,2}));
        }
        static void PrintArr(int[] arr)
        {
            for(int i=0; i<arr.Length; i++)
            {
                Console.WriteLine(arr[i]);  
            }
        }
    
        static int[] Sort(int[] original)
        {
            var copy = new int[original.Length];
            Array.Copy(original, copy, original.Length);
            for(int i =0;i< copy.Length; i++)
            {
                int minIndex = i;
                for(int j=i+1;j<copy.Length; ++j)
                {
                    if(copy[j]<copy[minIndex])
                    {
                        minIndex = j;   
                    }
                }
                var temp = copy[i];
                copy[i]= copy[minIndex];
                copy[minIndex] = temp;
            }
            return copy;
        }
    }
}

