using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleAp15Generic
{
    public abstract class ElementBase
    {
        protected ElementBase _next { get; set; }
        public ElementBase GetNext() => _next == null ? this : _next.GetNext();
        public void SetNext(ElementBase element) => _next = element;
    }
}
