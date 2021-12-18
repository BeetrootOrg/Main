using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Linq;

namespace ConsoleApp
{
    //i.safontev/homework/10-encapsulation
   
    enum Subjects
    {
        Math,
        History,
        Biology,
        Chemistry,
        Programming,
        PhysicalCulrite
    }
    class School
    {
        public string Name { get; set; }
        public Teacher[] AllTeachers { get; set; }
        public Student[] AllStudents { get; set; }
        public Class[] AllClasses { get; set; }
    }

    class Teacher
    {
        public string Name { get; set; }
        public string Surname { get; set; }
        public string Gender { get; set; }
        private int Age { get; set; }
        private double Salary { get; set; }
        public Subjects Subject { get; set; }

    }

    class Student
    {
        public string Name { get; set; }
        public string Surname { get; set; }
        public string Gender { get; set; }
        public Class Class { get; set; }
        public int Age { get; set; }

    }

    class Class
    {
        public string Name { get; set; }
        public Student[] Students { get; set; }
        public Shedule Shedule { get; set; }

    }

    class Shedule
    {
        public string Day { get; set; }
        public Subjects[] Subjects { get; set; }
    }

    class Program
    {
        static void Main()
        {
            


        }

    }
}