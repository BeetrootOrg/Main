using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Demo
{
    public class ElementBase
    {
        public ElementBase _next { get; set; }
        public int _number { get; set; }

        public ElementBase(int _element)
        {
            this._number = _element;
        }

        public ElementBase GetElement()
        {
            if (_next == null)
            {
                return this;
            }
            return _next.GetElement();
        }
        public void SetNext(ElementBase elementBase)
        {
            _next = elementBase;
        }
    }
}