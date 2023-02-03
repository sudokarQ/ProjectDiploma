using DiplomaProject.Backend.Common.Models.Dto.Client;
using DiplomaProject.Backend.Common.Models.Dto.Promotion;

namespace DiplomaProject.Backend.BuisnessLayer.InterfacesAndServices.Interfaces
{
    public interface IPromotionService
    {
        Task CreateAsync(PromotionPostDto promotion);
        Task<List<PromotionPostDto>> GetListByNameAsync(string name);
        Task<PromotionPostDto> FindById(Guid id);
        Task RemoveAsync(Guid id);
        Task UpdateAsync(Guid id, PromotionPostDto editedPromotion);
        Task<List<PromotionPostDto>> GetAllAsync();
    }
}
