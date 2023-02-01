using DiplomaProject.Backend.Common.Models.Dto.Promotion;

namespace DiplomaProject.Backend.BuisnessLayer.InterfacesAndServices.Interfaces
{
    public interface IPromotionService
    {
        Task<List<PromotionPostDto>> GetAsync(Func<PromotionPostDto, bool> predicate);
        Task CreateAsync(PromotionPostDto promotion);
        Task<PromotionPostDto> FindById(Guid id);
        Task<PromotionPostDto> FindByName(string name);
        Task RemoveAsync(Guid id);
        Task Update(PromotionPostDto item);
        Task<List<PromotionPostDto>> GetAllAsync();
    }
}
