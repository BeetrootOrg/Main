using Newtonsoft.Json;
using System.Collections.Generic;
using System;
using System.IO;
using System.Linq;
using System.Text;
using System.Reflection;


namespace ConsoleApp
{
    static class PersonsExtension
    {
        public static void CountByGender1(this IEnumerable<Person> persons)
        {
            Console.WriteLine($"Males: {persons.Count(person => person.Gender == Gender.Male)}");
            Console.WriteLine($"Females: {persons.Count(person => person.Gender == Gender.Female)}");
        }

        public static void CountByGender2(this IEnumerable<Person> persons)
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

        public static void YoungestPerson1(this IEnumerable<Person> persons)
        {
            Console.WriteLine($"Youngest: {persons.OrderBy(x => x.Age).First()}");
        }

        public static void YoungestPerson2(this IEnumerable<Person> persons)
        {
            Console.WriteLine($"Youngest: {persons.MinBy(x => x.Age)}");
        }

        public static void OldestPerson(this IEnumerable<Person> persons)
        {
            Console.WriteLine($"Oldest: {persons.MaxBy(x => x.Age)}");
        }

        public static void AverageAgeByMale(this IEnumerable<Person> persons)
        {
            var age = persons.GroupBy(x => x.Gender)
                .Where(group => group.Key == Gender.Male)
                .SelectMany(group => group)
                .Average(person => person.Age);

            Console.WriteLine($"Average Male Age: {age}");
        }

        public static void AverageAgeByGender(this IEnumerable<Person> persons)
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

        public static void NearestToAverageAge(this IEnumerable<Person> persons)
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

        public static void AllNearestToAverageAge(this IEnumerable<Person> persons)
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

        public static void MostUsedTag(this IEnumerable<Person> persons)
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

        public static void MinMaxDistanceBetweenPersons(this IEnumerable<Person> persons)
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

        public static void GroupByEyeColor(this IEnumerable<Person> persons)
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

        public static void CollectAllEmail(this IEnumerable<Person> persons)
        {
            var emails = persons.Select(person => person.Email)
                .Aggregate(new StringBuilder(),
                    (sb, email) => sb.Append(email).Append(";"),
                    sb => sb.ToString());

            Console.WriteLine($"All emails: {emails}");
        }

        public static void MaxFriends(this IEnumerable<Person> persons, int top)
        {
            var topFriends = persons.OrderByDescending(person => person.Friends.Length)
                .Take(top);

            var i = 0;
            foreach (var topFriend in topFriends)
            {
                Console.WriteLine($"Top friend {++i}: {topFriend.Name} with {topFriend.Friends.Length} friends");
            }
        }

        public static void EverybodyHasEmail(this IEnumerable<Person> persons)
        {
            var allHasEmails = persons.All(person => !string.IsNullOrEmpty(person.Email));
            Console.WriteLine($"Everybody has email: {allHasEmails}");
        }
        public static void ShowCompanyNameWithMaxPeople(this IEnumerable<Person> persons)
        {
            int cnt = 0;

            var result = persons.GroupBy(person => person.Company)
                .Select(group => new
                {
                    Company = group.Key,
                    Count = group.Count()
                });

            foreach (var item in result)
            {
                Console.WriteLine($"{cnt++}: {item.Count} working in \"{item.Company}\" company");
            }

            Console.WriteLine($"Most working in: {result.MaxBy(item => item.Count)}");
        }
        public static void GroupBySameWordsInAbout(this IEnumerable<Person> persons)
        {
            // to do...
        }
    }
    class ConsoleApp
    {
        // finish all tasks from lesson using LinqExample.zip and do next:
        //
        // find out who is located farthest north/south/west/east using latitude/longitude data
        // find max and min distance between 2 persons
        // find 2 persons whos ‘about’ have the most same words
        // find persons with same friends(compare by friend’s name)

        // створити наступні методи:
        // метод, що виводить людей що знаходяться найпівнічніше/південіше/західніше/східніше
        // метод, що виводить двох людей, у яких в About найбільше однакових слів
        // метод, що виводить двох людей, у котрих є спільний друг
        // метод, що виводить назву компанії в якій працює найбільша кількість людей та кількість людей, що там працює
        // ShowCompanyNameWithMaxPeople

        static void Main(string[] args)
        {

            Console.WriteLine("\r\n a.tkachenko/homework/19-Linq \r\n");

            var persons = JsonConvert.DeserializeObject<IEnumerable<Person>>(File.ReadAllText("data.json"));

            persons.CountByGender1();
            persons.CountByGender2();

            persons.YoungestPerson1();
            persons.YoungestPerson2();

            persons.OldestPerson();

            persons.AverageAgeByGender();
            persons.NearestToAverageAge();
            persons.AllNearestToAverageAge();

            persons.MostUsedTag();

            persons.MinMaxDistanceBetweenPersons();

            persons.GroupByEyeColor();
            persons.CollectAllEmail();

            persons.MaxFriends(5);

            persons.EverybodyHasEmail();

            const int age = 42;

            var fourtyTwoYearsOld = persons.First(x => x.Age == age);
            fourtyTwoYearsOld = persons.FirstOrDefault(x => x.Age == age);
            fourtyTwoYearsOld = persons.Single(x => x.Age == age);
            fourtyTwoYearsOld = persons.SingleOrDefault(x => x.Age == age);
            fourtyTwoYearsOld = persons.Last(x => x.Age == age);
            fourtyTwoYearsOld = persons.LastOrDefault(x => x.Age == age);

            var range = Enumerable.Range(5, 10);
            var repeat = Enumerable.Repeat(fourtyTwoYearsOld, 5);

            // made just this
            persons.ShowCompanyNameWithMaxPeople();
        }
    }
}
