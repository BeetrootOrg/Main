using AutoMapper;
using BLL.Repository.Interfaces;
using BLL.Services.Interfaces;
using DLL.Entites.Base;
using Microsoft.Extensions.Caching.Memory;
using Shared.Models.Base;

namespace BLL.Services.Implementation
{
    public class CrudService<TEntity, TModel> : ICrudService<TEntity, TModel>
        where TEntity : BaseEntity
        where TModel : BaseEntityModel
    {
        private readonly IGenericRepository<TEntity> _repository;
        private readonly IMapper _maper;
        private IMemoryCache _memoryCache;

        public CrudService(IGenericRepository<TEntity> repository, IMapper maper, IMemoryCache memoryCache)
        {
            _repository = repository;
            _maper = maper;
            _memoryCache = memoryCache;
        }
        public virtual async Task<List<TModel>> GetAll()
        {
            var entities = await _repository.GetAll();
            return _maper.Map<List<TModel>>(entities);
        }

        public virtual async Task<TModel> GetById(int id)
        {
            var entity = await _repository.Get(id);
            if (entity != null)
            {
                _memoryCache.Set(id,entity,
                new MemoryCacheEntryOptions().SetAbsoluteExpiration(TimeSpan.FromMinutes(5)));
            }
            return _maper.Map<TModel>(entity);
        }
        public virtual async Task<TModel> Create(TEntity entity)
        {
            await _repository.Create(entity);
            _memoryCache.Set(entity.Id, entity, new MemoryCacheEntryOptions
            {
                AbsoluteExpirationRelativeToNow = TimeSpan.FromMinutes(5)
            });
            return _maper.Map<TModel>(entity);
        }

        public virtual async Task<TModel> Edit(TEntity entity)
        {
            await _repository.Edit(entity);
            return _maper.Map<TModel>(entity);
        }

        public virtual async Task Delete(int id)
        {
            await _repository.Delete(id);
        }

    }
}
