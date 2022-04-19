using DLL.Entites;

namespace BLL.Repository.Interfaces
{
    public interface IAccessoriesRepository
    {
        List<Accessories> GetAll();
        Accessories GetById(int id);
        void Create(Accessories model);
        void Edit(Accessories updated);
        void Delete(int id);
    }
}
