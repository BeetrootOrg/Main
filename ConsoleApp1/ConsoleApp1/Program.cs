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

            person.FirstName = "Dima";
            person.LastName = "Sulym";
            person.Age = 32;
            person.PhoneNumber = "+380631669127";
            person.Height = 202;
            person.Weight = 108;

            Console.WriteLine(person.WeightIndex());
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
        public int Weight { get; set; }
        public double WeightIndex()
        {
            return Weight/(Height*Height/10000);
        }
    }

    public class User
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }  
    }

    public class PhoneNumberRecord
    {
        public User User { get; set; }
        public string phoneNumber { get; set; }
    }

    public class PhoneBook
    {
        public PhoneNumberRecord[] phoneNumberRecords { get; set; }
    }
   
}