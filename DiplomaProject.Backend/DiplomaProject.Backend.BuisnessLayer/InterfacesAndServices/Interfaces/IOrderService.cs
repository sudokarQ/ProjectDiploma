using DiplomaProject.Backend.Common.Models.Dto;
using DiplomaProject.Backend.Common.Models.Dto.Order;

namespace DiplomaProject.Backend.BuisnessLayer.InterfacesAndServices.Interfaces
{
    public interface IOrderService
    {
        Task CreateAsync(OrderPostDto shop);
        Task RemoveAsync(IdDto dto);
        Task UpdateAsync(OrderPutDto dto);
        Task<List<OrderGetDto>> GetAllAsync();
        Task<OrderGetDto> FindByIdAsync(IdDto dto);
    }
}
