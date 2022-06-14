using LinqLesson;
using Shouldly;
using System.Collections.Generic;
using Xunit;

namespace LinqLessons.UnitTest
{
    public class UnitTest
    {
        
        [Fact]
        public void BigestCompanyShouldBe()
        {
            //Avarage
            var persons = new List<Person>();

            var Company1 = new Person()
            {
                Company = "BLA-BLA"
                
            };
            persons.Add(Company1);

            var Company2 = new Person()
            {
                Company = "LA-LA"
               
            };
            persons.Add(Company2);

            var Company3 = new Person()
            {
                Company = "FA-Fa"
                
            };
            persons.Add(Company3);


            //Act

            var actualCompany = persons.BigestCompany();

            //Arrange

            actualCompany.ShouldContain(persons.BigestCompany());
        }
    }
}