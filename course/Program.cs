using System.Diagnostics.CodeAnalysis;
using Newtonsoft.Json;

namespace Course
{
    public enum Side
    {
        North,
        South,
        West,
        East,
    }

    class Program
    {
        static void Main()
        {
            var persons = JsonConvert.DeserializeObject<IEnumerable<Person>>(File.ReadAllText("data.json"));

            FarthestPerson(persons, Side.West);
            FarthestPerson(persons);
            Console.WriteLine("\n");
            SimilarAboutPeople(persons);
            Console.WriteLine("\n");
            SameFriendPeople(persons);
            Console.WriteLine("\n");
            CompanyWithMostPeople(persons);
        }

        static void FarthestPerson(IEnumerable<Person> persons, Side side = Side.North)
        {
            var person = side switch
            {
                Side.South => persons.MinBy(x => x.Latitude),
                Side.East => persons.MaxBy(x => x.Longitude),
                Side.West => persons.MinBy(x => x.Longitude),
                _ => persons.MaxBy(x => x.Latitude),
            };
            Console.WriteLine($"The farthest {side} person is {person.Name}");
        }

        static void SimilarAboutPeople(IEnumerable<Person> persons)
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
                    int commonAboutWords = 0;
                    var firstAboutList = twoPersons.First.About.Split(' ').Distinct().ToList();
                    var secondAboutList = twoPersons.Second.About.Split(' ').Distinct().ToList();
                    foreach (var word in firstAboutList)
                    {
                        if (secondAboutList.Contains(word))
                        {
                            commonAboutWords++;
                        }
                    }

                    return new
                    {
                        First = twoPersons.First,
                        Second = twoPersons.Second,
                        CommonAboutWords = commonAboutWords
                    };
                })
                .ToList();
            var commonAboutFriends = friends.MaxBy(x => x.CommonAboutWords);
            Console.WriteLine($"People {commonAboutFriends.First.Name} and {commonAboutFriends.Second.Name} have similarities in Above");
            Console.WriteLine($"The number of similarities - {commonAboutFriends.CommonAboutWords}");
        }

        static void SameFriendPeople(IEnumerable<Person> persons)
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
                    bool hasCommonFriend = false;
                    foreach (Friend friend in twoPersons.First.Friends)
                    {
                        if (twoPersons.Second.Friends.Any(secondFriend => secondFriend.Name == friend.Name))
                        {
                            hasCommonFriend = true;
                            break;
                        }
                    }

                    return new
                    {
                        First = twoPersons.First,
                        Second = twoPersons.Second,
                        HasCommonFriend = hasCommonFriend
                    };
                })
                .ToList();
            var commonFriends = friends.FirstOrDefault(x => x.HasCommonFriend);
            if (commonFriends == null)
            {
                throw new Exception("People in your database have no common friends");
            }
            Console.WriteLine($"People {commonFriends.First.Name} and {commonFriends.Second.Name} have same friend");
        }

        static void CompanyWithMostPeople(IEnumerable<Person> persons)
        {
            var biggestCompany = persons.SelectMany(person => person.Company)
                .GroupBy(company => company)
                .Select(company => new
                {
                    Company = company.Key,
                    Count = company.Count()
                })
                .MaxBy(x => x.Count);
            Console.WriteLine($"The biggest company is {biggestCompany.Company} with {biggestCompany.Count} employees");
        }
    }    
}
