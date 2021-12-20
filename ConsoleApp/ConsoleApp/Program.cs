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

    class Program
    {
        static void Main()
        {
            var array = Enumerable.Range(0, 10);
            ShowAll(FilterValues(array, (int item) => item > 5));
            ShowAll(FilterValues(array, OddOnly));

            // 1st option - decalre delegate
            Dima evenOnly = (int item) => item % 2 == 0;
            ShowAll(FilterValues(array, evenOnly));

            // 2nd option - declare anonymous method
            static bool OddOnly(int item) => item % 2 == 1;

            var number = 0;
            Func<int, int> calculate = (i) =>
            {
                number += i;
                return number;
            };

            Func<int, int> calculate2 = (i) =>
            {
                var number = 0;
                number += i;
                return number;
            };

            calculate(5);
            calculate(2);

            Console.WriteLine("CLOSURE NUMBER");
            Console.WriteLine(number);

            var num1 = calculate2(5);
            var num2 = calculate2(2);

            Console.WriteLine("NON CLOSURE NUMBER");
            Console.WriteLine(number);
            Console.WriteLine(num1);
            Console.WriteLine(num2);

            var observable1 = new ChangesObservable<int> { Name = "First" };
            var observable2 = new ChangesObservable<int> { Name = "Second" };

            ChangesObservable<int>.ChangeEventHandler handler = (sender, args) =>
            {
                var changesObservable = sender as ChangesObservable<int>;
                Console.WriteLine($"Value changed inside {changesObservable.Name} from {args.PreviousValue} to {args.NewValue}");
            };
            
            observable1.ChangeEvent += handler;
            observable2.ChangeEvent += handler;

            observable1.Value = 1;
            observable2.Value = 2;

            ShowAll(new WhereEnumerable<int>(new[] { 1, 2, 3, 4, 0, 8, 11, 1998 }, (item) => item % 2 == 1));
            ShowAll(new WhereEnumerable<int>(new[] { 1, 2, 3, 4, 0, 8, 11, 1998 }, (item) => item > 5));
            ShowAll(new WhereEnumerable<int>(new[] { 1, 2, 3, 4, 0, 8, 11, 1998 }, (item) => item % 2 == 0));
            ShowAll(new WhereEnumerable<int>(new[] { 1, 2, 3, 4, 0, 8, 11, 1998 }, (item) => item % 3 == 0));

            Console.WriteLine(FirstOrDefault(new[] { 1, 2 }, (item) => item > 1));
            Console.WriteLine(FirstOrDefault(new[] { 1, 2 }, (item) => item > 2));

            Console.WriteLine(FirstOrDefault(new[] { "str1", "str2" }, (item) => item.Contains("str")));
            Console.WriteLine(FirstOrDefault(new[] { "str1", "str2" }, (item) => item.Contains("3")));

            Console.WriteLine(Any(new[] { "str1", "str2" }, (item) => item.Contains("str")));
            Console.WriteLine(Any(new[] { "str1", "str2" }, (item) => item.Contains("3")));
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