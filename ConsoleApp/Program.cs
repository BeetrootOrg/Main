using System;

namespace ConsoleApp
{
    public class Comment
    {
        public User Author { get; set; }
        public DateTime CreatedAt { get; set; }
        public string Content { get; set; }
    }

    public class User
    {
        public string UserName { get; set; }
        private string Password { get; set; }
        public int Id { get; init; }

        private string Email { get; set; }

        public byte[] Avatar { get; set; }

        public User[] Followers { get; set; }

    }

    public class Post
    {
        public User User { get; set; }
        public long Id { get; init; }
        public DateTime CreatedAt { get; set; }
        public string Description { get; set; }
        public byte[] Content { get; set; }
    }

    public class Feed
    { 
        public Post[] Posts { get; set; }
        public User Owner { get; set; } 
     }

    public class Updatable
    {
        private int _fieldA;
        private string _fieldB;

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
        public int TimesUpdated { get; private set; }

        public void ShowValues() => Console.WriteLine($"Updatable has next values: {GetFieldA()}; {GetFieldB()}; {GetUpdated()}");

        private string GetFieldA() => $"{nameof(FieldA)} = {FieldA}";
        private string GetFieldB() => $"{nameof(FieldB)} = {FieldB}";
        private string GetUpdated() => $"{nameof(TimesUpdated)} = {TimesUpdated}";

    }

    class Program
    {
        static void Main()
        {
            var obj = new Updatable
            {
                FieldA = 42,
                FieldB = "42"
            };

            obj.FieldA = 43;
            obj.FieldB = "45";

            obj.ShowValues();
        }
    }
}