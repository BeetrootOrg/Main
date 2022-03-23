using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.Services.Interfaces
{
    public interface ICrudService<TEntity, TModel>
    {
        Task<List<TModel>> GetAll();
        Task<TModel> GetById(int id);
    }
}
