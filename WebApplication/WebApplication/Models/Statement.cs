using System;
using System.ComponentModel.DataAnnotations;

namespace WebApplication.Models
{
    public class StatementKind
    {
        public int Id { get; set; }
        public string Type { get; set; }
        public string Name { get; set; }
    }
    public class Statement
    {
        public int Id { get; init; }
        public string Title { get; set; }

        [DataType(DataType.Date)]
        public DateTime DateOfCreation { get; init; }
        public User Plaintiff { get; set; }
        public User Defendant { get; set; }
        public Court Court { get; set; }
        public StatementKind StatementKind { get; set; }
    }
}
