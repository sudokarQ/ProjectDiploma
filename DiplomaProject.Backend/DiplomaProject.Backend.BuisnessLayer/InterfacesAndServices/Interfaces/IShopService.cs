using DiplomaProject.Backend.Common.Models.Dto.Shop;

namespace DiplomaProject.Backend.BuisnessLayer.InterfacesAndServices.Interfaces
{
    public interface IShopService
    {
        Task CreateAsync(ShopPostDto shop);
        Task<ShopPostDto> FindByIdAsync(Guid id);
        Task<List<ShopPostDto>> GetListByNameAsync(string name);
        Task RemoveAsync(Guid id);
        Task UpdateAsync(Guid id, ShopPostDto editedShop);
        Task<List<ShopPostDto>> GetAllAsync();
    }
}
