using ConsoleApp19Linq.Logic;
using FakeItEasy;
using LinqLesson;
using System;
using System.Collections.Generic;
using System.Linq;
using Xunit;

namespace Tests
{
    public class UnitTest1
    {
        private readonly ILinqMethods _service;
        public UnitTest1()
        {
            _service = new LinqMethods();
        }


        [Fact]
        public void GetFarestPeople_Success()
        {
            //Arrange
            var people = new List<Person>();
            var north = new Person()
            {
                Longitude = 50
            };
            people.Add(north);
            var south = new Person()
            {
                Longitude = -10
            };
            people.Add(south);
            var east = new Person()
            {
                Latitude = -80
            };
            people.Add(east);
            var west = new Person()
            {
                Latitude = 50
            };
            people.Add(west);

            //Act
            var result = _service.GetFarestPeople(people).ToList();

            //Assert
            Assert.Equal(result[0].Longitude, south.Longitude);
            Assert.Equal(result[1].Latitude, west.Latitude);
            Assert.Equal(result[2].Longitude, north.Longitude);
            Assert.Equal(result[3].Latitude, east.Latitude);
        }

        [Fact]
        public void GetTop2PeopleWithDuplicates()
        {
            //Arrange

            var people = new List<Person>();

            var person1 = new Person()
            {
                Name = "Jora",
                About = "bi bi bi"
            };
            people.Add(person1);
            var person2 = new Person()
            {
                Name = "Yakov",
                About = "ba ba"
            };
            people.Add(person2);
            var person3 = new Person()
            {
                Name = "Taras",
                About = "bi"
            };
            people.Add(person3);
            //Act
            var result = _service.GetTop2PeopleWithDuplicates(people).ToList();

            //Assert
            Assert.Equal(result[0].Name, person1.Name);
            Assert.Equal(result[1].Name, person2.Name);
        }
        [Fact]
        public void TopPersonsCompany()
        {
            var people = new List<Person>();
            //Arrange
            var person1 = new Person()
            {
                Company = "Google"
            };
            people.Add(person1);
            var person2 = new Person()
            {
                Company = "Apple"
            };
            people.Add(person2);
            var person3 = new Person()
            {
                Company = "Google"
            };
            people.Add(person3);

            //Act
            var result = _service.TopPersonsCompany(people).ToList();

            //Assert
            Assert.Equal(person1.Company, result);
        }
        [Fact]
        public void TwoPeopleWithOneFriend()
        {
            var people = new List<Person>();
            //Averrage
            var person1 = new Person()
            {
                Friends = new Friend[] { new Friend() { Name = "Sasha" } }
            };
            people.Add(person1);
            var person2 = new Person()
            {
                Friends = new Friend[] { new Friend() { Name = "Sasha" } }
            };
            people.Add(person2);
            var person3 = new Person()
            {
                Friends = new Friend[] { new Friend() { Name = "Pasha" } }
            };
            people.Add(person3);

            //Act
            var result = _service.TwoPeopleWithOneFriend(people);

            //Assert
            Assert.Equal(1, result);
        }

    }

}
