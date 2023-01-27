using DiplomaProject.Backend.BuisnessLayer.InterfacesAndServices.Interfaces;
using DiplomaProject.Backend.Common.Models.Dto.Shop;
using DiplomaProject.Backend.DataLayer.Repositories.Interfaces;

namespace DiplomaProject.Backend.BuisnessLayer.InterfacesAndServices.Services
{
    public class ShopService : IShopService
    {
        private readonly IShopRepository _shopRepository;
        
        public ShopService(IShopRepository shopRepository)
        {
            _shopRepository = shopRepository;
        }

        public void CreateAsync(ShopPostDto shop) //потом на таски заменить
        {
            if (Validation(shop))
                _shopRepository.CreateAsync(new()
                {
                    Id = new Guid(),
                    Name = shop.Name,
                    Description = shop.Description,
                });
            else
                throw new Exception("Validation declined");
        }

        public async Task<ShopPostDto> FindById(Guid id)
        {
            var shop = await _shopRepository.FindByIdAsync(id);
            if (shop != null)
            {
                return new ShopPostDto { Name = shop.Name, Description = shop.Description };
            }
            return null;
        }

        public async Task<ShopPostDto> FindByName(string name)
        {
            var shop = await _shopRepository.FindByNameAsync(name);
            if (shop != null)
            {
                return new ShopPostDto { Name = shop.Name, Description = shop.Description };
            }
            return null;
        }

        public Task<List<ShopPostDto>> GetAsync(Func<ShopPostDto, bool> predicate)
        {

            return null;
        }

        public async Task<List<ShopPostDto>> GetAllAsync()
        {
            var shops = await _shopRepository.GetAsync();
            return shops.Select(x => new ShopPostDto { Name = x.Name, Description = x.Description }).ToList();
        }

        public void Remove(ShopPostDto shopDto)
        {
            var shop = _shopRepository.FirstOrDefault(x => x.Name == shopDto.Name);
            _shopRepository.RemoveAsync(shop);
        }

        public void Update(ShopPostDto shopDto)
        {
            var shop = _shopRepository.FirstOrDefault(x => x.Name == shopDto.Name);
            _shopRepository.UpdateAsync(shop);
        }

        private bool Validation(ShopPostDto shop)
        {
            if (string.IsNullOrEmpty(shop.Name))
                return false;

            if (_shopRepository.Find(x => x.Name == shop.Name).Any())
                return false;

            return true;
        }
    }
}
