using DiplomaProject.Backend.Common.Models.Entity;

namespace DiplomaProject.Backend.DataLayer.Repositories.Interfaces
{
    public interface IServiceRepository : IGenericRepository<Service>
    {
        Task<Service> FindByIdAsync(Guid id);
        Task<Service> FindByNameAsync(string name);
    }
}
