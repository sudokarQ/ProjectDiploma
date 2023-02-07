using DiplomaProject.Backend.BuisnessLayer.InterfacesAndServices.Interfaces;
using DiplomaProject.Backend.Common.Models.Dto;
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


        [HttpGet("GetAllOrders")]
        [AllowAnonymous]
        public async Task<List<OrderGetDto>> GetAllAsync()
        {
            var orders = await _orderService.GetAllAsync();
            return orders;
        }

        [HttpPost("CreateOrder")]
        [AllowAnonymous]
        public async Task<IActionResult> CreateAsync(OrderPostDto orderPostDto)
        {
            await _orderService.CreateAsync(orderPostDto);
            return Ok();
        }

        [HttpDelete("DeleteOrder")]
        [AllowAnonymous]
        public async Task<IActionResult> Remove(IdDto dto)
        {
            await _orderService.RemoveAsync(dto);
            return Ok();
        }

        [HttpPut("UpdateOrder")]
        [AllowAnonymous]
        public async Task<IActionResult> Update(OrderPutDto dto)
        {
            await _orderService.UpdateAsync(dto);
            return Ok();
        }

        [HttpGet("FindOrder")]
        [AllowAnonymous]
        public async Task<OrderGetDto> FindByIdAsync(IdDto dto)
        {
            var orderDto = await _orderService.FindByIdAsync(dto);
            return orderDto;
        }
    }
}
