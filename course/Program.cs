using ICourse;

namespace Course
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

    public interface IWriteOnlyInterface<in T>
    {
        void Add (T item);
        T this[int index] { set; }
    }
    #endregion

    #region LinkedList

    public class LinkedList<T> : IList, IReadOnlyList<T>, IWriteOnlyInterface<T>
    {
        private class ListItem
        {
            public T Value { get; set; }
            public ListItem Next { get; set; }
        }

        private ListItem _head;
        private ListItem _tail;
        public int Count { get; set; }

        public void Add(T item)
        {
            var listItem = new ListItem
            {
                Value = item,
                Next = null
            };

            if (_head == null)
            {
                // list is empty
                _head = listItem;
                _tail = listItem;
            }
            else
            {
                _tail.Next = listItem;
                _tail = listItem;
            }
            Count++;
        }

        public T Get(int index)
        {
            var item = GetByIndex(index);
            return item.Value;
        }

        public void Clear()
        {
            _head = null;
            _tail = null;
            Count = 0;
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

            return Array.Empty<T>();
        }

        public T this[int index]
        {
            get => GetByIndex(index).Value;
            set
            {
                GetByIndex(index).Value = value;
            }
        }

        private ListItem GetByIndex(int index)
        {
            if (index < 0 && index >= Count)
            {
                throw new ArgumentOutOfRangeException($"List has only {Count} elements");
            }
            var item = _head;
            for (var i = 0; i < index; i++)
            {
                item = item.Next;
            }
            return item;
        }
    }

    #endregion

    class Course
    {
        static void Main()
        {
            var int1 = 5;
            var int2 = 7;
            Swap(ref int1, ref int2);

            ShowArray(new[] { 1, 2, 3, 4, 5 });

            var list = new LinkedList<string>();
            list.Add("element");
        }

        static void Swap<T>(ref T val1, ref T val2)
        {
            (val1, val2) = (val2, val1);
        }

        static void ShowArray<TElement>(TElement[] array)
        {
            foreach (var element in array) Console.WriteLine(element);
        }
    }
}
