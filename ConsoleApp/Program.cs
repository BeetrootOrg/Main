namespace ConsoleApp
{
    using System;

    class ConsoleApp
    {
        enum ShopName
        {
            CarShop,
            ATBShop,
            TavriaShop
        }
        class Product
        {
            public int ID { get; set; }
            public string Name { get; set; }
            public string Category { get; set; }
            public string Description { get; set; }
            public int Price { get; set; }
            public int Quantity { get; set; }
            public Product(int id, string name, string category, string description, int price, int quantity)
            {
                this.ID = id;
                this.Name = name;
                this.Category = category;
                this.Description = description;
                this.Price = price;
                this.Quantity = quantity;
            }
        }
        class Cart
        {
            public int ID { get; set; }
            public Product product { get; set; }
            public int TotalPrice;
        }
        interface IProduct
        {
            void AddProduct(int ID, string name, string Category, string Description, int Price, int quantity);
            public void EditProduct(ref Product product, int id, string name, string category, string description, int price, int quantity);
            bool DeleteProduct(ref Product product, int ID);
        }
        interface IProductShow
        {
            void ShowProduct();
        }
        class Admin : IProduct, IProductShow
        {
            private int ID;
            private string Name;
            private Product [] _product;
            public Admin(int id, string name)
            {
                this.ID = id;
                this.Name = name;
            }
            public void InitProductDateBase(Product [] prduct)
            {
                _product = prduct;
            }
            public void AddProduct(int id, string name, string category, string description, int price, int quantity)
            {
                _product[id] = new Product(id, name, category, description, price, quantity);
            }

            public void EditProduct(ref Product product, int id, string name, string category, string description, int price, int quantity)
            {
                product.ID = id;
                product.Name = name;
                product.Category = category;
                product.Description = description;
                product.Price = price;
            }

            public bool DeleteProduct(ref Product product, int ID)
            {
                return true;
            }

            public void ShowProduct()
            {
                Console.WriteLine("Show Data:");
                for (int i = 0; i < _product.Length; i++)
                {
                    if (_product[i] != null)
                    {
                        Console.Write("Id: {0}, ", _product[i].ID);
                        Console.Write("Name: {0}, ", _product[i].Name);
                        Console.Write("Category: {0}, ", _product[i].Category);
                        Console.Write("Description: {0}, ", _product[i].Description);
                        Console.Write("Price: {0}, ", _product[i].Price);
                        Console.Write("Quantity: {0}\r\n", _product[i].Quantity);
                    }
                }
            }
        }
        class Buyer : IProductShow
        {
            public int id;
            public string name { get; set; }
            public string address { get; set; }
            public Cart cart;
            public Buyer(int id, string name, string address)
            {
                this.id = id;
                this.name = name;
                this.address = address;
            }
            public void ShowProduct() 
            {
                Console.Write("Show Buyers Cart:");
                if (cart.product != null)
                {
                    Console.Write("\r\n");
                    Console.Write("Id: {0}, ", cart.product.ID);
                    Console.Write("Name: {0}, ", cart.product.Name);
                    Console.Write("Category: {0}, ", cart.product.Category);
                    Console.Write("Description: {0}, ", cart.product.Description);
                    Console.Write("Price: {0}, ", cart.product.Price);
                    Console.Write("Quantity: {0}, ", cart.product.Quantity);
                    Console.Write("TotalPrice: {0}\r\n", cart.TotalPrice);
                }
                else
                {
                    Console.Write(" - Cart is empty\r\n");
                }
            }
            public Cart AddProductToCart(Product product, int quantity) 
            {
                cart = new Cart();
                cart.ID = 0;
                cart.product = product;
                cart.product.Quantity = quantity;
                cart.TotalPrice = product.Price * quantity;
                return cart;
            }
            public void DeleteProductFromCart() 
            {
                cart.product = null;
            }

        }
        abstract class InternetShopFactory
        {
            public abstract InternetShop CreateInternetShopFactory(ShopName Name);
            public abstract ShopName GetName();
            public abstract void ConnectToDB(Product[] db);
            public abstract Product[] GetDataBaseObject();
            public abstract void EditDB(Product[] db);
        }
        abstract class InternetShop : InternetShopFactory
        {
            public override InternetShop CreateInternetShopFactory(ShopName Name)
            {
                Console.WriteLine("Run \"{0}\"", Name);
                switch (Name)
                {
                    case ShopName.CarShop:
                        return new CarShop(Name);
                    case ShopName.ATBShop:
                        return new ATBShop(Name);
                    default:
                        throw new ArgumentException(" Error: Shop could not be created!");
                }
            }
        }
        class CarShop : InternetShop
        {
            private ShopName Name;
            private Product[] DataBase;
            public CarShop(ShopName Name)
            {
                if (Name == ShopName.CarShop)
                {
                    this.Name = Name;
                }
                else
                {
                    throw new ArgumentException("Need connect to \"CarDateBase\"");
                }
            }
            public override ShopName GetName()
            {
                return Name;
            }
            public override void ConnectToDB(Product[] db)
            {
                DataBase = db;
            }
            public override Product[] GetDataBaseObject()
            {
                return DataBase;
            }
            public override void EditDB(Product[] db)
            {

            }
        }
        class ATBShop : InternetShop
        {
            private ShopName Name;
            private Product[] DataBase;
            public ATBShop(ShopName Name)
            {
                if (Name == ShopName.ATBShop)
                {
                    this.Name = Name;
                }
                else
                {
                    throw new ArgumentException("Need connect to \"ATBDateBase\"");
                }
            }
            public override ShopName GetName()
            {
                return Name;
            }
            public override void ConnectToDB(Product[] db)
            {
                DataBase = db;
            }
            public override Product[] GetDataBaseObject()
            {
                return DataBase;
            }
            public override void EditDB(Product[] db)
            {

            }
        }
        enum DeliveryStatus
        {
            Initial = 0,
            InProgress = 1,
            Succes = 2
        }
        class Delivery
        {
            private string _serviceName;
            private string _address;
            public DeliveryStatus Status { get; set; }
            public Delivery(string name, string addr)
            {
                Status = DeliveryStatus.Initial;
               _serviceName = name;
               _address = addr;
            }
            public DeliveryStatus CheckStatus()
            {
                int rInt;
                do
                {
                    Random r = new Random((int)DateTime.Now.Ticks);
                    rInt = r.Next(0, 3);
                }while((DeliveryStatus)rInt != DeliveryStatus.Succes);

                return DeliveryStatus.Succes;
            }
        }
        class Receipt : IProductShow
        {
            public DateTime date { get; set; }
            public Buyer buyer { get; set; }
            public DeliveryStatus Status { get; set; }

            public void ShowProduct()
            {
                Console.Write("Show Buyers Receipt:");
                if (buyer.cart.product != null)
                {
                    Console.Write("\r\n");
                    Console.Write("DateTime: {0}, ", date);
                    Console.Write("Buyer: {0}, ", buyer.name);
                    Console.Write("Address: {0}, ", buyer.address);
                    Console.Write("Id: {0}, ", buyer.cart.product.ID);
                    Console.Write("Name: {0}, ", buyer.cart.product.Name);
                    Console.Write("Category: {0}, ", buyer.cart.product.Category);
                    Console.Write("Price: {0}, ", buyer.cart.product.Price);
                    Console.Write("Quantity: {0}, ", buyer.cart.product.Quantity);
                    Console.Write("TotalPrice: {0}\r\n", buyer.cart.TotalPrice);
                }
                else
                {
                    Console.Write(" - Cart is empty\r\n");
                }
            }
        }
        class Shop
        {
            private InternetShopFactory _carFactory;
            public Admin Admin { get; set; }
            private const int _maximumNumberOfBuyers = 10;
            private Buyer[] _buyers;
            private Receipt[] _receipts;
            Delivery [] _delivery;
            public Shop(InternetShopFactory factory)
            {
                Admin = null;
                _carFactory = factory.CreateInternetShopFactory(factory.GetName());
                _buyers = new Buyer[_maximumNumberOfBuyers];
                _delivery = new Delivery[_maximumNumberOfBuyers];
                _receipts = new Receipt[_maximumNumberOfBuyers];
            }
            public void RunConnectToDB(Product[] db)
            {
                _carFactory.ConnectToDB(db);
            }
            public void AddAdmin(Admin admin)
            {
                if(Admin == null)
                {
                    Admin = admin;
                }
                else
                {
                    throw (new ArgumentException("Shop already has Admin"));
                }
            }
            public bool EnablePermissionForAdmin(Admin admin)
            {
                if (Admin == admin)
                {
                    Admin.InitProductDateBase(_carFactory.GetDataBaseObject());
                    return true;
                }
                return false;
            }
            public void ShowData(Product [] product)
            {

            }
            public Buyer AddNewBuyer(string name, string address)
            {
                for (int i = 0; i < _maximumNumberOfBuyers; i++)
                {
                    if (_buyers[i] == null)
                    {
                        _buyers[i] = new Buyer(i, name, address);
                        _delivery[i] = new Delivery(name, address);
                        _delivery[i].Status = DeliveryStatus.Initial;
                        return _buyers[i];
                    }
                }
                throw (new Exception("Сan't add new user"));
            }
            public void DeleteBuyer(int i)
            {
                if (i < _buyers.Length)
                {
                    _buyers[i] = null;
                }
                else
                {
                    throw (new Exception("Wrong Buyer ID!"));
                }
            }
            public void BuyerAddNewItemToCart(int id, Product product, int quantity)
            {
                if (id < _buyers.Length)
                {
                    _receipts[id] = new Receipt();
                    _receipts[id].date = DateTime.Now;
                    _receipts[id].buyer = _buyers[id];
                    _receipts[id].buyer.cart = _buyers[id].AddProductToCart(product, quantity);
                    _receipts[id].Status = DeliveryStatus.Initial;
                }
                else
                {
                    throw (new Exception("Wrong Buyer ID!"));
                }
            }
            public void BuyersShowCart(int id)
            {
                if (id < _buyers.Length)
                {
                    _buyers[id].ShowProduct();
                }
                else
                {
                    throw (new Exception("Wrong Buyer ID!"));
                }
            }
            public void BuyersShowReceipt(int id)
            {
                if (id < _receipts.Length)
                {
                    _receipts[id].ShowProduct();
                }
                else
                {
                    throw (new Exception("Wrong Buyer ID!"));
                }
            }
            public void SendItemToBuyer(int id)
            {
                if (id < _buyers.Length)
                {
                    Console.WriteLine("Send Item to Buyer...");
                    _delivery[id].Status = DeliveryStatus.InProgress;
                }
                else
                {
                    throw (new Exception("Wrong Buyer ID!"));
                }
            }
            public DeliveryStatus CheckDeliveryStatus(int id)
            {
                if (id < _buyers.Length)
                {
                    Console.WriteLine("Delivery status: {0}", _delivery[id].Status);
                    return _delivery[id].Status;
                }
                else
                {
                    throw (new Exception("Wrong Buyer ID!"));
                }
            }
            public DeliveryStatus WaitDeliveryAndCheckStatus(int id)
            {
                if (id < _buyers.Length)
                {
                    Console.WriteLine("Delivery status: {0}", _delivery[id].Status);
                    _delivery[id].Status = _delivery[id].CheckStatus();
                    Console.WriteLine("Delivery status: {0}", _delivery[id].Status);
                    return _delivery[id].Status;
                }
                else
                {
                    throw (new Exception("Wrong Buyer ID!"));
                }
            }
            public void BuyerDeleteCart(int id)
            {
                if (id < _buyers.Length)
                {
                    _buyers[id].DeleteProductFromCart();
                }
                else
                {
                    throw (new Exception("Wrong Buyer ID!"));
                }
            }
        }
        static void Main(string[] args)
        {
            Console.WriteLine("\r\n a.tkachenko/homework/14-InternetShop \r\n");

            Product[] SomeDatabase = new Product[3];
            Admin ShopAdmin;
            Buyer buyer;
            try
            {
                Console.WriteLine("\r\n Car Shop:");
                InternetShopFactory MyCarInternetShop = new CarShop(ShopName.CarShop);
                Shop ShopService = new Shop(MyCarInternetShop);
                ShopService.RunConnectToDB(SomeDatabase);
                ShopAdmin = new Admin(0, "admin");
                ShopService.AddAdmin(ShopAdmin);
                ShopService.EnablePermissionForAdmin(ShopAdmin);
                ShopService.Admin.AddProduct(0, "Ford", "Car", "good car", 10000 ,1);
                ShopService.Admin.AddProduct(1, "Opel", "Car", "good car", 11000, 2);
                ShopService.Admin.AddProduct(2, "Renault", "Car", "good car", 12000, 3);
                ShopService.Admin.ShowProduct();
                buyer = ShopService.AddNewBuyer("Petya", "Lviv");
                ShopService.BuyerAddNewItemToCart(buyer.id, SomeDatabase[0], 1);
                ShopService.BuyersShowCart(buyer.id);
                ShopService.BuyersShowReceipt(buyer.id);
                ShopService.CheckDeliveryStatus(buyer.id);
                ShopService.SendItemToBuyer(buyer.id);
                ShopService.WaitDeliveryAndCheckStatus(buyer.id);

                Console.WriteLine("\r\n ATB Shop:");
                Product[] ATBeDatabase = new Product[3];
                InternetShopFactory MyATBInternetShop = new ATBShop(ShopName.ATBShop);
                ShopService = new Shop(MyATBInternetShop);
                ShopService.RunConnectToDB(ATBeDatabase);
                ShopAdmin = new Admin(0, "admin");
                ShopService.AddAdmin(ShopAdmin);
                ShopService.EnablePermissionForAdmin(ShopAdmin);
                ShopService.Admin.AddProduct(0, "Milk", "Milk poduct", "2%", 30, 100);
                ShopService.Admin.AddProduct(1, "Yogurt", "Milk poduct", "3%", 40, 200);
                ShopService.Admin.AddProduct(2, "Bread", "Bread product", "Borodinsky", 50, 300);
                ShopService.Admin.ShowProduct();
                buyer = ShopService.AddNewBuyer("Petya", "Lviv");
                ShopService.BuyerAddNewItemToCart(buyer.id, ATBeDatabase[0], 5);
                ShopService.BuyersShowCart(buyer.id);
                ShopService.BuyersShowReceipt(buyer.id);
                ShopService.CheckDeliveryStatus(buyer.id);
                ShopService.SendItemToBuyer(buyer.id);
                ShopService.WaitDeliveryAndCheckStatus(buyer.id);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }
    }
}
