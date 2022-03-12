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
        public Armor GetById(int id)
        {
            return _armorRepository.GetById(id);
        }

        public void Create(Armor model)
        {
            _armorRepository.Create(model);
        }
        public void Edit(Armor updated)
        {
            _armorRepository.Edit(updated);

        }
        public void Delete(int id)
        {
            _armorRepository.Delete(id);
        }
    }
}
