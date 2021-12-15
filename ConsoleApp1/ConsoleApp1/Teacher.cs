using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1
{
    public class Teacher : People
    {
        public TeacherSchedule Schedule { get; set; }
        public Class Class { get; set; }
        public bool IsCurator { get; set; }
        public string Subject { get; set; }
    }
}
