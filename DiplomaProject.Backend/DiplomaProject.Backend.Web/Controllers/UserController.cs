using DiplomaProject.Backend.BuisnessLayer.InterfacesAndServices.Interfaces;
using DiplomaProject.Backend.BuisnessLayer.InterfacesAndServices.Services;
using DiplomaProject.Backend.Common.Models.Dto.Client;
using DiplomaProject.Backend.Common.Models.Dto.User;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace DiplomaProject.Backend.Web.Controllers
{
    public class UserController : Controller
    {
        private readonly IUserService _userService;

        public UserController(IUserService userService)
        {
            _userService = userService;
        }


        [HttpGet("GetAllUsers")]
        [AllowAnonymous]
        public Task<List<UserPostDto>> GetAllAsync()
        {
            var users = _userService.GetAllAsync();
            return users;
        }

        [HttpGet("GetUsersByLogin")]
        [AllowAnonymous]
        public Task<List<UserPostDto>> GetListByLogin(string name)
        {
            var users = _userService.GetListByLoginAsync(name);
            return users;
        }

        [HttpPost("CreateUser")]
        [AllowAnonymous]
        public async Task<IActionResult> CreateAsync(UserPostDto UserPostDto)
        {
            await _userService.CreateAsync(UserPostDto);
            return Ok();
        }

        [HttpDelete("DeleteUser")]
        [AllowAnonymous]
        public async Task<IActionResult> Remove(Guid id)
        {
            await _userService.RemoveAsync(id);
            return Ok();
        }

        [HttpPut("UpdateUser")]
        [AllowAnonymous]
        public async Task<IActionResult> Update(Guid id, UserPostDto editedUser)
        {
            await _userService.UpdateAsync(id, editedUser);
            return Ok();
        }

        [HttpGet("FindUser")]
        [AllowAnonymous]
        public async Task<UserPostDto> FindByIdAsync(Guid id)
        {
            var clientDto = await _userService.FindByIdAsync(id);
            return clientDto;
        }
    }
}

