using System;

namespace ConsoleApp
{
    class School
    {
        string NameOfSchool { get; set; }
        Teacher[] Teachers { get; set; }
        Pupil[] PupilsInSchool { get; set; }
        Class[] Classes { get; set; }
        Schedule Schedule { get; set; }
    }

    class Schedule
    {
        DateTime DayOfWeek { get; set; }
        Lesson[] Lessons { get; set; }
    }

    class Lesson
    {
        string ClassNameLesson { get; set; }
        string NameLesson { get; set; }
        TimeOnly TimeStart { get; set; }
        TimeOnly TimeEnd { get; set; }

    }

    class Class
    {
        string Name { get; set; }
        Teacher[] Teachers { get; set; }
        Pupil[] Pupils { get; set; }
        Schedule Schedule { get; set; }
    }
    class Teacher
    {
        string FirstName { get; init; }
        string LastName { get; init; }
        string FullName => $"{FirstName} {LastName}";
        private string PhoneNumber { get; set; }
        private string Email { get; set; }
        private Class[] TeacherClasses { get; set; }

    }

    class Pupil
    {
        string FirstName { get; init; }
        string LastName { get; init; }
        string FullName => $"{FirstName} {LastName}";
        private string PhoneNumber { get; set; }
        Class PupilClass { get; set; }
    }

    public class Program
    {
        static void Main()
        {
            Console.WriteLine(Math.Ceiling(96.0 / 25.0));
        }           
    }
}