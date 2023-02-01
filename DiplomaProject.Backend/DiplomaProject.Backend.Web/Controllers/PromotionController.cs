using DiplomaProject.Backend.BuisnessLayer.InterfacesAndServices.Interfaces;
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

        //[HttpGet("GetPromotion")]
        //[AllowAnonymous]
        //public IActionResult GetAsync(Func<PromotionPostDto, bool> predicate)
        //{
        //    _promotionService.GetAsync(predicate);
        //    return Ok();
        //}

        [HttpGet("GetAllpromotions")]
        [AllowAnonymous]
        public Task<List<PromotionPostDto>> GetAllAsync()
        {
            var promotions = _promotionService.GetAllAsync();
            return promotions;
        }

        [HttpPost("CreatePromotion")]
        [AllowAnonymous]
        public IActionResult CreateAsync(PromotionPostDto PromotionPostDto)
        {
            _promotionService.CreateAsync(PromotionPostDto);
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
        public async Task<IActionResult> Update(PromotionPostDto PromotionPostDto)
        {
            await _promotionService.Update(PromotionPostDto);
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
