namespace ConsoleApp
{
    using System;

    class ConsoleApp
    {
        #region LinkedList

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
            public void Push(T item) //  - adds obj at the top of stack
            {
                Console.WriteLine("Push: {0}", item);
                Insert(item, Count);
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

            private T ShowAndRemove(int index)
            {
                T retValue;
                if ((index == Count) || (index < 0))
                {
                    // throw new ArgumentOutOfRangeException(nameof(index));
                    throw new Exception("Stack is Empty");
                }

                if (index == 0)
                {
                    var prev = GetByIndex(0);
                    retValue = prev.Value;
                    _head = _head.Next;
                }
                else
                {
                    var prev = GetByIndex(index - 1);
                    retValue = prev.Next.Value;
                    prev.Next = prev.Next.Next;
                }

                --Count;
                return retValue;
            }
            private T Show(int index)
            {
                T retValue;
                if ((index == Count) || (index < 0))
                {
                    throw new Exception("Stack is Empty");
                    // throw new ArgumentOutOfRangeException(nameof(index));
                }

                if (index == 0)
                {
                    var prev = GetByIndex(0);
                    retValue = prev.Value;
                }
                else
                {
                    var prev = GetByIndex(index - 1);
                    retValue = prev.Next.Value;
                }
                return retValue;
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
            public T Pop()
            {
                try
                {
                    return ShowAndRemove(Count - 1);
                }
                catch (Exception ex)
                {
                    // Console.WriteLine(" - " + ex.Message);
                    return default(T);
                }
            }
            public T Peek()
            {
                try
                {
                    return Show(Count - 1);
                }
                catch (Exception ex)
                {
                    // Console.WriteLine(" - " + ex.Message);
                    return default(T);
                }
            }
            //void CopyTo(/*arr*/) // - copies stack to array
            //{

            //}
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
        static void Main(string[] args)
        {
            Console.WriteLine("\r\n a.tkachenko/homework/15-Stack \r\n");

            try
            {
                var list = new LinkedList<string>();
                list.Push("el1");
                ShowArray(list.GetAll());
                list.Push("el2");
                ShowArray(list.GetAll());
                list.Push("el3");
                ShowArray(list.GetAll());

                Console.WriteLine("Stack Count: {0}\r\n", list.Count);

                list.Clear();
                Console.WriteLine("Stack Count: {0}\r\n", list.Count);
                ShowArray(list.GetAll());

                list.Push("el4");
                ShowArray(list.GetAll());
                list.Push("el5");
                ShowArray(list.GetAll());
                list.Push("el6");
                ShowArray(list.GetAll());
                list.Push("el7");
                ShowArray(list.GetAll());

                Console.WriteLine("Pop: {0}", list.Pop());
                ShowArray(list.GetAll());
                Console.WriteLine("Pop: {0}", list.Pop());
                ShowArray(list.GetAll());

                Console.WriteLine("Peek: {0}", list.Peek());
                ShowArray(list.GetAll());

                Console.WriteLine("Pop: {0}", list.Pop());
                ShowArray(list.GetAll());
                Console.WriteLine("Pop: {0}", list.Pop());
                ShowArray(list.GetAll());

                list.Clear();
                Console.WriteLine("Stack Count: {0}\r\n", list.Count);
                ShowArray(list.GetAll());

            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }
        static void ShowArray<TElement>(TElement[] array)
        {
            if(array.Length == 0)
            {
                Console.Write("Stack is empty!\r\n");
                return;
            }
            Console.Write("All Stack:\r\n");
            for(int i = array.Length-1; i >= 0; i--)
            {
                Console.WriteLine(array[i].ToString());
            }
            Console.Write("\r\n");
        }
    }
}
