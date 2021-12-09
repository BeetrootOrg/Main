using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp11HomeworkEncapsulation
{
    public class Teacher: PersonBaseClass
    {
        private Class _class { get; set; }
        public Teacher(string firstName, string lastName, Class @class) : base(firstName, lastName)
        {
            _class = @class;
        }
        public void GetClassInfo() => throw new NotImplementedException();

    }
}
