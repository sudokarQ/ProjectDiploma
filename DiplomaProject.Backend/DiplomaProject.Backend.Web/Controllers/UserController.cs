using DiplomaProject.Backend.BuisnessLayer.InterfacesAndServices.Interfaces;
using DiplomaProject.Backend.Common.Models.Dto;
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
        public Task<List<UserGetDto>> GetAllAsync()
        {
            var users = _userService.GetAllAsync();
            return users;
        }

        [HttpGet("GetUsersByLogin")]
        [AllowAnonymous]
        public Task<List<UserSearchGetDto>> GetListByLogin(UserSearchGetDto dto)
        {
            var users = _userService.GetListByLoginAsync(dto);
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
        public async Task<IActionResult> Remove(IdDto dto)
        {
            await _userService.RemoveAsync(dto);
            return Ok();
        }

        [HttpPut("UpdateUser")]
        [AllowAnonymous]
        public async Task<IActionResult> Update(UserPutDto dto)
        {
            await _userService.UpdateAsync(dto);
            return Ok();
        }

        [HttpGet("FindUser")]
        [AllowAnonymous]
        public async Task<UserGetDto> FindByIdAsync(IdDto dto)
        {
            var clientDto = await _userService.FindByIdAsync(dto);
            return clientDto;
        }
    }
}

