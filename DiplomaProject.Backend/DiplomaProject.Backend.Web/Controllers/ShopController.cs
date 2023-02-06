using DiplomaProject.Backend.BuisnessLayer.InterfacesAndServices.Interfaces;
using DiplomaProject.Backend.Common.Models.Dto;
using DiplomaProject.Backend.Common.Models.Dto.Shop;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace DiplomaProject.Backend.Web.Controllers
{
    public class ShopController : Controller
    {
        private readonly IShopService _shopService;

        public ShopController(IShopService shopService)
        {
            _shopService= shopService;
        }


        [HttpGet("GetAllShops")]
        [AllowAnonymous]
        public Task<List<ShopGetDto>> GetAllAsync()
        {
            var shops = _shopService.GetAllAsync();
            return shops;
        }

        [HttpGet("GetShopsByName")]
        [AllowAnonymous]
        public Task<List<ShopSearchGetDto>> GetListByName(ShopSearchGetDto dto)
        {
            var shops = _shopService.GetListByNameAsync(dto);
            return shops;
        }

        [HttpPost("CreateShop")]
        [AllowAnonymous]
        public async Task<IActionResult> CreateAsync(ShopPostDto shopPostDto)
        {
            await _shopService.CreateAsync(shopPostDto);
            return Ok();
        }

        [HttpDelete("DeleteShop")]
        [AllowAnonymous]
        public async Task<IActionResult> Remove(IdDto dto)
        {
            await _shopService.RemoveAsync(dto);
            return Ok();
        }

        [HttpPut("UpdateShop")]
        [AllowAnonymous]
        public async Task<IActionResult> Update(ShopPutDto editedShop)
        {
            await _shopService.UpdateAsync(editedShop);
            return Ok();
        }

        [HttpGet("FindShop")]
        [AllowAnonymous]
        public async Task<ShopGetDto> FindByIdAsync(IdDto dto)
        {
            var shopDto = await _shopService.FindByIdAsync(dto);
            if (shopDto is null)
                return null;

            return shopDto;
        }
    }
}
