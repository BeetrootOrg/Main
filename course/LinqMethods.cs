

namespace Course
{
    public enum Side
    {
        North,
        South,
        West,
        East,
    }

    public class LinqMethods
    {
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
                    var firstAboutList = twoPersons.First.About.Split(' ').Distinct().ToList();
                    var secondAboutList = twoPersons.Second.About.Split(' ').Distinct().ToList();
                    int commonAboutWords = firstAboutList.Intersect(secondAboutList).Count();

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
                // throw new Exception("People in your database have no common friends");
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

        internal string GetCompanyWithMostPeople(List<Person> people)
        {
            var biggestCompany = people
                .GroupBy(person => person.Company)
                .Select(company => new
                {
                    Company = company.Key,
                    Count = company.Count()
                })
                .MaxBy(x => x.Count);
            return biggestCompany.Company;
        }
    }
}
