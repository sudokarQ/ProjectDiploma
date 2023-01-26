using DiplomaProject.Backend.Common.Models.Dto.Client;
using DiplomaProject.Backend.Common.Models.Dto.Shop;

namespace DiplomaProject.Backend.BuisnessLayer.InterfacesAndServices.Interfaces
{
    public interface IClientService
    {
        Task<List<ClientPostDto>> GetAsync(Func<ClientPostDto, bool> predicate);
        void CreateAsync(ClientPostDto shop);
        Task<ClientPostDto> FindById(Guid id);
        Task<ClientPostDto> FindByName(string name);
        void Remove(ClientPostDto item);
        void Update(ClientPostDto item);
        Task<List<ClientPostDto>> GetAllAsync();
    }
}
