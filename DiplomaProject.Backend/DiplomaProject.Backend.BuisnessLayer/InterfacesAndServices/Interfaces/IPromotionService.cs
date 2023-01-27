using DiplomaProject.Backend.Common.Models.Dto.Promotion;

namespace DiplomaProject.Backend.BuisnessLayer.InterfacesAndServices.Interfaces
{
    public interface IPromotionService
    {
        Task<List<PromotionPostDto>> GetAsync(Func<PromotionPostDto, bool> predicate);
        void CreateAsync(PromotionPostDto promotion);
        Task<PromotionPostDto> FindById(Guid id);
        Task<PromotionPostDto> FindByName(string name);
        void Remove(PromotionPostDto item);
        void Update(PromotionPostDto item);
        Task<List<PromotionPostDto>> GetAllAsync();
    }
}
