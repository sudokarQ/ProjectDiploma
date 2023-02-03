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

        public async Task CreateAsync(ShopPostDto shop)
        {
            if (Validation(shop))
                await _shopRepository.CreateAsync(new()
                {
                    Id = new Guid(),
                    Name = shop.Name,
                    Description = shop.Description,
                    Adress = shop.Adress,
                });
            else
                throw new Exception("Validation declined");
        }

        public async Task<ShopPostDto> FindByIdAsync(Guid id)
        {
            var shop = await _shopRepository.FindByIdAsync(x => x.Id == id);
            if (shop is not null)
            {
                return new ShopPostDto 
                { 
                    Id = shop.Id,
                    Name = shop.Name, 
                    Description = shop.Description, 
                    Adress = shop.Adress
                };
            }
            return null;
        }

        public async Task<List<ShopPostDto>> GetListByNameAsync(string name)
        {
            var shops = await _shopRepository.GetAsync(x => x.Name.ToLower().StartsWith(name.ToLower()));

            return shops.Select(x => new ShopPostDto
            {
                Id = x.Id,
                Name = x.Name,
                Description = x.Description,
                Adress = x.Adress,
            }).OrderBy(x => x.Name).ThenBy(x => x.Description).ToList();
        }

        public async Task<List<ShopPostDto>> GetAllAsync()
            => (await _shopRepository.GetAllAsync()).Select(x => new ShopPostDto
            {
                Id = x.Id,
                Name = x.Name,
                Description = x.Description,
                Adress = x.Adress,
            }).ToList();

        public async Task RemoveAsync(Guid id)
        {
            var shop = await _shopRepository.FirstOrDefaultAsync(x => x.Id == id);
            await _shopRepository.RemoveAsync(shop);
        }

        public async Task UpdateAsync(Guid id, ShopPostDto editedShop)
        {
            var shop =  await _shopRepository.FirstOrDefaultAsync(x => x.Id == id);

            if (shop is null || !Validation(editedShop))
                return;

            shop.Name = editedShop.Name;
            shop.Description = editedShop.Description;
            shop.Adress = editedShop.Adress;

            await _shopRepository.UpdateAsync(shop);
        }

        private bool Validation(ShopPostDto shop)
        {
            if (string.IsNullOrEmpty(shop.Name))
                return false;

            //if (_shopRepository.FirstOrDefaultAsync(x => x.Name == shop.Name) is not null)
            //    return false;

            return true;
        }
    }
}
