using System;

namespace ConsoleApp
{
    public class Stack<T>
    {
        private class StackItem
        { 
            public T Value { get; init; }
            public StackItem Next { get; set; }
        }

        private StackItem _head;
        public int Count { get; private set; }

        public void Push(T item)
        {
            var head = new StackItem
            {
                Value = item,
                Next = _head
            };

            _head = head;
            ++Count;
        }

        public T Pop()
        {
            ValidateAnyElement();

            var item = _head;
            _head = _head.Next;
            --Count;

            return item.Value;
        }

        public void Clear()
        {
            _head = null;
            Count = 0;
        }

        public T Peek()
        {
            ValidateAnyElement();
            return _head.Value;
        }

        public void CopyTo(T[] arr)
        {
            var length = Math.Min(Count, arr.Length);

            var current = _head;
            for (int i = 0; i < length; i++)
            {
                arr[i] = current.Value;
                current = current.Next;
            }
        }

        private void ValidateAnyElement()
        {
            if (Count == 0)
            {
                throw new ArgumentException("Stack is empty");
            }
        }
    }

    class Program
    {
        static void Main()
        {
            var stack = new Stack<int>();

            stack.Push(1);
            stack.Push(2);

            var item = stack.Pop();
            item = stack.Peek();
            item = stack.Peek();

            stack.CopyTo(new int[0]);
            stack.CopyTo(new int[1]);
            stack.CopyTo(new int[2]);
        }
    }
}