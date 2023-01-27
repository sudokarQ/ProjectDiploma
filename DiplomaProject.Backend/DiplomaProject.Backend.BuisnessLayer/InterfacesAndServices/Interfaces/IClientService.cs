using DiplomaProject.Backend.Common.Models.Dto.Client;

namespace DiplomaProject.Backend.BuisnessLayer.InterfacesAndServices.Interfaces
{
    public interface IClientService
    {
        Task<List<ClientPostDto>> GetAsync(Func<ClientPostDto, bool> predicate);
        Task CreateAsync(ClientPostDto client);
        Task<ClientPostDto> FindByIdAsync(Guid id);
        Task<ClientPostDto> FindByNameAsync(string name);
        Task RemoveAsync(ClientPostDto item);
        Task UpdateAsync(ClientPostDto item);
        Task<List<ClientPostDto>> GetAllAsync();
    }
}
