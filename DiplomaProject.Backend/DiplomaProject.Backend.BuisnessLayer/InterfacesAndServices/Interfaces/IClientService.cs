using DiplomaProject.Backend.Common.Models.Dto.Client;
using DiplomaProject.Backend.Common.Models.Entity;
using System.Linq.Expressions;

namespace DiplomaProject.Backend.BuisnessLayer.InterfacesAndServices.Interfaces
{
    public interface IClientService
    {
        Task<List<ClientPostDto>> GetAsync();
        Task CreateAsync(ClientPostDto client);
        Task<ClientPostDto> FindByIdAsync(Guid id);
        Task<ClientPostDto> FindByNameAsync(string name);
        Task RemoveAsync(Guid id);
        Task UpdateAsync(Guid id, ClientPostDto editedClient);
        Task<List<ClientPostDto>> GetAllAsync();
    }
}
