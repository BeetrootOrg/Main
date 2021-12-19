using System;

namespace ConsoleAp15Generic
{
    public class Program
    {
        static void Main(string[] args)
        {
            var stack = new CustomStack<NumerableElement>(new NumerableElement() { Number = 1});
            stack.Add(new NumerableElement() { Number = 3 });
            stack.Add(new NumerableElement() { Number = 2 });
            Console.WriteLine(stack.Pop().Number);
        }
    }
}
