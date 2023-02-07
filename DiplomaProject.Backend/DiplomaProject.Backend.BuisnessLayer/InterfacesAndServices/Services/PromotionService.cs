using DiplomaProject.Backend.BuisnessLayer.InterfacesAndServices.Interfaces;
using DiplomaProject.Backend.Common.Models.Dto;
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
                    ServiceId = promotion.ServiceId,
                });
            else
                throw new Exception("Validation declined");
        }

        public async Task<PromotionGetDto> FindByIdAsync(IdDto dto)
        {
            var promotion = await _promotionRepository.FindByIdAsync(x => x.Id == dto.Id);

            return promotion is null ? null : new PromotionGetDto
            {
                Id = promotion.Id,
                Name = promotion.Name,
                Description = promotion.Description,
                BeginDate = promotion.BeginDate,
                EndDate = promotion.EndDate,
                DiscountPercent = promotion.DiscountPercent,
                IsCorporate = promotion.IsCorporate,
                CompanyPercent = promotion.CompanyPercent,
                ServiceId = promotion.ServiceId,
            };
        }


        public async Task<List<PromotionSearchGetDto>> GetListByNameAsync(PromotionSearchGetDto dto)
        {
            var clients = await _promotionRepository.GetAsync(x => x.Name.ToLower().StartsWith(dto.Name.ToLower()));

            return clients.Select(x => new PromotionSearchGetDto
            {
                Id = x.Id,
                Name = x.Name,
                ServiceId = x.ServiceId,
            }).OrderBy(x => x.Name).ToList();
        }


        public async Task<List<PromotionGetDto>> GetAllAsync()
            => (await _promotionRepository.GetAllAsync()).Select(promotion => new PromotionGetDto
            {
                Id = promotion.Id,
                Name = promotion.Name,
                Description = promotion.Description,
                BeginDate = promotion.BeginDate,
                EndDate = promotion.EndDate,
                DiscountPercent = promotion.DiscountPercent,
                IsCorporate = promotion.IsCorporate,
                CompanyPercent = promotion.CompanyPercent,
                ServiceId = promotion.ServiceId,
            }).ToList();

        public async Task RemoveAsync(IdDto dto)
        {
            var promotion = await _promotionRepository.FirstOrDefaultAsync(x => x.Id == dto.Id);
            await _promotionRepository.RemoveAsync(promotion);
        }

        public async Task UpdateAsync(PromotionPutDto dto)
        {
            var promotion = await _promotionRepository.FirstOrDefaultAsync(x => x.Id == dto.Id);

            if (promotion is null)
                return;

            //Валидация?

            promotion.Name = dto.Name ?? promotion.Name;
            promotion.Description = dto.Description ?? promotion.Description;
            promotion.DiscountPercent = dto.DiscountPercent ?? promotion.DiscountPercent;
            promotion.IsCorporate = dto.IsCorporate ?? promotion.IsCorporate;
            promotion.CompanyPercent = dto.CompanyPercent ?? promotion.CompanyPercent;
            promotion.BeginDate = dto.BeginDate ?? promotion.BeginDate;
            promotion.EndDate = dto.EndDate ?? promotion.EndDate;
            promotion.ServiceId = dto.ServiceId ?? promotion.ServiceId;

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
