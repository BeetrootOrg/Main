using System;
namespace Course
{
    public class Lesson
    {
        public int Id { get; init; }
        public string Name { get; set; }
    }

    public class Schedule
    {
        public int Id { get; init; }
        public Lesson[] Lessons { get; set; }
    }

    public class Pupil
    {
        public int Id { get; init; }
        public string FullName { get; set; }
        public Class Class { get; set; }
        private string PersonalCharacteristics { get; set; }
    }
    public class Class
    {
        public int Id { get; init; }
        public Teacher ClassManager { get; set; }
        public Pupil[] Pupils { get; set; }
        public Schedule Schedule { get; set; }
    }

    public class Teacher
    {
        public int Id { get; init; }
        public string FullName { get; set; }
        public Lesson[] LessonsToTeach { get; set; }
        private double AnnualIncome { get; set; }
        public Schedule TeachersSchedule { get; set; }
        private string PersonalCharacteristics { get; set; }
    }

    public class School
    {
        public int Id { get; init; }
        public string Name { get; set; }
        public DateTime LaunchDate { get; init; }
        public Class[] Classes { get; set; }
        private Teacher[] Teachers { get; set; }
    }
}
