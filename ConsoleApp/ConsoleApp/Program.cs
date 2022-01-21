using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

namespace ConsoleApp
{
    public class ChunkByEnumerable<T> : IEnumerable<IEnumerable<T>>
    {
        private readonly IEnumerable<T> _items;
        private readonly int _size;

        public ChunkByEnumerable(IEnumerable<T> items, int size)
        {
            _items = items;
            _size = size;
        }

        private class ChunkByEnumerator : IEnumerator<IEnumerable<T>>
        {
            private readonly IEnumerator<T> _enumerator;
            private readonly int _size;

            public ChunkByEnumerator(IEnumerator<T> enumerator, int size)
            {
                _enumerator = enumerator;
                _size = size;
            }

            public IEnumerable<T> Current { get; private set; }

            object IEnumerator.Current => Current;

            public void Dispose() => _enumerator.Dispose();

            public bool MoveNext()
            {
                var arr = new T[_size];
                var currentIndex = 0;

                while (currentIndex < _size && _enumerator.MoveNext())
                {
                    arr[currentIndex++] = _enumerator.Current;
                }

                if (currentIndex == 0)
                {
                    return false;
                }

                if (currentIndex < _size)
                {
                    Array.Resize(ref arr, currentIndex);
                }

                Current = arr;
                return true;
            }

            public void Reset() => _enumerator.Reset();
        }

        public IEnumerator<IEnumerable<T>> GetEnumerator() => new ChunkByEnumerator(_items.GetEnumerator(), _size);
        IEnumerator IEnumerable.GetEnumerator() => GetEnumerator();
    }

    public static class DateTimeExtensions
    {
        public static bool IsWeekend(this DateTime date) =>
            date.DayOfWeek == DayOfWeek.Sunday || date.DayOfWeek == DayOfWeek.Saturday;

        public static bool IsWorkday(this DateTime date) => !date.IsWeekend();

        public static IEnumerable<IEnumerable<T>> ChunkBy<T>(this IEnumerable<T> collection, int size)
            => new ChunkByEnumerable<T>(collection, size);
    }

    class Program
    {
        static void Main()
        {
            int[] arr = { 1, 2, 3, 4, 5 };
            var chunked = arr.ChunkBy(2).ToArray();
            chunked = arr.ChunkBy(3).ToArray();
            chunked = arr.ChunkBy(5).ToArray();
            chunked = arr.ChunkBy(7).ToArray();
        }
    }
}