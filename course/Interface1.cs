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
        void MakeOrder();
        void WriteComment();
        void EditComment();
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
    }

    internal interface IAdmin : IUser
    {
        void CreateProduct();
        void DeleteProduct();
        void BanUser();
    }
}
