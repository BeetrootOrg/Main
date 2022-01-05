using Newtonsoft.Json;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace LinqLesson;

class Program
{
    static void Main(string[] args)
    {
        var persons = JsonConvert.DeserializeObject<IEnumerable<Person>>(File.ReadAllText("data.json"));
        System.Console.WriteLine(persons.Count());
    }
}
