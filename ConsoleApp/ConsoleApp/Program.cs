using System;

namespace ConsoleApp
{
    public class School
    {
        public string Name { get; set; }
        public string Address { get; set; }
    }

    public class Teacher
    {
        public int ID { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public Class[] ListOfClasses { get; set; }
        public Schedule TeacherSchedule { get; set; }
    }
    public class Class
    {
        public int ID { get; set; }
        public string Name { get; set; }
        public Teacher[] ListOfTeachers { get; set; }
    }
    public class Schedule
    {
        public int ID { get; set; }
        public Class[] ListOfClasses { get; set; }
    }
    public class Group
    {
        public int ID { get; set; }
        public Teacher MainTeacher { get; set; }
        public Student[] ListOfStudents { get; set; }
        public Schedule GroupSchedule { get; set; }
    }
    public class Student
    {
        public int ID { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public Group StudentsGroup { get; set; }
    }
}
