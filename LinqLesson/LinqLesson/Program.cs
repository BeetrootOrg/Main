using Newtonsoft.Json;
using System.Collections.Generic;
using System;
using System.IO;
using System.Linq;

namespace LinqLesson;

class Program
{
    static void Main(string[] args)
    {
        var persons = JsonConvert.DeserializeObject<IEnumerable<Person>>(File.ReadAllText("data.json"));

        CountByGender1(persons);
        YoungestPerson1(persons);
        YoungestPerson2(persons);
    }

    static void CountByGender1(IEnumerable<Person> persons)
    {
        Console.WriteLine($"Males: {persons.Count(person => person.Gender == Gender.Male)}");
        Console.WriteLine($"Females: {persons.Count(person => person.Gender == Gender.Female)}");
    }

    static void YoungestPerson1(IEnumerable<Person> persons)
    {
        Console.WriteLine($"Youngest: {persons.OrderBy(x => x.Age).First()}");
    }

    static void YoungestPerson2(IEnumerable<Person> persons)
    {
        Console.WriteLine($"Youngest: {persons.MinBy(x => x.Age)}");
    }
}
