using DiplomaProject.Backend.Common.Models.Entity;

namespace DiplomaProject.Backend.DataLayer.Repositories.Interfaces
{
    public interface IClientRepository : IGenericRepository<Client>
    {
        Task<Client> FindByNameAsync(string name);
    }
}
