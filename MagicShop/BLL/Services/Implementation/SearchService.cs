using BLL.Repository.Interfaces;
using BLL.Services.Interfaces;
using DLL.Entites;
using DLL.Entites.Base;
using Shared.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.Services.Implementation
{
    public class SearchService : ISearchService
    {
        private readonly IGenericRepository<Armor> _armorRepo;
        private readonly IGenericRepository<Accessories> _accessoriesRepo;
        private readonly IGenericRepository<MagicWeapon> _magicWeaponRepo;
        private readonly IGenericRepository<RangeWeapon> _rangeWeaponRepo;
        private readonly IGenericRepository<MeleeWeapon> _meleeWeaponRepo;


        public SearchService(IGenericRepository<Armor> armorRepos, IGenericRepository<Accessories> accessoriesRepos,
            IGenericRepository<MagicWeapon> magicWeaponRepos, IGenericRepository<RangeWeapon> rangeWeaponRepos,
            IGenericRepository<MeleeWeapon> meleeWeaponRepos)
        {
            _armorRepo = armorRepos;
            _accessoriesRepo = accessoriesRepos;
            _magicWeaponRepo = magicWeaponRepos;
            _rangeWeaponRepo = rangeWeaponRepos;
            _meleeWeaponRepo = meleeWeaponRepos;
        }

        public async Task<List<BaseEntity>> Search(string request)
        {
            var res = new List<BaseEntity>();
            var filter1 = (await _armorRepo.GetAll()).Where(x => x.Name.Contains(request));
            var filter2 = (await _accessoriesRepo.GetAll()).Where(x => x.Name.Contains(request));
            var filter3 = (await _magicWeaponRepo.GetAll()).Where(x => x.Name.Contains(request));
            var filter4 = (await _rangeWeaponRepo.GetAll()).Where(x => x.Name.Contains(request));
            var filter5 = (await _meleeWeaponRepo.GetAll()).Where(x => x.Name.Contains(request));

            res = res.Concat(filter1.Cast<BaseEntity>()).ToList();
            res = res.Concat(filter2.Cast<BaseEntity>()).ToList();
            res = res.Concat(filter3.Cast<BaseEntity>()).ToList();
            res = res.Concat(filter4.Cast<BaseEntity>()).ToList();
            res = res.Concat(filter5.Cast<BaseEntity>()).ToList();

            return res;
        }
       
    }
}
