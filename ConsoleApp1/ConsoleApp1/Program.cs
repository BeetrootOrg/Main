namespace Console
{
    using System;
    using System.Collections.Generic;
    using System.IO;
    using System.Text;
    class Program
    { 
    public static void Main()
        {
            var person = new Person();
            Console.WriteLine(person.Age);
            Console.WriteLine(person);
        }
    }
    public enum Gender
    {
        Male,
        Fenale
    }
    public class Person
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public int Age { get; set; }
        public string PhoneNumber { get; set; }
        public Gender Gender { get; set; }
        public int Height { get; set; }

    }

}