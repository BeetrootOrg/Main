using System;

namespace ConsoleApp
{
    public class Program
    {

        #region LenkedList
        public class Stack<T>
        {
            private class StackItem
            {
                public T Value { get; set; }
                public StackItem Next { get; set; }
            }

            private StackItem _head;
            public int Count { get; private set; }

            public void Push(T item)
            {
                var stackItem = new StackItem
                {
                    Value = item,
                    Next = null
                };

                if (_head == null)
                {
                    _head = stackItem;
                }
                else
                {
                    stackItem.Next = _head;
                    _head = stackItem;
                }

                ++Count;
            }

            public T Pop()
            {
                if (_head == null)
                {
                    throw new ArgumentNullException(nameof(_head));
                }

                var firstElement = _head.Value;
                _head = _head.Next;

                --Count;

                return firstElement;
            }

            public void ShowAll()
            {
                var item = _head;
                for (int i = 0; i < Count; ++i)
                {
                    Console.WriteLine(item.Value);
                    item = item.Next;
                }
            }

            public void Clear()
            {
                _head = null;
                Count = 0;
            }
        }

        #endregion
        static void Main()
        {
            var int1 = 5;
            var int2 = 7;
            var int3 = 8;

            Stack<int> stack = new Stack<int>();
            stack.Push(int1);
            stack.Push(int2);
            stack.Push(int3);
            
            stack.ShowAll();
            int a = stack.Pop();

            Console.WriteLine($"Stack.Pop() = {a}");
            Console.WriteLine("After Pop():");
            stack.ShowAll();

        }
    }
}