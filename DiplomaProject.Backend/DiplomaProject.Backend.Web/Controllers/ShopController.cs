using DiplomaProject.Backend.BuisnessLayer.InterfacesAndServices.Interfaces;
using DiplomaProject.Backend.Common.Models.Dto.Shop;
using DiplomaProject.Backend.Common.Models.Entity;
using DiplomaProject.Backend.DataLayer.GenericRepository;
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

        [HttpPost("CreateShop")]
        [AllowAnonymous]
        public IActionResult CreateAsync(ShopPostDto shopPostDto)
        {
            _shopService.CreateAsync(shopPostDto);
            return Ok();
        }
    }
}
