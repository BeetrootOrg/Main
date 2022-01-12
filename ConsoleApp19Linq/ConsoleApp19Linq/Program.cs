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

//            використовуючи код з персонами, що я писав під час уроку, створити наступні методи:
//            метод, що виводить людей що знаходяться найпівнічніше/ південіше / західніше / східніше
//            метод, що виводить двох людей, у яких в About найбільше однакових слів
//            метод, що виводить двох людей, у котрих є спільний друг
//            метод, що виводить назву компанії в якій працює найбільша кількість людей та кількість людей, що там працює
            
            var persons = JsonConvert.DeserializeObject<IEnumerable<Person>>(File.ReadAllText("data.json"));
            GetTop2PeopleWithDuplicates(persons);
            TopPersonsCompany(persons);
        }

        private static IEnumerable<Person> GetFarestPeople(IEnumerable<Person> persons)
        {
            var east = persons.OrderBy(x => x.Longitude).First();
            var west = persons.OrderByDescending(x => x.Longitude).First();
            var north = persons.OrderBy(x => x.Latitude).First();
            var south = persons.OrderByDescending(x => x.Latitude).First();
            return new List<Person>() { south, west, north, south};
        }

        private static IEnumerable<Person> GetTop2PeopleWithDuplicates(IEnumerable<Person> persons)
        {
            var about = persons.OrderBy(x => CountDuplicates(x.About)).Take(2);
            return about;
        }


        private static int CountDuplicates(string about)
        {

            var list = about.Split(' ').ToList();
            return list.GroupBy(n => n).Count(c => c.Count() > 1);
        }

        private static IEnumerable<Person> TwoPeopleWithOneFriend(IEnumerable<Person> persons)
        {
            //NOT FINISHED YET
            var friends = persons.Join(persons,
                 person => true,
                 person2 => true,
                 (person, person2) => new
                 {
                     First = person,
                     Second = person2
                 })
                 .Where(twoPersons => twoPersons.First != twoPersons.Second);
            return null;
         }

        private static void TopPersonsCompany(IEnumerable<Person> persons)
        {
            var topCompany = persons.SelectMany(person => person.Company)
               .GroupBy(company => company).Select(company => new
               {
                   Company = company.Key,
                   Count = company.Count()
               }).OrderByDescending(x => x.Count).First();
            Console.WriteLine($"{topCompany.Company} {topCompany.Count}");
        }

    }
}
