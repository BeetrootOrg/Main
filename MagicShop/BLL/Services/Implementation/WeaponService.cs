using AutoMapper;
using BLL.Repository.Interfaces;
using BLL.Services.Interfaces;
using Shared.Models.Base;

namespace BLL.Services.Implementation
{
    public class WeaponService : IWeaponService
    {
        private IWeaponRepository _weaponRepository;
        private readonly IMapper _mapper;

        public WeaponService(IWeaponRepository weaponRepository, IMapper mapper)
        {
            _weaponRepository = weaponRepository;
            _mapper = mapper;
        }
        public async Task<List<BaseWeaponModel>> GetAllWeapons()
        {
            return _mapper.Map<List<BaseWeaponModel>>(await _weaponRepository.GetAllWeapons());

        }
    }
}
