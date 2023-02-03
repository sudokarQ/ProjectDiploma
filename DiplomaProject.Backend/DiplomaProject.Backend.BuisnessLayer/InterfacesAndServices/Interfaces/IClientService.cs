using DiplomaProject.Backend.Common.Models.Dto.Client;

namespace DiplomaProject.Backend.BuisnessLayer.InterfacesAndServices.Interfaces
{
    public interface IClientService
    {
        Task CreateAsync(ClientPostDto client);
        Task<ClientPostDto> FindByIdAsync(Guid id);
        Task RemoveAsync(Guid id);
        Task UpdateAsync(Guid id, ClientPostDto editedClient);
        Task<List<ClientPostDto>> GetAllAsync();
        Task<List<ClientPostDto>> GetListByNameAsync(string name);
    }
}
