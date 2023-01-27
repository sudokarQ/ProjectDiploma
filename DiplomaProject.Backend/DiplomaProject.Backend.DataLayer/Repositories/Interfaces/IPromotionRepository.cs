using DiplomaProject.Backend.Common.Models.Entity;

namespace DiplomaProject.Backend.DataLayer.Repositories.Interfaces
{
    public interface IPromotionRepository : IGenericRepository<Promotion>
    {
        Task<Promotion> FindByIdAsync(Guid id);
        Task<Promotion> FindByNameAsync(string name);
    }
}
