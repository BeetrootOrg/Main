using System;
using System.Collections.Generic;
using ConsoleApp.Models.Domain;

namespace ConsoleApp.Tests;

internal class UserEqualityComparer : IEqualityComparer<User>
{
    public bool Equals(User x, User y)
    {
        if (ReferenceEquals(x, y)) return true;
        if (ReferenceEquals(x, null)) return false;
        if (ReferenceEquals(y, null)) return false;
        if (x.GetType() != y.GetType()) return false;
        return x.RealName == y.RealName && 
               x.Name == y.Name && 
               x.IsAdmin == y.IsAdmin && 
               x.IsOwner == y.IsOwner && 
               x.IsBot == y.IsBot && 
               x.IsAppUser == y.IsAppUser && 
               x.IsPrimaryOwner == y.IsPrimaryOwner;
    }

    public int GetHashCode(User obj)
    {
        return HashCode.Combine(obj.RealName, obj.Name, obj.IsAdmin, obj.IsOwner, obj.IsBot, obj.IsAppUser, obj.IsPrimaryOwner);
    }
}