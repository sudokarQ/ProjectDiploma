using DiplomaProject.Backend.Common.Models.Dto;
using DiplomaProject.Backend.Common.Models.Dto.Client;

namespace DiplomaProject.Backend.BuisnessLayer.InterfacesAndServices.Interfaces
{
    public interface IClientService
    {
        Task CreateAsync(ClientPostDto client);
        Task<ClientGetDto> FindByIdAsync(IdDto dto);
        Task RemoveAsync(IdDto dto);
        Task UpdateAsync(ClientPutDto dto);
        Task<List<ClientGetDto>> GetAllAsync();
        Task<List<ClientSearchGetDto>> GetListByNameAsync(ClientSearchGetDto dto);
    }
}
