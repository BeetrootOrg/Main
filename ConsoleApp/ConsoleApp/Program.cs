using System;
using System.Collections.Generic;
using System.Linq;

namespace ConsoleApp
{
    delegate bool Dima(int number);

    class Program
    {
        static void Main()
        {
            var array = Enumerable.Range(0, 10);
            ShowAll(FilterValues(array, (int item) => item > 5));
            ShowAll(FilterValues(array, OddOnly));

            // 1st option - decalre delegate
            Dima evenOnly = (int item) => item % 2 == 0;
            ShowAll(FilterValues(array, evenOnly));

            // 2nd option - declare anonymous method
            static bool OddOnly(int item) => item % 2 == 1;

            var number = 0;
            Func<int, int> calculate = (i) =>
            {
                number += i;
                return number;
            };

            Func<int, int> calculate2 = (i) =>
            {
                var number = 0;
                number += i;
                return number;
            };

            calculate2(5);
            calculate2(2);

            Console.WriteLine("NUMBER");
            Console.WriteLine(number);
        }

        public static IEnumerable<int> FilterValues(IEnumerable<int> collection, Dima predicate)
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