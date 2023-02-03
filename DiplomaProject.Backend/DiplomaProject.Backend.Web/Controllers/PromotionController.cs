﻿using DiplomaProject.Backend.BuisnessLayer.InterfacesAndServices.Interfaces;
using DiplomaProject.Backend.BuisnessLayer.InterfacesAndServices.Services;
using DiplomaProject.Backend.Common.Models.Dto.Client;
using DiplomaProject.Backend.Common.Models.Dto.Promotion;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace DiplomaProject.Backend.Web.Controllers
{
    public class PromotionController : Controller
    {
        private readonly IPromotionService _promotionService;

        public PromotionController(IPromotionService promotionService)
        {
            _promotionService = promotionService;
        }


        [HttpGet("GetAllpromotions")]
        [AllowAnonymous]
        public Task<List<PromotionPostDto>> GetAllAsync()
        {
            var promotions = _promotionService.GetAllAsync();
            return promotions;
        }

        [HttpGet("GetPromotionsByName")]
        [AllowAnonymous]
        public Task<List<PromotionPostDto>> GetListByName(string name)
        {
            var promotions = _promotionService.GetListByNameAsync(name);
            return promotions;
        }

        [HttpPost("CreatePromotion")]
        [AllowAnonymous]
        public async Task<IActionResult> CreateAsync(PromotionPostDto PromotionPostDto)
        {
            await _promotionService.CreateAsync(PromotionPostDto);
            return Ok();
        }

        [HttpDelete("DeletePromotion")]
        [AllowAnonymous]
        public async Task<IActionResult> Remove(Guid id)
        {
            await _promotionService.RemoveAsync(id);
            return Ok();
        }

        [HttpPut("UpdatePromotion")]
        [AllowAnonymous]
        public async Task<IActionResult> Update(Guid id, PromotionPostDto editedPromotion)
        {
            await _promotionService.UpdateAsync(id, editedPromotion);
            return Ok();
        }

        [HttpGet("FindPromotion")]
        [AllowAnonymous]
        public async Task<PromotionPostDto> FindByIdAsync(Guid id)
        {
            var PromotionDto = await _promotionService.FindById(id);
            if (PromotionDto == null)
                return null;

            return PromotionDto;
        }
    }
}
