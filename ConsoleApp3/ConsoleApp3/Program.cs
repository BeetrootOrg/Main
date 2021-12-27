using System;

namespace ConsoleApp
{

    public class Stack<T>
    {
        public T[] Stck { get; set; }
        public int Top { get; set; }
        public int Size { get; }

        public Stack(int Size)
        {
            Stck = new T[Size]; 
            this.Size = Stck.Length;
        }

        public void Push(T Element)
        {

            if (Top == Size)
            {
                throw new InvalidOperationException("You are nerd!!! STACK OVERFLOW!!!");
            }
            else
            {
            Stck[Top] = Element;
            Top++;
            }
        }

        public T Pop()
        {
            if (Top > 0)
            {

                T lastElement = Stck[Top-1];
                Stck[Top - 1]=default(T);
                Top--;
                return lastElement;
            }
            return default(T);
        }

        public void Clear()
        {
            Stck = default(T[]);
            Top = 0;
        }

        public T Peek()
        {
            return Stck[Top-1];
        }

        public T[] CopyTo()
        {
            T[] S = new T[Top];
            Array.Copy( Stck, S, Top);
            return S;
        }

        public override string ToString()
        {
            if (Top>0)
            {
                return string.Concat("CONTENTS OF THE STACK: ",string.Join(", ", Stck.Skip(0).Take(Top).ToArray()));  
            }
            else
            {
                return "STACK IS EMPTY";
            }
            
        }
    }


    class Program
    {
        static void Main()
        {
            Stack<int> stack = new Stack<int>(5);

            Console.WriteLine(stack.Top);
            Console.WriteLine(stack);

            stack.Push(1);
            stack.Push(2);
            stack.Push(3);
            stack.Push(4);
            stack.Push(5);

            Console.WriteLine(stack);

            int t = stack.Peek();
            Console.WriteLine($"Last element is: {t}");
            Console.WriteLine(stack);

            t = stack.Pop();
            Console.WriteLine($"Last element is: {t}");
            Console.WriteLine(stack);

            int[] arr;
            arr = stack.CopyTo();

            string result = string.Join(" ", arr);
            Console.WriteLine($"STACK COPY RESULT: {result}");

            stack.Clear();
            Console.WriteLine(stack);
        }

    }
}