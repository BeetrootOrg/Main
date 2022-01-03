﻿using System;

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

            public T Peek()
            {
                if (_head == null)
                {
                    throw new ArgumentNullException(nameof(_head));
                }

                var firstElement = _head.Value;

                return firstElement;
            }
            
            public void ShowAll()
            {
                if (Count == 0)
                {
                    Console.WriteLine("Stack Is Empty!!!");
                }
                else
                {
                    var item = _head;
                    for (int i = 0; i < Count; ++i)
                    {
                        Console.WriteLine(item.Value);
                        item = item.Next;
                    }
                }
            }

            public T[] CopyToArray()
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
        }

        #endregion
        static void Main()
        {
            var int1 = 1;
            var int2 = 2;
            var int3 = 3;
            var int4 = 4;

            Stack<int> stack = new Stack<int>();
            stack.Push(int1);
            stack.Push(int2);
            stack.Push(int3);
            stack.Push(int4);
            
            stack.ShowAll();

            int a = stack.Pop();

            Console.WriteLine($"Stack.Pop() = {a}");
            Console.WriteLine("After Pop():");
            stack.ShowAll();

            a = stack.Peek();
            Console.WriteLine($"Stack.Peek() = {a}");
            Console.WriteLine("After Peek():");
            stack.ShowAll();

            Console.WriteLine("\nIn Array");
            var arr = stack.CopyToArray();

            for (int i = 0; i < arr.Length; i++)
            {
                Console.WriteLine(arr[i]);
            }

            Console.WriteLine($"Count elements = {stack.Count}");
            stack.Clear();
            stack.ShowAll();

        }
    }
}