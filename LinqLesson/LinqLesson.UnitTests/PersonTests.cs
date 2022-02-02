using Bogus;
using Shouldly;
using System;
using System.Collections.Generic;
using System.Linq;
using Xunit;

namespace LinqLesson.UnitTests
{
    public class PersonTests
    {
        private readonly Faker<Person> _faker;

        public PersonTests()
        {
            _faker = new Faker<Person>()
                .RuleFor(x => x.Email, f => f.Internet.Email());
        }

        [Fact]
        public void CollectAllEmailsShouldDoItWithRandomData()
        {
            CollectAllEmailShouldDoIt(_faker.GenerateBetween(5, 15));
        }

        [Theory]
        [InlineData("person@msdn.com")]
        [InlineData("person@msdn.com", "example@gmail.com")]
        [InlineData("person@msdn.com", "example@gmail.com", "example@gmail.com")]
        [InlineData("example@gmail.com", "example@gmail.com", "example@gmail.com")]
        [InlineData("person@gmail.com", "example@gmail.com", "guy@gmail.com")]
        public void CollectAllEmailsShouldDoItWithDefinedData(params string[] emails)
        {
            CollectAllEmailShouldDoIt(emails.Select(email => new Person { Email = email }));
        }

        [Fact]
        public void CollectAllEmailsShouldReturnEmptyStringIfNotPersosn()
        {
            CollectAllEmailShouldDoIt(Enumerable.Empty<Person>());
        }

        [Fact]
        public void CollectAllEmailsShouldThrowExceptionIfNullPassed()
        {
            // Arrange
            IEnumerable<Person> persons = null;

            // Act
            Action act = () => persons.CollectAllEmails();

            // Assert
            act.ShouldThrow<ArgumentNullException>();
        }


        private void CollectAllEmailShouldDoIt(IEnumerable<Person> persons)
        {
            // Arrange
            // 1. example@gmail.com
            // 2. person@msdn.com
            // method will return example@gmail.com;person@msdn.com - ok
            // what about person@msdn.com;example@gmail.com - ok
            // what about person@msdn.com,example@gmail.com - no
            // what about random string - no
            // what about person@msdn.com;example@gmail.com;example@gmail.com - no
            // what about person@msdn.com;example@gmail.com;another@gmail.com - no
            // what about person@msdn.com - no
            // what about empty string - no
            // what about null string - no

            // Act
            var actualEmails = persons.CollectAllEmails();
            var copy = actualEmails;

            // Assert
            foreach (var person in persons)
            {
                copy.ShouldContain(person.Email);
                copy = ReplaceFirst(copy, person.Email, string.Empty);
            }

            copy.Trim(';').ShouldBeEmpty();
        }

        private static string ReplaceFirst(string text, string search, string replace)
        {
            int position = text.IndexOf(search);
            if (position < 0)
            {
                return text;
            }

            return text[..position] + replace + text[(position + search.Length)..];
        }
    }
}