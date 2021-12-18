using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleAppHomework13Interfaces.Interfaces
{
    public interface ICheck
    {
        public int Id { get; set; }
        public IClient Client { get; set; }
        public List<IProduct> Products { get; set; }
        public int Sum { get; set; }
        public DateTime Date { get; set; }
    }
}
