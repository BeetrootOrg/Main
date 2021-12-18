using ConsoleAppHomework13Interfaces.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleAppHomework13Interfaces
{
    public class Check: ICheck
    {
        public int Id { get; set; }
        public IClient Client { get; set; }
        public List<IProduct> Products { get; set; }
        public DateTime Date { get; set; }

        public int Sum { get; set; }



        public Check(IClient client, List<IProduct> products, DateTime date, int sum)
        {
            Client = client;
            Products = products;
            Date = date;
            Sum = sum;
        }

    }
}
