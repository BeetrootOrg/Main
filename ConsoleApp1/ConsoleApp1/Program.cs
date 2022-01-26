using Newtonsoft.Json;
using System.Collections.Generic;
using System;
using System.IO;
using System.Linq;

namespace LinqLesson;

public class ProgramX
{
    public static void Main()
    {
        var persons = JsonConvert.DeserializeObject<IEnumerable<Person>>(File.ReadAllText("data.json"));

        MutualFriends(persons);
        WordsMatches(persons);

        FarthestPerson(persons);
        //List<Person> people = new List<Person>{
        //           new Person{Id="1",Index=1,Guid=new Guid("a016f28c-dd5e-414c-85d2-706aee8862d6"),IsActive=true,Balance="7",Age=32,EyeColor="brown",Name="Vasia Pupkin",Gender=Gender.Male,Company="Horns and Hoofs",Email="",Phone="",Address="",About="",Registered=new DateTime(2010,7,20),Latitude=67,Longitude=25,Tags=null,Friends=null},
        //           new Person{Id="1",Index=1,Guid=new Guid("b105e6fe-4dd9-4966-8bce-300ef6096fdf"),IsActive=true,Balance="7",Age=32,EyeColor="brown",Name="Lionia Holubkov",Gender=Gender.Male,Company="Horns and Hoofs",Email="",Phone="",Address="",About="",Registered=new DateTime(2010,7,20),Latitude=67,Longitude=25,Tags=null,Friends=null},
        //           new Person{Id="1",Index=1,Guid=new Guid("eec58a87-db71-44cc-8862-be65eac4442a"),IsActive=true,Balance="1000000",Age=25,EyeColor="brown",Name="Dima Misik",Gender=Gender.Male,Company="FBI",Email="",Phone="",Address="",About="",Registered=new DateTime(2010,7,20),Latitude=67,Longitude=25,Tags=null,Friends=null},
                                              //};


        string xxx=MaxCompany(persons);

    }

    private static object Guid(string v)
    {
        throw new NotImplementedException();
    }

    static void FarthestPerson(IEnumerable<Person> persons)
    {




        Console.WriteLine("Northernmost Person: {0}", persons.MaxBy(y => y.Latitude).Name);
        Console.WriteLine("");
        Console.WriteLine("Southernmost Person: {0}", persons.MinBy(y => y.Latitude).Name);
        Console.WriteLine("");

        Console.WriteLine("Westernmost Person: {0}", persons.MinBy(y => y.Longitude).Name);
        Console.WriteLine("");
        Console.WriteLine("Easternmost Person: {0}", persons.MaxBy(y => y.Longitude).Name);

    }



    public static string MaxCompany(IEnumerable<Person> persons)
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

        return result.ToString();  
        //Console.WriteLine($" {result} is the most populated company");

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