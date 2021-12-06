using System;
using System.Text;

namespace ConsoleApp
{
    // i.safontev/classwork/11-encapsulation
    public class User
    {
        public string UserName { get; set; }
        private string Password { get; set; }
        public long ID { get; set; }//set- init
        private string Email { get; set; }
        public byte[] Avatar { get; set; }
        public User[] Followers { get; set; }

    }

    public class Feed
    {
        public Post[] Posts { get; set; }
        public User Owner { get; set; }

    }

    public class Post
    {
        public User User { get; set; }
        public long ID { get; set; }
        public DateTime CreatedAt { get; set; }
        public byte[] Content { get; set; }
        public string Description { get; set; }
        public Comment[] Comment { get; set; }

    }

    public class Comment
    {
        public User Author{ get; set; }
        public DateTime CreatedAt { get; set; }
        public string Content { get; set; }

    }

    public class Updatable
    {
        public int TimesUpdated { get; private set; }
        int _fieldA;
        string _fieldB;

        public int FieldA 
        {
            get
            {
                return _fieldA;
            }
            set
            {
                ++TimesUpdated;
                _fieldA = value;
            } 
        }
        public string FieldB
        {
            get
            {
                return _fieldB;
            }
            set
            {
                ++TimesUpdated;
                _fieldB = value;
            }
        }
        public void ShowValues() => Console.WriteLine($"Updatable has next values{GetFieldA()}; {GetFieldB()}; {GetTimesUpdated()};");
        string GetFieldA() => $"{nameof(FieldA)} = {FieldA}"; 
        string GetFieldB() => $"{nameof(FieldB)} = {FieldB}";
        string GetTimesUpdated() => $"{nameof(TimesUpdated)} = {TimesUpdated}";

    }

    class Program//internal by default
    {
        static void Main(string[] args)
        {
            Updatable obj=new Updatable
            {
                FieldA = 1,
                FieldB = "a",
            };
            obj.FieldA = 2;
            obj.FieldB = "b";

            obj.ShowValues();
            
        }
    }
}
