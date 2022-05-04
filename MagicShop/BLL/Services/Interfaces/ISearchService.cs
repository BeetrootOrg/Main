using DLL.Entites.Base;

namespace BLL.Services.Interfaces
{
    public interface ISearchService
    {
        Task<List<BaseEntity>> Search(string request);
    }
}
