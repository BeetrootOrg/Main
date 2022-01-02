using System;

namespace ConsoleApp
{
    /*Create generic Stack<T>(what it is) class with next methods:

Push(obj) - adds obj at the top of stack
Pop() - returns top element of stack & removes it
Clear() - clear stack
Count - property return number of elements
Peek() - returns top element but doesn’t remove it
CopyTo(arr) - copies stack to array
    */
    public class Stack<T>
    {
        private class StackItem
        {
            public T Value { get; set; }
            public StackItem Next { get; set; }

        }

        private StackItem _base;
        public int Count { get; private set; }

        public void Push(T item)
        {
            Insert(item, 0);
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
            var item = _base;

            for (int i = 0; i < Count; ++i)
            {
                array[i] = item.Value;
                item = item.Next;
            }

            return array;
        }

        public T[] CopyToArr(T[] arr)
        {
            arr = GetAll();
            return arr;
        }

        public void Clear()
        {
            _base = null;
            Count = 0;
        }

        public T Pop()
        {
            var tItem = _base;
            if (Count > 0)
            {
                _base = _base.Next;
                --Count;
            }
            else
            throw new ArgumentException("there isn't elements do delete");
            
            return tItem.Value;
            
        }

       public T  Peek()
       {
            return _base.Value;
        
       }

        public void Insert(T item, int index)
        {
            if (index == 0)
            {
                var stackItem = new StackItem
                {
                    Value = item,
                    Next = _base
                };

                _base = stackItem;
            }
            else
            {
                var prev = GetByIndex(index-1);

                var stackItem = new StackItem
                {
                    Value = item,
                    Next = prev.Next
                };

                prev.Next = stackItem;
            }

            ++Count;
        }


        private StackItem GetByIndex(int index)
        {
            if (index < 0 || index >= Count)
            {
                throw new ArgumentOutOfRangeException(nameof(index));
            }

            var item = _base;
            for (int i = 0; i < index; i++)
            {
                item = item.Next;
            }

            return item;
        }

    }


    class Program
    {
        static void Main()
        {

            var stack = new Stack<int>();
            stack.Push(1);
            stack.Push(2);
            stack.Push(3);
            stack.Push(0);
        



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