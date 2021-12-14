using ConsoleAppHomework13Interfaces.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleAppHomework13Interfaces
{
    public class InternetShop : IInternetShop
    {
        private List<IProduct> _products { get; set; }
        private List<IClient> _clients { get; set; }
        private List<ICheck> _checks { get; set; }
        private decimal _balance { get; set; }



        public Check AddCheck()
        {
            throw new NotImplementedException();
        }

        public Client AddClient()
        {
            throw new NotImplementedException();
        }

        public Product AddProduct()
        {
            throw new NotImplementedException();
        }

        public Check GetCheck()
        {
            throw new NotImplementedException();
        }

        public Client GetClient()
        {
            throw new NotImplementedException();
        }

        public Product GetProduct()
        {
            throw new NotImplementedException();
        }
    }
}
