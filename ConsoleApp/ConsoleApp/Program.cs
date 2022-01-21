using Newtonsoft.Json;
using System.Collections.Generic;
using System;
using System.Linq;
using System.IO;


namespace LinqLesson;

static class PersonsExtension
{
    const double RadiusEarth = 6372.795;

    public static void MinMaxDistanceBetweenPersons(this IEnumerable<Person> persons)
    {
        var distances = persons.Join(persons,
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
                var distance = DistanceOnEarth(twoPersons.First.Latitude, twoPersons.Second.Longitude, twoPersons.Second.Latitude, twoPersons.Second.Longitude);

                return new
                {
                    First = twoPersons.First,
                    Second = twoPersons.Second,
                    Distance = distance
                };
            })
            .ToArray();

        var min = distances.MinBy(x => x.Distance);
        var max = distances.MaxBy(x => x.Distance);

        Console.WriteLine($"Min distance is between {min.First} and {min.Second} is {min.Distance} km");
        Console.WriteLine($"Max distance is between {max.First} and {max.Second} is {max.Distance} km");
    }

    public static void MaxDistanseFromCardinalDirection(this IEnumerable<Person> persons)
    {
        var distances = persons.Select(person =>
        {
            var distanceToNorth = DistanceOnEarth(person.Latitude, person.Longitude, 90, person.Longitude);
            var distanceToSouth = DistanceOnEarth(person.Latitude, person.Longitude, -90, person.Longitude);
            var distanceToEast = DistanceOnEarth(person.Latitude, person.Longitude, person.Latitude, 0);
            var distanceToWest = DistanceOnEarth(person.Latitude, person.Longitude, person.Latitude, -180);

            return new
            {
                Name = person.Name,
                DistanceToNorth = distanceToNorth,
                DistanceToSouth = distanceToSouth,
                DistanceToEast = distanceToEast,
                DistanceToWest = distanceToWest
            };
        }).ToArray();

        var maxFromNorth = distances.MaxBy(x => x.DistanceToNorth);
        var maxFromSouth = distances.MaxBy(x => x.DistanceToSouth);
        var maxFromEast = distances.MaxBy(x => x.DistanceToEast);
        var maxFromWest = distances.MaxBy(x => x.DistanceToWest);

        Console.WriteLine($"Max distance to North by {maxFromNorth.Name}, {maxFromNorth.DistanceToNorth} km");
        Console.WriteLine($"Max distance to North by {maxFromSouth.Name}, {maxFromSouth.DistanceToSouth} km");
        Console.WriteLine($"Max distance to North by {maxFromEast.Name}, {maxFromEast.DistanceToEast} km");
        Console.WriteLine($"Max distance to North by {maxFromWest.Name}, {maxFromWest.DistanceToWest} km");
    }


    public static void SameWordsInAbout(this IEnumerable<Person> persons)
    {
        var group = persons.Join(persons,
            person => true,
            person => true,
            (person1, person2) => new
            {
                First = person1,
                Second = person2
            })
            .Where(twoPerson => twoPerson.First != twoPerson.Second)
            .Select(twoPersons =>
            {
                var listFirst = twoPersons.First.About.Split('.', '?', '!', ' ', ';', ':', ',');
                var listSecond = twoPersons.Second.About.Split('.', '?', '!', ' ', ';', ':', ',');

                return new
                {
                    FirstPerson = twoPersons.First,
                    SecondPerson = twoPersons.Second,
                    SimilarWordsInAbout = listFirst.Intersect(listSecond).Count()
                };
            }).ToList();

        var resultPersons = group.MaxBy(x => x.SimilarWordsInAbout);

        Console.WriteLine($"Most similar ABOUT is: {resultPersons.SimilarWordsInAbout} same word in {resultPersons.FirstPerson.Name} and {resultPersons.SecondPerson.Name} descroption.");
    }

    public static void SameFriends(this IEnumerable<Person> persons)
    {
        var group = persons.Join(persons,
            person => true,
            person => true,
            (person1, person2) => new
            {
                First = person1,
                Second = person2
            })
            .Where(twoPerson => twoPerson.First != twoPerson.Second)
            .Select(twoPersons =>
            {
                var listFriendsFirst = twoPersons.First.Friends.Select(x => x.Name);
                var listFriendsSecond = twoPersons.Second.Friends.Select(x => x.Name);

                return new
                {
                    FirstPerson = twoPersons.First,
                    SecondPerson = twoPersons.Second,

                    SameFriends = listFriendsFirst.Intersect(listFriendsSecond)
                };
            })
            .Where(twoPersons => twoPersons.SameFriends.Count() > 0)
            .ToList();

        if (group.Count > 0)
        {
            foreach (var twoPerson in group)
            {
                Console.WriteLine($"People with same friends: {twoPerson.FirstPerson.Name} and {twoPerson.SecondPerson.Name}");
            }
        }
        else
        {
            Console.WriteLine("No one have same friends.");
        }

    }

    public static double DistanceOnEarth(double firstLatitude, double firstLongitude, double secondLatitude, double secondLongitude)
    {
        //Convert To Radian
        var x1 = AngleToRadian(firstLatitude);
        var y1 = AngleToRadian(firstLongitude);

        var x2 = AngleToRadian(secondLatitude);
        var y2 = AngleToRadian(secondLongitude);


        return Math.Round(RadiusEarth * Math.Acos(Math.Sin(x1) * Math.Sin(x2) + Math.Cos(x1) * Math.Cos(x2) * Math.Cos(y2 - y1)));
    }
    static double AngleToRadian(double x) => x * Math.PI / 180;
}

class Program
{
    static void Main(string[] args)
    {

        var persons = JsonConvert.DeserializeObject<IEnumerable<Person>>(File.ReadAllText("data.json"));

        persons.MaxDistanseFromCardinalDirection();

        persons.SameWordsInAbout();

        persons.SameFriends();

    }

}
