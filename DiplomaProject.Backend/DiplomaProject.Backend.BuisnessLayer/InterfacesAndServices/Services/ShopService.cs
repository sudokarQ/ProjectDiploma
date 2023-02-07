using DiplomaProject.Backend.BuisnessLayer.InterfacesAndServices.Interfaces;
using DiplomaProject.Backend.Common.Models.Dto;
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

        public async Task<ShopGetDto> FindByIdAsync(IdDto dto)
        {
            var shop = await _shopRepository.FindByIdAsync(x => x.Id == dto.Id);

            return shop is null ? null : new ShopGetDto
            {
                Id = shop.Id,
                Name = shop.Name,
                Description = shop.Description,
                Adress = shop.Adress
            };

        }

        public async Task<List<ShopSearchGetDto>> GetListByNameAsync(ShopSearchGetDto dto)
        {
            var shops = await _shopRepository.GetAsync(x => x.Name.ToLower().StartsWith(dto.Name.ToLower()));

            return shops.Select(x => new ShopSearchGetDto
            {
                Id = x.Id,
                Name = x.Name,
            }).OrderBy(x => x.Name).ToList();
        }

        public async Task<List<ShopGetDto>> GetAllAsync()
            => (await _shopRepository.GetAllAsync()).Select(x => new ShopGetDto
            {
                Id = x.Id,
                Name = x.Name,
                Description = x.Description,
                Adress = x.Adress,
            }).ToList();

        public async Task RemoveAsync(IdDto dto)
        {
            var shop = await _shopRepository.FirstOrDefaultAsync(x => x.Id == dto.Id);
            await _shopRepository.RemoveAsync(shop);
        }

        public async Task UpdateAsync(ShopPutDto dto) //ShopPutDto создать, в ней ид, имя, описание, не сильно значимые поля.
        {
            var shop = await _shopRepository.FirstOrDefaultAsync(x => x.Id == dto.Id);

            if (shop is null || (shop.Name == dto.Name && shop.Description == dto.Description)) // проверка на совпадения всех полей - просто возвращать
                return;

            shop.Name = dto.Name ?? shop.Name;
            shop.Description = dto.Description ?? shop.Description;

            await _shopRepository.UpdateAsync(shop);
        }

        // атрибуты, fluentAPI, третий способ ниже. Для более сложных моделей валидация методом - оставить минимальную на логику, то что нельзя запихнуть в первые два.
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
