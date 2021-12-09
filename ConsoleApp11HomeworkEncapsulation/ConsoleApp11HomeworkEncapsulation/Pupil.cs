using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp11HomeworkEncapsulation
{
    public class Pupil: PersonBaseClass
    {
        private Group _group { get; set; }
        public Pupil(string firstName, string lastName, Group group):base(firstName, lastName)
        {
            _group = group;
        }

        public void GetGroupInfo()=> throw new NotImplementedException();
    }
}
