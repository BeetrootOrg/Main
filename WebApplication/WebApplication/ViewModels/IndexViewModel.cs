using WebApplication.Models;
using System.Collections.Generic;

namespace WebApplication.ViewModels
{
    public class IndexViewModel
    {
        public IEnumerable<User> Users { get; set; }
        public IEnumerable<Court> Courts { get; set; }
        public IEnumerable<StatementKind> StatementKinds { get; set; }
    }
}
