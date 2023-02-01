using DiplomaProject.Backend.BuisnessLayer.InterfacesAndServices.Interfaces;
using DiplomaProject.Backend.Common.Models.Dto.Client;
using DiplomaProject.Backend.Common.Models.Dto.Shop;
using DiplomaProject.Backend.Common.Models.Entity;
using DiplomaProject.Backend.DataLayer.Repositories.Interfaces;
using DiplomaProject.Backend.DataLayer.Repositories.Repos;

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
                });
            else
                throw new Exception("Validation declined");
        }

        public async Task<ShopPostDto> FindById(Guid id)
        {
            var shop = await _shopRepository.FindByIdAsync(id);
            if (shop is not null)
            {
                return new ShopPostDto 
                { 
                    Name = shop.Name, 
                    Description = shop.Description 
                };
            }
            return null;
        }

        public async Task<ShopPostDto> FindByName(string name)
        {
            var shop = await _shopRepository.FindByNameAsync(name);
            if (shop != null)
            {
                return new ShopPostDto
                {
                    Name = shop.Name,
                    Description = shop.Description
                };
            }

            return null;
        }

        public async Task<List<ShopPostDto>> GetAsync(Func<ShopPostDto, bool> predicate)
        {
            var shops = await _shopRepository.GetAsync(x => x.Name == "123");
            return shops.Select(x => new ShopPostDto
            {
                Name = x.Name,
                Description = x.Description
            }).ToList();
        }

        public async Task<List<ShopPostDto>> GetAllAsync()
        {
            var shops = await _shopRepository.GetAllAsync();
            return shops.Select(x => new ShopPostDto { Name = x.Name, Description = x.Description }).ToList();
        }

        public async Task Remove(ShopPostDto shopDto)
        {
            var shop = await _shopRepository.FirstOrDefaultAsync(x => x.Name == shopDto.Name);
            await _shopRepository.RemoveAsync(shop);
        }

        public async Task Update(ShopPostDto shopDto) //дописать
        {
            var shop =  await _shopRepository.FirstOrDefaultAsync(x => x.Name == shopDto.Name);
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
