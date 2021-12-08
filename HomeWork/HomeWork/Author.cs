using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HomeWork
{
    public class Author
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Contact { get; set; }
        public int ID { get; set; }

        public void AddBook()
        {

        }

        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();
            sb.Append(FirstName);
            sb.Append(';');
            sb.Append(LastName);
            sb.Append(';');
            sb.Append(Contact);
            return sb.ToString();
        }

    }
}
