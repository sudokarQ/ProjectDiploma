using DiplomaProject.Backend.Common.Models.Dto.Order;
using DiplomaProject.Backend.Common.Models.Entity;

namespace DiplomaProject.Backend.BuisnessLayer.InterfacesAndServices.Interfaces
{
    public interface IOrderService
    {
        Task<List<OrderPostDto>> GetAsync(Func<OrderPostDto, bool> predicate);
        Task CreateAsync(OrderPostDto shop);
        Task RemoveAsync(Guid id);
        Task UpdateAsync(OrderPostDto item);
        Task<List<OrderPostDto>> GetAllAsync();
        Task<OrderPostDto> FindByIdAsync(Guid id);
    }
}
