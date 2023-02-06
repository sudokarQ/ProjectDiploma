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

        public async Task CreateAsync(PromotionPostDto promotion)
        {
            if (Validation(promotion))
                await _promotionRepository.CreateAsync(new()
                {
                    Id = new Guid(),
                    Name = promotion.Name,
                    Description = promotion.Description,
                    DiscountPercent = promotion.DiscountPercent,
                    IsCorporate = promotion.IsCorporate,
                    BeginDate = promotion.BeginDate,
                    EndDate = promotion.EndDate,
                    CompanyPercent = promotion.CompanyPercent,
                    //Service = promotion.ServiceId,
                });
            else
                throw new Exception("Validation declined");
        }

        public async Task<PromotionPostDto> FindById(Guid id)
        {
            var promotion = await _promotionRepository.FindByIdAsync(x => x.Id == id);
            if (promotion != null)
            {
                return new PromotionPostDto
                {
                    Id = id,
                    Name = promotion.Name,
                    Description = promotion.Description,
                    DiscountPercent = promotion.DiscountPercent,
                    IsCorporate = promotion.IsCorporate,
                };
            }
            return null;
        }


        public async Task<List<PromotionPostDto>> GetListByNameAsync(string name)
        {
            var clients = await _promotionRepository.GetAsync(x => x.Name.ToLower().StartsWith(name.ToLower()));

            return clients.Select(x => new PromotionPostDto
            {
                Id = x.Id,
                Name = x.Name,
                Description = x.Description,
                DiscountPercent = x.DiscountPercent,
                IsCorporate = x.IsCorporate,
                BeginDate = x.BeginDate,
                EndDate = x.EndDate,
                CompanyPercent = x.CompanyPercent,
                //Service = x.Service,
            }).OrderBy(x => x.Name).ThenBy(x => x.Description).ToList();
        }


        public async Task<List<PromotionPostDto>> GetAllAsync()
            => (await _promotionRepository.GetAllAsync()).Select(x => new PromotionPostDto
            {
                Id = x.Id,
                Name = x.Name,
                Description = x.Description,
                DiscountPercent = x.DiscountPercent,
                IsCorporate = x.IsCorporate,
            }).ToList();

        public async Task RemoveAsync(Guid id)
        {
            var promotion = await _promotionRepository.FirstOrDefaultAsync(x => x.Id == id);
            await _promotionRepository.RemoveAsync(promotion);
        }

        public async Task UpdateAsync(Guid id, PromotionPostDto editedPromotion)
        {
            var promotion = await _promotionRepository.FirstOrDefaultAsync(x => x.Id == id);

            if (promotion is null || !Validation(editedPromotion))
                return;

            promotion.Name = editedPromotion.Name;
            promotion.Description = editedPromotion.Description;
            promotion.DiscountPercent = editedPromotion.DiscountPercent;
            promotion.IsCorporate = editedPromotion.IsCorporate;

            await _promotionRepository.UpdateAsync(promotion);
        }

        private bool Validation(PromotionPostDto promotion)
        {
            if (string.IsNullOrEmpty(promotion.Name))
                return false;

            if (promotion.DiscountPercent < 0 || promotion.DiscountPercent > 100)
                return false;

            return true;
        }
    }
}
