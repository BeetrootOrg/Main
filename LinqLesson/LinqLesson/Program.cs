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

        CountByGender(persons);
    }

    static void CountByGender(IEnumerable<Person> persons)
    {
        Console.WriteLine($"Males: {persons.Count(person => person.Gender == Gender.Male)}");
        Console.WriteLine($"Females: {persons.Count(person => person.Gender == Gender.Female)}");
    }
}
