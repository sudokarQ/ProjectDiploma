using DiplomaProject.Backend.Common.Models.Dto.Client;
using DiplomaProject.Backend.Common.Models.Dto.Order;
using DiplomaProject.Backend.Common.Models.Entity;

namespace DiplomaProject.Backend.BuisnessLayer.InterfacesAndServices.Interfaces
{
    public interface IOrderService
    {
        Task CreateAsync(OrderPostDto shop);
        Task RemoveAsync(Guid id);
        Task UpdateAsync(Guid id, OrderPostDto editedOrder);
        Task<List<OrderPostDto>> GetAllAsync();
        Task<OrderPostDto> FindByIdAsync(Guid id);
    }
}
