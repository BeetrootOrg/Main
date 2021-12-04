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
        private int _phoneNumberUpdatedCounter;
        private string _phoneNumber;


        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string FullName => $"{FirstName} {LastName}";
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

        public double WeightIndex()
        {
            return Weight / (Height * Height / 10000);
        }
    }

    class User
    {
        public string FirstName { get; init; }
        public string LastName { get; init; }
        public string FullName => $"{FirstName} {LastName}";
    }

    class PhoneNumberRecord
    {
        public User User { get; init; }
        public string PhoneNumber { get; init; }

        public string Show() => $"{User.FullName} -> {PhoneNumber}";
    }

    class PhoneNumberBook
    {
        public PhoneNumberRecord[] Book { get; init; }

        public void ShowAll()
        {
            foreach (var record in Book)
            {
                Console.WriteLine(record.Show());
            }
        }
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

            var person1 = new Person
            {
                Weight = 90,
                Height = 190
            };

            Console.WriteLine(person.PhoneNumber);
            Console.WriteLine(person.Weight);
            Console.WriteLine(person.FullName);

            person.PhoneNumber = "+12346";
            Console.WriteLine(person.PhoneNumberUpdatedCounter);
            Console.WriteLine($"Weight Index = {person.WeightIndex()}");
            Console.WriteLine($"Weight Index = {person1.WeightIndex()}");

            var users = new User[]
            {
                new User
                {
                    FirstName = "A",
                    LastName = "B"
                },
                new User
                {
                    FirstName = "C",
                    LastName = "D"
                }
            };

            var phoneNumbers = new PhoneNumberRecord[]
            {
                new PhoneNumberRecord
                {
                    User = users[0],
                    PhoneNumber = "+1234"
                },
                new PhoneNumberRecord
                {
                    User = users[1],
                    PhoneNumber = "+1235"
                },
                new PhoneNumberRecord
                {
                    User = users[0],
                    PhoneNumber = "126"
                }
            };

            var book = new PhoneNumberBook
            {
                Book = phoneNumbers
            };

            book.ShowAll();
        }
    }
}