using DiplomaProject.Backend.Common.Models.Dto;
using DiplomaProject.Backend.Common.Models.Dto.Promotion;

namespace DiplomaProject.Backend.BuisnessLayer.InterfacesAndServices.Interfaces
{
    public interface IPromotionService
    {
        Task CreateAsync(PromotionPostDto promotion);
        Task<List<PromotionSearchGetDto>> GetListByNameAsync(PromotionSearchGetDto dto);
        Task<PromotionGetDto> FindByIdAsync(IdDto dto);
        Task RemoveAsync(IdDto dto);
        Task UpdateAsync(PromotionPutDto dto);
        Task<List<PromotionGetDto>> GetAllAsync();
    }
}
