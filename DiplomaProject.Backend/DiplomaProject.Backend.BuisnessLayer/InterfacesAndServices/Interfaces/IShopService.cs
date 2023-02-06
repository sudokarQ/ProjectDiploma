using DiplomaProject.Backend.Common.Models.Dto;
using DiplomaProject.Backend.Common.Models.Dto.Shop;

namespace DiplomaProject.Backend.BuisnessLayer.InterfacesAndServices.Interfaces
{
    public interface IShopService
    {
        Task CreateAsync(ShopPostDto shop);
        Task<ShopGetDto> FindByIdAsync(IdDto dto);
        Task<List<ShopSearchGetDto>> GetListByNameAsync(ShopSearchGetDto dto);
        Task RemoveAsync(IdDto dto);
        Task UpdateAsync(ShopPutDto dto);
        Task<List<ShopGetDto>> GetAllAsync();
    }
}
