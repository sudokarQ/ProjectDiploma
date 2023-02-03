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

        public async Task<UserPostDto> FindByIdAsync(Guid id)
        {
            var user = await _userRepository.FindByIdAsync(x => x.Id == id);
            return user is null ? null : new UserPostDto
            {
                Id = user.Id,
                Login = user.Login,
                Password = user.Password,
            };
        }

        public async Task<UserPostDto> FindByLoginAsync(string login)
        {
            var user = await _userRepository.FindByLoginAsync(login);
            return user is null ? null : new UserPostDto
            {   Id = user.Id,
                Login = user.Login,
                Password = user.Password,
            }!;
        }

        public async Task<List<UserPostDto>> GetAllAsync()
            => (await _userRepository.GetAllAsync()).Select(x => new UserPostDto
            {
                Id = x.Id,
                Login = x.Login,
                Password = x.Password,
            }).ToList();

        public async Task RemoveAsync(Guid id)
        {
            var user = await _userRepository.FirstOrDefaultAsync(x => x.Id == id);
            await _userRepository.RemoveAsync(user);
        }

        public async Task UpdateAsync(Guid id, UserPostDto editedUser)
        {
            var user = await _userRepository.FirstOrDefaultAsync(x => x.Id == id);

            if (user is null)
                return;

            if (!await Validation(editedUser))
                throw new Exception("Validation declined");

            user.Login = editedUser.Login;
            user.Password = editedUser.Password;

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
