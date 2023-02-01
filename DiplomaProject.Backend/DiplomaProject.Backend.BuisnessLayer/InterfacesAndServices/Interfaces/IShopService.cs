using DiplomaProject.Backend.Common.Models.Dto.Shop;

namespace DiplomaProject.Backend.BuisnessLayer.InterfacesAndServices.Interfaces
{
    public interface IShopService
    {
        Task<List<ShopPostDto>> GetAsync(Func<ShopPostDto, bool> predicate);
        Task CreateAsync(ShopPostDto shop);
        Task<ShopPostDto> FindById(Guid id);
        Task<ShopPostDto> FindByName(string name);
        Task Remove(ShopPostDto item);
        Task Update(ShopPostDto item);
        Task<List<ShopPostDto>> GetAllAsync();
    }
}
