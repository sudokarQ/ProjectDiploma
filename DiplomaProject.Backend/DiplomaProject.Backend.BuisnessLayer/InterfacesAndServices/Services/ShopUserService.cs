using DiplomaProject.Backend.BuisnessLayer.InterfacesAndServices.Interfaces;
using DiplomaProject.Backend.Common.Models.Dto;
using DiplomaProject.Backend.Common.Models.Dto.ShopUser;
using DiplomaProject.Backend.DataLayer.Repositories.Interfaces;

namespace DiplomaProject.Backend.BuisnessLayer.InterfacesAndServices.Services
{
    public class ShopUserService : IShopUserService
    {
        private readonly IShopUserRepository _shopUserRepository;

        public ShopUserService(IShopUserRepository shopUserRepository)
        {
            _shopUserRepository = shopUserRepository;
        }

        public async Task CreateAsync(ShopUserPostDto shopUser)
        {
            await _shopUserRepository.CreateAsync(new()
            {
                Id = new Guid(),
                ShopId = shopUser.ShopId,
                UserId = shopUser.UserId
            });
        }

        public async Task<List<ShopUserGetDto>> GetAllAsync()
            => (await _shopUserRepository.GetAllAsync()).Select(x => new ShopUserGetDto
            {
                Id = x.Id,
                ShopId = x.ShopId,
                UserId = x.UserId
            }).ToList();

        public async Task<ShopUserGetDto> FindByIdAsync(IdDto dto)
        {
            var service = await _shopUserRepository.FindByIdAsync(x => x.Id == dto.Id);
            return service is null ? null : new ShopUserGetDto
            {
                Id = service.Id,
                ShopId = service.ShopId,
                UserId = service.UserId
            };
        }

        public async Task RemoveAsync(IdDto dto)
        {
            var shop = await _shopUserRepository.FirstOrDefaultAsync(x => x.Id == dto.Id);
            await _shopUserRepository.RemoveAsync(shop);
        }
    }
}
