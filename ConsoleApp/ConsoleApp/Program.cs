﻿using System;

namespace ConsoleApp
{
    enum Gender
    {
        Male,
        Female
    }

    class Person
    {
        private int _phoneNumberUpdatedCounter;
        private string _phoneNumber;


        public string FirstName { get; set; }
        public string LastName { get; set; }
        public int Age { get; set; }
        public string PhoneNumber
        {
            get
            {
                return _phoneNumber;
            }
            set
            {
                _phoneNumber = value;
                ++_phoneNumberUpdatedCounter;
            }
        }

        public Gender Gender { get; set; }
        public int Height { get; set; }

        public int PhoneNumberUpdatedCounter
        {
            get
            {
                return _phoneNumberUpdatedCounter;
            }
        }

        public int Weight { get; init; }
    }

    class Program
    {
        static void Main()
        {
            var person = new Person();
            Console.WriteLine(person);
            Console.WriteLine(person.Age);

            // 1st approach to init
            person.FirstName = "Dima";
            person.LastName = "Misik";
            person.Age = 25;
            person.PhoneNumber = "+12345";
            person.Gender = Gender.Male;
            person.Height = 178;

            Console.WriteLine(person.Age);

            // 2nd approach to init - preferable
            person = new Person
            {
                FirstName = "Dima",
                LastName = "Misik",
                Age = 25,
                PhoneNumber = "+12345",
                Gender = Gender.Male,
                Height = 178,
                Weight = 70
            };

            var person1 = new Person();

            Console.WriteLine(person.PhoneNumber);
            Console.WriteLine(person.Weight);

            person.PhoneNumber = "+12346";
            Console.WriteLine(person.PhoneNumberUpdatedCounter);
        }
    }
}