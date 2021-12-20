﻿using System;
using System.Collections.Generic;
using System.Linq;

namespace ConsoleApp
{
    delegate bool Dima(int number);



    public class ChangesObservable<T>
    {
        public delegate void ChangeEventHandler(object sender, ChangeEvetArgs args);

        public record ChangeEvetArgs(T PreviousValue, T NewValue);

        public event ChangeEventHandler ChangeEvent;

        private T _value;

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

            var observable = new ChangesObservable<int>();
            observable.ChangeEvent += (sender, args) =>
            {
                Console.WriteLine($"Value changed from {args.PreviousValue} to {args.NewValue}");
            };

            observable.ChangeEvent += (sender, args) =>
            {
                Console.WriteLine($"ANOTHER HANDLER: Value changed from {args.PreviousValue} to {args.NewValue}");
            };

            observable.Value = 1;
            observable.Value = 2;
            observable.Value = 3;
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

        public static void ShowAll<T>(IEnumerable<T> collection)
        {
            foreach (var item in collection)
            {
                Console.WriteLine(item);
            }
        }
    }
}