using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Linq;

namespace ConsoleApp
{
    #region Classes

    record Person(string FirstName, string LastName)
    {
    }

    class TestClass
    {
        public int Number { get; set; }

        public override string ToString() => Number.ToString();
    }

    class TestClassEqualityComparer : IEqualityComparer<TestClass>
    {
        public bool Equals(TestClass x, TestClass y)
        {
            if (ReferenceEquals(x, y))
            {
                return true;
            }

            if (x == null || y == null)
            {
                return false;
            }

            return x.Number == y.Number;
        }

        public int GetHashCode([DisallowNull] TestClass obj) => obj.Number.GetHashCode();
    }

    #endregion

    #region Power Enumerable

    public class PowerEnumerable : IEnumerable<int>
    {
        private class PowerEnumerator : IEnumerator<int>
        {
            private readonly int _number;
            private readonly int _exponent;

            private int _currentExponent = 0;

            public PowerEnumerator(int number, int exponent)
            {
                _number = number;
                _exponent = exponent;
            }

            public int Current { get; private set; } = 1;

            object IEnumerator.Current => Current;

            public void Dispose()
            {
            }

            public bool MoveNext()
            {
                if (_currentExponent < _exponent)
                {
                    Current *= _number;
                    ++_currentExponent;

                    return true;
                }

                return false;
            }

            public void Reset()
            {
                Current = 1;
                _currentExponent = 0;
            }
        }

        private readonly int _number;
        private readonly int _exponent;

        public PowerEnumerable(int number, int exponent)
        {
            _number = number;
            _exponent = exponent;
        }

        public IEnumerator<int> GetEnumerator() => new PowerEnumerator(_number, _exponent);
        IEnumerator IEnumerable.GetEnumerator() => GetEnumerator();
    }

    #endregion

    #region Even Only Enumerable

    public class EvenOnlyEnumerable : IEnumerable<int>
    {
        private class EvenOnlyEnumerator : IEnumerator<int>
        {
            public int Current { get; private set; }

            object IEnumerator.Current => Current;

            private readonly IEnumerator<int> _enumerator;

            public EvenOnlyEnumerator(IEnumerator<int> enumerator)
            {
                _enumerator = enumerator;
            }

            public void Dispose() => _enumerator.Dispose();

            public bool MoveNext()
            {
                while (_enumerator.MoveNext())
                {
                    var current = _enumerator.Current;
                    if (current % 2 == 0)
                    {
                        Current = current;
                        return true;
                    }
                }

                return false;
            }

            public void Reset() => _enumerator.Reset();
        }

        private readonly IEnumerable<int> _collection;

        public EvenOnlyEnumerable(IEnumerable<int> collection)
        {
            _collection = collection;
        }

        public IEnumerator<int> GetEnumerator() => new EvenOnlyEnumerator(_collection.GetEnumerator());

        IEnumerator IEnumerable.GetEnumerator() => GetEnumerator();
    }

    #endregion

    #region Power Collection Enumerable

    public class PowerCollectionEnumerable : IEnumerable<int>
    {
        private class PowerCollectionEnumerator : IEnumerator<int>
        {
            private readonly IEnumerator<int> _enumerator;
            private readonly int _exponent;

            private IEnumerator<int> _powerEnumerator;

            public PowerCollectionEnumerator(IEnumerator<int> enumerator, int exponent)
            {
                _enumerator = enumerator;
                _exponent = exponent;
            }

            public int Current { get; private set; }

            object IEnumerator.Current => Current;

            public void Dispose()
            {
            }

            public bool MoveNext()
            {
                while (true)
                {
                    if (_powerEnumerator == null)
                    {
                        if (!_enumerator.MoveNext())
                        {
                            return false;
                        }

                        var powerEnumerable = new PowerEnumerable(_enumerator.Current, _exponent);
                        _powerEnumerator = powerEnumerable.GetEnumerator();
                    }

                    
                    while (_powerEnumerator.MoveNext())
                    {
                        Current = _powerEnumerator.Current;
                        return true;
                    }

                    _powerEnumerator = null;
                }

            }

            public void Reset()
            {
                _enumerator.Reset();
                _powerEnumerator = null;
            }
        }

        private readonly IEnumerable<int> _collection;
        private readonly int _exponent;

        public PowerCollectionEnumerable(IEnumerable<int> collection, int exponent)
        {
            _collection = collection;
            _exponent = exponent;
        }

        public IEnumerator<int> GetEnumerator() => new PowerCollectionEnumerator(_collection.GetEnumerator(), _exponent);
        IEnumerator IEnumerable.GetEnumerator() => GetEnumerator();
    }

    #endregion

    class Program
    {
        static void Main()
        {
            var list = new List<Person>
            {
                new Person("F", "L"),
                new Person("First", "Last")
            };

            // almost analogue to above
            //new Person[]
            //{
            //    new Person("F", "L"),
            //    new Person("First", "Last")
            //};

            list.Add(new Person("F", "L"));
            list.Add(new Person("D", "M"));
            list.Add(new Person("Dima", "Misik"));
            list.Add(new Person("G", "T"));
            list.Add(new Person("S", "P"));

            ShowAll(list);

            Console.WriteLine(list.Count);
            Console.WriteLine(list[1]);

            var deleted = list.Remove(new Person("F", "L"));
            Console.WriteLine(deleted);

            list.RemoveAt(0);
            list.RemoveRange(1, 2);

            list.AddRange(list);
            list.Insert(2, new Person("Y", "L"));
            list.InsertRange(3, list);

            // need to implement IComparable on Person to work
            // list.Sort();
            list.Reverse();

            var contains = list.Contains(new Person("F", "L"));
            Console.WriteLine(contains);

            var set = new HashSet<Person>(list);
            ShowAll(set);

            var added = set.Add(new Person("F", "L"));
            Console.WriteLine(added);

            var set1 = new HashSet<int>(new[] { 1, 2, 3 });
            var set2 = new HashSet<int>(new[] { 3, 4 });

            set1.SymmetricExceptWith(set2);
            ShowAll(set1);

            // list.Clear();

            var dictionary = new Dictionary<int, string>
            {
                [1] = "one"
            };

            // the same as above
            dictionary = new Dictionary<int, string>
            {
                { 1, "one" }
            };

            dictionary.Add(2, "two");
            dictionary.TryAdd(2, "three");

            dictionary.Add(10000, "ten thousand");

            ShowAll(dictionary);

            const string phoneNumber1 = "+123455";
            const string phoneNumber2 = "+123456";
            var dict2 = new Dictionary<string, Person>
            {
                [phoneNumber1] = set.ElementAt(1),
                [phoneNumber2] = set.ElementAt(1),
            };

            ShowAll(dict2);

            var dict3 = new Dictionary<TestClass, Person>(new TestClassEqualityComparer())
            {
                [new TestClass { Number = 1 }] = set.ElementAt(1),
                [new TestClass { Number = 1 }] = set.ElementAt(2),
            };

            ShowAll(dict3);

            if (dict2.TryGetValue(phoneNumber1, out var person1) &&
                dict2.TryGetValue(phoneNumber2, out var person2))
            {
                Console.WriteLine($"Equals: {person1.Equals(person2)}");
            }

            var result = dict2[phoneNumber1];
            dict2.Remove(phoneNumber1);

            Console.WriteLine("Keys");
            ShowAll(dict2.Keys);

            Console.WriteLine("Values");
            ShowAll(dict2.Values);

            ShowAll(Power(2, 4));
            ShowAll(new PowerEnumerable(2, 4));

            ShowAll(new EvenOnlyEnumerable(new[] { 1, 2, 3, 4, 5 }));
            ShowAll(new EvenOnlyEnumerable(Array.Empty<int>()));
            ShowAll(new EvenOnlyEnumerable(new[] { 1, 3 }));

            ShowAll(new PowerCollectionEnumerable(new EvenOnlyEnumerable(new[] { 1, 2, 3 }), 3));
        }

        static void ShowAll<T>(IEnumerable<T> collection)
        {
            foreach (var item in collection)
            {
                Console.WriteLine(item);
            }
        }

        static IEnumerable<int> Power(int number, int exponent)
        {
            int result = 1;

            for (int i = 0; i < exponent; i++)
            {
                result = result * number;
                yield return result;
            }
        }
    }
}