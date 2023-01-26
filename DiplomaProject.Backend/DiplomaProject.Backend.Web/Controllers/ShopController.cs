using DiplomaProject.Backend.BuisnessLayer.InterfacesAndServices.Interfaces;
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

        //[HttpGet("GetShop")]
        //[AllowAnonymous]
        //public IActionResult GetAsync(Func<ShopPostDto, bool> predicate)
        //{
        //    _shopService.GetAsync(predicate);
        //    return Ok();
        //}

        [HttpGet("GetAllShops")]
        [AllowAnonymous]
        public Task<List<ShopPostDto>> GetAllAsync()
        {
            var shops = _shopService.GetAllAsync();
            return shops;
        }

        [HttpPost("CreateShop")]
        [AllowAnonymous]
        public IActionResult CreateAsync(ShopPostDto shopPostDto)
        {
            _shopService.CreateAsync(shopPostDto);
            return Ok();
        }

        [HttpDelete("DeleteShop")]
        [AllowAnonymous]
        public IActionResult Remove(ShopPostDto shopPostDto)
        {
            _shopService.Remove(shopPostDto);
            return Ok();
        }

        [HttpPut("UpdateShop")]
        [AllowAnonymous]
        public IActionResult Update(ShopPostDto shopPostDto)
        {
            _shopService.Update(shopPostDto);
            return Ok();
        }

        [HttpGet("FindShop")]
        [AllowAnonymous]
        public async Task<ShopPostDto> FindByIdAsync(Guid id)
        {
            var shopDto = await _shopService.FindById(id);
            if (shopDto == null)
                return null;

            return shopDto;
        }
    }
}
