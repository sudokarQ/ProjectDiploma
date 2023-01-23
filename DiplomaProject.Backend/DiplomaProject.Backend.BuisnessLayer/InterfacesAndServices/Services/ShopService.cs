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
                _genericRepository.Create(new()
                {
                    Id = new Guid(),
                    Name = shop.Name,
                    Description = shop.Description,
                });
            else
                throw new Exception("Validation declined");
        }

        public Task<Shop> GetAsync()
        {
            throw new NotImplementedException();
        }

        private bool Validation(ShopPostDto shop)
        {
            if (shop.Name == null)
                return false;

            return true;
        }
    }
}
