using BLL.Repository.Interfaces;
using BLL.Services.Interfaces;
using DLL.Context;
using DLL.Entites;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
    }
}
