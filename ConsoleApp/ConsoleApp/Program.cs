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
    static class DateTimeExtensions
    {
        public static IEnumerable<DateTime> DatesUntill(this DateTime from, DateTime to, TimeSpan step)
        {
            if (from < to && step < TimeSpan.Zero || from > to && step > TimeSpan.Zero)
            {
                throw new ArgumentException($"Incorrect input");
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

        public static int Age(this DateTime birthday)
        {
            var now = DateTime.Now;
            if (birthday > now)
            {
                throw new ArgumentOutOfRangeException(nameof(birthday), "You are an idiot");
            }

            return (DateTime.MinValue + (now - birthday)).Year - 1;
        }

        public static DateTime NextWorkingDay(this DateTime dateTime) => dateTime.DayOfWeek switch
        {
            DayOfWeek.Friday => dateTime.Date.AddDays(3),
            DayOfWeek.Saturday => dateTime.Date.AddDays(2),
            _ => dateTime.Date.AddDays(1)
        };

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

            var now = DateTime.Now;
            Console.WriteLine("FROM MIN TO MAX");
            ShowAll(now.DatesUntill(now.AddDays(7), TimeSpan.FromHours(5)));

            Console.WriteLine("FROM MAX TO MIN");
            ShowAll(now.AddDays(7).DatesUntill(now, TimeSpan.FromHours(5).Negate()));

            Console.WriteLine("EMPTY");
            ShowAll(now.DatesUntill(now, TimeSpan.FromHours(5)));
            ShowAll(now.DatesUntill(now, TimeSpan.FromHours(5).Negate()));

            Console.WriteLine($"\n");
            Console.WriteLine(new DateTime(2003, 01, 17).Age());
            //Console.WriteLine(new DateTime(2023, 01, 17).Age());

            Console.WriteLine(new DateTime(2021, 12, 22).NextWorkingDay());
            Console.WriteLine(new DateTime(2021, 12, 23).NextWorkingDay());
            Console.WriteLine(new DateTime(2021, 12, 24).NextWorkingDay());
            Console.WriteLine(new DateTime(2021, 12, 25).NextWorkingDay());

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