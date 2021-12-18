using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Console
{
    #region Interfaces
    public interface IBuyer
    {       
        string Name { get; }
        string LastName { get; }
    }

    public interface ICreateBasket
    {
        public void CreateBasket();
    }


    public interface IUpdateBasket
    {
        public void UpdateBasket();
    }

    public interface iAddProduct
    {
        public void AddProduct(IProduct product);
    }

    public interface IProduct
    {
        public string Name { get; set; }
        public string Code { get; set; }
        public float Price { get; set; }
    }

    public interface iCartProduct : IProduct
    {
        public float Quantity { get; set; }
        public float Amount { get; }
    }
    #endregion
}
