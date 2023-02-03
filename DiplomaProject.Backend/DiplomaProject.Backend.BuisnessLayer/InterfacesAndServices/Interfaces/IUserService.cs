using DiplomaProject.Backend.Common.Models.Dto.User;

namespace DiplomaProject.Backend.BuisnessLayer.InterfacesAndServices.Interfaces
{
    public interface IUserService
    {
        Task CreateAsync(UserPostDto user);
        Task<UserPostDto> FindByIdAsync(Guid id);
        Task<List<UserPostDto>> GetListByLoginAsync(string name);
        Task RemoveAsync(Guid id);
        Task UpdateAsync(Guid id, UserPostDto editedUser);
        Task<List<UserPostDto>> GetAllAsync();
    }
}
