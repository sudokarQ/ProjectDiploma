using DiplomaProject.Backend.BuisnessLayer.InterfacesAndServices.Interfaces;
using DiplomaProject.Backend.Common.Models.Dto.Client;
using DiplomaProject.Backend.Common.Models.Dto.Order;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace DiplomaProject.Backend.Web.Controllers
{
    public class OrderController : Controller
    {
        private readonly IOrderService _orderService;

        public OrderController(IOrderService orderService)
        {
            _orderService = orderService;
        }

        //[HttpGet("GetShop")]
        //[AllowAnonymous]
        //public IActionResult GetAsync(Func<ShopPostDto, bool> predicate)
        //{
        //    _shopService.GetAsync(predicate);
        //    return Ok();
        //}

        [HttpGet("GetAllOrders")]
        [AllowAnonymous]
        public Task<List<OrderPostDto>> GetAllAsync()
        {
            var orders = _orderService.GetAllAsync();
            return orders;
        }

        [HttpPost("CreateOrder")]
        [AllowAnonymous]
        public IActionResult CreateAsync(OrderPostDto orderPostDto)
        {
            _orderService.CreateAsync(orderPostDto);
            return Ok();
        }

        [HttpDelete("DeleteOrder")]
        [AllowAnonymous]
        public async Task<IActionResult> Remove(Guid id)
        {
            await _orderService.RemoveAsync(id);
            return Ok();
        }

        [HttpPut("UpdateOrder")]
        [AllowAnonymous]
        public async Task<IActionResult> Update(OrderPostDto orderPostDto)
        {
            await _orderService.UpdateAsync(orderPostDto);
            return Ok();
        }

        [HttpGet("FindOrder")]
        [AllowAnonymous]
        public async Task<OrderPostDto> FindByIdAsync(Guid id)
        {
            var orderDto = await _orderService.FindByIdAsync(id);
            return orderDto;
        }
    }
}
