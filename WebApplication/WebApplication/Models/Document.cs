using System.ComponentModel.DataAnnotations;

namespace WebApplication.Models
{
    public class Document
    {
        private static int _id;

        public int Id {
            get=> _id;
            set=> ++_id;
        }

        public string Title { get; set; }

        [DataType(DataType.Date)]
        public DateTime DateOfCreation { get; init; }

        public User Plaintiff { get; set; }

        public User Defendant { get; set; }

        public Court Court { get; set; }

    }
}
