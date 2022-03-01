using BLL.Repository.Interfaces;
using BLL.Services.Interfaces;
using DLL.Entites.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.Services.Implementation
{
    public class ArmorService : IArmorService
    {
        private IArmorRepository _armorRepository;

        public ArmorService(IArmorRepository armorRepository)
        {
            _armorRepository = armorRepository;
        }
        public List<Armor> GetAll()
        {
            return _armorRepository.GetAll();
        }
    }
}
