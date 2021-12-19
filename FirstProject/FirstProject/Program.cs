using System;

namespace FirstProject
{
 
    class School
    {
        public string Number { get; init; }
        public string LocationId { get; init; }
        public int Staff { get; set; }

    }

    class Teacher
    {
        public string FirstName { get; init; }
        public string LastName { get; init; }
        private DateTime DateOfBirth { get; init; }
        public DateTime Experience { get; set; }
        private string PhoneNumber { get; set; }

    }

    class Schedule
    {
        public string Classes { get; set; }
        public int Rooms { get; set; }
        public string Teachers { get; set; }
        public string Subject { get; set; }
    }

    class Class
    {
        public int String { get; init; }
        public int Grade { get; set; }
        public string ClassTeacher { get; set; }
        private int ClassRoom { get; set; }

    }

    class Student
    {
        public string FirstName { get; init; }
        public string LastName { get; init; }
        public DateTime DateOfBirth { get; init; }
        public string PhoneNumber { get; set; }
        public string Class { get; set; }
        public int Marks { get; set; }  
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