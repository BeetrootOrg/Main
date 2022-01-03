namespace ConsoleApp
{
    public class Shop
    {
        public Product[] ProductsList { get; set; }
        public User[] UsersList { get; set; }
    }

    public class Product
    {
        public string SKU { get; set; }
        public string Name { get; set; }
        public double Price { get; set; }
        public string Weight { get; set; }
        public string Color { get; set; }
        public Category ProductCategory { get; set; }

    }

    public class Category
    {
        public string CategoryName { get; set; }
        public string[] CategoryProperties { get; set; }
    }

    public class User
    {

    }
    public class Receipts
    {

    }

    public interface IAddProducts
    {

    }

    class Program
    {
        static void Main()
        {
        }
    }
}