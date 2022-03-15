namespace WebApplication.Models
{
    public class NewDocument
    {
        public string Id { get; set; }
        public string Title { get; set; }
        public DateTime DateOfCreation { get; set; }

        public User User1 { get; set; }

        public User User2 { get; set; }

        public string Court { get; set; }

        //public Document {get;set;}
    }
}
