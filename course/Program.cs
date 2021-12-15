using ICourse;

namespace Course
{
    class User : IUser
    {
        private Order[] _orders;

        public int Id { get; init; }

        public string Name { get; set; }
        public Order[] Orders { get => _orders; }

        public void EditComment()
        {
            throw new NotImplementedException();
        }

        public void MakeOrder()
        {
            throw new NotImplementedException();
        }

        public void WriteComment()
        {
            throw new NotImplementedException();
        }
    }

    class Admin : IAdmin
    {
        private Order[] _orders;

        public int Id { get; init; }

        public string Name { get; set; }
        public Order[] Orders { get => _orders; }

        public void BanUser()
        {
            throw new NotImplementedException();
        }

        public void CreateProduct()
        {
            throw new NotImplementedException();
        }

        public void DeleteProduct()
        {
            throw new NotImplementedException();
        }

        public void EditComment()
        {
            throw new NotImplementedException();
        }

        public void MakeOrder()
        {
            throw new NotImplementedException();
        }

        public void WriteComment()
        {
            throw new NotImplementedException();
        }
    }

    class Order : IOrder
    {
        public int Id { get; init; }
        public User MadeBy { get; init; }
        public Item[] Items { get; init; }
    }

    class Item : IItem
    {
        public int Id { get; set; }

        public string Name { get; set; }
        public double Price { get; set; }
    }

    class OnlineShop
    {
        public int Id { get; init; }
        private User[] Users { get; set; }
        private Order[] Orders { get; set; }
        private Admin[] Admins { get; set; }
    }
}
