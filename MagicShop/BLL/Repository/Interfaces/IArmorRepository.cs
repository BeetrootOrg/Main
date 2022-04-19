using DLL.Entites.Base;

namespace BLL.Repository.Interfaces
{
    public interface IArmorRepository
    {
        List<Armor> GetAll();
        Armor GetById(int id);
        void Create(Armor model);
        void Edit(Armor updated);
        void Delete(int id);
    }
}
