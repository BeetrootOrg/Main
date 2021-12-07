using System;
using System.IO;

namespace ConsoleApp
{

    public class School
    {
        //If it`s a name of cabbinet "string" if as a room "object?"
        // Have no "set" because we can`t change Gym and Director as a room
        public string ClassRoom { get;}
        public string Gym { get; }
        public string Corridors { get; }
        public string Canteen { get; }
        public string DirectorCabinet { get;}
        public string TeacherRoom { get;}


    }

    public class Inventory
    {
        public object SchoolDesks { get; set; }
        public object Board { get; set; }
        public object Chalk { get; set; }
        public object AttendanceLog { get; set; } //класный журнал

    }

    public class Director
    {
        private int Payment { get; set; }
        public string Qualification { get; set; }
        public int DateTime { get; init; }
        public string Sex { get; set; } // not sure about "set". We have very strange time for now)))

    }

    public class Teacher
    {
        private int Payment { get; set; }
        public string SubjectOfStudy { get; set; }
        public string Responsobility { get; set; }
        public string DateTime { get; init; }
        public string Sex { get; init; }

    }

    public class Student
    {
        private string KnowledgeLVL { get; set; }
        public string Responsobility { get; set; }
        public int Class { get; set; } 
        public int DateTime { get; init; }
        public string Sex { get; init; }
        public string Backpack { get; set; } // description
    }

    public class Backpack 
    {
        //not sure about "public and private" if its stuff of Student it shold be all public but then everyone can use it?
        public string TextBooks { get; set; }
        public string NoteBooks { get; set; }
        public int Pens { get; set; } //amount of
        public string Food { get; set; } //type of
        private string Wallet { get; set; } //deskription. If we talk about amount of money in it will be "int"
        private string Pistol { get; set; }
        public string MobilePhone { get; set; }
        private string Drugs { get; set; }
        
    }
    class Program
    {        
        static void Main()
        {
            
            
        }

        
    }
}