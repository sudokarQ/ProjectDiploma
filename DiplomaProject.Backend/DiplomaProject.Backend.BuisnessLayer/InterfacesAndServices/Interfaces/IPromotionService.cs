using DiplomaProject.Backend.Common.Models.Dto.Promotion;

namespace DiplomaProject.Backend.BuisnessLayer.InterfacesAndServices.Interfaces
{
    public interface IPromotionService
    {
        Task CreateAsync(PromotionPostDto promotion);
        Task<PromotionPostDto> FindById(Guid id);
        Task<PromotionPostDto> FindByName(string name);
        Task RemoveAsync(Guid id);
        Task UpdateAsync(Guid id, PromotionPostDto editedPromotion);
        Task<List<PromotionPostDto>> GetAllAsync();
    }
}
