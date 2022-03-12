using BLL.Repository.Interfaces;
using DLL.Context;
using DLL.Entites.Base;

namespace BLL.Repository.Implementation
{
    public class ArmorRepository : IArmorRepository
    {
        private readonly ArmoryDbContext _armoryDbContext;

        public ArmorRepository(ArmoryDbContext armoryDbContext)
        {
            _armoryDbContext = armoryDbContext;
        }
        public List<Armor> GetAll()
        {
            return _armoryDbContext.Armor.ToList();
            
        }
        public Armor GetById(int id)
        {
            return _armoryDbContext.Armor.FirstOrDefault(x => x.Id == id);
        }

        public void Create(Armor model)
        {
            _armoryDbContext.Armor.Add(model);
            _armoryDbContext.SaveChanges();
        }
        public void Edit(Armor updated)
        {
            _armoryDbContext.Armor.Update(updated);
            _armoryDbContext.SaveChanges();
        }
        public void Delete(int id)
        {
            Armor a = _armoryDbContext.Armor.FirstOrDefault(x => x.Id == id);
            if (a != null)
            {
                _armoryDbContext.Armor.Remove(a);
                _armoryDbContext.SaveChanges();
            }
        }
    }
}
