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
        public long Id { get; init; }
        public string Email { get; set; }
        public byte[] Avatar { get; set; }
        public User[] Followers { get; set; }
    }

    public class Post
    {
        public User User { get; set; }
        public long Id { get; init; }
        public DateTime CreatedAt { get; set; }
        public byte[] Content { get; set; }
        public string Description { get; set; }
        public Comment[] Comment { get; set; }
    }

    public class Feed
    {
        public Post[] Posts { get; set; }
        public User Owner { get; set; }
    }

    public class Updatable
    {
        private int _fieldA;
        private int _fieldB;
        public int FieldA
        {
            get
            {
                return _fieldA;
            }
            set
            {
                ++TimeUpdated;
                _fieldA = value;
            }

        }
        public string FieldB { get; set; }
        public int TimeUpdated { get; private set; }
    }

    public class Program
    {
        static void Main()
        {
            
        }           
    }
}