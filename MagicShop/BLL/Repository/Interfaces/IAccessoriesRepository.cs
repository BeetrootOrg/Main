using DLL.Entites;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.Repository.Interfaces
{
    public interface IAccessoriesRepository
    {
        List<Accessories> GetAll();
        Accessories GetById(int id);
        void Create(Accessories model);

    }
}
