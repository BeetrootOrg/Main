using ConsoleApp19Linq.Logic;
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
            var service = new LinqMethods();
            service.TopPersonsCompany(persons);
        }

    }
}
