using DiplomaProject.Backend.Common.Models.Entity;

namespace DiplomaProject.Backend.DataLayer.Repositories.Interfaces
{
    public interface IUserRepository : IGenericRepository<User>
    {
        Task<User> FindByIdAsync(Guid id);
        Task<User> FindByLoginAsync(string login);
    }
}
