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
            public Product(int id, string name, string category, string description, int price)
            {
                this.ID = id;
                this.Name = name;
                this.Category = category;
                this.Description = description;
                this.Price = price;
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
            void AddProduct(int ID, string name, string Category, string Description, int Price);
            public void EditProduct(ref Product product, int id, string name, string category, string description, int price);
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
            public void AddProduct(int id, string name, string category, string description, int price)
            {
                _product[id] = new Product(id, name, category, description, price);
            }

            public void EditProduct(ref Product product, int id, string name, string category, string description, int price)
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
                        Console.Write("Price: {0}\r\n", _product[i].Price);
                    }
                }
            }
        }
        class Buyer : IProductShow
        {
            public int id;
            private string _name;
            private string _address;
            private Cart _cart;
            public Buyer(int id, string name, string address)
            {
                this.id = id;
                this._name = name;
                this._address = address;
            }
            public void ShowProduct() 
            {
                Console.Write("Show Buyers Cart:");
                if (_cart.product != null)
                {
                    Console.Write("\r\n");
                    Console.Write("Id: {0}, ", _cart.product.ID);
                    Console.Write("Name: {0}, ", _cart.product.Name);
                    Console.Write("Category: {0}, ", _cart.product.Category);
                    Console.Write("Description: {0}, ", _cart.product.Description);
                    Console.Write("Price: {0}\r\n", _cart.product.Price);
                }
                else
                {
                    Console.Write(" - Cart is empty\r\n");
                }
            }
            public void AddProductToCart(Product product) 
            {
                _cart = new Cart();
                _cart.ID = 0;
                _cart.product = product;
                _cart.TotalPrice = product.Price;
            }
            public void DeleteProductFromCart() 
            {
                _cart.product = null;
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
        class Shop
        {
            private InternetShopFactory _carFactory;
            public Admin Admin { get; set; }
            private const int _maximumNumberOfBuyers = 10;
            private Buyer[] _buyers;
            Delivery [] _delivery;
            public Shop(InternetShopFactory factory)
            {
                Admin = null;
                _carFactory = factory.CreateInternetShopFactory(factory.GetName());
                _buyers = new Buyer[_maximumNumberOfBuyers];
                _delivery = new Delivery[_maximumNumberOfBuyers];
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
            public void BuyerAddNewItemToCart(int id, Product product)
            {
                if (id < _buyers.Length)
                {
                    _buyers[id].AddProductToCart(product);
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
            Console.WriteLine("\r\n a.tkachenko/homework/13-InternetShop \r\n");

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
                ShopService.Admin.AddProduct(0, "Ford", "Car", "good car", 10000);
                ShopService.Admin.AddProduct(1, "Opel", "Car", "good car", 11000);
                ShopService.Admin.AddProduct(2, "Renault", "Car", "good car", 12000);
                ShopService.Admin.ShowProduct();
                buyer = ShopService.AddNewBuyer("Petya", "Lviv");
                ShopService.BuyerAddNewItemToCart(buyer.id, SomeDatabase[0]);
                ShopService.BuyersShowCart(buyer.id);
                ShopService.CheckDeliveryStatus(buyer.id);
                ShopService.SendItemToBuyer(buyer.id);
                ShopService.WaitDeliveryAndCheckStatus(buyer.id);
                ShopService.BuyerDeleteCart(buyer.id);
                ShopService.BuyersShowCart(buyer.id);
                ShopService.DeleteBuyer(buyer.id);
                buyer = null;

                Console.WriteLine("\r\n ATB Shop:");
                Product[] ATBeDatabase = new Product[3];
                InternetShopFactory MyATBInternetShop = new ATBShop(ShopName.ATBShop);
                ShopService = new Shop(MyATBInternetShop);
                ShopService.RunConnectToDB(ATBeDatabase);
                ShopAdmin = new Admin(0, "admin");
                ShopService.AddAdmin(ShopAdmin);
                ShopService.EnablePermissionForAdmin(ShopAdmin);
                ShopService.Admin.AddProduct(0, "Milk", "Milk poduct", "2%", 30);
                ShopService.Admin.AddProduct(1, "Yogurt", "Milk poduct", "3%", 40);
                ShopService.Admin.AddProduct(2, "Bread", "Bread product", "Borodinsky", 50);
                ShopService.Admin.ShowProduct();
                buyer = ShopService.AddNewBuyer("Petya", "Lviv");
                ShopService.BuyerAddNewItemToCart(buyer.id, ATBeDatabase[0]);
                ShopService.BuyersShowCart(buyer.id);
                ShopService.CheckDeliveryStatus(buyer.id);
                ShopService.SendItemToBuyer(buyer.id);
                ShopService.WaitDeliveryAndCheckStatus(buyer.id);
                ShopService.BuyerDeleteCart(buyer.id);
                ShopService.BuyersShowCart(buyer.id);
                ShopService.DeleteBuyer(buyer.id);
                buyer = null;

            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }
    }
}
