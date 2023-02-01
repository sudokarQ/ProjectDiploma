using DiplomaProject.Backend.Common.Models.Dto.User;

namespace DiplomaProject.Backend.BuisnessLayer.InterfacesAndServices.Interfaces
{
    public interface IUserService
    {
        Task<List<UserPostDto>> GetAsync(Func<UserPostDto, bool> predicate);
        Task CreateAsync(UserPostDto user);
        Task<UserPostDto> FindByIdAsync(Guid id);
        Task<UserPostDto> FindByLoginAsync(string login);
        Task RemoveAsync(Guid id);
        Task UpdateAsync(Guid id, UserPostDto editedUser);
        Task<List<UserPostDto>> GetAllAsync();
    }
}
