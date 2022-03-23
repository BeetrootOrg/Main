using BLL.Repository.Interfaces;
using DLL.Context;
using DLL.Entites.Base;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.Repository.Implementation
{
    public class GenericRepository<T> : IGenericRepository<T>
        where T : BaseEntity
    {
        private readonly ArmoryDbContext _dbContext;
        private readonly DbSet<T> _set;
        public GenericRepository(ArmoryDbContext dbContext)
        {
            _dbContext = dbContext;
            _set = _dbContext.Set<T>();
        }

        public async  Task<List<T>> GetAll()
        {
            return await _set.ToListAsync<T>();

        }
        public async Task<T> Get(int id)
        {
            return await _set.FirstAsync(x => x.Id == id);
        }

    }
}
