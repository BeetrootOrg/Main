using System;

namespace ConsoleApp
{
    //i.safontev/classwork/15-generics
    #region Interfaces

    public interface IList
    {
        int Count { get; }
        void Clear();
        void Remove(int index);
    }


    public interface IReadOnlyList<out T> : IList
    {
        T[] GetAll();
        T this[int index] { get; }
    }

    public interface IWriteOnlyList<in T> : IList
    {
        void Add(T item);
        void Insert(T item, int index);
        T this[int index] { set; }
    }

    #endregion

    #region LinkedList

    public class LinkedList<T> : IReadOnlyList<T>, IWriteOnlyList<T>
    {
        private class ListItem
        {
            public T Value { get; set; }
            public ListItem Next { get; set; }
        }

        private ListItem _head;
        public int Count { get; private set; }

        public void Add(T item) => Insert(item, Count);

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

            for (int i = 0; i < Count; ++i)
            {
                array[i] = item.Value;
                item = item.Next;
            }

            return array;
        }

        public void Clear()
        {
            _head = null;
            Count = 0;
        }

        public void Remove(int index)
        {
            if (index == Count)
            {
                throw new ArgumentOutOfRangeException(nameof(index));
            }

            if (index == 0)
            {
                _head = _head.Next;
            }
            else
            {
                var prev = GetByIndex(index - 1);
                prev.Next = prev.Next.Next;
            }

            --Count;
        }

        public void Insert(T item, int index)
        {
            if (index == 0)
            {
                var listItem = new ListItem
                {
                    Value = item,
                    Next = _head
                };

                _head = listItem;
            }
            else
            {
                var prev = GetByIndex(index - 1);

                var listItem = new ListItem
                {
                    Value = item,
                    Next = prev.Next
                };

                prev.Next = listItem;
            }

            ++Count;
        }

        private ListItem GetByIndex(int index)
        {
            if (index < 0 || index >= Count)
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

            ShowArray(list.GetAll());

            // ShowRandomListElement(list);
            // SetRandomListElement(list, "element");

            list[0] = "el0";
            list[1] = "el1";
            list[2] = "el2";

            list.Remove(0);
            list.Add("el3");
            list.Remove(2);
            list.Add("el4");
            list.Remove(1);

            Console.WriteLine("AFTER REMOVE");
            ShowArray(list.GetAll());

            list.Insert("insert0", 0);
            list.Insert("insert1", 3);
            list.Insert("insert2", 2);

            list.Clear();
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

        static void ShowRandomListElement<T>(IReadOnlyList<T> list)
        {
            var index = new Random((int)DateTime.Now.Ticks).Next(0, list.Count);
            Console.WriteLine(list[index]);
        }

        static void SetRandomListElement<T>(IWriteOnlyList<T> list, T element)
        {
            var index = new Random((int)DateTime.Now.Ticks).Next(0, list.Count);
            list[index] = element;
        }
    }
}