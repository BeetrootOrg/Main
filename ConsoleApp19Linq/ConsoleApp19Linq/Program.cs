using LinqLesson;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace ConsoleApp19Linq
{
    internal class Program
    {
        static void Main(string[] args)
        {
            var persons = JsonConvert.DeserializeObject<IEnumerable<Person>>(File.ReadAllText("data.json"));
        }

        public IEnumerable<Person> GetFarestPeople(IEnumerable<Person> persons)
        {
            var east = persons.OrderBy(x => x.Latitude).First();
            var west = persons.OrderByDescending(x => x.Latitude).First();
            var north = persons.OrderByDescending(x => x.Longitude).First();
            var south = persons.OrderBy(x => x.Longitude).First();
            return new List<Person>() { south, west, north, east };
        }

        public IEnumerable<Person> GetTop2PeopleWithDuplicates(IEnumerable<Person> persons)
        {
            var about = persons.OrderByDescending(x => CountDuplicates(x.About)).Take(2);
            return about;
        }


        public int CountDuplicates(string about)
        {

            var list = about.Split(' ').ToList();
            return list.GroupBy(n => n).Count(c => c.Count() > 1);
        }

        public int TwoPeopleWithOneFriend(IEnumerable<Person> persons)
        {
            var result = persons.Join(persons,
                person => true,
                person => true,
                (p1, p2) => new
                {
                    First = p1,
                    Second = p2
                }).Where(p => p.First != p.Second).Select(p =>
                {
                    var firstFriends = p.First.Friends;
                    var secondFriends = p.Second.Friends;
                    var intersection = firstFriends.Intersect(secondFriends);
                    return new { p.First, p.Second, CommonFriends = intersection };
                });
            return result.Count() / 2;

        }

        public string TopPersonsCompany(IEnumerable<Person> persons)
        {
            var topCompany = persons
               .GroupBy(p => p.Company).Select(company => new
               {
                   Company = company.Key,
                   Count = company.Count()
               }).OrderByDescending(x => x.Count).First();
            Console.WriteLine($"{topCompany.Company} {topCompany.Count}");
            return topCompany.Company;
        }

    }
}
