using DiplomaProject.Backend.Common.Models.Dto.Service;

namespace DiplomaProject.Backend.BuisnessLayer.InterfacesAndServices.Interfaces
{
    public interface IServiceService
    {
        Task CreateAsync(ServicePostDto service);
        Task<ServicePostDto> FindByIdAsync(Guid id);
        Task<ServicePostDto> FindByNameAsync(string name);
        Task RemoveAsync(Guid id);
        Task UpdateAsync(Guid id, ServicePostDto editedService);
        Task<List<ServicePostDto>> GetAllAsync();
    }
}
