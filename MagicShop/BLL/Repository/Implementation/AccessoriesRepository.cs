﻿using BLL.Repository.Interfaces;
using DLL.Context;
using DLL.Entites;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.Repository.Implementation
{
    public class AccessoriesRepository : IAccessoriesRepository
    {
        private readonly ArmoryDbContext _armoryDbContext;
        public AccessoriesRepository(ArmoryDbContext armoryDbContext)
        {
            _armoryDbContext = armoryDbContext;
        }
        public List<Accessories> GetAll()
        {
            return _armoryDbContext.Accessories.ToList();
        }

        public Accessories GetById(int id)
        {
            return _armoryDbContext.Accessories.FirstOrDefault(x => x.Id == id);
        }
        public void Create(Accessories model)
        {
            _armoryDbContext.Accessories.Add(model);
            _armoryDbContext.SaveChanges();
        }
    }
}
