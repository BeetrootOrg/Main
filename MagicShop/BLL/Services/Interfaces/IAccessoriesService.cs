using DLL.Entites;

namespace BLL.Services.Interfaces
{
    public interface IAccessoriesService
    {
        List<Accessories> GetAll();
        Accessories GetById(int id);
        void Create(Accessories model);
        void Edit(Accessories updated);
        void Delete(int id);
    }
}
