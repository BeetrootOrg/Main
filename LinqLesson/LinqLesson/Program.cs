using Newtonsoft.Json;
using System.Collections.Generic;
using System;
using System.IO;
using System.Linq;
using System.Text;

namespace LinqLesson;

static class PersonsExtension
{
   
    public static void DistanceBetwenPersons(this IEnumerable<Person> persons)
    {
        var northest = persons.MaxBy(persons=>persons.Longitude);
        var southest = persons.MinBy (persons=>persons.Longitude);
        var western = persons.MinBy(persons => persons.Latitude);
        var eastern = persons.MaxBy(persons => persons.Latitude);

        Console.WriteLine("\nPerson who lives northest:");
        Console.WriteLine(northest);
        Console.WriteLine("\nPerson who lives southest:");
        Console.WriteLine(southest);
        Console.WriteLine("\nPerson who lives western:");
        Console.WriteLine(western);
        Console.WriteLine("\nPerson who lives eastern:");
        Console.WriteLine(eastern);
    }

    

    public static void BigestWordAbout(this IEnumerable<Person> persons)
    {
        var result = persons.Join(persons,
            person => true,
            person => true,
            (person1, person2) => new
            {
                First = person1,
                Second = person2
            })

            .Where(pair => pair.First != pair.Second)
            .Select(pair =>
            {
                var firstAbout = pair.First.About;
                var secondAbout = pair.Second.About;

                var compare = firstAbout.Split(' ').Intersect(secondAbout.Split(' '));

                return new
                {
                    First = pair.First,
                    Second = pair.Second,
                    BigestWord = compare.Count()
                };
            })

        .MaxBy(pair => pair.BigestWord);
        Console.WriteLine($"\nThe bigest count of word is on {result.BigestWord}");
            
    }

    public static void SameFriend(this IEnumerable<Person> persons)
    {
        var result = persons.Join(persons,
            person => true,
            person => true,
            (person1, person2) => new
            {
                First = person1,
                Second = person2
            })

            .Where(pair => pair.First != pair.Second)
            .Select(pair =>
            {
                var firstFrisend = pair.First.Friends;
                var secondFriend = pair.Second.Friends;

                var compare = firstFrisend.Intersect(secondFriend);

                return new
                {
                    First = pair.First,
                    Second = pair.Second,

                    SameFriend = compare
                };
            });

            Console.WriteLine($"The same friend is {result.Count()}");
    }

    public static void BigestCompany(this IEnumerable<Person> persons)
    {
        var result = persons.GroupBy(persons => persons.Company)
            .Select(group => new
            {
                CompanyName = group.Key,
                CounOfPersonal = group.Count()

            })
            
            .MaxBy(c => c.CounOfPersonal);

        Console.WriteLine($"The bigest company is {result.CompanyName} with {result.CounOfPersonal} members");
    }
}

class Program
{
    static void Main(string[] args)
    {       

        var persons = JsonConvert.DeserializeObject<IEnumerable<Person>>(File.ReadAllText("data.json"));

        persons.DistanceBetwenPersons();
        persons.BigestWordAbout();
        persons.SameFriend();
        persons.BigestCompany();

    }
}
