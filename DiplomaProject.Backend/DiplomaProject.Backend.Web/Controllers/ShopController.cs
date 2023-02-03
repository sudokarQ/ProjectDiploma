﻿using DiplomaProject.Backend.BuisnessLayer.InterfacesAndServices.Interfaces;
using DiplomaProject.Backend.BuisnessLayer.InterfacesAndServices.Services;
using DiplomaProject.Backend.Common.Models.Dto.Client;
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
        public Task<List<ShopPostDto>> GetAllAsync()
        {
            var shops = _shopService.GetAllAsync();
            return shops;
        }

        [HttpGet("GetShopsByName")]
        [AllowAnonymous]
        public Task<List<ShopPostDto>> GetListByName(string name)
        {
            var shops = _shopService.GetListByNameAsync(name);
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
        public async Task<IActionResult> Remove(Guid id)
        {
            await _shopService.RemoveAsync(id);
            return Ok();
        }

        [HttpPut("UpdateShop")]
        [AllowAnonymous]
        public async Task<IActionResult> Update(Guid id, ShopPostDto editedShop)
        {
            await _shopService.UpdateAsync(id, editedShop);
            return Ok();
        }

        [HttpGet("FindShop")]
        [AllowAnonymous]
        public async Task<ShopPostDto> FindByIdAsync(Guid id)
        {
            var shopDto = await _shopService.FindByIdAsync(id);
            if (shopDto is null)
                return null;

            return shopDto;
        }
    }
}
