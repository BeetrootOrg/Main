using System;

namespace ConsoleApp
{
    #region LinkedList

    public class LinkedList<T>
    {
        private class ListItem
        {
            public T Value { get; init; }
            public ListItem Next { get; set; }
        }

        private ListItem _head;

        public LinkedList()
        {
            _head = null;
        }

        public void Add(T item)
        {
            _head = new ListItem
            {
                Value = item,
                Next = null
            };
        }

        public T[] GetAll()
        {
            if (_head != null)
            {
                return new T[] { _head.Value };
            }

            return Array.Empty<T>();
        }
    }

    #endregion

    class Program
    {
        static void Main()
        {
            var int1 = 5;
            var int2 = 7;

            Swap(ref int1, ref int2);

            var str1 = "string";
            var str2 = "hello";
            Swap(ref str1, ref str2);

            // ShowArray(new[] { 1, 2, 3 });
            // ShowArray(new[] { "hello", "Dima" });

            var list = new LinkedList<string>();
            list.Add("element");
            ShowArray(list.GetAll());
        }

        static void Swap<T>(ref T val1, ref T val2)
        {
            (val1, val2) = (val2, val1);
        }

        static void ShowArray<TElement>(TElement[] array)
        {
            foreach (var item in array)
            {
                Console.WriteLine(item);
            }
        }
    }
}