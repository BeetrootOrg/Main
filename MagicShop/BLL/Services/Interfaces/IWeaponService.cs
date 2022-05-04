using Shared.Models.Base;

namespace BLL.Services.Interfaces
{
    public interface IWeaponService 
    {
        Task<List<BaseWeaponModel>> GetAllWeapons();
    }
}
