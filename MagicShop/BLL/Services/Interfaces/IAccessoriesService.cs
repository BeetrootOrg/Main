using DLL.Entites;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.Services.Interfaces
{
    public interface IAccessoriesService
    {
        List<Accessories> GetAll();
        Accessories GetById(int id);
        void Create(Accessories model);
        void Edit(Accessories updated);
        void Delete(int id);
    }
}
