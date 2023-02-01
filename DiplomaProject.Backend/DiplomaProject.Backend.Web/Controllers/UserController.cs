using DiplomaProject.Backend.BuisnessLayer.InterfacesAndServices.Interfaces;
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

        //[HttpGet("GetShop")]
        //[AllowAnonymous]
        //public IActionResult GetAsync(Func<ShopPostDto, bool> predicate)
        //{
        //    _shopService.GetAsync(predicate);
        //    return Ok();
        //}

        [HttpGet("GetAllUsers")]
        [AllowAnonymous]
        public Task<List<UserPostDto>> GetAllAsync()
        {
            var users = _userService.GetAllAsync();
            return users;
        }

        [HttpPost("CreateUser")]
        [AllowAnonymous]
        public IActionResult CreateAsync(UserPostDto UserPostDto)
        {
            _userService.CreateAsync(UserPostDto);
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

