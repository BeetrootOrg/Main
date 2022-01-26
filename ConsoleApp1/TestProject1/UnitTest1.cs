using LinqLesson;
using Microsoft.VisualStudio.TestPlatform.TestHost;
using System;
using System.Collections.Generic;
using Xunit;

namespace TestProject1
{
    public class LinqUnitTest1
    {

        public LinqLesson.ProgramX _program = new LinqLesson.ProgramX();

        [Fact]
        public void MaxCompanyTest()
        {

            List<Person> people = new List<Person>{
                   new Person{Id="1",Index=1,Guid=new Guid("a016f28c-dd5e-414c-85d2-706aee8862d6"),IsActive=true,Balance="7",Age=32,EyeColor="brown",Name="Vasia Pupkin",Gender=Gender.Male,Company="Horns and Hoofs",Email="",Phone="",Address="",About="",Registered=new DateTime(2010,7,20),Latitude=67,Longitude=25,Tags=null,Friends=null},
                   new Person{Id="1",Index=1,Guid=new Guid("b105e6fe-4dd9-4966-8bce-300ef6096fdf"),IsActive=true,Balance="7",Age=32,EyeColor="brown",Name="Lionia Holubkov",Gender=Gender.Male,Company="Horns and Hoofs",Email="",Phone="",Address="",About="",Registered=new DateTime(2010,7,20),Latitude=67,Longitude=25,Tags=null,Friends=null},
                   new Person{Id="1",Index=1,Guid=new Guid("eec58a87-db71-44cc-8862-be65eac4442a"),IsActive=true,Balance="1000000",Age=25,EyeColor="brown",Name="Dima Misik",Gender=Gender.Male,Company="FBI",Email="",Phone="",Address="",About="",Registered=new DateTime(2010,7,20),Latitude=67,Longitude=25,Tags=null,Friends=null},

            reality =_program.MaxCompany(people);

            Assert.Equal("Horns and Hoofs", reality);
        }
    }
}