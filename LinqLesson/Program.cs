using Newtonsoft.Json;
using System.Collections.Generic;
using System;
using System.IO;
using System.Linq;

namespace LinqLesson;

class Program
{
    static void Main()
    {
        var persons = JsonConvert.DeserializeObject<IEnumerable<Person>>(File.ReadAllText("data.json"));


        MaxCompany(persons);
        MutualFriends(persons);
        WordsMatches(persons);

        FarthestPerson(persons);
    }

  
    static void FarthestPerson(IEnumerable<Person> persons)
        {




        Console.WriteLine("Northernmost Person: {0}",persons.MaxBy(y => y.Latitude).Name);
        Console.WriteLine("");
        Console.WriteLine("Southernmost Person: {0}",persons.MinBy(y => y.Latitude).Name);
        Console.WriteLine("");

        Console.WriteLine("Westernmost Person: {0}",persons.MinBy(y => y.Longitude).Name);
        Console.WriteLine("");
        Console.WriteLine("Easternmost Person: {0}",persons.MaxBy(y => y.Longitude).Name);
           
        }

    

    static void MaxCompany(IEnumerable<Person> persons)
    {
        var result = persons.GroupBy(person => person.Company)
            .Select
            (group => new
            {
                Company = group.Key,
                Count = group.Count()
            })
            .OrderByDescending(x => x.Count)
            .First()
            .Company;


        Console.WriteLine($" {result} is the most populated company");

    }

    
    static void MutualFriends(IEnumerable<Person> persons)
    {
        var friends = persons.Join(persons,
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
                foreach (var friend in twoPersons.First.Friends)
                {
                    if (twoPersons.Second.Friends.Any(x => x.Name == friend.Name))
                    {
                       break;
                    }
                }

                return new
                {
                    First = twoPersons.First,
                    Second = twoPersons.Second
                };
            })
            .ToList();
        var mutual = friends.FirstOrDefault();
        if (mutual != null)
        {
            Console.WriteLine($"{mutual.First.Name} and {mutual.Second.Name} have at least one mutual friend");
        }
        else 
        {
            Console.WriteLine("No one has mutual friends");
        }

        

            


    }



    static void WordsMatches(IEnumerable<Person> persons)
    {
        var Pairs = persons.Join(persons,
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
                int counter = 0;
                var firstWords = twoPersons.First.About.Split(' ').Distinct().ToList();
                var secondWords = twoPersons.Second.About.Split(' ').Distinct().ToList();
                foreach (var word in firstWords)
                {
                    if (secondWords.Contains(word))
                    {
                        counter++;
                    }
                }

                return new
                {
                    First = twoPersons.First,
                    Second = twoPersons.Second,
                    Matches = counter
                };
            })
            .ToList();
        Console.WriteLine($"{ Pairs.Count} mutual pairs were analised");
        var similarPersons = Pairs.MaxBy(a => a.Matches);
        Console.WriteLine($"{similarPersons.First.Name} and {similarPersons.Second.Name} are similar with {similarPersons.Matches} matches");
  
    }
}