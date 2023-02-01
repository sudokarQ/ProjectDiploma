using DiplomaProject.Backend.BuisnessLayer.InterfacesAndServices.Interfaces;
using DiplomaProject.Backend.Common.Models.Dto.Promotion;
using DiplomaProject.Backend.DataLayer.Repositories.Interfaces;

namespace DiplomaProject.Backend.BuisnessLayer.InterfacesAndServices.Services
{
    public class PromotionService : IPromotionService
    {
        private readonly IPromotionRepository _promotionRepository;

        public PromotionService(IPromotionRepository promotionRepository)
        {
            _promotionRepository = promotionRepository;
        }

        public async Task CreateAsync(PromotionPostDto promotion) //потом на таски заменить
        {
            if (Validation(promotion))
                await _promotionRepository.CreateAsync(new()
                {
                    Id = new Guid(),
                    Name = promotion.Name,
                    Description = promotion.Description,
                    DiscountPercent = promotion.DiscountPercent,
                    IsCorporate = promotion.IsCorporate,
                });
            else
                throw new Exception("Validation declined");
        }

        public async Task<PromotionPostDto> FindById(Guid id)
        {
            var promotion = await _promotionRepository.FindByIdAsync(id);
            if (promotion != null)
            {
                return new PromotionPostDto
                {
                    Name = promotion.Name,
                    Description = promotion.Description,
                    DiscountPercent = promotion.DiscountPercent,
                    IsCorporate = promotion.IsCorporate,
                };
            }
            return null;
        }

        public async Task<PromotionPostDto> FindByName(string name)
        {
            var promotion = await _promotionRepository.FindByNameAsync(name);
            if (promotion != null)
            {
                return new PromotionPostDto
                {
                    Name = promotion.Name,
                    Description = promotion.Description,
                    DiscountPercent = promotion.DiscountPercent,
                    IsCorporate = promotion.IsCorporate,
                };
            }
            return null;
        }

        public Task<List<PromotionPostDto>> GetAsync(Func<PromotionPostDto, bool> predicate)
        {

            return null;
        }

        public async Task<List<PromotionPostDto>> GetAllAsync()
        {
            var promotions = await _promotionRepository.GetAllAsync();
            return promotions.Select(x => new PromotionPostDto
            {
                Name = x.Name,
                Description = x.Description,
                DiscountPercent = x.DiscountPercent,
                IsCorporate = x.IsCorporate,
            }).ToList();
        }

        public async Task RemoveAsync(Guid id)
        {
            var promotion = await _promotionRepository.FirstOrDefaultAsync(x => x.Id == id);
            await _promotionRepository.RemoveAsync(promotion);
        }

        public async Task Update(PromotionPostDto promotionDto)
        {
            var promotion = await _promotionRepository.FirstOrDefaultAsync(x => x.Name == promotionDto.Name);
            await _promotionRepository.UpdateAsync(promotion);
        }

        private bool Validation(PromotionPostDto promotion)
        {
            if (string.IsNullOrEmpty(promotion.Name))
                return false;

            return true;
        }
    }
}
