using System;

namespace ConsoleApp
{
    enum Gender
    {
        Male,
        Female
    }

    class Person
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public int Age { get; set; }
        public string PhoneNumber { get; set; }
        public Gender Gender { get; set; }
        public int Height { get; set; }
    }

    class Program
    {
        static void Main()
        {
            var person = new Person();
            Console.WriteLine(person);
            Console.WriteLine(person.Age);
        }
    }
}