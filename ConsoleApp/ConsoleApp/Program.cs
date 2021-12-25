using System;

namespace ConsoleApp
{
    //i.safontev/classwork/15-generics
    public class Stack<T>
    {
        public T[] Arr { get; set; }
        public int Top { get; set; }
        public int Count { get; set; }

        public Stack(int Count)
        {
            this.Count = Count;
            Arr = new T[Count];
        }

        public void Push(T Element) 
        {
            int k = 1;
            if (Top == Count)
            {
                T[] newArray = new T[Top + 1];
                Array.Copy(Arr, 0, newArray, 0, Top);
                Arr = newArray;
                k = 0;
            }
            Arr[Top] = Element;
            Top += k;
        }

        public T Pop()
        {
            if (Top > 0)
            {
                Console.WriteLine(Top);
                T lastElement = Arr[Top];
                Top--;
                return lastElement;
            }
            return default(T);
        }

        public void Clear()
        {
            Arr = default(T[]);
            Top = 0;
        }

        public T Peek()
        {
            return Arr[Top];
        }

        public T[] CopyTo()
        {
            T[] newArray = new T[Top];
            Array.Copy(Arr, 0, newArray, 0, Top);
            return newArray;    
        }

        public override string ToString()
        {
            string s = null;
            for(int i = 0; i <= Top; i++)
            {
                s += " " + Arr[i];
            }
            return $"Arr={s}\n";
        }
    }
    class Program
    {
        static void Main()
        {
            Stack<int> arr1 = new Stack<int>(3);

            arr1.Push(1);
            arr1.Push(2);
            arr1.Push(3);
            arr1.Push(4);

            Console.WriteLine(arr1);

            int t = arr1.Peek();
            Console.WriteLine($"Last element is: {t}");
            Console.WriteLine(arr1);

            t = arr1.Pop();
            Console.WriteLine($"Last element is: {t}");
            Console.WriteLine(arr1);

            int[] arr2;
            arr2 = arr1.CopyTo();

            arr1.Clear();

        }


    }
}