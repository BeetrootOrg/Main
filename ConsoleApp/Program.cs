namespace ConsoleApp
{
    using System;
    class ConsoleApp
    {
        enum Subject
        {
            Mathematics,
            Literature,
            History
        }

        class Lesson
        {
            DateTime dateTime;
            Subject subject;
            Teacher teacher;
        }
        class Schedule
        {
            private int _MaxGrade;
            private int _DaysInYear;
            private Lesson[,] _Lessons;

            public Schedule()
            {
                _Lessons = new Lesson[365, 11];
            }
            public Schedule (int daysInYear, int maxGrade)
            {
                _DaysInYear = daysInYear;
                _MaxGrade = maxGrade;
                _Lessons = new Lesson[_DaysInYear,_MaxGrade];
            }
            public void UpdateSchedule (DateTime dateTime, Subject subject, Teacher teacher) {}
            public (Teacher, int Grade)[] GetSchedule (DateTime dateTime, Subject subject) { return null; }
            public (Subject, int Grade)[] GetSchedule (DateTime dateTime, Teacher teacher) { return null; }
            public (Subject, Teacher)[] GetSchedule (DateTime dateTime, int Grade) { return null; }
        }
        class Classes
        {
            Subject subject;
            Schedule schedule;
        }
        class PupilsInformation
        {
            private Schedule schedule;
            public PupilsInformation(ref Schedule sch)
            {
                schedule = sch;
            }
            public (Subject, Teacher)[] GetScheduleInformation(DateTime dateTime, int Grade) { return schedule.GetSchedule(dateTime, Grade); }
        }
        class Pupils
        {
            string Name;
            Subject[] subject;
            public PupilsInformation Information;
        }
        class Teacherformation
        {
            private Schedule schedule;
            public Teacherformation(ref Schedule sch)
            {
                schedule = sch;
            }
            public (Subject, Teacher)[] GetScheduleInformation(DateTime dateTime, int Grade) { return schedule.GetSchedule(dateTime, Grade); }
            public (Teacher, int Grade)[] GetScheduleInformation(DateTime dateTime, Subject subject) { return schedule.GetSchedule(dateTime, subject); }
            public (Subject, int Grade)[] GetScheduleInformation(DateTime dateTime, Teacher teacher) { return schedule.GetSchedule(dateTime, teacher); }
        }
        class Teacher
        {
            string Name;
            Subject TeachSubject;
            public Teacherformation teacherformation;
            public Teacher(ref Teacherformation refInfo)
            {
                teacherformation = refInfo;
            }
        }
        class School
        {
            const int DaysInYear = 365;
            const int MaxGrade = 11;
            const int MaxTeachers = 20;
            const int MaxClassess = MaxGrade;

            static Schedule schedule;

            private Teacher[] _Teacher;
            private Pupils[,] _Pupils;
            private Classes[] _Classes;

            public PupilsInformation pupilsInformation;
            public Teacherformation teacherformation;

            public School()
            {
             schedule = new Schedule(DaysInYear, MaxGrade);

                _Teacher = new Teacher[MaxTeachers];
                _Pupils = new Pupils[MaxGrade, 0];
                _Classes = new Classes[MaxClassess];

                pupilsInformation = new PupilsInformation(ref schedule);
                teacherformation = new Teacherformation(ref schedule);

                updateTeachersSchedule();
            }

            void updateTeachersSchedule()
            {
                for (int i = 0; i < _Teacher.Length; i++)
                {
                    _Teacher[i] = new Teacher(ref teacherformation);
                }
            }
            public void ShowTeasherInformation()
            {
                DateTime dateTime = DateTime.Now;
                _Teacher[0].teacherformation.GetScheduleInformation(dateTime, 1);
            }
        }
        static void Main(string[] args)
        {
            Console.WriteLine("\r\n a.tkachenko/homework/11-Encapsulation \r\n");

            School school = new School();

        }
    }
}
