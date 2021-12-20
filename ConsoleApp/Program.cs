using System;
using System.Collections.Generic;

namespace ConsoleApp
{
  
    class Program
    {
        static void Main()
        {
            var array = Enumerable.Range(0, 10);
            ShowAll(FilterValues(array, (int item) => item > 5));
         
        }

        public static IEnumerable<int> FilterValues(IEnumerable<int> collection, Func<int, bool> predicate)
        {
            foreach (var item in collection)
            {

                if (predicate(item))
                {
                    yield return item;
                }
            }
        }
        public static void ShowAll<T>(IEnumerable<T> collection)
        {
            foreach (var item in collection)
            {
                Console.WriteLine(item);
            }
        }
    }


}   