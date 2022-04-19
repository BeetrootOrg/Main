using Shared.Models.Base;

namespace BLL.Services.Interfaces
{
    public interface ICrudService<TEntity, TModel>
        where TModel : BaseEntityModel
    {
        Task<List<TModel>> GetAll();
        Task<TModel> GetById(int id);
        Task<TModel> Create(TEntity entity);
        Task<TModel> Edit(TEntity entity);
        Task Delete(int id);
    }
}
