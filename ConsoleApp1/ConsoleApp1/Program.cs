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

    #region Menu
    public static class Menu
    {
        public static void Login()
        {

        }

        public static void MainMenu()
        {

        }

        public static void OrderMenu()
        {

        }

        public static void CustomerDetails()
        {

        }

        public static void GetBill()
        {

        }
    }

    #endregion

    #region FileInterFaces

    public class FileIO
    {
        public FileIO(ref Shop shop, bool init)
        {
            if (!init)
            {
                List<string> prdList = new List<string>();
                foreach(var prd in shop.Products)
                {
                    StringBuilder sb = new StringBuilder();
                    sb.Append(prd.Code);
                    sb.Append(';');
                    sb.Append(prd.Name);
                    sb.Append(';');
                    sb.Append(prd.Price);
                    prdList.Add(sb.ToString());
                }
                List<string> cartProducts = new List<string>();
                List<string> receipt = new List<string>();
                List<string> customers = new List<string>();
                foreach (var cust in shop.Customers)
                {
                    foreach(var rec in cust.Receipts)
                    {
                        foreach(CartProduct prd in rec.Basket)
                        {
                            StringBuilder sb = new StringBuilder();
                            sb.Append(prd.OrderID);
                            sb.Append(';');
                            sb.Append(prd.Code);
                            sb.Append(';');
                            sb.Append(prd.Name);
                            sb.Append(';');
                            sb.Append(prd.Price);
                            sb.Append(';');
                            sb.Append(prd.Quantity);
                            cartProducts.Add(sb.ToString());
                        }
                        StringBuilder sb2 = new StringBuilder();
                        sb2.Append(rec.ID);
                        sb2.Append(';');
                        sb2.Append(rec.CustomerID);
                        sb2.Append(';');
                        sb2.Append(rec.Status);
                        receipt.Add(sb2.ToString());
                    }
                    StringBuilder sb3 = new StringBuilder();
                    sb3.Append(cust.CustomerID);
                    sb3.Append(';');
                    sb3.Append(cust.Name);
                    sb3.Append(';');
                    sb3.Append(cust.LastName);
                    customers.Add(sb3.ToString());
                    
                }
                File.WriteAllLines("orDetail.csv",prdList.ToArray());
                File.WriteAllLines("orders.csv", receipt.ToArray());
                File.WriteAllLines("customer.csv",customers.ToArray());
            }
        }
        public void OperateProducts(ref Shop shop, bool init)
        {
            if (init)
            {
                var content = File.ReadAllLines("products.csv");
                foreach(var item in content)
                {
                    var line = item.Split(';');
                    Product product = new Product();
                    product.Code = line[0];
                    product.Name = line[1];
                    product.Price = (float)Convert.ToDouble(line[2]);
                }
            }
        }

        public void OperateOrders(ref Shop shop, bool init)
        {
            if (init)
            {
                var content2 = File.ReadAllLines("orDetail.csv");
                List<CartProduct> cartProducts = new List<CartProduct>();
                foreach(var item in content2)
                {
                    var line = item.Split(';');
                    CartProduct product = new CartProduct();
                    product.OrderID = Convert.ToInt32(line[0]);
                    product.Code = line[1];
                    product.Name = line[2];
                    product.Price= (float)Convert.ToDouble(line[3]);
                    product.Quantity = (float)Convert.ToDouble(line[4]);
                }
                var content = File.ReadAllLines("orders.csv");
                foreach (var item in content)
                {
                    var line = item.Split(';');
                    Receipt receipt = new Receipt();
                    receipt.ID = Convert.ToInt32(line[0]);
                    receipt.CustomerID = Convert.ToInt32(line[1]);
                    receipt.Status = line[2];
                    List<CartProduct> carts = new List<CartProduct>();
                    foreach(var cp in cartProducts)
                    {
                        if(cp.OrderID == receipt.ID)
                        {
                            carts.Add(cp);
                        }
                    }
                    receipt.Basket = carts.ToArray();
                }
            }
        }

        public void OperateCustomers(ref Shop shop, bool init)
        {

        }
    }

    #endregion

    #region abstract Bill

    public abstract class Bill
    {
        public virtual int ID { get; set; }
        public virtual int CustomerID { get; set; }
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
        public int OrderID { get; set; }
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
        public int CustomerID { get; set; }
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

