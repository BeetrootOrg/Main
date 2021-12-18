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
        public int Count { get; private set; }

        public void Add(T item)
        {
            var listItem = new ListItem
            {
                Value = item,
                Next = null
            };

            if (_head == null)
            {
                // list is empty - assign head
                _head = listItem;
            } 
            else
            {
                // list is not empty - go to last element
                var last = _head;
                while (last.Next != null)
                {
                    last = last.Next;
                }

                last.Next = listItem;
            }

            ++Count;
        }

        public T[] GetAll()
        {
            var array = new T[Count];
            var item = _head;

            for (int i = 0; i < Count; i++)
            {
                array[i] = item.Value;
                item = item.Next;
            }

            return array;
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
            list.Add("el1");
            list.Add("el2");
            list.Add("el3");
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