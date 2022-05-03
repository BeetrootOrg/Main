using AutoMapper;
using BLL.Repository.Interfaces;
using BLL.Services.Interfaces;
using DLL.Entites.Base;
using Shared.Models.Base;

namespace BLL.Services.Implementation
{
    public class CrudService<TEntity, TModel> : ICrudService<TEntity, TModel>
        where TEntity : BaseEntity
        where TModel : BaseEntityModel
    {
        private readonly IGenericRepository<TEntity> _repository;
        private readonly IMapper _maper;

        public CrudService(IGenericRepository<TEntity> repository, IMapper maper)
        {
            _repository = repository;
            _maper = maper;
        }
        public virtual async Task<List<TModel>> GetAll()
        {
            var entities = await _repository.GetAll();
            return _maper.Map<List<TModel>>(entities);
        }

        public virtual async Task<TModel> GetById(int id)
        {
            var entity = await _repository.Get(id);
            return _maper.Map<TModel>(entity);
        }
        public virtual async Task<TModel> Create(TEntity entity)
        {
            await _repository.Create(entity);
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
