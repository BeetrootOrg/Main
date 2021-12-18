using System;

namespace ConsoleApp
{
    enum Subject
    {
        Math,
        Chemistry,
        Biology,
        Law,
        History,
        Literature
    }

    class School
    {
        public string Number { get; init; }
        public string Adress { get; init; }
        public int QuantityOfRooms { get; set; }
    
    }

    class Teacher
    {
        public string FirstName { get; init; }
        public string LastName { get; init;  }
        private DateTime DateOfBirth{ get; init; }
        public DateTime Experience { get; set; }
        private string  HomeAdress{ get; set; }
        private string PhoneNumber { get; set; }
        public Subject subject { get; set; }

    }

    class Schedule
    {
        public string Classes { get; set; }
        public Subject Subjects { get; set; }
        public int Rooms { get; set; }
        public string Teachers {get;set;}

  
    }

    class Class
    {   
        public int String{ get; init; }
        public int Grade{ get; set; }
        public string ClassTeacher { get; set; }
        private int ClassRoom { get; set; }
        
    }

    class Student
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public DateTime DateOfBirth { get; set; }
        public string HomeAdress { get; set; }
        public string PhoneNumber { get; set; }
        public string Class { get; set; }

        public void AddStudent(string firstName, string lastName, DateTime dateOfBirth, string className, string homeAdress ="", string phoneNumber="")
        {
            
            FirstName = firstName;
            LastName = lastName;
            DateOfBirth = dateOfBirth;
            HomeAdress = homeAdress;
            PhoneNumber = phoneNumber;
            Class = className;

        }
     
    }



    class Program
    {
        static void Main()
        {
            {      
                
            }
        }
    }
}