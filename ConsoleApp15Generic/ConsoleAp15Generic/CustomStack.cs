using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleAp15Generic
{
    public class CustomStack<T> where T : ElementBase
    {
        private T _first { get; set; }
        public CustomStack(T element)
        {
            _first = element;
        }

        public void Add(T next)
        {
            var top = _first.GetNext();
            top.SetNext(next);
        }

        public T Pop() => (T)_first.GetNext();
    }
}
