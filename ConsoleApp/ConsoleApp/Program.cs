using System;

namespace ConsoleApp
{
    #region LinkedList

    public class LinkedList<T>
    {
        private class ListItem
        {
            public T Value { get; set; }
            public ListItem Next { get; set; }
        }

        private ListItem _head;
        private ListItem _tail;
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
                // list is empty - assign head & tail
                _head = listItem;
                _tail = listItem;
            } 
            else
            {
                // list is not empty - reassign tail
                _tail.Next = listItem;
                _tail = listItem;
            }

            ++Count;
        }

        public T this[int index]
        {
            get => GetByIndex(index).Value;
            set
            {
                var item = GetByIndex(index);
                item.Value = value;
            }
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

        private ListItem GetByIndex(int index)
        {
            if (index >= Count)
            {
                throw new ArgumentOutOfRangeException(nameof(index));
            }

            var item = _head;
            for (int i = 0; i < index; i++)
            {
                item = item.Next;
            }

            return item;
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

            list[0] = "el4";

            Console.WriteLine(list[0]);
            Console.WriteLine(list[1]);
            Console.WriteLine(list[2]);
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