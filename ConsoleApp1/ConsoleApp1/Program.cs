namespace Homework
{

    public class Program
    {

        public void Main()
        {

        }

        public class Stack<T>
        {
            private class ListItem
            {
                public T Value { get; set; }
                public ListItem next { get; set; } 
            }
            private ListItem _head;
            public int Count { get; private set; }

            public void Push(T item)
            {
                var newItem = new ListItem();
                newItem.Value = item;
                newItem.next = _head;
                _head = newItem;
                Count++;
            }

            public T Pop()
            {
                if (Count > 0)
                {
                    var ret = _head.Value;
                    _head = _head.next;
                    Count--;
                    return ret;
                }
                else
                {
                    throw new System.Exception("Empty list");
                }

            }

            public void Clear()
            {
                _head = null;
                Count = 0;
            }

            public T Peek()
            {
                return _head.Value;
            }

            public T[] CopyToArray()
            {
                var ret = new T[Count];
                for (int i = 0; i < Count; i++)
                {
                    ret[i] = this.Pop();
                }
                return ret;
            }
        }
    }
}