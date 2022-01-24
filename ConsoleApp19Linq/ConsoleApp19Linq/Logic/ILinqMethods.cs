using LinqLesson;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp19Linq.Logic
{
    public interface ILinqMethods
    {
        IEnumerable<Person> GetTop2PeopleWithDuplicates(IEnumerable<Person> persons);
        int CountDuplicates(string about);
        int TwoPeopleWithOneFriend(IEnumerable<Person> persons);
        string TopPersonsCompany(IEnumerable<Person> persons);
        IEnumerable<Person> GetFarestPeople(IEnumerable<Person> persons);
    }
}
