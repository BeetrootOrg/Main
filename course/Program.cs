using ICourse;
namespace Course
{
    class User : IUser
    {
        private Order[] _orders;
        private Comment[] _comments;

        public int Id { get; init; }

        public string Name { get; set; }
        public Order[] Orders { get => _orders; }

        public bool Banned { get; set; }

        public virtual void GetComments(Comment[] data)
        {
            _comments = data;
        }

        public virtual void EditComment(string commentText)
        {
            var curComment = Array.Find(_comments, comment => comment.WrittenBy == this);
            if (curComment != null)
            {
                curComment.CommentText = commentText;
            }
            else
            {
                throw new ArgumentOutOfRangeException("No comment was found");
            }
        }

        public virtual void MakeOrder(Order orderToCreate)
        {
            Array.Resize(ref _orders, _orders.Length + 1);
            _orders[_orders.Length - 1] = orderToCreate;
        }

        public void WriteComment(Item itemToAdd, string commentText)
        {
            itemToAdd.AddComment(commentText, this);
        }
    }

    class Comment
    {
        private int Id;
        public User WrittenBy { get; init; }
        public Item WrittenIn { get; init; }
        public string CommentText { get; set; }
    }

    class Admin : IAdmin
    {
        private Order[] _orders;
        private OnlineShop _onlineShop;

        public int Id { get; init; }

        public string Name { get; set; }
        public Order[] Orders { get => _orders; }
        public bool Banned { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }

        public void BanUser(User userToBan)
        {
            userToBan.Banned = true;
        }

        public void CreateProduct(string productName, double productPrice)
        {
            var item = new Item
            {
                Name = productName,
                Price = productPrice,
            };
            _onlineShop.AddProduct(item);
        }

        public void DeleteProduct(Item itemToDelete)
        {
            _onlineShop.DeleteItem(itemToDelete);
        }

        public void EditComment(string Text)
        {
            throw new NotImplementedException();
        }

        public void MakeOrder(Order orderToCreate)
        {
            throw new NotImplementedException();
        }

        public void WriteComment(Item itemToAdd, string commentText)
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
        private Comment[] _comments;
        public int Id { get; set; }

        public string Name { get; set; }
        public double Price { get; set; }
        public Comment[] Comments { get => _comments; }

        public void AddComment(string commentText, User writtenBy)
        {
            Array.Resize(ref _comments, _comments.Length + 1);
            _comments[_comments.Length - 1] = new Comment
            {
                WrittenBy = writtenBy,
                WrittenIn = this,
                CommentText = commentText
            };
        }
    }

    class OnlineShop
    {
        private Item[] _items;
        public int Id { get; init; }
        private User[] Users { get; set; }
        public void GetUsers(User[] data)
        {
            Users = data;
        }
        private Order[] Orders { get; set; }
        public void GetOrders(Order[] data)
        {
            Orders = data;
        }
        private Admin[] Admins { get; set; }
        public void GetAdmins(Admin[] data)
        {
            Admins = data;
        }
        public Item[] Items { get => _items; }

        public void AddProduct (Item itemToAdd)
        {
            Array.Resize(ref _items, _items.Length + 1);
            _items[_items.Length - 1] = itemToAdd;
        }
        public void DeleteItem (Item itemToDelete)
        {
            _items = Array.FindAll(_items, item => item.Id != itemToDelete.Id).ToArray();
        }
    }
}
