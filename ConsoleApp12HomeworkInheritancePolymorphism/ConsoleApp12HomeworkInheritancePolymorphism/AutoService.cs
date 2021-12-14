using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp12HomeworkInheritancePolymorphism
{
    public class AutoService
    {
        public List<Vehicle> Vehicles { get; set; }
        public List<Client> Clients { get; set; }
        public List<Order> Orders { get; set; }
        public decimal Balance { get; set; }


        public Client AddClient() => throw new NotImplementedException();
        public Vehicle AddVehicle() => throw new NotImplementedException();
        public Order AddOrder() => throw new NotImplementedException();
        public void PrintCheck() => throw new NotImplementedException();
        public Client GetClient(int id) => throw new NotImplementedException();
        public Vehicle GetVehicle(int id) => throw new NotImplementedException();
        public Order GetOrder(int id) => throw new NotImplementedException();

    }
}
