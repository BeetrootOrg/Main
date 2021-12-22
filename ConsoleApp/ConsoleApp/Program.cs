using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Linq;

namespace ConsoleApp
{
    //i.safontev/classwork/18-extensions
    delegate bool UnicalName(int number);
    #region Changes
    class ChangesObservable<T>
    {
        public delegate void ChangeEventHandler(object sender, ChangeEventArgs args);
        public record ChangeEventArgs(T PreviousValue, T NewValue);

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
        protected virtual void RaiseChangedEvent(T old, T @new) => ChangeEvent?.Invoke(this, new ChangeEventArgs(old, @new));

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
        // ?? 0 is like:
        // var result = str?.Split(' ').Length;
        // return result == null ? 0 : result;
        //public static int? CountWords(this string str) => str?.Split(' ').Length ?? 0;

        public static int? CountWords(this string str) => string.IsNullOrEmpty(str) ? 0 : str.Split(' ').Length;
    }
    class Program
    {
        static void Main()
        {
            Console.WriteLine($"This is a string".CountWords());
            Console.WriteLine($"Word".CountWords());
            Console.WriteLine(((string)null).CountWords());
            Console.WriteLine($"".CountWords());

            ShowAll(Take(new[] { 1, 2, 3 }, 2));
            ShowAll(Take(new[] { 1, 2, 3 }, null));
        }

        public static IEnumerable<T> Take<T>(IEnumerable<T> collection, Nullable<int> count = null) =>//Nullable<int> count == int? count
            count.HasValue ? Take(collection, count.Value) : collection;

        public static IEnumerable<T> Take<T>(IEnumerable<T> collection, int count )
        {
            using var enumerator = collection.GetEnumerator();//using- auto Dispose()
            var returned = 0;

            while (returned < count && enumerator.MoveNext())
            {
                yield return enumerator.Current;
                ++returned;
            }
        }

        public static IEnumerable<int> FilterValues(IEnumerable<int> collection, UnicalName predicate)
        {
            foreach(var item in collection)
            {
                if (predicate(item))
                {
                    yield return item;
                }
            }

        }
        public static void ShowAll<T>(IEnumerable<T> collection)
        {
            foreach (var item in collection)
            {
                Console.WriteLine(item);
            }
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
        public static T FirstOrDefault<T>(IEnumerable<T> collection, Func<T,bool> predicate)
        {
            foreach(var item in collection)
            {
                if (predicate(item))
                {
                    return item;
                }
            }
            return default; //if T is int we cant return null
        }
    }
}