using DiplomaProject.Backend.Common.Models.Entity;

namespace DiplomaProject.Backend.DataLayer.Repositories.Interfaces
{
    public interface IOrderRepository : IGenericRepository<Order>
    {
        Task<Order> FindByIdAsync(Guid id);
        Task<Order> FindByDateAndTimeAsync(DateOnly date, TimeOnly time);
    }
}
