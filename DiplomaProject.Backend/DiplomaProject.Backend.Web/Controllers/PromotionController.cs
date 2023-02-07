using DiplomaProject.Backend.BuisnessLayer.InterfacesAndServices.Interfaces;
using DiplomaProject.Backend.Common.Models.Dto;
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
        public Task<List<PromotionGetDto>> GetAllAsync()
        {
            var promotions = _promotionService.GetAllAsync();
            return promotions;
        }

        [HttpGet("GetPromotionsByName")]
        [AllowAnonymous]
        public Task<List<PromotionSearchGetDto>> GetListByName(PromotionSearchGetDto dto)
        {
            var promotions = _promotionService.GetListByNameAsync(dto);
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
        public async Task<IActionResult> Remove(IdDto dto)
        {
            await _promotionService.RemoveAsync(dto);
            return Ok();
        }

        [HttpPut("UpdatePromotion")]
        [AllowAnonymous]
        public async Task<IActionResult> Update(PromotionPutDto dto)
        {
            await _promotionService.UpdateAsync(dto);
            return Ok();
        }

        [HttpGet("FindPromotion")]
        [AllowAnonymous]
        public async Task<PromotionGetDto> FindByIdAsync(IdDto dto)
        {
            var PromotionDto = await _promotionService.FindByIdAsync(dto);
            if (PromotionDto == null)
                return null;

            return PromotionDto;
        }
    }
}
