namespace BLL.Repository.Interfaces
{
    public interface IGenericRepository<TEntity> 
    {
        Task<List<TEntity>> GetAll();
        Task<TEntity> Get(int id);
        Task<TEntity> Create(TEntity entities);
        Task Edit(TEntity entities);
        Task Delete(int id);
    }
}
