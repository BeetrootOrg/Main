using DLL.Entites.Base;

namespace BLL.Repository.Interfaces
{
    public interface IWeaponRepository
    {
        Task<List<BaseWeapon>> GetAllWeapons();
        
    }
}
