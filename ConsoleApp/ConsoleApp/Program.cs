using System;

namespace ConsoleApp
{
    public class Program
    {
        #region Interfaces

        public interface IList
        {
            int Count { get; }
            void Clear();
        }
        
        public interface IReadOnlyList<out T>
        {
            T[] GetAll();
            T this[int index] { get; }
        }

        public interface IWriteOnlyList<in T>
        {
            void Add(T item);
            T this[int index] { set; }
        }

        #endregion

        #region LenkedList
        public class LenkedList<T> : IList, IReadOnlyList<T>, IWriteOnlyList<T>
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
                    _head = listItem;
                    _tail = listItem;
                }
                else
                {
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

                for(int i = 0; i < Count; i++)
                {
                    array[i] = item.Value;
                    item = item.Next;
                }
                return array;
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

            public void Clear()
            {
                _head = null;
                _tail = null;
                Count = 0;
            }
        }

        #endregion
        static void Main()
        {
            var int1 = 5;
            var int2 = 7;

            Swap(ref int1,ref int2);

            var string1 = "string";
            var string2 = "hello";

            Swap(ref string1,ref string2);

            //ShowArray(new[] { 1, 2, 3 });
            //ShowArray(new[] { "Hello", "Dima" });


            var list = new LenkedList<string>();
            list.Add("element");
            ShowArray(list.GetAll());


            IReadOnlyList<string> readOnlyList = list;
            IWriteOnlyList<string> writeOnlyList = list;


        }
         
        static void Swap<T>(ref T val1,ref T val2)
        {
            (val1, val2) = (val2, val1);
        }

        static void ShowArray<TElement>(TElement[] array)
        {
            foreach(var item in array)
            {
                Console.WriteLine(item);
            }
        }
    }
}