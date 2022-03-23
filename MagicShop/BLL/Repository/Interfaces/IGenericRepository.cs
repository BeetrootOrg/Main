namespace BLL.Repository.Interfaces
{
    public interface IGenericRepository<T> 
    {
        Task<List<T>> GetAll();
        Task<T> Get(int id);
    }
}
