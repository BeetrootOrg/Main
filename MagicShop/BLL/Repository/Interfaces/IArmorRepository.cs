using DLL.Entites.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.Repository.Interfaces
{
    public interface IArmorRepository
    {
        List<Armor> GetAll();
        Armor GetById(int id);
        void Create(Armor model);
    }
}
