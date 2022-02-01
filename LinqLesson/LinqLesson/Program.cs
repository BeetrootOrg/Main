using Newtonsoft.Json;
using System.Collections.Generic;
using System;
using System.IO;
using System.Linq;
using System.Text;

namespace LinqLesson;

public static class PersonsExtension
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

    public static Person YoungestPerson1(this IEnumerable<Person> persons)
    {
        var personWeNeed = persons.OrderBy(x => x.Age).First();
        Console.WriteLine($"Youngest: {personWeNeed}");
        return personWeNeed;

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

    public static string MostUsedTag(this IEnumerable<Person> persons)
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

        return mostUsedTag.Tag.ToString();
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

    #region Homework
    public static void TheMostFarthestPerson(this IEnumerable<Person> persons)
    {
        var northernPerson = persons.OrderByDescending(x => x.Latitude).First();
        var southernPerson = persons.OrderBy(x => x.Latitude).First();
        var easternPerson = persons.OrderByDescending(x => x.Longitude).First();
        var westernPerson = persons.OrderBy(x => x.Longitude).First();

        Console.WriteLine($"The most northest person is: {northernPerson.Name}, Latitude is  {northernPerson.Latitude}");
        Console.WriteLine($"The most southest person is: {southernPerson.Name}, Latitude is  {southernPerson.Latitude}");
        Console.WriteLine($"The most eastest person is: {easternPerson.Name}, Longitude is {easternPerson.Longitude}");
        Console.WriteLine($"The most westest person is: {westernPerson.Name}, Longitude is {westernPerson.Longitude}\n");
    }


    public static void FindMaxEqualsInAbout(this IEnumerable<Person> persons)
    {
        var intersect = persons.Join(persons,
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
                var intersect = twoPersons.First.About.Split(' ')
                .Intersect(twoPersons.Second.About.Split(' '))
                .ToArray().Length;


                return new
                {
                    First = twoPersons.First,
                    Second = twoPersons.Second,
                    Intersect = intersect
                };
            });

        var max = intersect.MaxBy(x => x.Intersect);

        Console.WriteLine($"Max equals in about is between {max.First.Name} and {max.Second.Name} is {max.Intersect} words\n");

    }

    public static void FindPersonsWithMutualFriends(this IEnumerable<Person> persons)
    {
        var mutual = persons.Join(persons,
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
                var i = 0;
                foreach (Friend friend1 in twoPersons.First.Friends)
                {
                    foreach (Friend friend2 in twoPersons.Second.Friends)
                    {
                        if (friend1.Name == friend2.Name) ++i;
                    }
                }
                var mutual=i;
 

                return new
                {
                    First = twoPersons.First,
                    Second = twoPersons.Second,
                    Mutual = mutual
                };
            });

        var hasMutualFriends = mutual.MaxBy(x => x.Mutual);



        if (hasMutualFriends.Mutual != 0)
        {
            Console.WriteLine($"{hasMutualFriends.First.Name} and {hasMutualFriends.Second.Name} has {hasMutualFriends.Mutual} mutual friends");
        }
        else
        {
            Console.WriteLine("seems like no one has mutual friends\n");
        }

    }

    public static void FindTheBiggerCompany(this IEnumerable<Person> persons)
    {
        var biggerCompany = persons.GroupBy(person => person.Company)
            .Select(company => new
           {
               Company = company.Key,
               Count = company.Count()
           })
            .OrderByDescending(x => x.Count)
            .First();
        Console.WriteLine($"{biggerCompany.Company} {biggerCompany.Count}");

    }

    #endregion
}

public class Program
{
    static void Main(string[] args)
    {
        var persons = JsonConvert.DeserializeObject<IEnumerable<Person>>(File.ReadAllText("data.json"));

        
        persons.TheMostFarthestPerson();
        persons.FindMaxEqualsInAbout();
        persons.FindPersonsWithMutualFriends();
        persons.FindTheBiggerCompany();









    }
}
