namespace Program
{
    using System.Collections.Generic;
    using System.Globalization;

    public static class Program
    {
        public static void Main()
        {

        }
    }

    public class User
    {
        public int Id { get; set; }
        public string UserName { get; set; }
        private string Password { get; set; }
        private string Email { get; set; }
        public string Avatar { get; set; }
        public List<Post> Posts { get; set; }
        public List<User> Followers { get; set; }
    }

    public class Post
    {
        public User User { get; set; }
        public int Id { get; set; }
        public string CreatedAt { get; set; }

        public string Header { get; set; }
        public string Content { get; set; }
        public string Context { get; set; }
        public List<Comment> Comments { get; set; }
    }

    public class Comment
    {
        public Post Post { get; set; }
        public User Author { get; set; }
        public string Content { get; set; }
    }

    public class Feed
    {
        public List<Post> Posts { get; set;}
        public User Owner { get; set; }
    }
}