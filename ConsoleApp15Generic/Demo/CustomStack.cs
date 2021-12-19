using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Demo
{
    public class CustomStack 
    {
        public ElementBase _first { get; set; }

        public ElementBase Pop()
        {
            return _first.GetElement();
        }
        
        public void Add(ElementBase element)
        {
            var last = Pop();
            last.SetNext(element);
        }
    }
}
