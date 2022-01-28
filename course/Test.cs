using Course;
using Xunit;

namespace CourseTests
{
    public class UnitTest1
    {
        private readonly LinqMethods _service;
        public UnitTest1()
        {
            _service = new LinqMethods();
        }

        [Fact]
        public void GetCompanyWithMostPeople()
        {
            var people = new List<Person>();
            //Arrange
            var person1 = new Person()
            {
                Company = "Test1"
            };
            people.Add(person1);
            var person2 = new Person()
            {
                Company = "Test2"
            };
            people.Add(person2);
            var person3 = new Person()
            {
                Company = "Test3"
            };
            people.Add(person3);
            var person4 = new Person()
            {
                Company = "Test1"
            };
            people.Add(person4);

            //Act
            var result = _service.GetCompanyWithMostPeople(people);

            //Assert
            Assert.Equal(person1.Company, result);
        }

    }

}
