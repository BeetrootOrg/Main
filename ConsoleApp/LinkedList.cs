using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp
{
    #region LinkedList
    public interface IList
    {
        int Count { get; }
        void Clear();
    }
    public interface IReadOnStack<out T> : IList
    {
        public T Pop();
        public T Peek();
    }
    public interface IWriteOnStack<in T> : IList
    {
        public void Push(T item);
    }
    public interface IReadOnlyList<out T> : IList
    {
        T[] GetAll();
        T this[int index] { get; }
    }
    public interface IWriteOnlyList<in T> : IList
    {
        void Insert(T item, int index);
        T this[int index] { set; }
    }
    public class LinkedList<T> : IReadOnlyList<T>, IWriteOnlyList<T>, IReadOnStack<T>, IWriteOnStack<T>
    {
        private class ListItem
        {
            public T Value { get; set; }
            public ListItem Next { get; set; }
        }
        private ListItem _head;
        public int Count { get; private set; }
        public void Push(T item)
        {
            // Console.WriteLine("Push: {0}", item.GetType());
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
        public T Pop()
        {
            try
            {
                return ShowAndRemove(Count - 1);
            }
            catch (Exception ex)
            {
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
        public void CopyTo(T[] array)
        {
            if (Count <= 0)
            {
                array = null;
                return;
            }
            var item = _head;
            for (int i = 0; i < Count; ++i)
            {
                array[i] = item.Value;
                item = item.Next;
            }
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
}
