using DiplomaProject.Backend.Common.Models.Dto;
using DiplomaProject.Backend.Common.Models.Dto.ShopUser;

namespace DiplomaProject.Backend.BuisnessLayer.InterfacesAndServices.Interfaces
{
    public interface IShopUserService
    {
        Task CreateAsync(ShopUserPostDto shop);
        Task RemoveAsync(IdDto dto);
        Task<List<ShopUserGetDto>> GetAllAsync();
        Task<ShopUserGetDto> FindByIdAsync(IdDto dto);
    }
}
