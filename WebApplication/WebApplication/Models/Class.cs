namespace WebApplication.Models
{
    public class MarriageCertificate
    {
        public int Id { get; set; }
        public User User1 { get; set; }
        public User User2 { get; set; }

        public DateTime DateOfMarriage { get; set; }

    }
}
