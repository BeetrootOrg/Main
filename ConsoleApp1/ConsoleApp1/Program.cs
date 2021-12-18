namespace Console
{
    using System;
    using System.Collections.Generic;
    using System.Collections;
    using System.IO;
    using System.Text;
    class Program
    {
        
        static void Main()
        {           
           
  
        }  


    }

    #region abstract Bill

    public abstract class Bill
    {
        public virtual float TotalAmount { get; set; }
        public virtual iCartProduct[] Basket { get; set; } 

        public virtual Customer Customer { get; set; }

    }

    #endregion

    #region ProductClasses
    public class Product : IProduct
    {
        public string Name { get; set; }
        public string Code { get; set; }
        public float Price { get; set; }
    }

    public class CartProduct : iCartProduct
    {
        public float Quantity { get; set; }

        public float Amount { get { return Price * Quantity; } }

        public string Name { get; set; }
        public string Code { get; set; }
        public float Price { get; set; }
    }

    #endregion

    #region Shop and Cart
    public class Shop : ICreateBasket
    {
        public Product[] Products { get; set; }
        public Customer[] Customers { get; set; }
        public Cart[] Carts { get; set; }
        public int CurrentCustomer { get; set; }
        public void CreateBasket()
        {
            var cart = new Cart(ref Customers[CurrentCustomer]);
            var tmp = Carts;
            var ind = Carts.Length;
            Array.Resize(ref tmp, ind + 1);
            cart.Basket = Array.Empty<CartProduct>();
            tmp[ind] = cart;
            Carts = tmp;
        }

        public void CreateCustomer(Customer customer)
        {
            
            var tmp = Customers;
            var ind = Customers.Length;
            Array.Resize(ref tmp, ind + 1);
            tmp[ind] = customer;
            Customers = tmp;
        }

        public void CreateProduct(Product product)
        {            
            var tmp = Products;
            var ind = Products.Length;
            Array.Resize(ref tmp, ind + 1);
            tmp[ind] = product;
            Products = tmp;
        }
    }

    public class Cart : Bill , iAddProduct
    {
        public Cart(ref Customer buyer)
        {
            this.Customer = buyer;
        }
        public void AddProduct(IProduct product)
        {
            if (Basket.Length > 0 || Basket != null)
            {
                int stat = 0;
                foreach (var item in Basket)
                {
                    if(item.Code == product.Code)
                    {
                        item.Quantity++;
                        stat = 1;
                        break;
                    }
                }
                if(stat == 0)
                {
                    var tmp = Basket;
                    var ind = Basket.Length;
                    Array.Resize(ref tmp, ind + 1);
                    var cartPrd = (CartProduct)product;
                    cartPrd.Quantity = 1;
                    tmp[ind] = cartPrd;
                }

            }
        }

        public void Order()
        {
            var tmp = Customer.Receipts;
            var ind = Customer.Receipts.Length;
            Array.Resize(ref tmp, ind + 1);
            var rec = this;            
            tmp[ind] = (Receipt)(Bill)rec;
            tmp[ind].Status = "A";
            Customer.Receipts = tmp;
        }

        public void Cancell()
        {
            var tmp = Customer.Receipts;
            var ind = Customer.Receipts.Length;
            Array.Resize(ref tmp, ind + 1);
            var rec = this;
            tmp[ind] = (Receipt)(Bill)rec;
            tmp[ind].Status = "C";
            Customer.Receipts = tmp;
        }
    }

    #endregion

    #region Customer and receipts

    public class Customer : IBuyer
    {   
        public string Name { get; init; }

        public string LastName { get; init; }

        public Receipt[] Receipts { get; set; }

        public void ShowAllReceipts()
        {
            foreach (var receipt in Receipts)
            {
                Console.WriteLine($"{receipt.Customer};{receipt.Status};{receipt.TotalAmount}");
            }
        }
    }

    public class Receipt : Bill
    {
        public string Status { get; set; }
    }

    #endregion
}

