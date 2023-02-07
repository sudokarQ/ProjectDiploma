using DiplomaProject.Backend.BuisnessLayer.InterfacesAndServices.Interfaces;
using DiplomaProject.Backend.Common.Models.Dto;
using DiplomaProject.Backend.Common.Models.Dto.User;
using DiplomaProject.Backend.DataLayer.Repositories.Interfaces;

namespace DiplomaProject.Backend.BuisnessLayer.InterfacesAndServices.Services
{
    public class UserService : IUserService
    {
        private readonly IUserRepository _userRepository;

        public UserService(IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }

        public async Task CreateAsync(UserPostDto user)
        {
            if (await Validation(user))
                await _userRepository.CreateAsync(new()
                {
                    Id = new Guid(),
                    Login = user.Login,
                    Password = user.Password,
                });
            else
                throw new Exception("Validation declined");
        }

        public async Task<UserGetDto> FindByIdAsync(IdDto dto)
        {
            var user = await _userRepository.FindByIdAsync(x => x.Id == dto.Id);
            return user is null ? null : new UserGetDto
            {
                Id = user.Id,
                Login = user.Login,
                Password = user.Password,
            };
        }

        public async Task<List<UserSearchGetDto>> GetListByLoginAsync(UserSearchGetDto dto)
        {
            var users = await _userRepository.GetAsync(x => x.Login.ToLower().StartsWith(dto.Login.ToLower()));

            return users.Select(x => new UserSearchGetDto
            {
                Id = x.Id,
                Login = x.Login,
            }).OrderBy(x => x.Login).ToList();
        }

        public async Task<List<UserGetDto>> GetAllAsync()
            => (await _userRepository.GetAllAsync()).Select(x => new UserGetDto
            {
                Id = x.Id,
                Login = x.Login,
                Password = x.Password,
            }).ToList();

        public async Task RemoveAsync(IdDto dto)
        {
            var user = await _userRepository.FirstOrDefaultAsync(x => x.Id == dto.Id);
            await _userRepository.RemoveAsync(user);
        }

        public async Task UpdateAsync(UserPutDto dto)
        {
            var user = await _userRepository.FirstOrDefaultAsync(x => x.Id == dto.Id);

            if (user is null || (user.Login == dto.Login && user.Password == dto.Password))
                return;

            //if (!await Validation(editedUser))
            //    throw new Exception("Validation declined");

            user.Login = dto.Login ?? user.Login;
            user.Password = dto.Password ?? user.Password;

            await _userRepository.UpdateAsync(user);
        }

        private async Task<bool> Validation(UserPostDto user)
        {
            if (string.IsNullOrEmpty(user.Login) || string.IsNullOrEmpty(user.Password))
                return false;

            bool isAny = await _userRepository.AnyAsync(x => x.Login == user.Login);

            if (isAny) 
                return false;

            return true;
        }
    }
}
