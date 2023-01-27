using DiplomaProject.Backend.Common.Models.Entity;

namespace DiplomaProject.Backend.DataLayer.Repositories.Interfaces
{
    public interface IShopRepository : IGenericRepository<Shop>
    {
        Task<Shop> FindByIdAsync(Guid id);
        Task<Shop> FindByNameAsync(string name);
    }
}
