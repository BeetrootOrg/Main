using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp11HomeworkEncapsulation
{
    public class PersonBaseClass
    {
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public PersonBaseClass(string firstName, string lastName)
        {
            FirstName = firstName;
            LastName = lastName;
        }

        public void GetNameInfo()=> throw new NotImplementedException();
    }
}
