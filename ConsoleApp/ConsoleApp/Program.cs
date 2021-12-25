using System;
namespace ConsoleApp
{
    enum Sex
    {
        Male,
        Female,
    }
    enum Material
    {
        Wood,
        Metal,
        Plastic,
    }
    enum Position
    {
        HeadTeacher,
        Director,
    }
    enum Subjects
    {
        Math,
        Physics,
        Chemistry,
        PE,
        Geography,
    }
    class School
    {
        public Staff Staff { get; set; }
        public Classrooms Classrooms { get; set; }
        public Students Students { get; set; }
    }
    class Staff
    {
        public Cleaner Cleaner { get; set; }
        public SecurityGuard SecurityGuard { get; set; }
        public Administration Administration { get; set; }
        public Teacher Teacher { get; set; }

    }
    class Cleaner
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public int Payment { get; set; }
        public int Age { get; init; }
    }
    class SecurityGuard
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public int Payment { get; set; }
        public int Age { get; init; }
    }
    class Administration
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public int Payment { get; set; }
        public Position Position { get; set; }
        public int Age { get; init; }
    }
    class Teacher
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public int Payment { get; set; }
        public Subjects Subjects { get; set; }
        public int Age { get; init; }
    }
    class Students
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public int Grade{ get; set; }
        public int Age { get; init; }
        public Sex Sex { get; init; }
    }
    class Classrooms
    {
        public Table Table { get; init; }
        public Chair Chair { get; init; }
        public Blackboard Blackboard { get; init; }
        public SubjectClassrom SubjectClassrom { get; init; }
        public int ClassroomsNumber{ get; init; }

    }
    class Table
    {
        public Material Material { get; init; }
        public int Amount{ get; init; }
    }
    class Chair
    {
        public Material Material { get; init; }
        public int Amount{ get; init; }
    }
    class Blackboard
    {
        public Material Material { get; init; }
        public int Amount{ get; init; }
    }
    class SubjectClassrom
    {
        public Subjects Subjects { get; init; }
        public Teacher Teacher { get; init; }
    }
}