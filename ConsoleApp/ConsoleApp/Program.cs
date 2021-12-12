using System;

namespace ConsoleApp
{
    class School
    {
        string NameOfSchool { get; set; }
        Teacher[] Teachers { get; set; }
        Pupil[] Pupils { get; set; }
        Schedule Schedule { get; set; }
    }

    class Schedule
    {
        DateTime DayOfWeek { get; set; }
        Lesson[] Lessons { get; set; }
    }

    class Lesson
    {
        string NameLesson { get; set; }
        TimeOnly TimeStart { get; set; }
        TimeOnly TimeEnd { get; set; }
    }

    class Class
    {
        Teacher[] Teachers { get; set; }
        Pupil[] Pupils { get; set; }
        string[] Schedule { get; set; }
    }
    class Teacher
    {
        string FirstName { get; init; }
        string LastName { get; init; }
        string FullName => $"{FirstName} {LastName}";
        string PhoneNumber { get; set; }
        string Email { get; set; }
        Class[] Classes { get; set; }

    }

    class Pupil
    {
        string FirstName { get; init; }
        string LastName { get; init; }
        string FullName => $"{FirstName} {LastName}";
        string PhoneNumber { get; set; }
    }

    public class Program
    {
        static void Main()
        {
           
        }           
    }
}