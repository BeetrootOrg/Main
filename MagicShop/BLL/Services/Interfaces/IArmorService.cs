using DLL.Entites.Base;

namespace BLL.Services.Interfaces
{
    public interface IArmorService
    {
        List<Armor> GetAll();
        Armor GetById(int id);
        void Create(Armor model);
        void Edit(Armor updated);
        void Delete(int id);
    }
}
