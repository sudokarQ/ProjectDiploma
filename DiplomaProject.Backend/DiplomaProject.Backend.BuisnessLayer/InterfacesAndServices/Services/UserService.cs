using DiplomaProject.Backend.BuisnessLayer.InterfacesAndServices.Interfaces;
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
            if (Validation(user))
                await _userRepository.CreateAsync(new()
                {
                    Id = new Guid(),
                    Login = user.Login,
                    Password = user.Password,
                });
            else
                throw new Exception("Validation declined");
        }

        public async Task<UserPostDto> FindByIdAsync(Guid id)
        {
            var user = await _userRepository.FindByIdAsync(id);
            return user is null ? null : new UserPostDto
            {
                Login = user.Login,
                Password = user.Password,
            };
        }

        public async Task<UserPostDto> FindByLoginAsync(string login)
        {
            var user = await _userRepository.FindByLoginAsync(login);
            return user is null ? null : new UserPostDto
            {
                Login = user.Login,
                Password = user.Password,
            }!;
        }

        public Task<List<UserPostDto>> GetAsync(Func<UserPostDto, bool> predicate)
        {

            return null;
        }

        public async Task<List<UserPostDto>> GetAllAsync()
        {
            var users = await _userRepository.GetAsync();
            return users.Select(x => new UserPostDto
            {
                Login = x.Login,
                Password = x.Password,
            }).ToList();
        }

        public async Task RemoveAsync(UserPostDto userDto)
        {
            var user = _userRepository.FirstOrDefault(x => x.Login == userDto.Login);
            await _userRepository.RemoveAsync(user);
        }

        public async Task UpdateAsync(UserPostDto userDto)
        {
            var user = _userRepository.FirstOrDefault(x => x.Login == userDto.Login);
            await _userRepository.UpdateAsync(user);
        }

        private bool Validation(UserPostDto user)
        {
            if (string.IsNullOrEmpty(user.Login) || string.IsNullOrEmpty(user.Password))
                return false;

            if (_userRepository.Find(x => x.Login == user.Login).Any())
                return false;

            return true;
        }
    }
}
