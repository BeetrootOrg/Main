using BLL.Repository.Interfaces;
using DLL.Context;
using DLL.Entites.Base;
using Microsoft.EntityFrameworkCore;

namespace BLL.Repository.Implementation
{
    public class GenericRepository<TEntity> : IGenericRepository<TEntity>
        where TEntity : BaseEntity
    {
        private readonly ArmoryDbContext _dbContext;
        private readonly DbSet<TEntity> _set;
        public GenericRepository(ArmoryDbContext dbContext)
        {
            _dbContext = dbContext;
            _set = _dbContext.Set<TEntity>();
        }

        public async  Task<List<TEntity>> GetAll()
        {
            return await _set.ToListAsync<TEntity>();

        }
        public async Task<TEntity> Get(int id)
        {
            return await _set.FirstAsync(x => x.Id == id);
        }
        public async Task Create(TEntity entities)
        {
           await _set.AddAsync(entities);
           await _dbContext.SaveChangesAsync();
        }
        public async Task Edit(TEntity entity)
        {
            TEntity existing = await Get(entity.Id);
            if (existing != null)
            {   
                _dbContext.Entry(existing).CurrentValues.SetValues(entity);
                await _dbContext.SaveChangesAsync();
            }
        }
        public async Task Delete(int id)
        {
             TEntity entityDel = await _set.FirstAsync(x => x.Id == id);
            if (entityDel != null)
            {
                _dbContext.Remove(entityDel);
                await _dbContext.SaveChangesAsync();
            }
        }
    }
}
