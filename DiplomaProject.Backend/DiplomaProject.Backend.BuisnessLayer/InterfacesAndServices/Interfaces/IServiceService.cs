using DiplomaProject.Backend.Common.Models.Dto;
using DiplomaProject.Backend.Common.Models.Dto.Service;

namespace DiplomaProject.Backend.BuisnessLayer.InterfacesAndServices.Interfaces
{
    public interface IServiceService
    {
        Task CreateAsync(ServicePostDto service);
        Task<ServiceGetDto> FindByIdAsync(IdDto dto);
        Task RemoveAsync(IdDto dto);
        Task UpdateAsync(ServicePutDto dto);
        Task<List<ServiceGetDto>> GetAllAsync();
        Task<List<ServiceSearchGetDto>> GetListByNameAsync(ServiceSearchGetDto dto);
        Task<List<ServiceSearchGetDto>> GetListByShopAsync(IdDto dto);
    }
}
