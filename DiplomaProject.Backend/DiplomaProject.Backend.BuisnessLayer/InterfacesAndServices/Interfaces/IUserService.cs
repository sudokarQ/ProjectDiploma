using DiplomaProject.Backend.Common.Models.Dto;
using DiplomaProject.Backend.Common.Models.Dto.User;

namespace DiplomaProject.Backend.BuisnessLayer.InterfacesAndServices.Interfaces
{
    public interface IUserService
    {
        Task CreateAsync(UserPostDto user);
        Task<UserGetDto> FindByIdAsync(IdDto dto);
        Task<List<UserSearchGetDto>> GetListByLoginAsync(UserSearchGetDto dto);
        Task RemoveAsync(IdDto dto);
        Task UpdateAsync(UserPutDto dto);
        Task<List<UserGetDto>> GetAllAsync();
    }
}
