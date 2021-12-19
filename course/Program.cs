namespace Course
{
    class Course
    {
        static void Main()
        {
            var stack = new Stack<string>();
            stack.Push("A");
            stack.Push("B");
            stack.Push("C");
            var arr = new string[] {};
            stack.CopyTo(ref arr);
            PrintArray(arr);
        }

        static void PrintArray<T>(T[] arr)
        {
            foreach (T item in arr)
            {
                Console.WriteLine(item);
            }
        }
    }

    public class Stack<T>
    {
        public class StackItem
        {
            public T Value { get; set; }
            public StackItem Previous { get; set; }
        }

        private StackItem _last;
        private int _count;

        public void Push(T obj)
        {
            var stackItem = new StackItem
            {
                Value = obj
            };

            if (_last == null)
            {
                _last = stackItem;
            }
            else
            {
                stackItem.Previous = _last;
                _last = stackItem;
            }
            ++_count;
        }

        public T Pop()
        {
            var valueToReturn = _last.Value;
            _last = _last.Previous;
            --_count;
            return valueToReturn;
        }

        public void Clear()
        {
            _last = null;
        }

        public T Peek()
        {
            return _last.Value;
        }

        public int Count => _count;

        public void CopyTo(ref T[] arr)
        {
            Array.Resize<T>(ref arr, _count);
            var stackItem = _last;
            for (int i = 0; i < _count; i++)
            {
                arr[i] = stackItem.Value;
                stackItem = stackItem.Previous;
            }
        }
    }
}
