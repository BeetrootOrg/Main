using LinqLesson;
using System.Collections.Generic;
using Xunit;

namespace ConsoleApp.UnitTest
{
    public class UnitTest1
    {

        //  public LinqLesson.Program program = new LinqLesson.Program();


        [Fact]
        public void Test1()
        {
            Assert.Equal(1, 1);

        }

        [Fact]
        public void TestMostUsedTag()
        {
            //Arrange
            List<Person> people = new List<Person>();

            for (int i = 0; i < 5; i++)
            {
                var person = new Person
                {
                    Id = i.ToString(),
                    Index = i,
                    Tags = new[] { "testTag" },
                };

                people.Add(person);
            };

            //Act
            string result = people.MostUsedTag();

            //Assert

            Assert.Equal("testTag", result);
        }

        [Fact]
        public void TestYoungestPerson1()
        {
            //Arrange
            List<Person> people = new List<Person>();

            for (int i = 1; i < 5; i++)
            {
                var person = new Person
                {
                    Id = i.ToString(),
                    Index = i,
                    Age=i,
                };

                people.Add(person);
            };

            //Act
            int minAge = people.YoungestPerson1().Age;

            //Assert

            Assert.Equal(1, minAge);
        }

    }
}