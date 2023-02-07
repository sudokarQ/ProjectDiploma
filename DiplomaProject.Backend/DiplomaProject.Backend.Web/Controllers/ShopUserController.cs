using DiplomaProject.Backend.BuisnessLayer.InterfacesAndServices.Interfaces;
using DiplomaProject.Backend.Common.Models.Dto;
using DiplomaProject.Backend.Common.Models.Dto.ShopUser;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace DiplomaProject.Backend.Web.Controllers
{
    public class ShopUserController : Controller
    {
        private readonly IShopUserService _shopUserService;

        public ShopUserController(IShopUserService shopUserService)
        {
            _shopUserService = shopUserService;
        }


        [HttpGet("GetAllShopUsers")]
        [AllowAnonymous]
        public async Task<List<ShopUserGetDto>> GetAllAsync()
        {
            var shopUsers = await _shopUserService.GetAllAsync();
            return shopUsers;
        }


        [HttpPost("CreateShopUser")]
        [AllowAnonymous]
        public async Task<IActionResult> CreateAsync(ShopUserPostDto shopUserPostDto)
        {
            await _shopUserService.CreateAsync(shopUserPostDto);
            return Ok();
        }

        [HttpDelete("DeleteShopUser")]
        [AllowAnonymous]
        public async Task<IActionResult> Remove(IdDto dto)
        {
            await _shopUserService.RemoveAsync(dto);
            return Ok();
        }

        [HttpGet("FindShopUser")]
        [AllowAnonymous]
        public async Task<ShopUserGetDto> FindByIdAsync(IdDto dto)
        {
            var shopUserDto = await _shopUserService.FindByIdAsync(dto);
            return shopUserDto;
        }
    }
}
