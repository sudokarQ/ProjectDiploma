using DiplomaProject.Backend.BuisnessLayer.InterfacesAndServices.Interfaces;
using DiplomaProject.Backend.Common.Models.Dto.Shop;
using DiplomaProject.Backend.Common.Models.Entity;
using DiplomaProject.Backend.DataLayer.GenericRepository;

namespace DiplomaProject.Backend.BuisnessLayer.InterfacesAndServices.Services
{
    public class ShopService : IShopService
    {
        private readonly IGenericRepository<Shop> _genericRepository;
        
        public ShopService(IGenericRepository<Shop> genericRepository)
        {
            _genericRepository = genericRepository;
        }

        public void CreateAsync(ShopPostDto shop) //потом на таски заменить
        {
            if (Validation(shop))
                _genericRepository.CreateAsync(new()
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
            var shop = await _genericRepository.FindById(id);
            if (shop != null)
            {
                return new ShopPostDto { Name = shop.Name, Description = shop.Description };
            }
            return null;
        }

        public async Task<ShopPostDto> FindByName(string name)
        {
            var shop = await _genericRepository.FindByName(name);
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
            var shops = await _genericRepository.GetAsync();
            return shops.Select(x => new ShopPostDto { Name = x.Name, Description = x.Description }).ToList();
        }

        public void Remove(ShopPostDto shopDto)
        {
            var shop = _genericRepository.FirstOrDefault(x => x.Name == shopDto.Name);
            _genericRepository.Remove(shop);
        }

        public void Update(ShopPostDto shopDto)
        {
            var shop = _genericRepository.FirstOrDefault(x => x.Name == shopDto.Name);
            _genericRepository.Update(shop);
        }

        private bool Validation(ShopPostDto shop)
        {
            if (string.IsNullOrEmpty(shop.Name))
                return false;

            if (_genericRepository.Find(x => x.Name == shop.Name).Any())
                return false;

            return true;
        }
    }
}
