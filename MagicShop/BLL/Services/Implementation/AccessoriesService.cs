using BLL.Repository.Interfaces;
using BLL.Services.Interfaces;
using DLL.Entites;

namespace BLL.Services.Implementation
{
    public class AccessoriesService : IAccessoriesService
    {
        private IAccessoriesRepository _accessoriesRepository;
        public AccessoriesService(IAccessoriesRepository accessoriesRepository)
        {
            _accessoriesRepository = accessoriesRepository;
        }
        public List<Accessories> GetAll()
        {
            return _accessoriesRepository.GetAll();
        }

        public Accessories GetById(int id)
        {
            return _accessoriesRepository.GetById(id);
        }
        public void Create(Accessories model)
        {
            _accessoriesRepository.Create(model);
        }
        public void Edit(Accessories updated)
        {
            _accessoriesRepository.Edit(updated);

        }
        public void Delete(int id)
        {
            _accessoriesRepository.Delete(id);
        }
    }
}
