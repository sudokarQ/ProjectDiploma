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

        public void CreateAsync(PromotionPostDto promotion) //потом на таски заменить
        {
            if (Validation(promotion))
                _promotionRepository.CreateAsync(new()
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
            var promotions = await _promotionRepository.GetAsync();
            return promotions.Select(x => new PromotionPostDto
            {
                Name = x.Name,
                Description = x.Description,
                DiscountPercent = x.DiscountPercent,
                IsCorporate = x.IsCorporate,
            }).ToList();
        }

        public void Remove(PromotionPostDto promotionDto)
        {
            var promotion = _promotionRepository.FirstOrDefault(x => x.Name == promotionDto.Name);
            _promotionRepository.RemoveAsync(promotion);
        }

        public void Update(PromotionPostDto promotionDto)
        {
            var promotion = _promotionRepository.FirstOrDefault(x => x.Name == promotionDto.Name);
            _promotionRepository.UpdateAsync(promotion);
        }

        private bool Validation(PromotionPostDto promotion)
        {
            if (string.IsNullOrEmpty(promotion.Name))
                return false;

            if (_promotionRepository.Find(x => x.Name == promotion.Name).Any())
                return false;

            return true;
        }
    }
}
