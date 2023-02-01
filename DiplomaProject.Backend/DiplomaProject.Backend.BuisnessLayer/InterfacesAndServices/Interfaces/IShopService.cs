using DiplomaProject.Backend.Common.Models.Dto.Shop;

namespace DiplomaProject.Backend.BuisnessLayer.InterfacesAndServices.Interfaces
{
    public interface IShopService
    {
        Task<List<ShopPostDto>> GetAsync(Func<ShopPostDto, bool> predicate);
        Task CreateAsync(ShopPostDto shop);
        Task<ShopPostDto> FindByIdAsync(Guid id);
        Task<ShopPostDto> FindByNameAsync(string name);
        Task RemoveAsync(Guid id);
        Task Update(Guid id);
        Task<List<ShopPostDto>> GetAllAsync();
    }
}
