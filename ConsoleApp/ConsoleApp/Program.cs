using Newtonsoft.Json;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Linq;
using System.IO;
using System.Text;

namespace ConsoleApp
{
    //i.safontev/classwork/19-linq

    class Program
    {
        static void Main()
        {
            var persons = JsonConvert.DeserializeObject<IEnumerable<Person>>(File.ReadAllText("data.json"));

            CountByGender1(persons);
            CountByGender2(persons);

            YoungestPerson1(persons);
            YoungestPerson2(persons);

            OldestPerson(persons);

            AverageAgeByGender(persons);
            NearestToAverageAge(persons);
            AllNearestToAverageAge(persons);

            MostUsedTag(persons);

            MinMaxDistanceBetweenPersons(persons);

            GroupByEyeColor(persons);
            CollectAllEmail(persons);

        }
        static void CountByGender1(IEnumerable<Person> persons)
        {
            Console.WriteLine($"Males: {persons.Count(person => person.Gender == Gender.Male)}");
            Console.WriteLine($"Females: {persons.Count(person => person.Gender == Gender.Female)}");
        }

        static void CountByGender2(IEnumerable<Person> persons)
        {
            var result = persons.GroupBy(person => person.Gender)
                .Select(group => new
                {
                    Gender = group.Key,
                    Count = group.Count()
                });

            foreach (var item in result)
            {
                Console.WriteLine($"{item.Gender}s: {item.Count}");
            }
        }

        static void YoungestPerson1(IEnumerable<Person> persons)
        {
            Console.WriteLine($"Youngest: {persons.OrderBy(x => x.Age).First()}");
        }

        static void YoungestPerson2(IEnumerable<Person> persons)
        {
            Console.WriteLine($"Youngest: {persons.MinBy(x => x.Age)}");
        }

        static void OldestPerson(IEnumerable<Person> persons)
        {
            Console.WriteLine($"Oldest: {persons.MaxBy(x => x.Age)}");
        }

        static void AverageAgeByMale(IEnumerable<Person> persons)
        {
            var age = persons.GroupBy(x => x.Gender)
                .Where(group => group.Key == Gender.Male)
                .SelectMany(group => group)
                .Average(person => person.Age);

            Console.WriteLine($"Average Male Age: {age}");
        }

        static void AverageAgeByGender(IEnumerable<Person> persons)
        {
            var average = persons.GroupBy(x => x.Gender)
                .Select(group => new
                {
                    Gender = group.Key,
                    AverageAge = group.Average(person => person.Age)
                });

            foreach (var item in average)
            {
                Console.WriteLine($"{item.Gender}s average age: {item.AverageAge}");
            }
        }

        static void NearestToAverageAge(IEnumerable<Person> persons)
        {
            var average = persons.GroupBy(x => x.Gender)
                .Select(group =>
                {
                    var averageAge = group.Average(person => person.Age);
                    var nearestToAverage = group.MinBy(person => Math.Abs(person.Age - averageAge));

                    return new
                    {
                        Gender = group.Key,
                        NearestToAverage = nearestToAverage
                    };
                });

            foreach (var item in average)
            {
                Console.WriteLine($"{item.Gender}s nearest to average age: {item.NearestToAverage}");
            }
        }

        static void AllNearestToAverageAge(IEnumerable<Person> persons)
        {
            var average = persons.GroupBy(x => x.Gender)
                .Select(group =>
                {
                    var averageAge = group.Average(person => person.Age);
                    var nearestAgeToAverage = group.MinBy(person => Math.Abs(person.Age - averageAge)).Age;

                    return new
                    {
                        Gender = group.Key,
                        NearestToAverage = group.Where(person => person.Age == nearestAgeToAverage)
                    };
                });

            foreach (var item in average)
            {
                Console.WriteLine($"{item.Gender}s nearest to average age (count): {item.NearestToAverage.Count()}");
            }
        }

        static void MostUsedTag(IEnumerable<Person> persons)
        {
            var mostUsedTag = persons.SelectMany(person => person.Tags)
                .GroupBy(tag => tag) // key: pariatur, value: [pariatur, pariatur, ..., pariatur] - 25 times
                .Select(group => new
                {
                    Tag = group.Key,
                    Count = group.Count()
                })
                .MaxBy(x => x.Count);

            Console.WriteLine($"Most used tag: {mostUsedTag.Tag} ({mostUsedTag.Count})");
        }

        static void MinMaxDistanceBetweenPersons(IEnumerable<Person> persons)
        {
            var distances = persons.Join(persons,
                person => true,
                person => true,
                (person1, person2) => new
                {
                    First = person1,
                    Second = person2
                })
                .Where(twoPersons => twoPersons.First != twoPersons.Second)
                .Select(twoPersons =>
                {
                    var distance = Math.Sqrt(Math.Pow(twoPersons.First.Latitude - twoPersons.Second.Latitude, 2)
                        + Math.Pow(twoPersons.First.Longitude - twoPersons.Second.Longitude, 2));

                    return new
                    {
                        First = twoPersons.First,
                        Second = twoPersons.Second,
                        Distance = distance
                    };
                })
                .ToArray();

            var min = distances.MinBy(x => x.Distance);
            var max = distances.MaxBy(x => x.Distance);

            Console.WriteLine($"Min distance is between {min.First} and {min.Second} is {min.Distance}");
            Console.WriteLine($"Max distance is between {max.First} and {max.Second} is {max.Distance}");

        }

        static void GroupByEyeColor(IEnumerable<Person> persons)
        {
            var result = persons.GroupBy(person => person.EyeColor)
                .Select(group => new
                {
                    EyeColor = group.Key,
                    Count = group.Count()
                });

            foreach (var item in result)
            {
                Console.WriteLine($"{item.Count} has {item.EyeColor} eye color");
            }
        }

        static void CollectAllEmail(IEnumerable<Person> persons)
        {
            var emails = persons.Select(person => person.Email)
                .Aggregate(new StringBuilder(),
                    (sb, email) => sb.Append(email).Append(";"),
                    sb => sb.ToString());

            Console.WriteLine($"All emails: {emails}");
        }

    }
}