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
        private int _phoneNumberUpdatedCount;
        public int PhoneNumberUpdatedCount 
        { 
            get 
            {
                return _phoneNumberUpdatedCount; 
            } 
        }
        private string _phoneNumber;
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string FullName=>$"{FirstName} {LastName}";
        public Gender Gender { get; set; }
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
                _phoneNumberUpdatedCount++;
            } 
        }
        public double Height { get; set; }
        public int Weight { get; set; }
        
        public double WeightIndex()
        {
            return Weight / (Height * Height / 10000);
        }

    }
    class User
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string FullName => $"{FirstName} {LastName}";

    }
    class PhoneNumberRecord
    {
        public User User { get; set; }
        public string PhoneNumber { get; set; }
        public string Show() => $"{User.FullName} -> {PhoneNumber}";

    }
    class PhoneNumberBook
    {
        public PhoneNumberRecord[] Book { get; set; }
        public void ShowAll()
        {
            foreach(var record in Book)
            {
                Console.WriteLine(record.Show());
            }
        }
    }
    class Program
    {
        static void Main(string[] args)
        {
            var person1 = new Person();
            Console.WriteLine(person1);
            Console.WriteLine(person1.Age);
            //1 variant
            person1.FirstName = "Ivan";
            person1.LastName = "Safontev";
            person1.Age = 18;
            person1.PhoneNumber = "+1234";
            person1.Gender = Gender.Male;
            person1.Height = 180;

            //2 variant
            person1 = new Person
            {
                FirstName = "Ivan",
                LastName = "Safontev",
                Age = 18,
                PhoneNumber = "+1234",
                Gender = Gender.Male,
                Height = 180,
                Weight = 80,

            };
            Console.WriteLine(person1.FullName);
            person1.PhoneNumber = "+123456";
            Console.WriteLine(person1.PhoneNumberUpdatedCount);

            //person1 = null;

            Console.WriteLine($"Weight index= {person1.WeightIndex()}");


            var users = new User[]
            {
                new User
                {
                    FirstName ="a",
                    LastName="b",
                },
                new User
                {
                    FirstName="c",
                    LastName="d",
                }
            };

            var PhoneNumbers = new PhoneNumberRecord[]
            {
                new PhoneNumberRecord
                {
                    User=users[0],
                    PhoneNumber="+1234",
                },
                new PhoneNumberRecord
                {
                    User=users[1],
                    PhoneNumber="+123432",
                }
            };

            var book = new PhoneNumberBook
            {
                Book = PhoneNumbers
            };
            book.ShowAll();
        }
    }
}
