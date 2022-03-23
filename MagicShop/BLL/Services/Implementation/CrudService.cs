using AutoMapper;
using BLL.Repository.Interfaces;
using BLL.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.Services.Implementation
{
    public class CrudService<TEntity, TModel> : ICrudService<TEntity, TModel>
    {
        private readonly IGenericRepository<TEntity> _repository;
        private readonly IMapper _maper;
        public CrudService(IGenericRepository<TEntity> repository, IMapper maper)
        {
            _repository = repository;
            _maper = maper;
        }
        public async Task<List<TModel>> GetAll()
        {
            var entities = await _repository.GetAll();
            return _maper.Map<List<TModel>>(entities);
        }

        public async Task<TModel> GetById(int id)
        {
            var entity = await _repository.Get(id);
            return _maper.Map<TModel>(entity);
        }
    }
}
