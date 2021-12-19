using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Course;

namespace ICourse
{
    internal interface IUser
    {
        int Id { get; }
        string Name { get; set; }
        Order[] Orders { get; }
        bool Banned { get; set; }
        void MakeOrder(Order orderToCreate);
        void WriteComment(Item itemToAdd, string commentText);
        void EditComment(string Text);
    }

    internal interface IOrder
    {
        int Id { get; }
        User MadeBy { get; init; }
        Item[] Items { get; init; }
    }

    internal interface IItem
    {
        int Id { get; }
        string Name { get; set; }
        double Price { get; set; }
        Comment[] Comments { get; }
        void AddComment(string commentText, User writtenBy);
    }

    internal interface IAdmin : IUser
    {
        void CreateProduct(string productName, double productPrice);
        void DeleteProduct(Item itemToDelete);
        void BanUser(User userToBan);
    }
}
