using System;

namespace ConsoleApp
{
    public class Program
    {
        #region LenkedList
        public class LenkedList<T>
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

                if(_head == null)
                {
                    _head = listItem;
                }
                else
                {
                    var last = _head;
                    while(last.Next != null)
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

                for(int i = 0; i < Count; i++)
                {
                    array[i] = item.Value;
                    item = item.Next;
                }
                return array;
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