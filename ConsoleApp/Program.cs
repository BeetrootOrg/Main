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
            public DateTime dateTime;
            public Subject subject;
            public string Teacher;

            public Lesson (DateTime dt, Subject sbj, string teacher)
            {
                dateTime = dt;
                subject = sbj;
                Teacher = teacher;
            }
        }
        class Schedule
        {
            private int _MaxGrade;
            private int _DaysInYear;
            private Lesson[,] _Lessons;
            private Classes [] _ClassRoom;

            public Schedule()
            {
                _Lessons = new Lesson[365, 11];
                _ClassRoom = new Classes[11];
            }
            public Schedule (int daysInYear, int maxGrade, int classRooms)
            {
                _DaysInYear = daysInYear;
                _MaxGrade = maxGrade;
                _Lessons = new Lesson[_DaysInYear,_MaxGrade];
                _ClassRoom = new Classes[classRooms];
            }

            private int GetDay(ref DateTime dateTime) { return 0; }
            private Classes GetClassRoom(DateTime dateTime, Subject subject) { return null; }
            private Classes GetClassRoom(DateTime dateTime, int Grade) { return null; }
            private Classes GetClassRoom(DateTime dateTime, Teacher teacher) { return null; }

            public void UpdateSchedule(DateTime dateTime, int grade, Subject subject, string teacherName, int roomID) 
            { 
                _Lessons[GetDay(ref dateTime), grade] = new Lesson(dateTime, subject, teacherName);
                _ClassRoom[grade].RoomID = roomID;
            }
            
            public (Teacher, int Grade, Classes) GetPupilsSchedule(DateTime dateTime, Subject subject) { return (null, 0, GetClassRoom(dateTime, subject)); }
            public (Subject, int Grade, Classes) GetPupilsSchedule(DateTime dateTime, Teacher teacher) { return (0, 0, GetClassRoom(dateTime, teacher)); }
            public (Subject, Teacher, Classes) GetPupilsSchedule(DateTime dateTime, int Grade) { return (0,null, GetClassRoom(dateTime, Grade)); }

            public (Teacher, int Grade, Classes) GetTeacherSchedule(DateTime dateTime, Subject subject) { return (null, 0, GetClassRoom(dateTime, subject)); }
            public (Subject, int Grade, Classes) GetTeacherSchedule(DateTime dateTime, Teacher teacher) { return (0, 0, GetClassRoom(dateTime, teacher)); }
            public (Subject, Teacher, Classes) GetTeacherSchedule(DateTime dateTime, int Grade) { return (0,null, GetClassRoom(dateTime, Grade)); }
        }
        class Classes
        {
            public int RoomID  { get; set; }
        }
        class PupilsInformation
        {
            private Schedule schedule;
            public PupilsInformation(ref Schedule sch)
            {
                schedule = sch;
            }
            public (Teacher, int Grade, Classes) GetScheduleInformation(DateTime dateTime, Subject subject) { return schedule.GetPupilsSchedule(dateTime, subject); }
            public (Subject, int Grade, Classes) GetScheduleInformation(DateTime dateTime, Teacher teacher) { return schedule.GetPupilsSchedule(dateTime, teacher); }
            public (Subject, Teacher, Classes) GetScheduleInformation(DateTime dateTime, int Grade) { return schedule.GetPupilsSchedule(dateTime, Grade); }
        }
        class Pupils
        {
            string Name;
            Subject[] subject;
            private PupilsInformation Information;

            public Pupils(ref PupilsInformation info)
            {
                Information = info;
            }
            public void AddNewName(string name)
            {
                Name = name;
            }
            public void InitNumOfSubject(int maxSubjects)
            {
                subject = new Subject[maxSubjects];
            }
            public void AddNewSubject(int id, Subject sb)
            {
                subject[id] = sb;
            }
            public (Teacher, int Grade, Classes) GetScheduleInformation(DateTime dateTime, Subject subject) { return Information.GetScheduleInformation(dateTime, subject); }
            public (Subject, int Grade, Classes) GetScheduleInformation(DateTime dateTime, Teacher teacher) { return Information.GetScheduleInformation(dateTime, teacher); }
            public (Subject, Teacher, Classes) GetScheduleInformation(DateTime dateTime, int Grade) { return Information.GetScheduleInformation(dateTime, Grade); }
        }
        class Teacherformation
        {
            private Schedule schedule;
            public Teacherformation(ref Schedule sch)
            {
                schedule = sch;
            }

            public (Subject, Teacher, Classes) GetScheduleInformation(DateTime dateTime, int Grade) { return schedule.GetTeacherSchedule(dateTime, Grade); }
            public (Teacher, int Grade, Classes) GetScheduleInformation(DateTime dateTime, Subject subject) { return schedule.GetTeacherSchedule(dateTime, subject); }
            public (Subject, int Grade, Classes) GetScheduleInformation(DateTime dateTime, Teacher teacher) { return schedule.GetTeacherSchedule(dateTime, teacher); }

        }
        class Teacher
        {
            int ID;
            string Name;
            Subject TeachSubject;
            private Teacherformation teacherformation;
            public Teacher(ref Teacherformation refInfo)
            {
                teacherformation = refInfo;
            }
            public (Subject, Teacher, Classes) GetTeacherformation(DateTime dateTime, int Grade) { return teacherformation.GetScheduleInformation(dateTime, Grade); }
            public (Teacher, int Grade, Classes) GetTeacherformation(DateTime dateTime, Subject subject) { return teacherformation.GetScheduleInformation(dateTime, subject); }
            public (Subject, int Grade, Classes) GetTeacherformation(DateTime dateTime, Teacher teacher) { return teacherformation.GetScheduleInformation(dateTime, teacher); }
            public void AddNewName(string name)
            {
                Name = name;
            }
            public void UpdateIDe(int id)
            {
                ID = id;
            }
            public void UpdateTeachSubject(Subject sb)
            {
                TeachSubject = sb;
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
                 schedule = new Schedule(DaysInYear, MaxGrade, MaxClassess);

                _Teacher = new Teacher[MaxTeachers];
                _Pupils = new Pupils[MaxGrade, 1];
                _Classes = new Classes[MaxClassess];

                pupilsInformation = new PupilsInformation(ref schedule);
                teacherformation = new Teacherformation(ref schedule);

                InitTeachersSchedule();
                InitPupilsSchedule();
            }

            private void InitTeachersSchedule()
            {
                for (int i = 0; i < _Teacher.Length; i++)
                {
                    _Teacher[i] = new Teacher(ref teacherformation);
                }
            }
            private void InitPupilsSchedule()
            {
                for (int i = 0; i < MaxGrade; i++)
                {
                   _Pupils[i,0] = new Pupils(ref pupilsInformation);
                }
            }
            public void AddNewTecher(int id, string name)
            {
                _Teacher[id].AddNewName(name);
            }
            public void AddNewPupils(int grade, int id, string name)
            {
                _Pupils[grade, id] = new Pupils(ref pupilsInformation);
                _Pupils[grade,id].AddNewName(name);
            }
            public void InitMaxSubjectForPupil(int grade, int id, int max)
            {
                _Pupils[grade, id].InitNumOfSubject(max);
            }
            public void AddNewSubjectForPupil(int grade, int id, int SubjectId, Subject sb)
            {
                _Pupils[grade, id].AddNewSubject(SubjectId, sb);
            }
            public void ShowTeasherInformation()
            {
                _Teacher[0].GetTeacherformation(DateTime.Now, 1);
            }
            public void ShowPupilsInformation()
            {
                _Pupils[0,0].GetScheduleInformation(DateTime.Now, 1);
            }
        }
        static void Main(string[] args)
        {
            Console.WriteLine("\r\n a.tkachenko/homework/11-Encapsulation \r\n");

            School school = new School();
            school.AddNewTecher(0,"Maria Ivanovna");

            school.AddNewPupils(0, 0, "Ivan Petrov");
            school.InitMaxSubjectForPupil(0, 0, 10);
            school.AddNewSubjectForPupil(0, 0, 0, Subject.Literature);

            school.ShowTeasherInformation();
            school.ShowPupilsInformation();
        }
    }
}
