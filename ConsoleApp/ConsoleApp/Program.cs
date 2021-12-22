using System;
using System.Collections.Generic;
using System.Linq;

namespace ConsoleApp
{
    delegate bool Dima(int number);

    #region Changes
    public class ChangesObservable<T>
    {
        public delegate void ChangeEventHandler(object sender, ChangeEvetArgs args);

        public record ChangeEvetArgs(T PreviousValue, T NewValue);

        public event ChangeEventHandler ChangeEvent;

        private T _value;

        public string Name { get; init; }

        public T Value
        {
            get
            {
                return _value;
            }
            set
            {
                var oldValue = _value;
                _value = value;
                RaiseChangedEvent(oldValue, value);
            }
        }

        protected virtual void RaiseChangedEvent(T old, T @new) => ChangeEvent?.Invoke(this, new ChangeEvetArgs(old, @new));

    }
    #endregion

    #region Where Enumerable

    public class WhereEnumerable<T> : IEnumerable<T>
    {
        private readonly IEnumerable<T> _collection;
        private readonly Func<T, bool> _predicate;

        public WhereEnumerable(IEnumerable<T> collection, Func<T, bool> predicate)
        {
            _collection = collection;
            _predicate = predicate;
        }

        public IEnumerator<T> GetEnumerator() => new WhereEnumerator(_collection.GetEnumerator(), _predicate);

        System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator() => GetEnumerator();

        private class WhereEnumerator : IEnumerator<T>
        {
            private readonly IEnumerator<T> _enumerator;
            private readonly Func<T, bool> _predicate;

            public WhereEnumerator(IEnumerator<T> enumerator, Func<T, bool> predicate)
            {
                _enumerator = enumerator;
                _predicate = predicate;
            }

            public T Current { get; private set; }

            object System.Collections.IEnumerator.Current => Current;

            public void Dispose()
            {
                _enumerator.Dispose();
            }

            public bool MoveNext()
            {
                while (_enumerator.MoveNext())
                {
                    if (_predicate(_enumerator.Current))
                    {
                        Current = _enumerator.Current;
                        return true;
                    }
                }

                return false;
            }

            public void Reset()
            {
                _enumerator.Reset();
            }
        }
    }

    #endregion

    static class StringExtensions
    {
        public static int CountWords(this string str) => string.IsNullOrEmpty(str) ? 0 : str.Split(' ').Length;
    }

    static class DateTimeExtensions
    {
        public static IEnumerable<DateTime> DatesUntil(this DateTime from, DateTime to, TimeSpan step)
        {
            if (from < to && step < TimeSpan.Zero ||
                from > to && step > TimeSpan.Zero)
            {
                throw new ArgumentException("Incorrect input");
            }

            if (from == to)
            {
                yield break;
            }

            Func<DateTime, bool> predicate = from < to
                ? (dateTime) => dateTime <= to
                : (dateTime) => dateTime >= to;

            for (DateTime current = from; predicate(current); current = current.Add(step))
            {
                yield return current;
            }
        }
    }

    class Program
    {
        static void Main()
        {
            Console.WriteLine("This is a string".CountWords());
            Console.WriteLine("Word".CountWords());
            Console.WriteLine(((string)null).CountWords());
            Console.WriteLine("".CountWords());

            Console.WriteLine("TAKE FROM ARRAY");

            ShowAll(Take(new[] { 1, 2, 3 }, 2));
            ShowAll(Take(new[] { 1, 2, 3 }, null));

            var now = DateTime.Now;
            Console.WriteLine("FROM MIN TO MAX");
            ShowAll(now.DatesUntil(now.AddDays(7), TimeSpan.FromHours(5)));

            Console.WriteLine("FROM MAX TO MIN");
            ShowAll(now.AddDays(7).DatesUntil(now, TimeSpan.FromHours(5).Negate()));

            Console.WriteLine("EMPTY");
            ShowAll(now.DatesUntil(now, TimeSpan.FromHours(5)));
            ShowAll(now.DatesUntil(now, TimeSpan.FromHours(5).Negate()));
        }

        public static IEnumerable<T> Take<T>(IEnumerable<T> collection, int? count = null) => 
            count.HasValue ? Take(collection, count.Value) : collection;

        public static IEnumerable<T> Take<T>(IEnumerable<T> collection, int count)
        {
            using var enumerator = collection.GetEnumerator();
            var returned = 0;

            while (returned < count && enumerator.MoveNext())
            {
                yield return enumerator.Current;
                ++returned;
            }
        }

        public static IEnumerable<int> FilterValues(IEnumerable<int> collection, Dima predicate)
        {
            foreach (var item in collection)
            {
                if (predicate(item))
                {
                    yield return item;
                }
            }
        }

        public static T FirstOrDefault<T>(IEnumerable<T> collection, Func<T, bool> predicate)
        {
            foreach (var item in collection)
            {
                if (predicate(item))
                {
                    return item;
                }
            }

            return default;
        }

        public static bool Any<T>(IEnumerable<T> collection, Func<T, bool> predicate)
        {
            foreach (var item in collection)
            {
                if (predicate(item))
                {
                    return true;
                }
            }

            return false;
        }

        public static void ShowAll<T>(IEnumerable<T> collection)
        {
            foreach (var item in collection)
            {
                Console.WriteLine(item);
            }
        }
    }
}